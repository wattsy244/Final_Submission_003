using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public GameObject coin;  // set the object we want to spawn
    public int numberToSpawn = 10; // set the amount 
    public float distanceCoin = 2.0f; // set the distance between each object
    // Start is called before the first frame update
    void Start()
    {
        // check if "i" is less than the number of objects we want to spawn,  if not stop
        // initate coin prefab, move its position to (0,0,0), keep rotation the same

        for(var i = 0; i < numberToSpawn; i++)
        {
            Instantiate(coin, new Vector3(i * distanceCoin,0,0),Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
