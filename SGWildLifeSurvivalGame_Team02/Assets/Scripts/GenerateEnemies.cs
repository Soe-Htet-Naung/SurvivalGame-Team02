using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public float startSpwanTimer = 5;
    public float timeBeforeEachSpawn = 30;
    public GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", startSpwanTimer, timeBeforeEachSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemies()
    {

        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

}