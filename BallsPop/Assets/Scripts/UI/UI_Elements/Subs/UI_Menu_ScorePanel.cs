using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_ScorePanel : UI_Elements
{
    GameObject canvas_obj;
    Text highScore;

    public UI_Menu_ScorePanel(ScoreManager scoreManager)
    {
        canvas_obj = Get_Scene_CanvasObject(canvas_obj, "HighScore");
        highScore = Get_Scene_TextField(highScore, "HighScore");

        Check_CurrentScore(scoreManager);
    }

    private void Check_CurrentScore(ScoreManager scoreManager)
    {
        if (scoreManager.Get_HighScore() == 0)
        {
            Hide();
        }
        else
        {
            Show();
            Update_Score(scoreManager);
        }
    }

    private void Update_Score(ScoreManager scoreManager)
    {
        highScore.text = "Current high score :\n" + scoreManager.Get_HighScore();
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
