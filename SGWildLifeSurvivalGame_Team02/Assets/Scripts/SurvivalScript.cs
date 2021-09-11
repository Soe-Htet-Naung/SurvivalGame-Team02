using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        hpSlider.value = currentHealth;
        hungerSlider.value = currentHunger;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Metabolism();

        //UpdateHPbar&HungerBar
        hpSlider.value = currentHealth;
        hungerSlider.value = currentHunger;

        //KeepHPandHunger <= 100
        HealthCheck();
        HungerCheck();

        //GameOver?
        GameOver();
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

    private void HealthCheck()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

    private void HungerCheck()
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
        if(currentHealth >= 0)
        {
            currentHealth -= damage;
        }
    }

    private void GameOver()
    {
        if (isDead == true)
        {
            SceneManager.LoadScene(3);
        }
    }
}
