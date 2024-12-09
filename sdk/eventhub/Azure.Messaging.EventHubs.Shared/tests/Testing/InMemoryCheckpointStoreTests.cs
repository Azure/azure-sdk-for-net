// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="InMemoryCheckpointStore" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class InMemoryCheckpointStoreTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            var storageManager = new InMemoryCheckpointStore();
            IEnumerable<EventProcessorPartitionOwnership> ownership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(ownership, Is.Not.Null.And.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();
            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId"
            };

            ownershipList.Add(ownership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(ownership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidVersion")]
        public async Task OwnershipClaimFailsWhenVersionIsInvalid(string version)
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();
            var firstOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId"
            };

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            ownershipList.Clear();

            var secondOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId",
                Version = version
            };

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(firstOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenVersionsValid()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();
            var firstOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId"
            };

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // Version must have been set by the storage manager.

            var version = firstOwnership.Version;

            ownershipList.Clear();

            var secondOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId",
                Version = version
            };

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();
            var ownershipCount = 5;

            for (int i = 0; i < ownershipCount; i++)
            {
                ownershipList.Add(
                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = "namespace",
                        EventHubName = "eventHubName",
                        ConsumerGroup = "consumerGroup",
                        OwnerIdentifier = "ownerIdentifier",
                        PartitionId = $"partitionId { i }"
                    });
            }

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(ownershipCount));
            Assert.That(storedOwnership.OrderBy(ownership => ownership.PartitionId).SequenceEqual(ownershipList), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();
            var ownershipCount = 5;

            for (int i = 0; i < ownershipCount; i++)
            {
                ownershipList.Add(
                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = "namespace",
                        EventHubName = "eventHubName",
                        ConsumerGroup = "consumerGroup",
                        OwnerIdentifier = "ownerIdentifier",
                        PartitionId = $"{ i }"
                    });
            }

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // The versions must have been set by the storage manager.

            var versions = ownershipList.Select(ownership => ownership.Version).ToList();

            ownershipList.Clear();

            // Use a valid version when 'i' is odd.  This way, we can expect 'ownershipCount / 2' successful
            // claims (rounded down).

            var expectedClaimedCount = ownershipCount / 2;

            for (int i = 0; i < ownershipCount; i++)
            {
                ownershipList.Add(
                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = "namespace",
                        EventHubName = "eventHubName",
                        ConsumerGroup = "consumerGroup",
                        OwnerIdentifier = "ownerIdentifier",
                        PartitionId = $"{ i }",
                        Version = i % 2 == 1 ? versions[i] : null
                    });
            }

            IEnumerable<EventProcessorPartitionOwnership> claimedOwnership = await storageManager.ClaimOwnershipAsync(ownershipList);

            Assert.That(claimedOwnership, Is.Not.Null);
            Assert.That(claimedOwnership.Count, Is.EqualTo(expectedClaimedCount));
            Assert.That(claimedOwnership.OrderBy(ownership => int.Parse(ownership.PartitionId)).SequenceEqual(ownershipList.Where(ownership => int.Parse(ownership.PartitionId) % 2 == 1)), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();

            var firstOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup1",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId"
            };

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // Version must have been set by the storage manager.

            var version = firstOwnership.Version;

            ownershipList.Clear();

            var secondOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup2",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId",
                Version = version
            };

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership1 = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup1");
            IEnumerable<EventProcessorPartitionOwnership> storedOwnership2 = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup2");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();

            var firstOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName1",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId"
            };

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // Version must have been set by the storage manager.

            var version = firstOwnership.Version;

            ownershipList.Clear();

            var secondOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName2",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId",
                Version = version
            };

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership1 = await storageManager.ListOwnershipAsync("namespace", "eventHubName1", "consumerGroup");
            IEnumerable<EventProcessorPartitionOwnership> storedOwnership2 = await storageManager.ListOwnershipAsync("namespace", "eventHubName2", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherNamespaces()
        {
            var storageManager = new InMemoryCheckpointStore();
            var ownershipList = new List<EventProcessorPartitionOwnership>();

            var firstOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace1",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId"
            };

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // Version must have been set by the storage manager.

            var version = firstOwnership.Version;

            ownershipList.Clear();

            var secondOwnership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "namespace2",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                OwnerIdentifier = "ownerIdentifier",
                PartitionId = "partitionId",
                Version = version
            };

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<EventProcessorPartitionOwnership> storedOwnership1 = await storageManager.ListOwnershipAsync("namespace1", "eventHubName", "consumerGroup");
            IEnumerable<EventProcessorPartitionOwnership> storedOwnership2 = await storageManager.ListOwnershipAsync("namespace2", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            var storageManager = new InMemoryCheckpointStore();

            await storageManager.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup1", "partitionId", "Id", new CheckpointPosition("10"));
            await storageManager.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup2", "partitionId", "Id", new CheckpointPosition("444", 10));

            var storedCheckpoint1 = await storageManager.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup1", "partitionId");
            var storedCheckpoint2 = await storageManager.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup2", "partitionId");

            Assert.That(storedCheckpoint1, Is.Not.Null);
            Assert.That(storedCheckpoint2, Is.Not.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            var storageManager = new InMemoryCheckpointStore();

            await storageManager.UpdateCheckpointAsync("namespace", "eventHubName1", "consumerGroup", "partitionId", "Id", new CheckpointPosition("10"));
            await storageManager.UpdateCheckpointAsync("namespace", "eventHubName2", "consumerGroup", "partitionId", "Id", new CheckpointPosition("444", 10));

            var storedCheckpoint1 = await storageManager.GetCheckpointAsync("namespace", "eventHubName1", "consumerGroup", "partitionId");
            var storedCheckpoint2 = await storageManager.GetCheckpointAsync("namespace", "eventHubName2", "consumerGroup", "partitionId");

            Assert.That(storedCheckpoint1, Is.Not.Null);
            Assert.That(storedCheckpoint2, Is.Not.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherNamespaces()
        {
            var storageManager = new InMemoryCheckpointStore();

            await storageManager.UpdateCheckpointAsync("namespace1", "eventHubName", "consumerGroup", "partitionId", "Id", new CheckpointPosition("10"));
            await storageManager.UpdateCheckpointAsync("namespace2", "eventHubName", "consumerGroup", "partitionId", "Id", new CheckpointPosition("444", 10));

            var storedCheckpoint1 = await storageManager.GetCheckpointAsync("namespace1", "eventHubName", "consumerGroup", "partitionId");
            var storedCheckpoint2 = await storageManager.GetCheckpointAsync("namespace2", "eventHubName", "consumerGroup", "partitionId");

            Assert.That(storedCheckpoint1, Is.Not.Null);
            Assert.That(storedCheckpoint2, Is.Not.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            var storageManager = new InMemoryCheckpointStore();

            await storageManager.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId1", "Id", new CheckpointPosition("111", 10));
            await storageManager.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId2", "Id", new CheckpointPosition("9"));

            var storedCheckpoint1 = await storageManager.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId1");
            var storedCheckpoint2 = await storageManager.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId2");

            Assert.That(storedCheckpoint1, Is.Not.Null);
            Assert.That(storedCheckpoint2, Is.Not.Null);
        }
    }
}
