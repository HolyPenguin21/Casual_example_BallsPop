using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCreator
{
    ViewportBounds viewportBounds;

    GameObject[] ballsPool; // Review - use class not object
    Transform pollHolder;
    GameObject ballPrefab;

    public BallsCreator(SceneSettings sceneSettings, EventsHandler eventsHandler)
    {
        viewportBounds = sceneSettings.Get_ViewportBounds();
        ballPrefab = Resources.Load("Objects/BallPrefab", typeof(GameObject)) as GameObject;

        Setup_BallsPool(15, eventsHandler);
    }

    private void Setup_BallsPool(int count, EventsHandler eventsHandler)
    {
        ballsPool = new GameObject[count];

        pollHolder = new GameObject("PoolHolder").transform;

        for (int i = 0; i < ballsPool.Length; i++)
        {
            GameObject ball_obj = MonoBehaviour.Instantiate(ballPrefab, pollHolder);
            ball_obj.SetActive(false);

            Ball ball_sc = ball_obj.GetComponent<Ball>();
            ball_sc.eventsHandler = eventsHandler;

            ballsPool[i] = ball_obj;
        }
    }    

    public void SpawnBall()
    {
        GameObject ballToSpawn = Get_FreeBall();
        ballToSpawn.transform.position = Set_SpawnPosition();
        ballToSpawn.transform.rotation = Set_RandomRotation();

        ballToSpawn.SetActive(true);
    }

    private GameObject Get_FreeBall()
    {
        foreach (GameObject ball in ballsPool)
        {
            if (!ball.activeInHierarchy)
                return ball;
        }

        Debug.LogError("Missing ball prefabs, add more into pool");
        return null;
    }

    private Vector3 Set_SpawnPosition()
    {
        float x_Scale = 1; // Review - give reference

        float x_Pos = Random.Range(-viewportBounds.x_bounds[1] + x_Scale, viewportBounds.x_bounds[1] - x_Scale);
        float y_Pos = viewportBounds.y_bounds[1];

        Vector3 pos = new Vector3(x_Pos, y_Pos, 0);

        return pos;
    }

    private Quaternion Set_RandomRotation()
    {
        return Quaternion.identity;
    }
}
