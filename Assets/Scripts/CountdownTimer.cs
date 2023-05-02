using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    public Slider timeSlider;
    public Text timeText;

    public static float countdownTime = 30f;

    void Start()
    {
        timeText.text = timeSlider.value.ToString();
        // Set the countdown time to the selected time value
        countdownTime = timeSlider.value;
        Timer();

    }
    void Update()
    {
        timeText.text = timeSlider.value.ToString();
    }
    public void Timer()
    {
        countdownTime = timeSlider.value;
    }



}