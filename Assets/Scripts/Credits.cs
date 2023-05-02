using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Credits : MonoBehaviour
{
    public Button Exit;
    public HighScore highscore;
   
    void Start()
    {
        highscore.ShowTopScores();
        // Add a listener to the button click event
        
    }
    
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
}
