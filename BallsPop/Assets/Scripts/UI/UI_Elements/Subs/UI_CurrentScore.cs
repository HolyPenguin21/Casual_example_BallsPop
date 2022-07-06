using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CurrentScore : UI_Elements
{
    GameObject canvas_obj;
    Text score_text;

    Player player;

    public UI_CurrentScore(Player player)
    {
        this.player = player;

        canvas_obj = Get_Scene_CanvasObject(canvas_obj, "ScoreCanvas");
        score_text = Get_Scene_TextField(score_text, "ScoreText");
    }

    public void Update_ScoreText()
    {
        score_text.text = "Score : " + player.currentScore;
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
