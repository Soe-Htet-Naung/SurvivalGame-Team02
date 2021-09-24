using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAI : MonoBehaviour{

    public float lookRadius = 20f;
    public float attackRadius = 10f;

    public NavMeshAgent enemy;

    public Transform Player;


    public Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = Player;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position,transform.position);

        if (distance<= lookRadius)
        {
            enemy.SetDestination(Player.position);

            if (distance<= agent.stoppingDistance)
            {
                //attack the target with projectiles
            }
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
       
        
    }

}
