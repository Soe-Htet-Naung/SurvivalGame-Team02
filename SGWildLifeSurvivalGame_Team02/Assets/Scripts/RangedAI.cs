using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAI : MonoBehaviour{

    public float lookRadius = 20f;
    public float attackRadius = 10f;

    private float timeBtwShots;
    
    public float startTimeBtwShots;

    public GameObject Projectile;

    public NavMeshAgent enemy;

    public Transform Player;

    public bool playerInSightRange;
    public bool playerInAttackRange;

    
    bool allreadyAttacked;
    public Transform target;
    NavMeshAgent agent;

   
    // Start is called before the first frame update
    void Start()
    {
        target = Player;
        agent = GetComponent<NavMeshAgent>();
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player in sight range 

        float distance = Vector3.Distance(target.position,transform.position);

        if (distance<= lookRadius)
        {
            enemy.SetDestination(Player.position);

            if (distance<= agent.stoppingDistance || timeBtwShots <= 0)
            {
                //attack the target with projectiles
                Instantiate(Projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
       
        
    }

}
