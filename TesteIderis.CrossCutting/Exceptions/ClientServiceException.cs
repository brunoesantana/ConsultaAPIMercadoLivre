using System;
using System.Runtime.Serialization;

namespace TesteIderis.CrossCutting.Exceptions
{
    public class ClientServiceException : Exception
    {
        public ClientServiceException()
        {
        }

        public ClientServiceException(string message) : base(message)
        {
        }

        public ClientServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}