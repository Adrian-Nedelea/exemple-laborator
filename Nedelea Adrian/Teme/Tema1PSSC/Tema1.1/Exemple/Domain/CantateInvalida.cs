using System;
using System.Runtime.Serialization;

namespace Exemple.Domain
{
    [Serializable]
    internal class CantitateInvalida: Exception
    {
        public CantitateInvalida()
        {
        }

        public CantitateInvalida(string? message) : base(message)
        {
        }

        public CantitateInvalida(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CantitateInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}