using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float mouseSensitivity = 1.0f;
    public float jumpForce = 5f;
    public float gravity = 20f;

    private float verticalRotation = 0;
    private Rigidbody rb;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // sets rb as Rigidbody

        Cursor.lockState = CursorLockMode.Locked; // locks the cursor 

        
    }

    // Update is called once per frame
    void Update()
    {
        WASD(); // calls the function WASD()

        RotationInputM(); // calls the function RotationInputM()
        // Apply gravity if not grounded
        if (!isGrounded)
        {
            rb.velocity += Vector3.up * -gravity * Time.deltaTime;
        }

        // Check if the player is on the ground to allow jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void RotationInputM()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity; // create a float to declare the horizontal rotation of the mouse, effected by sensitivity.

        transform.Rotate(0, horizontalRotation, 0); // move the camera around the y according to mouse movement 

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity; // declare that the input for verticle movement is the +- mouse movement across the y axis

        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90); // clamp the rotation between -90, 90 to stop overlapping

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); // grab the camera to match with vertical rotation

    }

    void WASD()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  // takes horizontal input from WASD and arrow keys

        float moveVertical = Input.GetAxis("Vertical");  // takes vertical input from WASD and arrow keys

        Vector3 movement = new Vector3(moveHorizontal,0,moveVertical) * movementSpeed * Time.deltaTime;  // control movement using movespeed and time.deltaTime

        movement = transform.TransformDirection(movement);  // make sure player is facing the right direction

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // set velocity of the rb to match Y
    }

    // Jump function
    void Jump()
    {
        // Apply the jump force only along the Y axis
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        isGrounded = false;  // Set isGrounded to false since the player is in the air after jumping
    }

    // Check if player is grounded
    private void OnCollisionStay(Collision collision)
    {
        // If the player is colliding with something from below (ground), allow jumping
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // When the player leaves the ground (e.g., stepping off a ledge), stop jumping
        isGrounded = false;
    }
}
