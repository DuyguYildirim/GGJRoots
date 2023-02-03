using Ambrosia.Common.ModuleManagement;
using UnityEngine;
using UnityEngine.Scripting;

namespace Ambrosia.Common.ModuleManagement
{
    /// <summary>
    /// Loads and initializes the single <see cref="ModuleRegistry"/> instance.
    /// </summary>
    internal static class Bootstrapper
    {
        [Preserve]
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            ModuleRegistry.Load().Bootstrap();
        }
    }
}
