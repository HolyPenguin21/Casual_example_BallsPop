using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager
{
    public int Get_HighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public void Set_HighScore(int score)
    {
        if (score > Get_HighScore())
            PlayerPrefs.GetInt("highScore", score);
    }

    public void Add_CurrentScore(int value)
    { 

    }
}
