using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{

    public void setPrefPerformance()
    {
        PlayerPrefs.SetInt("Graphic", 0);
    }
    public void setPrefHigh()
    {
        PlayerPrefs.SetInt("Graphic", 1);
    }

    public Guidance guidance;

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void openGuidance()
    {
        guidance.open();   
    }
    public void hidemenu()
    {
        gameObject.SetActive(false);
    }
    public void open()
    {
        gameObject.SetActive(true);

    }

}
