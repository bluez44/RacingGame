using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel; // Reference to the Game Over panel

    void Update()
    {
        ShowTimerText();
    }

    public void ShowTimerText()
    {
        timerText.SetText(GameManager.Instance.timeLimit.ToString("0.00")); // Set the timer text to the current time limit
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game"); // Load the Menu scene
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu"); // Load the Menu scene
    }
}

