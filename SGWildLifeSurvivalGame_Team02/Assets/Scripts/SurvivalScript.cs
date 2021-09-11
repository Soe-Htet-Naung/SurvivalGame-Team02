using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalScript : MonoBehaviour
{

    public float hunger = 100;
    public float healthPoints = 100;
    public float metabolismRate = 0.1f;
    public float sideEffectRate = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Metabolism();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Consume Food
        if(other.tag == "Food")
        {
            hunger += 30;
            healthPoints += 10;
        }
        //Drink Wah-Ar
        if(other.tag == "Water")
        {
            hunger += 10;
        }
    }

    private void Metabolism() // This function will make player get hungry
    {
        if (hunger >= 0)
        {
            hunger -= metabolismRate * Time.deltaTime;
        }
        else
        {
            hunger = 0;
            healthPoints -= sideEffectRate * Time.deltaTime;
        }
    }
}
