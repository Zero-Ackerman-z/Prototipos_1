using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        HideGameOver();
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void HideGameOver()
    {
        gameOverScreen.SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame(); 
    }
}
