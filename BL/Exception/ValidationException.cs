using System;

namespace BL.Exception
{
    public class ValidationException : FormatException
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
