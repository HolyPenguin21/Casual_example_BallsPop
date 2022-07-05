using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ContinuousRotation : MonoBehaviour
{
    Vector3 endRotation = new Vector3(0, 360, 0);

    void Start()
    {
        transform.DORotate(endRotation, 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
