// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.Threading;
using Azure.Core;
using Azure.Storage.Test;
using Azure.Core.Pipeline;
using System.Threading.Channels;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class CommitChunkHandlerTests
    {
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";

        private readonly int _maxDelayInSec = 1;
        private readonly string _failedEventMsg = "Amount of Failed Event Handler calls was incorrect.";
        private readonly string _putBlockMsg = "Amount of Put Block Task calls were incorrect";
        private readonly string _reportProgressInBytesMsg = "Amount of Progress amount calls were incorrect.";
        private readonly string _commitBlockMsg = "Amount of Commit Block Task calls were incorrect";

        private ClientDiagnostics ClientDiagnostics => new(ClientOptions.Default);

        private void VerifyDelegateInvocations(
            MockCommitChunkBehaviors behaviors,
            int expectedFailureCount,
            int expectedPutBlockCount,
            int expectedReportProgressCount,
            int expectedCompleteFileCount,
            int maxWaitTimeInSec = 6)
        {
            using CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(maxWaitTimeInSec));
            CancellationToken cancellationToken = cancellationSource.Token;
            int currentFailedEventCount = behaviors.InvokeFailedEventHandlerTask.Invocations.Count;
            int currentPutBlockCount = behaviors.PutBlockTask.Invocations.Count;
            int currentProgressReportedCount = behaviors.ReportProgressInBytesTask.Invocations.Count;
            int currentCompleteDownloadCount = behaviors.QueueCommitBlockTask.Invocations.Count;
            try
            {
                while (currentFailedEventCount != expectedFailureCount
                       || currentPutBlockCount != expectedPutBlockCount
                       || currentProgressReportedCount != expectedReportProgressCount
                       || currentCompleteDownloadCount != expectedCompleteFileCount)
                {
                    CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                    // If it exceeds the count we should just fail. But if it's less,
                    // we can retry and see if the invocation count will reach the
                    // expected amount
                    Thread.Sleep(TimeSpan.FromSeconds(_maxDelayInSec));

                    currentFailedEventCount = behaviors.InvokeFailedEventHandlerTask.Invocations.Count;
                    Assert.LessOrEqual(currentFailedEventCount, expectedFailureCount, _failedEventMsg);
                    currentPutBlockCount = behaviors.PutBlockTask.Invocations.Count;
                    Assert.LessOrEqual(currentPutBlockCount, expectedPutBlockCount, _putBlockMsg);
                    currentProgressReportedCount = behaviors.ReportProgressInBytesTask.Invocations.Count;
                    Assert.LessOrEqual(currentProgressReportedCount, expectedReportProgressCount, _reportProgressInBytesMsg);
                    currentCompleteDownloadCount = behaviors.QueueCommitBlockTask.Invocations.Count;
                    Assert.LessOrEqual(currentCompleteDownloadCount, expectedCompleteFileCount, _commitBlockMsg);
                }
            }
            catch (TaskCanceledException)
            {
                string message = "Timed out waiting for the correct amount of invocations for each task\n" +
                    $"Current Failed Event Invocations: {currentFailedEventCount} | Expected: {expectedFailureCount}\n" +
                    $"Current Put Block Invocations: {currentPutBlockCount} | Expected: {expectedPutBlockCount}\n" +
                    $"Current Progress Reported Invocations: {currentProgressReportedCount} | Expected: {expectedReportProgressCount}\n" +
                    $"Current Commit Block Invocations: {currentCompleteDownloadCount} | Expected: {expectedCompleteFileCount}";
                Assert.Fail(message);
            }
        }

        public CommitChunkHandlerTests() { }

        private Mock<CommitChunkHandler.QueuePutBlockTaskInternal> GetPutBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueuePutBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsAny<StorageResourceItemProperties>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<CommitChunkHandler.QueuePutBlockTaskInternal> GetExceptionPutBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueuePutBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<StorageResourceItemProperties>()))
                .Throws(new RequestFailedException("Mock Request Error"));
            return mock;
        }

        private Mock<CommitChunkHandler.QueueCommitBlockTaskInternal> GetCommitBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueueCommitBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<StorageResourceItemProperties>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<CommitChunkHandler.QueueCommitBlockTaskInternal> GetExceptionCommitBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueueCommitBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<StorageResourceItemProperties>()))
                .Throws(new RequestFailedException("Mock Request Error"));
            return mock;
        }

        private Mock<CommitChunkHandler.ReportProgressInBytes> GetReportProgressInBytesTask()
        {
            var mock = new Mock<CommitChunkHandler.ReportProgressInBytes>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>()))
                .Returns(new ValueTask());
            return mock;
        }

        private Mock<CommitChunkHandler.InvokeFailedEventHandlerInternal> GetInvokeFailedEventHandlerTask()
        {
            var mock = new Mock<CommitChunkHandler.InvokeFailedEventHandlerInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<Exception>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        internal struct MockCommitChunkBehaviors
        {
            public Mock<CommitChunkHandler.QueuePutBlockTaskInternal> PutBlockTask;
            public Mock<CommitChunkHandler.ReportProgressInBytes> ReportProgressInBytesTask;
            public Mock<CommitChunkHandler.QueueCommitBlockTaskInternal> QueueCommitBlockTask;
            public Mock<CommitChunkHandler.InvokeFailedEventHandlerInternal> InvokeFailedEventHandlerTask;
        }

        private MockCommitChunkBehaviors GetCommitChunkBehaviors()
            => new MockCommitChunkBehaviors()
            {
                PutBlockTask = GetPutBlockTask(),
                ReportProgressInBytesTask = GetReportProgressInBytesTask(),
                QueueCommitBlockTask = GetCommitBlockTask(),
                InvokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask()
            };

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        [TestCase(Constants.MB)]
        [TestCase(4 * Constants.MB)]
        public async Task OneChunkTransfer(long blockSize)
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            long expectedLength = blockSize * 2;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Unordered,
                default,
                CancellationToken.None);

            // Make one chunk that would meet the expected length
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize));

            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task ParallelChunkTransfer(long blockSize)
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            long expectedLength = blockSize * 3;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Unordered,
                default,
                CancellationToken.None);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Now add the last block to meet the required commited block amount.
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize * 2,
                bytesTransferred: blockSize));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task ParallelChunkTransfer_ExceedError(long blockSize)
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            long expectedLength = blockSize * 2;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Unordered,
                default,
                CancellationToken.None);

            // Make one chunk that would update the bytes that would cause the bytes to exceed the expected amount
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize * 2));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512, 4)]
        [TestCase(512, 20)]
        [TestCase(Constants.KB, 4)]
        [TestCase(Constants.KB, 20)]
        public async Task ParallelChunkTransfer_MultipleProcesses(long blockSize, int taskSize)
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            long expectedLength = blockSize * (taskSize + 1);

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Unordered,
                default,
                CancellationToken.None);

            List<Task> runningTasks = new List<Task>();

            for (int i = 0; i < taskSize; i++)
            {
                Task task = Task.Run(async () => await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                    // Before commit block is called, one block chunk has already been added when creating the destination
                    offset: blockSize,
                    bytesTransferred: blockSize)));
                runningTasks.Add(task);
            }

            // Wait for all the remaining blocks to finish staging and then
            // commit the block list to complete the upload
            await Task.WhenAll(runningTasks).ConfigureAwait(false);

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: taskSize,
                expectedCompleteFileCount: 1);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task SequentialChunkTransfer(long blockSize)
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            long expectedLength = blockSize * 3;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Sequential,
                default,
                CancellationToken.None);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Now add the last block to meet the required commited block amount.
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize * 2,
                bytesTransferred: blockSize));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 1,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task SequentialChunkTransfer_ExceedError(long blockSize)
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            long expectedLength = blockSize * 2;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Sequential,
                default,
                CancellationToken.None);

            // Make one chunk that would update the bytes that would cause the bytes to exceed the expected amount
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize * 2));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        public async Task GetPutBlockTask_ExpectedFailure()
        {
            // Arrange
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            mockCommitChunkBehaviors.PutBlockTask = GetExceptionPutBlockTask();

            int blockSize = 512;
            long expectedLength = blockSize * 3;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                behaviors: new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                transferOrder: TransferOrder.Sequential,
                default,
                CancellationToken.None);

            // Act
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                offset: blockSize,
                bytesTransferred: blockSize));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        public async Task GetCommitBlockTask_ExpectedFailure()
        {
            // Arrange
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            mockCommitChunkBehaviors.QueueCommitBlockTask = GetExceptionCommitBlockTask();
            int blockSize = 512;
            long expectedLength = blockSize * 2;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                behaviors: new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                transferOrder: TransferOrder.Unordered,
                default,
                CancellationToken.None);

            // Act
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                offset: 0,
                bytesTransferred: blockSize));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }

        [Test]
        public async Task CleanUpAsync()
        {
            // Arrange - Create CommitChunkHandler then Dispose it so the event handler is disposed
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            int blockSize = 512;
            long expectedLength = blockSize * 2;

            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                behaviors: new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                transferOrder: TransferOrder.Unordered,
                default,
                CancellationToken.None);

            // Act
            await commitBlockHandler.CleanUpAsync();

            Assert.ThrowsAsync<ChannelClosedException>(async () =>
                await commitBlockHandler.QueueChunkAsync(default));

            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);
        }

        [Test]
        public async Task CompleteTransferTask_Properties()
        {
            // Set up tasks
            MockCommitChunkBehaviors mockCommitChunkBehaviors = GetCommitChunkBehaviors();
            int blockSize = 512;
            long expectedLength = blockSize * 2;

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
            StorageResourceItemProperties properties = new()
            {
                ResourceLength = expectedLength,
                ETag = new ETag("etag"),
                LastModifiedTime = DateTimeOffset.UtcNow.AddHours(-1),
                RawProperties = sourceProperties
            };
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = mockCommitChunkBehaviors.PutBlockTask.Object,
                    QueueCommitBlockTask = mockCommitChunkBehaviors.QueueCommitBlockTask.Object,
                    ReportProgressInBytes = mockCommitChunkBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockCommitChunkBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                TransferOrder.Unordered,
                properties,
                CancellationToken.None);

            // Make one chunk that would meet the expected length
            await commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize));

            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);

            mockCommitChunkBehaviors.QueueCommitBlockTask.Verify(b => b(properties));

            // Cleanup
            await commitBlockHandler.CleanUpAsync();
        }
    }
}
