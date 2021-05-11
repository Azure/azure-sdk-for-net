// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Configuration options for functions that bind to multiple multiple <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public class BatchMessageOptions
    {
        /// <summary>
        /// Gets or sets the maximum number of messages that will be passed to each function call. The default value is 1000.
        /// </summary>
        public int MaxMessages { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the amount of time to wait for each batch receive call.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        public TimeSpan? MaxReceiveWaitTime { get; set; }
    }
}