// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BlobCheckpointStoreInternal" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class BlobCheckpointStoreInternalDiagnosticsTests
    {
        private const string FullyQualifiedNamespace = "fqns";
        private const string EventHubName = "name";
        private const string ConsumerGroup = "group";
        private const string Identifier = "id";
        private const string MatchingEtag = "etag";
        private const string WrongEtag = "wrongEtag";
        private const string PartitionId = "1";

        private readonly string OwnershipIdentifier = Guid.NewGuid().ToString();

        /// <summary>
        ///   Verifies basic functionality of ListOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipLogsStartAndComplete()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, CancellationToken.None);

            mockLog.Verify(m => m.ListOwnershipStart(FullyQualifiedNamespace, EventHubName, ConsumerGroup));
            mockLog.Verify(m => m.ListOwnershipComplete(FullyQualifiedNamespace, EventHubName, ConsumerGroup, blobList.Count));
        }

        /// <summary>
        ///   Verifies basic functionality of ListOwnershipAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void ListOwnershipLogsErrorOnException()
        {
            var ex = new RequestFailedException(0, "foo", BlobErrorCode.ContainerNotFound.ToString(), null);
            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient(getBlobsAsyncException: ex));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, CancellationToken.None), Throws.InstanceOf<RequestFailedException>());
            mockLog.Verify(m => m.ListOwnershipError(FullyQualifiedNamespace, EventHubName, ConsumerGroup, ex.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate logging.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipLogsStartAndComplete()
        {
            var partitionOwnership = new List<EventProcessorPartitionOwnership>
            {
                new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    EventHubName = EventHubName,
                    ConsumerGroup = ConsumerGroup,
                    OwnerIdentifier = OwnershipIdentifier,
                    PartitionId = PartitionId,
                    LastModifiedTime = DateTime.UtcNow
                }
            };

            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/1", _ => { });
            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None);
            mockLog.Verify(m => m.ClaimOwnershipStart(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier));
            mockLog.Verify(m => m.ClaimOwnershipComplete(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate logging.
        /// </summary>
        ///
        [Test]
        public void ClaimOwnershipLogsErrors()
        {
            var partitionOwnership = new List<EventProcessorPartitionOwnership>
            {
                new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    EventHubName = EventHubName,
                    ConsumerGroup = ConsumerGroup,
                    OwnerIdentifier = OwnershipIdentifier,
                    PartitionId = PartitionId,
                    LastModifiedTime = DateTime.UtcNow
                }
            };

            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<BlobEventStoreEventSource>();
            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/1", client => client.UploadBlobException = expectedException);

            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(m => m.ClaimOwnershipError(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, expectedException.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipForNewPartitionLogsOwnershipClaimed()
        {
            var partitionOwnership = new List<EventProcessorPartitionOwnership>
            {
                new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    EventHubName = EventHubName,
                    ConsumerGroup = ConsumerGroup,
                    OwnerIdentifier = OwnershipIdentifier,
                    PartitionId = PartitionId,
                    LastModifiedTime = DateTime.UtcNow
                }
            };

            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/1", _ => { });
            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None);
            mockLog.Verify(m => m.OwnershipClaimed(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipForExistingPartitionLogsOwnershipClaimed()
        {
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{MatchingEtag}"""), DateTime.UtcNow);

            var partitionOwnership = new List<EventProcessorPartitionOwnership>
            {
                new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    EventHubName = EventHubName,
                    ConsumerGroup = ConsumerGroup,
                    OwnerIdentifier = OwnershipIdentifier,
                    PartitionId = PartitionId,
                    LastModifiedTime = DateTime.UtcNow,
                    Version = MatchingEtag
                }
            };

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/1", client => client.BlobInfo = blobInfo);
            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None);
            mockLog.Verify(m => m.OwnershipClaimed(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipForExistingPartitionWithWrongEtagLogsOwnershipNotClaimable()
        {
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{WrongEtag}"""), DateTime.UtcNow);

            var partitionOwnership = new List<EventProcessorPartitionOwnership>
            {
                new EventProcessorPartitionOwnership
                {
                    FullyQualifiedNamespace = FullyQualifiedNamespace,
                    EventHubName = EventHubName,
                    ConsumerGroup = ConsumerGroup,
                    OwnerIdentifier = OwnershipIdentifier,
                    PartitionId = PartitionId,
                    LastModifiedTime = DateTime.UtcNow,
                    Version = MatchingEtag
                }
            };

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/1", client => client.BlobInfo = blobInfo);
            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None);
            mockLog.Verify(m => m.OwnershipNotClaimable(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, It.Is<string>(e => e.Contains(BlobErrorCode.ConditionNotMet.ToString()))));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsStartAndCompleteWhenTheBlobExists()
        {
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{MatchingEtag}"""), DateTime.UtcNow);

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };

            var mockContainerClient = new MockBlobContainerClient() { Blobs = blobList };

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/1", client =>
            {
                client.BlobInfo = blobInfo;
                client.UploadBlobException = new Exception("Upload should not be called");
            });

            var target = new BlobCheckpointStoreInternal(mockContainerClient);

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var expectedSequenceNumber = 0;
            await target.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, Identifier, new CheckpointPosition(expectedSequenceNumber), CancellationToken.None);
            mockLog.Verify(log => log.UpdateCheckpointStart(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, expectedSequenceNumber.ToString(), "-1", string.Empty));
            mockLog.Verify(log => log.UpdateCheckpointComplete(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, expectedSequenceNumber.ToString(), "-1", string.Empty));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsStartAndCompleteWhenTheBlobDoesNotExist()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };
            var mockBlobContainerClient = new MockBlobContainerClient() { Blobs = blobList };
            mockBlobContainerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/1", _ => { });

            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var expectedSequenceNumber = 0;

            await target.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, Identifier, new CheckpointPosition(expectedSequenceNumber), CancellationToken.None);
            mockLog.Verify(log => log.UpdateCheckpointStart(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, expectedSequenceNumber.ToString(), "-1", string.Empty));
            mockLog.Verify(log => log.UpdateCheckpointComplete(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, expectedSequenceNumber.ToString(), "-1", string.Empty));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate logs are written
        ///   when exceptions occur.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointLogsErrorsWhenTheBlobExists()
        {
            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<BlobEventStoreEventSource>();

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/1", client =>
            {
                client.BlobClientSetMetadataException = expectedException;
                client.UploadBlobException = new Exception("Upload should not be called");
            });

            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            target.Logger = mockLog.Object;

            var expectedSequenceNumber = 456;
            Assert.That(async () => await target.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, Identifier, new CheckpointPosition(expectedSequenceNumber), CancellationToken.None), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(log => log.UpdateCheckpointError(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, expectedException.Message, expectedSequenceNumber.ToString(), "-1", string.Empty));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate logs are written
        ///   when exceptions occur.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointLogsErrorsWhenTheBlobDoesNotExist()
        {
            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<BlobEventStoreEventSource>();

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/1", client =>
            {
                client.UploadBlobException = expectedException;
            });

            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            target.Logger = mockLog.Object;

            var expectedSequenceNumber = 6;
            Assert.That(async () => await target.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, Identifier, new CheckpointPosition(expectedSequenceNumber), CancellationToken.None), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(log => log.UpdateCheckpointError(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, expectedException.Message, expectedSequenceNumber.ToString(), "-1", string.Empty));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointForMissingContainerLogsCheckpointUpdateError()
        {
            var ex = new RequestFailedException(404, BlobErrorCode.ContainerNotFound.ToString(), BlobErrorCode.ContainerNotFound.ToString(), null);
            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/1", client => client.UploadBlobException = ex);
            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var expectedSequenceNumber = 999;
            Assert.That(async () => await target.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, Identifier, new CheckpointPosition(expectedSequenceNumber), CancellationToken.None), Throws.InstanceOf<RequestFailedException>());
            mockLog.Verify(m => m.UpdateCheckpointError(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, ex.Message, expectedSequenceNumber.ToString(), "-1", string.Empty));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointLogsStartAndComplete()
        {
            var clientIdentifier = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.ClientIdentifier, clientIdentifier},
                                               {BlobMetadataKey.SequenceNumber, "10"}
                                           })
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            mockLog.Verify(m => m.GetCheckpointStart(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0"));
            mockLog.Verify(m => m.GetCheckpointComplete(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", clientIdentifier, It.IsAny<DateTimeOffset>()));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted when errors occur.
        /// </summary>
        ///
        [Test]
        public void GetCheckpointLogsErrors()
        {
            var expectedException = new DllNotFoundException("BOOM!");
            var mockContainerClient = new MockBlobContainerClient() { GetBlobsAsyncException = expectedException };
            var target = new BlobCheckpointStoreInternal(mockContainerClient);

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/0", client =>
            {
                client.GetPropertiesException = expectedException;
            });

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(m => m.GetCheckpointError(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", expectedException.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointLogsInvalidCheckpoint()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };
            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });

            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);
            mockLog.Verify(m => m.InvalidCheckpointFound("0", FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        private class MockBlobContainerClient : BlobContainerClient
        {
            public override Uri Uri { get; }
            public override string AccountName { get; }
            public override string Name { get; }
            internal IEnumerable<BlobItem> Blobs;
            internal Exception GetBlobsAsyncException;
            internal Dictionary<string, MockBlobClient> BlobClients = new();

            public MockBlobContainerClient(string accountName = "blobAccount",
                                           string containerName = "container",
                                           Exception getBlobsAsyncException = null)
            {
                GetBlobsAsyncException = getBlobsAsyncException;
                Blobs = Enumerable.Empty<BlobItem>();
                AccountName = accountName;
                Name = containerName;
                Uri = new Uri("https://foo");
            }
            public override AsyncPageable<BlobItem> GetBlobsAsync(BlobTraits traits = BlobTraits.None, BlobStates states = BlobStates.None, string prefix = null, CancellationToken cancellationToken = default)
            {
                if (GetBlobsAsyncException != null)
                {
                    throw GetBlobsAsyncException;
                }

                return new MockAsyncPageable<BlobItem>(Blobs.Where(b => prefix == null || b.Name.StartsWith(prefix, StringComparison.Ordinal)));
            }

            public override BlobClient GetBlobClient(string blobName)
            {
                if (BlobClients.TryGetValue(blobName, out var client))
                {
                    return client;
                }

                var blob = Blobs.SingleOrDefault(c => c.Name == blobName);
                if (blob != null)
                {
                    return new MockBlobClient(blobName)
                    {
                        Properties = BlobsModelFactory.BlobProperties(metadata: blob.Metadata)
                    };
                }

                return new MockBlobClient(blobName);
            }

            internal MockBlobContainerClient AddBlobClient(string name, Action<MockBlobClient> configure)
            {
                var client = new MockBlobClient(name);
                configure(client);
                BlobClients[name] = client;
                return this;
            }
        }

        private class MockBlobClient : BlobClient
        {
            public override string Name { get; }

            internal BlobInfo BlobInfo;
            internal BlobProperties Properties;
            internal Exception UploadBlobException;
            internal Exception BlobClientSetMetadataException;
            internal DllNotFoundException GetPropertiesException;
            public MockBlobClient(string blobName)
            {
                Name = blobName;
            }

            public override Task<Response<BlobInfo>> SetMetadataAsync(IDictionary<string, string> metadata, BlobRequestConditions conditions = null, CancellationToken cancellationToken = default)
            {
                if (BlobClientSetMetadataException != null)
                {
                    throw BlobClientSetMetadataException;
                }

                if (BlobInfo == null)
                {
                    throw new RequestFailedException(404, BlobErrorCode.BlobNotFound.ToString(), BlobErrorCode.BlobNotFound.ToString(), default);
                }

                if ((conditions == null) || (BlobInfo.ETag.Equals($@"""{conditions.IfMatch}""")))
                {
                    return Task.FromResult(Response.FromValue(BlobInfo, Mock.Of<Response>()));
                }

                throw new RequestFailedException(412, BlobErrorCode.ConditionNotMet.ToString(), BlobErrorCode.ConditionNotMet.ToString(), default);
            }

            public override Task<Response<BlobContentInfo>> UploadAsync(Stream content, BlobHttpHeaders httpHeaders = null, IDictionary<string, string> metadata = null, BlobRequestConditions conditions = null, IProgress<long> progressHandler = null, AccessTier? accessTier = null, StorageTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
            {
                if (UploadBlobException != null)
                {
                    throw UploadBlobException;
                }

                if (BlobInfo != null)
                {
                    throw new RequestFailedException(409, BlobErrorCode.BlobAlreadyExists.ToString(), BlobErrorCode.BlobAlreadyExists.ToString(), default);
                }

                return Task.FromResult(
                    Response.FromValue(
                        BlobsModelFactory.BlobContentInfo(new ETag("etag"), DateTime.UtcNow, new byte[] { }, string.Empty, 0L),
                        Mock.Of<Response>()));
            }

            public override Task<Response> DownloadToAsync(Stream destination, CancellationToken cancellationToken) => Task.FromResult(Mock.Of<Response>());

            public override Task<Response<BlobProperties>> GetPropertiesAsync(BlobRequestConditions conditions = null, CancellationToken cancellationToken = default)
            {
                if (GetPropertiesException != null)
                {
                    throw GetPropertiesException;
                }

                if (Properties == null)
                {
                    throw new RequestFailedException(404, BlobErrorCode.BlobNotFound.ToString(), BlobErrorCode.BlobNotFound.ToString(), default);
                }

                return Task.FromResult(Response.FromValue(Properties, Mock.Of<Response>()));
            }
        }

        private class MockAsyncPageable<T> : AsyncPageable<T>
        {
            private readonly IEnumerable<T> Items;

            internal MockAsyncPageable(IEnumerable<T> items)
            {
                Items = items;
            }
            public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                return CratePageResponse(Items);
            }

            internal async IAsyncEnumerable<Page<P>> CratePageResponse<P>(IEnumerable<P> value)
            {
                await Task.Delay(0);
                yield return new MockPage<P>(value);
            }
        }

        private class MockPage<T> : Page<T>
        {
            private readonly IReadOnlyList<T> InnerValues;
            public override IReadOnlyList<T> Values => InnerValues;

            public override string ContinuationToken => throw new NotImplementedException();

            public override Response GetRawResponse() => throw new NotImplementedException();

            public MockPage(IEnumerable<T> items)
            {
                InnerValues = items.ToList().AsReadOnly();
            }
        }
    }
}
