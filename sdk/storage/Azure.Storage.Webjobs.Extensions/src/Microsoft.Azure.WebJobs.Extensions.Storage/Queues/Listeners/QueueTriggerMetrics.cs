// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Scale;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    /// <summary>
    /// Metrics type representing the status of an Azure Queue.
    /// </summary>
    internal class QueueTriggerMetrics : ScaleMetrics
    {
        /// <summary>
        /// The current length of the queue.
        /// </summary>
        public int QueueLength { get; set; }

        /// <summary>
        /// The length of time the next message in the queue has been
        /// sitting there.
        /// </summary>
        public TimeSpan QueueTime { get; set; }
    }
}
