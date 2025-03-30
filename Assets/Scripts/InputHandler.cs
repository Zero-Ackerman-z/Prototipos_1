using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private SnakeControls controls;
    public Vector2 MoveDirection { get; private set; }

    private void Awake()
    {
        controls = new SnakeControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Move.performed += ctx => SetDirection(ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    private void SetDirection(Vector2 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            MoveDirection = new Vector2(Mathf.Sign(input.x), 0);
        }
        else
        {
            MoveDirection = new Vector2(0, Mathf.Sign(input.y));
        }
    }
}


