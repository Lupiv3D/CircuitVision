using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string currentProject;
    public int currentStep;
    public string componentsNeeded = "";
    public int progress;

    public GameObject [] boards;
    public int boardType;
    public GameObject requiredBoard;


     private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showComponents()
    {
        Debug.Log(componentsNeeded);
    }

    public void setBoardType()
    {
        switch (componentsNeeded)
        {
            case "resistorLED":
            boardType = 0;
            break;
            case "LEDresistor":
            boardType = 0;
            break;
            case "resistordiode":
            boardType = 0;
            break;
            case "dioderesistor":
            boardType = 0;
            break;
            case "open switchresistorLED":
            boardType = 1;
            break;
            case "resistorLEDopen switch":
            boardType = 1;
            break;
            case "open switchLED":
            boardType = 2;
            break;
            case "LEDopen switch":
            boardType = 2;
            break;
            case "LED":
            boardType = 3;
            break;
            case "diode":
            boardType = 3;
            break;
            default:
            break;
        }
        requiredBoard = boards[boardType];
    }

    private int calculateProgress()
    {
        progress = Mathf.RoundToInt(((currentStep+1) / (componentsNeeded.Length + 4)) * 100);
        return progress;
    }
}
