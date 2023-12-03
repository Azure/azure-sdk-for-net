﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.Threading;
using Azure.Core;
using Azure.Storage.Tests.Shared;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class CommitChunkHandlerTests
    {
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
            CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(maxWaitTimeInSec));
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
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<long>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<CommitChunkHandler.QueuePutBlockTaskInternal> GetExceptionPutBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueuePutBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<long>()))
                .Throws(new RequestFailedException("Mock Request Error"));
            return mock;
        }

        private Mock<CommitChunkHandler.QueueCommitBlockTaskInternal> GetCommitBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueueCommitBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del())
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<CommitChunkHandler.QueueCommitBlockTaskInternal> GetExceptionCommitBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueueCommitBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del())
                .Throws(new RequestFailedException("Mock Request Error"));
            return mock;
        }

        private Mock<CommitChunkHandler.ReportProgressInBytes> GetReportProgressInBytesTask()
        {
            var mock = new Mock<CommitChunkHandler.ReportProgressInBytes>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>()));
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
                DataTransferOrder.Unordered,
                ClientDiagnostics,
                CancellationToken.None);

            // Make one chunk that would meet the expected length
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);
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
                DataTransferOrder.Unordered,
                ClientDiagnostics,
                CancellationToken.None);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Now add the last block to meet the required commited block amount.
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize * 2,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);
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
                DataTransferOrder.Unordered,
                ClientDiagnostics,
                CancellationToken.None);

            // Make one chunk that would update the bytes that would cause the bytes to exceed the expected amount
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize * 2,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);
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
                DataTransferOrder.Unordered,
                ClientDiagnostics,
                CancellationToken.None);

            List<Task> runningTasks = new List<Task>();

            for (int i = 0; i < taskSize; i++)
            {
                Task task = commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                    transferId: "fake-id",
                    success: true,
                    // Before commit block is called, one block chunk has already been added when creating the destination
                    offset: blockSize,
                    bytesTransferred: blockSize,
                    exception: default,
                    isRunningSynchronously: false,
                    cancellationToken: CancellationToken.None));
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
                DataTransferOrder.Sequential,
                ClientDiagnostics,
                CancellationToken.None);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Now add the last block to meet the required commited block amount.
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize * 2,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 1,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);
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
                DataTransferOrder.Sequential,
                ClientDiagnostics,
                CancellationToken.None);

            // Make one chunk that would update the bytes that would cause the bytes to exceed the expected amount
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize * 2,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);
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
                transferOrder: DataTransferOrder.Sequential,
                ClientDiagnostics,
                CancellationToken.None);

            // Act
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                offset: blockSize,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);
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
                transferOrder: DataTransferOrder.Unordered,
                ClientDiagnostics,
                CancellationToken.None);

            // Act
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 1,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);
        }

        [Test]
        public async Task DisposedEventHandler()
        {
            // Arrange - Create DownloadChunkHandler then Dispose it so the event handler is disposed
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
                transferOrder: DataTransferOrder.Unordered,
                ClientDiagnostics,
                CancellationToken.None);

            // Act
            commitBlockHandler.Dispose();

            // Assert - Do not throw when trying to invoke the event handler when disposed
            await commitBlockHandler.InvokeEvent(default);

            VerifyDelegateInvocations(
                behaviors: mockCommitChunkBehaviors,
                expectedFailureCount: 0,
                expectedPutBlockCount: 0,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);
        }
    }
}
