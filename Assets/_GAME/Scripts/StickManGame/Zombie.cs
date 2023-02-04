using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void Start()
    {
        Sequence sq = DOTween.Sequence();
        sq.Join(
            transform.DOLocalMove(new Vector3(transform.position.x - 1, 0, 0),
                5));
        sq.Append(transform.DOLocalRotate(new Vector3(0, -90, 0), 1));
        sq.Append(transform.DOLocalMove(
            new Vector3(transform.position.x + 1, 0, 0),
            5));
        sq.Append(transform.DOLocalRotate(new Vector3(0, 90, 0), 1));
        sq.Append(transform.DOLocalMove(
            new Vector3(transform.position.x + -1, 0, 0),
            5));
        sq.SetLoops(-1, LoopType.Restart);
    }
}