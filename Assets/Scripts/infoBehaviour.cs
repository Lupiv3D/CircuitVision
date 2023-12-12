using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gaze : MonoBehaviour
{
    // List to store infoBehaviour components
    List<infoBehaviour> infos = new List<infoBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        // Find all infoBehaviour components in the scene and add them to the list
        infos = FindObjectsOfType<infoBehaviour>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if a raycast from the camera is hitting any object
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;

            // If the hit object has the "Component" tag
            if (go.CompareTag("Component"))
            {
                // Open the info related to the hit component
                OpenInfo(go.GetComponent<infoBehaviour>());
                print("hi"); // Output "hi" to the console
            }
        }
        else
        {
            // If no object is hit, close all infoBehaviours
            CloseAll();
        }
    }

    // Open the information associated with a specific infoBehaviour
    void OpenInfo(infoBehaviour desiredInfo)
    {
        foreach (infoBehaviour info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo(); // Open the desired infoBehaviour
            }
            else
            {
                info.ClosInfo(); // Close other infoBehaviours
            }
        }
    }

    // Close all infoBehaviours
    void CloseAll()
    {
        foreach (infoBehaviour info in infos)
        {
            info.ClosInfo(); // Close all infoBehaviours
        }
    }
}
