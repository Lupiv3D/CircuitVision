using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArTexture : MonoBehaviour
{
    [SerializeField]
    private ARCameraBackground _arCameraBackground;

    [SerializeField]
    private int interval = 1;

    [SerializeField]
    private SsdSample _ssdSample;

    private RenderTexture _cameraTexture;
    DateTime last;

    private void Start()
    {
        last = DateTime.Now;
        _cameraTexture = new RenderTexture(Screen.width, Screen.height, 0);
    }


    void Update()
    {
        DateTime now = DateTime.Now;
        if ((now - last).TotalSeconds >= interval)
        {
            Detect();
            last = now;
        }
    }

    private void Detect()
    {
        //AR RenderTexture
        Graphics.Blit(null, _cameraTexture, _arCameraBackground.material);

        //Texture
        _ssdSample.Invoke(_cameraTexture);
    }

}
