// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class SubscriptionClientOptions : ServiceBusReceiverClientOptions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="SubscriptionClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="SubscriptionClientOptions" />.</returns>
        ///
        internal SubscriptionClientOptions Clone() =>
            new SubscriptionClientOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };
    }
}
