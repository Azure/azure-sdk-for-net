// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;

namespace Microsoft.Azure
{
    /// <summary>
    /// An exception generated from an http response returned from a Microsoft Azure service
    /// </summary>
    public class CloudException : HttpOperationException<CloudError>
    {
        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        public CloudException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
