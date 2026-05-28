// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The EventProcessor relies on a <see cref="CheckpointStore" /> to store checkpoints and handle partition
    ///   ownership.  <see cref="InMemoryCheckpointStore"/> is simple storage manager that stores checkpoints and
    ///   partition ownership in memory of your program.
    ///
    ///   You can use the <see cref="InMemoryCheckpointStore"/> to get started with using the `EventProcessor`.
    ///   But in production, you should choose an implementation of the <see cref="CheckpointStore" /> interface that will
    ///   store the checkpoints and partition ownership to a persistent store instead.
    /// </summary>
    ///
    internal class InMemoryCheckpointStore : CheckpointStore
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
        public Dictionary<(string FullyQualifiedNamespace, string EventHubName, string ConsumerGroup, string PartitionId), CheckpointData> Checkpoints { get; }

        /// <summary>
        ///   The set of stored ownership.
        /// </summary>
        ///
        public Dictionary<(string FullyQualifiedNamespace, string EventHubName, string ConsumerGroup, string PartitionId), EventProcessorPartitionOwnership> Ownership { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MockCheckPointStorage"/> class.
        /// </summary>
        ///
        public InMemoryCheckpointStore() : this(null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MockCheckPointStorage"/> class.
        /// </summary>
        ///
        /// <param name="logger">Logs activities performed by this storage manager.</param>
        ///
        public InMemoryCheckpointStore(Action<string> logger = null)
        {
            _logger = logger;

            Ownership = new Dictionary<(string, string, string, string), EventProcessorPartitionOwnership>();
            Checkpoints = new Dictionary<(string, string, string, string), CheckpointData>();
        }

        /// <summary>
        ///   The value to set the ownership LastModifiedTime to.
        /// </summary>
        ///
        public DateTimeOffset LastModifiedTime { get; set; } = DateTimeOffset.Now;

        /// <summary>
        ///   The total lease renewals.
        /// </summary>
        ///
        public int TotalRenewals { get; set; }

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
                                                                                                CancellationToken cancellationToken = default)
        {
            var claimedOwnership = new List<EventProcessorPartitionOwnership>();

            // The following lock makes sure two different event processors won't try to claim ownership of a partition
            // simultaneously.  This approach prevents an ownership from being stolen just after being claimed.

            lock (_ownershipLock)
            {
                foreach (EventProcessorPartitionOwnership ownership in desiredOwnership)
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
                        ownership.LastModifiedTime = LastModifiedTime;
                        TotalRenewals++;
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
                                                                          CancellationToken cancellationToken = default)
        {
            EventProcessorCheckpoint checkpoint;

            EventProcessorCheckpoint TransformCheckpointData(CheckpointData data) =>
                new EventProcessorCheckpoint
                {
                    FullyQualifiedNamespace = data.FullyQualifiedNamespace,
                    EventHubName = data.EventHubName,
                    ConsumerGroup = data.ConsumerGroup,
                    PartitionId = data.PartitionId,
                    StartingPosition = EventPosition.FromSequenceNumber(data.StartingPosition.SequenceNumber, false),
                    ClientIdentifier = data.ClientIdentifier,
                    LastModified = (DateTimeOffset.TryParse(data.LastModified, out var lastModified) ? lastModified : default)
                };

            lock (_checkpointLock)
            {
                checkpoint = Checkpoints.Values
                    .Where(data => data.FullyQualifiedNamespace == fullyQualifiedNamespace
                        && data.EventHubName == eventHubName
                        && data.ConsumerGroup == consumerGroup
                        && data.PartitionId == partitionId)
                    .Select(data => TransformCheckpointData(data))
                    .SingleOrDefault();
            }

            return Task.FromResult(checkpoint);
        }

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
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
                                                   CancellationToken cancellationToken = default)
        {
            lock (_checkpointLock)
            {
                var key = (fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId);
                Checkpoints[key] = new CheckpointData(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, clientIdentifier, startingPosition, DateTimeOffset.Now.ToString());

                Log($"Checkpoint with partition id = '{partitionId}' updated successfully by {clientIdentifier}.");
            }

            return Task.CompletedTask;
        }

        public EventProcessorPartitionOwnership TryGetLatestOwnership(EventProcessorPartitionOwnership ownership)
        {
            var key = (ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.PartitionId);
            if (Ownership.TryGetValue(key, out ownership))
            {
                return ownership;
            }

            return null;
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
            public string FullyQualifiedNamespace { get; }
            public string EventHubName { get; }
            public string ConsumerGroup { get; }
            public string PartitionId { get; }
            public CheckpointPosition StartingPosition { get; }
            public string LastModified { get; }
            public string ClientIdentifier { get; }

            public CheckpointData(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  string consumerGroup,
                                  string partitionId,
                                  string clientIdentifier,
                                  CheckpointPosition startingPosition,
                                  string lastModified)
            {
               FullyQualifiedNamespace = fullyQualifiedNamespace;
               EventHubName = eventHubName;
               ConsumerGroup = consumerGroup;
               PartitionId = partitionId;
               StartingPosition = startingPosition;
               LastModified = lastModified;
               ClientIdentifier = clientIdentifier;
            }
        }
    }
}
