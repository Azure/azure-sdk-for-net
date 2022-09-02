// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class CommitBlockEventHandler
    {
        #region Delegate Definitions
        public delegate Task QueueCommitBlockTaskInternal();
        public delegate Task UpdateTransferStatusInternal(StorageTransferStatus status);
        public delegate void TriggerCancellationInternal();
        #endregion Delegate Definitions

        private readonly QueueCommitBlockTaskInternal _queueCommitBlockTask;
        private readonly TriggerCancellationInternal _triggerCancellationTask;
        private readonly UpdateTransferStatusInternal _updateTransferStatus;

        public struct Behaviors
        {
            public QueueCommitBlockTaskInternal QueueCommitBlockTask { get; set; }
            public TriggerCancellationInternal TriggerCancellationTask { get; set; }
            public UpdateTransferStatusInternal UpdateTransferStatus { get; set; }
        }

        private event SyncAsyncEventHandler<BlobStageBlockEventArgs> _commitBlockHandler;
        internal SyncAsyncEventHandler<BlobStageBlockEventArgs> GetCommitBlockHandler() => _commitBlockHandler;

        private readonly BlobSingleUploadOptions _uploadOptions;

        private long _bytesTransferred;
        private long _expectedLength;
        private readonly Uri _sourcePath;
        private readonly BlockBlobClient _destinationClient;
        private CancellationToken _cancellationToken;

        public CommitBlockEventHandler(
            long expectedLength,
            Uri sourcePath,
            BlockBlobClient destinationClient, // TODO: change this to just using the Uri
            Behaviors behaviors,
            BlobSingleUploadOptions uploadOptions,
            CancellationToken cancellationToken)
        {
            if (expectedLength <= 0) throw new ArgumentException("Cannot initiate Commit Block List function with File that has a negative or zero length");
            Argument.AssertNotNull(sourcePath, nameof(sourcePath));
            Argument.AssertNotNull(destinationClient, nameof(destinationClient));
            Argument.AssertNotNull(behaviors, nameof(behaviors));
            Argument.AssertNotNull(uploadOptions, nameof(uploadOptions));

            // Set values
            _expectedLength = expectedLength;
            _sourcePath = sourcePath;
            _destinationClient = destinationClient;
            _queueCommitBlockTask = behaviors.QueueCommitBlockTask;
            _triggerCancellationTask = behaviors.TriggerCancellationTask;
            _updateTransferStatus = behaviors.UpdateTransferStatus;
            _uploadOptions = uploadOptions;
            _cancellationToken = cancellationToken;

            // Set bytes transferred to 0
            _bytesTransferred = 0;

            AddCommitBlockEvent();
        }

        public void AddCommitBlockEvent()
        {
            _commitBlockHandler += async (BlobStageBlockEventArgs args) =>
            {
                Interlocked.Add(ref _bytesTransferred, args.BytesTransferred);
                if (args.Success)
                {
                    // Use progress tracker to get the amount of bytes transferred
                    if (_bytesTransferred == _expectedLength)
                    {
                        // Add CommitBlockList task to the channel
                        await _queueCommitBlockTask().ConfigureAwait(false);
                    }
                    else if (_bytesTransferred > _expectedLength)
                    {
                        await _updateTransferStatus(StorageTransferStatus.Completed).ConfigureAwait(false);
                        _uploadOptions?.GetUploadFailed().Invoke(
                            new BlobUploadFailedEventArgs(
                                args.TransferId,
                                _sourcePath.AbsolutePath,
                                _destinationClient,
                                new Exception("Bytes have overflowed, cannot commit block"),
                                false,
                                _cancellationToken));
                        _triggerCancellationTask();
                    }
                }
                else
                {
                    // Set status to completed
                    await _updateTransferStatus(StorageTransferStatus.Completed).ConfigureAwait(false);
                    _uploadOptions?.GetUploadFailed().Invoke(
                            new BlobUploadFailedEventArgs(
                                args.TransferId,
                                _sourcePath.AbsolutePath,
                                _destinationClient,
                                new Exception("Failure on stageblock"),
                                false,
                                _cancellationToken));
                    _triggerCancellationTask();
                }
            };
        }

        public void AddEvent(SyncAsyncEventHandler<BlobStageBlockEventArgs> stageBlockEvent)
        {
            _commitBlockHandler += stageBlockEvent;
        }

        public async Task InvokeEvent(BlobStageBlockEventArgs args)
        {
            await _commitBlockHandler.Invoke(args).ConfigureAwait(false);
        }
    }
}
