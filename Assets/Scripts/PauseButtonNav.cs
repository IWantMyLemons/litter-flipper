using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonNav : MonoBehaviour
{
    //button navigator for pause button
    public void PauseButton()
    {
        // SceneManager.LoadScene("Main Menu");
    }

    //button navigator in pause menu scenes
    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ResumeButton()
    {
        SceneManager.LoadScene("Main Menu");
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
