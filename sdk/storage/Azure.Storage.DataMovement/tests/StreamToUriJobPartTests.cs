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
using System.IO;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class StreamToUriJobPartTests
    {
        private readonly int _maxDelayInSec = 1;
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        public StreamToUriJobPartTests() { }

        private static byte[] GetRandomBuffer(long size, Random random = null)
        {
            random ??= new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }

        private Mock<TransferJobInternal.QueueChunkTaskInternal> GetQueueChunkTask()
        {
            var mock = new Mock<TransferJobInternal.QueueChunkTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<Func<Task>>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<JobPartInternal.QueueChunkDelegate> GetPartQueueChunkTask()
        {
            var mock = new Mock<JobPartInternal.QueueChunkDelegate>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<Func<Task>>()))
                .Callback<Func<Task>>(
                async (funcTask) =>
                {
                    await funcTask().ConfigureAwait(false);
                })
                .Returns(Task.CompletedTask);
            return mock;
        }

        private StorageResourceItemProperties GetResourceProperties(long length)
        {
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> tags = DataProvider.BuildTags();

            Dictionary<string, object> sourceProperties = new()
            {
                { "ContentType", DefaultContentType },
                { "ContentEncoding", DefaultContentEncoding },
                { "ContentLanguage", DefaultContentLanguage },
                { "ContentDisposition", DefaultContentDisposition },
                { "CacheControl", DefaultCacheControl },
                { "Metadata", metadata },
                { "Tags", tags }
            };
            return new(
                    resourceLength: length,
                    eTag: new("ETag"),
                    lastModifiedTime: DateTimeOffset.UtcNow.AddHours(-1),
                    properties: sourceProperties);
        }

        private Mock<StorageResourceItem> GetLocalStorageResourceItem(long length = Constants.KB)
        {
            Mock<StorageResourceItem> mock = new();
            mock.Setup(r => r.Length).Returns(length);
            mock.Setup(r => r.Uri).Returns(new Uri("C:\\User\\folder\\file"));
            mock.Setup(r => r.ResourceId).Returns("mock");
            mock.Setup(r => r.ProviderId).Returns("mock");
            mock.Setup(r => r.GetSourceCheckpointData())
                .Returns(new MockResourceCheckpointData());
            mock.Setup(r => r.GetDestinationCheckpointData())
                .Returns(new MockResourceCheckpointData());
            return mock;
        }

        private Mock<StorageResourceItem> GetServiceStorageResourceItem(long length = Constants.KB)
        {
            Mock<StorageResourceItem> mock = new();
            mock.Setup(r => r.Length).Returns(length);
            mock.Setup(r => r.Uri).Returns(new Uri("https://storageacount.blob.core.windows.net/container/source"));
            mock.Setup(r => r.ResourceId).Returns("mock");
            mock.Setup(r => r.ProviderId).Returns("mock");
            mock.Setup(r => r.GetSourceCheckpointData())
                .Returns(new MockResourceCheckpointData());
            mock.Setup(r => r.GetDestinationCheckpointData())
                .Returns(new MockResourceCheckpointData());
            return mock;
        }

        private void VerifyInvocation(
            Mock<StorageResourceItem> destinationMock,
            Expression<Action<StorageResourceItem>> expectedInvocation,
            int numberOfInvocationCalls = 1,
            int maxWaitTimeInSec = 6)
        {
            CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(maxWaitTimeInSec));
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
                    }
                    catch (MockException)
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
            long length = Constants.KB;
            Mock<TransferJobInternal.QueueChunkTaskInternal> mockQueueChunkTask = GetQueueChunkTask();
            Mock<JobPartInternal.QueueChunkDelegate> mockPartQueueChunkTask = GetPartQueueChunkTask();

            // Set up Destination to copy in one shot with a large chunk size and smaller total length.
            Mock<StorageResourceItem> mockDestination = GetServiceStorageResourceItem();
            mockDestination.Setup(resource => resource.CopyFromStreamAsync(It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(r => r.MaxSupportedChunkSize).Returns(Constants.MB);

            // Set up source with properties and read stream
            Mock<StorageResourceItem> mockSource = GetLocalStorageResourceItem(length);
            StorageResourceItemProperties properties = GetResourceProperties(length);
            mockSource.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties));
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            StorageResourceReadStreamResult readStreamResult = new(
                    stream,
                    new HttpRange(0, length),
                    properties);
            mockSource.Setup(r => r.ReadStreamAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(readStreamResult));

            // Set up default checkpointer with transfer job
            LocalTransferCheckpointer checkpointer = new(default);
            await checkpointer.AddNewJobAsync(
                transferId: transferId,
                source: mockSource.Object,
                destination: mockDestination.Object);

            StreamToUriTransferJob job = new(
                new DataTransfer(
                    id: transferId,
                    transferManager: new TransferManager()),
                mockSource.Object,
                mockDestination.Object,
                new DataTransferOptions(),
                mockQueueChunkTask.Object,
                checkpointer,
                DataTransferErrorMode.StopOnAnyFailure,
                ArrayPool<byte>.Shared,
                new ClientDiagnostics(ClientOptions.Default));
            StreamToUriJobPart jobPart = await StreamToUriJobPart.CreateJobPartAsync(
                job,
                1);
            jobPart.SetQueueChunkDelegate(mockPartQueueChunkTask.Object);

            // Act
            await jobPart.ProcessPartToChunkAsync();

            // Verify
            VerifyInvocation(
                mockDestination,
                resource => resource.CopyFromStreamAsync(
                    stream,
                    length,
                    It.IsAny<bool>(),
                    length,
                    It.Is<StorageResourceWriteToOffsetOptions>(options =>
                        options != default && options.SourceProperties != default &&
                        options.SourceProperties.Equals(properties)),
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
            Mock<StorageResourceItem> mockSource = GetLocalStorageResourceItem(length);
            StorageResourceItemProperties properties = GetResourceProperties(length);
            mockSource.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties));

            // Setup destination with small chunk size and a larger source total length
            // to cause chunked copy
            Mock<StorageResourceItem> mockDestination = GetServiceStorageResourceItem();
            mockDestination.Setup(resource => resource.CopyFromStreamAsync(It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(resource => resource.CompleteTransferAsync(It.IsAny<bool>(), It.IsAny<StorageResourceCompleteTransferOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockDestination.Setup(r => r.MaxSupportedChunkSize).Returns(chunkSize);
            var data = GetRandomBuffer(length);
            using var stream = new MemoryStream(data);
            using var stream2 = new MemoryStream(data);
            using var stream3 = new MemoryStream(data);
            using var stream4 = new MemoryStream(data);
            mockSource.Setup(r => r.ReadStreamAsync(0, It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((long position, long? length, CancellationToken token) =>
                {
                    // Create a custom StorageResourceReadStreamResult
                    return new StorageResourceReadStreamResult(
                        stream, // Your actual stream
                        new HttpRange(position, chunkSize), // Your actual HttpRange
                        properties); // Your actual properties
                });
            mockSource.Setup(r => r.ReadStreamAsync(chunkSize, It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((long position, long? length, CancellationToken token) =>
                {
                    // Create a custom StorageResourceReadStreamResult
                    return new StorageResourceReadStreamResult(
                        stream2, // Your actual stream
                        new HttpRange(position, chunkSize), // Your actual HttpRange
                        properties); // Your actual properties
                });
            mockSource.Setup(r => r.ReadStreamAsync(chunkSize*2, It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((long position, long? length, CancellationToken token) =>
                {
                    // Create a custom StorageResourceReadStreamResult
                    return new StorageResourceReadStreamResult(
                        stream3, // Your actual stream
                        new HttpRange(position, chunkSize), // Your actual HttpRange
                        properties); // Your actual properties
                });
            mockSource.Setup(r => r.ReadStreamAsync(chunkSize * 3, It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((long position, long? length, CancellationToken token) =>
                {
                    // Create a custom StorageResourceReadStreamResult
                    return new StorageResourceReadStreamResult(
                        stream4, // Your actual stream
                        new HttpRange(position, chunkSize), // Your actual HttpRange
                        properties); // Your actual properties
                });

            // Set up default checkpointer with transfer job
            LocalTransferCheckpointer checkpointer = new(default);
            await checkpointer.AddNewJobAsync(
                transferId: transferId,
                source: mockSource.Object,
                destination: mockDestination.Object);

            Mock<TransferJobInternal.QueueChunkTaskInternal> mockQueueChunkTask = GetQueueChunkTask();
            Mock<JobPartInternal.QueueChunkDelegate> mockPartQueueChunkTask = GetPartQueueChunkTask();

            StreamToUriTransferJob job = new(
                new DataTransfer(
                    id: transferId,
                    transferManager: new TransferManager()),
                mockSource.Object,
                mockDestination.Object,
                new DataTransferOptions(),
                mockQueueChunkTask.Object,
                checkpointer,
                DataTransferErrorMode.StopOnAnyFailure,
                ArrayPool<byte>.Shared,
                new ClientDiagnostics(ClientOptions.Default));
            StreamToUriJobPart jobPart = await StreamToUriJobPart.CreateJobPartAsync(
                job,
                1);
            jobPart.SetQueueChunkDelegate(mockPartQueueChunkTask.Object);

            await jobPart.ProcessPartToChunkAsync();

            VerifyInvocation(
                mockDestination,
                resource => resource.CopyFromStreamAsync(
                    It.IsAny<Stream>(),
                    It.IsAny<long>(),
                    It.IsAny<bool>(),
                    It.IsAny<long>(),
                    It.Is<StorageResourceWriteToOffsetOptions>(options => options.SourceProperties.Equals(properties)),
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
