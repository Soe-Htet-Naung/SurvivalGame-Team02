using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimerScript : MonoBehaviour
{
    //Days Hours and Secs
    public float sevenDaysInSecs = 10080f; //168mins in Sec AKA 7 days in Game time | 24mins = 1 day in our game
    public float aDayInSecs = 1440f; // 24mins = 1440 secs
    public float currentSec = 0; //CurrentSec of the day, which is Minute in this game.
    public float currentHr = 0;//Current Hour of the day

    //ForInvokeTimer
    public float x = 0; // Secs before First Invoke
    public float y = 60; // Secs between each Interval

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
        DayCountDown();
        DayNightCircle();
        ChangeSkyBoxOverTime();
        HourCounter();
    }

    private void DayCountDown()
    {
        sevenDaysInSecs -= Time.deltaTime;

        if (sevenDaysInSecs >= 8640)
        {
            dayText.text = "Days Left To Survive : 7";
        }
        else if(sevenDaysInSecs >= 7200)
        {
            dayText.text = "Days Left To Survive : 6";
        }
        else if (sevenDaysInSecs >= 5760)
        {
            dayText.text = "Days Left To Survive : 5";
        }
        else if (sevenDaysInSecs >= 4320)
        {
            dayText.text = "Days Left To Survive : 4";
        }
        else if (sevenDaysInSecs >= 2880)
        {
            dayText.text = "Days Left To Survive : 3";
        }
        else if (sevenDaysInSecs >= 1440)
        {
            dayText.text = "Days Left To Survive : 2";
        }
        else if (sevenDaysInSecs >= 0)
        {
            dayText.text = "Days Left To Survive : 1";
        }
        else
        {
            dayText.text = "Times Up!";
            sevenDaysInSecs = 0;
        }

    }

    private void DayNightCircle()
    {
        if(aDayInSecs > 0)
        {
            aDayInSecs -= Time.deltaTime;
        }
        else if( aDayInSecs <= 0)
        {
            aDayInSecs = 1440f;
        }
    }

    private void ChangeSkyBoxOverTime()
    {
        if(aDayInSecs >= 1080 )
        {
            RenderSettings.skybox = morningSkyBox;
        }
        else if(aDayInSecs >= 720)
        {
            RenderSettings.skybox = afternoonSkyBox;
        }
        else if(aDayInSecs >= 360)
        {
            RenderSettings.skybox = eveningSkyBox;
        }
        else
        {
            RenderSettings.skybox = nightSkyBox;
        }
    }

    private void HourCounter()
    {
        if(currentSec < 1440)
        {
            currentSec += Time.deltaTime;
            StartCoroutine("ConvertToHours");
            hourText.text = currentHr.ToString() + " Hr : " + currentSec.ToString("F0") + " Mins";

        }
        else if(currentSec >= 1440)
        {
            currentSec = 0;
        }
    }

    IEnumerator ConvertToHours()
    {
        if(currentSec >= 60)
        {
            currentHr += 1;
        }
        
        yield return currentHr;
    }

}
