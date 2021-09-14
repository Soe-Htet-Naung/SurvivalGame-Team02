using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public float startSpwanTimer = 2;
    public float timeBeforeEachSpawn = 15;
    public GameObject fruitPrefab;
    public Transform[]  spawnPoints;
    public int currentSpawnLocation;

    
    void Start()
    {
        InvokeRepeating("SpawnFruit", startSpwanTimer, timeBeforeEachSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnFruit()
    {
        currentSpawnLocation = Random.Range(0, spawnPoints.Length); //Randomize the location to spawn from given locations

        GameObject orangeFruit =  Instantiate(fruitPrefab, spawnPoints[currentSpawnLocation].position, spawnPoints[currentSpawnLocation].rotation);
    }

}
