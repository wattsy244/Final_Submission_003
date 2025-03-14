using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gameManger = FindObjectOfType<GameManager>();  // checks for the game manager script

            if (gameManger != null)  // checks the game manager is not empty
            {
                gameManger.DamageDelt(damage); // add coin to AddCollectedCoin
            }

           
        }



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
