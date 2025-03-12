using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

            
public class BTNManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    public void NewLevelBtn(string newLevel)
    {
        SceneManager.LoadScene("TheChase");                   // loads the scene that you name as string 
    }

    // ExitGameBtn
    /* step 1: Create another custom method for exiting the game
     * step 2: quit the application 
     */

    public void ExitGameBtn()
    {
        Application.Quit();        // exits the application
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
