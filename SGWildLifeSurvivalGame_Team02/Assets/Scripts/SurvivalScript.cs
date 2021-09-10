using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalScript : MonoBehaviour
{

    public int hunger = 100;
    public int healthPoints = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            hunger += 30;
            healthPoints += 10;
        }
        if(other.tag == "Water")
        {
            hunger += 10;
        }
    }
}
