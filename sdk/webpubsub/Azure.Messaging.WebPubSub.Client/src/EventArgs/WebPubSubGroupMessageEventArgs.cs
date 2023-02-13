// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The event args for message from groups
    /// </summary>
    public class WebPubSubGroupMessageEventArgs
    {
        /// <summary>
        /// The group data message.
        /// </summary>
        public GroupDataMessage Message { get; }

        /// <summary>
        /// Gets a cancellation token related to the original operation that raised the event.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        internal WebPubSubGroupMessageEventArgs(GroupDataMessage groupResponseMessage, CancellationToken cancellationToken = default)
        {
            Message = groupResponseMessage;
            CancellationToken = cancellationToken;
        }
    }
}
