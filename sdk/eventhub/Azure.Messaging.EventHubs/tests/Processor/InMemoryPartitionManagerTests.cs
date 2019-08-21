// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Tests.Processor
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
            var ownership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

            Assert.That(ownership, Is.Not.Null);
            Assert.That(ownership, Is.Empty);
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
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId"
                );

            ownershipList.Add(ownership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

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
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    offset: 2,
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

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
                    "eventHubName",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    offset: 2,
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

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
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        $"partitionId { i }"
                    ));
            }

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

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
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        $"partitionId { i }",
                        offset: i,
                        eTag: i % 2 == 1 ? eTags[i] : null
                    ));
            }

            var claimedOwnership = await partitionManager.ClaimOwnershipAsync(ownershipList);

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
        [Ignore("Failing test: current implementation only uses partition id as key")]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            var partitionManager = new InMemoryPartitionManager();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
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
                    "eventHubName",
                    "consumerGroup2",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            var storedOwnership1 = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup1");
            var storedOwnership2 = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup2");

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
        [Ignore("Failing test: current implementation only uses partition id as key")]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            var partitionManager = new InMemoryPartitionManager();
            var ownershipList = new List<PartitionOwnership>();
            var firstOwnership =
                new PartitionOwnership
                (
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
                    "eventHubName2",
                    "consumerGroup",
                    "ownerIdentifier",
                    "partitionId",
                    eTag: eTag
                );

            ownershipList.Add(secondOwnership);

            await partitionManager.ClaimOwnershipAsync(ownershipList);

            var storedOwnership1 = await partitionManager.ListOwnershipAsync("eventHubName1", "consumerGroup");
            var storedOwnership2 = await partitionManager.ListOwnershipAsync("eventHubName2", "consumerGroup");

            Assert.That(storedOwnership1, Is.Not.Null);
            Assert.That(storedOwnership1.Count, Is.EqualTo(1));
            Assert.That(storedOwnership1.Single(), Is.EqualTo(firstOwnership));

            Assert.That(storedOwnership2, Is.Not.Null);
            Assert.That(storedOwnership2.Count, Is.EqualTo(1));
            Assert.That(storedOwnership2.Single(), Is.EqualTo(secondOwnership));
        }
    }
}
