using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    string[] users;
    string[] userInfo;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        StartCoroutine(GetRequest("https://ntrillizio.com/Highscores.php"));

        //GetHighScores();
        /*highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 54, name = "AAA"},
            new HighscoreEntry{ score = 456, name = "ANT"},
            new HighscoreEntry{ score = 120, name = "CAT"},
            new HighscoreEntry{ score = 424, name = "NAN"},
            new HighscoreEntry{ score = 720, name = "PAT"},
            new HighscoreEntry{ score = 485, name = "ASS"},
            new HighscoreEntry{ score = 320, name = "JOE"}
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }*/

        //PlayerPrefs.Set
    }

    private void TranslateRawHighScores()
    {
        foreach (string user in users)
        {
            //highscoreEntryList.Add(new HighscoreEntry { user.Substring(user.IndexOf("*")), user.Substring(0) };
        }
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

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://ntrillizio.com/Highscores.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Error: " + webRequest.downloadHandler.text);
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received: " + webRequest.downloadHandler.text);

                    string rawresponse = webRequest.downloadHandler.text;

                    users = rawresponse.Split('*');

                    highscoreEntryList = new List<HighscoreEntry>();
                    
                    foreach(string user in users)
                    {
                        if (user != "")
                        {
                            userInfo = user.Split(',');
                            highscoreEntryList.Add(new HighscoreEntry { score = int.Parse(userInfo[1]), name = userInfo[0]});
                        }
                        //highscoreEntryList.Add(new HighscoreEntry { score = int.Parse(user.Substring(user.IndexOf(",") + 1)), name = user.Substring(0, user.IndexOf(",") - 1) });
                    }

                    for (int i = 0; i < highscoreEntryList.Count; i++)
                    {
                        for (int j = i + 1; j < highscoreEntryList.Count; j++)
                        {
                            if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                            {
                                //swap
                                HighscoreEntry tmp = highscoreEntryList[i];
                                highscoreEntryList[i] = highscoreEntryList[j];
                                highscoreEntryList[j] = tmp;
                            }
                        }
                    }

                    highscoreEntryTransformList = new List<Transform>();
                    foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
                    {
                        CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                    }

                    break;
            }
        }
    }
}
