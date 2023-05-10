using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class ClockExample : MonoBehaviour
{
    public GameMangerController gameMangerController;
    private TMP_Text textClock;
    public float timeRemaining = 5;
    public bool timerIsRunning = false;
    private bool isDead;
    
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
                timeRemaining = 0;
                timerIsRunning = false;
                if (!isDead)
                {
                    isDead = true;
                    gameMangerController.gameOver();
                }
                
                
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
