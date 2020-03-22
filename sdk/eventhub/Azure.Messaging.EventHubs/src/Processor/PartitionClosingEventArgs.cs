// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about the partition whose processing is being stopped.
    /// </summary>
    ///
    public class PartitionClosingEventArgs
    {
        /// <summary>
        ///   The identifier of the Event Hub partition this instance is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The reason why the processing for the associated partition is being stopped.
        /// </summary>
        ///
        public ProcessingStoppedReason Reason { get; }

        /// <summary>
        ///   A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        ///
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionClosingEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition this instance is associated with.</param>
        /// <param name="reason">The reason why the processing for the associated partition is being stopped.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public PartitionClosingEventArgs(string partitionId,
                                         ProcessingStoppedReason reason,
                                         CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            PartitionId = partitionId;
            Reason = reason;
            CancellationToken = cancellationToken;
        }
    }
}
