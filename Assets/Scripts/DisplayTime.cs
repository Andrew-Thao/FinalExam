using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayTime : MonoBehaviour
{

    public Text countdownText; // Text box to display countdown

    private float startTime;

    public static float remainingTime;

    void Start()
    {


        // Set the countdown start time
        startTime = CountdownTimer.countdownTime;
        countdownText.text = startTime.ToString();
        remainingTime = startTime;
    }

    void Update()
    {



        // Calculate the remaining time
        remainingTime -= Time.deltaTime;

        // If the remaining time is greater than zero, update the countdown text
        if (remainingTime > 0)
        {
            countdownText.text = "Countdown: " + remainingTime.ToString("F2") + " seconds";
        }
        // If the remaining time is zero or less, stop the countdown and show "Time's Up" in the text box
        else
        {
            countdownText.text = "Time's Up!";

        }

    }
}