// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// The exception thrown when a SignalR trigger fails to process an invocation.
    /// </summary>
    public class SignalRTriggerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRTriggerException"/> class.
        /// </summary>
        public SignalRTriggerException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRTriggerException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SignalRTriggerException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRTriggerException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public SignalRTriggerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}