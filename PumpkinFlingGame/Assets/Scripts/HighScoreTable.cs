//using Assets.HeroEditor.Common.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class HighScoreTable : MonoBehaviour
{
    public static HighScoreTable Instance;
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    private string filePath;
    private string highScoreData;
    private SaveData sd;
    private void Awake()
    {
        //sd = GetComponent<SaveData>();
        if (System.IO.File.Exists(Application.persistentDataPath + "/highScoreData.json"))
        {
            entryContainer = transform.Find("HighScoreEntryContainer");
            entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
            entryTemplate.gameObject.SetActive(false);

            highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{ score = 777, name = "TEST"}
        };

            filePath = Application.persistentDataPath + "/highScoreData.json";
            highScoreData = System.IO.File.ReadAllText(filePath);
            HighScores highScores = JsonUtility.FromJson<HighScores>(highScoreData);
            if (highScores.highScoreEntryList != null)
            {
                for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
                {
                    for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
                    {
                        if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                        {
                            HighScoreEntry tmp = highScores.highScoreEntryList[i];
                            highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                            highScores.highScoreEntryList[j] = tmp;
                        }
                    }
                }
            }

            if (highScores.highScoreEntryList.Count > 10)
            {
                for (int h = highScores.highScoreEntryList.Count; h > 10; h--)
                {
                    highScores.highScoreEntryList.RemoveAt(10);
                }
            }
            highScoreEntryTransformList = new List<Transform>();

            foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
            {
                CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
            }

            HighScores highScore = new HighScores { highScoreEntryList = highScoreEntryList };
            string json = JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString("HighScoreTable", json);            
        }
        else
        {
            sd.CreateJson();
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count + 1;
        string rankString;        
        
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break; 
        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    
    public void AddHighScoreEntry(int score, string name)
    {
        //create High Score Entry       
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name};      

        // load saved high scores
        filePath = Application.persistentDataPath + "/highScoreData.json";
        highScoreData = System.IO.File.ReadAllText(filePath);
        HighScores highScores = JsonUtility.FromJson<HighScores>(highScoreData);
        //string jsonString = PlayerPrefs.GetString("HighScoreTable");

        //add new entry to high scores
        //highScores.highScoreEntryList.Clear();
        highScores.highScoreEntryList.Add(highScoreEntry);

        //save updated high scores
        filePath = Application.persistentDataPath + "/highScoreData.json";
        highScoreData = JsonUtility.ToJson(highScores);
        System.IO.File.WriteAllText(filePath, highScoreData);
        
        //PlayerPrefs.SetString("HighScoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("HighScoreTable"));
    }
    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;        
    }
}

public class SaveData : MonoBehaviour
{
    public HighScoreEntry highScore = new HighScoreEntry();

    public void CreateJson()
    {
        string hsData = JsonUtility.ToJson(highScore);
        string filePath = Application.persistentDataPath + "/highScoreData.json";
        System.IO.File.WriteAllText(filePath, hsData);
    }
}

[System.Serializable]
public class HighScoreEntry
{
    public int score;
    public string name;
}
