using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static string playerName; //make sure to set it to static to carry over
    public Text playerText; //this textbox should be dragged from the new scene 

    public void Start()
    {
        playerText.text = InputName.playerName;


    }

}

