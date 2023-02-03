using System;

namespace Ambrosia.Common.Core
{
    public abstract class AmbrosiaException : Exception
    {
        protected AmbrosiaException(string message) : base(message) { }
        protected AmbrosiaException(string message, Exception inner) : base(message, inner) { }
    }
}