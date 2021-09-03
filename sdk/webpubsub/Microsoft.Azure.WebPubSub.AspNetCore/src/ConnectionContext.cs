// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Request context from headers following CloudEvents.
    /// </summary>
    public class ConnectionContext
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        public WebPubSubEventType EventType { get; internal set; }

        /// <summary>
        /// The event name of the message.
        /// </summary>
        public string EventName { get; internal set; }

        /// <summary>
        /// The hub which the connection belongs to.
        /// </summary>
        public string Hub { get; internal set; }

        /// <summary>
        /// The connection-id of the client.
        /// </summary>
        public string ConnectionId { get; internal set; }

        /// <summary>
        /// The user identity of the client.
        /// </summary>
        public string UserId { get; internal set; }

        /// <summary>
        /// The signature for validation.
        /// </summary>
        public string Signature { get; internal set; }

        /// <summary>
        /// Upstream origin.
        /// </summary>
        public string Origin { get; internal set; }

        /// <summary>
        /// The connection states.
        /// </summary>
        public Dictionary<string, object> States { get; internal set; } = new Dictionary<string, object>();

        /// <summary>
        /// The headers of request.
        /// </summary>
        public Dictionary<string, StringValues> Headers { get; internal set; }
    }
}
