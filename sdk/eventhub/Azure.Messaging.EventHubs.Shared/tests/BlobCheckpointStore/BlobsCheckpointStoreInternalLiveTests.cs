// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="BlobCheckpointStoreInternal" />
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
    public class BlobsCheckpointStoreInternalLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="BlobCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        public async Task BlobStorageManagerCanListOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                Assert.That(async () => await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="BlobCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        public async Task BlobStorageManagerCanGetACheckpoint()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                Assert.That(async () => await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partition", default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="BlobCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("ETag")]
        public async Task BlobStorageManagerCanClaimOwnership(string version)
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var ownershipList = new List<EventProcessorPartitionOwnership>
                {
                    // Null version and non-null version hit different paths of the code, calling different methods that connect
                    // to the Storage service.

                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = "namespace",
                        EventHubName = "eventHubName",
                        ConsumerGroup = "consumerGroup",
                        OwnerIdentifier = "ownerIdentifier",
                        PartitionId = "partitionId",
                        Version = version
                    }
                };

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(ownershipList, default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="BlobCheckpointStore" /> is able to
        ///   connect to the Storage service.
        /// </summary>
        ///
        [Test]
        public async Task BlobStorageManagerCanUpdateCheckpoint()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var ownershipList = new List<EventProcessorPartitionOwnership>
                {
                    // Make sure the ownership exists beforehand so we hit all storage SDK calls in the checkpoint store.

                    new EventProcessorPartitionOwnership
                    {
                        FullyQualifiedNamespace = "namespace",
                        EventHubName = "eventHubName",
                        ConsumerGroup = "consumerGroup",
                        OwnerIdentifier = "ownerIdentifier",
                        PartitionId = "partitionId"
                    }
                };

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);
                Assert.That(async () => await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId", "Id", new CheckpointPosition(10), default), Throws.Nothing);
                Assert.That(async () => await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId", 0, 10, default), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncReturnsEmptyIEnumerableWhenThereAreNoOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
                var ownership = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(ownership, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointAsyncReturnsNullIfNoCheckpointExists()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
                var checkpoints = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partition", default);

                Assert.That(checkpoints, Is.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointDetectsWhenTheContainerDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, $"test-container-{Guid.NewGuid()}");
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                Assert.That(async () => await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partition", default), Throws.Exception);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task FirstOwnershipClaimSucceeds()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
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
                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

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

                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
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

                var claimedOwnership = await checkpointStore.ClaimOwnershipAsync(ownershipList, default);
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);
                var claimedOwnershipMatch = s_doubleQuotesExpression.Match(claimedOwnership.First().Version);
                var storedOwnershipListMatch = s_doubleQuotesExpression.Match(storedOwnershipList.First().Version);

                Assert.That(claimedOwnershipMatch.Success, Is.False);
                Assert.That(storedOwnershipListMatch.Success, Is.False);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSetsLastModifiedTimeAndVersion()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
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
                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                Assert.That(ownership.LastModifiedTime, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(ownership.LastModifiedTime, Is.GreaterThan(DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(5))));
                Assert.That(ownership.Version, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("invalidETag")]
        public async Task OwnershipClaimFailsWhenVersionIsInvalid(string version)
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var firstOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId"
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { firstOwnership }, default);

                var secondOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId",
                    Version = version
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { secondOwnership }, default);
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimFailsWhenVersionExistsAndOwnershipDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var eTaggyOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId",
                    Version = "ETag"
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { eTaggyOwnership }, default);
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null.And.Empty);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimSucceedsWhenVersionIsValid()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var firstOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId"
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { firstOwnership }, default);

                // The first ownership's version should have been set by the checkpoint store.

                var secondOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId",
                    Version = firstOwnership.Version
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { secondOwnership }, default);
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(secondOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncCanClaimMultipleOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
                var ownershipList = new List<EventProcessorPartitionOwnership>();
                var ownershipCount = 5;

                for (var i = 0; i < ownershipCount; i++)
                {
                    ownershipList.Add(
                        new EventProcessorPartitionOwnership
                        {
                            FullyQualifiedNamespace = "namespace",
                            EventHubName = "eventHubName",
                            ConsumerGroup = "consumerGroup",
                            OwnerIdentifier = "ownerIdentifier",
                            PartitionId = $"partitionId {i}"
                        });
                }

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(ownershipCount));

                var index = 0;

                foreach (EventProcessorPartitionOwnership ownership in storedOwnershipList.OrderBy(ownership => ownership.PartitionId))
                {
                    Assert.That(ownership.IsEquivalentTo(ownershipList[index]), Is.True, $"Ownership of partition '{ ownership.PartitionId }' should be equivalent.");
                    ++index;
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncReturnsOnlyTheSuccessfullyClaimedOwnership()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);
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
                            PartitionId = $"{i}"
                        });
                }

                await checkpointStore.ClaimOwnershipAsync(ownershipList, default);

                // The versions must have been set by the checkpoint store.

                var versions = ownershipList.Select(ownership => ownership.Version).ToList();
                ownershipList.Clear();

                // Use a valid eTag when 'i' is odd.  This way, we can expect 'ownershipCount / 2' successful
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
                            PartitionId = $"{i}",
                            Version = i % 2 == 1 ? versions[i] : null
                        });
                }

                var claimedOwnershipList = await checkpointStore.ClaimOwnershipAsync(ownershipList, default);
                var expectedOwnership = ownershipList.Where(ownership => int.Parse(ownership.PartitionId) % 2 == 1);

                Assert.That(claimedOwnershipList, Is.Not.Null);
                Assert.That(claimedOwnershipList.Count, Is.EqualTo(expectedClaimedCount));

                var index = 0;

                foreach (EventProcessorPartitionOwnership ownership in claimedOwnershipList.OrderBy(ownership => ownership.PartitionId))
                {
                    Assert.That(ownership.IsEquivalentTo(expectedOwnership.ElementAt(index)), Is.True, $"Ownership of partition '{ ownership.PartitionId }' should be equivalent.");
                    ++index;
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherConsumerGroups()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var firstOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup1",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId"
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { firstOwnership }, default);

                // The first ownership's version should have been set by the checkpoint store.

                var secondOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup2",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId",
                    Version = firstOwnership.Version
                };

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new[] { secondOwnership }, default), Throws.InstanceOf<RequestFailedException>());
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup1", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherEventHubs()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var firstOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName1",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId"
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { firstOwnership }, default);

                // The first ownership's version should have been set by the checkpoint store.

                var secondOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName2",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId",
                    Version = firstOwnership.Version
                };

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new[] { secondOwnership }, default), Throws.InstanceOf<RequestFailedException>());
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace", "eventHubName1", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OwnershipClaimDoesNotInterfereWithOtherNamespaces()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var firstOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace1",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId"
                };

                await checkpointStore.ClaimOwnershipAsync(new[] { firstOwnership }, default);

                // The first ownership's version should have been set by the checkpoint store.

                var secondOwnership = new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = "namespace2",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    OwnerIdentifier = "ownerIdentifier",
                    PartitionId = "partitionId",
                    Version = firstOwnership.Version
                };

                Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new[] { secondOwnership }, default), Throws.InstanceOf<RequestFailedException>());
                var storedOwnershipList = await checkpointStore.ListOwnershipAsync("namespace1", "eventHubName", "consumerGroup", default);

                Assert.That(storedOwnershipList, Is.Not.Null);
                Assert.That(storedOwnershipList.Count, Is.EqualTo(1));
                Assert.That(storedOwnershipList.Single().IsEquivalentTo(firstOwnership), Is.True);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipFailsWhenContainerDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, $"test-container-{Guid.NewGuid()}");
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                Assert.That(async () => await checkpointStore.ListOwnershipAsync("namespace", "eventHubName", "consumerGroup", default), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateFailsWhenContainerDoesNotExist()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, $"test-container-{Guid.NewGuid()}");
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                Assert.That(async () => await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId", "Id", new CheckpointPosition(10), default), Throws.InstanceOf<RequestFailedException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateCreatesTheBlobOnFirstCall()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var checkpoint = new EventProcessorCheckpoint
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    PartitionId = "partitionId",
                    ClientIdentifier = "Id"
                };

                var mockEvent = new MockEventData(
                    eventBody: Array.Empty<byte>(),
                    offset: 10,
                    sequenceNumber: 20);

                // There should be no blobs or checkpoints before the first call.

                var blobCount = 0;
                var storedCheckpoint = await checkpointStore.GetCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, default);

                await foreach (var blob in containerClient.GetBlobsAsync())
                {
                    ++blobCount;
                    break;
                }

                Assert.That(blobCount, Is.EqualTo(0));
                Assert.That(storedCheckpoint, Is.Null);

                // Calling update should create the checkpoint.

                await checkpointStore.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, new CheckpointPosition(mockEvent.SequenceNumber), default);
                storedCheckpoint = await checkpointStore.GetCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, default);

                Assert.That(storedCheckpoint, Is.Not.Null);
                Assert.That(storedCheckpoint.StartingPosition, Is.EqualTo(EventPosition.FromSequenceNumber(mockEvent.SequenceNumber, false)));
                Assert.That(storedCheckpoint.ClientIdentifier, Is.EqualTo("Id"));

                // There should be a single blob in the container.

                blobCount = 0;

                await foreach (var blob in containerClient.GetBlobsAsync())
                {
                    ++blobCount;

                    if (blobCount > 1)
                    {
                        break;
                    }
                }

                Assert.That(blobCount, Is.EqualTo(1));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdatesAnExistingBlob()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                var checkpoint = new EventProcessorCheckpoint
                {
                    FullyQualifiedNamespace = "namespace",
                    EventHubName = "eventHubName",
                    ConsumerGroup = "consumerGroup",
                    PartitionId = "partitionId",
                    ClientIdentifier = "Id"
                };

                var mockEvent = new MockEventData(
                    eventBody: Array.Empty<byte>(),
                    offset: 10,
                    sequenceNumber: 20);

                // Calling update should create the checkpoint.

                await checkpointStore.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, new CheckpointPosition(mockEvent.SequenceNumber), default);

                var blobCount = 0;
                var storedCheckpoint = await checkpointStore.GetCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, default);

                await foreach (var blob in containerClient.GetBlobsAsync())
                {
                    ++blobCount;

                    if (blobCount > 1)
                    {
                        break;
                    }
                }

                Assert.That(blobCount, Is.EqualTo(1));
                Assert.That(storedCheckpoint, Is.Not.Null);
                Assert.That(storedCheckpoint.StartingPosition, Is.EqualTo(EventPosition.FromSequenceNumber(mockEvent.SequenceNumber, false)));
                Assert.That(storedCheckpoint.ClientIdentifier, Is.EqualTo("Id"));

                // Calling update again should update the existing checkpoint.

                mockEvent = new MockEventData(
                    eventBody: Array.Empty<byte>(),
                    offset: 50,
                    sequenceNumber: 60);

                await checkpointStore.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, new CheckpointPosition(mockEvent.SequenceNumber), default);

                blobCount = 0;
                storedCheckpoint = await checkpointStore.GetCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, default);

                await foreach (var blob in containerClient.GetBlobsAsync())
                {
                    ++blobCount;

                    if (blobCount > 1)
                    {
                        break;
                    }
                }

                Assert.That(blobCount, Is.EqualTo(1));
                Assert.That(storedCheckpoint, Is.Not.Null);
                Assert.That(storedCheckpoint.StartingPosition, Is.EqualTo(EventPosition.FromSequenceNumber(mockEvent.SequenceNumber, false)));
                Assert.That(storedCheckpoint.ClientIdentifier, Is.EqualTo("Id"));
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherConsumerGroups()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup1", "partitionId", "Id", new CheckpointPosition(20), default);
                await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup2", "partitionId", "Id", new CheckpointPosition(20), default);

                var storedCheckpoint1 = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup1", "partitionId", default);
                var storedCheckpoint2 = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup2", "partitionId", default);

                Assert.That(storedCheckpoint1, Is.Not.Null);
                Assert.That(storedCheckpoint2, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherEventHubs()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName1", "consumerGroup", "partitionId", "Id", new CheckpointPosition(20), default);
                await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName2", "consumerGroup", "partitionId", "Id", new CheckpointPosition(20), default);

                var storedCheckpoint1 = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName1", "consumerGroup", "partitionId", default);
                var storedCheckpoint2 = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName2", "consumerGroup", "partitionId", default);

                Assert.That(storedCheckpoint1, Is.Not.Null);
                Assert.That(storedCheckpoint2, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherNamespaces()
        {
            await using (var storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                await checkpointStore.UpdateCheckpointAsync("namespace1", "eventHubName", "consumerGroup", "partitionId", "Id", new CheckpointPosition(20), default);
                await checkpointStore.UpdateCheckpointAsync("namespace2", "eventHubName", "consumerGroup", "partitionId", "Id", new CheckpointPosition(20), default);

                var storedCheckpoint1 = await checkpointStore.GetCheckpointAsync("namespace1", "eventHubName", "consumerGroup", "partitionId", default);
                var storedCheckpoint2 = await checkpointStore.GetCheckpointAsync("namespace2", "eventHubName", "consumerGroup", "partitionId", default);

                Assert.That(storedCheckpoint1, Is.Not.Null);
                Assert.That(storedCheckpoint2, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CheckpointUpdateDoesNotInterfereWithOtherPartitions()
        {
            await using (StorageScope storageScope = await StorageScope.CreateAsync())
            {
                var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
                var containerClient = new BlobContainerClient(storageConnectionString, storageScope.ContainerName);
                var checkpointStore = new BlobCheckpointStoreInternal(containerClient);

                await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId1", "Id", new CheckpointPosition(20), default);
                await checkpointStore.UpdateCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId2", "Id", new CheckpointPosition(20), default);

                var storedCheckpoint1 = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId1", default);
                var storedCheckpoint2 = await checkpointStore.GetCheckpointAsync("namespace", "eventHubName", "consumerGroup", "partitionId2", default);

                Assert.That(storedCheckpoint1, Is.Not.Null);
                Assert.That(storedCheckpoint2, Is.Not.Null);
            }
        }
    }
}
