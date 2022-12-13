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
    public class CommitBlockHandlerTests
    {
        public CommitBlockHandlerTests() { }

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
        public async Task OneChunkTransfer(long blockSize)
        {
            // Set up tasks
            for (int i = 0; i < 100; i++)
            {
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

                // Assert
                Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Report Event Handler calls were incorrect");
                Assert.AreEqual(0, putBlockTask.Invocations.Count, "Put Block Task calls were incorrect");
                Assert.AreEqual(1, commitBlockTask.Invocations.Count, "Commit Block Task calls were incorrect");
                Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Report Progress amount calls were incorrect");
            }
        }
    }
}
