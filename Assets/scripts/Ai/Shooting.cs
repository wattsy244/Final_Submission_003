using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate;
    public GameObject projectile;
    public float FOV;

    public GameObject target;
   //velocity of bullets
    public int force;
    public float range;
   
    

    //barrel
    public GameObject Barrel;

    //
    public ObjectPool myObjectPool;

    //creats a list of the projectiles fired
    List<GameObject> Lastprojectiles = new List<GameObject>();
    float Timer = 0.0f;
    //raycasting stuff
    public float sightRange = 10f;
    bool Inrange=true;
    bool InSight = false;
    //--------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            //perform the raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, sightRange))
            {
                if( hit.collider.gameObject == target)
                {
                    InSight = true;
                    Debug.Log("in sight");
                }
                else
                {
                    InSight = false;
                    Debug.Log("not in sight");
                }
            }
            else
            {
                Inrange = false;
                Debug.Log("not in range");
            }
        }

        if (InSight && Inrange == true)
        {


            Timer += Time.deltaTime;
            if (Timer >= fireRate)
            {
                //checks that the gun is aiming at target
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
                if (angle < FOV)
                {

                    FireBullet();
                    Timer = 0.0f;

                }
            }
        }

       
    }

    void FireBullet()
    {
       
        
            //shoot
            // sets bullet prefab as my CB and instanitaes it
            
            // links to the objectpool and runs the getpooledObject function which will fire the last object in the array
            GameObject myCB = myObjectPool.GetPooledObject();

            // spawns the cannonball at the barrel
            myCB.transform.position = new Vector3(Barrel.transform.position.x, Barrel.transform.position.y, Barrel.transform.position.z);
            // get rigibody as myRB
            Rigidbody myRB = myCB.GetComponent<Rigidbody>();
            //add force based on player location
            myRB.AddForce((target.transform.position  - transform.position)* force);
          
            
        
    }

    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, (target.transform.position - transform.position).normalized * sightRange);
        }
    }
}
