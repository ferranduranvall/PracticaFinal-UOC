using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombiesToPlayer : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public ZombiesIA scriptZombiesMovement;
    public Transform player;

   

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player3rd")
        {
            scriptZombiesMovement.enabled = false;
            agent.SetDestination(player.position);

        }
    
    }
}
