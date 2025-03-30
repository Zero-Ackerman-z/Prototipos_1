using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SnakeData", menuName = "Snake/Snake Data")]
public class SnakeData : ScriptableObject
{
    [SerializeField] public float MoveSpeed;
   // [SerializeField] private int initialSize = 3;
    [SerializeField] public Color SnakeColor;

    //public float MoveSpeed => moveSpeed;
    //public int InitialSize => initialSize;
    //public Color SnakeColor => snakeColor;
}

