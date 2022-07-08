using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public int scorePointsReward = 1;

    Transform tr;
    Transform mesh_tr;

    ContinuousRotation continuousRotation;
    Movement movement;

    [HideInInspector] public EventsHandler eventsHandler; // Review

    private void Awake()
    {
        tr = transform;
        mesh_tr = tr.Find("Mesh");

        continuousRotation = new ContinuousRotation();
        movement = new Movement();
    }

    private void OnEnable()
    {
        continuousRotation.StartRotation(mesh_tr);
        movement.StartMove(tr);
    }

    private void OnDisable()
    {
        DOTween.Kill(tr);
        DOTween.Kill(mesh_tr);
    }

    private void OnMouseDown()
    {
        if (Time.timeScale == 0) return;

        gameObject.SetActive(false);
        eventsHandler.On_BallDestroyed(scorePointsReward); // Review
    }

    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        eventsHandler.On_BallMissed(scorePointsReward); // Review
    }
}
