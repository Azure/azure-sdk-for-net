// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Handles all load balancing concerns for an event processor including claiming, stealing, and relinquishing ownership.
    /// </summary>
    ///
    internal class PartitionLoadBalancer
    {
        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>
        ///   Responsible for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private readonly StorageManager StorageManager;

        /// <summary>
        ///   A partition distribution dictionary, mapping an owner's identifier to the amount of partitions it owns and its list of partitions.
        /// </summary>
        ///
        private readonly Dictionary<string, List<EventProcessorPartitionOwnership>> ActiveOwnershipWithDistribution = new Dictionary<string, List<EventProcessorPartitionOwnership>>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this load balancer is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get;  }

        /// <summary>
        ///   The identifier of the EventProcessorClient that owns this load balancer.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   The minimum amount of time for an ownership to be considered expired without further updates.
        /// </summary>
        ///
        public TimeSpan OwnershipExpirationInterval { get; }

        /// <summary>
        ///   The minimum amount of time to be elapsed between two load balancing verifications.
        /// </summary>
        ///
        public TimeSpan LoadBalanceInterval { get; internal set; }

        /// <summary>
        ///   Indicates whether the load balancer believes itself to be in a balanced state
        ///   when considering its fair share of partitions and whether any partitions
        ///   remain unclaimed.
        /// </summary>
        ///
        public virtual bool IsBalanced { get; private set; }

        /// <summary>
        ///   The partitionIds currently owned by the associated event processor.
        /// </summary>
        ///
        public virtual IEnumerable<string> OwnedPartitionIds => InstanceOwnership.Keys;

        /// <summary>
        ///   The instance of <see cref="PartitionLoadBalancerEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal PartitionLoadBalancerEventSource Logger { get; set; } = PartitionLoadBalancerEventSource.Log;

        /// <summary>
        ///   The set of partition ownership the associated event processor owns.  Partition ids are used as keys.
        /// </summary>
        ///
        private Dictionary<string, EventProcessorPartitionOwnership> InstanceOwnership { get; set; } = new Dictionary<string, EventProcessorPartitionOwnership>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionLoadBalancer" /> class.
        /// </summary>
        ///
        /// <param name="storageManager">Responsible for creation of checkpoints and for ownership claim.</param>
        /// <param name="identifier">The identifier of the EventProcessorClient that owns this load balancer.</param>
        /// <param name="consumerGroup">The name of the consumer group this load balancer is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace that the processor is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="ownershipExpirationInterval">The minimum amount of time for an ownership to be considered expired without further updates.</param>
        /// <param name="loadBalancingInterval">The minimum amount of time to be elapsed between two load balancing verifications.</param>
        ///
        public PartitionLoadBalancer(StorageManager storageManager,
                                     string identifier,
                                     string consumerGroup,
                                     string fullyQualifiedNamespace,
                                     string eventHubName,
                                     TimeSpan ownershipExpirationInterval,
                                     TimeSpan loadBalancingInterval)
        {
            Argument.AssertNotNull(storageManager, nameof(storageManager));
            Argument.AssertNotNullOrEmpty(identifier, nameof(identifier));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));

            StorageManager = storageManager;
            OwnerIdentifier = identifier;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnershipExpirationInterval = ownershipExpirationInterval;
            LoadBalanceInterval = loadBalancingInterval;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionLoadBalancer" /> class.
        /// </summary>
        ///
        protected PartitionLoadBalancer()
        {
            // Because this constructor is used heavily in testing, initialize the
            // critical timing properties to their default option values.

            var options = new EventProcessorOptions();

            LoadBalanceInterval = options.LoadBalancingUpdateInterval;
            OwnershipExpirationInterval = options.PartitionOwnershipExpirationInterval;
        }

        /// <summary>
        ///   Performs load balancing between multiple EventProcessorClient instances, claiming others' partitions to enforce
        ///   a more equal distribution when necessary.  It also manages its own partition processing tasks and ownership.
        /// </summary>
        ///
        /// <param name="partitionIds">The set of partitionIds available for ownership balancing.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if this instance is not eligible, if no claimable ownership was found or if the claim attempt failed.</returns>
        ///
        public virtual async ValueTask<EventProcessorPartitionOwnership> RunLoadBalancingAsync(string[] partitionIds,
                                                                                               CancellationToken cancellationToken)
        {
            // Renew this instance's ownership so they don't expire.

            await RenewOwnershipAsync(cancellationToken).ConfigureAwait(false);

            // From the storage service, obtain a complete list of ownership, including expired ones.  We may still need
            // their eTags to claim orphan partitions.

            IEnumerable<EventProcessorPartitionOwnership> completeOwnershipList;

            try
            {
                completeOwnershipList = (await StorageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken)
                    .ConfigureAwait(false))
                    .ToList();
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If ownership list retrieval fails, give up on the current cycle.  There's nothing more we can do
                // without an updated ownership list.  Set the EventHubName to null so it doesn't modify the exception
                // message.  This exception message is used so the processor can retrieve the raw Operation string, and
                // adding the EventHubName would append unwanted info to it.

                throw new EventHubsException(true, null, Resources.OperationListOwnership, ex);
            }

            // There's no point in continuing the current cycle if we failed to fetch the completeOwnershipList.

            if (completeOwnershipList == default)
            {
                return default;
            }

            var unclaimedPartitions = new HashSet<string>(partitionIds);

            // Create a partition distribution dictionary from the complete ownership list we have, mapping an owner's identifier to the list of
            // partitions it owns.  When an event processor goes down and it has only expired ownership, it will not be taken into consideration
            // by others.  The expiration time defaults to 30 seconds, but it may be overridden by a derived class.

            var utcNow = DateTimeOffset.UtcNow;
            var activeOwnership = default(EventProcessorPartitionOwnership);

            ActiveOwnershipWithDistribution.Clear();
            ActiveOwnershipWithDistribution[OwnerIdentifier] = new List<EventProcessorPartitionOwnership>();

            foreach (EventProcessorPartitionOwnership ownership in completeOwnershipList)
            {
                if (utcNow.Subtract(ownership.LastModifiedTime) < OwnershipExpirationInterval && !string.IsNullOrEmpty(ownership.OwnerIdentifier))
                {
                    activeOwnership = ownership;

                    // If a processor crashes and restarts, then it is possible for it to own partitions that it is not currently
                    // tracking as owned.  Test for this case and ensure that ownership is tracked and extended.

                    if ((string.Equals(ownership.OwnerIdentifier, OwnerIdentifier, StringComparison.OrdinalIgnoreCase)) && (!InstanceOwnership.ContainsKey(ownership.PartitionId)))
                    {
                        (_, activeOwnership) = await ClaimOwnershipAsync(ownership.PartitionId, new[] { ownership }, cancellationToken).ConfigureAwait(false);

                        // If the claim failed, then the ownership period was not extended.  Since the original ownership had not
                        // yet expired prior to the claim attempt, consider the original to be the active ownership for this cycle.

                        if (activeOwnership == default)
                        {
                            activeOwnership = ownership;
                        }

                        InstanceOwnership[activeOwnership.PartitionId] = activeOwnership;
                    }

                    // Update active ownership and trim the unclaimed partitions.

                    if (ActiveOwnershipWithDistribution.ContainsKey(activeOwnership.OwnerIdentifier))
                    {
                        ActiveOwnershipWithDistribution[activeOwnership.OwnerIdentifier].Add(activeOwnership);
                    }
                    else
                    {
                        ActiveOwnershipWithDistribution[activeOwnership.OwnerIdentifier] = new List<EventProcessorPartitionOwnership> { activeOwnership };
                    }

                    unclaimedPartitions.Remove(activeOwnership.PartitionId);
                }
            }

            // Find an ownership to claim and try to claim it.  The method will return null if this instance was not eligible to
            // increase its ownership list, if no claimable ownership could be found or if a claim attempt has failed.

            var (claimAttempted, claimedOwnership) = await FindAndClaimOwnershipAsync(completeOwnershipList, unclaimedPartitions, partitionIds.Length, cancellationToken).ConfigureAwait(false);

            if (claimedOwnership != null)
            {
                InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;
            }

            // Update the balanced state.  Consider the load balanced if this processor has its minimum share of partitions and did not
            // attempt to claim a partition.

            var minimumDesiredPartitions = partitionIds.Length / ActiveOwnershipWithDistribution.Keys.Count;
            IsBalanced = ((InstanceOwnership.Count >= minimumDesiredPartitions) && (!claimAttempted));

            return claimedOwnership;
        }

        /// <summary>
        ///   Relinquishes this instance's ownership so they can be claimed by other processors and clears the OwnedPartitionIds.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        public virtual async Task RelinquishOwnershipAsync(CancellationToken cancellationToken)
        {
            IEnumerable<EventProcessorPartitionOwnership> ownershipToRelinquish = InstanceOwnership.Values
                .Select(ownership => new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = ownership.FullyQualifiedNamespace,
                    EventHubName = ownership.EventHubName,
                    ConsumerGroup = ownership.ConsumerGroup,
                    OwnerIdentifier = string.Empty, //set ownership to Empty so that it is treated as available to claim
                    PartitionId = ownership.PartitionId,
                    LastModifiedTime = ownership.LastModifiedTime,
                    Version = ownership.Version
                });

            await StorageManager.ClaimOwnershipAsync(ownershipToRelinquish, cancellationToken).ConfigureAwait(false);

            InstanceOwnership.Clear();
        }

        /// <summary>
        ///   Finds and tries to claim an ownership if this processor instance is eligible to increase its ownership list.
        /// </summary>
        ///
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the storage service.</param>
        /// <param name="unclaimedPartitions">The set of partitionIds that are currently unclaimed.</param>
        /// <param name="partitionCount">The count of partitions.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A tuple indicating whether a claim was attempted and any ownership that was claimed.  The claimed ownership will be <c>null</c> if no claim was attempted or if the claim attempt failed.</returns>
        ///
        private ValueTask<(bool wasClaimAttempted, EventProcessorPartitionOwnership claimedPartition)> FindAndClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> completeOwnershipEnumerable,
                                                                                                                                  HashSet<string> unclaimedPartitions,
                                                                                                                                  int partitionCount,
                                                                                                                                  CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // The minimum owned partitions count is the minimum amount of partitions every event processor needs to own when the distribution
            // is balanced.  If n = minimumOwnedPartitionsCount, a balanced distribution will only have processors that own n or n + 1 partitions
            // each.  We can guarantee the partition distribution has at least one key, which corresponds to this event processor instance, even
            // if it owns no partitions.

            var minimumOwnedPartitionsCount = partitionCount / ActiveOwnershipWithDistribution.Keys.Count;
            Logger.MinimumPartitionsPerEventProcessor(minimumOwnedPartitionsCount);

            var ownedPartitionsCount = ActiveOwnershipWithDistribution[OwnerIdentifier].Count;
            Logger.CurrentOwnershipCount(ownedPartitionsCount, OwnerIdentifier);

            // There are two possible situations in which we may need to claim a partition ownership:
            //
            //   - The first one is when we are below the minimum amount of owned partitions.  There's nothing more to check, as we need to claim more
            //     partitions to enforce balancing.
            //
            //   - The second case is a bit tricky.  Sometimes the claim must be performed by an event processor that already has reached the minimum
            //     amount of ownership.  This may happen, for instance, when we have 13 partitions and 3 processors, each of them owning 4 partitions.
            //     The minimum amount of partitions per processor is, in fact, 4, but in this example we still have 1 orphan partition to claim.  To
            //     avoid overlooking this kind of situation, we may want to claim an ownership when we have exactly the minimum amount of ownership,
            //     but we are making sure there are no better candidates among the other event processors.

            if (ownedPartitionsCount < minimumOwnedPartitionsCount
                || (ownedPartitionsCount == minimumOwnedPartitionsCount && !ActiveOwnershipWithDistribution.Values.Any(partitions => partitions.Count < minimumOwnedPartitionsCount)))
            {
                // Look for unclaimed partitions.  If any, randomly pick one of them to claim.

                Logger.UnclaimedPartitions(unclaimedPartitions);

                if (unclaimedPartitions.Count > 0)
                {
                    var index = RandomNumberGenerator.Value.Next(unclaimedPartitions.Count);
                    var returnTask = ClaimOwnershipAsync(unclaimedPartitions.ElementAt(index), completeOwnershipEnumerable, cancellationToken);

                    return new ValueTask<(bool, EventProcessorPartitionOwnership)>(returnTask);
                }

                // Only try to steal partitions if there are no unclaimed partitions left.  At first, only processors that have exceeded the
                // maximum owned partition count should be targeted.

                Logger.ShouldStealPartition(OwnerIdentifier);

                var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;
                var partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount = new List<string>();
                var partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount = new List<string>();

                // Build a list of partitions owned by processors owning exactly maximumOwnedPartitionsCount partitions
                // and a list of partitions owned by processors owning more than maximumOwnedPartitionsCount partitions.
                // Ignore the partitions already owned by this processor even though the current processor should never meet either criteria.

                foreach (var key in ActiveOwnershipWithDistribution.Keys)
                {
                    var ownedPartitions = ActiveOwnershipWithDistribution[key];

                    if (ownedPartitions.Count < maximumOwnedPartitionsCount || string.Equals(key, OwnerIdentifier, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skip if the common case is true.

                        continue;
                    }
                    if (ownedPartitions.Count == maximumOwnedPartitionsCount)
                    {
                        ownedPartitions
                            .ForEach(ownership => partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount.Add(ownership.PartitionId));
                    }
                    else
                    {
                        ownedPartitions
                            .ForEach(ownership => partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount.Add(ownership.PartitionId));
                    }
                }

                // Here's the important part.  If there are no processors that have exceeded the maximum owned partition count allowed, we may
                // need to steal from the processors that have exactly the maximum amount.  If this instance is below the minimum count, then
                // we have no choice as we need to enforce balancing.  Otherwise, leave it as it is because the distribution wouldn't change.

                if (partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount.Count > 0)
                {
                    // If any stealable partitions were found, randomly pick one of them to claim.

                    Logger.StealPartition(OwnerIdentifier);

                    var index = RandomNumberGenerator.Value.Next(partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount.Count);

                    var returnTask = ClaimOwnershipAsync(
                        partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount[index],
                        completeOwnershipEnumerable,
                        cancellationToken);

                    return new ValueTask<(bool, EventProcessorPartitionOwnership)>(returnTask);
                }
                else if (ownedPartitionsCount < minimumOwnedPartitionsCount)
                {
                    // If any stealable partitions were found, randomly pick one of them to claim.

                    Logger.StealPartition(OwnerIdentifier);

                    var index = RandomNumberGenerator.Value.Next(partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount.Count);

                    var returnTask = ClaimOwnershipAsync(
                        partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount[index],
                        completeOwnershipEnumerable,
                        cancellationToken);

                    return new ValueTask<(bool, EventProcessorPartitionOwnership)>(returnTask);
                }
            }

            // No ownership has been claimed.

            return new ValueTask<(bool, EventProcessorPartitionOwnership)>((false, default(EventProcessorPartitionOwnership)));
        }

        /// <summary>
        ///   Renews this instance's ownership so they don't expire.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RenewOwnershipAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.RenewOwnershipStart(OwnerIdentifier);

            IEnumerable<EventProcessorPartitionOwnership> ownershipToRenew = InstanceOwnership.Values
                .Select(ownership => new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = ownership.FullyQualifiedNamespace,
                    EventHubName = ownership.EventHubName,
                    ConsumerGroup = ownership.ConsumerGroup,
                    OwnerIdentifier = ownership.OwnerIdentifier,
                    PartitionId = ownership.PartitionId,
                    LastModifiedTime = DateTimeOffset.UtcNow,
                    Version = ownership.Version
                });

            try
            {
                // Dispose of all previous partition ownership instances and get a whole new dictionary.

                InstanceOwnership = (await StorageManager.ClaimOwnershipAsync(ownershipToRenew, cancellationToken)
                    .ConfigureAwait(false))
                    .ToDictionary(ownership => ownership.PartitionId);
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If ownership renewal fails just give up and try again in the next cycle.  The processor may
                // end up losing some of its ownership.

                Logger.RenewOwnershipError(OwnerIdentifier, ex.Message);

                // Set the EventHubName to null so it doesn't modify the exception message. This exception message is
                // used so the processor can retrieve the raw Operation string, and adding the EventHubName would append
                // unwanted info to it.

                throw new EventHubsException(true, null, Resources.OperationRenewOwnership, ex);
            }
            finally
            {
                Logger.RenewOwnershipComplete(OwnerIdentifier);
            }
        }

        /// <summary>
        ///   Tries to claim ownership of the specified partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the ownership is associated with.</param>
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A tuple indicating whether a claim was attempted and the claimed ownership. The claimed ownership will be <c>null</c> if the claim attempt failed.</returns>
        ///
        private async Task<(bool wasClaimAttempted, EventProcessorPartitionOwnership claimedPartition)> ClaimOwnershipAsync(string partitionId,
                                                                                                                            IEnumerable<EventProcessorPartitionOwnership> completeOwnershipEnumerable,
                                                                                                                            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            Logger.ClaimOwnershipStart(partitionId);

            // We need the eTag from the most recent ownership of this partition, even if it's expired.  We want to keep the offset and
            // the sequence number as well.

            var oldOwnership = completeOwnershipEnumerable.FirstOrDefault(ownership => ownership.PartitionId == partitionId);

            var newOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                OwnerIdentifier = OwnerIdentifier,
                PartitionId = partitionId,
                LastModifiedTime = DateTimeOffset.UtcNow,
                Version = oldOwnership?.Version
            };

            var claimedOwnership = default(IEnumerable<EventProcessorPartitionOwnership>);

            try
            {
                claimedOwnership = await StorageManager.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership> { newOwnership }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If ownership claim fails, just treat it as a usual ownership claim failure.

                Logger.ClaimOwnershipError(partitionId, ex.Message);

                // Set the EventHubName to null so it doesn't modify the exception message. This exception message is
                // used so the processor can retrieve the raw Operation string, and adding the EventHubName would append
                // unwanted info to it. This exception also communicates the PartitionId to the caller.

                var exception = new EventHubsException(true, null, Resources.OperationClaimOwnership, ex);
                exception.SetFailureOperation(exception.Message);
                exception.SetFailureData(partitionId);
                throw exception;
            }

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            return (true, claimedOwnership.FirstOrDefault());
        }
    }
}
