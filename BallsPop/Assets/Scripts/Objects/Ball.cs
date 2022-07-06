using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public int scorePointsReward = 1;

    Transform tr;

    ContinuousRotation continuousRotation;
    Movement movement;

    [HideInInspector] public EventsHandler eventsHandler;

    private void Awake()
    {
        tr = transform;

        continuousRotation = new ContinuousRotation();
        movement = new Movement();
    }

    private void OnEnable()
    {
        continuousRotation.StartRotation(tr);
        movement.StartMove(tr);
    }

    private void OnDisable()
    {
        DOTween.Kill(tr);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        eventsHandler.On_BallDestroyed(scorePointsReward);
    }
}
