using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonNav : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    //button navigator for pause button
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    //button navigator in pause menu scenes
    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void MusicDown()
    {
        // SceneManager.LoadScene("Level 4");
    }
    public void MusicUp()
    {
        // SceneManager.LoadScene("Level 5");
    }

    public void SoundDown()
    {
        // SceneManager.LoadScene("Main Menu");
    }

    public void SoundUp()
    {
        // SceneManager.LoadScene("Main Menu");
    }
}
