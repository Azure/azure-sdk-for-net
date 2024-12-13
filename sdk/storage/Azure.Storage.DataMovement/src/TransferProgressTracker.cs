// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Internal class for tracking progress of transfers and reporting back to
    /// user's progress handler.
    /// </summary>
    internal class TransferProgressTracker : IAsyncDisposable
    {
        private class ProgressEventArgs
        {
            public int CompletedChange { get; set; } = 0;
            public int SkippedChange { get; set; } = 0;
            public int FailedChange { get; set; } = 0;
            public int InProgressChange { get; set; } = 0;
            public int QueuedChange { get; set; } = 0;
            public long BytesChange { get; set; } = 0;
        }

        private readonly ProgressHandlerOptions _options;

        private IProcessor<ProgressEventArgs> _progressProcessor;
        private long _completedCount = 0;
        private long _skippedCount = 0;
        private long _failedCount = 0;
        private long _inProgressCount = 0;
        private long _queuedCount = 0;
        private long _bytesTransferred = 0;

        public TransferProgressTracker(ProgressHandlerOptions options)
        {
            _options = options;
            _progressProcessor = ChannelProcessing.NewProcessor<ProgressEventArgs>(readers: 1);
            _progressProcessor.Process = ProcessProgressEvent;
        }

        public async ValueTask DisposeAsync()
        {
            // This will close the channel and block on all pending items being processed
            await _progressProcessor.DisposeAsync().ConfigureAwait(false);
        }

        public async ValueTask IncrementCompletedFilesAsync(CancellationToken cancellationToken)
        {
            await QueueProgressEvent(new ProgressEventArgs()
            {
                InProgressChange = -1,
                CompletedChange = 1,
            },
            cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask IncrementSkippedFilesAsync(CancellationToken cancellationToken)
        {
            await QueueProgressEvent(new ProgressEventArgs()
            {
                InProgressChange = -1,
                SkippedChange = 1,
            },
            cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask IncrementFailedFilesAsync(CancellationToken cancellationToken)
        {
            await QueueProgressEvent(new ProgressEventArgs()
            {
                InProgressChange = -1,
                FailedChange = 1,
            },
            cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask IncrementInProgressFilesAsync(CancellationToken cancellationToken)
        {
            await QueueProgressEvent(new ProgressEventArgs()
            {
                QueuedChange = -1,
                InProgressChange = 1,
            },
            cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask IncrementQueuedFilesAsync(CancellationToken cancellationToken)
        {
            await QueueProgressEvent(new ProgressEventArgs()
            {
                QueuedChange = 1,
            },
            cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask IncrementBytesTransferred(long bytesTransferred, CancellationToken cancellationToken)
        {
            if (_options?.TrackBytesTransferred == true)
            {
                await QueueProgressEvent(new ProgressEventArgs()
                {
                    BytesChange = bytesTransferred,
                },
                cancellationToken).ConfigureAwait(false);
            }
        }

        private async ValueTask QueueProgressEvent(ProgressEventArgs args, CancellationToken cancellationToken)
        {
            try
            {
                await _progressProcessor.QueueAsync(args, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is ChannelClosedException || ex is OperationCanceledException)
            {
                // The only time we should get these exceptions is if the job is being
                // disposed, either by pause or failure, in which case its safe to ignore these.
            }
        }

        private Task ProcessProgressEvent(ProgressEventArgs args, CancellationToken cancellationToken = default)
        {
            // Only ever one thread processing at a time so its safe to update these
            // Changes can be negative
            _completedCount += args.CompletedChange;
            _skippedCount += args.SkippedChange;
            _failedCount += args.FailedChange;
            _inProgressCount += args.InProgressChange;
            _queuedCount += args.QueuedChange;
            _bytesTransferred += args.BytesChange;

            DataTransferProgress progress = new()
            {
                CompletedCount = _completedCount,
                SkippedCount = _skippedCount,
                FailedCount = _failedCount,
                InProgressCount = _inProgressCount,
                QueuedCount = _queuedCount,
                BytesTransferred = _options.TrackBytesTransferred ? _bytesTransferred : null
            };
            _options?.ProgressHandler?.Report(progress);

            return Task.CompletedTask;
        }
    }
}
