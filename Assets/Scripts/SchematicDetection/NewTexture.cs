using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTexture : MonoBehaviour
{

    public RenderTexture _renderTexture;

    private float interval = 2.5f;

    [SerializeField]
    private SsdSample _ssdSample;
    private float last;

    private int attempts = 0;
    public bool started = false;

    bool error = false;
    bool lol = false;

    private void Start()
    {
        // last = DateTime.Now;
        // Detect();
    }

    public void startInvoke()
    {
        last = Time.time;
        Debug.Log(last);
        started = true;
        UI.Instance.Loading.SetActive(true);
        // Detect();
    }

    void Update()
    {
        if (started)
        {
            float now = Time.time;
            if (now - last >= interval)
            {
                Debug.Log(now);
                Detect();
                last = now;
                UI.Instance.Loading.SetActive(false);
                UI.Instance.displayCompResults();
            }
        }
    }

    private void Detect()
    {
        attempts++;
        _ssdSample.Invoke(_renderTexture);
    }

}
