using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public GameObject PauseButton;
    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
       PauseButton.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuScreen.SetActive(false);
        PauseButton.SetActive(true);

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Start Scene 1");
    }
}

