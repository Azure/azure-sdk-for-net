// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The event args for stopped
    /// </summary>
    public class WebPubSubRestoreGroupFailedEventArgs
    {
        /// <summary>
        /// Gets a cancellation token related to the original operation that raised the event.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// The exceptions throws when restore group fails
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// The group name
        /// </summary>
        public string Group { get; }

        internal WebPubSubRestoreGroupFailedEventArgs(string group, Exception ex, CancellationToken cancellationToken = default)
        {
            Group = group;
            Exception = ex;
            CancellationToken = cancellationToken;
        }
    }
}
