using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class ClockExample : MonoBehaviour
{
    private TMP_Text textClock;
    public float timeRemaining = 90;
    public bool timerIsRunning = false;
    private void Start()
    {
        textClock = GetComponent<TMP_Text>();
        timerIsRunning = true;
    }

    
    void Update (){

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textClock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}
