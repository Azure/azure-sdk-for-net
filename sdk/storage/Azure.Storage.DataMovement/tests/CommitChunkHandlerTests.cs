// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Azure.Storage.DataMovement;
using Azure.Core.Pipeline;
using System.Diagnostics;
using Azure.Storage.Test;
using System.IO;
using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class CommitChunkHandlerTests
    {
        public CommitChunkHandlerTests() { }

        private Mock<CommitChunkHandler.QueuePutBlockTaskInternal> GetPutBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueuePutBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<long>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<CommitChunkHandler.QueueCommitBlockTaskInternal> GetCommitBlockTask()
        {
            var mock = new Mock<CommitChunkHandler.QueueCommitBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del())
                .Returns(Task.CompletedTask);
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

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        [TestCase(Constants.MB)]
        [TestCase(4 * Constants.MB)]
        public async Task OneChunkTransfer(long blockSize)
        {
            // Set up tasks
            var putBlockTask = GetPutBlockTask();
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: blockSize * 2,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = putBlockTask.Object,
                    QueueCommitBlockTask = commitBlockTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                },
                TransferType.Concurrent);

            // Make one chunk that would meet the expected length
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Report Event Handler calls were incorrect");
            Assert.AreEqual(0, putBlockTask.Invocations.Count, "Amount of Put Block Task calls were incorrect");
            Assert.AreEqual(1, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
        }
        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task ParallelChunkTransfer(long blockSize)
        {
            // Set up tasks
            var putBlockTask = GetPutBlockTask();
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: blockSize * 3,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = putBlockTask.Object,
                    QueueCommitBlockTask = commitBlockTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                },
                TransferType.Concurrent);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(5); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(0, putBlockTask.Invocations.Count, "Amount of Put Block Task calls were incorrect");
            Assert.AreEqual(0, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");

            // Now add the last block to meet the required commited block amount.
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize * 2,
                bytesTransferred: blockSize,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(0, putBlockTask.Invocations.Count, "Amount of Put Block Task calls were incorrect");
            Assert.AreEqual(1, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(2, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task ParallelChunkTransfer_ExceedError(long blockSize)
        {
            // Set up tasks
            var putBlockTask = GetPutBlockTask();
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: blockSize * 2,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = putBlockTask.Object,
                    QueueCommitBlockTask = commitBlockTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                },
                TransferType.Concurrent);

            // Make one chunk that would update the bytes that would cause the bytes to exceed the expected amount
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize * 2,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(1, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(0, putBlockTask.Invocations.Count, "Amount of  Block Task calls were incorrect");
            Assert.AreEqual(0, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of  Progress amount calls were incorrect");
        }

        [Test]
        [TestCase(512, 4)]
        [TestCase(512, 20)]
        [TestCase(Constants.KB, 4)]
        [TestCase(Constants.KB, 20)]
        public async Task ParallelChunkTransfer_MultipleProcesses(long blockSize, long taskSize)
        {
            // Set up tasks
            var putBlockTask = GetPutBlockTask();
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: blockSize * (taskSize+1),
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = putBlockTask.Object,
                    QueueCommitBlockTask = commitBlockTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                },
                TransferType.Concurrent);

            List<Task> runningTasks = new List<Task>();

            for (int i = 0; i < taskSize; i++)
            {
                Task task = commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                    transferId: "fake-id",
                    success: true,
                    // Before commit block is called, one block chunk has already been added when creating the destination
                    offset: blockSize,
                    bytesTransferred: blockSize,
                    isRunningSynchronously: false,
                    cancellationToken: CancellationToken.None));
                runningTasks.Add(task);
            }

            // Wait for all the remaining blocks to finish staging and then
            // commit the block list to complete the upload
            await Task.WhenAll(runningTasks).ConfigureAwait(false);

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(5); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(0, putBlockTask.Invocations.Count, "Amount of Put Block Task calls were incorrect");
            Assert.AreEqual(1, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(taskSize, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task SequentialChunkTransfer(long blockSize)
        {
            // Set up tasks
            var putBlockTask = GetPutBlockTask();
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: blockSize * 3,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = putBlockTask.Object,
                    QueueCommitBlockTask = commitBlockTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                },
                TransferType.Sequential);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(1, putBlockTask.Invocations.Count, "Amount of Put Block Task calls were incorrect");
            Assert.AreEqual(0, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");

            // Now add the last block to meet the required commited block amount.
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize * 2,
                bytesTransferred: blockSize,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(5); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(1, putBlockTask.Invocations.Count, "Amount of Put Block Task calls were incorrect");
            Assert.AreEqual(1, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(2, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task SequentialChunkTransfer_ExceedError(long blockSize)
        {
            // Set up tasks
            var putBlockTask = GetPutBlockTask();
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: blockSize * 2,
                blockSize: blockSize,
                new CommitChunkHandler.Behaviors
                {
                    QueuePutBlockTask = putBlockTask.Object,
                    QueueCommitBlockTask = commitBlockTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                },
                TransferType.Sequential);

            // Make one chunk that would update the bytes that would cause the bytes to exceed the expected amount
            await commitBlockHandler.InvokeEvent(new StageChunkEventArgs(
                transferId: "fake-id",
                success: true,
                // Before commit block is called, one block chunk has already been added when creating the destination
                offset: blockSize,
                bytesTransferred: blockSize * 2,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(1, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(0, putBlockTask.Invocations.Count, "Amount of  Block Task calls were incorrect");
            Assert.AreEqual(0, commitBlockTask.Invocations.Count, "Amount of Commit Block Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of  Progress amount calls were incorrect");
        }
    }
}
