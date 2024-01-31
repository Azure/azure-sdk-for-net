// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The event args for message from server
    /// </summary>
    public class WebPubSubServerMessageEventArgs
    {
        /// <summary>
        /// The server data message
        /// </summary>
        public ServerDataMessage Message { get; }

        /// <summary>
        /// Gets a cancellation token related to the original operation that raised the event.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        internal WebPubSubServerMessageEventArgs(ServerDataMessage message, CancellationToken cancellationToken = default)
        {
            Message = message;
            CancellationToken = cancellationToken;
        }
    }
}
