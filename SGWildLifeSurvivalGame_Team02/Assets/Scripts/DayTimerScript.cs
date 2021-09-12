using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimerScript : MonoBehaviour
{
    //Days Hours and Secs
    public float sevenDaysInSecs = 10080f; //168mins in Sec AKA 7 days in Game time | 24mins = 1 day in our game |
    public int hoursInAday = 24; // 24 mins IRL | 1 min = 1 Hr
    public float aDayInSecs = 1440f; // 24mins = 1440 secs

    //SkyBoxs and UI
    public Material morningSkyBox;
    public Material afternoonSkyBox;
    public Material eveningSkyBox;
    public Material nightSkyBox;
    public Text dayText; //To show how many days left to Survive
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayCountDown();
        DayNightCircle();
        ChangeSkyBoxOverTime();
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
}
