using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SceneMain : MonoBehaviour
{
    SceneSettings sceneSettings;
    SceneLoader sceneLoader;
    EventsHandler eventsHandler;
    Game_UIController uIController;
    BallsCreator ballsCreator;
    Player player;
    ScoreManager scoreManager;

    bool gameStarted = false;
    float spawnRate = 0.5f;

    private void Awake()
    {
        sceneSettings = new SceneSettings(Camera.main);
        sceneLoader = new SceneLoader();
        eventsHandler = new EventsHandler();

        player = new Player(eventsHandler);

        uIController = new Game_UIController(sceneLoader, eventsHandler, player);
        scoreManager = new ScoreManager(eventsHandler, player, uIController);
        ballsCreator = new BallsCreator(sceneSettings, eventsHandler);

        eventsHandler.onGameStart += StartGame;
        eventsHandler.onGameEnd += EndGame;
    }

    private void StartGame()
    {
        gameStarted = true;
        StartCoroutine(SpawnCicle());
    }

    private IEnumerator SpawnCicle()
    {
        while (gameStarted)
        {
            ballsCreator.SpawnBall();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void EndGame()
    {
        gameStarted = false;
        // save results
        // reset balls prefabs
    }

    private void OnDestroy()
    {
        eventsHandler.RemoveSubscribtions();
    }
}
