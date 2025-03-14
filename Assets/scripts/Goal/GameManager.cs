using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int CollectedCoin = 0; // declare CollectedCoin as an int that equals 0
    public int health = 100;
   

    public void AddCollectedCoin(int amount)
    {

        CollectedCoin += amount;   // collected coin + the amount collected

        if(CollectedCoin >= 10)  // if coins collected = 2 then
        {
            SceneManager.LoadScene("You Win"); // load scene "You Win"
        }
    }

    public void DamageDelt(int amount)
    {
        health -= amount;
        Debug.Log(health);

        if (health <= 0 )
        {
            SceneManager.LoadScene("Death Screen");
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
