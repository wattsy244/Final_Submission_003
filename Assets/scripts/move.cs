using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpForce = 5f;
    public float gravity = 20f;
    public CharacterController characterController;
    public Camera mainCamera;
    public float cameraDistance = 5f;
    public float cameraHeight = 2f;
    private Vector3 moveDirection = Vector3.zero;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WASD();
        
       
    }

    void WASD()
    {
        //movemnt input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontalInput,0,verticalInput);

        //rotate the player
        if (moveVector != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        //apply movement 
        moveDirection = moveVector * moveSpeed;
        moveDirection = transform.rotation * moveDirection;

        //gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //jump
        if(Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpForce;

        }

        //apply movement with characterController
        characterController.Move(moveDirection * Time.deltaTime);

    }

    void Camera()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //get cameras vectors
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        //remove the Y 
        cameraForward.y = 0;
        cameraRight.y = 0;

        //normalize the vectors
        cameraForward.Normalize();
        cameraRight.Normalize();

        //move direction
        Vector3 moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput) * moveSpeed;
    }
}
