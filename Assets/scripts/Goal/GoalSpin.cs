using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpin : MonoBehaviour
{
    // Adjust the speed of the rotation in degrees per second in the Inspector.
    public float rotationSpeed = 50f;

    // This method is called once per frame.
    void Update()
    {
        // Rotate the object around its axis continuously.
        
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }
}

