// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Internal class for tracking progress of transfers and reporting back to
    /// user's progress handler.
    /// </summary>
    internal class TransferProgressTracker
    {
        internal class ProgressEventArgs
        {
            public int CompletedChange { get; set; } = 0;
            public int SkippedChange { get; set; } = 0;
            public int FailedChange { get; set; } = 0;
            public int InProgressChange { get; set; } = 0;
            public int QueuedChange { get; set; } = 0;
            public long BytesChange { get; set; } = 0;
        }

        private readonly TransferProgressHandlerOptions _options;

        private IProcessor<ProgressEventArgs> _progressProcessor;
        private long _completedCount = 0;
        private long _skippedCount = 0;
        private long _failedCount = 0;
        private long _inProgressCount = 0;
        private long _queuedCount = 0;
        private long _bytesTransferred = 0;

        public TransferProgressTracker(TransferProgressHandlerOptions options)
        {
            _options = options;
            _progressProcessor = ChannelProcessing.NewProcessor<ProgressEventArgs>(readers: 1);
            _progressProcessor.Process = ProcessProgressEvent;
        }

        internal TransferProgressTracker(IProcessor<ProgressEventArgs> progressProcessor, TransferProgressHandlerOptions options)
        {
            _options = options;
            _progressProcessor = progressProcessor;
            _progressProcessor.Process = ProcessProgressEvent;
        }

        public async Task TryCompleteAsync()
        {
            // This will close the channel and block on all pending items being processed
            await _progressProcessor.TryCompleteAsync().ConfigureAwait(false);
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

        public async ValueTask IncrementBytesTransferredAsync(long bytesTransferred, CancellationToken cancellationToken)
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

        private async ValueTask QueueProgressEvent(ProgressEventArgs args, CancellationToken cancellationToken = default)
        {
            try
            {
                await _progressProcessor.QueueAsync(args).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is ChannelClosedException || ex is OperationCanceledException)
            {
                // The only time we should get these exceptions is if the job is being
                // disposed, either by pause or failure, in which case its safe to ignore these.
            }
        }

        private Task ProcessProgressEvent(ProgressEventArgs args)
        {
            // Only ever one thread processing at a time so its safe to update these
            // Changes can be negative
            _completedCount += args.CompletedChange;
            _skippedCount += args.SkippedChange;
            _failedCount += args.FailedChange;
            _inProgressCount += args.InProgressChange;
            _queuedCount += args.QueuedChange;
            _bytesTransferred += args.BytesChange;

            TransferProgress progress = new()
            {
                CompletedCount = _completedCount,
                SkippedCount = _skippedCount,
                FailedCount = _failedCount,
                InProgressCount = _inProgressCount,
                QueuedCount = _queuedCount,
                BytesTransferred = _options?.TrackBytesTransferred == true ? _bytesTransferred : null
            };
            _options?.ProgressHandler?.Report(progress);

            return Task.CompletedTask;
        }
    }
}
