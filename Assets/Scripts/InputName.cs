using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public InputField inputField;
    public Text playerText;
    public static string playerName;
    //drag according objects in the intro
    public void ReadStringInput()
    {

        playerName = inputField.text.ToString();
        playerText.text = playerName.ToString();


    }

}
