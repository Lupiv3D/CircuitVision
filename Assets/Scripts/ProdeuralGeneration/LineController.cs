using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int pointCount =0;
    LineRenderer line;

    void Start()
    {
        //the LineRenderer component is attached to the same GameObject
        lineRenderer = GetComponent<LineRenderer>();
       // lineRenderer.positionCount = 2; // Two points to create a line
        lineRenderer.positionCount = 4; // Set the number of positions for the line (adjust as needed)
    }

    // Function to draw a line between two Vector3 points
    public void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        pointCount++;
        if (pointCount < 2)
        {
            line = Instantiate(lineRenderer);
            line.positionCount = 1;
        }
        else
        {
            line.positionCount=pointCount;
            pointCount= 0;
        }
        if (lineRenderer != null)
        {
            line.SetPosition(0, startPoint); // Set the start point of the line
            lineRenderer.SetPosition(1, endPoint); // Set the end point of the line
        }
        else
        {
            Debug.LogError("LineRenderer component not found!");
        }
    }
}
    