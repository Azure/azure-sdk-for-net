// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BlobCheckpointStore" /> class.
    /// </summary>
    ///
    [TestFixture]
    public class BlobCheckpointStoreTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ListOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ListOwnershipAsyncDelegatesTheCall()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedNamespace = "fakeNS";
            var expectedHub = "fakeHub";
            var expectedConsumerGroup = "fakeGroup";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var blobCheckpointStore = new BlobCheckpointStore(mockCheckpointStore.Object);

            _ = await blobCheckpointStore.ListOwnershipAsync(expectedNamespace, expectedHub, expectedConsumerGroup, cancellationSource.Token);

            mockCheckpointStore.Verify(store => store.ListOwnershipAsync(
                expectedNamespace,
                expectedHub,
                expectedConsumerGroup,
                cancellationSource.Token),
            Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.ClaimOwnershipAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ClaimOwnershipAsyncDelegatesTheCall()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedOwnership = new[] { new EventProcessorPartitionOwnership
            {
                FullyQualifiedNamespace = "fakeNS",
                EventHubName = "fakeHub",
                ConsumerGroup = "fakeGroup",
                PartitionId = "fakePart"
            }};

            var mockCheckpointStore = new Mock<CheckpointStore>();
            var blobCheckpointStore = new BlobCheckpointStore(mockCheckpointStore.Object);

            _ = await blobCheckpointStore.ClaimOwnershipAsync(expectedOwnership, cancellationSource.Token);

            mockCheckpointStore.Verify(store => store.ClaimOwnershipAsync(
                expectedOwnership,
                cancellationSource.Token),
            Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.GetCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetCheckpointAsyncDelegatesTheCall()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedNamespace = "fakeNS";
            var expectedHub = "fakeHub";
            var expectedConsumerGroup = "fakeGroup";
            var expectedPartition = "fakePart";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var blobCheckpointStore = new BlobCheckpointStore(mockCheckpointStore.Object);

            _ = await blobCheckpointStore.GetCheckpointAsync(expectedNamespace, expectedHub, expectedConsumerGroup, expectedPartition, cancellationSource.Token);

            mockCheckpointStore.Verify(store => store.GetCheckpointAsync(
                expectedNamespace,
                expectedHub,
                expectedConsumerGroup,
                expectedPartition,
                cancellationSource.Token),
            Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointAsyncDelegatesTheCall()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedNamespace = "fakeNS";
            var expectedHub = "fakeHub";
            var expectedConsumerGroup = "fakeGroup";
            var expectedPartition = "fakePart";
            var expectedProcessorId = "Id";
            var expectedOffset = "999";
            var mockCheckpointStore = new Mock<CheckpointStore>();
            var blobCheckpointStore = new BlobCheckpointStore(mockCheckpointStore.Object);

            await blobCheckpointStore.UpdateCheckpointAsync(expectedNamespace, expectedHub, expectedConsumerGroup, expectedPartition, expectedProcessorId, new CheckpointPosition(expectedOffset), cancellationSource.Token);

            mockCheckpointStore.Verify(store => store.UpdateCheckpointAsync(
                expectedNamespace,
                expectedHub,
                expectedConsumerGroup,
                expectedPartition,
                expectedProcessorId,
                It.Is<CheckpointPosition>(csp =>
                    csp.OffsetString == expectedOffset),
                cancellationSource.Token),
            Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BlobCheckpointStore" /> constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWrapsTheBlobContainer()
        {
            using var cancellationSource = new CancellationTokenSource();

            var mockBlobContainer = new Mock<BlobContainerClient>();
            var blobCheckpointStore = new BlobCheckpointStore(mockBlobContainer.Object);
            var expectedException = new DivideByZeroException("oops");

            mockBlobContainer
                .Setup(client => client.GetBlobsAsync(
                    It.IsAny<BlobTraits>(),
                    It.IsAny<BlobStates>(),
                    It.IsAny<string>(),
                    cancellationSource.Token))
                .Throws(expectedException);

            Assert.That(async () => await blobCheckpointStore.ListOwnershipAsync("fakeNS", "fakeHub", "fakeGroup", cancellationSource.Token), Throws.Exception.EqualTo(expectedException));
        }
    }
}
