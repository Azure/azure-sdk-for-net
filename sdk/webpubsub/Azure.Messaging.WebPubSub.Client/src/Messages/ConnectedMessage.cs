// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing the client is connected
    /// </summary>
    public class ConnectedMessage : WebPubSubMessage
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
        /// The reconnection token for recovering the connection. Only availble in reliable subprotocol.
        /// </summary>
        public string ReconnectionToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectedMessage"/> class.
        /// </summary>
        /// <param name="userId">The user-id</param>
        /// <param name="connectionId">The connection ID of the client</param>
        /// <param name="reconnectionToken">The reconnection token for recovering the connection. Only availble in reliable subprotocol.</param>
        public ConnectedMessage(string userId, string connectionId, string reconnectionToken)
        {
            UserId = userId;
            ConnectionId = connectionId;
            ReconnectionToken = reconnectionToken;
        }
    }
}
