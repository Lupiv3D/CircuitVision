using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    GameObject [] info;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.boardType = 3;
        info = GameObject.FindGameObjectsWithTag("info");
        foreach (GameObject g in info)
            Destroy(g);
        GameManager.Instance.setBoardType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
