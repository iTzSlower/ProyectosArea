using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public InputField inputKey;
    public InputField inputValue;
    public Text textResult;

    public void Save() {
        string key = inputKey.text;
        string value = inputValue.text;

        Debug.Log(key + " - " + value);

        PlayerPrefs.SetString(key, value);
        Debug.Log(Int32.Parse(value));
        Debug.Log(float.Parse(value));
    }
    
    public void Load() {
        string value = PlayerPrefs.GetString("level","no level");

        textResult.text = value;
    }
    public void CreateFile() {
        string path = "D:/myFile.txt";
        string contents = "Lorem ipsum\n dolor sit amet";

        Dictionary<string, string> valuePairs;
        valuePairs = new Dictionary<string, string>();

        valuePairs.Add("name", "ralba");
        valuePairs.Add("level", "7");
        valuePairs.Add("calss", "druid");

        string[] lines = new string[3];
        int i = 0;
        foreach(KeyValuePair<string, string> item in valuePairs) {
            lines[i] = item.Key + " -> " + item.Value;
            i++;
        }

        //File.WriteAllText (path, contents);
        File.WriteAllLines(path, lines);

        //Debug.Log(Application.dataPath);
        //Debug.Log(Application.persistentDataPath);
        //Debug.Log(Application.streamingAssetsPath);
    }
}
