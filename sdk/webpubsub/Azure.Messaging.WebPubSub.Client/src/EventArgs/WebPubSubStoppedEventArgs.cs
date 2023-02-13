// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The event args for stopped
    /// </summary>
    public class WebPubSubStoppedEventArgs
    {
        /// <summary>
        /// Gets a cancellation token related to the original operation that raised the event.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        internal WebPubSubStoppedEventArgs(CancellationToken cancellationToken = default)
        {
            CancellationToken = cancellationToken;
        }
    }
}
