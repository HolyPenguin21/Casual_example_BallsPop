using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController
{    
    BallsCreator ballsCreator;
    //ParticleCreator particleCreator;

    private bool spawnEnabled = false;
    public bool SpawnEnabled 
    { 
        set { spawnEnabled = value; } 
    }

    float spawnRate = 0.5f;
    float start_spawnRate = 0.5f;

    public SpawnController(SceneSettings sceneSettings, EventsHandler eventsHandler)
    {
        ballsCreator = new BallsCreator(sceneSettings, eventsHandler);
        //particleCreator = new ParticleCreator();
    }

    public IEnumerator SpawnBall()
    {
        while (spawnEnabled)
        {
            ballsCreator.SpawnBall();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnParticle()
    { 
    }

    public void MakeItHarder()
    {
        if (!spawnEnabled) return;

        spawnRate -= Time.deltaTime / 100f;
    }

    public void Reset_SpawnVars()
    {
        spawnRate = start_spawnRate;
    }

    public void Reset_ActiveElements()
    {
        ballsCreator.Reset_ActiveBalls();
        //particleCreator.Reset_ActiveParticles(); // TO DO
    }
}
