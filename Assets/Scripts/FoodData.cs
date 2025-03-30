using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Snake/Food Data")]
public class FoodData : ScriptableObject
{
    [SerializeField] public int ScoreValue;
    [SerializeField] public Color FoodColor;
   
}
