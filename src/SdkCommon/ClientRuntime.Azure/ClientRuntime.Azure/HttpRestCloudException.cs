using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest;

namespace Microsoft.Rest.Azure
{
    public class HttpRestCloudException : CloudException, IHttpRestException<CloudError>
    {
        public void SetErrorModel(CloudError model) => Body = model;
        
        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        public HttpRestCloudException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public HttpRestCloudException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public HttpRestCloudException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public string Code => Body.Code;

        public string ErrorInformation => Body.Message;

    }

}