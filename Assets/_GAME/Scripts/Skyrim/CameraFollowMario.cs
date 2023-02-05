using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMario : MonoBehaviour
{
    public Transform target;

    private Transform _target;
    private void Awake()
    {
        _target = target.transform;

    }
    private void LateUpdate()
    {
        if (_target)
        {
            transform.position = new Vector3(_target.position.x, transform.position.y, transform.position.z);
        }
    }
}