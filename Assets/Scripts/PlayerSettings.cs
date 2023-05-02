using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;


public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private AudioSource myAudio;
    public int lives;
    public int score;
    public float timer;
    [SerializeField]
    public Text livesText;
    [SerializeField]
    public Text scoreText;
    [SerializeField]
    public Text timerText;

    private void Start()
    {
        lives = LivesButtons.lives;
        score = Points.score;
        timer = DisplayTime.remainingTime;
    }
    public void Awake()
    {
        // 1
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            myAudio.enabled = true;
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                myAudio.enabled = true;
                toggle.isOn = true;
            }
        }
    }
    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            myAudio.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            myAudio.enabled = false;
        }
        PlayerPrefs.Save();
    }
    private Save CreateSaveGameObject()
    {
        Save save = new Save();



        save.lives = lives;
        save.score = score;
        save.timer = timer;
        save.playerName = InputName.playerName;

        return save;
    }
    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        // 3
        lives = 0;
        score = 0;
        timer = 0;

        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + timer;


        Debug.Log("Game Saved");
    }
    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {


            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();


            livesText.text = "Lives: " + save.lives.ToString();
            scoreText.text = "Score: " + save.score.ToString();
            timerText.text = "Time: " + save.timer.ToString();
            lives = save.lives;
            score = save.score;
            timer = save.timer;

            Debug.Log("Game Loaded");


        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }
    
}

