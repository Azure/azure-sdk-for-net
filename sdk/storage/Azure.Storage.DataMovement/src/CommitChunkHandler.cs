// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Channels;
using Azure.Core.Pipeline;

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
        private CancellationToken _cancellationToken;

        private readonly SemaphoreSlim _currentBytesSemaphore;
        private long _bytesTransferred;
        private readonly long _expectedLength;
        private readonly long _blockSize;
        private readonly DataTransferOrder _transferOrder;
        private readonly ClientDiagnostics _clientDiagnostics;

        public CommitChunkHandler(
            long expectedLength,
            long blockSize,
            Behaviors behaviors,
            DataTransferOrder transferOrder,
            ClientDiagnostics clientDiagnostics,
            CancellationToken cancellationToken)
        {
            if (expectedLength <= 0)
            {
                throw Errors.InvalidExpectedLength(expectedLength);
            }
            Argument.AssertNotNull(behaviors, nameof(behaviors));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

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
            _cancellationToken = cancellationToken;
            _processStageChunkEvents = Task.Run(() => NotifyOfPendingStageChunkEvents());

            // Set bytes transferred to block size because we transferred the initial block
            _currentBytesSemaphore = new SemaphoreSlim(1, 1);
            _bytesTransferred = blockSize;

            _blockSize = blockSize;
            _transferOrder = transferOrder;
            if (_transferOrder == DataTransferOrder.Sequential)
            {
                _commitBlockHandler += SequentialBlockEvent;
            }
            _commitBlockHandler += ConcurrentBlockEvent;
            _clientDiagnostics = clientDiagnostics;
        }

        public async ValueTask DisposeAsync()
        {
            // We no longer have to read from the channel. We are not expecting any more requests.
            _stageChunkChannel.Writer.TryComplete();
            await _stageChunkChannel.Reader.Completion.ConfigureAwait(false);

            if (_currentBytesSemaphore != default)
            {
                _currentBytesSemaphore.Dispose();
            }
            DipsoseHandlers();
        }

        private void DipsoseHandlers()
        {
            if (_transferOrder == DataTransferOrder.Sequential)
            {
                _commitBlockHandler -= SequentialBlockEvent;
            }
            _commitBlockHandler -= ConcurrentBlockEvent;
        }

        private async Task ConcurrentBlockEvent(StageChunkEventArgs args)
        {
            try
            {
                if (args.Success)
                {
                    // Let's add to the channel, and our notifier will handle the chunks.
                    await _stageChunkChannel.Writer.WriteAsync(args, _cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    // Log an unexpected error since it came back unsuccessful
                    throw args.Exception;
                }
            }
            catch (Exception ex)
            {
                // Log an unexpected error since it came back unsuccessful
                await _invokeFailedEventHandler(ex).ConfigureAwait(false);
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
                    // Report the incremental bytes transferred
                    _reportProgressInBytes(args.BytesTransferred);

                    if (_bytesTransferred == _expectedLength)
                    {
                        // Add CommitBlockList task to the channel
                        await _queueCommitBlockTask().ConfigureAwait(false);
                    }
                    else if (_bytesTransferred > _expectedLength)
                    {
                        throw Errors.MismatchLengthTransferred(
                                expectedLength: _expectedLength,
                                actualLength: _bytesTransferred);
                    }
                    _currentBytesSemaphore.Release();
                }
            }
            catch (Exception ex)
            {
                if (_currentBytesSemaphore.CurrentCount == 0)
                {
                    _currentBytesSemaphore.Release();
                }
                // Invoke the failed event argument here after we've released the semaphore
                // or else we risk disposing the semaphore and releasing it after.
                await _invokeFailedEventHandler(ex).ConfigureAwait(false);
            }
        }

        private async Task SequentialBlockEvent(StageChunkEventArgs args)
        {
            try
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
                    // Log an unexpected error since it came back unsuccessful
                    throw args.Exception;
                }
            }
            catch (Exception ex)
            {
                // Log an unexpected error since it came back unsuccessful
                await _invokeFailedEventHandler(ex).ConfigureAwait(false);
            }
        }

        public async Task InvokeEvent(StageChunkEventArgs args)
        {
            // There's a race condition where the event handler was disposed and an event
            // was already invoked, we should skip over this as the download chunk handler
            // was already disposed, and we should just ignore any more incoming events.
            if (_commitBlockHandler != null)
            {
                await _commitBlockHandler.RaiseAsync(
                    args,
                    nameof(CommitChunkHandler),
                    nameof(_commitBlockHandler),
                    _clientDiagnostics).ConfigureAwait(false);
            }
        }
    }
}
