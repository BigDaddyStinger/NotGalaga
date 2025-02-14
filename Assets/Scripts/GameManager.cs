using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;
using UnityEditor.Build;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TMP_Text TopLeftText;
    [SerializeField] TMP_Text TopRightText;
    [SerializeField] TMP_Text MiddleBanner;
    [SerializeField] public int playerScore;
    [SerializeField] public int lives;
    [SerializeField] public int playerLives;
    [SerializeField] public bool isGameOver = false;
    [SerializeField] Button restartButton;

    public GameObject gameOverUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        GameSetup();
       if (restartButton != null)
       {
            restartButton.onClick.AddListener(ResetGame);
       }
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateScore();
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameSetup()
    {
        playerScore = 0;
        lives = 3;
        TopLeftText.text = "Score: " + playerScore;
        TopRightText.text = lives + " Lives";
        return;

    }

    public void AddScoreSmall(int smallPoints) 
    {

        playerScore += smallPoints;
        return;
    }

    public void AddScoreBig(int bigPoints)
    {
        playerScore += bigPoints;
        return;
    }

    public void AddLives(int playerLives)
    {
        lives += playerLives;
        return;
    }

    public void ReduceLives(int playerLives)
    {
            lives -= playerLives;
        if (lives <= 0)
            isGameOver = true;
        else
        return;
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            isGameOver = true;
            MiddleBanner.text = "Game Over";
            gameOverUI.SetActive(true);
        }
    }

    public void UpdateScore()
    {
        TopLeftText.text = "Score: " + playerScore;
        TopRightText.text = lives + " Lives";
    }


}
