using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    //remember to create empty gameobject and slide script into gameobject
    public static int score = 0; // initialize score to zero
    public Text scoreDisplay; // reference to the UI text component that displays the score

    public void IncreaseScore()
    {
        score++; // increment score by 1
        scoreDisplay.text = score.ToString(); // update score display
    }

    public void DecreaseScore()
    {
        score--; // decrement score by 1
        scoreDisplay.text = score.ToString(); // update score display
    }
}