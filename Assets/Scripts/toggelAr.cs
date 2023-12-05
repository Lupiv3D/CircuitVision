using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class toggelAr : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;


    public void OnValueChange(bool isOn)
    {
        VisualizePlane(isOn);
        VisualizePoints(isOn);
    }
    

    void VisualizePlane(bool active)
    {
        planeManager.enabled= active;
        foreach(ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(active);
        }
    }
    // Start is called before the first frame update

    void VisualizePoints(bool active)
    {
        pointCloudManager.enabled = active;
        foreach (ARPointCloud point  in pointCloudManager.trackables)
        {
            point.gameObject.SetActive(active);
        }
    }

}
