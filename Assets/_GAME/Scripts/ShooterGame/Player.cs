using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float playerSpeed;

    [SerializeField] private float rotationsPerMinute;

    [SerializeField] private Transform gunTransform;

    void Update()
    {
        #region Movement

        //ileri-geri
        float vertical = Input.GetAxis("Vertical");

        //dönme
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            transform.Rotate(0, 6f * rotationsPerMinute * Time.deltaTime, 0);
        }

        if (horizontal > 0)
        {
            transform.Rotate(0, 6f * -rotationsPerMinute * Time.deltaTime, 0);
        }

        Vector3 move = transform.forward * vertical;
        characterController.Move(move * playerSpeed * Time.deltaTime);

        #endregion

        #region Shoot

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(gunTransform.position, gunTransform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Did Hit");
                    Destroy(hit.transform.gameObject);
                }
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
            }
        }

        #endregion
    }
}