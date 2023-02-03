using System;
using System.Linq;
using JetBrains.Annotations;

namespace Ambrosia.Common.Utility
{
    [PublicAPI]
    public static class Extensions
    {
         /// <summary>
        /// Returns the type name. If this is a generic type, appends the list of generic type arguments between angle
        /// brackets.
        /// </summary>
        /// <param name="type">The type.</param>
        public static string GetFormattedName(this Type type)
        {
            if (!type.IsGenericType)
            {
                return type.Name;
            }

            var genericArguments = type.GetGenericArguments()
                .Select(x => x.GetFormattedName())
                .Aggregate((x1, x2) => $"{x1}, {x2}");

            return $"{type.Name.Before("`")}<{genericArguments}>";
        }

        /// <summary>
        /// Returns a new string that only includes what comes before the first instance of <paramref name="phrase"/>.
        /// </summary>
        public static string Before(this string original, string phrase)
        {
            var index = original.IndexOf(phrase, StringComparison.Ordinal);
            return index >= 0 ? original.Substring(0, index) : original;
        }

        // TODO: maybe generalize this to accept closed generics and non-generics as well
        /// <summary>
        /// Searches upwards to find a closed generic type that matches a given open generic type in the hierarchy of a given type.
        /// Starting type is also included in the search.
        /// </summary>
        /// <param name="type">The search will start here and go upwards (towards ancestors).</param>
        /// <param name="targetOpenGenericType">The open generic type we are searching for.</param>
        /// <param name="foundClosedGenericType">The found closed generic type, or null.</param>
        /// <returns>True if a match is found, false otherwise.</returns>
        /// <remarks>
        /// A generic type is considered open if at least one of its generic parameters is not given. For example:
        /// <list type="bullet">
        ///     <item>For this definition: <c>Foo&lt;T&gt;</c></item>
        ///     <item>This is an open generic type: <c>Foo&lt;&gt;</c></item>
        ///     <item>This is a closed generic type: <c>Foo&lt;int&gt;</c></item>
        /// </list>
        /// </remarks>
        public static bool TryGetClosedGenericAncestorType(this Type type, Type targetOpenGenericType, out Type foundClosedGenericType)
        {
            for (var candidate = type; candidate != null; candidate = candidate.BaseType)
            {
                if (candidate.IsGenericType && candidate.GetGenericTypeDefinition() == targetOpenGenericType)
                {
                    foundClosedGenericType = candidate;
                    return true;
                }
            }

            foundClosedGenericType = null;
            return false;
        }
    }
}