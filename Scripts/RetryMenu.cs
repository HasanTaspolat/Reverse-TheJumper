using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryMenu : MonoBehaviour
{
    public Text HighScore;

    public void loadRetry()
    {
        Invoke("Setvisible", 1);
    }

    public void Setvisible()
    {
        gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void RestratGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
  
    }
    public void SetHighscoreInretry()
    {
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
   

}
