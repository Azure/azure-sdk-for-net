// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   Contains information about a batch that was unable to be published, as well
    ///   as the exception that occurred and the partition that the batch was being published
    ///   to.
    /// </summary>
    ///
    internal class SendEventBatchFailedEventArgs : EventArgs
    {
        /// <summary>
        ///   The set of events that were in the batch that failed to publish.
        /// </summary>
        ///
        public IEnumerable<EventData> EventBatch { get; set; }

        /// <summary>
        ///   The exception that occurred when trying to publish the batch.
        /// </summary>
        ///
        public Exception Exception { get; set; }

        /// <summary>
        ///   The identifier of the partition to which the batch was being published.
        /// </summary>
        ///
        public string PartitionId { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SendEventBatchFailedEventArgs"/> class.
        /// </summary>
        /// <param name="eventBatch">The set of events that were in the batch that failed to publish.</param>
        /// <param name="exception">The exception that occurred when trying to publish the batch.</param>
        /// <param name="partitionId">The identifier of the partition to which the batch was being published.</param>
        ///
        public SendEventBatchFailedEventArgs(IEnumerable<EventData> eventBatch,
                                             Exception exception,
                                             string partitionId)
        {
            EventBatch = eventBatch;
            Exception = exception;
            PartitionId = partitionId;
        }
    }
}
