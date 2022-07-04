using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_ScorePanel : UI_Elements
{
    GameObject canvasObj;
    Text highScore;

    public UI_Menu_ScorePanel(ScoreManager scoreManager)
    {
        canvasObj = Get_Scene_CanvasObject(canvasObj, "HighScore");
        highScore = Get_Scene_TextField(highScore, "HighScore");

        Check_CurrentScore(scoreManager);
    }

    private void Check_CurrentScore(ScoreManager scoreManager)
    {
        if (scoreManager.Get_HighScore() == 0)
        {
            canvasObj.SetActive(false);
        }
        else
        {
            canvasObj.SetActive(true);
            Update_Score(scoreManager);
        }
    }

    private void Update_Score(ScoreManager scoreManager)
    {
        highScore.text = "Current high score :\n" + scoreManager.Get_HighScore();
    }
}
