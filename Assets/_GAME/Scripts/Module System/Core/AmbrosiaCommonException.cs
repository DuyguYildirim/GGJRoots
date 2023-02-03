using System;

namespace Ambrosia.Common.Core
{
    /// <summary>
    /// All exceptions thrown in <c>Ambrosia.Common</c> is either this exact type, or a child of this type.
    /// </summary>
    public class AmbrosiaCommonException : AmbrosiaException
    {
        internal AmbrosiaCommonException(string message) : base(message) {}
        internal AmbrosiaCommonException(string message, Exception inner) : base(message, inner) {}

        internal static AmbrosiaCommonException FromArgumentOutOfRange(string paramName, object paramValue, string details = null)
        {
            var message = $"{paramName} is out of range with a value of {paramValue}";

            if (!string.IsNullOrWhiteSpace(details))
            {
                message += $"\nDetails: {details}";
            }

            return new AmbrosiaCommonException(message, new ArgumentOutOfRangeException(paramName, paramValue, message));
        }

        internal static AmbrosiaCommonException FromNotSupported(string message)
        {
            return new AmbrosiaCommonException(message, new NotSupportedException(message));
        }
    }
}
