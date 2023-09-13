using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class HighScoreTable : MonoBehaviour
{

    private Transform tableContent;
    private Transform contentTemplate;
    private List<Transform> highscoreTableList;
    private List<HighscoreEntry> highscoreEntryList;

    public static HighScoreTable instance;
    private string jsonString;

    [SerializeField]
    private string filename;
    public static HighScoreTable getInstance()
    {
        return instance;
    }

    [System.Obsolete]
    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        instance = this;
        tableContent = transform.Find("tableContent");
        contentTemplate = tableContent.Find("contentTemplate");

        contentTemplate.gameObject.SetActive(false);
        // buat reset high score
        //  resetHighscore();
        // StartCoroutine(getHighscore());

        // addHighScoreEntry(250, "ASH", 1000);
        // try {
        // string jsonString = PlayerPrefs.GetString("highScoreTable");
        // jsonString = FileHandler.ReadFromJSON("highscore.json");
        // Debug.Log(jsonString);
        // HighScores highScore = JsonUtility.FromJson<HighScores>(jsonString);
        // // Debug.Log(highScore);
        // // Debug.Log(highScore.highscoreEntryList.Count);
        // // Debug.Log(highScore == null);
        // if (highScore.highscoreEntryList.Count != 0)
        // {
        //     for (int i = 0; i < highScore.highscoreEntryList.Count; i++)
        //     {
        //         for (int j = 0; j < highScore.highscoreEntryList.Count; j++)
        //         {

        //             if (highScore.highscoreEntryList[j].scorePoint < highScore.highscoreEntryList[i].scorePoint)
        //             {
        //                 HighscoreEntry tmp = highScore.highscoreEntryList[i];
        //                 highScore.highscoreEntryList[i] = highScore.highscoreEntryList[j];
        //                 highScore.highscoreEntryList[j] = tmp;
        //             }
        //         }
        //     }

        //     highscoreTableList = new List<Transform>();

        //     for (int i = 0; i < highScore.highscoreEntryList.Count; i++)
        //     {

        //         if (i > 9)
        //         {
        //             break;
        //         }
        //         createContentTemplate(highScore.highscoreEntryList[i], tableContent, highscoreTableList);
        //     }
            // foreach (HighscoreEntry highscore in highScore.highscoreEntryList)
            // {
            //     createContentTemplate(highscore, tableContent, highscoreTableList);
            // }
        // }
        // else
        // {
        //     Debug.Log("null");
        // }
        // Debug.Log(jsonString);
        // } catch {
        //     resetHighscore();
        //     Debug.Log("reset");
        // }

    }

    void Start() {
        StartCoroutine(getHighscore());
    }

    // void update()
    // {

    // }

    public void resetHighscore()
    {
        HighScores highScores = new HighScores();
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        FileHandler.SaveToJSON<string>(json, "highscore.json");
        // PlayerPrefs.DeleteAll();
        // PlayerPrefs.Save();

    }

    private void createContentTemplate(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHieght = 55f;
        Transform contentEntry = Instantiate(contentTemplate, container);
        RectTransform entryRectTransform = contentEntry.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(-28, -templateHieght * transformList.Count - templateHieght);
        contentEntry.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankText;
        switch (rank)
        {
            case 1: rankText = "1ST"; break;
            case 2: rankText = "2ND"; break;
            case 3: rankText = "3RD"; break;
            default: rankText = rank + "TH"; break;
        }

        contentEntry.Find("rankText").GetComponent<TextMeshProUGUI>().text = rankText;
        contentEntry.Find("scoreText").GetComponent<TextMeshProUGUI>().text = highscoreEntry.scorePoint.ToString();
        string name = highscoreEntry.name;
        contentEntry.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        contentEntry.Find("background").gameObject.SetActive(rank % 2 == 0);

        // if (rank == 1)
        // {
        //     contentEntry.Find("rankText").GetComponent<TextMeshProUGUI>().color = Color.green;
        //     contentEntry.Find("scoreText").GetComponent<TextMeshProUGUI>().color = Color.green;
        //     contentEntry.Find("nameText").GetComponent<TextMeshProUGUI>().color = Color.green;
        // }
        transformList.Add(contentEntry);
    }

    public void addHighScoreEntry(float scoreTime, string name, float scorePoint)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { scoreTime = scoreTime, name = name, scorePoint = scorePoint };

        // string jsonString = PlayerPrefs.GetString("highScoreTable");
        string jsonString = FileHandler.ReadFromJSON("highscore.json");
        HighScores highScore = JsonUtility.FromJson<HighScores>(jsonString);

        highScore.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highScore);
        FileHandler.SaveToJSON<string>(json, "highscore.json");

    }

    [System.Obsolete]
    IEnumerator getHighscore()
    {
        string url = "http://54.254.221.187:5000/api/highscore";
        WWW w = new WWW(url);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("submit gagal");
            Debug.Log(w.error);
        }
        else
        {
            if (w.isDone)
            {
                Debug.Log("succes");
                Debug.Log(w.text);
                jsonString = w.text;
                HighScores highScore = JsonUtility.FromJson<HighScores>(jsonString);
                Debug.Log(highScore.highscoreEntryList[0].scorePoint);
                // Debug.Log(highScore.highscoreEntryList.Count);
                // Debug.Log(highScore == null);
                // if (highScore.highscoreEntryList.Count != 0)
                // {
                    for (int i = 0; i < highScore.highscoreEntryList.Count; i++)
                    {
                        for (int j = 0; j < highScore.highscoreEntryList.Count; j++)
                        {

                            if (highScore.highscoreEntryList[j].scorePoint < highScore.highscoreEntryList[i].scorePoint)
                            {
                                HighscoreEntry tmp = highScore.highscoreEntryList[i];
                                highScore.highscoreEntryList[i] = highScore.highscoreEntryList[j];
                                highScore.highscoreEntryList[j] = tmp;
                            }
                        }
                    }

                    highscoreTableList = new List<Transform>();

                    for (int i = 0; i < highScore.highscoreEntryList.Count; i++)
                    {

                        if (i > 9)
                        {
                            break;
                        }
                        createContentTemplate(highScore.highscoreEntryList[i], tableContent, highscoreTableList);
                    }
                }
            }

            w.Dispose();
        }

        public string setText(float waktu)
        {
            int menit = Mathf.FloorToInt(waktu / 60);
            int detik = Mathf.FloorToInt(waktu % 60);

            return menit.ToString("00") + ":" + detik.ToString("00");
        }

    private class HighScores
    {
        bool status;
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float scoreTime;
        public string name;
        public float scorePoint;
    }




}


