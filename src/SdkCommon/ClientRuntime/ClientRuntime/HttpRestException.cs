using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Rest
{
    public class HttpRestException<T> : HttpRestExceptionBase<T>
    {
        public T ErrorInformation => Body;

        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        public HttpRestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public HttpRestException(string message)
            : base(message, null)
        {
        }

        public HttpRestException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }
    }
}