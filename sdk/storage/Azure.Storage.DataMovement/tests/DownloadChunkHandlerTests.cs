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

        private readonly int _maxDelayInSec = 1;
        private readonly string _failedEventMsg = "Amount of Failed Event Handler calls was incorrect.";
        private readonly string _copyToDestinationMsg = "Amount of Copy To Destination Task calls were incorrect.";
        private readonly string _copyToChunkFileMsg = "Amount of Copy To Chunk File Task calls were incorrect.";
        private readonly string _reportProgressInBytesMsg = "Amount of Progress amount calls were incorrect.";
        private readonly string _completeFileDownloadMsg = "Complete File Download call amount calls were incorrect.";

        private void VerifyDelegateInvocations(
            MockDownloadChunkBehaviors behaviors,
            int expectedFailureCount,
            int expectedCopyDestinationCount,
            int expectedCopyChunkCount,
            int expectedReportProgressCount,
            int expectedCompleteFileCount,
            int maxWaitTimeInSec = 6)
        {
            CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(maxWaitTimeInSec));
            CancellationToken cancellationToken = cancellationSource.Token;
            int currentFailedEventCount = behaviors.InvokeFailedEventHandlerTask.Invocations.Count;
            int currentCopyDestinationCount = behaviors.CopyToDestinationFileTask.Invocations.Count;
            int currentCopyChunkCount = behaviors.CopyToChunkFileTask.Invocations.Count;
            int currentProgressReportedCount = behaviors.ReportProgressInBytesTask.Invocations.Count;
            int currentCompleteDownloadCount = behaviors.QueueCompleteFileDownloadTask.Invocations.Count;
            try
            {
                while (currentFailedEventCount != expectedFailureCount
                       || currentCopyDestinationCount != expectedCopyDestinationCount
                       || currentCopyChunkCount != expectedCopyChunkCount
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
                    currentCopyDestinationCount = behaviors.CopyToDestinationFileTask.Invocations.Count;
                    Assert.LessOrEqual(currentCopyDestinationCount, expectedCopyDestinationCount, _copyToDestinationMsg);
                    currentCopyChunkCount = behaviors.CopyToChunkFileTask.Invocations.Count;
                    Assert.LessOrEqual(currentCopyChunkCount, expectedCopyChunkCount, _copyToChunkFileMsg);
                    currentProgressReportedCount = behaviors.ReportProgressInBytesTask.Invocations.Count;
                    Assert.LessOrEqual(currentProgressReportedCount, expectedReportProgressCount, _reportProgressInBytesMsg);
                    currentCompleteDownloadCount = behaviors.QueueCompleteFileDownloadTask.Invocations.Count;
                    Assert.LessOrEqual(currentCompleteDownloadCount, expectedCompleteFileCount, _completeFileDownloadMsg);
                }
            }
            catch (TaskCanceledException)
            {
                string message = "Timed out waiting for the correct amount of invocations for each task\n" +
                    $"Current Failed Event Invocations: {currentFailedEventCount} | Expected: {expectedFailureCount}\n" +
                    $"Current Copy Destination Invocations: {currentCopyDestinationCount} | Expected: {expectedCopyDestinationCount}\n" +
                    $"Current Copy Chunk Invocations: {currentCopyChunkCount} | Expected: {expectedCopyChunkCount}\n" +
                    $"Current Progress Reported Invocations: {currentProgressReportedCount} | Expected: {expectedReportProgressCount}\n" +
                    $"Current Complete Download Invocations: {currentCompleteDownloadCount} | Expected: {expectedCompleteFileCount}";
                Assert.Fail(message);
            }
        }

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

        internal struct MockDownloadChunkBehaviors
        {
            public Mock<DownloadChunkHandler.CopyToDestinationFileInternal> CopyToDestinationFileTask;
            public Mock<DownloadChunkHandler.CopyToChunkFileInternal> CopyToChunkFileTask;
            public Mock<DownloadChunkHandler.ReportProgressInBytes> ReportProgressInBytesTask;
            public Mock<DownloadChunkHandler.QueueCompleteFileDownloadInternal> QueueCompleteFileDownloadTask;
            public Mock<DownloadChunkHandler.InvokeFailedEventHandlerInternal> InvokeFailedEventHandlerTask;
        }

        private MockDownloadChunkBehaviors GetMockDownloadChunkBehaviors()
            => new MockDownloadChunkBehaviors()
            {
                CopyToDestinationFileTask = GetCopyToDestinationFileTask(),
                CopyToChunkFileTask = GetCopyToChunkFileTask(),
                ReportProgressInBytesTask = GetReportProgressInBytesTask(),
                QueueCompleteFileDownloadTask = GetQueueCompleteFileDownloadTask(),
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
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();

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
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
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

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 1,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer(long blockSize)
        {
            // Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
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
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
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

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 1,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

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

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 2,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer_UnexpectedOffsetError(long blockSize)
        {
            // Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
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
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
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

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 1,
                expectedCopyDestinationCount: 1,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer_EarlyChunks(long blockSize)
        {
            // Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
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
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
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

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 0,
                expectedCopyChunkCount: 1,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);

            // Make the repeat at the same offset to cause an error.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 2,
                expectedCopyChunkCount: 1,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);
        }

        [Test]
        [TestCase(512, 4)]
        [TestCase(512, 20)]
        [TestCase(Constants.KB, 4)]
        [TestCase(Constants.KB, 20)]
        public async Task MultipleChunkTransfer_MultipleProcesses(long blockSize, int taskSize)
        {
            // Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
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
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
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

            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: taskSize,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: taskSize,
                expectedCompleteFileCount: 1);
        }
    }
}
