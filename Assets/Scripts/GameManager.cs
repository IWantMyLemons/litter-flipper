using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;

    [SerializeField] GameObject[] lifeImages; // Assign these in the Inspector
    [SerializeField] GameObject[] brokenLifeImages;

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
        UpdateUI();
    }

    public void WrongDrop()
    {
        lives -= 1;
        UpdateUI();

        if (lives <= 0)
        {
            // Game Over
            Debug.Log("Game Over!");
            // Implement game over logic here
        }
    }

    void UpdateUI()
    {
        // Update life images
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < lives)
            {
                lifeImages[i].SetActive(true);
                brokenLifeImages[i].SetActive(false);
            }
            else
            {
                lifeImages[i].SetActive(false);
                brokenLifeImages[i].SetActive(true);
            }
        }
    }
}
