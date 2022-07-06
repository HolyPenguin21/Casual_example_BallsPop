using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_ScorePanel : UI_Elements
{
    GameObject canvas_obj;
    Text highScore;

    public UI_Menu_ScorePanel()
    {
        canvas_obj = Get_Scene_CanvasObject(canvas_obj, "HighScore");
        highScore = Get_Scene_TextField(highScore, "HighScore");

        Check_CurrentScore();
    }

    private void Check_CurrentScore()
    {
        int currentHighScore = PlayerPrefs.GetInt("highScore");

        if (currentHighScore == 0)
        {
            Hide();
        }
        else
        {
            Show();
            Update_Score(currentHighScore);
        }
    }

    private void Update_Score(int value)
    {
        highScore.text = "Current high score :\n" + value;
    }

    public override void Hide()
    {
        canvas_obj.SetActive(false);
    }

    public override void Show()
    {
        canvas_obj.SetActive(true);
    }
}
