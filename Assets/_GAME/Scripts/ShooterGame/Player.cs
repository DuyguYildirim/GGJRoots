using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float playerSpeed;

    [SerializeField] private float rotationsPerMinute;

    void Update()
    {
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
    }
}