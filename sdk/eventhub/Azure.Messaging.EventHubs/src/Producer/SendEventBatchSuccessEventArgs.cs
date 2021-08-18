// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   Contains information about a batch that was published and the partition
    ///   that it was published to.
    /// </summary>
    ///
    internal class SendEventBatchSuccessEventArgs : EventArgs
    {
        /// <summary>
        ///   The set of events in the batch that was published.
        /// </summary>
        ///
        public IEnumerable<EventData> EventBatch { get; set; }

        /// <summary>
        ///   The identifier of the partition that the batch was published to.
        /// </summary>
        ///
        public string PartitionId { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SendEventBatchSuccessEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="eventBatch">The set of events in the batch that was published.</param>
        /// <param name="partitionId">The identifier of the partition that the batch was published to.</param>
        ///
        public SendEventBatchSuccessEventArgs(IEnumerable<EventData> eventBatch,
                                              string partitionId)
        {
            EventBatch = eventBatch;
            PartitionId = partitionId;
        }
    }
}
