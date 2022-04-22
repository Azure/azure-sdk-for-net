// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   Contains information about a batch that was published and the partition
    ///   that it was published to.
    /// </summary>
    ///
    public class SendEventBatchSucceededEventArgs : EventArgs
    {
        /// <summary>
        ///   The set of events in the batch that was published.
        /// </summary>
        ///
        public IReadOnlyList<EventData> EventBatch { get; }

        /// <summary>
        ///   The identifier of the partition that the batch was published to.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   A <see cref="System.Threading.CancellationToken"/> to indicate that the producer is being closed
        ///    or disposed and is requesting that the handler stop its activities.
        /// </summary>
        ///
        /// <remarks>
        ///   The handler processing events has responsibility for deciding whether or not to honor
        ///   the cancellation request.  If the application chooses not to do so, the producer will wait for the
        ///   handler to complete before shutting down.
        /// </remarks>
        ///
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SendEventBatchSucceededEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="eventBatch">The set of events in the batch that was published.</param>
        /// <param name="partitionId">The identifier of the partition that the batch was published to.</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public SendEventBatchSucceededEventArgs(IReadOnlyList<EventData> eventBatch,
                                                string partitionId,
                                                CancellationToken cancellationToken)
        {
            EventBatch = eventBatch;
            PartitionId = partitionId;
            CancellationToken = cancellationToken;
        }
    }
}
