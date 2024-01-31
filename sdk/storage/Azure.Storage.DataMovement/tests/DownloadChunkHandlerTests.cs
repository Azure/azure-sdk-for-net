// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading;
using Azure.Core;
using Azure.Storage.Tests.Shared;
using Azure.Core.Pipeline;

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

        private ClientDiagnostics ClientDiagnostics => new(ClientOptions.Default);

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

        private Mock<DownloadChunkHandler.CopyToChunkFileInternal> GetExceptionCopyToChunkFileTask()
        {
            var mock = new Mock<DownloadChunkHandler.CopyToChunkFileInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<string>(), It.IsNotNull<Stream>()))
                .Throws(new UnauthorizedAccessException());
            return mock;
        }

        private Mock<DownloadChunkHandler.CopyToDestinationFileInternal> GetExceptionCopyToDestinationFileTask()
        {
            var mock = new Mock<DownloadChunkHandler.CopyToDestinationFileInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<Stream>(), It.IsNotNull<long>()))
                .Throws(new UnauthorizedAccessException());
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

        private Mock<DownloadChunkHandler.QueueCompleteFileDownloadInternal> GetExceptionQueueCompleteFileDownloadTask()
        {
            var mock = new Mock<DownloadChunkHandler.QueueCompleteFileDownloadInternal>(MockBehavior.Strict);
            mock.Setup(del => del())
                .Throws(new UnauthorizedAccessException());
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

        /// <summary>
        /// Creates ranges that the download chunk handler is expecting.
        /// </summary>
        /// <param name="blockSize">
        /// The block size which the size of the range will equal.
        /// This value must be less or equal to the expected length.
        /// </param>
        /// <param name="expectedLength">
        /// Expected full length of the download to create ranges of.
        /// </param>
        /// <returns></returns>
        private List<HttpRange> GetRanges(long blockSize, long expectedLength)
        {
            Argument.AssertNotDefault(ref blockSize, name: nameof(blockSize));
            Argument.AssertNotDefault(ref expectedLength, name: nameof(expectedLength));
            if (expectedLength < blockSize)
            {
                Argument.AssertInRange(blockSize, expectedLength, default, nameof(blockSize));
            }
            List<HttpRange> ranges = new List<HttpRange>();

            for (long offset = 0; offset < expectedLength; offset += blockSize)
            {
                ranges.Add(new HttpRange(offset, Math.Min(expectedLength - offset, blockSize)));
            }

            return ranges;
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        [TestCase(Constants.MB)]
        [TestCase(4 * Constants.MB)]
        public async Task OneChunkTransfer(long blockSize)
        {
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();

            List<HttpRange> ranges = new List<HttpRange>()
            {
                new HttpRange(0, blockSize)
            };
            using var downloadChunkHandler = new DownloadChunkHandler(
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
                },
                ClientDiagnostics,
                CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act - Make one chunk that would meet the expected length
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
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
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            long expectedLength = blockSize * 2;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);
            using var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act - Make one chunk that would update the bytes but not cause a commit block list to occur
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
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

            // Act - Now add the last block to meet the required commited block amount.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: blockSize,
                bytesTransferred: blockSize,
                result: content2,
                exception: default,
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
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            long expectedLength = blockSize * 2;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);

            using var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Make initial range event
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Act - Make the repeat at the same offset to cause an error.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
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
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            long expectedLength = blockSize * 2;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);

            using var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act - Make initial range event
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: blockSize,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
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

            // Act - Make the repeat at the same offset to cause an error.
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
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
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            long expectedLength = blockSize * taskSize;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);
            using var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            List<Task> runningTasks = new List<Task>();

            // Act
            for (int i = 0; i < taskSize; i++)
            {
                PredictableStream content = new PredictableStream(blockSize);

                Task task = downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                    transferId: "fake-id",
                    success: true,
                    offset: i * blockSize,
                    bytesTransferred: blockSize,
                    result: content,
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
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: taskSize,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: taskSize,
                expectedCompleteFileCount: 1);
        }

        [Test]
        public async Task GetCopyToChunkFileTask_ExpectedFailure()
        {
            // Arrange
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            mockBehaviors.CopyToChunkFileTask = GetExceptionCopyToChunkFileTask();
            int blockSize = 512;
            long expectedLength = blockSize * 2;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: blockSize,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 1,
                expectedCopyDestinationCount: 0,
                expectedCopyChunkCount: 1,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);
        }

        [Test]
        public async Task GetCopyToDestinationFileTask_ExpectedFailure()
        {
            // Arrange
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            mockBehaviors.CopyToDestinationFileTask = GetExceptionCopyToDestinationFileTask();
            int blockSize = 512;
            long expectedLength = blockSize * 2;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 1,
                expectedCopyDestinationCount: 1,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);
        }

        [Test]
        public async Task QueueCompleteFileDownloadTask_ExpectedFailure()
        {
            // Arrange
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            mockBehaviors.QueueCompleteFileDownloadTask = GetExceptionQueueCompleteFileDownloadTask();
            int blockSize = 512;
            List<HttpRange> ranges = GetRanges(blockSize, blockSize);

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act
            await downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                transferId: "fake-id",
                success: true,
                offset: 0,
                bytesTransferred: blockSize,
                result: content,
                exception: default,
                isRunningSynchronously: false,
                cancellationToken: CancellationToken.None));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 1,
                expectedCopyDestinationCount: 1,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);
        }

        [Test]
        public async Task DisposedEventHandler()
        {
            // Arrange - Create DownloadChunkHandler then Dispose it so the event handler is disposed
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            int blockSize = 512;
            long expectedLength = blockSize * 2;
            List<HttpRange> ranges = GetRanges(blockSize, expectedLength);

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize,
                ranges: ranges,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    CopyToChunkFile = mockBehaviors.CopyToChunkFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                ClientDiagnostics,
                cancellationToken: CancellationToken.None);

            // Act
            downloadChunkHandler.Dispose();

            // Assert - Do not throw when trying to invoke the event handler when disposed
            await downloadChunkHandler.InvokeEvent(default);

            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 0,
                expectedCopyChunkCount: 0,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);
        }
    }
}
