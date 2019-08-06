// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   A non-volatile in-memory storage service that keeps track of checkpoints and ownership.  It must
    ///   be used with a single <see cref="EventProcessor"/> instance.
    /// </summary>
    ///
    public class InMemoryPartitionManager : PartitionManager
    {
        /// <summary>The primitive for synchronizing access during ownership claim.</summary>
        private readonly object OwnershipClaimLock = new object();

        /// <summary>The set of stored checkpoints.  Partition ids are used as keys.</summary>
        private ConcurrentDictionary<string, Checkpoint> Checkpoints;

        /// <summary>The set of stored ownership.  Partition ids are used as keys.</summary>
        private Dictionary<string, PartitionOwnership> Ownership;

        /// <summary>Logs activities performed by this partition manager.</summary>
        private Action<string> Logger;

        /// <summary>
        ///   Initializes a new instance of the <see cref="InMemoryPartitionManager"/> class.
        /// </summary>
        ///
        /// <param name="logger">Logs activities performed by this partition manager.</param>
        ///
        public InMemoryPartitionManager(Action<string> logger = null)
        {
            Logger = logger;

            Checkpoints = new ConcurrentDictionary<string, Checkpoint>();
            Ownership = new Dictionary<string, PartitionOwnership>();
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the in-memory storage service.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        public override Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string eventHubName,
                                                                                 string consumerGroup)
        {
            List<PartitionOwnership> ownershipList;

            lock(OwnershipClaimLock)
            {
                ownershipList = Ownership.Values
                    .Where(ownership => ownership.EventHubName == eventHubName &&
                        ownership.ConsumerGroup == consumerGroup)
                    .ToList();
            }

            return Task.FromResult((IEnumerable<PartitionOwnership>)ownershipList);
        }

        /// <summary>
        ///   Tries to claim a list of specified ownership.
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

            lock (OwnershipClaimLock)
            {
                foreach (var ownership in partitionOwnership)
                {
                    var isClaimable = true;

                    // In case the partition already has an owner, the ETags must match in order to claim it.

                    if (Ownership.TryGetValue(ownership.PartitionId, out var currentOwnership))
                    {
                        isClaimable = ownership.ETag == currentOwnership.ETag;
                    }

                    if (isClaimable)
                    {
                        ownership.ETag = Guid.NewGuid().ToString();

                        Ownership[ownership.PartitionId] = ownership;
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
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the in-memory storage service.
        /// </summary>
        ///
        /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override Task UpdateCheckpointAsync(Checkpoint checkpoint)
        {
            Checkpoints[checkpoint.PartitionId] = checkpoint;

            Log($"Checkpoint with partition id = '{checkpoint.PartitionId}' updated.");

            return Task.CompletedTask;
        }

        /// <summary>
        ///   Sends a log message to the current logger, if provided by the user.
        /// </summary>
        ///
        /// <param name="message">The log message to send.</param>
        ///
        private void Log(string message) => Logger?.Invoke(message);
    }
}
