// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    /// <summary>
    /// An exception thrown when service request fails.
    /// </summary>
    public class RequestFailedException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets the service specific error code if available. Please refer to the client documentation for the list of supported error codes.
        /// </summary>
        public string? ErrorCode { get; }

        public RequestFailedException(string message) : this(0, message)
        {
        }

        public RequestFailedException(string message, Exception? innerException) : this(0, message, innerException)
        {
        }

        public RequestFailedException(int status, string message)
            : this(status, message, null)
        {
        }

        public RequestFailedException(int status, string message, Exception? innerException)
            : this(status, message, null, innerException)
        {
        }

        public RequestFailedException(int status, string message, string? errorCode, Exception? innerException)
            : base(message, innerException)
        {
            Status = status;
            ErrorCode = errorCode;
        }
    }
}
