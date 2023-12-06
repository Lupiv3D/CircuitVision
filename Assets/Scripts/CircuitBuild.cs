using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBuild : MonoBehaviour
{
    public GameObject [] components;
    public Material powerMaterial;
    public GameObject powerPoint;
    public GameObject powerPath;


    private int currentStep;
    private int totalSteps;

    void Start()
    {
        currentStep = GameManager.Instance.currentStep;
        totalSteps = components.Length;
    }

    public void nextStep()
    {
        deactivateAll();

        if (currentStep == 0) showTarget(0);
        else if (currentStep == totalSteps) highlightPower();
        else if (currentStep == totalSteps+1) UI.Instance.hintText.text = "Circuit Completed!";
        else showTarget(currentStep);
        
        currentStep++;
        if (currentStep == 1) UI.Instance.infoButton.SetActive(true);
        GameManager.Instance.currentStep++;
    }

    private void showTarget(int step)
    {
        components[step].SetActive(true);
        UI.Instance.hintText.text = "Connect the " + components[step].name + " in the highlighted area";
    }

    private void highlightPower()
    {
        powerPath.SetActive(true); 
        powerPoint.GetComponent<MeshRenderer>().material = powerMaterial;

        UI.Instance.hintText.text = "Connect the wire in the highlighted points";
    }

    private void deactivateAll()
    {
        powerPath.SetActive(false);
        foreach (GameObject c in components)
            c.SetActive(false);
    }
}
