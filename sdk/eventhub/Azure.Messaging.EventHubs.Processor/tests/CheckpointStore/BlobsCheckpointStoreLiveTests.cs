// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="BlobsCheckpointStore" />
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
        /// <summary>The default retry policy to use for the test cases in this class.</summary>
        private EventHubsRetryPolicy DefaultRetryPolicy { get; } = new BasicRetryPolicy(new EventHubsRetryOptions());

        /// <summary>
        ///   Verifies that the <see cref="BlobsCheckpointStore" /> is able to
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                Assert.That(async () => await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="BlobsCheckpointStore" /> is able to
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                Assert.That(async () => await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup", default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="BlobsCheckpointStore" /> is able to
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
                var ownershipList = new List<PartitionOwnership>
                {

                    // Null ETag and non-null ETag hit different paths of the code, calling different methods that connect
                    // to the Storage service.

                    new PartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId",
                        eTag: eTag
                    )
                };

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(ownershipList, default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="BlobsCheckpointStore" /> is able to
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
                var ownershipList = new List<PartitionOwnership>
                {

                    // Make sure the ownership exists beforehand so we hit all storage SDK calls in the checkpoint store.

                    new PartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId"
                    )
                };

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                var checkpoint = new Checkpoint("namespace", "eventHubName", "consumerGroup", "partitionId", 10, 20);

                Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(checkpoint, default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
                IEnumerable<PartitionOwnership> ownership = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(ownership, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListCheckpointsAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
                IEnumerable<Checkpoint> checkpoints = await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(checkpoints, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                IEnumerable<PartitionOwnership> claimedOwnership = await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                var claimedOwnershipMatch = s_doubleQuotesExpression.Match(claimedOwnership.First().ETag);
                var storedOwnershipListMatch = s_doubleQuotesExpression.Match(storedOwnershipList.First().ETag);

                Assert.That(claimedOwnershipMatch.Success, Is.False);
                Assert.That(storedOwnershipListMatch.Success, Is.False);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                Assert.That(ownership.LastModifiedTime, Is.Not.Null);
                Assert.That(ownership.LastModifiedTime.Value, Is.GreaterThan(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(5))));

                Assert.That(ownership.ETag, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
                var ownershipList = new List<PartitionOwnership>();

                var eTaggyOwnership =
                    new PartitionOwnership
                    (
                        "namespace",
                        "eventHubName",
                        "consumerGroup",
                        "ownerIdentifier",
                        "partitionId",
                        eTag: "ETag"
                    );

                ownershipList.Add(eTaggyOwnership);

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                // ETag must have been set by the checkpoint store.

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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(secondOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

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
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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
                            partitionId: $"{i}"
                        ));
                }

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                // The ETags must have been set by the checkpoint store.

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
                            partitionId: $"{i}",
                            eTag: i % 2 == 1 ? eTags[i] : null
                        ));
                }

                IEnumerable<PartitionOwnership> claimedOwnershipList = await checkpointStore.ClaimOwnershipAsync(ownershipList, default);
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
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                // ETag must have been set by the checkpoint store.

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

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(ownershipList, default), Throws.InstanceOf<RequestFailedException>());

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup1", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                // ETag must have been set by the checkpoint store.

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

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(ownershipList, default), Throws.InstanceOf<RequestFailedException>());

                IEnumerable<PartitionOwnership> storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName1", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);
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

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                // ETag must have been set by the checkpoint store.

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

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(ownershipList, default), Throws.InstanceOf<RequestFailedException>());

                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace1", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                Assert.That(async () => await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                Assert.That(async () => await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup", default), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName", "consumerGroup", "partitionId", offset: 10, sequenceNumber: 20), default), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName", "consumerGroup1", "partitionId", 10, 20), default);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName", "consumerGroup2", "partitionId", 10, 20), default);

                IEnumerable<Checkpoint> storedCheckpointsList1 = await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup1", default);
                IEnumerable<Checkpoint> storedCheckpointsList2 = await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup2", default);

                Assert.That(storedCheckpointsList1, Is.Not.Null);
                Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

                Assert.That(storedCheckpointsList2, Is.Not.Null);
                Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName1", "consumerGroup", "partitionId", 10, 20), default);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName2", "consumerGroup", "partitionId", 10, 20), default);

                IEnumerable<Checkpoint> storedCheckpointsList1 = await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName1", "consumerGroup", default);
                IEnumerable<Checkpoint> storedCheckpointsList2 = await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName2", "consumerGroup", default);

                Assert.That(storedCheckpointsList1, Is.Not.Null);
                Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

                Assert.That(storedCheckpointsList2, Is.Not.Null);
                Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace1", "eventHubName", "consumerGroup", "partitionId", 10, 20), default);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace2", "eventHubName", "consumerGroup", "partitionId", 10, 20), default);

                IEnumerable<Checkpoint> storedCheckpointsList1 = await checkpointStore.ListCheckpointsAsync("namespace1", "eventHubName", "consumerGroup", default);
                IEnumerable<Checkpoint> storedCheckpointsList2 = await checkpointStore.ListCheckpointsAsync("namespace2", "eventHubName", "consumerGroup", default);

                Assert.That(storedCheckpointsList1, Is.Not.Null);
                Assert.That(storedCheckpointsList1.Count, Is.EqualTo(1));

                Assert.That(storedCheckpointsList2, Is.Not.Null);
                Assert.That(storedCheckpointsList2.Count, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
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

                var checkpointStore = new BlobsCheckpointStore(containerClient, DefaultRetryPolicy);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName", "consumerGroup", "partitionId1", 10, 20), default);

                await checkpointStore.UpdateCheckpointAsync(new Checkpoint
                    ("namespace", "eventHubName", "consumerGroup", "partitionId2", 10, 20), default);

                IEnumerable<Checkpoint> storedCheckpointsList = await checkpointStore.ListCheckpointsAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedCheckpointsList, Is.Not.Null);
                Assert.That(storedCheckpointsList.Count, Is.EqualTo(2));

                Checkpoint storedCheckpoint1 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId1");
                Checkpoint storedCheckpoint2 = storedCheckpointsList.First(checkpoint => checkpoint.PartitionId == "partitionId2");

                Assert.That(storedCheckpoint1, Is.Not.Null);
                Assert.That(storedCheckpoint2, Is.Not.Null);
            }
        }
    }
}
