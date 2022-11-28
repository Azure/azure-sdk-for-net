// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Storage.DataMovement;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    internal class CommitChunkHandler
    {
        #region Delegate Definitions
        public delegate Task QueuePutBlockTaskInternal(long offset, long blockSize, long expectedLength);
        public delegate Task QueueCommitBlockTaskInternal();
        public delegate Task UpdateTransferStatusInternal(StorageTransferStatus status);
        public delegate void ReportProgressInBytes(long bytesWritten);
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly QueuePutBlockTaskInternal _queuePutBlockTask;
        private readonly QueueCommitBlockTaskInternal _queueCommitBlockTask;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly UpdateTransferStatusInternal _updateTransferStatus;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;

        public struct Behaviors
        {
            public QueuePutBlockTaskInternal QueuePutBlockTask { get; set; }
            public QueueCommitBlockTaskInternal QueueCommitBlockTask { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }
            public UpdateTransferStatusInternal UpdateTransferStatus { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }
        }

        private event SyncAsyncEventHandler<StageChunkEventArgs> _commitBlockHandler;
        internal SyncAsyncEventHandler<StageChunkEventArgs> GetCommitBlockHandler() => _commitBlockHandler;

        private long _bytesTransferred;
        private long _expectedLength;
        private long _blockSize;

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
            _updateTransferStatus = behaviors.UpdateTransferStatus
                ?? throw Errors.ArgumentNull(nameof(behaviors.UpdateTransferStatus));

            // Set expected length to perform commit task
            _expectedLength = expectedLength;

            // Set bytes transferred to block size because we transferred the initial block
            _bytesTransferred = blockSize;

            _blockSize = blockSize;

            if (transferType == TransferType.Sequential)
            {
                AddQueueBlockEvent();
            }
            AddCommitBlockEvent();
        }

        public void AddCommitBlockEvent()
        {
            _commitBlockHandler += async (StageChunkEventArgs args) =>
            {
                if (args.Success)
                {
                    Interlocked.Add(ref _bytesTransferred, args.BytesTransferred);
                    // Use progress tracker to get the amount of bytes transferred
                    if (_bytesTransferred == _expectedLength)
                    {
                        // Add CommitBlockList task to the channel
                        await _queueCommitBlockTask().ConfigureAwait(false);
                    }
                    else if (_bytesTransferred > _expectedLength)
                    {
                        await _updateTransferStatus(StorageTransferStatus.CompletedWithSkippedTransfers).ConfigureAwait(false);
                        await _invokeFailedEventHandler(
                                new Exception("Unexpected Error: Amount of bytes transferred exceeds expected length.")).ConfigureAwait(false);
                    }
                    _reportProgressInBytes(_bytesTransferred);
                }
                else
                {
                    // Set status to completed
                    await _invokeFailedEventHandler(new Exception("Failure on Stage Block")).ConfigureAwait(false);
                }
            };
        }

        public void AddQueueBlockEvent()
        {
            _commitBlockHandler += async (StageChunkEventArgs args) =>
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
                };
        }

        public void AddEvent(SyncAsyncEventHandler<StageChunkEventArgs> stageBlockEvent)
        {
            _commitBlockHandler += stageBlockEvent;
        }

        public async Task InvokeEvent(StageChunkEventArgs args)
        {
            await _commitBlockHandler.Invoke(args).ConfigureAwait(false);
        }
    }
}
