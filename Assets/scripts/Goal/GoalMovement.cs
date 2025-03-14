using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMovement : MonoBehaviour
{
    // Adjust the speed of the movement in the Inspector.
    public float moveSpeed = 1.0f;

    // Adjust the height of the oscillation in the Inspector.
    public float amplitude = 1.0f;

    // Store the initial position of the object.
    private Vector3 startPos;

    // This method is called once when the script starts.
    void Start()
    {
        // Store the initial position of the object.
        startPos = transform.position;
    }

    // This method is called once per frame.
    void Update()
    {
        // Calculate the vertical movement using Mathf.Sin to create an oscillation effect.
        // Time.time is used to creat a smooth oscillation.
        float verticalMovement = Mathf.Sin(Time.time * moveSpeed) * amplitude;

        // Update the object's position by adding the vertical movement to its initial position.
        Vector3 newPosition = startPos + Vector3.up * verticalMovement;
        transform.position = newPosition;
    }
}

