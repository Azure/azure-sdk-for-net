// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class BlobTriggerExecutorTests
    {
        // Note: The tests that return true consume the notification.
        // The tests that return false reset the notification (to be provided again later).
        private const string TestClientRequestId = "testClientRequestId";

        private const string ContainerName = "container-blobtriggerexecutortests";

        private TestLoggerProvider _loggerProvider;
        private ILogger<BlobListener> _logger;
        private BlobServiceClient _blobServiceClient;

        [SetUp]
        public void SetUp()
        {
            _loggerProvider = new TestLoggerProvider();
            _blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            _blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(_loggerProvider);
            _logger = loggerFactory.CreateLogger<BlobListener>();
        }

        [Test]
        public void ExecuteAsync_IfBlobDoesNotMatchPattern_ReturnsSuccessfulResult()
        {
            // Arrange
            string containerName = ContainerName;
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            var otherContainer = _blobServiceClient.GetBlobContainerClient("other");

            IBlobPathSource input = BlobPathSource.Create(containerName + "/{name}");

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input);

            // Note: this test does not set the PollId. This ensures that we work okay with null values for these.
            var blob = otherContainer.GetBlockBlobClient("nonmatch");
            var context = new BlobTriggerExecutorContext
            {
                Blob = new BlobWithContainer<BlobBaseClient>(otherContainer, blob),
                TriggerSource = BlobTriggerScanSource.ContainerScan
            };

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual("BlobDoesNotMatchPattern", logMessage.EventId.Name);
            Assert.AreEqual(LogLevel.Debug, logMessage.Level);
            Assert.AreEqual(6, logMessage.State.Count());
            Assert.AreEqual("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.AreEqual(containerName + "/{name}", logMessage.GetStateValue<string>("pattern"));
            Assert.AreEqual(blob.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.Null(logMessage.GetStateValue<string>("pollId"));
            Assert.AreEqual(context.TriggerSource, logMessage.GetStateValue<BlobTriggerScanSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Test]
        public void ExecuteAsync_IfBlobDoesNotExist_ReturnsSuccessfulResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext(createBlob: false);
            IBlobPathSource input = CreateBlobPath(context.Blob);

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual("BlobHasNoETag", logMessage.EventId.Name);
            Assert.AreEqual(LogLevel.Debug, logMessage.Level);
            Assert.AreEqual(5, logMessage.State.Count());
            Assert.AreEqual(context.Blob.BlobClient.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.AreEqual("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.AreEqual(context.PollId, logMessage.GetStateValue<string>("pollId"));
            Assert.AreEqual(context.TriggerSource, logMessage.GetStateValue<BlobTriggerScanSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Test]
        public void ExecuteAsync_IfCompletedBlobReceiptExists_ReturnsSuccessfulResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            string expectedETag = context.Blob.BlobClient.GetProperties().Value.ETag.ToString();
            IBlobReceiptManager receiptManager = CreateCompletedReceiptManager();

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual("BlobAlreadyProcessed", logMessage.EventId.Name);
            Assert.AreEqual(LogLevel.Debug, logMessage.Level);
            Assert.AreEqual(6, logMessage.State.Count());
            Assert.AreEqual("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.AreEqual(context.Blob.BlobClient.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.AreEqual(expectedETag, logMessage.GetStateValue<string>("eTag"));
            Assert.AreEqual(context.PollId, logMessage.GetStateValue<string>("pollId"));
            Assert.AreEqual(context.TriggerSource, logMessage.GetStateValue<BlobTriggerScanSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Test]
        public void ExecuteAsync_IfIncompleteBlobReceiptExists_TriesToAcquireLease()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<string>(null))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            mock.Verify();
        }

        [Test]
        public void ExecuteAsync_IfBlobReceiptDoesNotExist_TriesToCreateReceipt()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BlobReceipt>(null));
            mock.Setup(m => m.TryCreateAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(false))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            mock.Verify();
        }

        [Test]
        public void ExecuteAsync_IfTryCreateReceiptFails_ReturnsUnsuccessfulResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BlobReceipt>(null));
            mock.Setup(m => m.TryCreateAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(false));
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.False(task.Result.Succeeded);
        }

        [Test]
        public void ExecuteAsync_IfTryCreateReceiptSucceeds_TriesToAcquireLease()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BlobReceipt>(null));
            mock.Setup(m => m.TryCreateAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<string>(null))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            mock.Verify();
        }

        [Test]
        public void ExecuteAsync_IfTryAcquireLeaseFails_ReturnsFailureResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<string>(null));
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            Assert.False(task.Result.Succeeded);
        }

        [Test]
        public void ExecuteAsync_IfTryAcquireLeaseSucceeds_ReadsLatestReceipt()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            int calls = 0;
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                    {
                        return Task.FromResult(calls++ == 0 ? BlobReceipt.Incomplete : BlobReceipt.Complete);
                    });
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            mock.Setup(m => m.ReleaseLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0));
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.GetAwaiter().GetResult();
            Assert.AreEqual(2, calls);
        }

        [Test]
        public void ExecuteAsync_IfLeasedReceiptBecameCompleted_ReleasesLeaseAndReturnsSuccessResult()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            int calls = 0;
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    int call = calls++;
                    return Task.FromResult(call == 0 ? BlobReceipt.Incomplete : BlobReceipt.Complete);
                });
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            mock.Setup(m => m.ReleaseLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            mock.Verify();
            Assert.True(task.Result.Succeeded);
        }

        [Test]
        public void ExecuteAsync_IfEnqueueAsyncThrows_ReleasesLease()
        {
            // Arrange
            BlobTriggerExecutorContext context = CreateExecutorContext();
            IBlobPathSource input = CreateBlobPath(context.Blob);
            InvalidOperationException expectedException = new InvalidOperationException();

            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            mock.Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            mock.Setup(m => m.ReleaseLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobReceiptManager receiptManager = mock.Object;

            Mock<IBlobTriggerQueueWriter> queueWriterMock = new Mock<IBlobTriggerQueueWriter>(MockBehavior.Strict);
            queueWriterMock
                .Setup(w => w.EnqueueAsync(It.IsAny<BlobTriggerMessage>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);
            IBlobTriggerQueueWriter queueWriter = queueWriterMock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(input, receiptManager,
                queueWriter);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            mock.Verify();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => task.GetAwaiter().GetResult());
            Assert.AreSame(expectedException, exception);
        }

        [Test]
        public void ExecuteAsync_IfLeasedIncompleteReceipt_EnqueuesMessageMarksCompletedReleasesLeaseAndReturnsSuccessResult()
        {
            // Arrange
            string expectedFunctionId = "FunctionId";
            BlobTriggerExecutorContext context = CreateExecutorContext();
            string expectedETag = context.Blob.BlobClient.GetProperties().Value.ETag.ToString();
            IBlobPathSource input = CreateBlobPath(context.Blob);

            Mock<IBlobReceiptManager> managerMock = CreateReceiptManagerReferenceMock();
            managerMock
                .Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Incomplete));
            managerMock
                .Setup(m => m.TryAcquireLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("LeaseId"));
            managerMock
                .Setup(m => m.MarkCompletedAsync(It.IsAny<BlockBlobClient>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            managerMock
                .Setup(m => m.ReleaseLeaseAsync(It.IsAny<BlockBlobClient>(), It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0))
                .Verifiable();
            IBlobReceiptManager receiptManager = managerMock.Object;

            Mock<IBlobTriggerQueueWriter> queueWriterMock = new Mock<IBlobTriggerQueueWriter>(MockBehavior.Strict);
            queueWriterMock
                .Setup(w => w.EnqueueAsync(It.IsAny<BlobTriggerMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(("testQueueName", "testMessageId")));
            IBlobTriggerQueueWriter queueWriter = queueWriterMock.Object;

            ITriggerExecutor<BlobTriggerExecutorContext> product = CreateProductUnderTest(expectedFunctionId, input,
                receiptManager, queueWriter);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(context, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            queueWriterMock
                .Verify(
                    w => w.EnqueueAsync(It.Is<BlobTriggerMessage>(m =>
                        m != null && m.FunctionId == expectedFunctionId /*&& m.BlobType == StorageBlobType.BlockBlob $$$ */ &&
                        m.BlobName == context.Blob.BlobClient.Name && m.ContainerName == context.Blob.BlobClient.BlobContainerName && m.ETag == expectedETag),
                        It.IsAny<CancellationToken>()),
                    Times.Once());
            managerMock.Verify();
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual("BlobMessageEnqueued", logMessage.EventId.Name);
            Assert.AreEqual(LogLevel.Debug, logMessage.Level);
            Assert.AreEqual(7, logMessage.State.Count());
            Assert.AreEqual("FunctionIdLogName", logMessage.GetStateValue<string>("functionName"));
            Assert.AreEqual(context.Blob.BlobClient.Name, logMessage.GetStateValue<string>("blobName"));
            Assert.AreEqual("testQueueName", logMessage.GetStateValue<string>("queueName"));
            Assert.AreEqual("testMessageId", logMessage.GetStateValue<string>("messageId"));
            Assert.AreEqual(context.PollId, logMessage.GetStateValue<string>("pollId"));
            Assert.AreEqual(context.TriggerSource, logMessage.GetStateValue<BlobTriggerScanSource>("triggerSource"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        private BlobTriggerExecutorContext CreateExecutorContext(bool createBlob = true)
        {
            return new BlobTriggerExecutorContext
            {
                Blob = CreateBlobReference(ContainerName, "blob", createBlob),
                PollId = TestClientRequestId,
                TriggerSource = BlobTriggerScanSource.ContainerScan
            };
        }

        private BlobWithContainer<BlobBaseClient> CreateBlobReference(string containerName, string blobName, bool createBlob = true)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            container.CreateIfNotExists();
            var blobClient = container.GetBlockBlobClient(blobName);
            if (createBlob)
            {
                blobClient.Upload(new MemoryStream());
            }
            return new BlobWithContainer<BlobBaseClient>(container, blobClient);
        }

        private static IBlobPathSource CreateBlobPath(BlobWithContainer<BlobBaseClient> blob)
        {
            return new FixedBlobPathSource(blob.BlobClient.ToBlobPath());
        }

        private IBlobReceiptManager CreateCompletedReceiptManager()
        {
            Mock<IBlobReceiptManager> mock = CreateReceiptManagerReferenceMock();
            mock.Setup(m => m.TryReadAsync(It.IsAny<BlockBlobClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(BlobReceipt.Complete));
            return mock.Object;
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
            return CreateProductUnderTest(input, CreateDummyReceiptManager());
        }

        private BlobTriggerExecutor CreateProductUnderTest(IBlobPathSource input,
            IBlobReceiptManager receiptManager)
        {
            return CreateProductUnderTest("FunctionId", input, receiptManager, CreateDummyQueueWriter());
        }

        private BlobTriggerExecutor CreateProductUnderTest(IBlobPathSource input,
            IBlobReceiptManager receiptManager, IBlobTriggerQueueWriter queueWriter)
        {
            return CreateProductUnderTest("FunctionId", input, receiptManager, queueWriter);
        }

        private BlobTriggerExecutor CreateProductUnderTest(string functionId, IBlobPathSource input,
            IBlobReceiptManager receiptManager, IBlobTriggerQueueWriter queueWriter)
        {
            var descriptor = new FunctionDescriptor
            {
                Id = functionId,
                LogName = functionId + "LogName"
            };

            return new BlobTriggerExecutor(String.Empty, descriptor, input, receiptManager, queueWriter, _logger);
        }

        private Mock<IBlobReceiptManager> CreateReceiptManagerReferenceMock()
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("receipts");
            var receiptBlob = blobContainerClient.GetBlockBlobClient("item");
            Mock<IBlobReceiptManager> mock = new Mock<IBlobReceiptManager>(MockBehavior.Strict);
            mock.Setup(m => m.CreateReference(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .Returns(receiptBlob);
            return mock;
        }
    }
}
