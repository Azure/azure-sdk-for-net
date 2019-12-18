// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;

namespace Azure.Messaging.EventHubs.Processor
{
    internal class PartitionLoadBalancer
    {
        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private readonly PartitionManager StorageManager;

        /// <summary>
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys.
        /// </summary>
        ///
        private Dictionary<string, PartitionOwnership> InstanceOwnership { get; set; } = new Dictionary<string, PartitionOwnership>();

        /// <summary>
        ///   A partition distribution dictionary, mapping an owner's identifier to the amount of partitions it owns and its list of partitions.
        /// </summary>
        ///
        private readonly Dictionary<string, List<PartitionOwnership>> ActiveOwnershipWithDistribution = new Dictionary<string, List<PartitionOwnership>>();

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        internal readonly string FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        internal readonly string EventHubName;

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        internal readonly string ConsumerGroup;

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        internal readonly string Identifier;

        /// <summary>
        ///   The minimum amount of time for an ownership to be considered expired without further updates.
        /// </summary>
        ///
        private TimeSpan OwnershipExpiration;

        public IEnumerable<string> OwnedPartitionIds => InstanceOwnership.Keys;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionLoadBalancer"/> class.
        /// </summary>
        ///
        public PartitionLoadBalancer(PartitionManager storageManager,
                                      string identifier,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      TimeSpan ownershipExpiration)
        {
            Argument.AssertNotNull(storageManager, nameof(storageManager));
            Argument.AssertNotNullOrEmpty(identifier, nameof(identifier));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));

            StorageManager = storageManager;
            Identifier = identifier;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnershipExpiration = ownershipExpiration;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionLoadBalancer"/> class.
        /// </summary>
        ///
        protected PartitionLoadBalancer()
        {
        }

        /// <summary>
        ///   Performs load balancing between multiple <see cref="EventProcessorClient" /> instances, claiming others' partitions to enforce
        ///   a more equal distribution when necessary.  It also manages its own partition processing tasks and ownership.
        /// </summary>
        ///
        /// <param name="partitionIds"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual async ValueTask<PartitionOwnership> RunAsync(string[] partitionIds, CancellationToken cancellationToken)
        {
            // Renew this instance's ownership so they don't expire.

            await RenewOwnershipAsync(cancellationToken).ConfigureAwait(false);

            // From the storage service, obtain a complete list of ownership, including expired ones.  We may still need
            // their eTags to claim orphan partitions.

            var completeOwnershipList = default(IEnumerable<PartitionOwnership>);

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
                // without an updated ownership list.

                throw new EventHubsException(true, EventHubName, Resources.OperationListOwnership, ex);
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

            ActiveOwnershipWithDistribution.Clear();
            ActiveOwnershipWithDistribution[Identifier] = new List<PartitionOwnership>();

            foreach (PartitionOwnership ownership in completeOwnershipList)
            {
                if (utcNow.Subtract(ownership.LastModifiedTime.Value) < OwnershipExpiration && !string.IsNullOrWhiteSpace(ownership.OwnerIdentifier))
                {
                    if (ActiveOwnershipWithDistribution.ContainsKey(ownership.OwnerIdentifier))
                    {
                        ActiveOwnershipWithDistribution[ownership.OwnerIdentifier].Add(ownership);
                    }
                    else
                    {
                        ActiveOwnershipWithDistribution[ownership.OwnerIdentifier] = new List<PartitionOwnership> { ownership };
                    }

                    unclaimedPartitions.Remove(ownership.PartitionId);
                }
            }

            // Find an ownership to claim and try to claim it.  The method will return null if this instance was not eligible to
            // increase its ownership list, if no claimable ownership could be found or if a claim attempt has failed.

            var claimedOwnership = await FindAndClaimOwnershipAsync(completeOwnershipList, unclaimedPartitions, partitionIds.Length, cancellationToken).ConfigureAwait(false);

            if (claimedOwnership != null)
            {
                InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;
            }

            return claimedOwnership;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            await RelinquishOwnershipAsync(cancellationToken);

            InstanceOwnership.Clear();
        }

        /// <summary>
        ///   Finds and tries to claim an ownership if this processor instance is eligible to increase its ownership list.
        /// </summary>
        ///
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the storage service.</param>
        /// <param name="unclaimedPartitions">The set of partitionIds that are currently unclaimed.</param>
        /// <param name="partitionCount">The count of partitions.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if this instance is not eligible, if no claimable ownership was found or if the claim attempt failed.</returns>
        ///
        private ValueTask<PartitionOwnership> FindAndClaimOwnershipAsync(IEnumerable<PartitionOwnership> completeOwnershipEnumerable,
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
            var ownedPartitionsCount = ActiveOwnershipWithDistribution[Identifier].Count;

            // There are two possible situations in which we may need to claim a partition ownership.
            //
            // The first one is when we are below the minimum amount of owned partitions.  There's nothing more to check, as we need to claim more
            // partitions to enforce balancing.
            //
            // The second case is a bit tricky.  Sometimes the claim must be performed by an event processor that already has reached the minimum
            // amount of ownership.  This may happen, for instance, when we have 13 partitions and 3 processors, each of them owning 4 partitions.
            // The minimum amount of partitions per processor is, in fact, 4, but in this example we still have 1 orphan partition to claim.  To
            // avoid overlooking this kind of situation, we may want to claim an ownership when we have exactly the minimum amount of ownership,
            // but we are making sure there are no better candidates among the other event processors.

            if (ownedPartitionsCount < minimumOwnedPartitionsCount
                || (ownedPartitionsCount == minimumOwnedPartitionsCount && !ActiveOwnershipWithDistribution.Values.Any(partitions => partitions.Count < minimumOwnedPartitionsCount)))
            {
                // Look for unclaimed partitions.  If any, randomly pick one of them to claim.

                if (unclaimedPartitions.Count > 0)
                {
                    var index = RandomNumberGenerator.Value.Next(unclaimedPartitions.Count);
                    var returnTask = ClaimOwnershipAsync(unclaimedPartitions.ElementAt(index), completeOwnershipEnumerable, cancellationToken);

                    return new ValueTask<PartitionOwnership>(returnTask);
                }

                // Only try to steal partitions if there are no unclaimed partitions left.  At first, only processors that have exceeded the
                // maximum owned partition count should be targeted.

                var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                var partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount = new List<string>();
                var partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount = new List<string>();

                // Build a list of partitions owned by processors owning exactly maximumOwnedPartitionsCount partitions
                // and a list of partitions owned by processors owning more than maximumOwnedPartitionsCount partitions.
                // Ignore the partitions already owned by this processor even though the current processor should never meet either criteria.

                foreach (var key in ActiveOwnershipWithDistribution.Keys)
                {
                    var ownedPartitions = ActiveOwnershipWithDistribution[key];

                    if (ownedPartitions.Count < maximumOwnedPartitionsCount || key == Identifier)
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

                    var index = RandomNumberGenerator.Value.Next(partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount.Count);

                    var returnTask = ClaimOwnershipAsync(
                        partitionsOwnedByProcessorWithGreaterThanMaximumOwnedPartitionsCount[index],
                        completeOwnershipEnumerable,
                        cancellationToken);

                    return new ValueTask<PartitionOwnership>(returnTask);
                }
                else if (ownedPartitionsCount < minimumOwnedPartitionsCount)
                {
                    // If any stealable partitions were found, randomly pick one of them to claim.

                    var index = RandomNumberGenerator.Value.Next(partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount.Count);

                    var returnTask = ClaimOwnershipAsync(
                        partitionsOwnedByProcessorWithExactlyMaximumOwnedPartitionsCount[index],
                        completeOwnershipEnumerable,
                        cancellationToken);

                    return new ValueTask<PartitionOwnership>(returnTask);
                }
            }

            // No ownership has been claimed.

            return new ValueTask<PartitionOwnership>(default(PartitionOwnership));
        }


        /// <summary>
        ///   Renews this instance's ownership so they don't expire.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RenewOwnershipAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            IEnumerable<PartitionOwnership> ownershipToRenew = InstanceOwnership.Values
                .Select(ownership => new PartitionOwnership
                (
                    ownership.FullyQualifiedNamespace,
                    ownership.EventHubName,
                    ownership.ConsumerGroup,
                    ownership.OwnerIdentifier,
                    ownership.PartitionId,
                    DateTimeOffset.UtcNow,
                    ownership.ETag
                ));

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

                throw new EventHubsException(true, EventHubName, Resources.OperationRenewOwnership, ex);
            }
        }

        /// <summary>
        ///   Tries to claim ownership of the specified partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the ownership is associated with.</param>
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if the claim attempt failed.</returns>
        ///
        private async Task<PartitionOwnership> ClaimOwnershipAsync(string partitionId,
                                                                   IEnumerable<PartitionOwnership> completeOwnershipEnumerable,
                                                                   CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // We need the eTag from the most recent ownership of this partition, even if it's expired.  We want to keep the offset and
            // the sequence number as well.

            var oldOwnership = completeOwnershipEnumerable.FirstOrDefault(ownership => ownership.PartitionId == partitionId);

            var newOwnership = new PartitionOwnership
            (
                FullyQualifiedNamespace,
                EventHubName,
                ConsumerGroup,
                Identifier,
                partitionId,
                DateTimeOffset.UtcNow,
                oldOwnership?.ETag
            );

            var claimedOwnership = default(IEnumerable<PartitionOwnership>);

            try
            {
                claimedOwnership = await StorageManager.ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If ownership claim fails, just treat it as a usual ownership claim failure.

                throw new EventHubsException(true, EventHubName, Resources.OperationClaimOwnership, ex);
            }

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            return claimedOwnership.FirstOrDefault();
        }

        /// <summary>
        ///   Relinquishes this instance's ownership so they can be claimed by other processors.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private Task RelinquishOwnershipAsync(CancellationToken cancellationToken)
        {
            IEnumerable<PartitionOwnership> ownershipToRelinquish = InstanceOwnership.Values
                .Select(ownership => new PartitionOwnership
                (
                    ownership.FullyQualifiedNamespace,
                    ownership.EventHubName,
                    ownership.ConsumerGroup,
                    string.Empty, //set ownership to Empty so that it is treated as availble to claim
                    ownership.PartitionId,
                    ownership.LastModifiedTime,
                    ownership.ETag
                ));

            return StorageManager.ClaimOwnershipAsync(ownershipToRelinquish, cancellationToken);
        }
    }
}