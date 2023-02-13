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
        public ulong? AckId { get; }

        /// <summary>
        /// The error
        /// </summary>
        public AckMessageError Error { get; }

        internal SendMessageFailedException(string message, ulong? ackId, AckMessageError error = null) : base(message)
        {
            AckId = ackId;
            Error = error;
        }

        internal SendMessageFailedException(string message, ulong? ackId, Exception innerException) : base(message, innerException)
        {
            AckId = ackId;
        }
    }
}
