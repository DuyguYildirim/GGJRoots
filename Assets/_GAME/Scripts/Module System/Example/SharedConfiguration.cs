using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Ambrosia.Game.Core
{
    //Ayrı bir scripte direk ayar tutulabilir
    [Serializable]
    public struct SharedConfiguration
    {
        [field: SerializeField] public int MinMoney { get; [UsedImplicitly] private set; }

        [field: SerializeField] public int MaxMoney { get; [UsedImplicitly] private set; }

        [field: SerializeField] public int MinWaitTİme { get; [UsedImplicitly] private set; }

        [field: SerializeField] public int MaxWaitTime { get; [UsedImplicitly] private set; }
    }
}