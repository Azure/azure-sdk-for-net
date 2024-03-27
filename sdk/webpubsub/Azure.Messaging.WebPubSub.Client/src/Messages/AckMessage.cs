// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing Ack.
    /// </summary>
    public class AckMessage : WebPubSubMessage
    {
        /// <summary>
        /// The ack-id
        /// </summary>
        public long AckId { get; }

        /// <summary>
        /// Representing whether the operation is success.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// The error detail when the operation is not success.
        /// </summary>
        public AckMessageError Error { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AckMessage"/> class.
        /// </summary>
        /// <param name="ackId">The ack-id</param>
        /// <param name="success">Representing whether the operation is success.</param>
        /// <param name="error">The error detail when the operation is not success.</param>
        public AckMessage(long ackId, bool success, AckMessageError error)
        {
            AckId = ackId;
            Success = success;
            Error = error;
        }
    }
}
