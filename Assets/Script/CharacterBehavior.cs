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

    private void Awake() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value) {
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value) {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    void Update()
    {
        // Changed Rotate to Translate for movement
        transform.Translate(movementValue.x, 0, movementValue.y);
        // Keep rotation for looking
        transform.Rotate(0, lookValue * Time.deltaTime, 0);
    }
}