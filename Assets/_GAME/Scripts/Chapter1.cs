using System;
using System.Collections;
using System.Collections.Generic;
using Ambrosia.EventBus;
using DG.Tweening;
using UnityEngine;

public class Chapter1 : MonoBehaviour
{
    [SerializeField] private GameObject chapter;
    [SerializeField] private GameObject chapterText;
    
    [SerializeField] private GameObject TextGame;

    private void OnEnable()
    {
        chapter.SetActive(true);
        TextGame.SetActive(false);
        StartCoroutine(WaitAndChapter(2.5f));
        StartCoroutine(WaitAndTextGame(2.5f));
    }
    
    IEnumerator WaitAndTextGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chapter.SetActive(false);
        TextGame.SetActive(true);
    }
    
    IEnumerator WaitAndChapter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chapterText.transform.DOMove(new Vector3(0, 3000, 0), 1);
    }
}