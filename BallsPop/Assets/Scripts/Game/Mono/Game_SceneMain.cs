using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SceneMain : MonoBehaviour
{
    SceneSettings sceneSettings;
    SceneLoader sceneLoader;
    EventsHandler eventsHandler;
    Game_UIController uIController;
    SpawnController spawnController;    
    Player player;
    ScoreManager scoreManager;  

    private void Awake()
    {
        sceneSettings = new SceneSettings(Camera.main);
        sceneLoader = new SceneLoader();
        eventsHandler = new EventsHandler();

        player = new Player(eventsHandler);

        uIController = new Game_UIController(sceneLoader, eventsHandler, player);
        spawnController = new SpawnController(sceneSettings, eventsHandler);
        scoreManager = new ScoreManager(eventsHandler, player);

        eventsHandler.onGameStart += StartGame;
        eventsHandler.onGameEnd += EndGame;
        eventsHandler.onGameRestart += EndGame;
        eventsHandler.onGameRestart += StartGame;
    }

    private void Update()
    {
        spawnController.MakeItHarder();
    }

    private void StartGame()
    {
        spawnController.spawnEnabled = true;
        StartCoroutine(spawnController.SpawnBall());
    }

    private void EndGame()
    {
        StopAllCoroutines();

        spawnController.spawnEnabled = false;
        spawnController.Reset_ActiveBalls();
        spawnController.Reset_SpawnVars();
    }    

    private void OnDestroy()
    {
        StopAllCoroutines();

        eventsHandler.RemoveSubscribtions();
    }
}
