using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


using UnityEditor;

public class HighScore : MonoBehaviour
{
    public Text HighScores;
    public int num_scores = 10;
    public Button resetButton;
    
   
        public void ShowTopScores()
        {
            string path = "Assets/highscores.txt";
            string line;
            string[] fields;
            string[] playerNames = new string[num_scores];
            int[] playerScores = new int[num_scores];
            int scores_read = 0;

            HighScores.text = ""; // clear the scores box

            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream && scores_read < num_scores)
            {
                line = reader.ReadLine();
                fields = line.Split(',');
                HighScores.text += fields[0] + " : " + fields[1] + "\n";
                scores_read += 1;
            }

        }
    public void AddNewScore()
    {

        string path = "Assets/highscores.txt";
        string line;
        string[] fields;
        int scores_written = 0;
        string newName = "don't forget to input";
        string newScore = "999";
        bool newScoreWritten = false;

        string[] writeNames = new string[10];
        string[] writeScores = new string[10];

        newName = InputName.playerName;
        newScore = Points.score.ToString();



        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
            {
                //check if we need to write new higher score first
                if (Convert.ToInt32(newScore) > Convert.ToInt32(fields[1]))
                {
                    writeNames[scores_written] = newName;
                    writeScores[scores_written] = newScore;
                    newScoreWritten = true;
                    scores_written += 1;
                }

            }
            if (scores_written < num_scores) // we have not written enough lines yet
            {
                writeNames[scores_written] = fields[0];
                writeScores[scores_written] = fields[1];
                scores_written += 1;
            }
        }
        reader.Close();
        // now we have parallel arrays with names and scores to write
        StreamWriter writer = new StreamWriter(path);

        for (int x = 0; x < scores_written; x++)
        {
            writer.WriteLine(writeNames[x] + ',' + writeScores[x]);
        }
        writer.Close();

        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("highscores.txt");


    }


    public void ResetHighscores()
    {

        string path = "Assets/highscores.txt";
        string line;
        string[] fields;
        int scores_written = 0;
        string newName = "don't forget to input";
        string newScore = "999";
        bool newScoreWritten = false;

        string[] writeNames = new string[10];
        string[] writeScores = new string[10];

        newName = InputName.playerName;
        newScore = Points.score.ToString();



        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
            {
                //check if we need to write new higher score first
                if (Convert.ToInt32(newScore) > Convert.ToInt32(fields[1]))
                {
                    writeNames[scores_written] = newName;
                    writeScores[scores_written] = newScore;
                    newScoreWritten = true;
                    scores_written += 1;
                }

            }
            if (scores_written < num_scores) // we have not written enough lines yet
            {
                writeNames[scores_written] = fields[0];
                writeScores[scores_written] = fields[1];
                scores_written += 1;
            }
        }
        reader.Close();
        // now we have parallel arrays with names and scores to write
        StreamWriter writer = new StreamWriter(path);

        for (int x = 0; x < scores_written; x++)
        {
            writeNames[x] = "Player Name";
            writeScores[x] = "0";
            writer.WriteLine(writeNames[x] + ',' + writeScores[x]);
        }
        writer.Close();

        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("highscores.txt");

    }

}
