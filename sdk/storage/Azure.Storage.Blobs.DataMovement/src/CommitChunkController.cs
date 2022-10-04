// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class CommitChunkController
    {
        #region Delegate Definitions
        public delegate Task QueueCommitBlockTaskInternal();
        public delegate Task UpdateTransferStatusInternal(StorageTransferStatus status);
        public delegate void ReportProgressInBytes(long bytesWritten);
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly QueueCommitBlockTaskInternal _queueCommitBlockTask;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly UpdateTransferStatusInternal _updateTransferStatus;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;

        public struct Behaviors
        {
            public QueueCommitBlockTaskInternal QueueCommitBlockTask { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }
            public UpdateTransferStatusInternal UpdateTransferStatus { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }
        }

        private event SyncAsyncEventHandler<BlobStageChunkEventArgs> _commitBlockHandler;
        internal SyncAsyncEventHandler<BlobStageChunkEventArgs> GetCommitBlockHandler() => _commitBlockHandler;

        private long _bytesTransferred;
        private long _expectedLength;

        public CommitChunkController(
            long expectedLength,
            Behaviors behaviors)
        {
            if (expectedLength <= 0)
            {
                throw new ArgumentException("Cannot initiate Commit Block List function with File that has a negative or zero length");
            }
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            _queueCommitBlockTask = behaviors.QueueCommitBlockTask
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCommitBlockTask));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));
            _updateTransferStatus = behaviors.UpdateTransferStatus
                ?? throw Errors.ArgumentNull(nameof(behaviors.UpdateTransferStatus));

            // Set values
            _expectedLength = expectedLength;
            _queueCommitBlockTask = behaviors.QueueCommitBlockTask;
            _updateTransferStatus = behaviors.UpdateTransferStatus;

            // Set bytes transferred to 0
            _bytesTransferred = 0;

            AddCommitBlockEvent();
        }

        public void AddCommitBlockEvent()
        {
            _commitBlockHandler += async (BlobStageChunkEventArgs args) =>
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
                        await _updateTransferStatus(StorageTransferStatus.Completed).ConfigureAwait(false);
                        await _invokeFailedEventHandler(
                                new Exception("Unexpected Error: Amount of bytes transferred exceeds expected length.")).ConfigureAwait(false);
                    }
                    _reportProgressInBytes(_bytesTransferred);
                }
                else
                {
                    // Set status to completed
                    await _updateTransferStatus(StorageTransferStatus.Completed).ConfigureAwait(false);
                    await _invokeFailedEventHandler(new Exception("Failure on Stage Block")).ConfigureAwait(false);
                }
            };
        }

        public void AddEvent(SyncAsyncEventHandler<BlobStageChunkEventArgs> stageBlockEvent)
        {
            _commitBlockHandler += stageBlockEvent;
        }

        public async Task InvokeEvent(BlobStageChunkEventArgs args)
        {
            await _commitBlockHandler.Invoke(args).ConfigureAwait(false);
        }
    }
}
