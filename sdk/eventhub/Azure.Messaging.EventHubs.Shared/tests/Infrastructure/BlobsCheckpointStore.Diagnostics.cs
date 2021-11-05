﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Tests;
using Moq;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A storage blob service that keeps track of checkpoints and ownership.
    /// </summary>
    ///
    internal sealed partial class BlobsCheckpointStore
    {
        /// <summary>
        ///   The instance of <see cref="BlobEventStoreEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        public IBlobEventLogger Logger { get; set; } = Mock.Of<IBlobEventLogger>();

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="ownershipCount">The amount of ownership received from the storage service.</param>
        ///
        partial void ListOwnershipComplete(string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           int ownershipCount) =>
            Logger.ListOwnershipComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, ownershipCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of ownership.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        partial void ListOwnershipError(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup,
                                        Exception exception) =>
            Logger.ListOwnershipError(fullyQualifiedNamespace, eventHubName, consumerGroup, exception.Message);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        partial void ListOwnershipStart(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup) =>
            Logger.ListOwnershipStart(fullyQualifiedNamespace, eventHubName, consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        /// <param name="checkpointCount">The amount of checkpoints received from the storage service.</param>
        ///
        partial void ListCheckpointsComplete(string fullyQualifiedNamespace,
                                             string eventHubName,
                                             string consumerGroup,
                                             int checkpointCount) =>
            Logger.ListCheckpointsComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, checkpointCount);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of checkpoints.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        partial void ListCheckpointsError(string fullyQualifiedNamespace,
                                          string eventHubName,
                                          string consumerGroup,
                                          Exception exception) =>
            Logger.ListCheckpointsError(fullyQualifiedNamespace, eventHubName, consumerGroup, exception.Message);

        /// <summary>
        ///   Indicates that invalid checkpoint data was found during an attempt to retrieve a list of checkpoints.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the data is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the data is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the data is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the data is associated with.</param>
        ///
        partial void InvalidCheckpointFound(string partitionId,
                                            string fullyQualifiedNamespace,
                                            string eventHubName,
                                            string consumerGroup) =>
            Logger.InvalidCheckpointFound(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        ///
        partial void ListCheckpointsStart(string fullyQualifiedNamespace,
                                          string eventHubName,
                                          string consumerGroup) =>
            Logger.ListCheckpointsStart(fullyQualifiedNamespace, eventHubName, consumerGroup);

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while updating a checkpoint.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        partial void UpdateCheckpointError(string partitionId,
                                           string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           Exception exception) =>
            Logger.UpdateCheckpointError(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, exception.Message);

        /// <summary>
        ///   Indicates that an attempt to update a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        ///
        partial void UpdateCheckpointComplete(string partitionId,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              string consumerGroup) =>
            Logger.UpdateCheckpointComplete(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);

        /// <summary>
        ///   Indicates that an attempt to create/update a checkpoint has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        ///
        partial void UpdateCheckpointStart(string partitionId,
                                           string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup) =>
            Logger.UpdateCheckpointStart(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);

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
        partial void ClaimOwnershipComplete(string partitionId,
                                            string fullyQualifiedNamespace,
                                            string eventHubName,
                                            string consumerGroup,
                                            string ownerIdentifier) =>
            Logger.ClaimOwnershipComplete(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier);

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
        partial void ClaimOwnershipError(string partitionId,
                                         string fullyQualifiedNamespace,
                                         string eventHubName,
                                         string consumerGroup,
                                         string ownerIdentifier,
                                         Exception exception) =>
            Logger.ClaimOwnershipError(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier, exception.Message);

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
        partial void OwnershipNotClaimable(string partitionId,
                                           string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string ownerIdentifier,
                                           string message) =>
            Logger.OwnershipNotClaimable(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier, message);

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
        partial void OwnershipClaimed(string partitionId,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      string consumerGroup,
                                      string ownerIdentifier) =>
            Logger.OwnershipClaimed(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier);

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
        partial void ClaimOwnershipStart(string partitionId,
                                         string fullyQualifiedNamespace,
                                         string eventHubName,
                                         string consumerGroup,
                                         string ownerIdentifier) =>
            Logger.ClaimOwnershipStart(partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier);

        /// <summary>
        ///   Indicates that a <see cref="BlobsCheckpointStore" /> was created.
        /// </summary>
        ///
        /// <param name="typeName">The type name for the checkpoint store.</param>
        /// <param name="accountName">The Storage account name corresponding to the associated container client.</param>
        /// <param name="containerName">The name of the associated container client.</param>
        ///
        partial void BlobsCheckpointStoreCreated(string typeName,
                                                 string accountName,
                                                 string containerName) =>
            Logger.BlobsCheckpointStoreCreated(typeName, accountName, containerName);

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        ///
        partial void GetCheckpointStart(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup,
                                        string partitionId) =>
            Logger.GetCheckpointStart(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId);

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        ///
        partial void GetCheckpointComplete(string fullyQualifiedNamespace,
                                           string eventHubName,
                                           string consumerGroup,
                                           string partitionId) =>
            Logger.GetCheckpointComplete(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId);

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
        partial void GetCheckpointError(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        string consumerGroup,
                                        string partitionId,
                                        Exception exception) =>
            Logger.GetCheckpointError(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, exception.Message);
    }
}
