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

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class CommitBlockHandlerTests
    {
        public CommitBlockHandlerTests() { }

        private Mock<CommitChunkHandler.QueuePutBlockTaskInternal> GetPutBlockTask(long offset, long blockSize, long expectedLength)
        {
            var mock = new Mock<CommitChunkHandler.QueuePutBlockTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(offset, blockSize, expectedLength))
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

        private Mock<CommitChunkHandler.ReportProgressInBytes> GetReportProgressInBytesTask(long bytesWritten)
        {
            var mock = new Mock<CommitChunkHandler.ReportProgressInBytes>(MockBehavior.Strict);
            mock.Setup(del => del(bytesWritten));
            return mock;
        }

        private Mock<CommitChunkHandler.InvokeFailedEventHandlerInternal> GetInvokeFailedEventHandlerTask(Exception ex)
        {
            var mock = new Mock<CommitChunkHandler.InvokeFailedEventHandlerInternal>(MockBehavior.Strict);
            mock.Setup(del => del(ex))
                .Returns(Task.CompletedTask);
            return mock;
        }

        [Test]
        [TestCase(0, 512, Constants.KB)]
        [TestCase(0, Constants.KB, Constants.KB*2)]
        [TestCase(64, 512, Constants.KB - 64)]
        public async Task OneChunkTransfer(long bytesWritten, long blockSize, long expectedLength)
        {
            FileNotFoundException exception = new FileNotFoundException();
            // Set up tasks
            var putBlockTask = GetPutBlockTask(0, 0, expectedLength);
            var commitBlockTask = GetCommitBlockTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask(blockSize);
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask(exception);
            var commitBlockHandler = new CommitChunkHandler(
                expectedLength: expectedLength,
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
                offset: 0,
                bytesTransferred: Constants.KB,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            Assert.AreEqual(0, putBlockTask.Invocations.Count);
            Assert.AreEqual(1, commitBlockTask.Invocations.Count);
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count);
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count);
        }
    }
}
