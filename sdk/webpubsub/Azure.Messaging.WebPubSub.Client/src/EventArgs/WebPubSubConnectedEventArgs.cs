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
        /// The connection id of the client
        /// </summary>
        public string ConnectionId { get; }

        /// <summary>
        /// Groups that currently the client should in from client sdk's perspective. Groups that join or leave from server won't be taken into consideration.
        /// E.g. Client A:  Join Group A ----------------> Leave Group A ------------> Join Group B ----------------> Reconnect
        ///      Server:                                                                             Leave Group B
        /// Then you will get Group B in the List. Because client can't recognize the operation from server.
        /// </summary>
        public IReadOnlyDictionary<string, Exception> GroupRestoreState { get; }

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
