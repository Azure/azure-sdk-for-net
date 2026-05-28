// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// To represent the result of ack-able operations.
    /// </summary>
    public class WebPubSubResult
    {
        /// <summary>
        /// The ack id of message just sent. If the operation is fire-and-forget, it will be null.
        /// </summary>
        public long? AckId { get; }

        /// <summary>
        /// Whether the message is duplicated, if true, the message with the ack id has been processed by service
        /// </summary>
        public bool IsDuplicated { get; }

        internal WebPubSubResult(): this(null, false)
        {
        }

        internal WebPubSubResult(long? ackId, bool isDuplicated)
        {
            AckId = ackId;
            IsDuplicated = isDuplicated;
        }
    }
}
