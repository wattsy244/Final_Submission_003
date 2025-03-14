using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject target;
    Vector3 LastKnownposition = Vector3.zero;
    Quaternion LookRotation;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if a target is set
        if (target != null)
        {
            if (LastKnownposition != target.transform.position)
            {
                // sets last known position to the traget location
                LastKnownposition = target.transform.position;
                // sets where we want to aim
                LookRotation = Quaternion.LookRotation(LastKnownposition - transform.position);

            }
            //rotates turret to rotate to the target
            if (transform.rotation != LookRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, LookRotation, speed * Time.deltaTime);
            }

        }
    }

    
}
