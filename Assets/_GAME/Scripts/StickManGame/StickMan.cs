using System;
using System.Collections;
using System.Collections.Generic;
using _GAME.Scripts.Events;
using Ambrosia.EventBus;
using Unity.VisualScripting;
using UnityEngine;

public class StickMan : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator anim;

    [SerializeField] private float playerSpeed;
    [SerializeField] private GameObject dieText;
    [SerializeField] private GameObject winText;

    void Update()
    {
        #region Movement

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * horizontal;
        characterController.Move(move * playerSpeed * Time.deltaTime);

        #endregion


        #region Attack

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isAttack");
        }

        #endregion

        #region Block

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("isBlock");
        }

        #endregion
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Destroy(coll.gameObject);
            playerSpeed = 0;
            dieText.SetActive(true);
            StartCoroutine(WaitAndDie(1));
            //UI çıkıcak buttona basınca oyun tekrar başlıcak
        }

        if (coll.gameObject.CompareTag("Finish"))
        {
            winText.SetActive(true);
            StartCoroutine(WaitAndWin(1));
        }
    }

    IEnumerator WaitAndDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EventBus<GameLoseEvent>.Emit(this, new GameLoseEvent());
    }

    IEnumerator WaitAndWin(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EventBus<StickManGameWinEvent>.Emit(this, new StickManGameWinEvent());
    }
}