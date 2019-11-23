// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Tests.Infrastructure;
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="Processor.BlobsCheckpointStore" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class BlobsCheckpointStoreLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="Processor.BlobsCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        public async Task BlobPartitionManagerCanListOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                Assert.That(async () => await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup"), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="Processor.BlobsCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        public async Task BlobPartitionManagerCanListCheckpoints()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                Assert.That(async () => await partitionManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup"), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="Processor.BlobsCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("ETag")]
        public async Task BlobPartitionManagerCanClaimOwnership(string eTag)
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>
                {

                    // Null ETag and non-null ETag hit different paths of the code, calling different methods that connect
                    // to the Storage service.

                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId",
                        eTag: eTag
                    )
                };

                Assert.That(async () => await partitionManager.ClaimOwnershipAsync(ownershipList), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="Processor.BlobsCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        public async Task BlobPartitionManagerCanUpdateCheckpoint()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>
                {

                    // Make sure the ownership exists beforehand so we hit all storage SDK calls in the partition manager.

                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId"
                    )
                };

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                var checkpoint = new MockCheckpoint("namespace", "eventHubName", "consumerGroup", "partitionId", 10, 20);

                Assert.That(async () => await partitionManager.UpdateCheckpointAsync(checkpoint), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                IEnumerable<PartitionOwnership> ownership = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(ownership, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointAsyncReturnsEmptyIEnumerableWhenThereAreNoCheckpoints()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                IEnumerable<Checkpoint> checkpoints = await partitionManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(checkpoints, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownership =
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId"
                    );

                ownershipList.Add(ownership);

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(ownership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies that returned eTag contains single quotes
        /// </summary>
        ///
        [Test]
        public async Task CheckReturnedEtagContainsSingleQuotes()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                // A regular expression used to capture strings enclosed in double quotes.
                Regex s_doubleQuotesExpression = new Regex("\"(.*)\"", RegexOptions.Compiled);

                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownership =
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId"
                    );

                ownershipList.Add(ownership);

                IEnumerable<PartitionOwnership> claimedOwnership = await partitionManager.ClaimOwnershipAsync(ownershipList);

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Match claimedOwnershipMatch = s_doubleQuotesExpression.Match(claimedOwnership.First().ETag);
                Match storedOwnershipListMatch = s_doubleQuotesExpression.Match(storedOwnershipList.First().ETag);

                Assert.That(claimedOwnershipMatch.Success, Is.False);
                Assert.That(storedOwnershipListMatch.Success, Is.False);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSetsLastModifiedTimeAndETag()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownership =
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId"
                    );

                ownershipList.Add(ownership);

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                Assert.That(ownership.LastModifiedTime, Is.Not.Null);
                Assert.That(ownership.LastModifiedTime.Value, Is.GreaterThan(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(5))));

                Assert.That(ownership.ETag, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidETag")]
        public async Task OwnershipClaimFailsWhenETagIsInvalid(string eTag)
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId"
                    );

                ownershipList.Add(firstOwnership);

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                ownershipList.Clear();

                var secondOwnership =
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId",
                        eTag: eTag
                    );

                ownershipList.Add(secondOwnership);

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimFailsWhenETagExistsAndOwnershipDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();

                var eTaggyOwnership =
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId",
                        eTag: "ETag"
                    );

                ownershipList.Add(eTaggyOwnership);

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenETagIsValid()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
                    (
                        "namespace",
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
                    new MockPartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId",
                        eTag: eTag
                    );

                ownershipList.Add(secondOwnership);

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(secondOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownershipCount = 5;

                for (int i = 0; i < ownershipCount; i++)
                {
                    ownershipList.Add(
                        new MockPartitionOwnership
                        (
                            "namespace",
                            "eventHubName",
                            "consumerGroup",
                            "ownerIdentifier",
                            $"partitionId { i }"
                        ));
                }

                await partitionManager.ClaimOwnershipAsync(ownershipList);

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(ownershipCount));

                var index = 0;

                foreach (PartitionOwnership ownership in storedOwnershipList.OrderBy(ownership => ownership.PartitionId))
                {
                    Assert.That(ownership.IsEquivalentTo(ownershipList[index]), Is.True, $"Ownership of partition '{ ownership.PartitionId }' should be equivalent.");
                    ++index;
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var ownershipCount = 5;

                for (int i = 0; i < ownershipCount; i++)
                {
                    ownershipList.Add(
                        new MockPartitionOwnership
                        (
                            "namespace",
                            "eventHubName",
                            "consumerGroup",
                            "ownerIdentifier",
                            partitionId: $"{i}"
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
                            "namespace",
                            "eventHubName",
                            "consumerGroup",
                            "ownerIdentifier",
                            partitionId: $"{i}",
                            eTag: i % 2 == 1 ? eTags[i] : null
                        ));
                }

                IEnumerable<PartitionOwnership> claimedOwnershipList = await partitionManager.ClaimOwnershipAsync(ownershipList);
                IEnumerable<PartitionOwnership> expectedOwnership = ownershipList.Where(ownership => int.Parse(ownership.PartitionId) % 2 == 1);

                Assert.That(claimedOwnershipList, Is.Not.Null);
                Assert.That(claimedOwnershipList.Count, Is.EqualTo(expectedClaimedCount));

                var index = 0;

                foreach (PartitionOwnership ownership in claimedOwnershipList.OrderBy(ownership => ownership.PartitionId))
                {
                    Assert.That(ownership.IsEquivalentTo(expectedOwnership.ElementAt(index)), Is.True, $"Ownership of partition '{ ownership.PartitionId }' should be equivalent.");
                    ++index;
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup1");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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

                IEnumerable<PartitionOwnership> storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace", "eventHubName1", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherNamespaces()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);
                var ownershipList = new List<PartitionOwnership>();
                var firstOwnership =
                    new MockPartitionOwnership
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
                    new MockPartitionOwnership
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

                var storedOwnershipList = await partitionManager.ListOwnershipAsync("namespace1", "eventHubName", "consumerGroup");

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipFailsWhenContainerDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, $"test-container-{Guid.NewGuid()}");

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                Assert.That(async () => await partitionManager.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup"), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsFailsWhenContainerDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, $"test-container-{Guid.NewGuid()}");

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                Assert.That(async () => await partitionManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup"), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateFailsWhenContainerDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, $"test-container-{Guid.NewGuid()}");

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                Assert.That(async () => await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName", "consumerGroup", "partitionId", offset: 10, sequenceNumber: 20)), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName", "consumerGroup1", "partitionId", 10, 20));

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName", "consumerGroup2", "partitionId", 10, 20));

                IEnumerable<Checkpoint> storedCheckpointsList1 = await partitionManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup1");
                IEnumerable<Checkpoint> storedCheckpointsList2 = await partitionManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup2");

                Assert.That(storedCheckpointsList1, Is.Not.Null);
                Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

                Assert.That(storedCheckpointsList2, Is.Not.Null);
                Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName1", "consumerGroup", "partitionId", 10, 20));

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName2", "consumerGroup", "partitionId", 10, 20));

                IEnumerable<Checkpoint> storedCheckpointsList1 = await partitionManager.ListCheckpointsAsync("namespace", "eventHubName1", "consumerGroup");
                IEnumerable<Checkpoint> storedCheckpointsList2 = await partitionManager.ListCheckpointsAsync("namespace", "eventHubName2", "consumerGroup");

                Assert.That(storedCheckpointsList1, Is.Not.Null);
                Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

                Assert.That(storedCheckpointsList2, Is.Not.Null);
                Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherNamespaces()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace1", "eventHubName", "consumerGroup", "partitionId", 10, 20));

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace2", "eventHubName", "consumerGroup", "partitionId", 10, 20));

                IEnumerable<Checkpoint> storedCheckpointsList1 = await partitionManager.ListCheckpointsAsync("namespace1", "eventHubName", "consumerGroup");
                IEnumerable<Checkpoint> storedCheckpointsList2 = await partitionManager.ListCheckpointsAsync("namespace2", "eventHubName", "consumerGroup");

                Assert.That(storedCheckpointsList1, Is.Not.Null);
                Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

                Assert.That(storedCheckpointsList2, Is.Not.Null);
                Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Processor.BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);

                var partitionManager = new Processor.BlobsCheckpointStore(containerClient);

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName", "consumerGroup", "partitionId1", 10, 20));

                await partitionManager.UpdateCheckpointAsync(new MockCheckpoint
                    ("namespace", "eventHubName", "consumerGroup", "partitionId2", 10, 20));

                IEnumerable<Checkpoint> storedCheckpointsList = await partitionManager.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup");

                Assert.That(storedCheckpointsList, Is.Not.Null);
                Assert.That(storedCheckpointsList.Count, Is.EqualTo(2));

                Checkpoint storedCheckpoint1 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId1");
                Checkpoint storedCheckpoint2 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId2");

                Assert.That(storedCheckpoint1, Is.Not.Null);

                Assert.That(storedCheckpoint2, Is.Not.Null);
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
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this partition ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
            /// <param name="eTag">The entity tag needed to update this ownership.</param>
            ///
            public MockPartitionOwnership(string fullyQualifiedNamespace,
                                          string eventHubName,
                                          string consumerGroup,
                                          string ownerIdentifier,
                                          string partitionId,
                                          DateTimeOffset? lastModifiedTime = null,
                                          string eTag = null) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier, partitionId, lastModifiedTime, eTag)
            {
            }
        }

        /// <summary>
        ///   A workaround so we can create <see cref="Checkpoint" /> instances.
        /// </summary>
        ///
        private class MockCheckpoint : Checkpoint
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="MockPartitionOwnership"/> class.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            ///
            public MockCheckpoint(string fullyQualifiedNamespace,
                                  string eventHubName,
                                  string consumerGroup,
                                  string partitionId,
                                  long offset,
                                  long sequenceNumber) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId, offset, sequenceNumber)
            {
            }
        }
    }
}
