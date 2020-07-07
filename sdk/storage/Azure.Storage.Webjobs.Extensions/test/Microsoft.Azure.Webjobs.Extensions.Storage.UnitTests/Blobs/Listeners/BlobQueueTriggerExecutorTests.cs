// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FakeStorage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Listeners
{
    public class BlobQueueTriggerExecutorTests
    {
        private const string TestBlobName = "TestBlobName";
        private const string TestContainerName = "container";
        private const string TestQueueMessageId = "abc123";

        private readonly TestLoggerProvider _loggerProvider = new TestLoggerProvider();
        private readonly ILogger<BlobListener> _logger;

        public BlobQueueTriggerExecutorTests()
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(_loggerProvider);
            _logger = loggerFactory.CreateLogger<BlobListener>();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
            Assert.Equal("FunctionNotFound", logMessage.EventId.Name);
            Assert.Equal(LogLevel.Debug, logMessage.Level);
            Assert.Equal(4, logMessage.State.Count());
            Assert.Equal(TestBlobName, logMessage.GetStateValue<string>("blobName"));
            Assert.Equal("Missing", logMessage.GetStateValue<string>("functionName"));
            Assert.Equal(TestQueueMessageId, logMessage.GetStateValue<string>("queueMessageId"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Fact]
        public void ExecuteAsync_IfBlobHasBeenDeleted_ReturnsSuccessResult()
        {
            // Arrange
            var account = new FakeAccount();
            string functionId = "FunctionId";

            // by default, Blob doesn't exist in the fake account, so it's as if it were deleted. 
            BlobQueueTriggerExecutor product = CreateProductUnderTest();

            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobClient = account.CreateCloudBlobClient(),
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
            Assert.Equal("BlobNotFound", logMessage.EventId.Name);
            Assert.Equal(LogLevel.Debug, logMessage.Level);
            Assert.Equal(3, logMessage.State.Count());
            Assert.Equal(TestBlobName, logMessage.GetStateValue<string>("blobName"));
            Assert.Equal(TestQueueMessageId, logMessage.GetStateValue<string>("queueMessageId"));
            Assert.True(!string.IsNullOrWhiteSpace(logMessage.GetStateValue<string>("{OriginalFormat}")));
        }

        [Fact]
        public void ExecuteAsync_IfBlobHasChanged_NotifiesWatcherAndReturnsSuccessResult()
        {
            var account = new FakeAccount();

            // Arrange
            string functionId = "FunctionId";
            SetEtag(account, TestContainerName, TestBlobName, "NewETag");
            Mock<IBlobWrittenWatcher> mock = new Mock<IBlobWrittenWatcher>(MockBehavior.Strict);
            mock.Setup(w => w.Notify(It.IsAny<ICloudBlob>()))
                .Verifiable();
            IBlobWrittenWatcher blobWrittenWatcher = mock.Object;

            BlobQueueTriggerExecutor product = CreateProductUnderTest(null, blobWrittenWatcher);

            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobClient = account.CreateCloudBlobClient(),
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

        [Fact]
        public async Task ExecuteAsync_IfBlobIsUnchanged_CallsInnerExecutor()
        {
            // Arrange
            var account = new FakeAccount();
            string functionId = "FunctionId";
            string matchingETag = "ETag";
            Guid expectedParentId = Guid.NewGuid();
            var message = CreateMessage(functionId, matchingETag);

            SetEtag(account, TestContainerName, TestBlobName, matchingETag);

            IBlobCausalityReader causalityReader = CreateStubCausalityReader(expectedParentId);

            FunctionResult expectedResult = new FunctionResult(true);
            Mock<ITriggeredFunctionExecutor> mock = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            mock.Setup(e => e.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback<TriggeredFunctionData, CancellationToken>(
                (mockInput, mockCancellationToken) =>
                {
                    Assert.Equal(expectedParentId, mockInput.ParentId);

                    var resultBlob = (ICloudBlob)mockInput.TriggerValue;
                    Assert.Equal(TestBlobName, resultBlob.Name);
                })
                .ReturnsAsync(expectedResult)
                .Verifiable();

            ITriggeredFunctionExecutor innerExecutor = mock.Object;
            BlobQueueTriggerExecutor product = CreateProductUnderTest(causalityReader);

            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                BlobClient = account.CreateCloudBlobClient(),
                Executor = innerExecutor
            };
            product.Register(functionId, registration);

            // Act
            FunctionResult result = await product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.Same(expectedResult, result);
            mock.Verify();
        }

        [Fact]
        public void ExecuteAsync_IfInnerExecutorSucceeds_ReturnsSuccessResult()
        {
            // Arrange
            var account = new FakeAccount();

            string functionId = "FunctionId";
            string matchingETag = "ETag";

            SetEtag(account, TestContainerName, TestBlobName, matchingETag);

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
                BlobClient = account.CreateCloudBlobClient(),
                Executor = innerExecutor
            };
            product.Register(functionId, registration);

            var message = CreateMessage(functionId, matchingETag);

            // Act
            Task<FunctionResult> task = product.ExecuteAsync(message, CancellationToken.None);

            // Assert
            Assert.Same(expectedResult, task.Result);
        }

        [Fact]
        public void ExecuteAsync_IfInnerExecutorFails_ReturnsFailureResult()
        {
            // Arrange
            var account = new FakeAccount();

            string functionId = "FunctionId";
            string matchingETag = "ETag";

            SetEtag(account, TestContainerName, TestBlobName, matchingETag);

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
                BlobClient = account.CreateCloudBlobClient(),
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

        private static ITriggeredFunctionExecutor CreateDummyInnerExecutor()
        {
            return new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict).Object;
        }

        private static ITriggeredFunctionExecutor CreateDummyTriggeredFunctionExecutor()
        {
            return new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict).Object;
        }

        private static CloudQueueMessage CreateMessage(string functionId, string eTag)
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

        private static CloudQueueMessage CreateMessage(BlobTriggerMessage triggerMessage)
        {
            return CreateMessage(JsonConvert.SerializeObject(triggerMessage));
        }

        private static CloudQueueMessage CreateMessage(string content)
        {
            var message = new CloudQueueMessage(content);
            message.SetId(TestQueueMessageId);
            message.SetInsertionTime(DateTimeOffset.UtcNow);
            message.SetDequeueCount(0);
            return message;
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
            return new BlobQueueTriggerExecutor(causalityReader, blobWrittenWatcher, _logger);
        }

        private static IBlobCausalityReader CreateStubCausalityReader()
        {
            return CreateStubCausalityReader(null);
        }

        private static IBlobCausalityReader CreateStubCausalityReader(Guid? parentId)
        {
            Mock<IBlobCausalityReader> mock = new Mock<IBlobCausalityReader>(MockBehavior.Strict);
            mock.Setup(r => r.GetWriterAsync(It.IsAny<ICloudBlob>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(parentId));
            return mock.Object;
        }

        private static IFunctionInstance CreateStubFunctionInstance(Guid? parentId)
        {
            Mock<IFunctionInstance> mock = new Mock<IFunctionInstance>(MockBehavior.Strict);
            mock.Setup(i => i.ParentId)
                .Returns(parentId);
            return mock.Object;
        }

        private static IFunctionExecutor CreateStubInnerExecutor(IDelayedException result)
        {
            Mock<IFunctionExecutor> mock = new Mock<IFunctionExecutor>(MockBehavior.Strict);
            mock.Setup(e => e.TryExecuteAsync(It.IsAny<IFunctionInstance>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(result));
            return mock.Object;
        }

        // Set the etag on the specified blob
        private static void SetEtag(FakeAccount account, string containerName, string blobName, string etag)
        {
            Mock<ICloudBlob> mockBlob = new Mock<ICloudBlob>(MockBehavior.Strict);
            mockBlob.SetupGet(b => b.Properties).Returns(new BlobProperties().SetEtag(etag));
            mockBlob.SetupGet(b => b.Name).Returns(blobName);

            account.SetBlob(containerName, blobName, mockBlob.Object);
        }
    }
}
