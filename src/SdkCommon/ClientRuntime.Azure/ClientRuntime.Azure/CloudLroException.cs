// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
namespace Microsoft.Rest.Azure
{
    public class CloudLroException : CloudException
    {
        public override string Message => _message;
        
        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        public CloudLroException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudLroException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudLroException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
