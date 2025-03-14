using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Pool of objects
    public GameObject[] objectPool;

    //count of array
    public int countOfPool;

    // cannonball prefab
    public GameObject Bullet;

    int LastIndex;

    // Start is called before the first frame update
    void Start()
    {
        // assign objectpool as the array of count as pool
        objectPool = new GameObject[countOfPool];
        // create a for loop to start when the amount of preabs is below the max amount of the array
        for (int i = 0; i < countOfPool; i++) 
        {
            // assign the prefab into the array
            objectPool[i] = Instantiate(Bullet) as GameObject;
            objectPool[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        int passIndex = LastIndex;

        //increment last index by 1
        LastIndex++;

        //check if out of bounds of array
        if(LastIndex == countOfPool) LastIndex = 0;//loops back to start of array

        //activate the object
        objectPool[passIndex].SetActive(true);
        return objectPool[passIndex];

    }



}
