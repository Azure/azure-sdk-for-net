// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BlobCheckpointStore" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class BlobsCheckpointStoreInternalTests
    {
        private const string FullyQualifiedNamespace = "FqNs";
        private const string EventHubName = "Name";
        private const string ConsumerGroup = "Group";
        private const string Identifier = "Id";
        private const string FullyQualifiedNamespaceLowercase = "fqns";
        private const string EventHubNameLowercase = "name";
        private const string ConsumerGroupLowercase = "group";
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
        ///   Verifies functionality of the <see cref="BlobCheckpointStore" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresBlobContainerClient()
        {
            Assert.That(() => new BlobCheckpointStoreInternal(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies basic functionality of ListOwnershipAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipLogsStartAndComplete()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });

            var mockLog = new Mock<IBlobEventLogger>();
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

            var mockLog = new Mock<IBlobEventLogger>();
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

            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/1", _ => { });
            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);
            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None)).ToList();
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
            var mockLog = new Mock<IBlobEventLogger>();
            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/1", client => client.UploadBlobException = expectedException);

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

            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/1", _ => { });
            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None)).ToList();
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

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/1", client => client.BlobInfo = blobInfo);
            var target = new BlobCheckpointStoreInternal(mockContainerClient);

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None)).ToList();
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

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/1", client => client.BlobInfo = blobInfo);
            var target = new BlobCheckpointStoreInternal(mockContainerClient);

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None)).ToList();
            CollectionAssert.IsEmpty(result);

            mockLog.Verify(m => m.OwnershipNotClaimable(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, OwnershipIdentifier, It.Is<string>(e => e.Contains(BlobErrorCode.ConditionNotMet.ToString()))));
        }

        /// <summary>
        ///   Verifies functionality of ClaimOwnershipAsync.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipCompensatesWhenABlobIsDeleted()
        {
            var ownershipBlobName = $"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/{PartitionId}";
            var setMetadataException = new RequestFailedException(404, "No blob here", BlobErrorCode.BlobNotFound.ToString(), null);
            var setMetadataCalled = false;
            var uploadBlobCalled = false;

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
                    Version = "FAKE"
                }
            };

            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient(ownershipBlobName, client =>
            {
                client.SetMetadataException = setMetadataException;

                client.SetMetadataAsyncCallback = (_, _, _) =>
                {
                    setMetadataCalled = true;
                };

                client.UploadAsyncCallback = (_, _, _, conditions, _, _, _, _) =>
                {
                    uploadBlobCalled = true;
                    Assert.That(conditions.IfNoneMatch, Is.EqualTo(new ETag("*")), "The IfNoneMatch condition should be set.");
                    Assert.That(conditions.IfMatch, Is.Null, "The IfMatch condition should be null.");
                };
            });

            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var result = (await target.ClaimOwnershipAsync(partitionOwnership, CancellationToken.None)).ToList();
            CollectionAssert.AreEquivalent(partitionOwnership, result);

            Assert.That(setMetadataCalled, "SetMetadata should have been called.");
            Assert.That(uploadBlobCalled, "UploadBlob should have been called.");
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointLogsStartAndComplete()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, "0"}
                                           })
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            var partition = "0";

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);

            mockLog.Verify(m => m.GetCheckpointStart(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition));
            mockLog.Verify(m => m.GetCheckpointComplete(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, null, It.IsAny<DateTimeOffset>()));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(BlobCheckpointStoreInternal.NoOffsetPlaceholderText)]
        public async Task GetCheckpointIgnoresPlaceholderOffsets(string placeholderOffset)
        {
            var expectedSequence = 133;
            var expectedStartingPosition = EventPosition.FromSequenceNumber(expectedSequence, false);
            var partition = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, placeholderOffset},
                                               {BlobMetadataKey.SequenceNumber, expectedSequence.ToString()}
                                           })
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A checkpoint should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(expectedStartingPosition));

            Assert.That(checkpoint, Is.InstanceOf<BlobCheckpointStoreInternal.BlobStorageCheckpoint>(), "Checkpoint instance was not the expected type.");

            var blobCheckpoint = (BlobCheckpointStoreInternal.BlobStorageCheckpoint)checkpoint;
            Assert.That(blobCheckpoint.Offset, Is.Null, $"The offset should not have been populated, as it was not set.");
            Assert.That(expectedSequence, Is.EqualTo(blobCheckpoint.SequenceNumber), "Checkpoint sequence number did not have the correct value.");
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointUsesOffsetAsTheStartingPositionWhenNoSequenceNumberIsPresent()
        {
            var expectedOffset = "13";
            var expectedStartingPosition = EventPosition.FromOffset(expectedOffset, false);
            var partition = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, expectedOffset.ToString()},
                                               {BlobMetadataKey.SequenceNumber, long.MinValue.ToString()}
                                           })
            };
            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A checkpoint should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(expectedStartingPosition));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointUsesSequenceNumberAsTheStartingPositionWhenNoOffsetIsPresent()
        {
            var expectedSequence = 133;
            var expectedStartingPosition = EventPosition.FromSequenceNumber(expectedSequence, false);
            var partition = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, ""},
                                               {BlobMetadataKey.SequenceNumber, expectedSequence.ToString()}
                                           })
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A checkpoint should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(expectedStartingPosition));

            Assert.That(checkpoint, Is.InstanceOf<BlobCheckpointStoreInternal.BlobStorageCheckpoint>(), "Checkpoint instance was not the expected type.");
            var blobCheckpoint = (BlobCheckpointStoreInternal.BlobStorageCheckpoint)checkpoint;
            Assert.That(blobCheckpoint.Offset, Is.Null, $"The offset should not have been populated, as it was not set.");
            Assert.That(expectedSequence, Is.EqualTo(blobCheckpoint.SequenceNumber), "Checkpoint sequence number did not have the correct value.");
        }

         /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointUsesOffsetAsTheStartingPosition()
        {
            var expectedOffset = "133";
            var expectedStartingPosition = EventPosition.FromOffset(expectedOffset, false);
            var partition = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, expectedOffset},
                                               {BlobMetadataKey.SequenceNumber, long.MinValue.ToString()}
                                           })
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A checkpoint should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(expectedStartingPosition));

            Assert.That(checkpoint, Is.InstanceOf<BlobCheckpointStoreInternal.BlobStorageCheckpoint>(), "Checkpoint instance was not the expected type.");
            var blobCheckpoint = (BlobCheckpointStoreInternal.BlobStorageCheckpoint)checkpoint;
            Assert.That(blobCheckpoint.SequenceNumber, Is.EqualTo(long.MinValue), "The offset should have been long.MinValue.");
            Assert.That(expectedOffset, Is.EqualTo(blobCheckpoint.Offset), "Checkpoint sequence number did not have the correct value.");
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointPrefersOffsetAsTheStartingPosition()
        {
            var offset = "13";
            var sequenceNumber = 7777;
            var expectedStartingPosition = EventPosition.FromOffset(offset, false);
            var partition = Guid.NewGuid().ToString();

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, offset},
                                               {BlobMetadataKey.SequenceNumber, sequenceNumber.ToString()}
                                           })
            };
            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A checkpoint should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(expectedStartingPosition));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointConsidersDataInvalidWithNoOffsetOrSequenceNumber()
        {
            var partitionId = "67";

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partitionId}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string>
                                           {
                                               {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                               {BlobMetadataKey.Offset, ""},
                                               {BlobMetadataKey.SequenceNumber, long.MinValue.ToString()}
                                           })
            };

            var mockLogger = new Mock<IBlobEventLogger>();

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });
            target.Logger = mockLogger.Object;

            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, CancellationToken.None);

            Assert.That(checkpoint, Is.Null);
            mockLogger.Verify(log => log.InvalidCheckpointFound(partitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointUsesOffsetAsTheStartingPositionWhenPresentInLegacyCheckpoint()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot")
            };

            var containerClient = new MockBlobContainerClient() { Blobs = blobList };
            containerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0", client =>
            {
                client.Content = Encoding.UTF8.GetBytes("{" +
                                                          "\"PartitionId\":\"0\"," +
                                                          "\"Owner\":\"681d365b-de1b-4288-9733-76294e17daf0\"," +
                                                          "\"Token\":\"2d0c4276-827d-4ca4-a345-729caeca3b82\"," +
                                                          "\"Epoch\":386," +
                                                          "\"Offset\":\"13\"," +
                                                          "\"SequenceNumber\":960180" +
                                                        "}");
            });

            var target = new BlobCheckpointStoreInternal(containerClient, initializeWithLegacyCheckpoints: true);
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A checkpoints should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(EventPosition.FromOffset("13", false)));
            Assert.That(checkpoint.PartitionId, Is.EqualTo("0"));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public async Task GetCheckpointLegacyCheckpointWithoutOffset(string offsetValue)
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot")
            };

            var offsetJsonValue = offsetValue is null ? "null" : $"\"{offsetValue}\"";
            var containerClient = new MockBlobContainerClient() { Blobs = blobList };

            containerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0", client =>
            {
                client.Content = Encoding.UTF8.GetBytes("{" +
                                                          "\"PartitionId\":\"0\"," +
                                                          "\"Owner\":\"681d365b-de1b-4288-9733-76294e17daf0\"," +
                                                          "\"Token\":\"2d0c4276-827d-4ca4-a345-729caeca3b82\"," +
                                                          "\"Epoch\":386," +
                                                          $"\"Offset\":{offsetJsonValue}," +
                                                          "\"SequenceNumber\":960180" +
                                                        "}");
            });

            var target = new BlobCheckpointStoreInternal(containerClient, initializeWithLegacyCheckpoints: true);
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            Assert.That(checkpoint, Is.Null, "A checkpoint should have not been returned.");
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void GetCheckpointForMissingPartitionThrowsAndLogsGetCheckpointError()
        {
            var partition = "0";
            var exception = new RequestFailedException(0, "foo", BlobErrorCode.ContainerNotFound.ToString(), null);
            var mockContainerClient = new MockBlobContainerClient();
            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            var mockLog = new Mock<IBlobEventLogger>();

            target.Logger = mockLog.Object;

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.GetPropertiesException = exception;
            });

            Assert.That(async () => await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None), Throws.InstanceOf<RequestFailedException>());
            mockLog.Verify(m => m.GetCheckpointError(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, exception.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsStartAndCompleteWhenTheBlobExists()
        {
            var position = new CheckpointPosition("777", 89);
            var expectedSequenceNumber = position.SequenceNumber.ToString(CultureInfo.InvariantCulture);

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId,
                ClientIdentifier = Identifier,
                StartingPosition = EventPosition.FromOffset(position.OffsetString)
            };

            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{MatchingEtag}"""), DateTime.UtcNow);

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {
                                               { BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString() },
                                               { BlobMetadataKey.Offset, position.OffsetString },
                                               { BlobMetadataKey.SequenceNumber, expectedSequenceNumber },
                                               { BlobMetadataKey.ClientIdentifier, Identifier }
                                           })
            };

            var mockContainerClient = new MockBlobContainerClient() { Blobs = blobList };

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/1", client =>
            {
                client.BlobInfo = blobInfo;
                client.UploadBlobException = new Exception("Upload should not be called");
            });

            var target = new BlobCheckpointStoreInternal(mockContainerClient);

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            await target.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, position, CancellationToken.None);
            mockLog.Verify(log => log.UpdateCheckpointStart(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.ClientIdentifier, expectedSequenceNumber, position.OffsetString));
            mockLog.Verify(log => log.UpdateCheckpointComplete(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.ClientIdentifier, expectedSequenceNumber, position.OffsetString));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on success.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointLogsStartAndCompleteWhenTheBlobDoesNotExist()
        {
            var sequenceNumber = 1234;
            var offset = "5678";

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId,
                ClientIdentifier = Identifier,
                StartingPosition = EventPosition.FromSequenceNumber(sequenceNumber)
            };

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/ownership/{Guid.NewGuid().ToString()}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };

            var mockBlobContainerClient = new MockBlobContainerClient() { Blobs = blobList };
            mockBlobContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/1", _ => { });

            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            await target.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, new CheckpointPosition(offset, sequenceNumber), CancellationToken.None);
            mockLog.Verify(log => log.UpdateCheckpointStart(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.ClientIdentifier, sequenceNumber.ToString(), offset));
            mockLog.Verify(log => log.UpdateCheckpointComplete(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.ClientIdentifier, sequenceNumber.ToString(), offset));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate logs are written
        ///   when exceptions occur.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointLogsErrorsWhenTheBlobExists()
        {
            var sequenceNumber = 456;
            var offset = "789";

            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId,
                ClientIdentifier = Identifier,
                StartingPosition = EventPosition.FromSequenceNumber(sequenceNumber)
            };

            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<IBlobEventLogger>();

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/1", client =>
            {
                client.SetMetadataException = expectedException;
                client.UploadBlobException = new Exception("Upload should not be called");
            });

            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, new CheckpointPosition(offset, sequenceNumber), CancellationToken.None), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(log => log.UpdateCheckpointError(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.ClientIdentifier, sequenceNumber.ToString(), offset.ToString(), expectedException.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate logs are written
        ///   when exceptions occur.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointLogsErrorsWhenTheBlobDoesNotExist()
        {
            var checkpoint = new EventProcessorCheckpoint
            {
                FullyQualifiedNamespace = FullyQualifiedNamespace,
                EventHubName = EventHubName,
                ConsumerGroup = ConsumerGroup,
                PartitionId = PartitionId,
                ClientIdentifier = Identifier
            };

            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<IBlobEventLogger>();

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/1", client =>
            {
                client.UploadBlobException = expectedException;
            });

            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.UpdateCheckpointAsync(checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.PartitionId, checkpoint.ClientIdentifier, new CheckpointPosition("0", 0), CancellationToken.None), Throws.Exception.EqualTo(expectedException));
            mockLog.Verify(log => log.UpdateCheckpointError(checkpoint.PartitionId, checkpoint.FullyQualifiedNamespace, checkpoint.EventHubName, checkpoint.ConsumerGroup, checkpoint.ClientIdentifier, "0", "0", expectedException.Message));
        }

        /// <summary>
        ///   Verifies basic functionality of UpdateCheckpointAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public void UpdateCheckpointForMissingContainerThrowsAndLogsCheckpointUpdateError()
        {
            var ex = new RequestFailedException(404, BlobErrorCode.ContainerNotFound.ToString(), BlobErrorCode.ContainerNotFound.ToString(), null);
            var mockBlobContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/1", client => client.UploadBlobException = ex);
            var target = new BlobCheckpointStoreInternal(mockBlobContainerClient);

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            Assert.That(async () => await target.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, PartitionId, Identifier, new CheckpointPosition("111", 0), CancellationToken.None), Throws.InstanceOf<RequestFailedException>());
            mockLog.Verify(m => m.UpdateCheckpointError(PartitionId, FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, "0", "111", ex.Message));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ListOwnershipAsync" />
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
            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            mockContainerClient.GetBlobsAsyncCallback = (traits, states, prefix, token) =>
            {
                serviceCalls++;
                throw exception;
            };

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await checkpointStore.ListOwnershipAsync("ns", "eh", "cg", cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncDelegatesTheCancellationToken()
        {
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

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
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesListOwnershipAsyncThrow()
        {
            var checkpointStore = new BlobCheckpointStoreInternal(Mock.Of<BlobContainerClient>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.ListOwnershipAsync("ns", "eh", "cg", cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void ClaimOwnershipAsyncSurfacesNonRetriableExceptionsWhenVersionIsNull(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;

            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid"
            };

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient("ns/eh/cg/ownership/pid", client =>
            {
                client.UploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
                {
                    serviceCalls++;
                    throw exception;
                };
            });

            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void ClaimOwnershipAsyncSurfacesNonRetriableExceptionsWhenVersionIsNotNull(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;
            var ownership = new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "ns",
                EventHubName = "eh",
                ConsumerGroup = "cg",
                OwnerIdentifier = "id",
                PartitionId = "pid",
                Version = "eTag"
            };

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient("ns/eh/cg/ownership/pid", client =>
            {
                client.SetMetadataAsyncCallback = (metadata, conditions, token) =>
                {
                    serviceCalls++;
                    throw exception;
                };
            });

            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should not have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("eTag")]
        public async Task ClaimOwnershipAsyncDelegatesTheCancellationToken(string version)
        {
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

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient("ns/eh/cg/ownership/pid", client =>
            {
                if (version == null)
                {
                    client.UploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
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
                    client.BlobInfo = Mock.Of<BlobInfo>();

                    client.SetMetadataAsyncCallback = (metadata, conditions, token) =>
                    {
                        if (!stateBeforeCancellation.HasValue)
                        {
                            stateBeforeCancellation = token.IsCancellationRequested;
                            cancellationSource.Cancel();
                            stateAfterCancellation = token.IsCancellationRequested;
                        }
                    };
                }
            });

            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);
            await checkpointStore.ClaimOwnershipAsync(new List<EventProcessorPartitionOwnership>() { ownership }, cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesClaimOwnershipAsyncThrow()
        {
            var checkpointStore = new BlobCheckpointStoreInternal(Mock.Of<BlobContainerClient>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.ClaimOwnershipAsync(Mock.Of<IEnumerable<EventProcessorPartitionOwnership>>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void GetCheckpointAsyncSurfacesNonRetriableExceptions(Exception exception)
        {
            var partition = "p0";
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.GetPropertiesException = exception;
            });

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await checkpointStore.GetCheckpointAsync(FullyQualifiedNamespaceLowercase, EventHubNameLowercase, ConsumerGroupLowercase, partition, cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointAsyncDelegatesTheCancellationToken()
        {
            var partition = "p0";
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            using var cancellationSource = new CancellationTokenSource();
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.GetPropertiesAsyncCallback = (conditions, token) =>
                {
                    if (!stateBeforeCancellation.HasValue)
                    {
                        stateBeforeCancellation = token.IsCancellationRequested;
                        cancellationSource.Cancel();
                        stateAfterCancellation = token.IsCancellationRequested;
                    }
                };
            });

            await checkpointStore.GetCheckpointAsync(FullyQualifiedNamespaceLowercase, EventHubNameLowercase, ConsumerGroupLowercase, partition, cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesGetCheckpointAsyncThrow()
        {
            var checkpointStore = new BlobCheckpointStoreInternal(Mock.Of<BlobContainerClient>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.GetCheckpointAsync("ns", "eh", "cg", "p0", cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void UpdateCheckpointAsyncSurfacesNonRetriableExceptionsWhenTheBlobExists(Exception exception)
        {
            var expectedServiceCalls = 1;
            var serviceCalls = 0;
            var partition = "p0";
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{MatchingEtag}"""), DateTime.UtcNow);

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.BlobInfo = blobInfo;
                client.UploadBlobException = new Exception("Upload should not be called");

                client.SetMetadataAsyncCallback = (metadata, conditions, token) =>
                {
                    serviceCalls++;
                    throw exception;
                };
            });

            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(FullyQualifiedNamespaceLowercase, EventHubNameLowercase, ConsumerGroupLowercase, partition, "Id", new CheckpointPosition("10"), cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
            Assert.That(serviceCalls, Is.EqualTo(expectedServiceCalls), "The retry policy should have been applied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void UpdateCheckpointAsyncSurfacesNonRetriableExceptionsWhenTheBlobDoesNotExist(Exception exception)
        {
            var partition = "p0";
            var mockContainerClient = new MockBlobContainerClient();
            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.SetMetadataException = exception;
            });

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await checkpointStore.UpdateCheckpointAsync(FullyQualifiedNamespaceLowercase, EventHubNameLowercase, ConsumerGroupLowercase, partition, "Id", new CheckpointPosition("10"), cancellationSource.Token), Throws.TypeOf(exception.GetType()), "The method call should surface the exception.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The operation should have stopped without cancellation.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointAsyncDelegatesTheCancellationTokenWhenTheBlobExists()
        {
            using var cancellationSource = new CancellationTokenSource();

            var partition = "p0";
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);
            var blobInfo = BlobsModelFactory.BlobInfo(new ETag($@"""{MatchingEtag}"""), DateTime.UtcNow);

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.BlobInfo = blobInfo;
                client.UploadBlobException = new Exception("Upload should not be called");
                client.SetMetadataAsyncCallback = (metadata, conditions, token) =>
                {
                    if (!stateBeforeCancellation.HasValue)
                    {
                        stateBeforeCancellation = token.IsCancellationRequested;
                        cancellationSource.Cancel();
                        stateAfterCancellation = token.IsCancellationRequested;
                    }
                };
            });

            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);

            await checkpointStore.UpdateCheckpointAsync(FullyQualifiedNamespaceLowercase, EventHubNameLowercase, ConsumerGroupLowercase, partition, "Id", new CheckpointPosition("10"), cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointAsyncDelegatesTheCancellationTokenWhenTheBlobDoesNotExist()
        {
            using var cancellationSource = new CancellationTokenSource();

            var partition = "p0";
            var stateBeforeCancellation = default(bool?);
            var stateAfterCancellation = default(bool?);

            var mockContainerClient = new MockBlobContainerClient().AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}", client =>
            {
                client.UploadAsyncCallback = (content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, token) =>
                {
                    if (!stateBeforeCancellation.HasValue)
                    {
                        stateBeforeCancellation = token.IsCancellationRequested;
                        cancellationSource.Cancel();
                        stateAfterCancellation = token.IsCancellationRequested;
                    }
                };
            });

            var checkpointStore = new BlobCheckpointStoreInternal(mockContainerClient);
            await checkpointStore.UpdateCheckpointAsync(FullyQualifiedNamespaceLowercase, EventHubNameLowercase, ConsumerGroupLowercase, partition, "Id", new CheckpointPosition("10"), cancellationSource.Token);

            Assert.That(stateBeforeCancellation.HasValue, Is.True, "State before cancellation should have been captured.");
            Assert.That(stateBeforeCancellation.Value, Is.False, "The token should not have been canceled before cancellation request.");
            Assert.That(stateAfterCancellation.HasValue, Is.True, "State after cancellation should have been captured.");
            Assert.That(stateAfterCancellation.Value, Is.True, "The token should have been canceled after cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCanceledTokenMakesUpdateCheckpointAsyncThrow()
        {
            var checkpointStore = new BlobCheckpointStoreInternal(Mock.Of<BlobContainerClient>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await checkpointStore.UpdateCheckpointAsync("ns", "eh", "cg", "p0", "Id", new CheckpointPosition("10"), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointPreferredNewCheckpointOverLegacy()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/0",
                                            false,
                                            BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag), contentLength: 0),
                                            "snapshot",
                                            new Dictionary<string, string>
                                            {
                                                {BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()},
                                                {BlobMetadataKey.SequenceNumber, "960182"},
                                                {BlobMetadataKey.Offset, "14"}
                                            }),

                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot")
            };

            var containerClient = new MockBlobContainerClient() { Blobs = blobList };

            containerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/0", client =>
            {
                client.Content = Encoding.UTF8.GetBytes("{" +
                                                            "\"PartitionId\":\"0\"," +
                                                            "\"Owner\":\"681d365b-de1b-4288-9733-76294e17daf0\"," +
                                                            "\"Token\":\"2d0c4276-827d-4ca4-a345-729caeca3b82\"," +
                                                            "\"Epoch\":386," +
                                                            "\"Offset\":\"13\"," +
                                                            "\"SequenceNumber\":960180" +
                                                            "}");
            });

            var target = new BlobCheckpointStoreInternal(containerClient, initializeWithLegacyCheckpoints: true);
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A single checkpoint should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(EventPosition.FromOffset("14", false)));
            Assert.That(checkpoint.PartitionId, Is.EqualTo("0"));

            Assert.That(checkpoint, Is.InstanceOf<BlobCheckpointStoreInternal.BlobStorageCheckpoint>(), "Checkpoint instance was not the expected type.");
            var blobCheckpoint = (BlobCheckpointStoreInternal.BlobStorageCheckpoint)checkpoint;
            Assert.That("14", Is.EqualTo(blobCheckpoint.Offset), "Checkpoint offset did not have the correct value.");
            Assert.That(960182, Is.EqualTo(blobCheckpoint.SequenceNumber), "Checkpoint sequence number did not have the correct value.");
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointsUsesOffsetAsTheStartingPositionWhenPresentInLegacyCheckpoint()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot")
            };

            var containerClient = new MockBlobContainerClient() { Blobs = blobList };

            containerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0", client =>
            {
                client.Content = Encoding.UTF8.GetBytes("{" +
                                                            "\"PartitionId\":\"0\"," +
                                                            "\"Owner\":\"681d365b-de1b-4288-9733-76294e17daf0\"," +
                                                            "\"Token\":\"2d0c4276-827d-4ca4-a345-729caeca3b82\"," +
                                                            "\"Epoch\":386," +
                                                            "\"Offset\":\"13\"," +
                                                            "\"SequenceNumber\":960180" +
                                                            "}");
            });

            var target = new BlobCheckpointStoreInternal(containerClient, initializeWithLegacyCheckpoints: true);
            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            Assert.That(checkpoint, Is.Not.Null, "A set of checkpoints should have been returned.");
            Assert.That(checkpoint.StartingPosition, Is.EqualTo(EventPosition.FromOffset("13", false)));
            Assert.That(checkpoint.PartitionId, Is.EqualTo("0"));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointConsidersDataInvalidWithNoOffsetOrSequenceNumberLegacyCheckpoint()
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot")
            };

            var containerClient = new MockBlobContainerClient() { Blobs = blobList };

            containerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0", client =>
            {
                client.Content = Encoding.UTF8.GetBytes("{" +
                                                            "\"PartitionId\":\"0\"," +
                                                            "\"Owner\":\"681d365b-de1b-4288-9733-76294e17daf0\"," +
                                                            "\"Token\":\"2d0c4276-827d-4ca4-a345-729caeca3b82\"," +
                                                            "\"Epoch\":386" +
                                                        "}");
            });

            var mockLogger = new Mock<IBlobEventLogger>();

            var target = new BlobCheckpointStoreInternal(containerClient, initializeWithLegacyCheckpoints: true);
            target.Logger = mockLogger.Object;

            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            Assert.That(checkpoint, Is.Null, "No valid checkpoints should exist.");
            mockLogger.Verify(log => log.InvalidCheckpointFound("0", FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the starting position is set correctly.
        /// </summary>
        ///
        [TestCase("")]
        [TestCase("{\"PartitionId\":\"0\",\"Owner\":\"681d365b-de1b-4288-9733-76294e17daf0\",")]
        [TestCase("\0\0\0")]
        public async Task GetCheckpointConsidersDataInvalidWithLegacyCheckpointBlobContainingInvalidJson(string json)
        {
            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot")
            };

            var containerClient = new MockBlobContainerClient() { Blobs = blobList };

            containerClient.AddBlobClient($"{FullyQualifiedNamespace}/{EventHubName}/{ConsumerGroup}/0", client =>
            {
                client.Content = Encoding.UTF8.GetBytes(json);
            });

            var mockLogger = new Mock<IBlobEventLogger>();

            var target = new BlobCheckpointStoreInternal(containerClient, initializeWithLegacyCheckpoints: true);
            target.Logger = mockLogger.Object;

            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);

            Assert.That(checkpoint, Is.Null, "No valid checkpoints should exist.");
            mockLogger.Verify(log => log.InvalidCheckpointFound("0", FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted when errors occur.
        /// </summary>
        ///
        [Test]
        public void GetCheckpointLogsErrors()
        {
            var expectedException = new DllNotFoundException("BOOM!");
            var mockLog = new Mock<IBlobEventLogger>();
            var mockContainerClient = new MockBlobContainerClient() { GetBlobsAsyncException = expectedException };

            var target = new BlobCheckpointStoreInternal(mockContainerClient);
            target.Logger = mockLog.Object;

            mockContainerClient.AddBlobClient($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/0", client =>
            {
                client.GetPropertiesException = expectedException;
            });

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
            var partition = "0";

            var blobList = new List<BlobItem>
            {
                BlobsModelFactory.BlobItem($"{FullyQualifiedNamespaceLowercase}/{EventHubNameLowercase}/{ConsumerGroupLowercase}/checkpoint/{partition}",
                                           false,
                                           BlobsModelFactory.BlobItemProperties(true, lastModified: DateTime.UtcNow, eTag: new ETag(MatchingEtag)),
                                           "snapshot",
                                           new Dictionary<string, string> {{BlobMetadataKey.OwnerIdentifier, Guid.NewGuid().ToString()}})
            };

            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient() { Blobs = blobList });

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partition, CancellationToken.None);
            mockLog.Verify(m => m.InvalidCheckpointFound(partition, FullyQualifiedNamespace, EventHubName, ConsumerGroup));
        }

        /// <summary>
        ///   Verifies basic functionality of GetCheckpointAsync and ensures the appropriate events are emitted on failure.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointForMissingPartitionReturnsNull()
        {
            var ex = new RequestFailedException(0, "foo", BlobErrorCode.ContainerNotFound.ToString(), null);
            var target = new BlobCheckpointStoreInternal(new MockBlobContainerClient(getBlobsAsyncException: ex));

            var mockLog = new Mock<IBlobEventLogger>();
            target.Logger = mockLog.Object;

            var checkpoint = await target.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, "0", CancellationToken.None);
            Assert.That(checkpoint, Is.Null);
        }

        private class MockBlobContainerClient : BlobContainerClient
        {
            public override Uri Uri { get; }
            public override string AccountName { get; }
            public override string Name { get; }
            internal IEnumerable<BlobItem> Blobs;
            internal Exception GetBlobsAsyncException;
            internal Action<BlobTraits, BlobStates, string, CancellationToken> GetBlobsAsyncCallback;
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
                GetBlobsAsyncCallback?.Invoke(traits, states, prefix, cancellationToken);

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
            internal Exception SetMetadataException;
            internal Exception GetPropertiesException;
            internal byte[] Content;
            internal Action<Stream, BlobHttpHeaders, IDictionary<string, string>, BlobRequestConditions, IProgress<long>, AccessTier?, StorageTransferOptions, CancellationToken> UploadAsyncCallback;
            internal Action<IDictionary<string, string>, BlobRequestConditions, CancellationToken> SetMetadataAsyncCallback;
            internal Action<BlobRequestConditions, CancellationToken> GetPropertiesAsyncCallback;

            public MockBlobClient(string blobName)
            {
                Name = blobName;
            }

            public override Task<Response<BlobInfo>> SetMetadataAsync(IDictionary<string, string> metadata, BlobRequestConditions conditions = null, CancellationToken cancellationToken = default)
            {
                SetMetadataAsyncCallback?.Invoke(metadata, conditions, cancellationToken);

                if (SetMetadataException != null)
                {
                    throw SetMetadataException;
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
                UploadAsyncCallback?.Invoke(content, httpHeaders, metadata, conditions, progressHandler, accessTier, transferOptions, cancellationToken);

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

            public override async Task<Response> DownloadToAsync(Stream destination, CancellationToken cancellationToken)
            {
                await destination.WriteAsync(Content, 0, Content.Length, cancellationToken);
                return Mock.Of<Response>();
            }

            public override Task<Response<BlobProperties>> GetPropertiesAsync(BlobRequestConditions conditions = null, CancellationToken cancellationToken = default)
            {
                GetPropertiesAsyncCallback?.Invoke(conditions, cancellationToken);

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
