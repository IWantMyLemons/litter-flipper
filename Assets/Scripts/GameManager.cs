using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int lives = 3;

    private int score = 0;

    [SerializeField] GameObject[] fullHeart; // Assign these in the Inspector
    [SerializeField] GameObject[] brokenHeart; // Assign these in the Inspector

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void CorrectDrop()
    {
        score += 1;
        UpdateUI();

        if (score >= 10){
            // You Win!
            Debug.Log("You Win!");
             // You Win Scene Activated
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
            // Game Over Scene Activated
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
