using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform target;                   // set your target
    public float distance = 5.0f;              // set the distance from traget
    public float sensitivity = 2.0f;           // set the sensitivity
    public float heightOffset = 1.5f;          // set the height 

    private float rotationX = 0.0f;            
    private float rotationY = 0.0f;


    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    // lock the cursor into the game 
        Cursor.visible = false;                 // make cursor invisable 
         
    }

    void Update()
    {
        HandleCameraInput();
        transform.LookAt(target);

    }
    void HandleCameraInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;    // rotate camera based on mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;    // rotate camera based on mouse movement

        rotationY += mouseX;                                      // update camera horizontal 

        rotationX -= mouseY;                                      // update camera verticle 

        rotationX = Mathf.Clamp(rotationX, -90,90);               // clamp camera movement

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0); // apply the rotation
    }

    // Update is called once per frame
    
    // late update is called after all update functions have been calle. this is useful to order the code. 
    void LateUpdate()
    {

        FollowTarget();
    }
    
    void FollowTarget()
    {
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * heightOffset;  // sets the camera position using target position, checks the camera is facing forward, usues distance and the height

        transform.position = targetPosition; // moves camera to correct location
    }
}
