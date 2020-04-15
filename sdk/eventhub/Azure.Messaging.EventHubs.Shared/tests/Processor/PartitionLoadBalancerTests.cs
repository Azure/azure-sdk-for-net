// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Tests;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Primitives.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionLoadBalancer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionLoadBalancerTests
    {
        private const string FullyQualifiedNamespace = "fqns";
        private const string EventHubName = "name";
        private const string ConsumerGroup = "consumerGroup";

        /// <summary>
        ///   Verifies that partitions owned by a <see cref="PartitionLoadBalancer" /> are immediately available to be claimed by another loadbalancer
        ///   after StopAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task RelinquishOwnershipAsyncRelinquishesPartitionOwnershipOtherClientsConsiderThemClaimableImmediately()
        {
            const int NumberOfPartitions = 3;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer1 = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));
            var loadbalancer2 = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));

            // Ownership should start empty.

            var completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            Assert.That(completeOwnership.Count(), Is.EqualTo(0));

            // Start the load balancer so that it claims a random partition until none are left.

            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer1.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            // All partitions are owned by loadbalancer1.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(loadbalancer1.OwnerIdentifier)), Is.EqualTo(NumberOfPartitions));

            // Stopping the load balancer should relinquish all partition ownership.

            await loadbalancer1.RelinquishOwnershipAsync(CancellationToken.None);

            completeOwnership = await storageManager.ListOwnershipAsync(loadbalancer1.FullyQualifiedNamespace, loadbalancer1.EventHubName, loadbalancer1.ConsumerGroup);

            // No partitions are owned by loadbalancer1.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(loadbalancer1.OwnerIdentifier)), Is.EqualTo(0));

            // Start loadbalancer2 so that the load balancer claims a random partition until none are left.
            // All partitions should be immediately claimable even though they were just claimed by the loadbalancer1.

            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer2.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            completeOwnership = await storageManager.ListOwnershipAsync(loadbalancer1.FullyQualifiedNamespace, loadbalancer1.EventHubName, loadbalancer1.ConsumerGroup);

            // All partitions are owned by loadbalancer2.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(loadbalancer2.OwnerIdentifier)), Is.EqualTo(NumberOfPartitions));
        }

        /// <summary>
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncClaimsAllClaimablePartitions()
        {
            const int NumberOfPartitions = 3;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));

            // Ownership should start empty.

            var completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            Assert.That(completeOwnership.Count(), Is.EqualTo(0));

            // Start the load balancer so that it claims a random partition until none are left.

            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            // All partitions are owned by load balancer.

            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions));
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct a <see cref="PartitionLoadBalancer" /> to claim ownership of a claimable partition
        ///   when it owns exactly the calculated MinimumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncClaimsPartitionsWhenOwnedEqualsMinimumOwnedPartitionsCount()
        {
            const int MinimumpartitionCount = 4;
            const int NumberOfPartitions = 13;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));

            // Create partitions owned by this load balancer.

            var loadbalancer1PartitionIds = Enumerable.Range(1, MinimumpartitionCount);
            var completeOwnership = CreatePartitionOwnership(loadbalancer1PartitionIds.Select(i => i.ToString()), loadbalancer.OwnerIdentifier);

            // Create partitions owned by a different load balancer.

            var loadbalancer2Id = Guid.NewGuid().ToString();
            var loadbalancer2PartitionIds = Enumerable.Range(loadbalancer1PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(loadbalancer2PartitionIds.Select(i => i.ToString()), loadbalancer2Id));

            // Create partitions owned by a different load balancer.

            var loadbalancer3Id = Guid.NewGuid().ToString();
            var loadbalancer3PartitionIds = Enumerable.Range(loadbalancer2PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(loadbalancer3PartitionIds.Select(i => i.ToString()), loadbalancer3Id));

            // Seed the storageManager with all partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);

            var claimablePartitionIds = partitionIds.Except(completeOwnership.Select(p => p.PartitionId));

            // Get owned partitions.

            var totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            var ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByloadbalancer1.Count(), Is.EqualTo(MinimumpartitionCount));
            Assert.That(ownedByloadbalancer1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)), Is.False);

            // Start the load balancer to claim ownership from of a Partition even though ownedPartitionCount == MinimumOwnedPartitionsCount.

            await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);

            // Get owned partitions.

            totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByloadbalancer1.Count(), Is.GreaterThan(MinimumpartitionCount));
            Assert.That(ownedByloadbalancer1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)), Is.True);
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct a <see cref="PartitionLoadBalancer" /> steal ownership of a partition
        ///   from another <see cref="PartitionLoadBalancer" /> the other load balancer owns greater than the calculated MaximumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncStealsPartitionsWhenThisLoadbalancerOwnsMinPartitionsAndOtherLoadbalancerOwnsGreatherThanMaxPartitions()
        {
            const int MinimumpartitionCount = 4;
            const int MaximumpartitionCount = 5;
            const int NumberOfPartitions = 14;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));

            // Create partitions owned by this load balancer.

            var loadbalancer1PartitionIds = Enumerable.Range(1, MinimumpartitionCount);
            var completeOwnership = CreatePartitionOwnership(loadbalancer1PartitionIds.Select(i => i.ToString()), loadbalancer.OwnerIdentifier);

            // Create partitions owned by a different load balancer.

            var loadbalancer2Id = Guid.NewGuid().ToString();
            var loadbalancer2PartitionIds = Enumerable.Range(loadbalancer1PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(loadbalancer2PartitionIds.Select(i => i.ToString()), loadbalancer2Id));

            // Create partitions owned by a different load balancer above the MaximumPartitionCount.

            var loadbalancer3Id = Guid.NewGuid().ToString();
            var stealablePartitionIds = Enumerable.Range(loadbalancer2PartitionIds.Max() + 1, MaximumpartitionCount + 1);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(stealablePartitionIds.Select(i => i.ToString()), loadbalancer3Id));

            // Seed the storageManager with the owned partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);

            // Get owned partitions.

            var totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            var ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);
            var ownedByloadbalancer3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer3Id);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByloadbalancer1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.False);

            // Verify load balancer 3 has stealable partitions.

            Assert.That(ownedByloadbalancer3.Count(), Is.GreaterThan(MaximumpartitionCount));

            // Start the load balancer to steal ownership from of a when ownedPartitionCount == MinimumOwnedPartitionsCount but a loadbalancer owns > MaximumPartitionCount.

            await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);

            // Get owned partitions.

            totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);
            ownedByloadbalancer3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer3Id);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByloadbalancer1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.True);

            // Verify load balancer 3 now does not own > MaximumPartitionCount.

            Assert.That(ownedByloadbalancer3.Count(), Is.EqualTo(MaximumpartitionCount));
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct a <see cref="PartitionLoadBalancer" /> steal ownership of a partition
        ///   from another <see cref="PartitionLoadBalancer" /> the other load balancer owns exactly the calculated MaximumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncStealsPartitionsWhenThisLoadbalancerOwnsLessThanMinPartitionsAndOtherLoadbalancerOwnsMaxPartitions()
        {
            const int MinimumpartitionCount = 4;
            const int MaximumpartitionCount = 5;
            const int NumberOfPartitions = 12;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));

            // Create more partitions owned by this load balancer.

            var loadbalancer1PartitionIds = Enumerable.Range(1, MinimumpartitionCount - 1);
            var completeOwnership = CreatePartitionOwnership(loadbalancer1PartitionIds.Select(i => i.ToString()), loadbalancer.OwnerIdentifier);

            // Create more partitions owned by a different load balancer.

            var loadbalancer2Id = Guid.NewGuid().ToString();
            var loadbalancer2PartitionIds = Enumerable.Range(loadbalancer1PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(loadbalancer2PartitionIds.Select(i => i.ToString()), loadbalancer2Id));

            // Create more partitions owned by a different load balancer above the MaximumPartitionCount.

            var loadbalancer3Id = Guid.NewGuid().ToString();
            var stealablePartitionIds = Enumerable.Range(loadbalancer2PartitionIds.Max() + 1, MaximumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(stealablePartitionIds.Select(i => i.ToString()), loadbalancer3Id));

            // Seed the storageManager with the owned partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);

            // Get owned partitions.

            var totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            var ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);
            var ownedByloadbalancer3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer3Id);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByloadbalancer1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.False);

            // Verify load balancer 3 has stealable partitions.

            Assert.That(ownedByloadbalancer3.Count(), Is.EqualTo(MaximumpartitionCount));

            // Start the load balancer to steal ownership from of a when ownedPartitionCount == MinimumOwnedPartitionsCount but a load balancer owns > MaximumPartitionCount.

            await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);

            // Get owned partitions.

            totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);
            ownedByloadbalancer3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer3Id);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByloadbalancer1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.True);

            // Verify load balancer 3 now does not own > MaximumPartitionCount.

            Assert.That(ownedByloadbalancer3.Count(), Is.LessThan(MaximumpartitionCount));
        }

        /// <summary>
        ///   Verify logs for the <see cref="PartitionLoadBalancer" />.
        /// </summary>
        ///
        [Test]
        public async Task VerifiesEventProcessorLogs()
        {
            const int NumberOfPartitions = 4;
            const int MinimumpartitionCount = NumberOfPartitions / 2;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1));

            // Create more partitions owned by a different load balancer.

            var loadbalancer2Id = Guid.NewGuid().ToString();
            var completeOwnership = CreatePartitionOwnership(partitionIds.Skip(1), loadbalancer2Id);

            // Seed the storageManager with the owned partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);

            var mockLog = new Mock<PartitionLoadBalancerEventSource>();
            loadbalancer.Logger = mockLog.Object;

            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            await loadbalancer.RelinquishOwnershipAsync(CancellationToken.None);

            mockLog.Verify(m => m.RenewOwnershipStart(loadbalancer.OwnerIdentifier));
            mockLog.Verify(m => m.RenewOwnershipComplete(loadbalancer.OwnerIdentifier));
            mockLog.Verify(m => m.ClaimOwnershipStart(It.Is<string>(p => partitionIds.Contains(p))));
            mockLog.Verify(m => m.MinimumPartitionsPerEventProcessor(MinimumpartitionCount));
            mockLog.Verify(m => m.CurrentOwnershipCount(MinimumpartitionCount, loadbalancer.OwnerIdentifier));
            mockLog.Verify(m => m.StealPartition(loadbalancer.OwnerIdentifier));
            mockLog.Verify(m => m.ShouldStealPartition(loadbalancer.OwnerIdentifier));
            mockLog.Verify(m => m.UnclaimedPartitions(It.Is<HashSet<string>>(p => p.Overlaps(partitionIds))));
        }

        /// <summary>
        ///   Creates a collection of <see cref="PartitionOwnership" /> based on the specified arguments.
        /// </summary>
        ///
        /// <param name="partitionIds">A collection of partition identifiers that the collection will be associated with.</param>
        /// <param name="identifier">The owner identifier of the EventProcessorClient owning the collection.</param>
        ///
        /// <returns>A collection of <see cref="PartitionOwnership" />.</returns>
        ///
        private IEnumerable<EventProcessorPartitionOwnership> CreatePartitionOwnership(IEnumerable<string> partitionIds,
                                                                                       string identifier)
        {
            return partitionIds
                .Select(partitionId =>
                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = FullyQualifiedNamespace,
                        EventHubName = EventHubName,
                        ConsumerGroup = ConsumerGroup,
                        OwnerIdentifier = identifier,
                        PartitionId = partitionId,
                        LastModifiedTime = DateTimeOffset.UtcNow,
                        Version = Guid.NewGuid().ToString()
                    }).ToList();
        }
    }
}
