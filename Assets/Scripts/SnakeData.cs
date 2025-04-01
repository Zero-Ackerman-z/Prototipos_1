using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SnakeData", menuName = "Snake/Snake Data")]
public class SnakeData : ScriptableObject
{
    [SerializeField] public float MoveSpeed;
    [SerializeField] public Color SnakeColor;

    
}

