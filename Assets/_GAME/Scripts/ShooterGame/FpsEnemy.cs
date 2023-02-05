using System;
using System.Collections;
using System.Collections.Generic;
using Ambrosia.EventBus;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class FpsEnemy : MonoBehaviour
{
    [SerializeField] private GameObject skinnedMesh;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        EventBus<isShootEnemyEvent>.AddListener(OnisShootEnemy);
    }

    private void OnDisable()
    {
        EventBus<isShootEnemyEvent>.RemoveListener(OnisShootEnemy);
    }

    private void OnisShootEnemy(object sender, isShootEnemyEvent e)
    {
        if (e._transformGameObject == gameObject)
        {
            skinnedMesh.SetActive(false);
            _particleSystem.Play();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        
    }
}