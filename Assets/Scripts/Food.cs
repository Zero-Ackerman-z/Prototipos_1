using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    [SerializeField] private List<FoodData> foodDataList = new List<FoodData>();
    /*public FoodData FoodInfo => foodDataList.Count > 0 ? foodDataList[0] : null;
    
   
    public void SetFoodData(FoodData newFoodData)
    {
        if (foodDataList.Contains(newFoodData))
        {
            foodDataList[0] = newFoodData;
        }
    }
    */
    private FoodData selectedFoodData;
    private SpriteRenderer spriteRenderer;

    public FoodData FoodInfo => selectedFoodData;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SelectRandomFood();
    }

    private void SelectRandomFood()
    {
        if (foodDataList.Count > 0)
        {
            selectedFoodData = foodDataList[Random.Range(0, foodDataList.Count)];
            if (spriteRenderer != null)
            {
                spriteRenderer.color = selectedFoodData.FoodColor;
            }
        }
    }
}
