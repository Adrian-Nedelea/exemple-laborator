using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    [Serializable]
    internal class PretInvalid : Exception
    {
        public PretInvalid()
        {
        }

        public PretInvalid(string? message) : base(message)
        {
        }

        public PretInvalid(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PretInvalid(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
