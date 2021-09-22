using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DayTimerScript : MonoBehaviour
{
    //Days Hours Mins and Secs
    public float currentSec = 0; //CurrentSec of the day, which is Minute in this game.
    public float currentHr = 0;//Current Hour of the day
    public float currentMins = 0f; // Current Mins for Display purposes
    public float currentDay = 0f;

    //bools for day/night
    [SerializeField] bool isDawn = false;


    //SkyBoxs
    public Material morningSkyBox;
    public Material afternoonSkyBox;
    public Material eveningSkyBox;
    public Material nightSkyBox;

    //Particle Systems
    ParticleSystem fogParSys;

    //Texts
    public Text dayText; //To show how many days left to Survive
    public Text hourText; // To show how many hours has it been for the day
    void Start()
    {
        fogParSys = GetComponent<ParticleSystem>();
        fogParSys.enableEmission = true;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayDayCount();
        DayNightCircle();
        SecsCounter();
        DisplayTime();
        GameOverTimer();
        WeatherParticleSystem();


    }

    private void DayNightCircle() //Change  skybox every 6hrs (6Mins IRL)
    {
        if(currentHr <= 6 )
        {
            RenderSettings.skybox = morningSkyBox;
            
        }
        else if(currentHr <= 12)
        {
            RenderSettings.skybox = afternoonSkyBox;
            
        }
        else if(currentHr <= 18)
        {
            RenderSettings.skybox = eveningSkyBox;
            
        }
        else
        {
            RenderSettings.skybox = nightSkyBox;
            
        }
    }
    
    private void WeatherParticleSystem() // Fogs at every morning
    {
        if (currentHr >= 0 && currentHr < 6)
        {
            isDawn = true;
            if (fogParSys.isPlaying == false)
            {
                fogParSys.Play();
                fogParSys.enableEmission = true;
            }


        }
        else if(currentHr > 6)
        {
            isDawn = false;
            if(fogParSys.isPlaying == true)
            {
                fogParSys.Stop();
                fogParSys.enableEmission = false;
            }

        }
    }
    private void SecsCounter()
    {
        if(currentSec < 1440) //less than total sec/mins of a day
        {
            currentSec += Time.deltaTime;
        }
        else if(currentSec >= 1440) //Reset the day
        {
            currentSec = 0;
        }
    }



    private void DisplayTime() 
    {
        currentMins = currentSec % 60;
        if(currentHr <= 23)
        {
            currentHr = Mathf.Floor(currentSec / 60);
        }
        else
        {
            currentHr = 0;
        }
       
        hourText.text = currentHr.ToString() + " Hr : " + currentMins.ToString("F0") + " Min";
    }

    private void DisplayDayCount()
    {
        currentDay += Mathf.Floor(currentHr/24);
        if (currentDay <= 1)
        {
            dayText.text = "Total Surived Days : " + currentDay.ToString() + " Day";
        }
        else
        {
            dayText.text = "Total Surived Days : " + currentDay.ToString() + " Days";
        }
        
    }

    private void GameOverTimer()
    {
        if (currentDay >= 7)
        {
            dayText.text = "Total Surived Days : " + currentDay.ToString() + " Days! Game OVER";
            SceneManager.LoadScene(3);
        }
    }

}
