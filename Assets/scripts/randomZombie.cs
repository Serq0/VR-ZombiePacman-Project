using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class randomZombie : MonoBehaviour
{

    public NavMeshAgent nmAgent;
    public GameObject[] SpawnObjects;
    public Transform Player;
    float MoveSpeed = 2.0f/2;
    float MaxDist = 2.5f;
    float killPlayer = 1.2f;
    int MinDist = 1;
    int StartChasingDistance = 6;
    int RandomOption;
    public bool chasePlayer;

    private Animator animator;

    void Start()
    {
        nmAgent.speed = MoveSpeed;
        RandomOption = Random.Range(0, SpawnObjects.Length);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= StartChasingDistance)
        {
            chasePlayer = true;
        }
        else
        {
            chasePlayer = false;
        }

        if(Vector3.Distance(transform.position, Player.position) <= killPlayer)
        {
            SceneManager.LoadScene("Pacman");
        }

        if (chasePlayer)
        {
            transform.LookAt(Player);
            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {
                //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                nmAgent.SetDestination(Player.position);

                if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                {
                    animator.SetTrigger("attack");
                }

            }
        }

        if (!chasePlayer)
        {
            transform.LookAt(SpawnObjects[RandomOption].transform);

            if (Vector3.Distance(transform.position, SpawnObjects[RandomOption].transform.position) >= MinDist)
            {

                //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                nmAgent.SetDestination(SpawnObjects[RandomOption].transform.position);


                if (Vector3.Distance(transform.position, SpawnObjects[RandomOption].transform.position) <= MaxDist)
                {
                    RandomOption = Random.Range(0, SpawnObjects.Length);
                }

            }

        }

    }

}