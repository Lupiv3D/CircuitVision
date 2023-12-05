using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBuild : MonoBehaviour
{
    public GameObject [] components;
    public Material [] powerMaterials;
    public GameObject [] powerPoints;
    public GameObject [] powerPaths;


    private int currentStep;
    private int totalSteps;

    void Start()
    {
        currentStep = GameManager.Instance.currentStep;
        totalSteps = components.Length + 1;
    }

    public void nextStep()
    {
        deactivateAll();

        if (currentStep == 0) highlightPower(0);
        else if (currentStep == totalSteps) highlightPower(1);
        else if (currentStep == totalSteps+1) UI.Instance.hintText.text = "Circuit Completed!";
        else showTarget(currentStep-1);
        
        currentStep++;
        GameManager.Instance.currentStep++;
    }

    private void showTarget(int step)
    {
        components[step].SetActive(true);
        UI.Instance.hintText.text = "Connect the " + components[step].name + " in the highlighted area";
    }

    private void highlightPower(int power)
    {
        powerPaths[power].SetActive(true);
        powerPoints[power].GetComponent<MeshRenderer>().material = powerMaterials[power];

        UI.Instance.hintText.text = "Connect the wire in the highlighted points";
    }

    private void deactivateAll()
    {
        foreach (GameObject c in components)
            c.SetActive(false);
        foreach (GameObject p in powerPaths)
            p.SetActive(false);
    }
}
