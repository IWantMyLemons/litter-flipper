using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonNav : MonoBehaviour
{
    //button navigator in level selection scenes
    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void LevelFour()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void LevelFive()
    {
        SceneManager.LoadScene("Level 5");
    }

     public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
