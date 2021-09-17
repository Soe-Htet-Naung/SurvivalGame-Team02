using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyMovementManager : MonoBehaviour
        {
            EnemyController enemyController;

            LayerMask detectionLayer;

            private void Awake()
            {
                enemyController = GetComponent<EnemyController>();
            }
            public void HandleDetection()
                {
                    Collider[] colliders = Physics.OverlapSphere(transform.position, enemyController.detectionRadius, detectionLayer);

                    for (int i = 0; i < colliders.Length; i++)
                    {

                    }

                }
        }   

}
