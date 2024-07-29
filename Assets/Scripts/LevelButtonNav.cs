using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonNav : MonoBehaviour
{
    public static int currLevel;
    private int nextLevel;

    //button navigator in level selection scenes
    public void LevelOne()
    {
        AudioManager.Instance.PlaySFX("dink");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("lv1");
        SceneManager.LoadScene("Level 1");
        currLevel = 1;
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
        currLevel = 2;
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
        currLevel = 3;
    }
    public void LevelFour()
    {
        SceneManager.LoadScene("Level 4");
        currLevel = 4;
    }
    public void LevelFive()
    {
        SceneManager.LoadScene("Level 5");
        currLevel = 5;
    }

    public void HomeButton()
    {
        AudioManager.Instance.PlaySFX("dink");
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevelButton()
    {
        nextLevel = currLevel + 1;
        SceneManager.LoadScene("Level " + nextLevel);
    }

    public int GetCurrLevel()
    {
        return currLevel;
    }
}
