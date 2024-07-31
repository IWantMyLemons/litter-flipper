using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonNav : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private int currLevel;
    private int nextLevel;

    //button navigator for pause button
    public void PauseButton()
    {
        AudioManager.Instance.PlaySFX("dink");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    //button navigator in pause menu scenes
    public void HomeButton()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("Menu");
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

    public void NextLevelButton()
    {
        LevelButtonNav.Instance.NextLevelButton();
    }
    
}
