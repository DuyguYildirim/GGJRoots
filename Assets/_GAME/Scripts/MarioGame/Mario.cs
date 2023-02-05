using System;
using _GAME.Scripts.Events;
using Ambrosia.EventBus;
using Unity.VisualScripting;
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

        if (horizontal != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

        #endregion

        #region Jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            anim.SetTrigger("isJump");
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

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Finish"))
        {
            //Win
            EventBus<MarioWinEvent>.Emit(this, new MarioWinEvent());
        }

        if (coll.gameObject.CompareTag("Lose"))
        {
            //Die
            EventBus<GameLoseEvent>.Emit(this, new GameLoseEvent());
        }
    }
}