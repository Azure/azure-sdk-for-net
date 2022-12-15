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
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class DownloadChunkHandlerTests
    {
        public DownloadChunkHandlerTests() { }

        private Mock<DownloadChunkHandler.CopyToDestinationFileInternal> GetCopyToDestinationFileTask()
        {
            var mock = new Mock<DownloadChunkHandler.CopyToDestinationFileInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<Stream>(), It.IsNotNull<long>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<DownloadChunkHandler.CopyToChunkFileInternal> GetCopyToChunkFileTask()
        {
            var mock = new Mock<DownloadChunkHandler.CopyToChunkFileInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<string>(),It.IsNotNull<Stream>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<DownloadChunkHandler.ReportProgressInBytes> GetReportProgressInBytesTask()
        {
            var mock = new Mock<DownloadChunkHandler.ReportProgressInBytes>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>()));
            return mock;
        }

        private Mock<DownloadChunkHandler.QueueCompleteFileDownloadInternal> GetQueueCompleteFileDownloadTask()
        {
            var mock = new Mock<DownloadChunkHandler.QueueCompleteFileDownloadInternal>(MockBehavior.Strict);
            mock.Setup(del => del())
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<DownloadChunkHandler.InvokeFailedEventHandlerInternal> GetInvokeFailedEventHandlerTask()
        {
            var mock = new Mock<DownloadChunkHandler.InvokeFailedEventHandlerInternal>(MockBehavior.Strict);
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
            var copyToDestinationTask = GetCopyToDestinationFileTask();
            var copyToChunkFileTask = GetCopyToChunkFileTask();
            var queueCompleteFileDownloadTask = GetQueueCompleteFileDownloadTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();

            List<HttpRange> ranges = new List<HttpRange>()
            {
                new HttpRange(0, blockSize)
            };
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize,
                ranges: ranges,
                new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = copyToDestinationTask.Object,
                    CopyToChunkFile = copyToChunkFileTask.Object,
                    QueueCompleteFileDownload = queueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                });

            PredictableStream content = new PredictableStream(blockSize);

            // Make one chunk that would meet the expected length
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Report Event Handler calls were incorrect");
            Assert.AreEqual(1, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(0, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(1, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer(long blockSize)
        {
            // Set up tasks
            var copyToDestinationTask = GetCopyToDestinationFileTask();
            var copyToChunkFileTask = GetCopyToChunkFileTask();
            var queueCompleteFileDownloadTask = GetQueueCompleteFileDownloadTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            List<HttpRange> ranges = new List<HttpRange>()
            {
                new HttpRange(0, blockSize),
                new HttpRange(blockSize, blockSize),
            };
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize * 2,
                ranges: ranges,
                new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = copyToDestinationTask.Object,
                    CopyToChunkFile = copyToChunkFileTask.Object,
                    QueueCompleteFileDownload = queueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                });

            PredictableStream content = new PredictableStream(blockSize);

            // Make one chunk that would update the bytes but not cause a commit block list to occur
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 5 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(1, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(0, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(0, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");

            PredictableStream content2 = new PredictableStream(blockSize);

            // Now add the last block to meet the required commited block amount.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: blockSize,
                bytesTransferred: blockSize,
                result: content2,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(2, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(0, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(2, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(1, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer_UnexpectedOffsetError(long blockSize)
        {
            // Set up tasks
            var copyToDestinationTask = GetCopyToDestinationFileTask();
            var copyToChunkFileTask = GetCopyToChunkFileTask();
            var queueCompleteFileDownloadTask = GetQueueCompleteFileDownloadTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            List<HttpRange> ranges = new List<HttpRange>()
            {
                new HttpRange(0, blockSize),
                new HttpRange(blockSize, blockSize),
            };
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize * 2,
                ranges: ranges,
                new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = copyToDestinationTask.Object,
                    CopyToChunkFile = copyToChunkFileTask.Object,
                    QueueCompleteFileDownload = queueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                });

            PredictableStream content = new PredictableStream(blockSize);

            // Make initial range event
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Make the repeat at the same offset to cause an error.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(1, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(1, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(0, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(1, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(0, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer_EarlyChunks(long blockSize)
        {
            // Set up tasks
            var copyToDestinationTask = GetCopyToDestinationFileTask();
            var copyToChunkFileTask = GetCopyToChunkFileTask();
            var queueCompleteFileDownloadTask = GetQueueCompleteFileDownloadTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            List<HttpRange> ranges = new List<HttpRange>()
            {
                new HttpRange(0, blockSize),
                new HttpRange(blockSize, blockSize),
            };
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize * 2,
                ranges: ranges,
                new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = copyToDestinationTask.Object,
                    CopyToChunkFile = copyToChunkFileTask.Object,
                    QueueCompleteFileDownload = queueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                });

            PredictableStream content = new PredictableStream(blockSize);

            // Make initial range event
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: blockSize,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(0, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(1, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(0, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(0, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");

            // Make the repeat at the same offset to cause an error.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 5 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(2, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(1, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(2, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(1, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");
        }

        [Test]
        [TestCase(512, 4)]
        [TestCase(512, 20)]
        [TestCase(Constants.KB, 4)]
        [TestCase(Constants.KB, 20)]
        public async Task MultipleChunkTransfer_MultipleProcesses(long blockSize, long taskSize)
        {
            // Set up tasks
            var copyToDestinationTask = GetCopyToDestinationFileTask();
            var copyToChunkFileTask = GetCopyToChunkFileTask();
            var queueCompleteFileDownloadTask = GetQueueCompleteFileDownloadTask();
            var reportProgressInBytesTask = GetReportProgressInBytesTask();
            var invokeFailedEventHandlerTask = GetInvokeFailedEventHandlerTask();
            List<HttpRange> ranges = new List<HttpRange>();
            for (int i = 0; i < taskSize; i++)
            {
                ranges.Add(new HttpRange(i * blockSize, blockSize));
            }
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize * (taskSize),
                ranges: ranges,
                new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = copyToDestinationTask.Object,
                    CopyToChunkFile = copyToChunkFileTask.Object,
                    QueueCompleteFileDownload = queueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = reportProgressInBytesTask.Object,
                    InvokeFailedHandler = invokeFailedEventHandlerTask.Object,
                });

            List<Task> runningTasks = new List<Task>();

            for (int i = 0; i < taskSize; i++)
            {
                PredictableStream content = new PredictableStream(blockSize);

                Task task = downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                    transferId: "fake-id",
                    success: true,
                    offset: i * blockSize,
                    bytesTransferred: blockSize,
                    result: content,
                    isRunningSynchronously: false,
                    cancellationToken: CancellationToken.None));
                runningTasks.Add(task);
            }

            // Wait for all the remaining blocks to finish staging and then
            // commit the block list to complete the upload
            await Task.WhenAll(runningTasks).ConfigureAwait(false);

            // Since the events get added to the channel and return immediately, it's
            // possible the chunks haven't been processed. Let's wait a respectable amount of time.
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 2 seconds

            // Assert
            Assert.AreEqual(0, invokeFailedEventHandlerTask.Invocations.Count, "Amount of Failed Event Handler calls were incorrect");
            Assert.AreEqual(taskSize, copyToDestinationTask.Invocations.Count, "Amount of Copy To Destination Task calls were incorrect");
            Assert.AreEqual(0, copyToChunkFileTask.Invocations.Count, "Amount of Copy To Chunk File Task calls were incorrect");
            Assert.AreEqual(taskSize, reportProgressInBytesTask.Invocations.Count, "Amount of Progress amount calls were incorrect");
            Assert.AreEqual(1, queueCompleteFileDownloadTask.Invocations.Count, "Complete File Download call amount calls were incorrect");
        }
    }
}
