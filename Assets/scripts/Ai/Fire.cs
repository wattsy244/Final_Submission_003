using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // bullet prefab
    public GameObject CannonBall;

    //fre rate
    public float CoolDown;
    float Timer;

    //barrel
    public GameObject Barrel;

    //
    public ObjectPool myObjectPool;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        // sets the timer to the framerate
        Timer += Time.deltaTime;
        //calls FireBullet function
        FireBullet();
        
    }

    void FireBullet()
    {
        if (Timer > CoolDown)
        {
            //shoot
            // sets cannon ball prefab as my CB and instanitaes it
           // GameObject myCB = Instantiate(CannonBall) as GameObject; // replace with a call to the object pool
            // links to the objectpool and runs the getpooledObject function which will fire the last object in the array
            GameObject myCB = myObjectPool.GetPooledObject();

            // spawns the cannonball at the barrel
            myCB.transform.position = new Vector3(Barrel.transform.position.x, Barrel.transform.position.y,Barrel.transform.position.z);
            // get rigibody as myRB
            Rigidbody myRB = myCB.GetComponent<Rigidbody>();
            //add force to the rigibody of the cannon ball
            myRB.AddForce(new Vector3(0, 1000, 2000));
            //resets the timer
            Timer = 0.0f;
        }
    }
}
