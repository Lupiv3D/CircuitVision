using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.VisualScripting;
using System;

public class Registration : MonoBehaviour
{
    //public TMP_InputField username;
    //public TMP_InputField password;
    public static Registration Instance;

    public TMP_Text warn;

    public TMP_InputField Signupusername;
    public TMP_InputField Signuppassword;
    public TMP_InputField Signupreinput;
    public TMP_InputField Projectname;

    public Button SignupButtion;
    public Button SigninButton;

    public Button CProjectButton;

    /*public void StartLogin()
    {
        StartCoroutine(Login(username.text, password.text));
    }*/

    private void Awake()
    {
        Instance = this;
    }

    public void SignUp()
    {
        StartCoroutine(Register(Signupusername.text, Signuppassword.text));
    }
    public void OnProjectCreated(string projectID)
    {
        string username = Main.instance.UserInfo.Username; // Replace with your method to obtain the logged-in user's username

        StartCoroutine(InsertUserProject(username, projectID, (response) => {
            Debug.Log("Project linked to user: " + response);
            // Additional logic for success/failure feedback to the user
        }));
    }
    

    public void TriggerProjectCreation()
    {

        string projectName = Projectname.text; // Get the project name from the input field
        string components = Main.instance.ssdSample.GetDetectedComponentsAsString();
        Debug.Log("ssdSample is null: " + (Main.instance.ssdSample == null));
        Debug.Log(components);
        StartCoroutine(CreateProject(projectName, components, OnProjectCreated));
    }


    public void OnNextStepClicked(string projectName)
    {
        /*string name = GameManager.Instance.projectName; // Get current project ID from GameManager
        string projectID = GameManager.Instance.projectid; // Get the username*/
        /*string projectName = projectButton.text;
        Debug.Log("Project Name: " + projectName);*/
        StartCoroutine(UpdateCurrentStep(projectName));
    }



    /*public void ShowUserProjects()
    {
        StartCoroutine(GetUserProjects(Main.instance.UserInfo.Username));
    }*/

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.instance.UserInfo.SetInfo(username, password);
                Main.instance.UserInfo.SetUsername(www.downloadHandler.text);
                if (www.downloadHandler.text == username)
                {
                    Debug.Log(www.downloadHandler.text);
                    UI.Instance.ChangePage(3);
                    Main.instance.UserProFile.SetActive(true);
                    //Main.instance.login.gameObject.SetActive(false);
                }
                else
                {
                    warn.SetText(www.downloadHandler.text);
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }

    }

    IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                UI.Instance.ChangePage(3);
            }
        }
    }


    public IEnumerator GetUserProjects(string Username, System.Action<string> callback)
    {

        WWWForm form = new WWWForm();
        form.AddField("Username", Username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/getitem.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;
                //call callback func to pass results
                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetProjects(string projectID, System.Action<string> callback)
    {

        WWWForm form = new WWWForm();
        form.AddField("projectID", projectID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/showprojs.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;
                //call callback func to pass results
                callback(jsonArray);
            }
        }
    }

    IEnumerator getimage(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/images.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;
            }
        }
    }

    public IEnumerator CreateProject(string projectName, string components, System.Action<string> onProjectCreated)
    {
        WWWForm form = new WWWForm();
        form.AddField("projectName", GameManager.Instance.currentProject);
        form.AddField("components", GameManager.Instance.componentsNeeded);

        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/createproj.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                string projectID = www.downloadHandler.text; // Assuming the response is the projectID
                onProjectCreated?.Invoke(projectID);
            }
        }
    }



    public IEnumerator InsertUserProject(string Username, string projectID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", Username);
        form.AddField("projectID", projectID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/createuserproj.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Log the response from the server
                Debug.Log(www.downloadHandler.text);
                // Call callback function to pass results
                callback(www.downloadHandler.text);
            }
        }
    }

    IEnumerator UpdateCurrentStep(string projectName)
    {
        WWWForm form = new WWWForm();
        form.AddField("projectName", projectName);
        //form.AddField("projectID", projectID); // If your PHP script requires the username

        using (UnityWebRequest www = UnityWebRequest.Post("http://172.20.10.7/321test/cstep.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error updating step: " + www.error);
            }
            else
            {
                Debug.Log("Step updated successfully. Server response: " + www.downloadHandler.text);
                GameManager.Instance.currentStep++; // Increment the step in GameManager
            }
        }
    }

}

/* Main.instance.UserInfo.SetInfo(username, password);
                     Main.instance.UserInfo.SetUsername(www.downloadHandler.text);*/


/*if (www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exists"))
{
    Debug.Log("Try again");
}
else
{
    Main.instance.UserProFile.SetActive(true);
    Main.instance.login.gameObject.SetActive(false);
}*/