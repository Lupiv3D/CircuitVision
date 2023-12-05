using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoBehaviour : MonoBehaviour
{
    const float SPEED = 6f;

    [SerializeField]
    Transform SectionInfo;

    Vector3 dessiredScale = Vector3.zero;

      void Update()
    {
        SectionInfo.localScale=Vector3.Lerp(SectionInfo.localScale, dessiredScale,Time.deltaTime * SPEED);

        
    }

    public void OpenInfo()
    {
        dessiredScale = Vector3.one;
    }

    public void ClosInfo()
    {
        dessiredScale= Vector3.zero;
    }

    internal List<infoBehaviour> ToList()
    {
        throw new NotImplementedException();
    }
}
