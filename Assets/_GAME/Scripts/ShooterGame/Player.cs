using Ambrosia.EventBus;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float playerSpeed;

    [SerializeField] private float rotationsPerMinute;

    [SerializeField] private Transform gunTransform;

    [SerializeField] private Animator gunAnimator;
    [SerializeField] private ParticleSystem particle;

    private int reloadGunIndex = 0;

    void Update()
    {
        #region Movement

        //ileri-geri
        float vertical = Input.GetAxis("Vertical");

        //dönme
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            transform.Rotate(0, 6f * -rotationsPerMinute * Time.deltaTime, 0);
        }

        if (horizontal > 0)
        {
            transform.Rotate(0, 6f * rotationsPerMinute * Time.deltaTime, 0);
        }

        Vector3 move = transform.forward * vertical;
        characterController.Move(move * playerSpeed * Time.deltaTime);

        #endregion

        #region Shoot

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gunAnimator.SetTrigger("isShoot");
            particle.Play();
            reloadGunIndex += 1;
            if (reloadGunIndex >= 2)
            {
                gunAnimator.SetTrigger("isReloadGun");
                reloadGunIndex = 0;
            }

            if (Physics.Raycast(gunTransform.position, gunTransform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    EventBus<isShootEnemyEvent>.Emit(this, new isShootEnemyEvent(hit.transform.gameObject));
                    //Destroy(hit.transform.gameObject, 10);
                }
            }

            // RaycastHit hit2;
            // if (Input.GetKeyDown(KeyCode.E))
            // {
            //     if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit2,
            //             Mathf.Infinity))
            //     {
            //         if (hit2.transform.gameObject.CompareTag("Door"))
            //         {
            //             Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaa");
            //             hit2.transform.DOLocalMove(
            //                 new Vector3(hit.transform.localPosition.x, hit2.transform.localPosition.y,
            //                     hit2.transform.localPosition.z + 1.5f), 1);
            //         }
            //     }
            // }


            if (Input.GetKeyDown(KeyCode.E))
            {
            }
        }

        #endregion
    }
}