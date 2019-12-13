// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    internal class PartitionLoadBalancer
    {
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
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private PartitionManager StorageManager { get; }

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

                var errorEventArgs = new ProcessErrorEventArgs(null, Resources.OperationRenewOwnership, ex, cancellationToken);
                _ = OnProcessErrorAsync(errorEventArgs);

                return;
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

                var errorEventArgs = new ProcessErrorEventArgs(null, Resources.OperationClaimOwnership, ex, cancellationToken);
                _ = OnProcessErrorAsync(errorEventArgs);

                return default;
            }

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            return claimedOwnership.FirstOrDefault();
        }
    }
}