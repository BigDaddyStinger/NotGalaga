using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // finish making the game over menu
            //
            // gameOverMenu.SetActive(!gameOverMenu.activeInHierarchy);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
