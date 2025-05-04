using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int playerHP = 3;

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
            // Add game over logic here*************Add scene
        }
    }
}

