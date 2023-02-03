using System;
using Ambrosia.Game.Core;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerSettingsExample : MonoBehaviour
{
    [Serializable]
    public struct Configuration
    {
        [field: SerializeField] public int MinMoney { get; [UsedImplicitly] private set; }

        [field: SerializeField] public int MaxMoney { get; [UsedImplicitly] private set; }

        [field: SerializeField] public int MinWaitTİme { get; [UsedImplicitly] private set; }

        [field: SerializeField] public int MaxWaitTime { get; [UsedImplicitly] private set; }
    }

    public static Configuration Config => GameConfig.Instance.Player;


    private void Start()
    {
        var money = Config.MaxMoney;
    }
}