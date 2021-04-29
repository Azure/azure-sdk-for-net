// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="InMemoryStorageManager" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class InMemoryStorageManagerTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            var storageManager = new InMemoryStorageManager();
            IEnumerable<EventProcessorPartitionOwnership> ownership = await storageManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(ownership, Is.Not.Null.And.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidVersion")]
        public async Task OwnershipClaimFailsWhenVersionIsInvalid(string version)
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenVersionsValid()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherNamespaces()
        {
            var storageManager = new InMemoryStorageManager();
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
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            var storageManager = new InMemoryStorageManager();

            var mockEvent = new MockEventData(
                eventBody: Array.Empty<byte>(),
                offset: 10,
                sequenceNumber: 20);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup1",
                PartitionId = "partitionId"
            }, mockEvent);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup2",
                PartitionId = "partitionId"
            }, mockEvent);

            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList1 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup1");
            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList2 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup2");

            Assert.That(storedCheckpointsList1, Is.Not.Null);
            Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

            Assert.That(storedCheckpointsList2, Is.Not.Null);
            Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            var storageManager = new InMemoryStorageManager();

            var mockEvent = new MockEventData(
                eventBody: Array.Empty<byte>(),
                offset: 10,
                sequenceNumber: 20);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName1",
                ConsumerGroup = "consumerGroup",
                PartitionId = "partitionId"
            }, mockEvent);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName2",
                ConsumerGroup = "consumerGroup",
                PartitionId = "partitionId"
            }, mockEvent);

            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList1 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName1", "consumerGroup");
            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList2 = await storageManager.ListCheckpointsAsync("namespace", "eventHubName2", "consumerGroup");

            Assert.That(storedCheckpointsList1, Is.Not.Null);
            Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

            Assert.That(storedCheckpointsList2, Is.Not.Null);
            Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherNamespaces()
        {
            var storageManager = new InMemoryStorageManager();

            var mockEvent = new MockEventData(
                eventBody: Array.Empty<byte>(),
                offset: 10,
                sequenceNumber: 20);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace1",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                PartitionId = "partitionId"
            }, mockEvent);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace2",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                PartitionId = "partitionId"
            }, mockEvent);

            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList1 = await storageManager.ListCheckpointsAsync("namespace1", "eventHubName", "consumerGroup");
            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList2 = await storageManager.ListCheckpointsAsync("namespace2", "eventHubName", "consumerGroup");

            Assert.That(storedCheckpointsList1, Is.Not.Null);
            Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

            Assert.That(storedCheckpointsList2, Is.Not.Null);
            Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="InMemoryStorageManager.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            var storageManager = new InMemoryStorageManager();

            var mockEvent = new MockEventData(
                eventBody: Array.Empty<byte>(),
                offset: 10,
                sequenceNumber: 20);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                PartitionId = "partitionId1"
            }, mockEvent);

            await storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "namespace",
                EventHubName = "eventHubName",
                ConsumerGroup = "consumerGroup",
                PartitionId = "partitionId2"
            }, mockEvent);

            IEnumerable<EventProcessorCheckpoint> storedCheckpointsList = await storageManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup");

            Assert.That(storedCheckpointsList, Is.Not.Null);
            Assert.That(storedCheckpointsList.Count, Is.EqualTo(2));

            EventProcessorCheckpoint storedCheckpoint1 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId1");
            EventProcessorCheckpoint storedCheckpoint2 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId2");

            Assert.That(storedCheckpoint1, Is.Not.Null);
            Assert.That(storedCheckpoint2, Is.Not.Null);
        }
    }
}
