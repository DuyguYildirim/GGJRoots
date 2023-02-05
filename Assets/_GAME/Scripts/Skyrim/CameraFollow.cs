using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Transform _target;

    [Range(50, 500)] public float sens;
    public Transform body;
    private float xRot = 0f;
    
    [SerializeField] private float rotationsPerMinute;

    private void Awake()
    {
        _target = target.transform;
    }

    private void LateUpdate()
    {
        if (_target)
        {
            transform.position = new Vector3(_target.position.x, _target.position.y, _target.position.z);
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            transform.Rotate(0, 6f * -rotationsPerMinute * Time.deltaTime, 0);
        }

        if (horizontal > 0)
        {
            transform.Rotate(0, 6f * rotationsPerMinute * Time.deltaTime, 0);
        }
    }
}