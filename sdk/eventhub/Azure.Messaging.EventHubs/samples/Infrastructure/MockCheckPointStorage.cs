// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Samples.Infrastructure
{
    /// <summary>
    ///   The EventProcessor relies on a <see cref="PartitionManager" /> to store checkpoints and handle partition
    ///   ownership.  <see cref="MockCheckPointStorage"/> is simple partition manager that stores checkpoints and
    ///   partition ownership in memory of your program.
    ///
    ///   You can use the <see cref="MockCheckPointStorage"/> to get started with using the `EventProcessor`.
    ///   But in production, you should choose an implementation of the <see cref="PartitionManager" /> interface that will
    ///   store the checkpoints and partition ownership to a persistent store instead.
    /// </summary>
    ///
    public sealed class MockCheckPointStorage : PartitionManager
    {
        /// <summary>The primitive for synchronizing access during ownership update.</summary>
        private readonly object _ownershipLock = new object();

        /// <summary>The set of stored ownership.</summary>
        private readonly Dictionary<(string, string, string, string), PartitionOwnership> _ownership;

        /// <summary>The primitive for synchronizing access during checkpoint update.</summary>
        private readonly object _checkpointLock = new object();

        /// <summary>The set of stored checkpoints.</summary>
        private readonly Dictionary<(string, string, string, string), Checkpoint> _checkpoints;

        /// <summary>Logs activities performed by this partition manager.</summary>
        private readonly Action<string> _logger;

        /// <summary>
        ///   Initializes a new instance of the <see cref="MockCheckPointStorage"/> class.
        /// </summary>
        ///
        /// <param name="logger">Logs activities performed by this partition manager.</param>
        ///
        public MockCheckPointStorage(Action<string> logger = null)
        {
            _logger = logger;

            _ownership = new Dictionary<(string, string, string, string), PartitionOwnership>();
            _checkpoints = new Dictionary<(string, string, string, string), Checkpoint>();
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the in-memory storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                 string eventHubName,
                                                                                 string consumerGroup)
        {
            List<PartitionOwnership> ownershipList;

            lock (_ownershipLock)
            {
                ownershipList = _ownership.Values
                    .Where(ownership => ownership.FullyQualifiedNamespace == fullyQualifiedNamespace
                        && ownership.EventHubName == eventHubName
                        && ownership.ConsumerGroup == consumerGroup)
                    .ToList();
            }

            return Task.FromResult((IEnumerable<PartitionOwnership>)ownershipList);
        }

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership.</returns>
        ///
        public override Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership)
        {
            var claimedOwnership = new List<PartitionOwnership>();

            // The following lock makes sure two different event processors won't try to claim ownership of a partition
            // simultaneously.  This approach prevents an ownership from being stolen just after being claimed.

            lock (_ownershipLock)
            {
                foreach (PartitionOwnership ownership in partitionOwnership)
                {
                    var isClaimable = true;
                    var key = (ownership.FullyQualifiedNamespace, ownership.EventHubName, ownership.ConsumerGroup, ownership.PartitionId);

                    // In case the partition already has an owner, the ETags must match in order to claim it.

                    if (_ownership.TryGetValue(key, out PartitionOwnership currentOwnership))
                    {
                        isClaimable = string.Equals(ownership.ETag, currentOwnership.ETag, StringComparison.InvariantCultureIgnoreCase);
                    }

                    if (isClaimable)
                    {
                        ownership.ETag = Guid.NewGuid().ToString();

                        _ownership[key] = ownership;
                        claimedOwnership.Add(ownership);

                        Log($"Ownership with partition id = '{ownership.PartitionId}' claimed.");
                    }
                    else
                    {
                        Log($"Ownership with partition id = '{ownership.PartitionId}' is not claimable.");
                    }
                }
            }

            return Task.FromResult((IEnumerable<PartitionOwnership>)claimedOwnership);
        }

        /// <summary>
        ///   Retrieves a complete checkpoint list from the in-memory storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override Task<IEnumerable<Checkpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                           string eventHubName,
                                                                           string consumerGroup)
        {
            List<Checkpoint> checkpointList;

            lock (_checkpointLock)
            {
                checkpointList = _checkpoints.Values
                    .Where(checkpoint => checkpoint.FullyQualifiedNamespace == fullyQualifiedNamespace
                        && checkpoint.EventHubName == eventHubName
                        && checkpoint.ConsumerGroup == consumerGroup)
                    .ToList();
            }

            return Task.FromResult((IEnumerable<Checkpoint>)checkpointList);
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the in-memory storage service.
        /// </summary>
        ///
        /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override Task UpdateCheckpointAsync(Checkpoint checkpoint)
        {
            lock (_checkpointLock)
            {
                var key = (checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId);
                _checkpoints[key] = checkpoint;

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
    }
}
