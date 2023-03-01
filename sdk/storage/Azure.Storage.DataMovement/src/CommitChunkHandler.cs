// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Storage.DataMovement;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Channels;

namespace Azure.Storage.DataMovement
{
    internal class CommitChunkHandler : IAsyncDisposable
    {
        // Indicates whether the current thread is processing stage chunks.
        private static Task _processStageChunkEvents;

        #region Delegate Definitions
        public delegate Task QueuePutBlockTaskInternal(long offset, long blockSize, long expectedLength);
        public delegate Task QueueCommitBlockTaskInternal();
        public delegate void ReportProgressInBytes(long bytesWritten);
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly QueuePutBlockTaskInternal _queuePutBlockTask;
        private readonly QueueCommitBlockTaskInternal _queueCommitBlockTask;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;

        public struct Behaviors
        {
            public QueuePutBlockTaskInternal QueuePutBlockTask { get; set; }
            public QueueCommitBlockTaskInternal QueueCommitBlockTask { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }
        }

        private event SyncAsyncEventHandler<StageChunkEventArgs> _commitBlockHandler;
        internal SyncAsyncEventHandler<StageChunkEventArgs> GetCommitBlockHandler() => _commitBlockHandler;

        /// <summary>
        /// Create channel of <see cref="StageChunkEventArgs"/> to keep track of that are
        /// waiting to update the bytesTransferredand other required operations.
        /// </summary>
        private readonly Channel<StageChunkEventArgs> _stageChunkChannel;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        private readonly SemaphoreSlim _currentBytesSemaphore;
        private long _bytesTransferred;
        private readonly long _expectedLength;
        private readonly long _blockSize;
        private readonly TransferType _transferType;

        public CommitChunkHandler(
            long expectedLength,
            long blockSize,
            Behaviors behaviors,
            TransferType transferType)
        {
            if (expectedLength <= 0)
            {
                throw new ArgumentException("Cannot initiate Commit Block List function with File that has a negative or zero length");
            }
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            _queuePutBlockTask = behaviors.QueuePutBlockTask
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueuePutBlockTask));
            _queueCommitBlockTask = behaviors.QueueCommitBlockTask
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCommitBlockTask));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));

            // Set expected length to perform commit task
            _expectedLength = expectedLength;

            // Create channel of finished Stage Chunk Args to update the bytesTransferred
            // and for ending tasks like commit block.
            // The size of the channel should never exceed 50k (limit on blocks in a block blob).
            // and that's in the worst case that we never read from the channel and had a maximum chunk blob.
            _stageChunkChannel = Channel.CreateUnbounded<StageChunkEventArgs>(
                new UnboundedChannelOptions()
                {
                    // Single reader is required as we can only read and write to bytesTransferred value
                    SingleReader = true,
                });
            _cancellationTokenSource = new CancellationTokenSource();
            _processStageChunkEvents = Task.Run(() => NotifyOfPendingStageChunkEvents());

            // Set bytes transferred to block size because we transferred the initial block
            _currentBytesSemaphore = new SemaphoreSlim(1, 1);
            _bytesTransferred = blockSize;

            _blockSize = blockSize;
            _transferType = transferType;
            if (_transferType == TransferType.Sequential)
            {
                _commitBlockHandler += QueueBlockEvent;
            }
            _commitBlockHandler += CommitBlockEvent;
        }

        public async ValueTask DisposeAsync()
        {
            // We no longer have to read from the channel. We are not expecting any more requests.
            _stageChunkChannel.Writer.Complete();
            await _stageChunkChannel.Reader.Completion.ConfigureAwait(false);
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
            _cancellationTokenSource.Dispose();

            if (_currentBytesSemaphore != default)
            {
                _currentBytesSemaphore.Dispose();
            }
            DipsoseHandlers();
        }

        public void DipsoseHandlers()
        {
            if (_transferType == TransferType.Sequential)
            {
                _commitBlockHandler -= QueueBlockEvent;
            }
            _commitBlockHandler -= CommitBlockEvent;
        }

        private async Task CommitBlockEvent(StageChunkEventArgs args)
        {
            if (args.Success)
            {
                // Let's add to the channel, and our notifier will handle the chunks.
                await _stageChunkChannel.Writer.WriteAsync(args, _cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await _invokeFailedEventHandler(new Exception("Failure on Stage Block")).ConfigureAwait(false);
            }
        }

        private async Task NotifyOfPendingStageChunkEvents()
        {
            try
            {
                while (await _stageChunkChannel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
                {
                    // Read one event argument at a time.
                    StageChunkEventArgs args = await _stageChunkChannel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
                    try
                    {
                        await _currentBytesSemaphore.WaitAsync(_cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // We should not continue if waiting on the semaphore has cancelled out.
                        return;
                    }

                    Interlocked.Add(ref _bytesTransferred, args.BytesTransferred);
                    // Use progress tracker to get the amount of bytes transferred
                    _reportProgressInBytes(_bytesTransferred);
                    if (_bytesTransferred == _expectedLength)
                    {
                        // Add CommitBlockList task to the channel
                        await _queueCommitBlockTask().ConfigureAwait(false);
                        _currentBytesSemaphore.Release();
                        return;
                    }
                    else if (_bytesTransferred > _expectedLength)
                    {
                        await _invokeFailedEventHandler(
                                new Exception("Unexpected Error: Amount of bytes transferred exceeds expected length.")).ConfigureAwait(false);
                        _currentBytesSemaphore.Release();
                        return;
                    }
                    _currentBytesSemaphore.Release();
                }
            }
            catch (OperationCanceledException)
            {
                // If operation cancelled, no need to log the exception. As it's logged by whoever called the cancellation (e.g. disposal)
            }
            catch (Exception ex)
            {
                await _invokeFailedEventHandler(ex).ConfigureAwait(false);
            }
        }

        private async Task QueueBlockEvent(StageChunkEventArgs args)
        {
            if (args.Success)
            {
                long oldOffset = args.Offset;
                long newOffset = oldOffset + _blockSize;
                if (newOffset < _expectedLength)
                {
                    long blockLength = (newOffset + _blockSize < _expectedLength) ?
                                    _blockSize :
                                    _expectedLength - newOffset;
                    await _queuePutBlockTask(newOffset, blockLength, _expectedLength).ConfigureAwait(false);
                }
            }
            else
            {
                // Set status to completed with failed
                await _invokeFailedEventHandler(new Exception("Failure on Stage Block")).ConfigureAwait(false);
            }
        }

        public async Task InvokeEvent(StageChunkEventArgs args)
        {
            await _commitBlockHandler.Invoke(args).ConfigureAwait(false);
        }
    }
}
