using TensorFlowLite;  
using UnityEngine;     
using UnityEngine.UI;  
using System.IO;       
using System.Collections.Generic;  
using System;          
using UnityEditor;     
using TMPro;

public class SsdSample : MonoBehaviour
{
    public string components;  // String to store detected components
    [SerializeField]
    private SSD.Options options = default;  // Options for SSD (Single Shot Multibox Detector)

    [SerializeField]
    private TMP_Text test;  

    [SerializeField]
    private AspectRatioFitter frameContainer = null;  // Container to fit the aspect ratio of frames

    [SerializeField]
    private Text framePrefab = null;  // Prefab for frames

    [SerializeField, Range(0f, 1f)]
    private float scoreThreshold = 0.5f;  // Threshold for detection score

    [SerializeField]
    private TextAsset labelMap = null;  // Asset containing labels

    private List<string> lists = new List<string>();  // List to store components name
    private SSD ssd;  // Instance of SSD
    private Text[] frames;  // Array of Text objects for frames
    private string[] labels;  // Array of labels
    //private string path1 = Application.dataPath + "/Log.txt";  // Path for logging, currently commented out
    private void Start()
    {
        // Start is called before the first frame update

#if UNITY_ANDROID && !UNITY_EDITOR
        // This block is specifically for Android devices and not for the Unity editor
        // Setup NNAPI delegate for accelerated machine learning inference
        if (options.accelerator == SSD.Accelerator.NNAPI && !Application.isEditor)
        {
            string cacheDir = Application.persistentDataPath;
            string modelToken = "ssd-token";
            var interpreterOptions = new InterpreterOptions();
            var nnapiOptions = NNAPIDelegate.DefaultOptions;
            nnapiOptions.AllowFp16 = true;
            nnapiOptions.CacheDir = cacheDir;
            nnapiOptions.ModelToken = modelToken;
            interpreterOptions.AddDelegate(new NNAPIDelegate(nnapiOptions));
            ssd = new SSD(options, interpreterOptions);
        }
        else
#endif // UNITY_ANDROID && !UNITY_EDITOR
        {
            ssd = new SSD(options);  // Initialize SSD with options
        }

        // Initialize frames
        frames = new Text[10];
        Transform parent = frameContainer.transform;
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i] = Instantiate(framePrefab, Vector3.zero, Quaternion.identity, parent);
            frames[i].transform.localPosition = Vector3.zero;
        }

        // Initialize labels by splitting the labelMap text asset
        labels = labelMap.text.Split('\n');
       
    }

    private void OnDestroy()
    {
        ssd?.Dispose();  // Dispose of SSD when the object is destroyed
    }

    public void Invoke(Texture texture)
    {
        ssd.Invoke(texture);  // Invoke SSD with the given texture

        SSD.Result[] results = ssd.GetResults();  // Get results from SSD
        Vector2 size = (frameContainer.transform as RectTransform).rect.size;
        components = "";
        for (int i = 0; i < results.Length; i++)
        {
            string labelName = SetFrame(frames[i], results[i], size);  // Set frame for each result
            if (!string.IsNullOrEmpty(labelName) && labelName != "?")
            {
                if (labelName != "battery")
                {
                    UI.Instance.compText.text += labelName + "\n";  // Add label name to UI text
                    GameManager.Instance.componentsNeeded += labelName;  // Add label name to componentsNeeded
                    components += labelName;  // Add label name to components string
                }
                Debug.Log(labelName);  // Log label name
            }

            if (labelName == "?") 
            {
                Destroy(gameObject);  // Destroy game object if label is unknown
            }
        }
    }

    public string GetDetectedComponentsAsString()
    {
        Debug.Log("in ssd: " + components);  // Log components string
        return components;  // Return components string
    }

    private string SetFrame(Text frame, SSD.Result result, Vector2 size)
    {
        if (result.score < scoreThreshold)
        {
            frame.gameObject.SetActive(false);  // Disable frame if score is below threshold
            return "?";  // Return unknown label
        }
        else
        {
            frame.gameObject.SetActive(true);  // Enable frame
        }

        // Set the text of the frame to include the label name and score percentage
        frame.text = $"{GetLabelName(result.classID)} : {(int)(result.score * 100)}%";
        
        var rt = frame.transform as RectTransform;
        rt.anchoredPosition = result.rect.position * size - size * 0.5f;  // Set anchored position of the frame
        rt.sizeDelta = result.rect.size * size;  // Set size of the frame

        return GetLabelName(result.classID);  // Return the label name

    }

    private string GetLabelName(int id)
    {
        if (id < 0 || id >= labels.Length - 1)
        {
            return "?";  // Return unknown label if id is out of range
        }
        return labels[id + 1];  // Return label name
    }


}
