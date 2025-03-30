using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public static FoodSpawner Instance { get; private set; }
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Vector2 gridSizeX;
    [SerializeField] private Vector2 gridSizeY;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-gridSizeX.x, gridSizeX.x), Random.Range(-gridSizeY.y, gridSizeY.y));
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}
