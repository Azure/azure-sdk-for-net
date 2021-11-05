// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class BlobQueueTriggerExecutorTests
    {
        private const string TestBlobName = "TestBlobName";
        private const string TestContainerName = "container-blobqueuetriggerexecutortests";
        private const string TestQueueMessageId = "abc123";

        private TestLoggerProvider _loggerProvider = new TestLoggerProvider();
        private ILogger<BlobListener> _logger;
        private BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainer;

        [SetUp]
        public void SetUp()
        {
            _loggerProvider = new TestLoggerProvider();
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(_loggerProvider);
            _logger = loggerFactory.CreateLogger<BlobListener>();

            _blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            _blobContainer = _blobServiceClient.GetBlobContainerClient(TestContainerName);
            _blobContainer.DeleteIfExists();
            _blobContainer.CreateIfNotExists();
        }

        [Test]
        public void ExecuteAsync_IfMessageIsNotJson_Throws()
        {
            // Arrange
            BlobQueueTriggerExecutor product = CreateProductUnderTest();
            var message = CreateMessage("ThisIsNotValidJson");

            // Act
            Task task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.Throws<JsonReaderException>(() => task.GetAwaiter().GetResult());
        }

        [Test]
        public void ExecuteAsync_IfMessageIsJsonNull_Throws()
        {
            // Arrange
            BlobQueueTriggerExecutor product = CreateProductUnderTest();
            var message = CreateMessage("null");

            // Act
            Task task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            ExceptionAssert.ThrowsInvalidOperation(() => task.GetAwaiter().GetResult(),
                "Invalid blob trigger message.");
        }

        [Test]
        public void ExecuteAsync_IfFunctionIdIsNull_Throws()
        {
            // Arrange
            BlobQueueTriggerExecutor product = CreateProductUnderTest();
            var message = CreateMessage("{}");

            // Act
            Task task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            ExceptionAssert.ThrowsInvalidOperation(() => task.GetAwaiter().GetResult(), "Invalid function ID.");
        }

        [Test]
        public void ExecuteAsync_IfMessageIsFunctionIdIsNotRegistered_ReturnsSuccessResult()
        {
            // Arrange
            BlobQueueTriggerExecutor product = CreateProductUnderTest();
            var message = CreateMessage(new BlobTriggerMessage { BlobName = TestBlobName, FunctionId = "Missing" });

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual("FunctionNotFound", logMessage.EventId.Name);
            Assert.AreEqual(LogLevel.Debug, logMessage.Level);
            Assert.AreEqual(4, logMessage.State.Count());
            Assert.AreEqual(TestBlobName, logMessage.GetStateValue<string>("blobName"));
            Assert.AreEqual("Missing", logMessage.GetStateValue<string>("functionName"));
            Assert.AreEqual(TestQueueMessageId, logMessage.GetStateValue<string>("queueMessageId"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Test]
        public void ExecuteAsync_IfBlobHasBeenDeleted_ReturnsSuccessResult()
        {
            // Arrange
            string functionId = "FunctionId";

            // by default, Blob doesn't exist in the fake account, so it's as if it were deleted.
            BlobQueueTriggerExecutor product = CreateProductUnderTest();

            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobServiceClient = _blobServiceClient,
                Executor = CreateDummyTriggeredFunctionExecutor()
            };
            product.Register(functionId, registration);

            var message = CreateMessage(functionId, "OriginalETag");

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.True(task.Result.Succeeded);

            // Validate log is written
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual("BlobNotFound", logMessage.EventId.Name);
            Assert.AreEqual(LogLevel.Debug, logMessage.Level);
            Assert.AreEqual(3, logMessage.State.Count());
            Assert.AreEqual(TestBlobName, logMessage.GetStateValue<string>("blobName"));
            Assert.AreEqual(TestQueueMessageId, logMessage.GetStateValue<string>("queueMessageId"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Test]
        public void ExecuteAsync_IfBlobHasChanged_NotifiesWatcherAndReturnsSuccessResult()
        {
            // Arrange
            string functionId = "FunctionId";
            string eTag = TouchBlob(TestContainerName, TestBlobName);
            Mock<IBlobWrittenWatcher> mock = new Mock<IBlobWrittenWatcher>(MockBehavior.Strict);
            mock.Setup(w => w.Notify(It.IsAny<BlobWithContainer<BlobBaseClient>>()))
                .Verifiable();
            IBlobWrittenWatcher blobWrittenWatcher = mock.Object;

            BlobQueueTriggerExecutor product = CreateProductUnderTest(null, blobWrittenWatcher);

            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobServiceClient = _blobServiceClient,
                Executor = CreateDummyTriggeredFunctionExecutor()
            };
            product.Register(functionId, registration);

            var message = CreateMessage(functionId, "OriginalETag");

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            task.WaitUntilCompleted();
            mock.Verify();
            Assert.True(task.Result.Succeeded);
        }

        [Test]
        public async Task ExecuteAsync_IfBlobIsUnchanged_CallsInnerExecutor()
        {
            // Arrange
            string functionId = "FunctionId";
            Guid expectedParentId = Guid.NewGuid();

            string matchingETag = TouchBlob(TestContainerName, TestBlobName);
            var message = CreateMessage(functionId, matchingETag);

            IBlobCausalityReader causalityReader = CreateStubCausalityReader(expectedParentId);

            FunctionResult expectedResult = new FunctionResult(true);
            Mock<ITriggeredFunctionExecutor> mock = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            mock.Setup(e => e.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback<TriggeredFunctionData, CancellationToken>(
                (mockInput, mockCancellationToken) =>
                {
                    Assert.AreEqual(expectedParentId, mockInput.ParentId);

                    var resultBlob = (BlobBaseClient)mockInput.TriggerValue;
                    Assert.AreEqual(TestBlobName, resultBlob.Name);
                })
                .ReturnsAsync(expectedResult)
                .Verifiable();

            ITriggeredFunctionExecutor innerExecutor = mock.Object;
            BlobQueueTriggerExecutor product = CreateProductUnderTest(causalityReader);

            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobServiceClient = _blobServiceClient,
                Executor = innerExecutor
            };
            product.Register(functionId, registration);

            // Act
            FunctionResult result = await product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.AreSame(expectedResult, result);
            mock.Verify();
        }

        [Test]
        public void ExecuteAsync_IfInnerExecutorSucceeds_ReturnsSuccessResult()
        {
            // Arrange
            string functionId = "FunctionId";
            string matchingETag = TouchBlob(TestContainerName, TestBlobName);

            IBlobCausalityReader causalityReader = CreateStubCausalityReader();

            FunctionResult expectedResult = new FunctionResult(true);
            Mock<ITriggeredFunctionExecutor> mock = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            mock.Setup(e => e.TryExecuteAsync(
                It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            BlobQueueTriggerExecutor product = CreateProductUnderTest(causalityReader);

            ITriggeredFunctionExecutor innerExecutor = mock.Object;
            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobServiceClient = _blobServiceClient,
                Executor = innerExecutor
            };
            product.Register(functionId, registration);

            var message = CreateMessage(functionId, matchingETag);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.AreSame(expectedResult, task.Result);
        }

        [Test]
        public void ExecuteAsync_IfInnerExecutorFails_ReturnsFailureResult()
        {
            // Arrange
            string functionId = "FunctionId";
            string matchingETag = TouchBlob(TestContainerName, TestBlobName);

            IBlobCausalityReader causalityReader = CreateStubCausalityReader();

            FunctionResult expectedResult = new FunctionResult(false);
            Mock<ITriggeredFunctionExecutor> mock = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            mock.Setup(e => e.TryExecuteAsync(
                It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            BlobQueueTriggerExecutor product = CreateProductUnderTest(causalityReader);

            ITriggeredFunctionExecutor innerExecutor = mock.Object;
            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobServiceClient = _blobServiceClient,
                Executor = innerExecutor
            };
            product.Register(functionId, registration);

            var message = CreateMessage(functionId, matchingETag);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.False(task.Result.Succeeded);
        }

        private static IBlobWrittenWatcher CreateDummyBlobWrittenWatcher()
        {
            return new Mock<IBlobWrittenWatcher>(MockBehavior.Strict).Object;
        }

        private static IBlobCausalityReader CreateDummyCausalityReader()
        {
            return new Mock<IBlobCausalityReader>(MockBehavior.Strict).Object;
        }

        private static ITriggeredFunctionExecutor CreateDummyTriggeredFunctionExecutor()
        {
            return new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict).Object;
        }

        private static QueueMessage CreateMessage(string functionId, string eTag)
        {
            BlobTriggerMessage triggerMessage = new BlobTriggerMessage
            {
                FunctionId = functionId,
                // BlobType = StorageBlobType.BlockBlob, $$$
                ContainerName = TestContainerName,
                BlobName = TestBlobName,
                ETag = eTag
            };
            return CreateMessage(triggerMessage);
        }

        private static QueueMessage CreateMessage(BlobTriggerMessage triggerMessage)
        {
            return CreateMessage(JsonConvert.SerializeObject(triggerMessage));
        }

        private static QueueMessage CreateMessage(string content)
        {
            return QueuesModelFactory.QueueMessage(TestQueueMessageId, "testReceipt", content, 0, insertedOn: DateTime.UtcNow);
        }

        private BlobQueueTriggerExecutor CreateProductUnderTest()
        {
            return CreateProductUnderTest(CreateDummyBlobWrittenWatcher());
        }

        private BlobQueueTriggerExecutor CreateProductUnderTest(IBlobWrittenWatcher blobWrittenWatcher)
        {
            IBlobCausalityReader causalityReader = CreateDummyCausalityReader();

            return CreateProductUnderTest(causalityReader, blobWrittenWatcher);
        }

        private BlobQueueTriggerExecutor CreateProductUnderTest(
            IBlobCausalityReader causalityReader)
        {
            return CreateProductUnderTest(causalityReader, CreateDummyBlobWrittenWatcher());
        }

        private BlobQueueTriggerExecutor CreateProductUnderTest(
             IBlobCausalityReader causalityReader, IBlobWrittenWatcher blobWrittenWatcher)
        {
            return new BlobQueueTriggerExecutor(causalityReader, BlobTriggerSource.LogsAndContainerScan, blobWrittenWatcher, _logger);
        }

        private static IBlobCausalityReader CreateStubCausalityReader()
        {
            return CreateStubCausalityReader(null);
        }

        private static IBlobCausalityReader CreateStubCausalityReader(Guid? parentId)
        {
            Mock<IBlobCausalityReader> mock = new Mock<IBlobCausalityReader>(MockBehavior.Strict);
            mock.Setup(r => r.GetWriterAsync(It.IsAny<BlobBaseClient>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(parentId));
            return mock.Object;
        }

        // Set the etag on the specified blob
        private string TouchBlob(string containerName, string blobName)
        {
            string content = Guid.NewGuid().ToString();
            var blobClient = _blobContainer.GetBlobClient(blobName);
            BlobContentInfo blobContentInfo = blobClient.Upload(new MemoryStream(Encoding.UTF8.GetBytes(content)), overwrite: true);
            return blobContentInfo.ETag.ToString();
        }
    }
}
