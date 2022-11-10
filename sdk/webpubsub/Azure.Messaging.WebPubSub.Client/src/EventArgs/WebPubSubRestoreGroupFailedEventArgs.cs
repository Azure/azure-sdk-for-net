// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// Groups that have joined by client will be restore after reconnection. Groups that joined or leaved from server won't be taken into consideration.
    /// E.g. Client A:  Join Group A ----------------> Leave Group A ------------> Join Group B ----------------> Reconnect
    ///      Server:                                                                             Leave Group B
    /// Then restore will contains Group B. Because client can't recognize the operation from server.
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
