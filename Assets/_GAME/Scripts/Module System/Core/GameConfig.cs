using Ambrosia.Common.ModuleManagement;
using JetBrains.Annotations;
using UnityEngine;

namespace Ambrosia.Game.Core
{
    [CreateAssetMenu(fileName = TypeName, menuName = MenuName)]
    public sealed class GameConfig : SingletonModule<GameConfig>
    {
        private const string TypeName = nameof(GameConfig);
        private const string MenuName = GameConstants.MenuPrefix + "/" + TypeName;

        [field: SerializeField] public SharedConfiguration Shared { get; [UsedImplicitly] private set; }

        [field: SerializeField] public PlayerSettingsExample.Configuration Player { get; [UsedImplicitly] private set; }
    }
}