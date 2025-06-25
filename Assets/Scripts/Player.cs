using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Input = UnityEngine.Windows.Input;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    private Rigidbody2D rb;
    private float movingspeed = 5f;
    private float minMovSpeed = 0.1f;
    private bool isRunning = false;
    
    

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement(); 
    }

    private void Update()
    {
        Vector2 inputVector = GameInput.instance.GetMovementVector();

        if (inputVector.magnitude > minMovSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.instance.GetMovementVector();
        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * movingspeed * Time.fixedDeltaTime);
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
    
}

