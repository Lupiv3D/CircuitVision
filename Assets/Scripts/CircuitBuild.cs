using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBuild : MonoBehaviour
{
    // Array to hold circuit components
    public GameObject[] components;

    // Material for the power path
    public Material powerMaterial;

    // Reference to the power point and power path game objects
    public GameObject powerPoint;
    public GameObject powerPath;

    // Variables to track current step and total steps in the circuit
    private int currentStep;
    private int totalSteps;

    void Start()
    {
        // Initialize currentStep with the current step from the GameManager
        currentStep = GameManager.Instance.currentStep;

        // Store the total number of components in the circuit
        totalSteps = components.Length;
    }

    // Function to proceed to the next step in the circuit
    public void nextStep()
    {
        // Deactivate all components and power path
        deactivateAll();

        // Determine the action based on the current step
        if (currentStep == 0)
        {
            // Show the first component as the target
            showTarget(0);
        }
        else if (currentStep == totalSteps)
        {
            // Highlight the power path when all components are placed
            highlightPower();
        }
        else if (currentStep == totalSteps + 1)
        {
            // Display a message indicating the circuit completion
            UI.Instance.hintText.text = "Circuit Completed!";
        }
        else
        {
            // Show the target component based on the current step
            showTarget(currentStep);
        }

        // Increment the current step
        currentStep++;

        // Display info button on the first step
        if (currentStep == 1)
        {
            UI.Instance.infoButton.SetActive(true);
        }

        // Increment the current step in the GameManager
        GameManager.Instance.currentStep++;
    }

    // Function to show a specific component as the target
    private void showTarget(int step)
    {
        // Activate the specified component
        components[step].SetActive(true);

        // Display a hint for the current step
        UI.Instance.hintText.text = "Connect the " + components[step].name + " in the highlighted area";
    }

    // Function to highlight the power path
    private void highlightPower()
    {
        // Activate the power path and set its material
        powerPath.SetActive(true);
        powerPoint.GetComponent<MeshRenderer>().material = powerMaterial;

        // Display a hint for connecting the wire
        UI.Instance.hintText.text = "Connect the wire in the highlighted points";
    }

    // Function to deactivate all components and power path
    private void deactivateAll()
    {
        powerPath.SetActive(false);

        // Deactivate all components in the array
        foreach (GameObject c in components)
        {
            c.SetActive(false);
        }
    }
}