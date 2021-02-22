// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that an <c>EventProcessorClient</c> will be
    ///   processing events from.  It can also be used to specify the position within a partition
    ///   where the associated <c>EventProcessorClient</c> should begin reading events in case
    ///   it cannot find a checkpoint.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
    ///
    public class PartitionInitializingEventArgs
    {
        /// <summary>
        ///   The identifier of the partition whose processing is starting.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The position within a partition where the associated <c>EventProcessorClient</c> should
        ///   begin reading events when no checkpoint can be found.
        /// </summary>
        ///
        public EventPosition DefaultStartingPosition { get; set; }

        /// <summary>
        ///   A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        ///
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionInitializingEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose processing is starting.</param>
        /// <param name="defaultStartingPosition">The position within a partition where the associated <c>EventProcessorClient</c> should begin reading events when no checkpoint can be found.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public PartitionInitializingEventArgs(string partitionId,
                                              EventPosition defaultStartingPosition,
                                              CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            PartitionId = partitionId;
            DefaultStartingPosition = defaultStartingPosition;
            CancellationToken = cancellationToken;
        }
    }
}
