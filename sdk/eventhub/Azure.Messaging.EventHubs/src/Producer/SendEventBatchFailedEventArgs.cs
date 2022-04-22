// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   Contains information about a batch that was unable to be published, as well
    ///   as the exception that occurred and the partition that the batch was being published
    ///   to.
    /// </summary>
    ///
    public class SendEventBatchFailedEventArgs : EventArgs
    {
        /// <summary>
        ///   The set of events that were in the batch that failed to publish.
        /// </summary>
        ///
        public IReadOnlyList<EventData> EventBatch { get; }

        /// <summary>
        ///   The exception that occurred when trying to publish the batch.
        /// </summary>
        ///
        public Exception Exception { get; }

        /// <summary>
        ///   The identifier of the partition to which the batch was being published.
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
        ///   Initializes a new instance of the <see cref="SendEventBatchFailedEventArgs"/> class.
        /// </summary>
        /// <param name="eventBatch">The set of events that were in the batch that failed to publish.</param>
        /// <param name="exception">The exception that occurred when trying to publish the batch.</param>
        /// <param name="partitionId">The identifier of the partition to which the batch was being published.</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public SendEventBatchFailedEventArgs(IReadOnlyList<EventData> eventBatch,
                                             Exception exception,
                                             string partitionId,
                                             CancellationToken cancellationToken = default)
        {
            EventBatch = eventBatch;
            Exception = exception;
            PartitionId = partitionId;
            CancellationToken = cancellationToken;
        }
    }
}
