using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_UIController
{
    public UI_BurgerMenu burger;
    public UI_StartGame startGame;
    public UI_CurrentScore currentScore;
    // lifesLeft
    // pauseMenu/Restart

    public Game_UIController(SceneLoader sceneLoader, EventsHandler eventsHandler, Player player)
    {
        burger = new UI_BurgerMenu(sceneLoader);
        startGame = new UI_StartGame(eventsHandler);
        currentScore = new UI_CurrentScore(eventsHandler, player);

        eventsHandler.onBallDestroyed += Update_ScoreText;
    }

    public void Update_ScoreText()
    {
        currentScore.Update_ScoreText();
    }
}
