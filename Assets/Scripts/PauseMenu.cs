using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isPaused = false;
    public int lives = LivesButtons.lives;
    public int score = Points.score;
    public float timer = DisplayTime.remainingTime;
    public Text livesText;
    public Text scoreText;
    public Text timerText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC key pauses AND resumes
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void NewGame()
    {
        lives = 0;
        score = 0;
        timer = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + timer;
        Resume();
    }
    
}
