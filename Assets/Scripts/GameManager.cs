using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TMP_Text TopLeftText;
    [SerializeField] TMP_Text TopRightText;
    public int score;
    public int lives;
    public int points;
    [SerializeField] bool isGameOver = false;
    [SerializeField] Button restartButton;

    public GameObject gameOverUI;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
        GameSetup();
       if (restartButton != null)
       {
            restartButton.onClick.AddListener(ResetGame);
       }
//        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // finish making the game over menu
            //
            // gameOverMenu.SetActive(!gameOverMenu.activeInHierarchy);
        }
        TopLeftText.text = "Score: " + score;
        TopRightText.text = lives + " Lives";
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameSetup()
    {
        score = 0;
        lives = 3;
        TopLeftText.text = "Score: " + score;
        TopRightText.text = lives + " Lives";

    }

    public void AddScoreSmall(int smallPoints) 
    {

        score += smallPoints; 
    }

    public void AddScoreBig(int bigPoints)
    {
        score += bigPoints;
    }

    public void AddLives()
    {
        lives++;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverUI.SetActive(true);
        }
    }


}
