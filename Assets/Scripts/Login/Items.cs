using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using System.ComponentModel;
using System.Xml.Linq;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject test;
    Action<string> _createItemsCallback;
    //Start is called before the first frame update
    void Start()
    {
        _createItemsCallback = (jsonArray) =>
        {
            StartCoroutine(CreateItemsRoutine(jsonArray));
        };

        CreateItems();
    }

    // Update is called once per frame
    public void CreateItems()
    {
        //problem
        string userId = Main.instance.UserInfo.Username;
        StartCoroutine(Main.instance.Registration.GetUserProjects(userId, _createItemsCallback));
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {

        JSONArray jsonArry = JSON.Parse(jsonArrayString) as JSONArray;
        yield return null;

        for (int i = 0; i < jsonArry.Count; i++)
        {
            bool isDone = false;
            string projectID = jsonArry[i].AsObject["projectID"];
            JSONObject itemInfoJson = new JSONObject();

            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };
            StartCoroutine(Main.instance.Registration.GetProjects(projectID, getItemInfoCallback));

            yield return new WaitUntil(() => isDone == true);


            //instantiate gameobj (project prefab)
           
            if (test == null)
            {
                Debug.LogError("Prefab not found in 'Prefabs/Container'");
                yield break; // Exit the coroutine if the prefab is not found
            }

            GameObject Container = Instantiate(test);
            Container.transform.SetParent(this.transform);
            Container.transform.localScale = Vector3.one;
            Container.transform.localPosition = Vector3.zero;


            //fill projects info
            
            TMP_Text titleText = Container.transform.Find("Title").GetComponent<TMP_Text>();
            string instanceTitle = itemInfoJson["name"]; // The title for this specific instance
            titleText.text = instanceTitle;

            Button buttonComponent = Container.GetComponent<Button>();
            buttonComponent.onClick.RemoveAllListeners(); // Clear existing listeners
            buttonComponent.onClick.AddListener(() => Main.instance.Registration.OnNextStepClicked(instanceTitle));
        }

    }



}
