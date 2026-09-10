// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// Exception thrown when an invocation fails.
    /// </summary>
    public class InvocationFailedException : Exception
    {
        /// <summary>
        /// The invocation id of the request.
        /// </summary>
        public string InvocationId { get; }

        /// <summary>
        /// The error code response from the service. If the error is not from the service, code is empty.
        /// </summary>
        public string Code { get; }

        internal InvocationFailedException(string message, string invocationId, string code) : base(message)
        {
            InvocationId = invocationId;
            Code = code ?? string.Empty;
        }

        internal InvocationFailedException(string message, string invocationId, Exception innerException) : base(message, innerException)
        {
            InvocationId = invocationId;
            Code = string.Empty;
        }
    }
}
