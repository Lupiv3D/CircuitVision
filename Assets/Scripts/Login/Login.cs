using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Login : MonoBehaviour
{


    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button LoginButton;
    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.instance.Registration.Login(usernameInput.text, passwordInput.text));

        });
    }

}
