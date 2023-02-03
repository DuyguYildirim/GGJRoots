//using DG.Tweening;
using Ambrosia.Common.Core;
using JetBrains.Annotations;
using UnityEngine;

namespace Ambrosia.Common.Utility
{
    [PublicAPI]
    public class Utils
    {
        /// <inheritdoc cref="Extensions.GetFormattedName(System.Type)"/>
        public static string GetFormattedName<T>()
        {
            return typeof(T).GetFormattedName();
        }

        /// <summary>
        /// Loads the singe instance of <typeparamref name="T"/> from the root of any Resources folder.
        /// </summary>
        /// <param name="path">Path to look, relative to the Resources folder. If empty, looks in root of all Resources folders.</param>
        /// <typeparam name="T">What are we searching for?</typeparam>
        /// <returns>The single instance of <typeparamref name="T"/>.</returns>
        /// <exception cref="SenecaCommonException">Throws if found no instance or multiple instances.</exception>
        public static T LoadSingleResource<T>(string path) where T : UnityEngine.Object
        {
            var instances = Resources.LoadAll<T>(path);

            if (instances.Length < 1)
            {
                throw new AmbrosiaCommonException($"No instances of {GetFormattedName<T>()} found! Make sure an instance exists under the root of a Resources folder.");
            }

            if (instances.Length > 1)
            {
                throw new AmbrosiaCommonException($"Multiple instances of {GetFormattedName<T>()} found! Make sure there is only one instance under the roots of all Resources folders combined.");
            }

            return instances[0];
        }

    }
}