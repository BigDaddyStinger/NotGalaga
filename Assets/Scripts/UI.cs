using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text TopLeftText;
    [SerializeField] TMP_Text TopRightText;
    [SerializeField] int score;
    [SerializeField] int lives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameSetup()
    {
        score = 0;
        lives = 3;
        TopLeftText.text = "Score: " + score;
        TopRightText.text = lives + " Lives";

    }
}
