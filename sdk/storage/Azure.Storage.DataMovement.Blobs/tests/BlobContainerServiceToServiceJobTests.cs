// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using Azure.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using BaseBlobs::Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Tests;
using Moq;
using System.Buffers;
using Azure.Core.Pipeline;
using System.Threading;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [TestFixture]
    public class BlobContainerServiceToServiceJobTests
    {
        private Mock<BlobStorageResourceContainer> GetMockBlobContainerResource()
        {
            Mock <BlobStorageResourceContainer> mock = new Mock<BlobStorageResourceContainer>();
            mock.Setup(r => r.Uri).Returns(new Uri("https://account.blob.core.windows.net/container"));
            mock.Setup(r => r.ProviderId).Returns("blob");
            mock.Setup(r => r.GetSourceCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            mock.Setup(r => r.GetDestinationCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            mock.Setup(r => r.GetStorageResourceReference(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string,string>((path,resourceId) =>
                {
                    return GetMockBlockBlobResource(path).Object;
                });
            return mock;
        }

        private Mock<BlockBlobStorageResource> GetMockBlockBlobResource(string blobName)
        {
            Mock<BlockBlobStorageResource> mock = new Mock<BlockBlobStorageResource>();
            mock.Setup(r => r.Uri).Returns(new Uri($"https://account.blob.core.windows.net/container/{blobName}"));
            mock.Setup(r => r.ResourceId).Returns("BlockBlob");
            mock.Setup(r => r.GetSourceCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            mock.Setup(r => r.GetDestinationCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            return mock;
        }

        private Mock<PageBlobStorageResource> GetMockPageBlobResource(string blobName)
        {
            Mock<PageBlobStorageResource> mock = new Mock<PageBlobStorageResource>();
            mock.Setup(r => r.Uri).Returns(new Uri($"https://account.blob.core.windows.net/container/{blobName}"));
            mock.Setup(r => r.ResourceId).Returns("PageBlob");
            mock.Setup(r => r.GetSourceCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            mock.Setup(r => r.GetDestinationCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            return mock;
        }

        private Mock<AppendBlobStorageResource> GetMockAppendBlobResource(string blobName)
        {
            Mock<AppendBlobStorageResource> mock = new Mock<AppendBlobStorageResource>();
            mock.Setup(r => r.Uri).Returns(new Uri($"https://account.blob.core.windows.net/container/{blobName}"));
            mock.Setup(r => r.ResourceId).Returns("AppendBlob");
            mock.Setup(r => r.GetSourceCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            mock.Setup(r => r.GetDestinationCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            return mock;
        }

        private static async IAsyncEnumerable<StorageResourceItem> GetStorageResourceItemsAsyncEnumerable(List<StorageResourceItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
            await Task.CompletedTask;
        }

        [Test]
        public async Task ProcessJobToJobPartAsync()
        {
            string transferId = Guid.NewGuid().ToString();
            Mock<BlobStorageResourceContainer> sourceMock = GetMockBlobContainerResource();
            Mock<BlobStorageResourceContainer> destinationMock = GetMockBlobContainerResource();

            // Set up default checkpointer with transfer job
            LocalTransferCheckpointer checkpointer = new(default);
            await checkpointer.AddNewJobAsync(
                transferId: transferId,
                source: sourceMock.Object,
                destination: destinationMock.Object);
            // Arrange
            // list of blobs in container
            List<StorageResourceItem> blobItems = new List<StorageResourceItem>
            {
                GetMockBlockBlobResource("blob1").Object,
                GetMockBlockBlobResource("blob2").Object,
                GetMockBlockBlobResource("blob3").Object,
            };
            sourceMock.Setup(r => r.GetStorageResourcesAsync(
                It.IsAny<StorageResourceContainer>(),
                It.IsAny<CancellationToken>()))
                .Returns(GetStorageResourceItemsAsyncEnumerable(blobItems));
            await using TransferManager manager = new TransferManager();
            TransferOperation transferOperation = new TransferOperation(id: transferId)
            {
                TransferManager = manager
            };
            TransferJobInternal transferJob = new(
                transferOperation,
                sourceMock.Object,
                destinationMock.Object,
                ServiceToServiceJobPart.CreateJobPartAsync,
                new TransferOptions(),
                checkpointer,
                TransferErrorMode.StopOnAnyFailure,
                ArrayPool<byte>.Shared,
                new ClientDiagnostics(ClientOptions.Default));

            // Act
            List<StorageResourceItem> destinationItems = new List<StorageResourceItem>();
            await foreach (JobPartInternal partItem in transferJob.ProcessJobToJobPartAsync())
            {
                destinationItems.Add(partItem._destinationResource);
            }

            // Assert / Verify
            Assert.AreEqual(blobItems.Count, destinationItems.Count);
            foreach (var item in destinationItems)
            {
                Assert.IsTrue(blobItems.Any(b => new BlobUriBuilder(b.Uri).BlobName == new BlobUriBuilder(item.Uri).BlobName));
                Assert.IsTrue(item is BlockBlobStorageResource);
            }
        }

        [Test]
        public async Task ProcessJobToJobPartAsync_AllBlobTypes()
        {
            string transferId = Guid.NewGuid().ToString();
            Mock<BlobStorageResourceContainer> sourceMock = GetMockBlobContainerResource();
            Mock<BlobStorageResourceContainer> destinationMock = GetMockBlobContainerResource();

            // Set up default checkpointer with transfer job
            LocalTransferCheckpointer checkpointer = new(default);
            await checkpointer.AddNewJobAsync(
                transferId: transferId,
                source: sourceMock.Object,
                destination: destinationMock.Object);
            // Arrange
            // list of blobs in container
            List<StorageResourceItem> blobItems = new List<StorageResourceItem>
            {
                GetMockBlockBlobResource("blockblob1").Object,
                GetMockAppendBlobResource("appendblob1").Object,
                GetMockPageBlobResource("pageblob1").Object,
                GetMockBlockBlobResource("blockblob2").Object,
                GetMockAppendBlobResource("appendblob2").Object,
                GetMockBlockBlobResource("blockblob3").Object,
            };
            sourceMock.Setup(r => r.GetStorageResourcesAsync(
                It.IsAny<StorageResourceContainer>(),
                It.IsAny<CancellationToken>()))
                .Returns(GetStorageResourceItemsAsyncEnumerable(blobItems));
            await using TransferManager manager = new TransferManager();
            TransferOperation transferOperation = new TransferOperation(id: transferId)
            {
                TransferManager = manager
            };
            TransferJobInternal transferJob = new(
                transferOperation,
                sourceMock.Object,
                destinationMock.Object,
                ServiceToServiceJobPart.CreateJobPartAsync,
                new TransferOptions(),
                checkpointer,
                TransferErrorMode.StopOnAnyFailure,
                ArrayPool<byte>.Shared,
                new ClientDiagnostics(ClientOptions.Default));

            // Act
            List<StorageResourceItem> destinationItems = new List<StorageResourceItem>();
            await foreach (JobPartInternal partItem in transferJob.ProcessJobToJobPartAsync())
            {
                destinationItems.Add(partItem._destinationResource);
            }

            // Assert / Verify
            Assert.AreEqual(blobItems.Count, destinationItems.Count);
            blobItems.Zip(destinationItems, (b, d) =>
            {
                Assert.AreEqual(new BlobUriBuilder(b.Uri).BlobName, new BlobUriBuilder(d.Uri).BlobName);
                Assert.AreEqual(b.ResourceId, d.ResourceId);
                return true;
            });
        }
    }
}
