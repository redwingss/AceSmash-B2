using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class Bdd : MonoBehaviour
{
    public TextMeshProUGUI scoreBoardText;
    public string pseudo;
    public string score;


    public int scorePlayer1;
    public int scorePlayer2;
    public int test = 4; 
    
    

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/logiciel_b2_unity/getuserscore");
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Connection to the Database failed !");
        }
        else
        {
            string s = www.downloadHandler.text;

            for (int i = 0; i + 1 < s.Split('-').Length && i < 20; i += 2)
            {
                pseudo = s.Split('-')[i];
                score = s.Split('-')[i + 1];

                pseudo = pseudo.Replace("Pseudo: ", "");
                score = score.Replace("Score: ", "");
                score = score.Replace("<br>", "");

                Debug.Log("Pseudo = " + pseudo);
                Debug.Log("Score = " + score);

                if (pseudo == "player1")
                {
                    scorePlayer1 = Int32.Parse(score);                    

                }
                if (pseudo == "player2")
                {
                    scorePlayer2 = Int32.Parse(score);
                }

                if (score.Contains("\n"))
                {
                    Debug.Log("yes");
                }
                if(scoreBoardText != null)
                {
                    scoreBoardText.text += pseudo + " | " + score + Environment.NewLine;

                }
            }
        }
    }
}