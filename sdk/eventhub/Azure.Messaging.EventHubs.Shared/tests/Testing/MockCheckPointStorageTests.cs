// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="MockCheckPointStorage" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class MockCheckPointStorageTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            var storageManager = new MockCheckPointStorage();
            IEnumerable<PartitionOwnership> ownership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(ownership, Is.Not.Null.And.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var ownership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(ownership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(ownership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidETag")]
        public async Task OwnershipClaimFailsWhenETagIsInvalid(string eTag)
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            ownershipList.Clear();

            var secondOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(firstOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenETagIsValid()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the storage manager.

            var eTag = firstOwnership.ETag;

            ownershipList.Clear();

            var secondOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var ownershipCount = 5;

            for (int i = 0; i < ownershipCount; i++)
            {
                ownershipList.Add(
                    new PartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        $"partitionId { i }"
                    ));
            }

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(ownershipCount));
            Assert.That(storedOwnership.OrderBy(ownership => ownership.PartitionId).SequenceEqual(ownershipList), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var ownershipCount = 5;

            for (int i = 0; i < ownershipCount; i++)
            {
                ownershipList.Add(
                    new PartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        $"{ i }"
                    ));
            }

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // The ETags must have been set by the storage manager.

            var eTags = ownershipList.Select(ownership => ownership.ETag).ToList();

            ownershipList.Clear();

            // Use a valid eTag when 'i' is odd.  This way, we can expect 'ownershipCount / 2' successful
            // claims (rounded down).

            var expectedClaimedCount = ownershipCount / 2;

            for (int i = 0; i < ownershipCount; i++)
            {
                ownershipList.Add(
                    new PartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        $"{ i }",
                        eTag: i % 2 == 1 ? eTags[i] : null
                    ));
            }

            IEnumerable<PartitionOwnership> claimedOwnership = await storageManager.ClaimOwnershipAsync(ownershipList);

            Assert.That(claimedOwnership, Is.Not.Null);
            Assert.That(claimedOwnership.Count, Is.EqualTo(expectedClaimedCount));
            Assert.That(claimedOwnership.OrderBy(ownership => int.Parse(ownership.PartitionId)).SequenceEqual(ownershipList.Where(ownership => int.Parse(ownership.PartitionId) % 2 == 1)), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup1",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the storage manager.

            var eTag = firstOwnership.ETag;

            ownershipList.Clear();

            var secondOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup2",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership1 = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup1");
            IEnumerable<PartitionOwnership> storedOwnership2 = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup2");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName1",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the storage manager.

            var eTag = firstOwnership.ETag;

            ownershipList.Clear();

            var secondOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName2",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership1 = await storageManager.ListOwnershipAsync("namespace", "eventHubName1", "consumerGroup");
            IEnumerable<PartitionOwnership> storedOwnership2 = await storageManager.ListOwnershipAsync("namespace", "eventHubName2", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherNamespaces()
        {
            var storageManager = new MockCheckPointStorage();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace1",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(firstOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the storage manager.

            var eTag = firstOwnership.ETag;

            ownershipList.Clear();

            var secondOwnership =
                new PartitionOwnership
                (
                    "namespace2",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await storageManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership1 = await storageManager.ListOwnershipAsync("namespace1", "eventHubName", "consumerGroup");
            IEnumerable<PartitionOwnership> storedOwnership2 = await storageManager.ListOwnershipAsync("namespace2", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            var storageManager = new MockCheckPointStorage();

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup1", "partitionId", 10, 20));

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup2", "partitionId", 10, 20));

            IEnumerable<Checkpoint> storedCheckpointsList1 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup1");
            IEnumerable<Checkpoint> storedCheckpointsList2 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup2");

            Assert.That(storedCheckpointsList1, Is.Not.Null);
            Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

            Assert.That(storedCheckpointsList2, Is.Not.Null);
            Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            var storageManager = new MockCheckPointStorage();

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName1", "consumerGroup", "partitionId", 10, 20));

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName2", "consumerGroup", "partitionId", 10, 20));

            IEnumerable<Checkpoint> storedCheckpointsList1 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName1", "consumerGroup");
            IEnumerable<Checkpoint> storedCheckpointsList2 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName2", "consumerGroup");

            Assert.That(storedCheckpointsList1, Is.Not.Null);
            Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

            Assert.That(storedCheckpointsList2, Is.Not.Null);
            Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherNamespaces()
        {
            var storageManager = new MockCheckPointStorage();

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace1", "eventHubName", "consumerGroup", "partitionId", 10, 20));

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace2", "eventHubName", "consumerGroup", "partitionId", 10, 20));

            IEnumerable<Checkpoint> storedCheckpointsList1 = await storageManager.ListCheckpointsAsync("namespace1", "eventHubName", "consumerGroup");
            IEnumerable<Checkpoint> storedCheckpointsList2 = await storageManager.ListCheckpointsAsync("namespace2", "eventHubName", "consumerGroup");

            Assert.That(storedCheckpointsList1, Is.Not.Null);
            Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

            Assert.That(storedCheckpointsList2, Is.Not.Null);
            Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="MockCheckPointStorage.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            var storageManager = new MockCheckPointStorage();

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup", "partitionId1", 10, 20));

            await storageManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup", "partitionId2", 10, 20));

            IEnumerable<Checkpoint> storedCheckpointsList = await storageManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedCheckpointsList, Is.Not.Null);
            Assert.That(storedCheckpointsList.Count, Is.EqualTo(2));

            Checkpoint storedCheckpoint1 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId1");
            Checkpoint storedCheckpoint2 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId2");

            Assert.That(storedCheckpoint1, Is.Not.Null);
            Assert.That(storedCheckpoint2, Is.Not.Null);
        }
    }
}
