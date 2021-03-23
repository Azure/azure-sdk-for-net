// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
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
        ///   Verifies that partitions owned by a <see cref="PartitionLoadBalancer" /> are immediately available to be claimed by another load balancer
        ///   after StopAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task RelinquishOwnershipAsyncRelinquishesPartitionOwnershipOtherClientsConsiderThemClaimableImmediately()
        {
            const int NumberOfPartitions = 3;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer1 = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));
            var loadbalancer2 = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

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
            var loadbalancer = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

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
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task IsBalancedIsCorrectWithOneProcessor()
        {
            const int NumberOfPartitions = 3;

            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadBalancer = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

            // Ownership should start empty.

            var completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            Assert.That(completeOwnership.Count(), Is.EqualTo(0), "No partitions should be owned.");

            // Start the load balancer so that it claims a random partition until none are left.

            for (var index = 0; index < NumberOfPartitions; ++index)
            {
                await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
                Assert.That(loadBalancer.IsBalanced, Is.False, "The load balancer should not believe the state is balanced while partitions remain unclaimed.");
            }

            // The load balancer should not consider itself balanced until a cycle is run with no partitions claimed.  Run one additional
            // cycle to satisfy that condition.

            Assert.That(loadBalancer.IsBalanced, Is.False, "The load balancer should not believe the state is balanced until no partition is claimed during a cycle.");
            await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);

            // All partitions are owned by load balancer.

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions), "All partitions should be owned.");
            Assert.That(loadBalancer.IsBalanced, Is.True, "The load balancer should believe the state is balanced when it owns all partitions.");
        }

        /// <summary>
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task IsBalancedIsCorrectWithMultipleProcessorsAndAnEventDistribution()
        {
            const int MinimumPartitionCount = 4;
            const int NumberOfPartitions = 12;

            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadBalancer = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));
            var completeOwnership = Enumerable.Empty<EventProcessorPartitionOwnership>();

            // Create partitions owned by a different load balancer.

            var secondLoadBalancerId = Guid.NewGuid().ToString();
            var secondLoadBalancerPartitions = Enumerable.Range(1, MinimumPartitionCount);

            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(secondLoadBalancerPartitions.Select(i => i.ToString()), secondLoadBalancerId));

            // Create partitions owned by a different load balancer.

            var thirdLoadBalancerId = Guid.NewGuid().ToString();
            var thirdLoadBalancerPartitions = Enumerable.Range(secondLoadBalancerPartitions.Max() + 1, MinimumPartitionCount);

            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(thirdLoadBalancerPartitions.Select(i => i.ToString()), thirdLoadBalancerId));

            // Seed the storageManager with all partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);

            // Ensure that there is exactly the minimum number of partitions available to be owned.

            var unownedPartitions = partitionIds.Except(completeOwnership.Select(p => p.PartitionId));
            Assert.That(unownedPartitions.Count(), Is.EqualTo(MinimumPartitionCount), "There should be exactly the balanced share of partitions left unowned.");

            // Run load balancing cycles until the load balancer believes that the state is balanced or the minimum count is quadrupled.

            var cycleCount = 0;

            while ((!loadBalancer.IsBalanced) && (cycleCount < (MinimumPartitionCount * 4)))
            {
                await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
                ++cycleCount;
            }

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            unownedPartitions = partitionIds.Except(completeOwnership.Select(p => p.PartitionId));

            Assert.That(unownedPartitions.Count(), Is.EqualTo(0), "There no partitions left unowned.");
            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions), "All partitions should be owned.");
            Assert.That(loadBalancer.IsBalanced, Is.True, "The load balancer should believe the state is balanced when it owns the correct number of partitions.");
            Assert.That(cycleCount, Is.EqualTo(MinimumPartitionCount + 1), "The load balancer should have reached a balanced state once all partitions were owned and the next cycle claimed none.");
        }

        /// <summary>
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task IsBalancedIsCorrectWithMultipleProcessorsAndAnUnevenDistribution()
        {
            const int MinimumPartitionCount = 4;
            const int NumberOfPartitions = 13;

            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadBalancer = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));
            var completeOwnership = Enumerable.Empty<EventProcessorPartitionOwnership>();

            // Create partitions owned by a different load balancer.

            var secondLoadBalancerId = Guid.NewGuid().ToString();
            var secondLoadBalancerPartitions = Enumerable.Range(1, MinimumPartitionCount);

            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(secondLoadBalancerPartitions.Select(i => i.ToString()), secondLoadBalancerId));

            // Create partitions owned by a different load balancer.

            var thirdLoadBalancerId = Guid.NewGuid().ToString();
            var thirdLoadBalancerPartitions = Enumerable.Range(secondLoadBalancerPartitions.Max() + 1, MinimumPartitionCount);

            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(thirdLoadBalancerPartitions.Select(i => i.ToString()), thirdLoadBalancerId));

            // Seed the storageManager with all partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);

            // Ensure that there is exactly one more than the minimum number of partitions available to be owned.

            var unownedPartitions = partitionIds.Except(completeOwnership.Select(p => p.PartitionId));
            Assert.That(unownedPartitions.Count(), Is.EqualTo(MinimumPartitionCount + 1), $"There should be { MinimumPartitionCount + 1 } partitions left unowned.");

            // Run load balancing cycles until the load balancer believes that the state is balanced or the minimum count is quadrupled.

            var cycleCount = 0;

            while ((!loadBalancer.IsBalanced) && (cycleCount < (MinimumPartitionCount * 4)))
            {
                await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
                ++cycleCount;
            }

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            unownedPartitions = partitionIds.Except(completeOwnership.Select(p => p.PartitionId));

            Assert.That(unownedPartitions.Count(), Is.EqualTo(0), "There no partitions left unowned.");
            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions), "All partitions should be owned.");
            Assert.That(loadBalancer.IsBalanced, Is.True, "The load balancer should believe the state is balanced when it owns the correct number of partitions.");
            Assert.That(cycleCount, Is.EqualTo(MinimumPartitionCount + 2), "The load balancer should have reached a balanced state once all partitions were owned and the next cycle claimed none.");
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct a <see cref="PartitionLoadBalancer" /> to claim ownership of a claimable partition
        ///   when it owns exactly the calculated MinimumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncClaimsPartitionsWhenOwnedEqualsMinimumOwnedPartitionsCount()
        {
            const int MinimumPartitionCount = 4;
            const int NumberOfPartitions = 13;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadbalancer = new PartitionLoadBalancer(
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

            // Create partitions owned by this load balancer.

            var loadbalancer1PartitionIds = Enumerable.Range(1, MinimumPartitionCount);
            var completeOwnership = CreatePartitionOwnership(loadbalancer1PartitionIds.Select(i => i.ToString()), loadbalancer.OwnerIdentifier);

            // Create partitions owned by a different load balancer.

            var loadbalancer2Id = Guid.NewGuid().ToString();
            var loadbalancer2PartitionIds = Enumerable.Range(loadbalancer1PartitionIds.Max() + 1, MinimumPartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(loadbalancer2PartitionIds.Select(i => i.ToString()), loadbalancer2Id));

            // Create partitions owned by a different load balancer.

            var loadbalancer3Id = Guid.NewGuid().ToString();
            var loadbalancer3PartitionIds = Enumerable.Range(loadbalancer2PartitionIds.Max() + 1, MinimumPartitionCount);
            completeOwnership = completeOwnership
                .Concat(CreatePartitionOwnership(loadbalancer3PartitionIds.Select(i => i.ToString()), loadbalancer3Id));

            // Seed the storageManager with all partitions.

            await storageManager.ClaimOwnershipAsync(completeOwnership);
            var claimablePartitionIds = partitionIds.Except(completeOwnership.Select(p => p.PartitionId));

            // Get owned partitions.

            var totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            var ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByloadbalancer1.Count(), Is.EqualTo(MinimumPartitionCount));
            Assert.That(ownedByloadbalancer1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)), Is.False);

            // Start the load balancer to claim ownership from of a Partition even though ownedPartitionCount == MinimumOwnedPartitionsCount.

            await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);

            // Get owned partitions.

            totalOwnedPartitions = await storageManager.ListOwnershipAsync(loadbalancer.FullyQualifiedNamespace, loadbalancer.EventHubName, loadbalancer.ConsumerGroup);
            ownedByloadbalancer1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == loadbalancer.OwnerIdentifier);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByloadbalancer1.Count(), Is.GreaterThan(MinimumPartitionCount));
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
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

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

            // Start the load balancer to steal ownership from of a when ownedPartitionCount == MinimumOwnedPartitionsCount but a load balancer owns > MaximumPartitionCount.

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
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

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
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncReclaimsOwnershipWhenRecovering()
        {
            const int NumberOfPartitions = 8;
            const int OrphanedPartitionCount = 4;

            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadBalancer = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

            // Ownership should start empty.

            var completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(0), "Storage should be tracking no ownership to start.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should start with no ownership.");

            // Mimic the state of a processor when recovering from a crash; storage says that the processor has ownership of some
            // number of partitions, but the processor state does not reflect that ownership.
            //
            // Assign the processor ownership over half of the partitions in storage, but do not formally claim them.

            var orphanedPartitions = partitionIds.Take(OrphanedPartitionCount);
            completeOwnership = await storageManager.ClaimOwnershipAsync(CreatePartitionOwnership(orphanedPartitions, loadBalancer.OwnerIdentifier));

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount), "Storage should be tracking half the partitions as orphaned.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should have no ownership of orphaned partitions.");

            // Run one load balancing cycle.  At the end of the cycle, it should have claimed a random partition
            // and recovered ownership of the orphans.

            await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount + 1), "Storage should be tracking the orphaned partitions and one additional as owned.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(OrphanedPartitionCount + 1), "The load balancer should have ownership of all orphaned partitions and one additional.");

            // Run load balancing cycles until the load balancer believes that the state is balanced or the partition count is quadrupled.

            var cycleCount = 0;

            while ((!loadBalancer.IsBalanced) && (cycleCount < (NumberOfPartitions * 4)))
            {
                await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
                ++cycleCount;
            }

            // All partitions should be owned by load balancer.

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions));
        }

        /// <summary>
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncReclaimsOwnershipWhenLeaseRenewalFails()
        {
            const int NumberOfPartitions = 8;
            const int OrphanedPartitionCount = 4;

            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var mockStorageManager = new Mock<InMemoryStorageManager>() { CallBase = true };
            var loadBalancer = new PartitionLoadBalancer(mockStorageManager.Object, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

            // Ownership should start empty.

            var completeOwnership = await mockStorageManager.Object.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(0), "Storage should be tracking no ownership to start.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should start with no ownership.");

            // Mimic the state of a processor when recovering from a crash; storage says that the processor has ownership of some
            // number of partitions, but the processor state does not reflect that ownership.
            //
            // Assign the processor ownership over half of the partitions in storage, but do not formally claim them.

            var orphanedPartitions = partitionIds.Take(OrphanedPartitionCount);
            completeOwnership = await mockStorageManager.Object.ClaimOwnershipAsync(CreatePartitionOwnership(orphanedPartitions, loadBalancer.OwnerIdentifier));

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount), "Storage should be tracking half the partitions as orphaned.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should have no ownership of orphaned partitions.");

            // Configure the Storage Manager to fail all claim attempts moving forward.

            mockStorageManager
                .Setup(sm => sm.ClaimOwnershipAsync(It.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<EventProcessorPartitionOwnership>());

            // Run one load balancing cycle.  At the end of the cycle, it should have recovered ownership of the orphans
            // but made no new claims.

            await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            completeOwnership = await mockStorageManager.Object.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount), "Storage should be tracking the orphaned partitions as owned.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(OrphanedPartitionCount), "The load balancer should have ownership of all orphaned partitions and none additional.");

            // Run load balancing cycles until the load balancer believes that the state is balanced or the partition count is quadrupled.

            var cycleCount = 0;

            while ((!loadBalancer.IsBalanced) && (cycleCount < (NumberOfPartitions * 4)))
            {
                await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
                ++cycleCount;
            }

            // Only the orphaned partitions should be owned by load balancer, other claims have failed.

            completeOwnership = await mockStorageManager.Object.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount), "Storage should be tracking the orphaned partitions as owned.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(OrphanedPartitionCount), "The load balancer should have ownership of all orphaned partitions and none additional.");
        }

        /// <summary>
        ///   Verifies that claimable partitions are claimed by a <see cref="PartitionLoadBalancer" /> after RunAsync is called.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncDoesNotStealOwnershipAsRecovery()
        {
            const int NumberOfPartitions = 8;
            const int MinimumPartitionCount = 4;
            const int OrphanedPartitionCount = 2;

            var otherLoadBalancerIdentifier = Guid.NewGuid().ToString();
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();
            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            var loadBalancer = new PartitionLoadBalancer(storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

            // Ownership should start empty.

            var completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(0), "Storage should be tracking no ownership to start.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should start with no ownership.");

            // Claim the minimum set of partitions for the "other" load balancer.

            completeOwnership = await storageManager.ClaimOwnershipAsync(CreatePartitionOwnership(partitionIds.Take(MinimumPartitionCount), otherLoadBalancerIdentifier));

            Assert.That(completeOwnership.Count(), Is.EqualTo(MinimumPartitionCount), "Storage should be tracking half the partitions as owned by another processor.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should have no ownership of any partitions.");

            // Mimic the state of a processor when recovering from a crash; storage says that the processor has ownership of some
            // number of partitions, but the processor state does not reflect that ownership.
            //
            // Assign the processor ownership over half of the partitions in storage, but do not formally claim them.

            await storageManager.ClaimOwnershipAsync(CreatePartitionOwnership(partitionIds.Skip(MinimumPartitionCount).Take(OrphanedPartitionCount), loadBalancer.OwnerIdentifier));
            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount + MinimumPartitionCount), "Storage should be tracking half the partitions as owned by another processor as well as some orphans.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(0), "The load balancer should have no ownership of orphaned or otherwise owned partitions.");

            // Run one load balancing cycle.  At the end of the cycle, it should have claimed a random partition
            // and recovered ownership of the orphans.

            await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(OrphanedPartitionCount + MinimumPartitionCount + 1), "Storage should be tracking the orphaned partitions, other processor partitions, and one additional as owned.");
            Assert.That(loadBalancer.OwnedPartitionIds.Count(), Is.EqualTo(OrphanedPartitionCount + 1), "The load balancer should have ownership of all orphaned partitions and one additional.");

            // Run load balancing cycles until the load balancer believes that the state is balanced or the partition count is quadrupled.

            var cycleCount = 0;

            while ((!loadBalancer.IsBalanced) && (cycleCount < (NumberOfPartitions * 4)))
            {
                await loadBalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
                ++cycleCount;
            }

            // All partitions should be owned by load balancer.

            completeOwnership = await storageManager.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions));
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
                storageManager, Guid.NewGuid().ToString(), ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

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
            mockLog.Verify(m => m.UnclaimedPartitions(It.Is<HashSet<string>>(set => set.Count == 0 || set.All(item => partitionIds.Contains(item)))));
        }

        /// <summary>
        ///   Verifies that ownership is renewed only for partitions past LoadBalancingInterval.
        /// </summary>
        ///
        [Test]
        public async Task RunLoadBalancingAsyncDoesNotRenewFreshPartitions()
        {
            const int NumberOfPartitions = 4;
            var partitionIds = Enumerable.Range(1, NumberOfPartitions).Select(p => p.ToString()).ToArray();

            var storageManager = new InMemoryStorageManager((s) => Console.WriteLine(s));
            string[] CollectVersions() => storageManager.Ownership.OrderBy(pair => pair.Key.PartitionId).Select(pair => pair.Value.Version).ToArray();

            var now = DateTimeOffset.UtcNow;

            var loadbalancerId = Guid.NewGuid().ToString();
            var loadbalancerMock = new Mock<PartitionLoadBalancer>(
                storageManager, loadbalancerId, ConsumerGroup, FullyQualifiedNamespace, EventHubName, TimeSpan.FromMinutes(3), TimeSpan.FromSeconds(60));
            loadbalancerMock.CallBase = true;
            loadbalancerMock.Setup(b => b.GetDateTimeOffsetNow()).Returns(() => now);
            var loadbalancer = loadbalancerMock.Object;

            storageManager.LastModifiedTime = now;

            // This run would re-take ownership and update versions
            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            var claimedVersions = CollectVersions();

            // This run would renew ownership
            now = now.AddSeconds(65);
            storageManager.LastModifiedTime = now;
            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            var renewedVersions = CollectVersions();

            // This run would not review anything as everything is up-to-date
            for (int i = 0; i < NumberOfPartitions; i++)
            {
                await loadbalancer.RunLoadBalancingAsync(partitionIds, CancellationToken.None);
            }

            var notRenewedVersions = CollectVersions();

            for (int i = 0; i < NumberOfPartitions; i++)
            {
                Assert.That(claimedVersions[i], Is.Not.EqualTo(renewedVersions[i]), "Partitions should've been claimed");
                Assert.That(renewedVersions[i], Is.EqualTo(notRenewedVersions[i]), "Partitions should've been skipped during renewal");
            }

            Assert.That(storageManager.TotalRenewals, Is.EqualTo(8), "There should be 4 initial claims and 4 renew claims");
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
