using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct isShootEnemyEvent
{
    public readonly GameObject _transformGameObject;

    public isShootEnemyEvent(GameObject transformGameObject)
    {
        _transformGameObject = transformGameObject;
    }
}