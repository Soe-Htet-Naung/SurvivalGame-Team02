using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAI : MonoBehaviour{

    public float lookRadius = 20f;
    public float attackRadius = 10f;
    
    public float speed = 1;
    public GameObject ProjectilePrefab;
    public Transform firePoint;

    public NavMeshAgent enemy;

    public Transform Player;

    public bool playerInSightRange;
    public bool playerInAttackRange;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    
    bool allreadyAttacked;
    private Transform target;
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
        // Check for player in sight range 

        float distance = Vector3.Distance(target.position,transform.position);


        if (distance<= lookRadius)
        {
            enemy.SetDestination(Player.position);

            if (distance<= agent.stoppingDistance || fireCountdown <=0f)
            {
                //attack the target with projectiles
                Shoot();
                fireCountdown = 1f/fireRate;

            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
       
        
    }
    void Shoot()
    {
        Debug.Log("SHOOT!");
        GameObject spitBall = (GameObject)Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = spitBall.GetComponent<Projectile>();

        if (projectile != null)
            projectile.Chase(target);
    }

}
