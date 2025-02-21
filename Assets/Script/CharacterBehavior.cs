using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterBehavior : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rb;  // Private Rigidbody reference

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();  // Cache the Rigidbody component
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x;
    }

    void Update()
    {
        // Add movement force - multiply by speed to make it noticeable
        rb.AddRelativeForce(
            movementValue.x * speed * Time.deltaTime,  // Left/Right
            0,
            movementValue.y * speed * Time.deltaTime); // Forward/Back

        // Add rotation torque - multiply by rotationSpeed for better control
        rb.AddRelativeTorque(0, lookValue * rotationSpeed * Time.deltaTime, 0);
    }
}