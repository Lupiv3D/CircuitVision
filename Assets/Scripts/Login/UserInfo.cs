using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{


    public string Username { get; set; }
    public string Password;

    public void SetInfo(string Username, string userpassword)
    {
        this.Username = Username;
        Password = userpassword;
    }

    public void SetUsername(string Username)
    {
        this.Username = Username;
    }


}
