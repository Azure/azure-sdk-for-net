// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Listeners
{
    public class BlobTriggerExecutorTests
    {
        // Note: The tests that return true consume the notification.
        // The tests that return false reset the notification (to be provided again later).
        private const string TestClientRequestId = "testClientRequestId";

        private readonly TestLoggerProvider _loggerProvider = new TestLoggerProvider();
        private readonly ILogger<BlobListener> _logger;

        public BlobTriggerExecutorTests()
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(_loggerProvider);
            _logger = loggerFactory.CreateLogger<BlobListener>();
        }

        [Fact]
        public void ExecuteAsync_IfBlobDoesNotMatchPattern_ReturnsSuccessfulResult()
        {
            // Arrange
            var account = CreateAccount();
            var client = account.CreateCloudBlobClient();
            string containerName = "container";
            var container = client.GetContainerReference(containerName);
            var otherContainer = client.GetContainerReference("other");

            IBlobPathSource input = BlobPathSource.Create(containerName + "/{name}");

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input);

            // Note: this test does not set the PollId. This ensures that we work okay with null values for these.
            var blob = otherContainer.GetBlockBlobReference("nonmatch");
            var context = new BlobTriggerExecutorContext
            {
                Blob = blob,
                TriggerSource = BlobTriggerSource.ContainerScan
            };

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Equal("BlobDoesNotMatchPattern", logMessage.EventId.Name);
            Assert.Equal(LogLevel.Debug, logMessage.Level);
            Assert.Equal(6, logMessage.State.Count());
            Assert.Equal("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.Equal(containerName + "/{name}", logMessage.GetStateValue<string>("pattern"));
            Assert.Equal(blob.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.Null(logMessage.GetStateValue<string>("pollId"));
            Assert.Equal(context.TriggerSource, logMessage.GetStateValue<BlobTriggerSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Fact]
        public void ExecuteAsync_IfBlobDoesNotExist_ReturnsSuccessfulResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader(null);

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Equal("BlobHasNoETag", logMessage.EventId.Name);
            Assert.Equal(LogLevel.Debug, logMessage.Level);
            Assert.Equal(5, logMessage.State.Count());
            Assert.Equal(context.Blob.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.Equal("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.Equal(context.PollId, logMessage.GetStateValue<string>("pollId"));
            Assert.Equal(context.TriggerSource, logMessage.GetStateValue<BlobTriggerSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Fact]
        public void ExecuteAsync_IfCompletedBlobReceiptExists_ReturnsSuccessfulResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");
            IBlobReceiptManager receiptManager = CreateCompletedReceiptManager();

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Equal("BlobAlreadyProcessed", logMessage.EventId.Name);
            Assert.Equal(LogLevel.Debug, logMessage.Level);
            Assert.Equal(6, logMessage.State.Count());
            Assert.Equal("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.Equal(context.Blob.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.Equal("ETag", logMessage.GetStateValue<string>("eTag"));
            Assert.Equal(context.PollId, logMessage.GetStateValue<string>("pollId"));
            Assert.Equal(context.TriggerSource, logMessage.GetStateValue<BlobTriggerSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Fact]
        public void ExecuteAsync_IfIncompleteBlobReceiptExists_TriesToAcquireLease()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<string>(null))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            mock.Verify();
        }

        [Fact]
        public void ExecuteAsync_IfBlobReceiptDoesNotExist_TriesToCreateReceipt()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BlobReceipt>(null));
            mock.Setup(m => m.TryCreateAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(false))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            mock.Verify();
        }

        [Fact]
        public void ExecuteAsync_IfTryCreateReceiptFails_ReturnsUnsuccessfulResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BlobReceipt>(null));
            mock.Setup(m => m.TryCreateAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(false));
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.False(task.Result.Succeeded);
        }

        [Fact]
        public void ExecuteAsync_IfTryCreateReceiptSucceeds_TriesToAcquireLease()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BlobReceipt>(null));
            mock.Setup(m => m.TryCreateAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<string>(null))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            mock.Verify();
        }

        [Fact]
        public void ExecuteAsync_IfTryAcquireLeaseFails_ReturnsFailureResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<string>(null));
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.False(task.Result.Succeeded);
        }

        [Fact]
        public void ExecuteAsync_IfTryAcquireLeaseSucceeds_ReadsLatestReceipt()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            int calls = 0;
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                    {
                        return Task.FromResult(calls++ == 0 ? BlobReceipt.Incomplete : BlobReceipt.Complete);
                    });
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            mock.Setup(m => m.ReleaseLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0));
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            Assert.Equal(2, calls);
        }

        [Fact]
        public void ExecuteAsync_IfLeasedReceiptBecameCompleted_ReleasesLeaseAndReturnsSuccessResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            int calls = 0;
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    int call = calls++;
                    return Task.FromResult(call == 0 ? BlobReceipt.Incomplete : BlobReceipt.Complete);
                });
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            mock.Setup(m => m.ReleaseLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            mock.Verify();
            Assert.True(task.Result.Succeeded);
        }

        [Fact]
        public void ExecuteAsync_IfEnqueueAsyncThrows_ReleasesLease()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader("ETag");
            InvalidOperationException expectedException = new InvalidOperationException();

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            mock.Setup(m => m.ReleaseLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            Mock<IBlobTriggerQueueWriter> queueWriterMock = new Mock<IBlobTriggerQueueWriter>(MockBehavior.Strict);
            queueWriterMock
                .Setup(w => w.EnqueueAsync(It.IsAny<BlobTriggerMessage>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);
            IBlobTriggerQueueWriter queueWriter = queueWriterMock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, eTagReader, receiptManager,
                queueWriter);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            mock.Verify();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => task.GetAwaiter().GetResult());
            Assert.Same(expectedException, exception);
        }

        [Fact]
        public void ExecuteAsync_IfLeasedIncompleteReceipt_EnqueuesMessageMarksCompletedReleasesLeaseAndReturnsSuccessResult()
        {
            // Arrange
            string expectedFunctionId = "FunctionId";
            string expectedETag = "ETag";
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            IBlobETagReader eTagReader = CreateStubETagReader(expectedETag);


            Mock<IBlobReceiptManager> managerMock = CreateReceiptManagerReferenceMock();
            managerMock
                .Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            managerMock
                .Setup(m => m.TryAcquireLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            managerMock
                .Setup(m => m.MarkCompletedAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            managerMock
                .Setup(m => m.ReleaseLeaseAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobReceiptManager receiptManager = managerMock.Object;

            Mock<IBlobTriggerQueueWriter> queueWriterMock = new Mock<IBlobTriggerQueueWriter>(MockBehavior.Strict);
            queueWriterMock
                .Setup(w => w.EnqueueAsync(It.IsAny<BlobTriggerMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(("testQueueName", "testMessageId")));
            IBlobTriggerQueueWriter queueWriter = queueWriterMock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(expectedFunctionId, input, eTagReader,
                receiptManager, queueWriter);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            queueWriterMock
                .Verify(
                    w => w.EnqueueAsync(It.Is<BlobTriggerMessage>(m =>
                        m != null && m.FunctionId == expectedFunctionId /*&& m.BlobType == StorageBlobType.BlockBlob $$$ */ &&
                        m.BlobName == context.Blob.Name && m.ContainerName == context.Blob.Container.Name && m.ETag == expectedETag),
                        It.IsAny<CancellationToken>()),
                    Times.Once());
            managerMock.Verify();
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.Equal("BlobMessageEnqueued", logMessage.EventId.Name);
            Assert.Equal(LogLevel.Debug, logMessage.Level);
            Assert.Equal(7, logMessage.State.Count());
            Assert.Equal("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.Equal(context.Blob.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.Equal("testQueueName", logMessage.GetStateValue<string>("queueName"));
            Assert.Equal("testMessageId", logMessage.GetStateValue<string>("messageId"));
            Assert.Equal(context.PollId, logMessage.GetStateValue<string>("pollId"));
            Assert.Equal(context.TriggerSource, logMessage.GetStateValue<BlobTriggerSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        private static FakeStorageAccount CreateAccount()
        {
            //StorageClientFactory clientFactory = new StorageClientFactory();
            //return new StorageAccount(CloudStorageAccount.DevelopmentStorageAccount, clientFactory);
            return new FakeStorageAccount();
        }

        private static BlobTriggerExecutorContext CreateExecutorContext()
        {
            return new BlobTriggerExecutorContext
            {
                Blob = CreateBlobReference("container", "blob"),
                PollId = TestClientRequestId,
                TriggerSource = BlobTriggerSource.ContainerScan
            };
        }

        private static BlobTriggerExecutorContext CreateExecutorContext(string containerName, string blobName)
        {
            return new BlobTriggerExecutorContext
            {
                Blob = CreateBlobReference(containerName, blobName),
                PollId = TestClientRequestId,
                TriggerSource = BlobTriggerSource.ContainerScan
            };
        }

        private static CloudBlockBlob CreateBlobReference(string containerName, string blobName)
        {
            var account = CreateAccount();
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            return container.GetBlockBlobReference(blobName);
        }

        private static IBlobPathSource CreateBlobPath(ICloudBlob blob)
        {
            return new FixedBlobPathSource(blob.ToBlobPath());
        }

        private static IBlobReceiptManager CreateCompletedReceiptManager()
        {
            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<CloudBlockBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Complete));
            return mock.Object;
        }

        private static IBlobETagReader CreateDummyETagReader()
        {
            return new Mock<IBlobETagReader>(MockBehavior.Strict).Object;
        }

        private static IBlobReceiptManager CreateDummyReceiptManager()
        {
            return new Mock<IBlobReceiptManager>(MockBehavior.Strict).Object;
        }

        private static IBlobTriggerQueueWriter CreateDummyQueueWriter()
        {
            return new Mock<IBlobTriggerQueueWriter>(MockBehavior.Strict).Object;
        }

        private BlobTriggerExecutor CreateProductUnderTest(IBlobPathSource input)
        {
            return CreateProductUnderTest(input, CreateDummyETagReader());
        }

        private BlobTriggerExecutor CreateProductUnderTest(IBlobPathSource input, IBlobETagReader eTagReader)
        {
            return CreateProductUnderTest(input, eTagReader, CreateDummyReceiptManager());
        }

        private BlobTriggerExecutor CreateProductUnderTest(IBlobPathSource input, IBlobETagReader eTagReader,
            IBlobReceiptManager receiptManager)
        {
            return CreateProductUnderTest("FunctionId", input, eTagReader, receiptManager, CreateDummyQueueWriter());
        }

        private BlobTriggerExecutor CreateProductUnderTest(IBlobPathSource input, IBlobETagReader eTagReader,
            IBlobReceiptManager receiptManager, IBlobTriggerQueueWriter queueWriter)
        {
            return CreateProductUnderTest("FunctionId", input, eTagReader, receiptManager, queueWriter);
        }

        private BlobTriggerExecutor CreateProductUnderTest(string functionId, IBlobPathSource input,
            IBlobETagReader eTagReader, IBlobReceiptManager receiptManager, IBlobTriggerQueueWriter queueWriter)
        {
            var descriptor = new FunctionDescriptor
            {
                Id = functionId,
                LogName = functionId + "LogName"
            };

            return new BlobTriggerExecutor(String.Empty, descriptor, input, eTagReader, receiptManager, queueWriter, _logger);
        }

        private static Mock<IBlobReceiptManager> CreateReceiptManagerReferenceMock()
        {
            CloudBlockBlob receiptBlob = CreateAccount().CreateCloudBlobClient()
                .GetContainerReference("receipts").GetBlockBlobReference("item");
            Mock<IBlobReceiptManager> mock = new Mock<IBlobReceiptManager>(MockBehavior.Strict);
            mock.Setup(m => m.CreateReference(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .Returns(receiptBlob);
            return mock;
        }

        private static IBlobETagReader CreateStubETagReader(string eTag)
        {
            Mock<IBlobETagReader> mock = new Mock<IBlobETagReader>(MockBehavior.Strict);
            mock
                .Setup(r => r.GetETagAsync(It.IsAny<ICloudBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(eTag));
            return mock.Object;
        }
    }
}
