using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    //--------------------Ai track distance-------------------------------------
    // Drag and drop the player's GameObject into this field in the Inspector.
    public Transform player;
    // Adjust the detection distance in the Inspector.
    public float detectionDistance = 10.0f;

    private bool InRange = false;
    //----------------------Ai attack distance-------------------------------------


    // Adjust the detection distance in the Inspector.
    public float DeathSpace = 2.0f;

    private bool Dead = false;
    //---------------------Ai movement---------------------------------------------
    // public varaiable assigning the targets transform in the inspector
    // representing the destination for NavMeshAgent
    public Transform target;
    // a private reference to the NavMeshAgent that will handle the navigation for the game object

   
    //----------------------------------------------------------------------
    

    //------------------------------------------------------
    private State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Search;
       
        
    }



    private enum State
    {
        Search,
        Attack,
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        switch (currentState)
        {
            case State.Search:
                Debug.Log("in searching state");
                // sets a random point on the navmesh
                //agent.SetDestination(Random.insideUnitSphere * 420);


                break;
            // in stsate B
            case State.Attack:
                Debug.Log("Firing");
                // checks there is a target
                if (target != null)
                {
                    // go to target
                    //agent.SetDestination(target.position);
                }
                break;



            

        }
        // Calculate the distance between this GameObject and the player.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        // Check if the player is close enough.
        if (distanceToPlayer <= detectionDistance)
        {
            InRange = true;
            // Display a message when the player is close enough.
            Debug.Log("Player InRange");
        }

        if (distanceToPlayer >= detectionDistance)
        {
            InRange = false;
            // Display a message when the player is close enough.
            Debug.Log("Player not InRange");
        }
        

        // Check if the player is in range.
        if (distanceToPlayer <= DeathSpace)
        {
            Dead = true;
            // Display a message when the player is close enough.
            Debug.Log("Player dead");


        }
        SwitchState();
        
       
    }



    public void SwitchState()
    {
        if (currentState == State.Search)
        {
            if (InRange == true)
            {
                currentState = State.Attack;


            }



        }

        if (currentState == State.Attack)
        {
            if (InRange == false)
            {
                currentState = State.Search;
            }

        }

    }



}
