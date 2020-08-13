using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreScript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private float h = Screen.height;

    private void Start()
    {

        entryContainer = transform.Find("highScoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        //PlayerPrefs.DeleteKey("highscoreTable");        

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        int max;
        if (highscores.highscoreEntryList.Count < 10)
        {
            max = highscores.highscoreEntryList.Count;
        }
        else max = 10;


        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
        PlayerPrefs.SetInt("lastScore", highscores.highscoreEntryList[9].score);

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float last = 0.1f;
        if (transformList.Count < 10)
        {
            float templateHeight = h * 0.00005f;
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchorMax = new Vector2(1, 1.0f - last * transformList.Count);
            entryRectTransform.anchorMin = new Vector2(0, 1.0f - last * (transformList.Count + 1.0f));
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }

            entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

            int score = highscoreEntry.score;

            entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();


            string name = highscoreEntry.name;

            entryTransform.Find("NameText").GetComponent<Text>().text = name;

            entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

            if (rank == 1)
            {
                entryTransform.Find("PosText").GetComponent<Text>().color = Color.yellow;
                entryTransform.Find("ScoreText").GetComponent<Text>().color = Color.yellow;
                entryTransform.Find("NameText").GetComponent<Text>().color = Color.yellow;
            }
            transformList.Add(entryTransform);
        }
    }

    public void AddHighScoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);

        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
