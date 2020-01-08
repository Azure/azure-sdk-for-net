// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BlobsCheckpointStore" />
    ///   class.
    /// </summary>
    ///
    public class BlobsCheckpointStoreTests
    {
        private const string FullyQualifiedNamespace = "fqns";
        private const string EventHubName = "name";
        private const string ConsumerGroup = "group";
        private const string MatchingEtag = "etag";
        private const string WrongEtag = "wrongEtag";
        private const string PartitionId = "1";
        private readonly string OwnershipIdentifier = Guid.NewGuid().ToString();

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresBlobContainerClient()
        {
            Assert.That(() => new BlobsCheckpointStore(null, Mock.Of<EventHubsRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresRetryPolicy()
        {
            Assert.That(() => new BlobsCheckpointStore(Mock.Of<BlobContainerClient>(), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies basic functionality of ListOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipLogsStartAndComplete()
        {
            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken());

            mockLog.Verify(m => m.ListOwnershipAsyncStart(FullyQualifiedNamespace, EventHubName, ConsumerGroup));
            mockLog.Verify(m => m.ListOwnershipAsyncComplete(FullyQualifiedNamespace, EventHubName, ConsumerGroup, blobList.Count));
        }

        /// <summary>
        ///   Verifies basic functionality of ListOwnershipAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void ListOwnershipLogsErrorOnException()
        {
            var ex = new RequestFailedException(0, "foo", BlobErrorCode.ContainerNotFound.ToString(), null);

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(getBlobsAsyncException: ex),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.ThrowsAsync<RequestFailedException>(async () => await target.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken()));

            mockLog.Verify(m => m.ListOwnershipAsyncError(FullyQualifiedNamespace, EventHubName, ConsumerGroup, It.Is<string>(e => e.Contains("RequestFailedException"))));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipForNewPartitionLogsOwnershipClaimed()
        {
            var partitionOwnerships = new List<PartitionOwnership>{
                new PartitionOwnership(FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, PartitionId, DateTime.UtcNow, null )
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient(),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnerships, new CancellationToken())).ToList();

            CollectionAssert.AreEquivalent(partitionOwnerships, result);
            mockLog.Verify(m => m.OwnershipClaimed(PartitionId, OwnershipIdentifier));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipForExistingPartitionLogsOwnershipClaimed()
        {
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{MatchingEtag}"""), DateTime.UtcNow);
            var partitionOwnerships = new List<PartitionOwnership>{
                new PartitionOwnership(FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, PartitionId, DateTime.UtcNow, MatchingEtag )
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient { BlobInfo = blobInfo },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnerships, new CancellationToken())).ToList();

            CollectionAssert.AreEquivalent(partitionOwnerships, result);
            mockLog.Verify(m => m.OwnershipClaimed(PartitionId, OwnershipIdentifier));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipForExistingPartitionWithWrongEtagLogsOwnershipNotClaimable()
        {
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{WrongEtag}"""), DateTime.UtcNow);
            var partitionOwnerships = new List<PartitionOwnership>{
                new PartitionOwnership(FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, PartitionId, DateTime.UtcNow, MatchingEtag )
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient { BlobInfo = blobInfo },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnerships, new CancellationToken())).ToList();

            CollectionAssert.IsEmpty(result);
            mockLog.Verify(m => m.OwnershipNotClaimable(PartitionId, OwnershipIdentifier, It.Is<string>(e => e.Contains(BlobErrorCode.ConditionNotMet.ToString()))));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void ClaimOwnershipForMissingPartitionThrowsAndLogsOwnershipNotClaimable()
        {
            var partitionOwnerships = new List<PartitionOwnership>{
                new PartitionOwnership(FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, PartitionId, DateTime.UtcNow, MatchingEtag )
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient(),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.ThrowsAsync<RequestFailedException>(async () => await target.ClaimOwnershipAsync(partitionOwnerships, new CancellationToken()));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsLogsStartAndComplete()
        {
            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken());

            mockLog.Verify(m => m.ListCheckpointsAsyncStart(FullyQualifiedNamespace, EventHubName, ConsumerGroup));
            mockLog.Verify(m => m.ListCheckpointsAsyncComplete(FullyQualifiedNamespace, EventHubName, ConsumerGroup, blobList.Count));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void ListCheckointsForMissingPartitionThrowsAndLogsOwnershipNotClaimable()
        {
            var ex = new RequestFailedException(0, "foo", BlobErrorCode.ContainerNotFound.ToString(), null);

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(getBlobsAsyncException: ex),
                                               new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.ThrowsAsync<RequestFailedException>(async () => await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken()));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsCheckpointUpdated()
        {
            var checkpoint = new Checkpoint(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, 0L, 0L);
            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.UpdateCheckpointAsync(checkpoint, new CancellationToken());

            mockLog.Verify(m => m.CheckpointUpdated(PartitionId));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointForMissingCheckpointThrowsAndLogsCheckpointUpdateError()
        {
            var checkpoint = new Checkpoint(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, 0L, 0L);
            var ex = new RequestFailedException(404, BlobErrorCode.ContainerNotFound.ToString(), BlobErrorCode.ContainerNotFound.ToString(), null);
            var target = new BlobsCheckpointStore(new MockBlobContainerClient(blobClientUploadBlobException: ex),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.ThrowsAsync<RequestFailedException>(async () => await target.UpdateCheckpointAsync(checkpoint, new CancellationToken()));

            mockLog.Verify(m => m.CheckpointUpdateError(PartitionId, It.Is<string>(s => s.Contains(BlobErrorCode.ContainerNotFound.ToString()))));
        }

        private class MockBlobContainerClient : BlobContainerClient
        {
            public override Uri Uri { get; }
            public override string AccountName { get; }
            public override string Name { get; }
            internal IEnumerable<BlobItem> Blobs;
            internal BlobInfo BlobInfo;
            internal Exception BlobClientUploadBlobException;
            internal Exception GetBlobsAsyncException;



            public MockBlobContainerClient(string accountName = "blobAccount",
                                           string containerName = "container",
                                           Exception getBlobsAsyncException = null,
                                           Exception blobClientUploadBlobException = null)
            {
                GetBlobsAsyncException = getBlobsAsyncException;
                BlobClientUploadBlobException = blobClientUploadBlobException;
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
                return new MockAsyncPageable<BlobItem>(Blobs);
            }

            public override BlobClient GetBlobClient(string blobName)
            {
                return new MockBlobClient(blobName, BlobInfo, BlobClientUploadBlobException);
            }
        }

        private class MockBlobClient : BlobClient
        {
            public override string Name { get; }
            internal BlobInfo BlobInfo;
            internal Exception BlobClientUploadBlobException;

            public MockBlobClient(string blobName, BlobInfo blobInfo = null, Exception blobClientUploadBlobException = null)
            {
                BlobClientUploadBlobException = blobClientUploadBlobException;
                Name = blobName;
                BlobInfo = blobInfo;
            }

            public override Task<Response<BlobInfo>> SetMetadataAsync(IDictionary<string, string> metadata, BlobRequestConditions conditions = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (BlobInfo == null)
                {
                    throw new RequestFailedException(404, BlobErrorCode.ContainerNotFound.ToString(), BlobErrorCode.ContainerNotFound.ToString(), default);
                }
                if (BlobInfo.ETag.Equals($@"""{conditions.IfMatch}"""))
                {
                    return Task.FromResult(Response.FromValue(BlobInfo, Mock.Of<Response>()));
                }
                throw new RequestFailedException(412, BlobErrorCode.ConditionNotMet.ToString(), BlobErrorCode.ConditionNotMet.ToString(), default);
            }

            public override Task<Response<BlobContentInfo>> UploadAsync(System.IO.Stream content, BlobHttpHeaders httpHeaders = null, IDictionary<string, string> metadata = null, BlobRequestConditions conditions = null, IProgress<long> progressHandler = null, AccessTier? accessTier = null, Storage.StorageTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
            {
                if (BlobClientUploadBlobException != null)
                {
                    throw BlobClientUploadBlobException;
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

            public override Response GetRawResponse()
            {
                throw new NotImplementedException();
            }

            public MockPage(IEnumerable<T> items)
            {
                InnerValues = items.ToList().AsReadOnly();
            }
        }
    }
}
