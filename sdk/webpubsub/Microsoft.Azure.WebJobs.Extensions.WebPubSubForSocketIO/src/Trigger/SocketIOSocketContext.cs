// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebPubSub.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Represents the context for a SocketIO socket.
    /// </summary>
    public class SocketIOSocketContext : WebPubSubConnectionContext
    {
        /// <summary>
        /// The socket id of the socket.
        /// </summary>
        public string SocketId { get; }

        /// <summary>
        /// The namespace of the socket.
        /// </summary>
        public string Namespace { get; }

        private new string UserId { get; }

        private new IReadOnlyDictionary<string, object> States { get; }

        /// <summary>
        /// Initializes a new instance of the SocketIOSocketContext class.
        /// </summary>
        internal SocketIOSocketContext(WebPubSubEventType eventType, string eventName, string hub, string connectionId, string ns, string socketId, string signature, string origin, IReadOnlyDictionary<string, string[]> headers) : base(eventType, eventName, hub, connectionId, null, signature, origin, (IReadOnlyDictionary<string, object>)null, headers)
        {
            SocketId = socketId;
            Namespace = ns;
        }
    }
}
