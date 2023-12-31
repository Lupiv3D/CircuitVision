using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public static UI Instance;
    private int currentPage = 0;
    public GameObject BG;
    public GameObject hideScene;

    public GameObject Loading;

    public GameObject [] compResults;

    public GameObject [] pages;

    public GameObject footer;
    public GameObject [] footerButtons;
    public TMP_Text hintText;

    public TMP_Text compText;

    private Anchor anchor;

    [Header("AR Overlay")]
    public GameObject [] transformButtons;

    private CircuitBuild circuitBuild;

    public GameObject[] listMenu;
    public GameObject listSteps;

    public GameObject confirmPrompt;
    public TMP_Text confirmText;
    public Button confirmButton;

    public GameObject infoMenu;
    public GameObject [] infoTexts1;
    public GameObject [] infoTexts2;


    public GameObject infoButton;


    [Header("Create Project")]
    public TMP_InputField projName;
    public Image image;




    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //Turn off Screensaver
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

   

    public void ChangePage(int pageNum)
    {
        pages[currentPage].SetActive(false);
        pages[pageNum].SetActive(true);
        currentPage = pageNum;

        pageCheck();
    }

    private void pageCheck()
    {
        if (currentPage == 3 && !(SceneManager.GetActiveScene().name == "MainAR" || SceneManager.GetActiveScene().name == "MainAR2"))
        {
            if(!footer.activeSelf) footer.SetActive(true);
            footerCheck(1);
        }
        else if (currentPage == 5)
        {
            footerCheck(2);
            SceneManager.LoadScene("MainCreate");
        }
        else if (currentPage == 6)
        {
            footerCheck(3);
        }
        else if (currentPage == 7)
        {
            BG.SetActive(false);
            StartCoroutine(loadScreen());
            footerCheck(4);
            SceneManager.LoadScene("MainAR");
        }
        else if (currentPage == 8)
        {
            BG.SetActive(false);
            StartCoroutine(loadScreen());
            footerCheck(4);
            SceneManager.LoadScene("MainAR2");
        }
        else if (currentPage == 3 && (SceneManager.GetActiveScene().name == "MainAR" || SceneManager.GetActiveScene().name == "MainAR2")) 
        {
            BG.SetActive(true);
            hideScene.SetActive(true);
            confirmPrompt.SetActive(false);
            footerCheck(1);
            SceneManager.LoadScene("MainUI");
        }\
    }

    private void footerCheck(int num)
    {
        for (int i = 0; i < footerButtons.Length; i ++)
            footerButtons[i].SetActive(false);
        
        switch (num)
        {
            case 1:
            footerButtons[1].SetActive(true);
            footerButtons[2].SetActive(true);
            footerButtons[4].SetActive(true);
            break;
            case 2:
            footerButtons[0].SetActive(true);
            footerButtons[3].SetActive(true);
            footerButtons[4].SetActive(true);
            break;
            case 3:
            footerButtons[0].SetActive(true);
            footerButtons[2].SetActive(true);
            footerButtons[5].SetActive(true);
            break;
            default:
            break;
        }
    }

    //Schematic Detection (Create Page)
    public void displayUpload()
    {
        compResults[4].SetActive(true);
        compResults[1].SetActive(true);
        compResults[0].SetActive(false);
    }

    public void startDetection()
    {
        GameObject.FindWithTag("SchemDetect").GetComponent<NewTexture>().startInvoke();
    }

    public void displayCompResults()
    {
        compResults[2].GetComponent<RectTransform>().anchoredPosition = new Vector3(0,450,0);
        compResults[3].GetComponent<RectTransform>().anchoredPosition = new Vector3(0,250,0);
        compResults[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(0,50,0);
        
        compResults[0].SetActive(true);
        compResults[6].SetActive(false);
        compResults[4].SetActive(false);

        compResults[5].GetComponent<Button>().interactable = true;
        GameManager.Instance.setBoardType();
    }

    public void createProject()
    {
        if (projName.text == null) GameManager.Instance.currentProject = "Untitled";
        else GameManager.Instance.currentProject = projName.text;

        GameManager.Instance.currentStep = 0;
        GameManager.Instance.setBoardType();

        listMenu[GameManager.Instance.boardType].SetActive(true);
    }

    //Load screen to AR Page
    private IEnumerator loadScreen()
    {
        Loading.SetActive(true);
        yield return new WaitForSeconds(1f);
        Loading.SetActive(false);
        hideScene.SetActive(false);
    }


    //Transform Buttons (AR Page)
    public void showTransform()
    {
        transformButtons[0].SetActive(true);
        transformButtons[2].SetActive(true);
        transformButtons[4].SetActive(true);
        transformButtons[6].SetActive(true);
    }

    public void transformAnchor(int type)
    {
        if (anchor == null) 
            anchor = GameObject.FindWithTag("Anchor").GetComponent<Anchor>();
        
        anchor.toggleTransform(type);
        transformCheck(type);
    }

    private void transformCheck(int num)
    {
        switch (num)
        {
            case 0:
            transformButtons[0].SetActive(!transformButtons[0].activeSelf);
            transformButtons[1].SetActive(!transformButtons[1].activeSelf);
            transformButtons[2].SetActive(true);
            transformButtons[3].SetActive(false);
            transformButtons[4].SetActive(true);
            transformButtons[5].SetActive(false);
            break;
            case 1:
            transformButtons[0].SetActive(true);
            transformButtons[1].SetActive(false);
            transformButtons[2].SetActive(!transformButtons[2].activeSelf);
            transformButtons[3].SetActive(!transformButtons[3].activeSelf);
            transformButtons[4].SetActive(true);
            transformButtons[5].SetActive(false);
            break;
            case 2:
            transformButtons[0].SetActive(true);
            transformButtons[1].SetActive(false);
            transformButtons[2].SetActive(true);
            transformButtons[3].SetActive(false);
            transformButtons[4].SetActive(!transformButtons[4].activeSelf);
            transformButtons[5].SetActive(!transformButtons[5].activeSelf);
            break;
            default:
            foreach (GameObject t in transformButtons)
                t.SetActive(false);
            transformButtons[0].SetActive(true);
            transformButtons[2].SetActive(true);
            transformButtons[4].SetActive(true);
            showTransform();
            break;
        }
    }

    //Show Popup Functions (AR Page)
    public void showList()
    {
        listSteps.SetActive(!listSteps.activeSelf);
    }

    public void showPrompt(int type)
    {
        switch (type)
        {
            case 1:
            confirmText.text = "End Project and Return to the Home Screen?";
            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(() => ChangePage(3));
            break;
            case 2:
            confirmText.text = "Proceed to the Next Step?";
            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(() => nextStep());
            break;
            default:
            break;
        }
        confirmPrompt.SetActive(!confirmPrompt.activeSelf);
    }

    public void showInfo()
    {
        if (GameManager.Instance.boardType == 0)
        {
            foreach (GameObject x in infoTexts1)
                x.SetActive(false);

            infoTexts1[GameManager.Instance.currentStep-1].SetActive(true);
        }
        else if (GameManager.Instance.boardType == 1)
        {
            foreach (GameObject x in infoTexts2)
                x.SetActive(false);

            infoTexts2[GameManager.Instance.currentStep-1].SetActive(true);
        }

        
        infoMenu.SetActive(!infoMenu.activeSelf);
    }

    //CircuitBuild functions
    public void nextStep()
    {
        if (circuitBuild == null)
            circuitBuild = GameObject.FindGameObjectWithTag("BreadBoard").GetComponent<CircuitBuild>();
        
        circuitBuild.nextStep();
        confirmPrompt.SetActive(false);
    }
}
