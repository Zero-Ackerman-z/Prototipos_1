using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] public SnakeData snakeData;
    [SerializeField] public Transform bodyPrefab;
    private InputHandler inputHandler;

    private Vector2 direction;
    private List<Transform> snakeBody = new List<Transform>();
    
    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;
    private void Awake()
    {
        inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().color = snakeData.SnakeColor;
        InvokeRepeating(nameof(Move), snakeData.MoveSpeed, snakeData.MoveSpeed);
    }

    public void Move()
    {
        Vector2 newDirection = inputHandler.MoveDirection;

        if (newDirection != Vector2.zero && newDirection != -direction)
        {
            direction = newDirection;
        }

        Vector2 newPosition = (Vector2)transform.position + direction;

        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].position = snakeBody[i - 1].position;
        }

        if (snakeBody.Count > 0)
        {
            snakeBody[0].position = transform.position;
        }

        transform.position = newPosition;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Debug.Log("Comida detectada: " + collision.name);

            Food food = collision.GetComponent<Food>();
            if (food != null)
            {
                FoodData selectedFood = food.FoodInfo; 

                if (selectedFood != null)
                {
                    Grow();

                    SpriteRenderer headRenderer = GetComponentInChildren<SpriteRenderer>();
                    if (headRenderer != null)
                    {
                        headRenderer.color = selectedFood.FoodColor;
                    }

                    foreach (Transform segment in snakeBody)
                    {
                        SpriteRenderer segmentRenderer = segment.GetComponentInChildren<SpriteRenderer>();
                        if (segmentRenderer != null)
                        {
                            segmentRenderer.color = selectedFood.FoodColor;
                        }
                    } 

                    Destroy(collision.gameObject);
                    FoodSpawner.Instance.SpawnFood();
                    GameManager.Instance.AddScore(selectedFood.ScoreValue);
                }
            }
        }
        else if (collision.CompareTag("Body") || collision.CompareTag("Wall"))
        {
            Debug.Log("Game Over: colisión con el cuerpo");
            OnGameOver?.Invoke();
        }
    }

    private void Grow()
    {
        Transform newPart = Instantiate(bodyPrefab);

        if (snakeBody.Count > 0)
        {
            newPart.position = snakeBody[snakeBody.Count - 1].position; 
        }
        /*
        else
        {
            newPart.position = transform.position; 
        }
        */
        snakeBody.Add(newPart);

    }

}
