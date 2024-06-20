// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The contract for logging <see cref="BlobsCheckpointStore" />
    ///   operations.
    /// </summary>
    ///
    public interface IBlobEventLogger
    {
        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="ownershipCount">The amount of ownership received from the storage service.</param>
        ///
        void ListOwnershipComplete(string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string consumerGroup,
                                   int ownershipCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of ownership.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        void ListOwnershipError(string fullyQualifiedNamespace,
                                string eventHubName,
                                string consumerGroup,
                                string exception);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        void ListOwnershipStart(string fullyQualifiedNamespace,
                                string eventHubName,
                                string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        /// <param name="checkpointCount">The amount of checkpoints received from the storage service.</param>
        ///
        void ListCheckpointsComplete(string fullyQualifiedNamespace,
                                     string eventHubName,
                                     string consumerGroup,
                                     int checkpointCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of checkpoints.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        void ListCheckpointsError(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  string consumerGroup,
                                  string exception);

        /// <summary>
        ///   Indicates that invalid checkpoint data was found during an attempt to retrieve a list of checkpoints.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the data is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the data is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the data is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the data is associated with.</param>
        ///
        void InvalidCheckpointFound(string partitionId,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    string consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        ///
        void ListCheckpointsStart(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  string consumerGroup);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while updating a checkpoint.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with this checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with this checkpoint.</param>
        /// <param name="offset">The offset associated with this checkpoint.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        void UpdateCheckpointError(string partitionId,
                                   string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string consumerGroup,
                                   string clientIdentifier,
                                   string sequenceNumber,
                                   string replicationSegment,
                                   string offset,
                                   string exception);

        /// <summary>
        ///   Indicates that an attempt to update a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with this checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with this checkpoint.</param>
        /// <param name="offset">The offset associated with this checkpoint.</param>
        ///
        void UpdateCheckpointComplete(string partitionId,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      string consumerGroup,
                                      string clientIdentifier,
                                      string sequenceNumber,
                                      string replicationSegment,
                                      string offset);

        /// <summary>
        ///   Indicates that an attempt to create/update a checkpoint has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with this checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with this checkpoint.</param>
        /// <param name="offset">The offset associated with this checkpoint.</param>
        ///
        void UpdateCheckpointStart(string partitionId,
                                   string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string consumerGroup,
                                   string clientIdentifier,
                                   string sequenceNumber,
                                   string replicationSegment,
                                   string offset);

        /// <summary>
        ///   Indicates that an attempt to retrieve claim partition ownership has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        void ClaimOwnershipComplete(string partitionId,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    string consumerGroup,
                                    string ownerIdentifier);

        /// <summary>
        ///   Indicates that an exception was encountered while attempting to retrieve claim partition ownership.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        void ClaimOwnershipError(string partitionId,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 string consumerGroup,
                                 string ownerIdentifier,
                                 string exception);

        /// <summary>
        ///   Indicates that ownership was unable to be claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="message">The message for the failure.</param>
        ///
        void OwnershipNotClaimable(string partitionId,
                                   string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string consumerGroup,
                                   string ownerIdentifier,
                                   string message);

        /// <summary>
        ///   Indicates that ownership was successfully claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        void OwnershipClaimed(string partitionId,
                              string fullyQualifiedNamespace,
                              string eventHubName,
                              string consumerGroup,
                              string ownerIdentifier);

        /// <summary>
        ///   Indicates that an attempt to claim a partition ownership has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        void ClaimOwnershipStart(string partitionId,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 string consumerGroup,
                                 string ownerIdentifier);

        /// <summary>
        ///   Indicates that a <see cref="BlobsCheckpointStore" /> was created.
        /// </summary>
        ///
        /// <param name="typeName">The type name for the checkpoint store.</param>
        /// <param name="accountName">The Storage account name corresponding to the associated container client.</param>
        /// <param name="containerName">The name of the associated container client.</param>
        ///
        void BlobsCheckpointStoreCreated(string typeName,
                                         string accountName,
                                         string containerName);

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        ///
        void GetCheckpointStart(string fullyQualifiedNamespace,
                                string eventHubName,
                                string consumerGroup,
                                string partitionId);

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the Event Hubs client that authored the checkpoint.</param>
        /// <param name="lastModified">The date and time the associated checkpoint was last modified.</param>
        ///
        void GetCheckpointComplete(string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string consumerGroup,
                                   string partitionId,
                                   string clientIdentifier,
                                   DateTimeOffset lastModified);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a checkpoint.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        void GetCheckpointError(string fullyQualifiedNamespace,
                                string eventHubName,
                                string consumerGroup,
                                string partitionId,
                                string exception);
    }
}
