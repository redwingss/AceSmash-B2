using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSystem : MonoBehaviour
{
    public GameObject fighter1;
    public GameObject fighter2;

    public GameObject[] fighter1Sticks;
    public GameObject[] fighter2Sticks;

    public GameObject fighter1Wins;
    public GameObject fighter2Wins;

    public int lifeFighter1;
    public int lifeFighter2;

    public string pseudoPlayer;
    public string pseudoPlayer2 = "player2";

    public int scorePlayer;
    public int scorePlayer2;


    public string maimMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeFighter1 <= 0) //player2 win
        {
            scorePlayer = FindObjectOfType<Bdd>().scorePlayer2;
            pseudoPlayer = "player2";
            fighter1.SetActive(false);
            fighter2Wins.SetActive(true);
        }

        if (lifeFighter2 <= 0) //player1 win
        {           
            pseudoPlayer = "player1";
            scorePlayer = FindObjectOfType<Bdd>().scorePlayer1;
            fighter2.SetActive(false);
            fighter1Wins.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }

    }

    public void TouchFighter1()
    {
        lifeFighter1 -= 1;

        for (int i = 0; i < fighter1Sticks.Length; i++)
        {
            if(lifeFighter1 > i)
            {
                fighter1Sticks[i].SetActive(true);
            } else {
                fighter1Sticks[i].SetActive(false);
            }
        }
    }

        public void TouchFighter2()
    {
        lifeFighter2 -= 1;

        for (int i = 0; i < fighter2Sticks.Length; i++)
        {
            if(lifeFighter2 > i)
            {
                fighter2Sticks[i].SetActive(true);
            } else {
                fighter2Sticks[i].SetActive(false);
            }
        }
    }
}
