using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DayTimerScript : MonoBehaviour
{
    //Days Hours and Secs
    //public float sevenDaysInSecs = 10080f; //168mins in Sec AKA 7 days in Game time | 24mins = 1 day in our game
    //public float aDayInSecs = 1440f; // 24mins = 1440 secs
    public float currentSec = 0; //CurrentSec of the day, which is Minute in this game.
    public float currentHr = 0;//Current Hour of the day
    public float displaySecs = 0f; // Current Secs (Mins) for Display purposes
    public float currentDay = 0f;


    //SkyBoxs and UI
    public Material morningSkyBox;
    public Material afternoonSkyBox;
    public Material eveningSkyBox;
    public Material nightSkyBox;
    public Text dayText; //To show how many days left to Survive
    public Text hourText; // To show how many hours has it been for the day
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // DayCountDown();
        NewDayCounter();
        //DayNightCircle();
        ChangeSkyBoxOverTime();
        MinsCounter();
        DisplayTimeInHrMins();
        GameOverTimer();
    }

    //private void DayCountDown()
    //{
    //    sevenDaysInSecs -= Time.deltaTime;

    //    if (sevenDaysInSecs >= 8640)
    //    {
    //        dayText.text = "Days Left To Survive : 7";
    //    }
    //    else if(sevenDaysInSecs >= 7200)
    //    {
    //        dayText.text = "Days Left To Survive : 6";
    //    }
    //    else if (sevenDaysInSecs >= 5760)
    //    {
    //        dayText.text = "Days Left To Survive : 5";
    //    }
    //    else if (sevenDaysInSecs >= 4320)
    //    {
    //        dayText.text = "Days Left To Survive : 4";
    //    }
    //    else if (sevenDaysInSecs >= 2880)
    //    {
    //        dayText.text = "Days Left To Survive : 3";
    //    }
    //    else if (sevenDaysInSecs >= 1440)
    //    {
    //        dayText.text = "Days Left To Survive : 2";
    //    }
    //    else if (sevenDaysInSecs >= 0)
    //    {
    //        dayText.text = "Days Left To Survive : 1";
    //    }
    //    else
    //    {
    //        dayText.text = "Times Up!";
    //        sevenDaysInSecs = 0;
    //    }

    //}

    //private void DayNightCircle()
    //{
    //    if(aDayInSecs > 0)
    //    {
    //        aDayInSecs -= Time.deltaTime;
    //    }
    //    else if( aDayInSecs <= 0)
    //    {
    //        aDayInSecs = 1440f;
    //    }
    //}

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



    private void DisplayTimeInHrMins() //The display mins won't go over 60
    {
        displaySecs = currentSec % 60;
        if(currentHr <= 23)
        {
            currentHr = Mathf.Floor(currentSec / 60);
        }
        else
        {
            currentHr = 0;
        }
       
        hourText.text = currentHr.ToString() + " Hr : " + displaySecs.ToString("F0") + " Min";
    }

    private void NewDayCounter()
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
