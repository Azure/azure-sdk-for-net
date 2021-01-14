// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Configuration options for ServiceBus batch receive.
    /// </summary>
    public class BatchOptions
    {
        /// <summary>
        /// The maximum number of messages that will be received.
        /// </summary>
        public int MaxMessageCount { get; set; }

        /// <summary>
        /// The time span the client waits for receiving a message before it times out.
        /// </summary>
        public TimeSpan OperationTimeout { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the messages should be completed after successful processing.
        /// </summary>
        public bool AutoComplete { get; set; }
    }
}
