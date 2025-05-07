using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text chocolateText;
    public Text livesText;
    public Transform heartsPanel; 

    private List<GameObject> hearts = new List<GameObject>();
    private int chocolateCount = 0;
    private int lives = 3;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
       
        foreach (Transform heart in heartsPanel)
        {
            hearts.Add(heart.gameObject);
        }

        UpdateUI();
    }

    public void AddChocolate()
    {
        chocolateCount++;
        UpdateUI();
        if (chocolateCount >= 20)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Ganaste");
        }
    }

    public void LoseLife()
    {
        if (lives <= 0) return;

        lives--;

        
        if (hearts.Count > 0)
        {
            GameObject heartToRemove = hearts[hearts.Count - 1];
            heartToRemove.SetActive(false);
            hearts.RemoveAt(hearts.Count - 1);
        }

        UpdateUI();

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Moriste");
        }
    }

    void UpdateUI()
    {
        chocolateText.text = "Chocolates: " + chocolateCount;
        livesText.text = "Vidas: " + lives;
    }
}
