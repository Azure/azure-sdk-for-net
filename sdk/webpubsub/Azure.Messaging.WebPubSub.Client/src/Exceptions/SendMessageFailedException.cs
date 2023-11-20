// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// Exception for sending message failed
    /// </summary>
    public class SendMessageFailedException : Exception
    {
        /// <summary>
        /// The ackId
        /// </summary>
        public long? AckId { get; }

        /// <summary>
        /// The error code response from the service. If the error is not from the serivce, code is empty.
        /// </summary>
        public string Code { get; }

        internal SendMessageFailedException(string message, long? ackId, string code) : base(message)
        {
            AckId = ackId;
            Code = code ?? string.Empty;
        }

        internal SendMessageFailedException(string message, long? ackId, Exception innerException) : base(message, innerException)
        {
            AckId = ackId;
            Code = string.Empty;
        }
    }
}
