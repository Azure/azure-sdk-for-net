// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Allows interaction with checkpoint and ownership data needed for event processor operation,
    ///   using Azure Storage blobs for persistence.
    /// </summary>
    ///
    public class BlobCheckpointStore : CheckpointStore
    {
        /// <summary>The checkpoint store providing the implementation for storage operations; calls will delegate to this instance.</summary>
        private readonly CheckpointStore _checkpointStoreImplementation;

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobCheckpointStore" /> class.
        /// </summary>
        ///
        /// <param name="blobContainerClient">The client responsible for persisting data to Azure Storage.</param>
        ///
        /// <remarks>
        ///   The blob container referenced by the <paramref name="blobContainerClient" /> is expected to exist.
        /// </remarks>
        ///
        public BlobCheckpointStore(BlobContainerClient blobContainerClient) : this(new BlobCheckpointStoreInternal(blobContainerClient))
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobCheckpointStore" /> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The implementation to which storage operations will be delegated.</param>
        ///
        internal BlobCheckpointStore(CheckpointStore checkpointStore) => _checkpointStoreImplementation = checkpointStore;

        /// <summary>
        ///   Requests a list of the ownership assignments for partitions between each of the cooperating event processor
        ///   instances for a given Event Hub and consumer group pairing.  This operation is used during load balancing to allow
        ///   the processor to discover other active collaborators and to make decisions about how to best balance work
        ///   between them.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership data to take into account when making load balancing decisions.</returns>
        ///
        public override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                               string eventHubName,
                                                                                               string consumerGroup,
                                                                                               CancellationToken cancellationToken) => _checkpointStoreImplementation.ListOwnershipAsync(fullyQualifiedNamespace, eventHubName, consumerGroup, cancellationToken);

        /// <summary>
        ///   Attempts to claim ownership of the specified partitions for processing.  This operation is used by
        ///   load balancing to enable distributing the responsibility for processing partitions for an
        ///   Event Hub and consumer group pairing amongst the active event processors.
        /// </summary>
        ///
        /// <param name="desiredOwnership">The set of partition ownership desired by the event processor instance; this is the set of partitions that it will attempt to request responsibility for processing.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records for the partitions that were successfully claimed; this is expected to be the <paramref name="desiredOwnership"/> or a subset of those partitions.</returns>
        ///
        public override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                                                                                                CancellationToken cancellationToken) => _checkpointStoreImplementation.ClaimOwnershipAsync(desiredOwnership, cancellationToken);

        /// <summary>
        ///   Requests checkpoint information for a specific partition, allowing an event processor to resume reading
        ///   from the next event in the stream.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The identifier of the partition to read a checkpoint for.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventProcessorCheckpoint"/> instance, if a checkpoint was found for the requested partition; otherwise, <c>null</c>.</returns>
        ///
        public override Task<EventProcessorCheckpoint> GetCheckpointAsync(string fullyQualifiedNamespace,
                                                                          string eventHubName,
                                                                          string consumerGroup,
                                                                          string partitionId,
                                                                          CancellationToken cancellationToken) => _checkpointStoreImplementation.GetCheckpointAsync(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, cancellationToken);

        /// <summary>
        ///   Obsolete.
        ///
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="offset">The offset to associate with the checkpoint, intended as informational metadata. This will only be used from positioning if there is no value provided for <paramref name="sequenceNumber"/>.</param>
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   This method is obsolete and should no longer be used.  Please use <see cref="UpdateCheckpointAsync(string, string, string, string, string, CheckpointPosition, CancellationToken)"/> instead.
        /// </remarks>
        ///
        [Obsolete(AttributeMessageText.LongOffsetUpdateCheckpointObsolete, false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task UpdateCheckpointAsync(string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string partitionId,
                                                  long offset,
                                                  long? sequenceNumber,
                                                  CancellationToken cancellationToken) => _checkpointStoreImplementation.UpdateCheckpointAsync(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, offset, sequenceNumber, cancellationToken);

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="startingPosition">The starting position to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        public override Task UpdateCheckpointAsync(string fullyQualifiedNamespace,
                                                   string eventHubName,
                                                   string consumerGroup,
                                                   string partitionId,
                                                   string clientIdentifier,
                                                   CheckpointPosition startingPosition,
                                                   CancellationToken cancellationToken) => _checkpointStoreImplementation.UpdateCheckpointAsync(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, clientIdentifier, startingPosition, cancellationToken);
    }
}
