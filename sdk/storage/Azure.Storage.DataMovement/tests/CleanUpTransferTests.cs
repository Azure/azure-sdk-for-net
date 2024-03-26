// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class CleanUpTransferTests
    {
        public CleanUpTransferTests() { }

        private Mock<StorageResourceItem> GetRemoteSourceResource(long length = Constants.KB)
        {
            Mock<StorageResourceItem> mock = new();
            mock.Setup(b => b.Uri)
                .Returns(new Uri("https://storageaccount.blob.core.windows.net/container/source.txt"));
            mock.Setup(b => b.ResourceId)
                .Returns("BlockBlob");
            mock.Setup(b => b.ProviderId)
                .Returns("blob");
            mock.Setup(b => b.GetSourceCheckpointData())
                .Returns(new MockResourceCheckpointData());
            mock.Setup(b => b.GetDestinationCheckpointData())
                .Returns(new MockResourceCheckpointData());
            mock.Setup(b => b.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new StorageResourceItemProperties(
                    resourceLength: length,
                    eTag: default,
                    lastModifiedTime: DateTimeOffset.UtcNow,
                    properties: default)));
            mock.Setup(b => b.GetCopyAuthorizationHeaderAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<HttpAuthorization>(default));
            return mock;
        }

        private Mock<StorageResourceItem> GetRemoteDestinationResource(bool throwOnDelete = false)
        {
            Mock<StorageResourceItem> mock = new();
            mock.Setup(b => b.Uri)
                .Returns(new Uri("https://storageaccount.blob.core.windows.net/container/dest.txt"));
            mock.Setup(b => b.ResourceId)
                .Returns("BlockBlob");
            mock.Setup(b => b.ProviderId)
                .Returns("blob");
            mock.Setup(b => b.MaxSupportedChunkSize)
                .Returns(Constants.GB);
            mock.Setup(b => b.GetSourceCheckpointData())
                .Returns(new MockResourceCheckpointData());
            mock.Setup(b => b.GetDestinationCheckpointData())
                .Returns(new MockResourceCheckpointData());
            mock.Setup(b => b.CompleteTransferAsync(It.IsAny<bool>(), It.IsAny<StorageResourceCompleteTransferOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            // Throw a failure when doing a CopyFromUri call to trigger a failed state
            mock.Setup(b => b.CopyFromUriAsync(It.IsAny<StorageResourceItem>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<StorageResourceCopyFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(
                    status: 403,
                    message: "Unable to authenticate",
                    errorCode: "AuthenticationFailed",
                    default));
            if (throwOnDelete)
            {
                mock.Setup(b => b.DeleteIfExistsAsync(It.IsAny<CancellationToken>()))
                    .Throws(new RequestFailedException(
                        status: 403,
                        message: "Unable to authenticate",
                        errorCode: "AuthenticationFailed",
                        default));
            }
            else
            {
                mock.Setup(b => b.DeleteIfExistsAsync(It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(true));
            }
            return mock;
        }

        private void AssertBaseSource(Mock<StorageResourceItem> source)
        {
            source.Verify(b => b.Uri, Times.Exactly(6));
            source.Verify(b => b.ProviderId, Times.Once());
            source.Verify(b => b.ResourceId, Times.Once());
            source.Verify(b => b.Length, Times.Once());
            source.Verify(b => b.GetSourceCheckpointData(), Times.Once());
            source.Verify(b => b.GetPropertiesAsync(It.IsAny<CancellationToken>()));
            source.Verify(b => b.GetCopyAuthorizationHeaderAsync(It.IsAny<CancellationToken>()));
            source.VerifyNoOtherCalls();
        }

        [Test]
        public async Task CleanupAfterFailureAsync()
        {
            // Arrange
            long sourceLength = Constants.KB;
            Mock<StorageResourceItem> sourceMock = GetRemoteSourceResource(sourceLength);
            Mock<StorageResourceItem> destMock = GetRemoteDestinationResource();

            // Act
            TransferManager transferManager = new();
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceMock.Object,
                destMock.Object,
                options);
            await transfer.WaitForCompletionAsync();

            // Assert
            AssertBaseSource(sourceMock);
            destMock.Verify(b => b.Uri, Times.Exactly(5));
            destMock.Verify(b => b.ProviderId, Times.Once());
            destMock.Verify(b => b.ResourceId, Times.Once());
            destMock.Verify(b => b.MaxSupportedChunkSize, Times.Exactly(2));
            destMock.Verify(b => b.GetDestinationCheckpointData(), Times.Once());
            destMock.Verify(b => b.CopyFromUriAsync(
                sourceMock.Object,
                false,
                sourceLength,
                It.IsAny<StorageResourceCopyFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            destMock.Verify(b => b.DeleteIfExistsAsync(It.IsAny<CancellationToken>()),
                Times.Once());
            destMock.VerifyNoOtherCalls();
            await testEventsRaised.AssertSingleFailedCheck(1);
        }

        [Test]
        public async Task ErrorThrownDuringCleanup()
        {
            // Arrange
            long sourceLength = Constants.KB;
            Mock<StorageResourceItem> sourceMock = GetRemoteSourceResource(sourceLength);
            // Set up destination to fail on delete
            Mock<StorageResourceItem> destMock = GetRemoteDestinationResource(throwOnDelete: true);

            // Act
            TransferManager transferManager = new();
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceMock.Object,
                destMock.Object,
                options);
            await transfer.WaitForCompletionAsync();

            // Assert
            AssertBaseSource(sourceMock);
            destMock.Verify(b => b.Uri, Times.Exactly(5));
            destMock.Verify(b => b.ProviderId, Times.Once());
            destMock.Verify(b => b.ResourceId, Times.Once());
            destMock.Verify(b => b.MaxSupportedChunkSize, Times.Exactly(2));
            destMock.Verify(b => b.GetDestinationCheckpointData(), Times.Once());
            destMock.Verify(b => b.CopyFromUriAsync(
                sourceMock.Object,
                false,
                sourceLength,
                It.IsAny<StorageResourceCopyFromUriOptions>(),
                It.IsAny<CancellationToken>()),
                Times.Once());
            destMock.Verify(b => b.DeleteIfExistsAsync(It.IsAny<CancellationToken>()),
                Times.Once());
            destMock.VerifyNoOtherCalls();
            await testEventsRaised.AssertSingleFailedCheck(2);
        }
    }
}
