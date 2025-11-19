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
using System.Threading.Channels;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class DownloadChunkHandlerTests
    {
        public DownloadChunkHandlerTests() { }

        private readonly int _maxDelayInSec = 1;
        private readonly string _failedEventMsg = "Amount of Failed Event Handler calls was incorrect.";
        private readonly string _copyToDestinationMsg = "Amount of Copy To Destination Task calls were incorrect.";
        private readonly string _reportProgressInBytesMsg = "Amount of Progress amount calls were incorrect.";
        private readonly string _completeFileDownloadMsg = "Complete File Download call amount calls were incorrect.";

        private void VerifyDelegateInvocations(
            MockDownloadChunkBehaviors behaviors,
            int expectedFailureCount,
            int expectedCopyDestinationCount,
            int expectedReportProgressCount,
            int expectedCompleteFileCount,
            int maxWaitTimeInSec = 6)
        {
            using CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(maxWaitTimeInSec));
            CancellationToken cancellationToken = cancellationSource.Token;
            int currentFailedEventCount = behaviors.InvokeFailedEventHandlerTask.Invocations.Count;
            int currentCopyDestinationCount = behaviors.CopyToDestinationFileTask.Invocations.Count;
            int currentProgressReportedCount = behaviors.ReportProgressInBytesTask.Invocations.Count;
            int currentCompleteDownloadCount = behaviors.QueueCompleteFileDownloadTask.Invocations.Count;
            try
            {
                while (currentFailedEventCount != expectedFailureCount
                       || currentCopyDestinationCount != expectedCopyDestinationCount
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
                    $"Current Progress Reported Invocations: {currentProgressReportedCount} | Expected: {expectedReportProgressCount}\n" +
                    $"Current Complete Download Invocations: {currentCompleteDownloadCount} | Expected: {expectedCompleteFileCount}";
                Assert.Fail(message);
            }

            // Assert the first call to copy to the destination always specifies initial and the rest don't
            int count = 0;
            foreach (IInvocation invocation in behaviors.CopyToDestinationFileTask.Invocations)
            {
                if (count == 0)
                {
                    Assert.That((bool)invocation.Arguments[4], Is.True);
                }
                else
                {
                    Assert.That((bool)invocation.Arguments[4], Is.False);
                }
                count++;
            }
        }

        private Mock<DownloadChunkHandler.CopyToDestinationFileInternal> GetCopyToDestinationFileTask()
        {
            var mock = new Mock<DownloadChunkHandler.CopyToDestinationFileInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<Stream>(), It.IsNotNull<long>(), It.IsAny<bool>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        private Mock<DownloadChunkHandler.CopyToDestinationFileInternal> GetExceptionCopyToDestinationFileTask()
        {
            var mock = new Mock<DownloadChunkHandler.CopyToDestinationFileInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>(), It.IsNotNull<long>(), It.IsNotNull<Stream>(), It.IsNotNull<long>(), It.IsAny<bool>()))
                .Throws(new UnauthorizedAccessException());
            return mock;
        }

        private Mock<DownloadChunkHandler.ReportProgressInBytes> GetReportProgressInBytesTask()
        {
            var mock = new Mock<DownloadChunkHandler.ReportProgressInBytes>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsNotNull<long>()))
                .Returns(new ValueTask());
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
            public Mock<DownloadChunkHandler.ReportProgressInBytes> ReportProgressInBytesTask;
            public Mock<DownloadChunkHandler.QueueCompleteFileDownloadInternal> QueueCompleteFileDownloadTask;
            public Mock<DownloadChunkHandler.InvokeFailedEventHandlerInternal> InvokeFailedEventHandlerTask;
        }

        private MockDownloadChunkBehaviors GetMockDownloadChunkBehaviors()
            => new MockDownloadChunkBehaviors()
            {
                CopyToDestinationFileTask = GetCopyToDestinationFileTask(),
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
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize,
                new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act - Make one chunk that would meet the expected length
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: 0,
                length: blockSize,
                content: content));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);

            // Cleanup
            await downloadChunkHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer(long blockSize)
        {
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            long expectedLength = blockSize * 2;
            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act - First chunk
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: 0,
                length: blockSize,
                content: content));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            PredictableStream content2 = new PredictableStream(blockSize);

            // Act - Second/final chunk
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: blockSize,
                length: blockSize,
                content: content2));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 2,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);

            // Cleanup
            await downloadChunkHandler.CleanUpAsync();
        }

        [Test]
        [TestCase(512)]
        [TestCase(Constants.KB)]
        public async Task MultipleChunkTransfer_EarlyChunks(long blockSize)
        {
            // Arrange - Set up tasks
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            long expectedLength = blockSize * 2;

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act - The second chunk returns first
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: blockSize,
                length: blockSize,
                content: content));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 0);

            // Act - The first chunk is then returned
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: 0,
                length: blockSize,
                content: content));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 2,
                expectedReportProgressCount: 2,
                expectedCompleteFileCount: 1);

            // Cleanup
            await downloadChunkHandler.CleanUpAsync();
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

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                cancellationToken: CancellationToken.None);

            List<Task> runningTasks = new List<Task>();

            // Act
            for (int i = 0; i < taskSize; i++)
            {
                PredictableStream content = new PredictableStream(blockSize);

                long offset = i * blockSize;
                Task task = Task.Run(async () => await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                    offset: offset,
                    length: blockSize,
                    content: content)));
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
                expectedReportProgressCount: taskSize,
                expectedCompleteFileCount: 1);

            // Cleanup
            await downloadChunkHandler.CleanUpAsync();
        }

        [Test]
        public async Task GetCopyToDestinationFileTask_ExpectedFailure()
        {
            // Arrange
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            mockBehaviors.CopyToDestinationFileTask = GetExceptionCopyToDestinationFileTask();
            int blockSize = 512;
            long expectedLength = blockSize * 2;

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: expectedLength,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: 0,
                length: blockSize,
                content: content));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 1,
                expectedCopyDestinationCount: 1,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);

            // Cleanup
            await downloadChunkHandler.CleanUpAsync();
        }

        [Test]
        public async Task QueueCompleteFileDownloadTask_ExpectedFailure()
        {
            // Arrange
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            mockBehaviors.QueueCompleteFileDownloadTask = GetExceptionQueueCompleteFileDownloadTask();
            int blockSize = 512;

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                cancellationToken: CancellationToken.None);

            PredictableStream content = new PredictableStream(blockSize);

            // Act
            await downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                offset: 0,
                length: blockSize,
                content: content));

            // Assert
            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 1,
                expectedCopyDestinationCount: 1,
                expectedReportProgressCount: 1,
                expectedCompleteFileCount: 1);

            // Cleanup
            await downloadChunkHandler.CleanUpAsync();
        }

        [Test]
        public async Task CleanUpAsync()
        {
            // Arrange - Create DownloadChunkHandler then Dispose it so the event handler is disposed
            MockDownloadChunkBehaviors mockBehaviors = GetMockDownloadChunkBehaviors();
            int blockSize = 512;
            long expectedLength = blockSize * 2;

            var downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: 0,
                expectedLength: blockSize,
                behaviors: new DownloadChunkHandler.Behaviors
                {
                    CopyToDestinationFile = mockBehaviors.CopyToDestinationFileTask.Object,
                    QueueCompleteFileDownload = mockBehaviors.QueueCompleteFileDownloadTask.Object,
                    ReportProgressInBytes = mockBehaviors.ReportProgressInBytesTask.Object,
                    InvokeFailedHandler = mockBehaviors.InvokeFailedEventHandlerTask.Object,
                },
                cancellationToken: CancellationToken.None);

            // Act
            await downloadChunkHandler.CleanUpAsync();

            Assert.ThrowsAsync<ChannelClosedException>(async () =>
                await downloadChunkHandler.QueueChunkAsync(default));

            VerifyDelegateInvocations(
                behaviors: mockBehaviors,
                expectedFailureCount: 0,
                expectedCopyDestinationCount: 0,
                expectedReportProgressCount: 0,
                expectedCompleteFileCount: 0);
        }
    }
}
