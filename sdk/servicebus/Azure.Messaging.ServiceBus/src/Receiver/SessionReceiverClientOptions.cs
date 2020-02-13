// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class SessionReceiverClientOptions : ServiceBusReceiverClientOptions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="SessionReceiverClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="SessionReceiverClientOptions" />.</returns>
        ///
        internal SessionReceiverClientOptions Clone() =>
            new SessionReceiverClientOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };
    }
}
