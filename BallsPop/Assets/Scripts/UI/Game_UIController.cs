using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_UIController
{
    public UI_BurgerMenu burger;
    public UI_PauseMenu pause;
    public UI_StartGame startGame;
    public UI_CurrentScore currentScore;
    // lifesLeft

    Player player;

    public Game_UIController(SceneLoader sceneLoader, EventsHandler eventsHandler, Player player)
    {
        this.player = player;

        burger = new UI_BurgerMenu(sceneLoader);
        pause = new UI_PauseMenu(eventsHandler);
        startGame = new UI_StartGame(eventsHandler);
        currentScore = new UI_CurrentScore();

        eventsHandler.onGameStart += Update_ScoreText;
        eventsHandler.onScoreUpdate += Update_ScoreText;
        eventsHandler.onGameRestart += Update_ScoreText;

        Update_ScoreText();
    }

    private void Update_ScoreText()
    {
        currentScore.Update_ScoreText(player.currentScore);
    }
}
