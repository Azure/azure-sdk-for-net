// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Args = Azure.Storage.DataMovement.TransferProgressTracker.ProgressEventArgs;

namespace Azure.Storage.DataMovement.Tests
{
    public class TransferProgressTrackerTests
    {
        private static Args _queuedArgs = new()
        {
            QueuedChange = 1,
        };
        private static Args _inProgressArgs = new()
        {
            QueuedChange = -1,
            InProgressChange = 1,
        };
        private static Args _CompletedArgs = new()
        {
            InProgressChange = -1,
            CompletedChange = 1,
        };
        private static Args _FailedArgs = new()
        {
            InProgressChange = -1,
            FailedChange = 1,
        };
        private static Args _SkippedArgs = new()
        {
            InProgressChange = -1,
            SkippedChange = 1,
        };

        private static bool ArgsEqual(Args x, Args y)
        {
            return x.CompletedChange == y.CompletedChange &&
                   x.SkippedChange == y.SkippedChange &&
                   x.FailedChange == y.FailedChange &&
                   x.InProgressChange == y.InProgressChange &&
                   x.QueuedChange == y.QueuedChange &&
                   x.BytesChange == y.BytesChange;
        }

        private class PassthroughProcessor : IProcessor<Args>
        {
            public ProcessAsync<Args> Process { get; set; }

            public async ValueTask QueueAsync(Args item, CancellationToken cancellationToken)
            {
                // Just call the process method immediately so it can be tested
                await Process(item);
            }

            public Task CleanUpAsync() => Task.CompletedTask;
        }

        private static void AssertProgressUpdates(List<TransferProgress> expected,  List<TransferProgress> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].QueuedCount, Is.EqualTo(expected[i].QueuedCount));
                Assert.That(actual[i].InProgressCount, Is.EqualTo(expected[i].InProgressCount));
                Assert.That(actual[i].CompletedCount, Is.EqualTo(expected[i].CompletedCount));
                Assert.That(actual[i].FailedCount, Is.EqualTo(expected[i].FailedCount));
                Assert.That(actual[i].SkippedCount, Is.EqualTo(expected[i].SkippedCount));
                Assert.That(actual[i].BytesTransferred, Is.EqualTo(expected[i].BytesTransferred));
            }
        }

        private static async Task RunSampleUpdates(TransferProgressTracker progressTracker)
        {
            CancellationToken ctx = CancellationToken.None;
            await progressTracker.IncrementQueuedFilesAsync(ctx);
            await progressTracker.IncrementQueuedFilesAsync(ctx);
            await progressTracker.IncrementInProgressFilesAsync(ctx);
            await progressTracker.IncrementQueuedFilesAsync(ctx);
            await progressTracker.IncrementQueuedFilesAsync(ctx);
            await progressTracker.IncrementQueuedFilesAsync(ctx);
            await progressTracker.IncrementInProgressFilesAsync(ctx);
            await progressTracker.IncrementInProgressFilesAsync(ctx);
            await progressTracker.IncrementInProgressFilesAsync(ctx);
            await progressTracker.IncrementInProgressFilesAsync(ctx);
            await progressTracker.IncrementSkippedFilesAsync(ctx);
            await progressTracker.IncrementBytesTransferredAsync(10, ctx);
            await progressTracker.IncrementCompletedFilesAsync(ctx);
            await progressTracker.IncrementBytesTransferredAsync(10, ctx);
            await progressTracker.IncrementBytesTransferredAsync(25, ctx);
            await progressTracker.IncrementCompletedFilesAsync(ctx);
            await progressTracker.IncrementCompletedFilesAsync(ctx);
            await progressTracker.IncrementFailedFilesAsync(ctx);
        }

        [Test]
        public async Task ProgressFlow_VerifyMocks()
        {
            Mock<IProcessor<Args>> progressProcessor = new();

            TransferProgressTracker progressTracker = new(progressProcessor.Object, default);
            progressProcessor.VerifySet(p => p.Process = It.IsNotNull<ProcessAsync<Args>>(), Times.Once());

            await RunSampleUpdates(progressTracker);

            // BytesTransferred events are not queued if not enabled in options
            progressProcessor.Verify(p => p.QueueAsync(It.Is<Args>(a => ArgsEqual(a, _queuedArgs)), It.IsAny<CancellationToken>()), Times.Exactly(5));
            progressProcessor.Verify(p => p.QueueAsync(It.Is<Args>(a => ArgsEqual(a, _inProgressArgs)), It.IsAny<CancellationToken>()), Times.Exactly(5));
            progressProcessor.Verify(p => p.QueueAsync(It.Is<Args>(a => ArgsEqual(a, _CompletedArgs)), It.IsAny<CancellationToken>()), Times.Exactly(3));
            progressProcessor.Verify(p => p.QueueAsync(It.Is<Args>(a => ArgsEqual(a, _FailedArgs)), It.IsAny<CancellationToken>()), Times.Exactly(1));
            progressProcessor.Verify(p => p.QueueAsync(It.Is<Args>(a => ArgsEqual(a, _SkippedArgs)), It.IsAny<CancellationToken>()), Times.Exactly(1));

            progressProcessor.VerifyNoOtherCalls();
        }

        [Test]
        public async Task ProgressFlow_NoOptions()
        {
            IProcessor<Args> progressProcessor = new PassthroughProcessor();
            TransferProgressTracker progressTracker = new(progressProcessor, default);
            await RunSampleUpdates(progressTracker);
            // Nothing to assert since there is no IProgress but just make sure it doesn't throw an exception
        }

        [Test]
        public async Task ProgressFlow_NoBytes_VerifyIProgress()
        {
            IProcessor<Args> progressProcessor = new PassthroughProcessor();
            TestProgressHandler progressHandler = new();

            TransferProgressTracker progressTracker = new(progressProcessor, new TransferProgressHandlerOptions()
            {
                ProgressHandler = progressHandler,
                TrackBytesTransferred = false
            });
            await RunSampleUpdates(progressTracker);

            List<TransferProgress> expectedProgressUpdates = [
                new() { QueuedCount = 1, InProgressCount = 0, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 2, InProgressCount = 0, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 1, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 2, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 3, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 4, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 3, InProgressCount = 2, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 2, InProgressCount = 3, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 1, InProgressCount = 4, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 0, InProgressCount = 5, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = null },
                new() { QueuedCount = 0, InProgressCount = 4, CompletedCount = 0, FailedCount = 0, SkippedCount = 1, BytesTransferred = null },
                new() { QueuedCount = 0, InProgressCount = 3, CompletedCount = 1, FailedCount = 0, SkippedCount = 1, BytesTransferred = null },
                new() { QueuedCount = 0, InProgressCount = 2, CompletedCount = 2, FailedCount = 0, SkippedCount = 1, BytesTransferred = null },
                new() { QueuedCount = 0, InProgressCount = 1, CompletedCount = 3, FailedCount = 0, SkippedCount = 1, BytesTransferred = null },
                new() { QueuedCount = 0, InProgressCount = 0, CompletedCount = 3, FailedCount = 1, SkippedCount = 1, BytesTransferred = null },
            ];

            AssertProgressUpdates(expectedProgressUpdates, progressHandler.Updates);
        }

        [Test]
        public async Task ProgressFlow_WithBytes_VerifyIProgress()
        {
            IProcessor<Args> progressProcessor = new PassthroughProcessor();
            TestProgressHandler progressHandler = new();

            TransferProgressTracker progressTracker = new(progressProcessor, new TransferProgressHandlerOptions()
            {
                ProgressHandler = progressHandler,
                TrackBytesTransferred = true
            });
            await RunSampleUpdates(progressTracker);

            List<TransferProgress> expectedProgressUpdates = [
                new() { QueuedCount = 1, InProgressCount = 0, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 2, InProgressCount = 0, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 1, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 2, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 3, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 4, InProgressCount = 1, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 3, InProgressCount = 2, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 2, InProgressCount = 3, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 1, InProgressCount = 4, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 0, InProgressCount = 5, CompletedCount = 0, FailedCount = 0, SkippedCount = 0, BytesTransferred = 0 },
                new() { QueuedCount = 0, InProgressCount = 4, CompletedCount = 0, FailedCount = 0, SkippedCount = 1, BytesTransferred = 0 },
                new() { QueuedCount = 0, InProgressCount = 4, CompletedCount = 0, FailedCount = 0, SkippedCount = 1, BytesTransferred = 10 },
                new() { QueuedCount = 0, InProgressCount = 3, CompletedCount = 1, FailedCount = 0, SkippedCount = 1, BytesTransferred = 10 },
                new() { QueuedCount = 0, InProgressCount = 3, CompletedCount = 1, FailedCount = 0, SkippedCount = 1, BytesTransferred = 20 },
                new() { QueuedCount = 0, InProgressCount = 3, CompletedCount = 1, FailedCount = 0, SkippedCount = 1, BytesTransferred = 45 },
                new() { QueuedCount = 0, InProgressCount = 2, CompletedCount = 2, FailedCount = 0, SkippedCount = 1, BytesTransferred = 45 },
                new() { QueuedCount = 0, InProgressCount = 1, CompletedCount = 3, FailedCount = 0, SkippedCount = 1, BytesTransferred = 45 },
                new() { QueuedCount = 0, InProgressCount = 0, CompletedCount = 3, FailedCount = 1, SkippedCount = 1, BytesTransferred = 45 },
            ];

            AssertProgressUpdates(expectedProgressUpdates, progressHandler.Updates);
        }
    }
}
