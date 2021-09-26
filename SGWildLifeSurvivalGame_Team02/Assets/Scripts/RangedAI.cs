using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAI : MonoBehaviour{

    public float lookRadius = 20f;
    public float attackRadius = 10f;
    
    public float speed = 1;
    public Rigidbody ProjectilePrefab;
    public Transform firePoint;

    public NavMeshAgent enemy;

    public Transform Player;

    public bool playerInSightRange;
    public bool playerInAttackRange;

    public float fireRate = 1f;
    public float iniFireCD = 10f;
    private float currentFireCountDown = 0;
    public int damageToPlayer = 20;
    public float fireSpeed = 3f;

    
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
        if (currentFireCountDown > 0)
        {
            currentFireCountDown += Time.deltaTime;
        }

        if (distance<= lookRadius)
        {
            enemy.SetDestination(Player.position);

            if (distance<= agent.stoppingDistance || currentFireCountDown >= iniFireCD)
            {
                //attack the target with projectiles
                Shoot();
                currentFireCountDown = 0;

            }
            
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
       
        
    }
    void Shoot()
    {

            Rigidbody spitBall = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
            spitBall.GetComponent<Projectile>().SetAttributes(damageToPlayer);
            spitBall.AddForce(spitBall.transform.forward * fireSpeed);
        

    }

}
