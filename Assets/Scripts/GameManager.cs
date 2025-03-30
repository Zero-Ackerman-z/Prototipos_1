using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int score;
    public bool IsGamePaused { get; private set; }

    public delegate void ScoreChanged(int newScore);
    public static event ScoreChanged OnScoreChanged;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        SnakeController.OnGameOver += GameOver;
    }
    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
        IsGamePaused = true;
        Time.timeScale = 0;
    }

    public void AddScore(int points)
    {
        score += points;
        OnScoreChanged.Invoke(score);
    }
    public void RestartGame()
    {
        score = 0; 
        OnScoreChanged?.Invoke(score); 
        IsGamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


