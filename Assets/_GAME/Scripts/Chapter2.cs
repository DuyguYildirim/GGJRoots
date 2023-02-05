using System;
using System.Collections;
using System.Collections.Generic;
using Ambrosia.EventBus;
using DG.Tweening;
using UnityEngine;

public class Chapter2 : MonoBehaviour
{
    [SerializeField] private GameObject chapter;
    [SerializeField] private GameObject chapterText;

    private void OnEnable()
    {
        chapter.SetActive(true);
        StartCoroutine(WaitAndChapter(1.5f));
        StartCoroutine(WaitAndTextGame(2.5f));
    }
    
    IEnumerator WaitAndTextGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chapter.SetActive(false);
    }
    
    IEnumerator WaitAndChapter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        chapterText.transform.DOLocalMove(new Vector3(0, 3000, 0), 1);
    }
}