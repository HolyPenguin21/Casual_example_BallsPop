using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsHandler
{
    public delegate void OnGameStart();
    public event OnGameStart onGameStart;

    public delegate void OnGameEnd();
    public event OnGameEnd onGameEnd;

    public delegate void OnGameRestart();
    public event OnGameRestart onGameRestart;

    public delegate void OnBallDestroyed(int value);
    public event OnBallDestroyed onBallDestroyed;

    public delegate void OnBallMissed();
    public event OnBallMissed onBallMissed;


    public void On_GameStart()
    {
        onGameStart?.Invoke();
    }

    public void On_GameEnd()
    {
        Debug.Log("Event > On_GameStart");
        onGameEnd?.Invoke();
    }

    public void On_GameRestart()
    {
        Debug.Log("Event > On_GameRestart");
        onGameRestart?.Invoke();
    }

    public void On_BallDestroyed(int value)
    {
        onBallDestroyed?.Invoke(value);
    }

    public void On_BallMissed()
    {
        Debug.Log("Event > On_BallMissed");
        onBallMissed?.Invoke();
    }

    public void RemoveSubscribtions()
    {
        onGameStart = null;
        onGameEnd = null;
        onGameRestart = null;
        onBallDestroyed = null;
        onBallMissed = null;
    }
}
