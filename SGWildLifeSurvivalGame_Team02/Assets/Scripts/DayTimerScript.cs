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


    //SkyBoxs
    public Material morningSkyBox;
    public Material afternoonSkyBox;
    public Material eveningSkyBox;
    public Material nightSkyBox;

    //Texts
    public Text dayText; //To show how many days left to Survive
    public Text hourText; // To show how many hours has it been for the day
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DayCounter();
        ChangeSkyBoxOverTime();
        MinsCounter();
        DisplayTimeInHrMins();
        GameOverTimer();
    }

    private void ChangeSkyBoxOverTime()
    {
        if(currentHr >= 1080 )
        {
            RenderSettings.skybox = morningSkyBox;
        }
        else if(currentHr >= 720)
        {
            RenderSettings.skybox = afternoonSkyBox;
        }
        else if(currentHr >= 360)
        {
            RenderSettings.skybox = eveningSkyBox;
        }
        else
        {
            RenderSettings.skybox = nightSkyBox;
        }
    }

    private void MinsCounter()
    {
        if(currentSec < 1440)
        {
            currentSec += Time.deltaTime;
        }
        else if(currentSec >= 1440)
        {
            currentSec = 0;
        }
    }



    private void DisplayTimeInHrMins() 
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

    private void DayCounter()
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
