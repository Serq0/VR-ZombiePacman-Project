using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{

    public NavMeshAgent nmAgent;
    public Transform Player;
    float MoveSpeed = 2.0f;
    int MaxDist = 2;
    int MinDist = 1;




    void Start()
    {
        nmAgent.speed = MoveSpeed;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            nmAgent.SetDestination(Player.position);


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
    
    /*
    public GameObject Player;
    public NavMeshAgent nmAgent;
    void Update()
    {
            Vector3 mouse = Player.transform;//Get the mouse Position
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);//Cast a ray to get where the mouse is pointing at
            RaycastHit hit;//Stores the position where the ray hit.
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))//If the raycast doesnt hit a wall
            {
                nmAgent.SetDestination(hit.point);
            }
    }
    */
}