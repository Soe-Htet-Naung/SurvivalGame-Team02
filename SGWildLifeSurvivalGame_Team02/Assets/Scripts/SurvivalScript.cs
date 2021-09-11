using UnityEngine;
using UnityEngine.UI;

public class SurvivalScript : MonoBehaviour
{
    public float maxHunger = 100;
    public float maxHealth = 100;
    public float currentHunger;
    public float currentHealth;
    public float metabolismRate = 0.1f;
    public float sideEffectRate = 0.5f;
    public float damage = 12;
    public Slider hpSlider;
    public Slider hungerSlider;

    void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        hpSlider.value = currentHealth;
        hungerSlider.value = currentHunger;
    }

    // Update is called once per frame
    void Update()
    {
        Metabolism();

        //UpdateHPbar&HungerBar
        hpSlider.value = currentHealth;
        hungerSlider.value = currentHunger;

        //KeepHPandHunger <= 100
        MaxHealthCheck();
        MaxHungerCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Consume Food
        if(other.tag == "Food")
        {  
            if(currentHunger < maxHunger)
            {
                currentHunger += 30;
                currentHealth += 10;
            }
        }
 
        //Drink Wah-Ar
        if(other.tag == "Water")
        {
            currentHunger += 10;
        }
    }

    private void Metabolism() // This function will make player get hungry
    {
        if (currentHunger >= 0)
        {
            currentHunger -= metabolismRate * Time.deltaTime;
        }
        else
        {
            currentHunger = 0;
            currentHealth -= sideEffectRate * Time.deltaTime;
        }
    }

    private void MaxHealthCheck()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void MaxHungerCheck()
    {
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Weapon")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth -= damage;
    }
}
