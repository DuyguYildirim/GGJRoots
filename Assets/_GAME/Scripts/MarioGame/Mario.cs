using System;
using UnityEngine;

public class Mario : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    private Vector3 velocity;
    [SerializeField] private Animator anim;
    [SerializeField] private float playerSpeed;

    private bool isGrounded;

    [SerializeField] private Transform ground;

    [SerializeField] private float distance = 0.3f;

    [SerializeField] private float jumpHeight;

    [SerializeField] private float gravity;

    [SerializeField] private LayerMask mask;
    //[SerializeField] private GameObject dieText;

    private void Update()
    {
        #region Movement

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * horizontal;
        characterController.Move(move * playerSpeed * Time.deltaTime);

        #endregion

        #region Jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        #endregion

        #region Gravity

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        #endregion
    }
}