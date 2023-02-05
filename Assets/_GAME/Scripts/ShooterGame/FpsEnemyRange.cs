using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FpsEnemyRange : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            enemyTransform.DOLocalMove(coll.gameObject.transform.localPosition, 5);
        }
    }
}