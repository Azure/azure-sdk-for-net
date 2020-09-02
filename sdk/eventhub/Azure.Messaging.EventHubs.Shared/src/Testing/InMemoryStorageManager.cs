// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The EventProcessor relies on a <see cref="StorageManager" /> to store checkpoints and handle partition
    ///   ownership.  <see cref="MockCheckPointStorage"/> is simple storage manager that stores checkpoints and
    ///   partition ownership in memory of your program.
    ///
    ///   You can use the <see cref="MockCheckPointStorage"/> to get started with using the `EventProcessor`.
    ///   But in production, you should choose an implementation of the <see cref="StorageManager" /> interface that will
    ///   store the checkpoints and partition ownership to a persistent store instead.
    /// </summary>
    ///
    internal class InMemoryStorageManager : StorageManager
    {
        /// <summary>The primitive for synchronizing access during ownership update.</summary>
        private readonly object _ownershipLock = new object();

        /// <summary>The primitive for synchronizing access during checkpoint update.</summary>
        private readonly object _checkpointLock = new object();

        /// <summary>Logs activities performed by this storage manager.</summary>
        private readonly Action<string> _logger;

        /// <summary>
        ///   The set of checkpoints held for this instance.
        /// </summary>
        ///
        public Dictionary<(string, string, string, string), CheckpointData> Checkpoints { get; }

        /// <summary>
        ///   The set of stored ownership.
        /// </summary>
        ///
        public Dictionary<(string, string, string, string), EventProcessorPartitionOwnership> Ownership { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MockCheckPointStorage"/> class.
        /// </summary>
        ///
        public InMemoryStorageManager() : this(null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MockCheckPointStorage"/> class.
        /// </summary>
        ///
        /// <param name="logger">Logs activities performed by this storage manager.</param>
        ///
        public InMemoryStorageManager(Action<string> logger = null)
        {
            _logger = logger;

            Ownership = new Dictionary<(string, string, string, string), EventProcessorPartitionOwnership>();
            Checkpoints = new Dictionary<(string, string, string, string), CheckpointData>();
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the in-memory storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  Not supported.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                               string eventHubName,
                                                                                               string consumerGroup,
                                                                                               CancellationToken cancellationToken = default)
        {
            List<EventProcessorPartitionOwnership> ownershipList;

            lock (_ownershipLock)
            {
                ownershipList = Ownership.Values
                    .Where(ownership => ownership.FullyQualifiedNamespace == fullyQualifiedNamespace
                        && ownership.EventHubName == eventHubName
                        && ownership.ConsumerGroup == consumerGroup)
                    .ToList();
            }

            return Task.FromResult((IEnumerable<EventProcessorPartitionOwnership>)ownershipList);
        }

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  Not supported.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership.</returns>
        ///
        public override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> partitionOwnership,
                                                                                                CancellationToken cancellationToken = default)
        {
            var claimedOwnership = new List<EventProcessorPartitionOwnership>();

            // The following lock makes sure two different event processors won't try to claim ownership of a partition
            // simultaneously.  This approach prevents an ownership from being stolen just after being claimed.

            lock (_ownershipLock)
            {
                foreach (EventProcessorPartitionOwnership ownership in partitionOwnership)
                {
                    var isClaimable = true;
                    var key = (ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.PartitionId);

                    // In case the partition already has an owner, the versions must match in order to claim it.

                    if (Ownership.TryGetValue(key, out EventProcessorPartitionOwnership currentOwnership))
                    {
                        isClaimable = string.Equals(ownership.Version, currentOwnership.Version, StringComparison.InvariantCultureIgnoreCase);
                    }

                    if (isClaimable)
                    {
                        ownership.Version = Guid.NewGuid().ToString();

                        Ownership[key] = ownership;
                        claimedOwnership.Add(ownership);

                        Log($"Ownership with partition id = '{ownership.PartitionId}' claimed by OwnershipIdentifier = '{ownership.OwnerIdentifier}'.");
                    }
                    else
                    {
                        Log($"Ownership with partition id = '{ownership.PartitionId}' is not claimable by OwnershipIdentifier = '{ownership.OwnerIdentifier}'.");
                    }
                }
            }

            return Task.FromResult((IEnumerable<EventProcessorPartitionOwnership>)claimedOwnership);
        }

        /// <summary>
        ///   Retrieves a complete checkpoint list from the in-memory storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  Not supported.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                                         string eventHubName,
                                                                                         string consumerGroup,
                                                                                         CancellationToken cancellationToken = default)
        {
            List<EventProcessorCheckpoint> checkpointList;

            EventProcessorCheckpoint TransformCheckpointData(CheckpointData data) =>
                new EventProcessorCheckpoint
                {
                    FullyQualifiedNamespace = data.Checkpoint.FullyQualifiedNamespace,
                    EventHubName = data.Checkpoint.EventHubName,
                    ConsumerGroup = data.Checkpoint.ConsumerGroup,
                    PartitionId = data.Checkpoint.PartitionId,
                    StartingPosition = EventPosition.FromOffset(data.Event.Offset, false)
                };

            lock (_checkpointLock)
            {
                checkpointList = Checkpoints.Values
                    .Where(data => data.Checkpoint.FullyQualifiedNamespace == fullyQualifiedNamespace
                        && data.Checkpoint.EventHubName == eventHubName
                        && data.Checkpoint.ConsumerGroup == consumerGroup)
                    .Select(data => TransformCheckpointData(data))
                    .ToList();
            }

            return Task.FromResult((IEnumerable<EventProcessorCheckpoint>)checkpointList);
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the in-memory storage service.
        /// </summary>
        ///
        /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
        /// <param name="eventData">The event to use as the basis for the checkpoint's starting position.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  Not supported.</param>
        ///
        public override Task UpdateCheckpointAsync(EventProcessorCheckpoint checkpoint,
                                                   EventData eventData,
                                                   CancellationToken cancellationToken = default)
        {
            lock (_checkpointLock)
            {
                var key = (checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId);
                Checkpoints[key] = new CheckpointData(checkpoint, eventData);

                Log($"Checkpoint with partition id = '{checkpoint.PartitionId}' updated successfully.");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///   Sends a log message to the current logger, if provided by the user.
        /// </summary>
        ///
        /// <param name="message">The log message to send.</param>
        ///
        private void Log(string message) => _logger?.Invoke(message);

        /// <summary>
        ///   Serves as a lightweight wrapper for the components that comprise the data
        ///   observed for a checkpoint.
        /// </summary>
        ///
        public struct CheckpointData
        {
            public EventProcessorCheckpoint Checkpoint { get; }
            public EventData Event { get; }

            public CheckpointData(EventProcessorCheckpoint checkpoint,
                                  EventData eventData)
            {
                Checkpoint = checkpoint;
                Event = eventData;
            }
        }
    }
}
