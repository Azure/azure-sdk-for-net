// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The event args for connected
    /// </summary>
    public class WebPubSubConnectedEventArgs
    {
        /// <summary>
        /// The user-id
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// The connection ID of the client. The ID is assigned when the client connects.
        /// </summary>
        public string ConnectionId { get; }

        /// <summary>
        /// Gets a cancellation token related to the original operation that raised the event.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        internal WebPubSubConnectedEventArgs(ConnectedMessage connectedMessage, CancellationToken cancellationToken = default)
        {
            UserId = connectedMessage.UserId;
            ConnectionId = connectedMessage.ConnectionId;
            CancellationToken = cancellationToken;
        }
    }
}
