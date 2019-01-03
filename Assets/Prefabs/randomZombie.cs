using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomZombie : MonoBehaviour
{

    public NavMeshAgent nmAgent;
    public GameObject[] SpawnObjects;
    float MoveSpeed = 2.0f;
    int MaxDist = 2;
    int MinDist = 1;
    int RandomOption;
    


    void Start()
    {
        nmAgent.speed = MoveSpeed;
        RandomOption = Random.Range(0, SpawnObjects.Length);
    }

    void Update()
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