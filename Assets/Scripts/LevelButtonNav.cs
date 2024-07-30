using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonNav : MonoBehaviour
{
    public static LevelButtonNav Instance;
    public static int currLevel;

    // Buttons for each level
    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;
    public Button levelFourButton;
    public Button levelFiveButton;

    [SerializeField] GameObject[] levelProgressBar;
    [SerializeField] GameObject[] lockLevel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // ResetProgress();

        // Initialize the first level as unlocked if not already done
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 1); // 1 means unlocked, 0 means locked
        }

        // Check and set button interactability based on unlocked levels
        levelOneButton.interactable = PlayerPrefs.GetInt("Level1", 0) == 1;
        levelTwoButton.interactable = PlayerPrefs.GetInt("Level2", 0) == 1;
        levelThreeButton.interactable = PlayerPrefs.GetInt("Level3", 0) == 1;
        levelFourButton.interactable = PlayerPrefs.GetInt("Level4", 0) == 1;
        levelFiveButton.interactable = PlayerPrefs.GetInt("Level5", 0) == 1;

        // Activate the progress bar for completed levels
        UpdateProgressBars();
    }

    // Button navigator in level selection scenes
    public void LevelOne()
    {
        if (PlayerPrefs.GetInt("Level1", 0) == 1)
        {
            AudioManager.Instance.PlaySFX("dink");
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("lv1");
            SceneManager.LoadScene("Level 1");
            currLevel = 1;
        }
    }

    public void LevelTwo()
    {
        if (PlayerPrefs.GetInt("Level2", 0) == 1)
        {
            SceneManager.LoadScene("Level 2");
            currLevel = 2;
        }
    }

    public void LevelThree()
    {
        if (PlayerPrefs.GetInt("Level3", 0) == 1)
        {
            SceneManager.LoadScene("Level 3");
            currLevel = 3;
        }
    }

    public void LevelFour()
    {
        if (PlayerPrefs.GetInt("Level4", 0) == 1)
        {
            SceneManager.LoadScene("Level 4");
            currLevel = 4;
        }
    }

    public void LevelFive()
    {
        if (PlayerPrefs.GetInt("Level5", 0) == 1)
        {
            SceneManager.LoadScene("Level 5");
            currLevel = 5;
        }
    }

    public void HomeButton()
    {
        AudioManager.Instance.PlaySFX("clop");
        SceneManager.LoadScene("Main Menu");
    }

    public int GetCurrLevel()
    {
        return currLevel;
    }

    // Call this method when a level is completed successfully
    public void UnlockNextLevel()
    {
        int nextLevelToUnlock = currLevel + 1;
        PlayerPrefs.SetInt("Level" + nextLevelToUnlock, 1);
    }

    // Method to update progress bars based on unlocked levels
    public void UpdateProgressBars()
    {
        for (int i = 0; i < levelProgressBar.Length; i++)
        {
            int levelToCheck = i + 2; // Progress bars correspond to levels 2, 3, 4, and 5
            if (PlayerPrefs.GetInt("Level" + levelToCheck, 0) == 1)
            {
                levelProgressBar[i].SetActive(true);
                lockLevel[i].SetActive(false);
            }
            else
            {
                levelProgressBar[i].SetActive(false);
                lockLevel[i].SetActive(true);
            }
        }
    }

    

    // // Method to reset progress
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("Level1", 1); // Keep the first level unlocked
        PlayerPrefs.SetInt("Level2", 0); // Lock all other levels
        PlayerPrefs.SetInt("Level3", 0);
        PlayerPrefs.SetInt("Level4", 0);
        PlayerPrefs.SetInt("Level5", 0);

        currLevel = 1;
    }
}
