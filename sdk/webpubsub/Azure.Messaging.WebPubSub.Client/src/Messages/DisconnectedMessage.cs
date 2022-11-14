// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing a client disconnection
    /// </summary>
    public class DisconnectedMessage : WebPubSubMessage
    {
        /// <summary>
        /// The reason for being disconnected.
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisconnectedMessage"/> class.
        /// </summary>
        /// <param name="reason">The reason of getting disconnected.</param>
        public DisconnectedMessage(string reason)
        {
            Reason = reason;
        }
    }
}
