using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager gameManger = FindObjectOfType<GameManager>();  // checks for the game manager script

            if (gameManger != null)  // checks the game manager is not empty
            {
                gameManger.AddCollectedCoin(1); // add coin to AddCollectedCoin
            }
        
            Destroy(gameObject); // destroys the game object
        }


        
    }
    
}
