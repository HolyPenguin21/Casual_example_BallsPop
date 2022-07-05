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
    // prefabHolder
    // scoreManager
    // inputManager

    private void Awake()
    {
        sceneSettings = new SceneSettings(Camera.main);
        sceneLoader = new SceneLoader();
        eventsHandler = new EventsHandler();

        player = new Player(eventsHandler);

        uIController = new Game_UIController(sceneLoader, eventsHandler, player);
        ballsCreator = new BallsCreator(sceneSettings);
    }

    private void OnDestroy()
    {
        eventsHandler.RemoveSubscribtions();
    }
}
