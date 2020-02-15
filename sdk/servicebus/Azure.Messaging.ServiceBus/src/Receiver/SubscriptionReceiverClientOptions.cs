// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class SubscriptionReceiverClientOptions : ServiceBusReceiverClientOptions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="SubscriptionReceiverClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="SubscriptionReceiverClientOptions" />.</returns>
        ///
        internal SubscriptionReceiverClientOptions Clone() =>
            new SubscriptionReceiverClientOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };
    }
}
