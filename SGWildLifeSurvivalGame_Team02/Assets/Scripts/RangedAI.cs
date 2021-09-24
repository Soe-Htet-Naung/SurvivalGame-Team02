using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : MonoBehaviour{

    public float lookRadius = 20f;
    public float attackRadius = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
    }
}
