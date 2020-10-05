// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   The type of approach to apply when calculating the delay
    ///   between retry attempts.
    /// </summary>
    ///
    public enum ServiceBusRetryMode
    {
        /// <summary>Retry attempts happen at fixed intervals; each delay is a consistent duration.</summary>
        Fixed,

        /// <summary>Retry attempts will delay based on a back-off strategy, where each attempt will increase the duration that it waits before retrying.</summary>
        Exponential
    }
}
