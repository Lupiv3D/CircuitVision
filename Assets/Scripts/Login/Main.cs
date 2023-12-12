using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main instance;

    public Registration Registration;
    public Login login;
    public UserInfo UserInfo;
    public GameObject UserProFile;
    public SsdSample ssdSample;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Registration = GetComponent<Registration>();
        UserInfo = GetComponent<UserInfo>();
        ssdSample = GetComponent<SsdSample>();
    }
}
