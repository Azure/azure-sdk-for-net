// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class QueueReceiverClientOptions : ServiceBusReceiverClientOptions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="QueueReceiverClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="QueueReceiverClientOptions" />.</returns>
        ///
        internal QueueReceiverClientOptions Clone() =>
            new QueueReceiverClientOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };
    }
}
