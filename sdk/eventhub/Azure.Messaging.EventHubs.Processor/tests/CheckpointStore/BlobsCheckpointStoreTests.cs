﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage;
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
        ///   Provides the test cases for non-fatal exceptions that are not retriable
        ///   when encountered in a subscription.
        /// </summary>
        ///
        public static IEnumerable<object[]> NonFatalNotRetriableExceptionTestCases()
        {
            yield return new object[] { new InvalidOperationException() };
            yield return new object[] { new NotSupportedException() };
            yield return new object[] { new NullReferenceException() };
            yield return new object[] { new ObjectDisposedException("dummy") };
        }

        /// <summary>
        ///   Provides the test cases for non-fatal exceptions that are retriable
        ///   when encountered in a subscription.
        /// </summary>
        ///
        public static IEnumerable<object[]> NonFatalRetriableExceptionTestCases()
        {
            yield return new object[] { new TimeoutException() };
        }

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

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(getBlobsAsyncException: ex),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken()), Throws.InstanceOf<RequestFailedException>());
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

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, new CancellationToken())).ToList();

            CollectionAssert.AreEquivalent(partitionOwnership, result);
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
            var mockContainerClient = new MockBlobContainerClient() { BlobClientUploadBlobException = expectedException };
            var target = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ClaimOwnershipAsync(partitionOwnership, new CancellationToken()), Throws.Exception.EqualTo(expectedException));
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

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, new CancellationToken())).ToList();

            CollectionAssert.AreEquivalent(partitionOwnership, result);
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

            var target = new BlobsCheckpointStore(new MockBlobContainerClient { BlobInfo = blobInfo },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, new CancellationToken())).ToList();

            CollectionAssert.AreEquivalent(partitionOwnership, result);
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

            var target = new BlobsCheckpointStore(new MockBlobContainerClient { BlobInfo = blobInfo },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, new CancellationToken())).ToList();

            CollectionAssert.IsEmpty(result);
            mockLog.Verify(m => m.OwnershipNotClaimable(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, It.Is<string>(e => e.Contains(BlobErrorCode.ConditionNotMet.ToString()))));
        }

        /// <summary>
        ///   Verifies basic functionality of ClaimOwnershipAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void ClaimOwnershipForMissingPartitionThrowsAndLogsOwnershipNotClaimable()
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
                    LastModifiedTime = DateTime.UtcNow,
                    Version = MatchingEtag
                }
            };

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ClaimOwnershipAsync(partitionOwnership, new CancellationToken()), Throws.InstanceOf<RequestFailedException>());
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsLogsStartAndComplete()
        {
            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, "0"}
                                           })
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList },
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken());

            mockLog.Verify(m => m.ListCheckpointsStart(FullyQualifiedNamespace, EventHubName, ConsumerGroup));
            mockLog.Verify(m => m.ListCheckpointsComplete(FullyQualifiedNamespace, EventHubName, ConsumerGroup, blobList.Count));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsUsesOffsetAsTheStartingPositionWhenPresent()
        {
            var expectedOffset = 13;
            var expectedStartingPosition = EventPosition.FromOffset(expectedOffset, false);

            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, expectedOffset.ToString()},
                                               {BlobMetadataKey.SequenceNumber, "7777"}
                                           })
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList }, new BasicRetryPolicy(new EventHubsRetryOptions()));
            var checkpoints = await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken());

            Assert.That(checkpoints, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoints.Single().StartingPosition, Is.EqualTo(expectedStartingPosition));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsUsesSequenceNumberAsTheStartingPositionWhenNoOffsetIsPresent()
        {
            var expectedSequence = 133;
            var expectedStartingPosition = EventPosition.FromSequenceNumber(expectedSequence, false);

            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.SequenceNumber, expectedSequence.ToString()}
                                           })
            };
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList }, new BasicRetryPolicy(new EventHubsRetryOptions()));
            var checkpoints = await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken());

            Assert.That(checkpoints, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoints.Single().StartingPosition, Is.EqualTo(expectedStartingPosition));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsConsidersDataInvalidWithNoOffsetOrSequenceNumber()
        {
            var partitionId = "67";

            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/{partitionId}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}
                                           })
            };

            var mockLogger = new Mock<BlobEventStoreEventSource>();
            var target = new BlobsCheckpointStore(new MockBlobContainerClient() { Blobs = blobList }, new BasicRetryPolicy(new EventHubsRetryOptions()));

            target.Logger = mockLogger.Object;

            var checkpoints = await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken());

            Assert.That(checkpoints, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoints.Any(), Is.False, "No valid checkpoints should exist.");

            mockLogger.Verify(log => log.InvalidCheckpointFound(partitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the appropriate events are emitted when errors occur.
        /// </summary>
        ///
        [Test]
        public void ListCheckpointsLogsErrors()
        {
            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<BlobEventStoreEventSource>();
            var mockContainerClient = new MockBlobContainerClient() { GetBlobsAsyncException = expectedException };
            var target = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken()), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(m => m.ListCheckpointsError(FullyQualifiedNamespace, EventHubName, ConsumerGroup, expectedException.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsLogsInvalidCheckpoint()
        {
            var partitionId = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>{
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/checkpoint/{partitionId}",
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
            mockLog.Verify(m => m.InvalidCheckpointFound(partitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of ListCheckpointsAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void ListCheckpointsForMissingPartitionThrowsAndLogsOwnershipNotClaimable()
        {
            var ex = new RequestFailedException(0, "foo", BlobErrorCode.ContainerNotFound.ToString(), null);

            var target = new BlobsCheckpointStore(new MockBlobContainerClient(getBlobsAsyncException: ex),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, new CancellationToken()), Throws.InstanceOf<RequestFailedException>());
            mockLog.Verify(m => m.ListCheckpointsError(FullyQualifiedNamespace, EventHubName, ConsumerGroup, ex.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsStartAndComplete()
        {
            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId,
            };

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

            await target.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), new CancellationToken());
            mockLog.Verify(log => log.UpdateCheckpointStart(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup));
            mockLog.Verify(log => log.UpdateCheckpointComplete(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate logs are written
        ///   when exceptions occur.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointLogsErrors()
        {
            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId,
            };

            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<BlobEventStoreEventSource>();
            var mockContainerClient = new MockBlobContainerClient() { BlobClientUploadBlobException = expectedException };
            var target = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            target.Logger = mockLog.Object;

            Assert.That(async () => await target.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), new CancellationToken()), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(log => log.UpdateCheckpointError(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, expectedException.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointForMissingCheckpointThrowsAndLogsCheckpointUpdateError()
        {
            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId
            };

            var ex = new RequestFailedException(404, BlobErrorCode.ContainerNotFound.ToString(), BlobErrorCode.ContainerNotFound.ToString(), null);
            var target = new BlobsCheckpointStore(new MockBlobContainerClient(blobClientUploadBlobException: ex),
                                                  new BasicRetryPolicy(new EventHubsRetryOptions()));
            var mockLog = new Mock<BlobEventStoreEventSource>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), new CancellationToken()), Throws.InstanceOf<RequestFailedException>());

            mockLog.Verify(m => m.UpdateCheckpointError(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, ex.Message));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void ListOwnershipAsyncRetriesAndSurfacesRetriableExceptions(Exception exception)
        {
            const int maximumRetries = 2;

            var expectedServiceCalls = (maximumRetries + 1);
            var serviceCalls = 0;

            var mockRetryPolicy = new Mock<EventHubsRetryPolicy>();
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, mockRetryPolicy.Object);

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ListOwnershipAsync("ns", "eh", "cg", cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void ListOwnershipAsyncSurfacesNonRetriableExceptions(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;

            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ListOwnershipAsync("ns", "eh", "cg", cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncDelegatesTheCancellationToken()
        {
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            using var cancellationSource = new CancellationTokenSource();
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                if (!stateBeforeCancellation.HasValue)
                {
                    stateBeforeCancellation = token.IsCancellationRequested;
                    cancellationSource.Cancel();
                    stateAfterCancellation = token.IsCancellationRequested;
                }
            };

            await checkpointStore.ListOwnershipAsync("ns", "eh", "cg", cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesListOwnershipAsyncThrow()
        {
            var checkpointStore = new BlobsCheckpointStore(Mock.Of<BlobContainerClient>(), Mock.Of<EventHubsRetryPolicy>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.ListOwnershipAsync("ns", "eh", "cg", cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void ClaimOwnershipAsyncRetriesAndSurfacesRetriableExceptionsWhenVersionIsNull(Exception exception)
        {
            const int maximumRetries = 2;

            var expectedServiceCalls = (maximumRetries + 1);
            var serviceCalls = 0;

            var mockRetryPolicy = new Mock<EventHubsRetryPolicy>();
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, mockRetryPolicy.Object);

            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid"
            };

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            mockContainerClient.BlobClientUploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void ClaimOwnershipAsyncSurfacesNonRetriableExceptionsWhenVersionIsNull(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;

            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid"
            };

            mockContainerClient.BlobClientUploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void ClaimOwnershipAsyncRetriesAndSurfacesRetriableExceptionsWhenVersionIsNotNull(Exception exception)
        {
            const int maximumRetries = 2;

            var expectedServiceCalls = (maximumRetries + 1);
            var serviceCalls = 0;

            var mockRetryPolicy = new Mock<EventHubsRetryPolicy>();
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, mockRetryPolicy.Object);

            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid",
                Version = "eTag"
            };

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            mockContainerClient.BlobInfo = Mock.Of<BlobInfo>();

            mockContainerClient.BlobClientSetMetadataAsyncCallback = (metadata, conditions, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void ClaimOwnershipAsyncSurfacesNonRetriableExceptionsWhenVersionIsNotNull(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;

            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid",
                Version = "eTag"
            };

            mockContainerClient.BlobInfo = Mock.Of<BlobInfo>();

            mockContainerClient.BlobClientSetMetadataAsyncCallback = (metadata, conditions, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("eTag")]
        public async Task ClaimOwnershipAsyncDelegatesTheCancellationToken(string version)
        {
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid",
                Version = version
            };

            using var cancellationSource = new CancellationTokenSource();
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);

            // UploadAsync will be called if eTag is null; SetMetadataAsync is used otherwise.

            if (version == null)
            {
                mockContainerClient.BlobClientUploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
                {
                    if (!stateBeforeCancellation.HasValue)
                    {
                        stateBeforeCancellation = token.IsCancellationRequested;
                        cancellationSource.Cancel();
                        stateAfterCancellation = token.IsCancellationRequested;
                    }
                };
            }
            else
            {
                mockContainerClient.BlobInfo = Mock.Of<BlobInfo>();

                mockContainerClient.BlobClientSetMetadataAsyncCallback = (metadata, conditions, token) =>
                {
                    if (!stateBeforeCancellation.HasValue)
                    {
                        stateBeforeCancellation = token.IsCancellationRequested;
                        cancellationSource.Cancel();
                        stateAfterCancellation = token.IsCancellationRequested;
                    }
                };
            }

            await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesClaimOwnershipAsyncThrow()
        {
            var checkpointStore = new BlobsCheckpointStore(Mock.Of<BlobContainerClient>(), Mock.Of<EventHubsRetryPolicy>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(Mock.Of<IEnumerable<EventProcessorPartitionOwnership>>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void ListCheckpointsAsyncRetriesAndSurfacesRetriableExceptions(Exception exception)
        {
            const int maximumRetries = 2;

            var expectedServiceCalls = (maximumRetries + 1);
            var serviceCalls = 0;

            var mockRetryPolicy = new Mock<EventHubsRetryPolicy>();
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, mockRetryPolicy.Object);

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ListCheckpointsAsync("ns", "eh", "cg", cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void ListCheckpointsAsyncSurfacesNonRetriableExceptions(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;

            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.ListCheckpointsAsync("ns", "eh", "cg", cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListCheckpointsAsyncDelegatesTheCancellationToken()
        {
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            using var cancellationSource = new CancellationTokenSource();
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                if (!stateBeforeCancellation.HasValue)
                {
                    stateBeforeCancellation = token.IsCancellationRequested;
                    cancellationSource.Cancel();
                    stateAfterCancellation = token.IsCancellationRequested;
                }
            };

            await checkpointStore.ListCheckpointsAsync("ns", "eh", "cg", cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.ListCheckpointsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesListCheckpointsAsyncThrow()
        {
            var checkpointStore = new BlobsCheckpointStore(Mock.Of<BlobContainerClient>(), Mock.Of<EventHubsRetryPolicy>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.ListCheckpointsAsync("ns", "eh", "cg", cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void UpdateCheckpointAsyncRetriesAndSurfacesRetriableExceptions(Exception exception)
        {
            const int maximumRetries = 2;

            var expectedServiceCalls = (maximumRetries + 1);
            var serviceCalls = 0;

            var mockRetryPolicy = new Mock<EventHubsRetryPolicy>();
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, mockRetryPolicy.Object);

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                PartitionId = "pid"
            };

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            mockContainerClient.BlobClientUploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void UpdateCheckpointAsyncSurfacesNonRetriableExceptions(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;

            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                PartitionId = "pid"
            };

            mockContainerClient.BlobClientUploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointAsyncDelegatesTheCancellationToken()
        {
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobsCheckpointStore(mockContainerClient, new BasicRetryPolicy(new EventHubsRetryOptions()));

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                PartitionId = "pid"
            };

            using var cancellationSource = new CancellationTokenSource();
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);

            mockContainerClient.BlobClientUploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
            {
                if (!stateBeforeCancellation.HasValue)
                {
                    stateBeforeCancellation = token.IsCancellationRequested;
                    cancellationSource.Cancel();
                    stateAfterCancellation = token.IsCancellationRequested;
                }
            };

            await checkpointStore.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobsCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesUpdateCheckpointAsyncThrow()
        {
            var checkpointStore = new BlobsCheckpointStore(Mock.Of<BlobContainerClient>(), Mock.Of<EventHubsRetryPolicy>());

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                PartitionId = "pid"
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(checkpoint, new EventData(Array.Empty<byte>()), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
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
            internal Action<BlobTraits, BlobStates, string, CancellationToken> GetBlobsAsyncCallback;
            internal Action<Stream, BlobHttpHeaders, IDictionary<string, string>, BlobRequestConditions, IProgress<long>, AccessTier?, StorageTransferOptions, CancellationToken> BlobClientUploadAsyncCallback;
            internal Action<IDictionary<string, string>, BlobRequestConditions, CancellationToken> BlobClientSetMetadataAsyncCallback;

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

                GetBlobsAsyncCallback?.Invoke(traits, states, prefix, cancellationToken);

                return new MockAsyncPageable<BlobItem>(Blobs);
            }

            public override BlobClient GetBlobClient(string blobName)
            {
                return new MockBlobClient(blobName, BlobInfo, BlobClientUploadBlobException, BlobClientUploadAsyncCallback, BlobClientSetMetadataAsyncCallback);
            }
        }

        private class MockBlobClient : BlobClient
        {
            public override string Name { get; }
            internal BlobInfo BlobInfo;
            internal Exception BlobClientUploadBlobException;
            private Action<Stream, BlobHttpHeaders, IDictionary<string, string>, BlobRequestConditions, IProgress<long>, AccessTier?, StorageTransferOptions, CancellationToken> UploadAsyncCallback;
            private Action<IDictionary<string, string>, BlobRequestConditions, CancellationToken> SetMetadataAsyncCallback;

            public MockBlobClient(string blobName,
                                  BlobInfo blobInfo = null,
                                  Exception blobClientUploadBlobException = null,
                                  Action<Stream, BlobHttpHeaders, IDictionary<string, string>, BlobRequestConditions, IProgress<long>, AccessTier?, StorageTransferOptions, CancellationToken> uploadAsyncCallback = null,
                                  Action<IDictionary<string, string>, BlobRequestConditions, CancellationToken> setMetadataAsyncCallback = null)
            {
                BlobClientUploadBlobException = blobClientUploadBlobException;
                UploadAsyncCallback = uploadAsyncCallback;
                SetMetadataAsyncCallback = setMetadataAsyncCallback;
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

                SetMetadataAsyncCallback?.Invoke(metadata, conditions, cancellationToken);

                throw new RequestFailedException(412, BlobErrorCode.ConditionNotMet.ToString(), BlobErrorCode.ConditionNotMet.ToString(), default);
            }

            public override Task<Response<BlobContentInfo>> UploadAsync(Stream content, BlobHttpHeaders httpHeaders = null, IDictionary<string, string> metadata = null, BlobRequestConditions conditions = null, IProgress<long> progressHandler = null, AccessTier? accessTier = null, StorageTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
            {
                if (BlobClientUploadBlobException != null)
                {
                    throw BlobClientUploadBlobException;
                }
                if (BlobInfo != null)
                {
                    throw new RequestFailedException(409, BlobErrorCode.BlobAlreadyExists.ToString(), BlobErrorCode.BlobAlreadyExists.ToString(), default);
                }

                UploadAsyncCallback?.Invoke(content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, cancellationToken);

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

            public override Response GetRawResponse() => throw new NotImplementedException();

            public MockPage(IEnumerable<T> items)
            {
                InnerValues = items.ToList().AsReadOnly();
            }
        }
    }
}
