using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int lives = 3;

    private int score = 0;

    private int currLevel;
    


    [SerializeField] GameObject[] fullHeart; // Assign these in the Inspector
    [SerializeField] GameObject[] brokenHeart; // Assign these in the Inspector

    [SerializeField] GameObject winMenu;

    [SerializeField] GameObject winButton;
    [SerializeField] GameObject winButtonLevel5;

    [SerializeField] GameObject loseMenu;

    [Tooltip("Minimum time for spawning.")]
    public int targetScore = 15;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        BookNavButton.Instance.BookOpenButton();
    }

    public void CorrectDrop()
    {
        score += 1;
        UpdateUI();

        if (score >= targetScore){
            // You Win!
            Debug.Log("You Win!");
            AudioManager.Instance.PlaySFX("yay");
             // You Win Scene Activated
            LevelButtonNav.Instance.UnlockNextLevel();
            
            if(LevelButtonNav.Instance.GetCurrLevel() == 5){
                winButton.SetActive(false);
                winButtonLevel5.SetActive(true);
            }
            else{
                winButtonLevel5.SetActive(false);
                winMenu.SetActive(true);
            }
            Time.timeScale = 0;
        }
    }

    public void WrongDrop()
    {
        lives -= 1;
        UpdateUI();

        if (lives <= 0)
        {
            // Game Over
            Debug.Log("Game Over!");
            AudioManager.Instance.PlaySFX("aww");
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateUI()
    {
        // Update score in log
        Debug.Log("Score: " + score);

        // Update life images
        for (int i = 0; i < 3; i++)
        {
            if (i < lives)
            {
                fullHeart[i].SetActive(true);
                brokenHeart[i].SetActive(false);
            }
            else
            {
                fullHeart[i].SetActive(false);
                brokenHeart[i].SetActive(true);
            }
        }
    }
}
