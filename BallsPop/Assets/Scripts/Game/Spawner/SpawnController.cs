using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController
{    
    BallsCreator ballsCreator;

    public bool spawnEnabled = false;
    float spawnRate = 0.5f;
    float start_spawnRate = 0.5f;

    public SpawnController(SceneSettings sceneSettings, EventsHandler eventsHandler)
    {
        ballsCreator = new BallsCreator(sceneSettings, eventsHandler);
    }

    public IEnumerator SpawnBall()
    {
        while (spawnEnabled)
        {
            ballsCreator.SpawnBall();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void MakeItHarder()
    {
        spawnRate -= Time.deltaTime / 100f;
    }

    public void Reset_SpawnVars()
    {
        spawnRate = start_spawnRate;
    }

    public void Reset_ActiveBalls()
    {
        ballsCreator.Reset_ActiveBalls();
    }
}
