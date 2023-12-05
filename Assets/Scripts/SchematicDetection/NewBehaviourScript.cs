using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private string pathToFile = Application.dataPath + "/Log.txt"; // Assign the path to your file

    private List<string> fileContents = new List<string>();

    void Start()
    {
        ReadFileContents();
    }

    private void ReadFileContents()
    {
        if (File.Exists(pathToFile))
        {
            StreamReader reader = new StreamReader(pathToFile);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                fileContents.Add(line);
            }

            reader.Close();

            // Do something with the contents of 'fileContents' list
            DisplayContents();
        }
        else
        {
            Debug.LogError("File does not exist at path: " + pathToFile);
        }
    }

    private void DisplayContents()
    {
        foreach (string line in fileContents)
        {
            Debug.Log(line);
            // UI.Instance.compText.text += "\n" + line;
            // You can process each line here or store it in a different data structure as needed
        }
    }
}

