using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 521054, name = "AAA"},
            new HighscoreEntry{ score = 123456, name = "ANT"},
            new HighscoreEntry{ score = 473920, name = "CAT"},
            new HighscoreEntry{ score = 927424, name = "NAN"},
            new HighscoreEntry{ score = 375920, name = "PAT"},
            new HighscoreEntry{ score = 103485, name = "ASS"},
            new HighscoreEntry{ score = 749320, name = "JOE"}
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //PlayerPrefs.Set
    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highsccoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
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

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highsccoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highsccoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        //set background active and not on evens and odds
        entryTransform.Find("Background").gameObject.SetActive(rank % 2 == 1);

        transformList.Add(entryTransform);
    }

    /// <summary>
    /// Represents a single high score entry
    /// </summary>
    //[System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
