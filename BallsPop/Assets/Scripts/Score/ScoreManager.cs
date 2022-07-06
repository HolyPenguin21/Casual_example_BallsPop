using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    Player player;
    Game_UIController uIController;

    public ScoreManager(EventsHandler eventsHandler, Player player, Game_UIController uIController)
    {
        this.player = player;
        this.uIController = uIController;

        eventsHandler.onBallDestroyed += Add_CurrentScore;
    }

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
        player.Add_Score(value);
        uIController.Update_ScoreText(player.currentScore);
    }
}
