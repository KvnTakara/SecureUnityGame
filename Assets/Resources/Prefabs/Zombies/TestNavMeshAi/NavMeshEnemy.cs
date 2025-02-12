using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Transform point;
    private NavMeshAgent agent;
    private EnemyStatus status;
    
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();
        point = GameObject.FindWithTag("HouseDefender").transform;
        agent.SetDestination(point.position);
    }

   
    void Update()
    {
        if (enemyManager.buildOn.Attack == false && status.tomouDano == false && status.vidaAtual > 0 )
        {
            agent.enabled = true;
            //agent.SetDestination(point.position);
        }
        else 
        {
            agent.enabled = false;
        }
        
    }
}
