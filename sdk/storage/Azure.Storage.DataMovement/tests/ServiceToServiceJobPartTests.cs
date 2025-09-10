// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Moq;
using NUnit.Framework;
using Azure.Storage.Test;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class ServiceToServiceJobPartTests
    {
        private readonly int _maxDelayInSec = 1;
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private const string DefaultSourcePermissionKey = "anlfdjsgkljWLJITflo'fu903w8ueng";
        private TransferInternalState.RemoveTransferDelegate _removeTransferDelegate = (string transferId) => true;

        public ServiceToServiceJobPartTests() { }

        private Mock<JobPartInternal.QueueChunkDelegate> GetPartQueueChunkTask()
        {
            var mock = new Mock<JobPartInternal.QueueChunkDelegate>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<Func<Task>>()))
                .Callback<Func<Task>, CancellationToken>(
                async(funcTask, _) =>
                {
                    await funcTask().ConfigureAwait(false);
                })
                .Returns(new ValueTask(Task.CompletedTask));
            return mock;
        }

        private StorageResourceItemProperties GetResourceProperties(int length)
        {
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();

            Dictionary<string, object> sourceProperties = new()
            {
                { DataMovementConstants.ResourceProperties.ContentType, DefaultContentType },
                { DataMovementConstants.ResourceProperties.ContentEncoding, DefaultContentEncoding },
                { DataMovementConstants.ResourceProperties.ContentLanguage, DefaultContentLanguage },
                { DataMovementConstants.ResourceProperties.ContentDisposition, DefaultContentDisposition },
                { DataMovementConstants.ResourceProperties.CacheControl, DefaultCacheControl },
                { DataMovementConstants.ResourceProperties.Metadata, metadata },
                { DataMovementConstants.ResourceProperties.SourceFilePermissionKey, DefaultSourcePermissionKey }
            };
            return new StorageResourceItemProperties()
            {
                ResourceLength = length,
                ETag = new ETag("ETag"),
                LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                RawProperties = sourceProperties
            };
        }

        private Mock<StorageResourceItem> GetStorageResourceItem(int length = Constants.KB)
        {
            Mock<StorageResourceItem> mock = new();
            mock.Setup(r => r.Length).Returns(length);
            mock.Setup(r => r.Uri).Returns(new Uri("https://storageacount.blob.core.windows.net/container/source"));
            mock.Setup(r => r.ResourceId).Returns("mock");
            mock.Setup(r => r.ProviderId).Returns("mock");
            mock.Setup(r => r.GetSourceCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            mock.Setup(r => r.GetDestinationCheckpointDetails())
                .Returns(new MockResourceCheckpointDetails());
            return mock;
        }

        private void VerifyInvocation(
            Mock<StorageResourceItem> destinationMock,
            Expression<Action<StorageResourceItem>> expectedInvocation,
            int numberOfInvocationCalls = 1,
            int maxWaitTimeInSec = 6)
        {
            using CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(maxWaitTimeInSec));
            CancellationToken cancellationToken = cancellationSource.Token;
            bool verified = false;

            try
            {
                do
                {
                    CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                    // If it exceeds the count we should just fail. But if it's less,
                    // we can retry and see if the invocation we expected will be called.
                    Thread.Sleep(TimeSpan.FromSeconds(_maxDelayInSec));

                    try
                    {
                        destinationMock.Verify(expectedInvocation, Times.Exactly(numberOfInvocationCalls));
                        verified = true;
                    } catch (MockException)
                    {
                        // This exception tells us it hasn't seen the expected invocation
                        // which might happen due to parallelism.
                    }
                } while (!verified);
            }
            catch (TaskCanceledException)
            {
                string message = "Timed out waiting for the correct amount of invocations for the task";
                Assert.Fail(message);
            }
        }

        [Test]
        public async Task ProcessPartToChunkAsync_OneShot()
        {
            //Arrange
            string transferId = Guid.NewGuid().ToString();
            int length = Constants.KB;

            // Set up source with properties
            Mock<StorageResourceItem> mockSource = GetStorageResourceItem(length);
            StorageResourceItemProperties properties = GetResourceProperties(length);
            HttpAuthorization httpAuthorization = new("BearerScheme", "authtoken");
            mockSource.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties));
            mockSource.Setup(r => r.GetCopyAuthorizationHeaderAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(httpAuthorization));
            mockSource.Setup(b => b.ShouldItemTransferAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));

            // Set up Destination to copy in one shot with a large chunk size and smaller total length.
            Mock<StorageResourceItem> mockDestination = GetStorageResourceItem();
            mockDestination.Setup(r => r.SetPermissionsAsync(It.IsAny<StorageResourceItem>(), It.IsAny<StorageResourceItemProperties>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(resource => resource.CopyFromUriAsync(It.IsAny<StorageResourceItem>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<StorageResourceCopyFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(r => r.MaxSupportedSingleTransferSize).Returns(Constants.MB);
            mockDestination.Setup(r => r.MaxSupportedChunkSize).Returns(Constants.MB);

            SingleItemStorageResourceContainer source = new(mockSource.Object);
            SingleItemStorageResourceContainer destination = new(mockDestination.Object);

            // Set up default checkpointer with transfer job
            LocalTransferCheckpointer checkpointer = new(default);
            await checkpointer.AddNewJobAsync(
                transferId: transferId,
                source: mockSource.Object,
                destination: mockDestination.Object);

            Mock<JobPartInternal.QueueChunkDelegate> mockPartQueueChunkTask = GetPartQueueChunkTask();

            TransferJobInternal job = new(
                new TransferOperation(removeTransferDelegate: _removeTransferDelegate,id: transferId),
                source,
                destination,
                ServiceToServiceJobPart.CreateJobPartAsync,
                new TransferOptions(),
                checkpointer,
                TransferErrorMode.StopOnAnyFailure,
                ArrayPool<byte>.Shared,
                new ClientDiagnostics(ClientOptions.Default));
            ServiceToServiceJobPart jobPart = await ServiceToServiceJobPart.CreateJobPartAsync(
                job,
                1,
                mockSource.Object,
                mockDestination.Object) as ServiceToServiceJobPart;
            jobPart.SetQueueChunkDelegate(mockPartQueueChunkTask.Object);

            // Act
            await jobPart.ProcessPartToChunkAsync();

            // Verify
            VerifyInvocation(
                mockDestination,
                resource => resource.SetPermissionsAsync(
                    mockSource.Object,
                    properties,
                    It.IsAny<CancellationToken>()));
            VerifyInvocation(
                mockDestination,
                resource => resource.CopyFromUriAsync(
                    mockSource.Object,
                    It.IsAny<bool>(),
                    length,
                    It.Is<StorageResourceCopyFromUriOptions>(options =>
                        options.SourceProperties.Equals(properties) &&
                        options.SourceAuthentication.Equals(httpAuthorization)),
                    It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task ProcessPartToChunkAsync_Chunks()
        {
            // Arrange
            string transferId = Guid.NewGuid().ToString();
            int length = Constants.KB * 4;
            int chunkSize = Constants.KB;
            int chunkAmount = length / chunkSize;
            Mock<StorageResourceItem> mockSource = GetStorageResourceItem(length);
            StorageResourceItemProperties properties = GetResourceProperties(length);
            mockSource.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties));
            mockSource.Setup(b => b.ShouldItemTransferAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));

            // Setup destination with small chunk size and a larger source total length
            // to cause chunked copy
            Mock<StorageResourceItem> mockDestination = GetStorageResourceItem();
            mockDestination.Setup(resource => resource.CopyBlockFromUriAsync(It.IsAny<StorageResourceItem>(), It.IsAny<HttpRange>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<StorageResourceCopyFromUriOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(resource => resource.CompleteTransferAsync(It.IsAny<bool>(), It.IsAny<StorageResourceCompleteTransferOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(r => r.MaxSupportedSingleTransferSize).Returns(length - 1);
            mockDestination.Setup(r => r.MaxSupportedChunkSize).Returns(chunkSize);
            mockDestination.Setup(r => r.MaxSupportedChunkCount).Returns(int.MaxValue);

            SingleItemStorageResourceContainer source = new(mockSource.Object);
            SingleItemStorageResourceContainer destination = new(mockDestination.Object);

            // Set up default checkpointer with transfer job
            LocalTransferCheckpointer checkpointer = new(default);
            await checkpointer.AddNewJobAsync(
                transferId: transferId,
                source: mockSource.Object,
                destination: mockDestination.Object);

            Mock<JobPartInternal.QueueChunkDelegate> mockPartQueueChunkTask = GetPartQueueChunkTask();

            TransferJobInternal job = new(
                new TransferOperation(removeTransferDelegate: _removeTransferDelegate, id: transferId),
                source,
                destination,
                ServiceToServiceJobPart.CreateJobPartAsync,
                new TransferOptions(),
                checkpointer,
                TransferErrorMode.StopOnAnyFailure,
                ArrayPool<byte>.Shared,
                new ClientDiagnostics(ClientOptions.Default));
            ServiceToServiceJobPart jobPart = await ServiceToServiceJobPart.CreateJobPartAsync(
                job,
                1,
                mockSource.Object,
                mockDestination.Object) as ServiceToServiceJobPart;
            jobPart.SetQueueChunkDelegate(mockPartQueueChunkTask.Object);

            await jobPart.ProcessPartToChunkAsync();

            VerifyInvocation(
                mockDestination,
                resource => resource.SetPermissionsAsync(
                    mockSource.Object,
                    properties,
                    It.IsAny<CancellationToken>()));
            VerifyInvocation(
                mockDestination,
                resource => resource.CopyBlockFromUriAsync(
                    mockSource.Object,
                    It.IsAny<HttpRange>(),
                    It.IsAny<bool>(),
                    length,
                    It.Is<StorageResourceCopyFromUriOptions>(options =>
                        options.SourceProperties.Equals(properties)),
                    It.IsAny<CancellationToken>()),
                chunkAmount);
            VerifyInvocation(
                mockDestination,
                resource => resource.CompleteTransferAsync(
                    It.IsAny<bool>(),
                    It.Is<StorageResourceCompleteTransferOptions>(options =>
                        options.SourceProperties.Equals(properties)),
                    It.IsAny<CancellationToken>()));
        }
    }
}
