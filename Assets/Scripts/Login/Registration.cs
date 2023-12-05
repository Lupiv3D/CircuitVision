using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.VisualScripting;

public class Registration : MonoBehaviour
{
    //public TMP_InputField username;
    //public TMP_InputField password;
    public TMP_Text warn;

    public TMP_InputField Signupusername;
    public TMP_InputField Signuppassword;
    public TMP_InputField Signupreinput;

    public Button SignupButtion;
    public Button SigninButton;
    /*public void StartLogin()
    {
        StartCoroutine(Login(username.text, password.text));
    }*/

    public void SignUp()
    {
        StartCoroutine(Register(Signupusername.text, Signuppassword.text));
    }

    public void ShowUserProjects()
    {
        //StartCoroutine(GetUserProjects(Main.instance.UserInfo.username));
    }
    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://10.152.136.9/321test/getusers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://10.152.136.9/321test/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError || www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exists"))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                UI.Instance.ChangePage(3);
                /*Main.instance.UserInfo.SetInfo(username, password);
                Main.instance.UserInfo.SetUsername(www.downloadHandler.text);*/
                // if (www.downloadHandler.text == "Successfully logged in")
                // {
                //     Debug.Log(www.downloadHandler.text);
                //     UI.Instance.ChangePage(3);
                //     /*Main.instance.UserInfo.SetInfo(username, password);
                //     Main.instance.UserInfo.SetUsername(www.downloadHandler.text);*/
                    
                //     // else
                //     // {
                //     //    /* Main.instance.UserProFile.SetActive(true);*/
                //     //     Main.instance.login.gameObject.SetActive(false);
                //     // }
                // }
                // else if (www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exists"))
                // {
                //     Debug.Log("Try again");
                // }
                // else
                // {
                //     //Did not Log in
                //     warn.SetText(www.downloadHandler.text);
                //     Debug.Log(www.downloadHandler.text);
                // }
            }
        }

    }
    IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://10.152.136.9/321test/register.php", form))
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


    public IEnumerator GetUserProjects(string username/*, System.Action<string> callback*/)
    {

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://10.152.136.9/321test/getitem.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

               // callback(jsonArray);
            }
        }
    }

    /* IEnumerator getimage(string username)
     {
         WWWForm form = new WWWForm();
         form.AddField("loginUser", username);

         using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/321test/images.php", form))
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
     }*/
}
