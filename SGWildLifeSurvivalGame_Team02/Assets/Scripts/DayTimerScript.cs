using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimerScript : MonoBehaviour
{
    public float sevenDaysInSecs = 10080f; //168mins in Sec AKA 7 days in Game time | 24mins = 1 day in our game |

    public Text dayText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayCountDown();
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
}
