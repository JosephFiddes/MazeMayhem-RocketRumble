using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Image bgnd1;
    public Image bgnd2;

    public Text scoreText;
    public Text highScoreText;
    public Animator highScoreAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get background colors
        bgnd1.color = Globals.color1;
        bgnd2.color = Globals.color2;

        // Set alpha to 1
        bgnd1.color = new Color(bgnd1.color.r, bgnd1.color.g, bgnd1.color.b, 1);
        bgnd2.color = new Color(bgnd2.color.r, bgnd2.color.g, bgnd2.color.b, 1);

        // Get score
        long score = Globals.final_score;
        long high_score = LoadOldHighScore(); // Load value from something later.

        scoreText.text = "Score: " + score.ToString();

        if (score > high_score)
        {
            // NEW HIGH SCORE!!!
            highScoreText.text = "New High-Score!";
            highScoreAnimation.Play("New Highscore Flash");

            SaveNewHighScore(score);
        } else
        {
            highScoreText.text = "High-Score: " + high_score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Play again.
        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        // Quit.
        if (Input.GetKey("q") || Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void SaveNewHighScore(long highScore)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/highscore.dat");
        SaveData data = new SaveData();
        data.highScore = highScore;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    long LoadOldHighScore()
    {
        if (File.Exists(Application.persistentDataPath
                   + "/highscore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/highscore.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            return data.highScore;
        }
        else
            return -1;
    }
}

[Serializable]
class SaveData
{
    public long highScore;
}
