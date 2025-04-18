using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 60f; // Time limit for the game in seconds
    public bool isGameOver = false; // Flag to check if the game is over
    private static GameManager instance; // Singleton instance of the GameManager
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public GameObject winPanel; // Reference to the Win panel
    public GameObject timeOverObject;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>(); // Try to find an existing instance in the scene
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeLimit -= Time.deltaTime; // Decrease the time limit by the time passed since the last frame
            if (timeLimit <= 0)
            {
                GameOver(); // Call the GameOver method if the time limit is reached
            }
        }
    }

    public void GameOver()
    {
        timeOverObject.SetActive(false); // Show the time over object
        gameOverPanel.SetActive(true); // Show the Game Over panel
        isGameOver = true; // Set the game over flag to true
        Debug.Log("Game Over!"); // Log the game over message
    }

    public void CheckPointPassed()
    {
        if (!isGameOver)
        {
            timeLimit += 5f;
        }
    }

    public void GameWin()
    {
        if (!isGameOver)
        {
            winPanel.SetActive(true); // Show the Win panel
            isGameOver = true; // Set the game over flag to true
            Debug.Log("You Win!"); // Log the win message
        }
    }
}
