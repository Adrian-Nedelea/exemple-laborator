using System;
using System.Runtime.Serialization;

namespace Exemple.Domain
{
    [Serializable]
    internal class ProdusInvalid : Exception
    {
        public ProdusInvalid()
        {
        }

        public ProdusInvalid(string? message) : base(message)
        {
        }

        public ProdusInvalid(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProdusInvalid(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}