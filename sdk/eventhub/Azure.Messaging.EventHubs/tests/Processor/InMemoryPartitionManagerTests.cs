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
    ///   The suite of tests for the <see cref="InMemoryPartitionManager" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class InMemoryPartitionManagerTests
    {
        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ListOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            var partitionManager = new InMemoryPartitionManager();
            IEnumerable<PartitionOwnership> ownership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(ownership, Is.Not.Null.And.Empty);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            var partitionManager = new InMemoryPartitionManager();
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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(ownership));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidETag")]
        public async Task OwnershipClaimFailsWhenETagIsInvalid(string eTag)
        {
            var partitionManager = new InMemoryPartitionManager();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    offset: 1
                );

            ownershipList.Add(firstOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            ownershipList.Clear();

            var secondOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    offset: 2,
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(firstOwnership));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenETagIsValid()
        {
            var partitionManager = new InMemoryPartitionManager();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
                    "namespace",
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    offset: 1
                );

            ownershipList.Add(firstOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the partition manager.

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
                    offset: 2,
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            var partitionManager = new InMemoryPartitionManager();
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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(ownershipCount));
            Assert.That(storedOwnership.OrderBy(ownership => ownership.PartitionId).SequenceEqual(ownershipList), Is.True);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            var partitionManager = new InMemoryPartitionManager();
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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            // The ETags must have been set by the partition manager.

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
                        $"partitionId { i }",
                        offset: i,
                        eTag: i % 2 == 1 ? eTags[i] : null
                    ));
            }

            IEnumerable<PartitionOwnership> claimedOwnership = await partitionManager.ClaimOwnershipAsync(ownershipList);

            Assert.That(claimedOwnership, Is.Not.Null);
            Assert.That(claimedOwnership.Count, Is.EqualTo(expectedClaimedCount));
            Assert.That(claimedOwnership.OrderBy(ownership => ownership.Offset).SequenceEqual(ownershipList.Where(ownership => ownership.Offset % 2 == 1)), Is.True);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            var partitionManager = new InMemoryPartitionManager();
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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the partition manager.

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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership1 = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup1");
            IEnumerable<PartitionOwnership> storedOwnership2 = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup2");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            var partitionManager = new InMemoryPartitionManager();
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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the partition manager.

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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership1 = await partitionManager.ListOwnershipAsync("namespace", "eventHubName1", "consumerGroup");
            IEnumerable<PartitionOwnership> storedOwnership2 = await partitionManager.ListOwnershipAsync("namespace", "eventHubName2", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherNamespaces()
        {
            var partitionManager = new InMemoryPartitionManager();
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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            // ETag must have been set by the partition manager.

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

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            IEnumerable<PartitionOwnership> storedOwnership1 = await partitionManager.ListOwnershipAsync("namespace1", "eventHubName", "consumerGroup");
            IEnumerable<PartitionOwnership> storedOwnership2 = await partitionManager.ListOwnershipAsync("namespace2", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateFailsWhenAssociatedOwnershipDoesNotExist()
        {
            var partitionManager = new InMemoryPartitionManager();

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: 10, sequenceNumber: 20));

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership, Is.Empty);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateFailsWhenOwnerChanges()
        {
            var partitionManager = new InMemoryPartitionManager();
            var originalOwnership = new PartitionOwnership
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier1", "partitionId", offset: 1, sequenceNumber: 2, lastModifiedTime: DateTimeOffset.UtcNow);

            await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
            {
                originalOwnership
            });

            // ETag must have been set by the partition manager.

            DateTimeOffset? originalLastModifiedTime = originalOwnership.LastModifiedTime;
            var originalETag = originalOwnership.ETag;

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier2", "partitionId", 10, 20));

            // Make sure the ownership hasn't changed.

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(originalOwnership));

            Assert.That(originalOwnership.OwnerIdentifier, Is.EqualTo("ownerIdentifier1"));
            Assert.That(originalOwnership.Offset, Is.EqualTo(1));
            Assert.That(originalOwnership.SequenceNumber, Is.EqualTo(2));
            Assert.That(originalOwnership.LastModifiedTime, Is.EqualTo(originalLastModifiedTime));
            Assert.That(originalOwnership.ETag, Is.EqualTo(originalETag));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateUpdatesOwnershipInformation()
        {
            var partitionManager = new InMemoryPartitionManager();
            var originalOwnership = new PartitionOwnership
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1, sequenceNumber: 2, lastModifiedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

            await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
            {
                originalOwnership
            });

            // ETag must have been set by the partition manager.

            DateTimeOffset? originalLastModifiedTime = originalOwnership.LastModifiedTime;
            var originalETag = originalOwnership.ETag;

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20));

            // Make sure the ownership has changed, even though the instance should be the same.

            IEnumerable<PartitionOwnership> storedOwnership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedOwnership, Is.Not.Null);
            Assert.That(storedOwnership.Count, Is.EqualTo(1));
            Assert.That(storedOwnership.Single(), Is.EqualTo(originalOwnership));

            Assert.That(originalOwnership.Offset, Is.EqualTo(10));
            Assert.That(originalOwnership.SequenceNumber, Is.EqualTo(20));
            Assert.That(originalOwnership.LastModifiedTime, Is.GreaterThan(originalLastModifiedTime));
            Assert.That(originalOwnership.ETag, Is.Not.EqualTo(originalETag));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            var partitionManager = new InMemoryPartitionManager();

            var ownership1 = new PartitionOwnership
                ("namespace", "eventHubName", "consumerGroup1", "ownerIdentifier", "partitionId", offset: 1);
            var ownership2 = new PartitionOwnership
                ("namespace", "eventHubName", "consumerGroup2", "ownerIdentifier", "partitionId", offset: 1);

            await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
            {
                ownership1,
                ownership2
            });

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup1", "ownerIdentifier", "partitionId", 10, 20));

            Assert.That(ownership1.Offset, Is.EqualTo(10));
            Assert.That(ownership2.Offset, Is.EqualTo(1));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            var partitionManager = new InMemoryPartitionManager();

            var ownership1 = new PartitionOwnership
                ("namespace", "eventHubName1", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1);
            var ownership2 = new PartitionOwnership
                ("namespace", "eventHubName2", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1);

            await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
            {
                ownership1,
                ownership2
            });

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName1", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20));

            Assert.That(ownership1.Offset, Is.EqualTo(10));
            Assert.That(ownership2.Offset, Is.EqualTo(1));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherNamespaces()
        {
            var partitionManager = new InMemoryPartitionManager();

            var ownership1 = new PartitionOwnership
                ("namespace1", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1);
            var ownership2 = new PartitionOwnership
                ("namespace2", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1);

            await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
            {
                ownership1,
                ownership2
            });

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace1", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20));

            Assert.That(ownership1.Offset, Is.EqualTo(10));
            Assert.That(ownership2.Offset, Is.EqualTo(1));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="InMemoryPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            var partitionManager = new InMemoryPartitionManager();

            var ownership1 = new PartitionOwnership
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId1", offset: 1);
            var ownership2 = new PartitionOwnership
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId2", offset: 1);

            await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
            {
                ownership1,
                ownership2
            });

            await partitionManager.UpdateCheckpointAsync(new Checkpoint
                ("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId1", 10, 20));

            Assert.That(ownership1.Offset, Is.EqualTo(10));
            Assert.That(ownership2.Offset, Is.EqualTo(1));
        }
    }
}
