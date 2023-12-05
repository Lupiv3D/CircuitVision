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
    [SerializeField]
    private SSD.Options options = default;

    [SerializeField]
    private TMP_Text test;


    [SerializeField]
    private AspectRatioFitter frameContainer = null;

    [SerializeField]
    private Text framePrefab = null;

    [SerializeField, Range(0f, 1f)]
    private float scoreThreshold = 0.5f;

    [SerializeField]
    private TextAsset labelMap = null;
    
    private List<string> lists = new List<string>();
    private SSD ssd;
    private Text[] frames;
    private string[] labels;
    //private string path1 = Application.dataPath + "/Log.txt";
    private void Start()
    {
       



#if UNITY_ANDROID && !UNITY_EDITOR
        // This is an example usage of the NNAPI delegate.
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
            ssd = new SSD(options);
        }

        // Init frames
        frames = new Text[10];
        Transform parent = frameContainer.transform;
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i] = Instantiate(framePrefab, Vector3.zero, Quaternion.identity, parent);
            frames[i].transform.localPosition = Vector3.zero;
        }

        // Labels
        labels = labelMap.text.Split('\n');
       
    }



    private void OnDestroy()
    {
        ssd?.Dispose();
    }


    public void Invoke(Texture texture)
    {
        ssd.Invoke(texture);

        SSD.Result[] results = ssd.GetResults();
        Vector2 size = (frameContainer.transform as RectTransform).rect.size;
            for (int i = 0; i < results.Length; i++)
            {
                string labelName = SetFrame(frames[i], results[i], size);
                if (!string.IsNullOrEmpty(labelName) && labelName != "?")
                {
                    if (labelName != "battery")
                    {
                        UI.Instance.compText.text += labelName + "\n";
                        GameManager.Instance.componentsNeeded += labelName; 
                    }
                    Debug.Log(labelName);
                }

                if (labelName == "?") 
                {
                    Destroy(gameObject);
                }
            }
    }

    private string SetFrame(Text frame, SSD.Result result, Vector2 size)
    {
        if (result.score < scoreThreshold)
        {
            frame.gameObject.SetActive(false);
            return "?";
        }
        else
        {
            frame.gameObject.SetActive(true);
        }

        
       // Debug.Log($"{GetLabelName(result.classID)} : {(int)(result.score * 100)}%");
        frame.text = $"{GetLabelName(result.classID)} : {(int)(result.score * 100)}%";
        
        var rt = frame.transform as RectTransform;
        rt.anchoredPosition = result.rect.position * size - size * 0.5f;
        rt.sizeDelta = result.rect.size * size;


        return GetLabelName(result.classID);

    }

    private string GetLabelName(int id)
    {
        if (id < 0 || id >= labels.Length - 1)
        {
            return "?";
        }
        return labels[id + 1];
    }


}

// using TensorFlowLite;
// using UnityEngine;
// using UnityEngine.UI;
// using System.IO;
// using System.Collections.Generic;
// using System;
// using UnityEditor;


// public class SsdSample : MonoBehaviour
// {
//     [SerializeField]
//     private SSD.Options options = default;

//     [SerializeField]
//     private AspectRatioFitter frameContainer = null;

//     [SerializeField]
//     private Text framePrefab = null;

//     [SerializeField, Range(0f, 1f)]
//     private float scoreThreshold = 0.5f;

//     [SerializeField]
//     private TextAsset labelMap = null;
    
//     private List<string> lists = new List<string>();
//     private SSD ssd;
//     private Text[] frames;
//     private string[] labels;
//     private string path1 = Application.dataPath + "/Log.txt";
//     private void Start()
//     {


//         Debug.Log("dataPath : " + path1);
// #if UNITY_ANDROID && !UNITY_EDITOR
//         // This is an example usage of the NNAPI delegate.
//         if (options.accelerator == SSD.Accelerator.NNAPI && !Application.isEditor)
//         {
//             string cacheDir = Application.persistentDataPath;
//             string modelToken = "ssd-token";
//             var interpreterOptions = new InterpreterOptions();
//             var nnapiOptions = NNAPIDelegate.DefaultOptions;
//             nnapiOptions.AllowFp16 = true;
//             nnapiOptions.CacheDir = cacheDir;
//             nnapiOptions.ModelToken = modelToken;
//             interpreterOptions.AddDelegate(new NNAPIDelegate(nnapiOptions));
//             ssd = new SSD(options, interpreterOptions);
//         }
//         else
// #endif // UNITY_ANDROID && !UNITY_EDITOR
//         {
//             ssd = new SSD(options);
//         }

//         // Init frames
//         frames = new Text[10];
//         Transform parent = frameContainer.transform;
//         for (int i = 0; i < frames.Length; i++)
//         {
//             frames[i] = Instantiate(framePrefab, Vector3.zero, Quaternion.identity, parent);
//             frames[i].transform.localPosition = Vector3.zero;
//         }

//         // Labels
//         labels = labelMap.text.Split('\n');
//        // Debug.Log(labels);
//     }



//     private void OnDestroy()
//     {
//         ssd?.Dispose();
//     }


//     public void Invoke(Texture texture)
//     {
//         ssd.Invoke(texture);

//         SSD.Result[] results = ssd.GetResults();
//         Vector2 size = (frameContainer.transform as RectTransform).rect.size;
//         /* for (int i = 0; i < 10; i++)
//          {
//              SetFrame(frames[i], results[i], size);
//              if (!File.Exists(path1))
//              {
//                  Debug.Log(SetFrame(frames[i], results[i], size));
//                  File.WriteAllText(path1, SetFrame(frames[i], results[i], size));
//              }
//          }*/

//         // using (StreamWriter writer = new StreamWriter(path1, true)) // Use StreamWriter to append to the file
//         // {
//         //     for (int i = 0; i < results.Length; i++)
//         //     {
//         //         string labelName = SetFrame(frames[i], results[i], size);
//         //         if (!string.IsNullOrEmpty(labelName) && !labelName.Equals("?"))
//         //         {
//         //             writer.WriteLine(labelName); // Write labelName to the file
//         //             UI.Instance.compText.text = labelName;
//         //         }
//         //     }
//         // }

//         for (int i = 0; i < results.Length; i++)
//             {
//                 string labelName = SetFrame(frames[i], results[i], size);
//                 if (!string.IsNullOrEmpty(labelName) && !labelName.Equals("?"))
//                 {
//                     UI.Instance.compText.text += labelName + "\n";
//                 }
//             }
//     }

//     private string SetFrame(Text frame, SSD.Result result, Vector2 size)
//     {
//         if (result.score < scoreThreshold)
//         {
//             frame.gameObject.SetActive(false);
//             return "?";
//         }
//         else
//         {
//             frame.gameObject.SetActive(true);
//         }

        
//        // Debug.Log($"{GetLabelName(result.classID)} : {(int)(result.score * 100)}%");
//         frame.text = $"{GetLabelName(result.classID)} : {(int)(result.score * 100)}%";
        
//         var rt = frame.transform as RectTransform;
//         rt.anchoredPosition = result.rect.position * size - size * 0.5f;
//         rt.sizeDelta = result.rect.size * size;

//         return GetLabelName(result.classID);
//     }

//     private string GetLabelName(int id)
//     {
//         if (id < 0 || id >= labels.Length - 1)
//         {
//             return "?";
//         }
//          return labels[id + 1];
//     }
// }
