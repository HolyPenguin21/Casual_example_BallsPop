using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int curHealth;
    public int maxHealth = 3;
    public int currentScore;

    EventsHandler eventsHandler;

    public Player(EventsHandler eventsHandler)
    {
        this.eventsHandler = eventsHandler;

        this.eventsHandler.onBallMissed += RemoveHealth;

        this.eventsHandler.onGameRestart += Set_MaxHealth;
        this.eventsHandler.onGameRestart += ResetScore;

        Set_MaxHealth();
    }

    private void RemoveHealth()
    {
        curHealth--;

        if (curHealth <= 0)
            eventsHandler.On_GameEnd();
    }

    private void Set_MaxHealth()
    {
        curHealth = maxHealth;
    }

    private void ResetScore()
    {
        currentScore = 0;
    }
}
