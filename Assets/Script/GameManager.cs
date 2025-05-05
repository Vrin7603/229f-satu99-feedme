using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int playerHP = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hpText;

    public static GameManager Instance;

    void Awake()
    {
        // Make this a global singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void ReduceHP(int amount)
    {
        playerHP -= amount;
        Debug.Log("HP: " + playerHP);
        if (playerHP <= 0)
        {
            Debug.Log("Player is defeated!");
            SceneManager.LoadScene("EndScene");
        }
    }
    void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score;
            hpText.text = "HP: " + GameManager.Instance.playerHP;

            // Set text colors
            scoreText.color = Color.yellow;
            hpText.color = Color.red;
        }
    }

    
}

