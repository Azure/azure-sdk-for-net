// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.CheckpointStore.Blob.Tests.Infrastructure;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blob.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="BlobPartitionManager" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    //[Category(TestCategory.Live)]
    //[Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class BlobPartitionManagerLiveTests
    {
        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ListOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

                Assert.That(ownership, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownership =
                    new MockPartitionOwnership
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
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidETag")]
        public async Task OwnershipClaimFailsWhenETagIsInvalid(string eTag)
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenETagIsValid()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownershipCount = 5;

                for (int i = 0; i < ownershipCount; i++)
                {
                    ownershipList.Add(
                        new MockPartitionOwnership
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
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownershipCount = 5;

                for (int i = 0; i < ownershipCount; i++)
                {
                    ownershipList.Add(
                        new MockPartitionOwnership
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
                        new MockPartitionOwnership
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
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.ClaimOwnershipAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateFailsWhenAssociatedOwnershipDoesNotExist()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: 10, sequenceNumber: 20));

                var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

                Assert.That(storedOwnership, Is.Not.Null);
                Assert.That(storedOwnership, Is.Empty);
            }
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateFailsWhenOwnerChanges()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var originalOwnership = new MockPartitionOwnership
                    ("eventHubName", "consumerGroup", "ownerIdentifier1", "partitionId", offset: 1, sequenceNumber: 2, lastModifiedTime: DateTimeOffset.UtcNow);

                await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
                {
                    originalOwnership
                });

                // ETag must have been set by the partition manager.

                var originalLastModifiedTime = originalOwnership.LastModifiedTime;
                var originalETag = originalOwnership.ETag;

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("eventHubName", "consumerGroup", "ownerIdentifier2", "partitionId", 10, 20));

                // Make sure the ownership hasn't changed.

                var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

                Assert.That(storedOwnership, Is.Not.Null);
                Assert.That(storedOwnership.Count, Is.EqualTo(1));
                Assert.That(storedOwnership.Single(), Is.EqualTo(originalOwnership));

                Assert.That(originalOwnership.OwnerIdentifier, Is.EqualTo("ownerIdentifier1"));
                Assert.That(originalOwnership.Offset, Is.EqualTo(1));
                Assert.That(originalOwnership.SequenceNumber, Is.EqualTo(2));
                Assert.That(originalOwnership.LastModifiedTime, Is.EqualTo(originalLastModifiedTime));
                Assert.That(originalOwnership.ETag, Is.EqualTo(originalETag));
            }
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateUpdatesOwnershipInformation()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);
                var originalOwnership = new MockPartitionOwnership
                    ("eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1, sequenceNumber: 2, lastModifiedTime: DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
                {
                    originalOwnership
                });

                // ETag must have been set by the partition manager.

                var originalLastModifiedTime = originalOwnership.LastModifiedTime;
                var originalETag = originalOwnership.ETag;

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20));

                // Make sure the ownership has changed, even though the instance should be the same.

                var storedOwnership = await partitionManager.ListOwnershipAsync("eventHubName", "consumerGroup");

                Assert.That(storedOwnership, Is.Not.Null);
                Assert.That(storedOwnership.Count, Is.EqualTo(1));
                Assert.That(storedOwnership.Single(), Is.EqualTo(originalOwnership));

                Assert.That(originalOwnership.Offset, Is.EqualTo(10));
                Assert.That(originalOwnership.SequenceNumber, Is.EqualTo(20));
                Assert.That(originalOwnership.LastModifiedTime, Is.GreaterThan(originalLastModifiedTime));
                Assert.That(originalOwnership.ETag, Is.Not.EqualTo(originalETag));
            }
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);

                var ownership1 = new MockPartitionOwnership
                    ("eventHubName", "consumerGroup1", "ownerIdentifier", "partitionId", offset: 1);
                var ownership2 = new MockPartitionOwnership
                    ("eventHubName", "consumerGroup2", "ownerIdentifier", "partitionId", offset: 1);

                await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
                {
                    ownership1,
                    ownership2
                });

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("eventHubName", "consumerGroup1", "ownerIdentifier", "partitionId", 10, 20));

                Assert.That(ownership1.Offset, Is.EqualTo(10));
                Assert.That(ownership2.Offset, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);

                var ownership1 = new MockPartitionOwnership
                    ("eventHubName1", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1);
                var ownership2 = new MockPartitionOwnership
                    ("eventHubName2", "consumerGroup", "ownerIdentifier", "partitionId", offset: 1);

                await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
                {
                    ownership1,
                    ownership2
                });

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("eventHubName1", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20));

                Assert.That(ownership1.Offset, Is.EqualTo(10));
                Assert.That(ownership2.Offset, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager.UpdateCheckpointAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new BlobPartitionManager(containerClient);

                var ownership1 = new MockPartitionOwnership
                    ("eventHubName", "consumerGroup", "ownerIdentifier", "partitionId1", offset: 1);
                var ownership2 = new MockPartitionOwnership
                    ("eventHubName", "consumerGroup", "ownerIdentifier", "partitionId2", offset: 1);

                await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
                {
                    ownership1,
                    ownership2
                });

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("eventHubName", "consumerGroup", "ownerIdentifier", "partitionId1", 10, 20));

                Assert.That(ownership1.Offset, Is.EqualTo(10));
                Assert.That(ownership2.Offset, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   A workaround so we can create <see cref="PartitionOwnership"/> instances.
        ///   This class can be removed once the following issue has been closed: https://github.com/Azure/azure-sdk-for-net/issues/7585
        /// </summary>
        ///
        private class MockPartitionOwnership : PartitionOwnership
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="MockPartitionOwnership"/> class.
            /// </summary>
            ///
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
            /// <param name="eTag">The entity tag needed to update this ownership.</param>
            ///
            public MockPartitionOwnership(string eventHubName,
                                          string consumerGroup,
                                          string ownerIdentifier,
                                          string partitionId,
                                          long? offset = null,
                                          long? sequenceNumber = null,
                                          DateTimeOffset? lastModifiedTime = null,
                                          string eTag = null) : base(eventHubName, consumerGroup, ownerIdentifier, partitionId, offset, sequenceNumber, lastModifiedTime, eTag)
            {
            }
        }

        /// <summary>
        ///   A workaround so we can create <see cref="Checkpoint"/> instances.
        /// </summary>
        ///
        private class MockCheckpoint : Checkpoint
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="MockPartitionOwnership"/> class.
            /// </summary>
            ///
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            ///
            public MockCheckpoint(string eventHubName,
                                  string consumerGroup,
                                  string ownerIdentifier,
                                  string partitionId,
                                  long offset,
                                  long sequenceNumber) : base(eventHubName, consumerGroup, ownerIdentifier, partitionId, offset, sequenceNumber)
            {
            }
        }
    }
}
