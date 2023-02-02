using System.Runtime.Serialization;

namespace ChalkboardUI.Exceptions
{
    public class ChalkboardException : Exception
    {
        public ChalkboardException()
        {
        }

        public ChalkboardException(string? message) : base(message)
        {
        }

        public ChalkboardException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected ChalkboardException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}