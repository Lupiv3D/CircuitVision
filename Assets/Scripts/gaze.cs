using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class gaze : MonoBehaviour
{

    List<infoBehaviour> infos= new List<infoBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        infos = FindObjectsOfType<infoBehaviour>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if(go.CompareTag("Component"))
            {
               OpenInfo(go.GetComponent<infoBehaviour>());
               print("hi");
            }
        }
        else
        {
            CloseAll();

        }
        
    }

    void OpenInfo(infoBehaviour desiredInfo)
    {
        foreach(infoBehaviour info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();

            }
            else
            {
                info.ClosInfo();
            }
        }
    }

    void CloseAll()
    {
        foreach(infoBehaviour info in infos)
        {
            info.ClosInfo();
        }
    }
}
