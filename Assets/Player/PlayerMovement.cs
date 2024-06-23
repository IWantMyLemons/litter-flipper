using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkForce;
    public float slideMultiplier;
    public float brakingForce;
    public float speedLimit;

    Rigidbody2D rb;

    Vector2 inputDirection;
    bool isSliding;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input devices
        isSliding = Input.GetButton("Jump");

        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");

        inputDirection = inputDirection.normalized;
    }

    void FixedUpdate()
    {
        // Walc
        if (float.Epsilon < inputDirection.magnitude)
        {
            rb.AddForce((isSliding ? slideMultiplier : 1) * Time.fixedDeltaTime * walkForce * inputDirection);
        }

        // Clamp to speed limit
        if (rb.velocity.magnitude > speedLimit)
        {
            rb.velocity = speedLimit * rb.velocity.normalized;
        }

        // If not sliding, brake movement
        if (!isSliding)
        {
            rb.AddForce(Time.fixedDeltaTime * brakingForce * -rb.velocity);
        }
    }
}
