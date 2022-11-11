﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal abstract class JobPartInternal
    {
        public delegate Task QueueChunkDelegate(Func<Task> item);
        public QueueChunkDelegate QueueChunk { get; internal set; }

        /// <summary>
        /// DataTransfer communicate when the transfer has finished and the progress
        /// </summary>
        internal DataTransfer _dataTransfer { get; set; }

        /// <summary>
        /// Cancellation Token Source
        ///
        /// Will be initialized when the tasks are running.
        ///
        /// Will be disposed of once all tasks of the job have completed or have been cancelled.
        /// </summary>
        internal CancellationTokenSource _cancellationTokenSource { get; set; }

        /// <summary>
        /// Plan file writer for hte respective job
        /// </summary>
        internal TransferCheckpointer _checkpointer { get; set; }

        /// <summary>
        /// Source resource
        /// </summary>
        internal StorageResource _sourceResource;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResource _destinationResource;

        /// <summary>
        /// The error handling options
        /// </summary>
        internal ErrorHandlingOptions _errorHandling;

        /// <summary>
        /// The maximum length of an transfer in bytes.
        ///
        /// On uploads, if the value is not set, it will be set at 4 MB if the total size is less than 100MB
        /// or will default to 8 MB if the total size is greater than or equal to 100MB.
        /// </summary>
        internal long? _maximumTransferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be Uploaded or Downloaded in a single request.
        /// Transfers larger than this limit will continue being downloaded or uploaded
        /// in chunks of size <see cref="_maximumTransferChunkSize"/>.
        ///
        /// On Uploads, if the value is not set, it will set at 256 MB.
        /// </summary>
        internal long _initialTransferSize { get; set; }

        /// <summary>
        /// Status of each Job part
        /// </summary>
        public StorageTransferStatus JobPartStatus { get; set; }

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatusEventHandler { get; internal set; }

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferFailedEventArgs> TransferFailedEventHandler { get; internal set; }

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        protected JobPartInternal() { }

        internal JobPartInternal(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            long? maximumTransferChunkSize,
            long initialTransferSize,
            ErrorHandlingOptions errorHandling,
            TransferCheckpointer checkpointer,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferFailedEventArgs> failedEventHandler,
            CancellationTokenSource cancellationTokenSource)
        {
            JobPartStatus = StorageTransferStatus.Queued;
            _dataTransfer = dataTransfer;
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _errorHandling = errorHandling;
            _checkpointer = checkpointer;
            _cancellationTokenSource = cancellationTokenSource;
            _maximumTransferChunkSize = maximumTransferChunkSize;
            _initialTransferSize = initialTransferSize;
            _arrayPool = arrayPool;
            TransferStatusEventHandler = statusEventHandler;
            TransferFailedEventHandler = failedEventHandler;
        }

        public void SetQueueChunkDelegate(QueueChunkDelegate chunkDelegate)
        {
            QueueChunk = chunkDelegate;
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job chunks</returns>
        public abstract Task ProcessPartToChunkAsync();

        internal async Task TriggerCancellation()
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
            await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
            _dataTransfer._state.ResetTransferredBytes();
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferStatus"></param>
        internal async Task OnTransferStatusChanged(StorageTransferStatus transferStatus)
        {
            if (JobPartStatus != transferStatus)
            {
                JobPartStatus = transferStatus;
                // TODO: change to RaiseAsync
                if (TransferFailedEventHandler != null)
                {
                    await TransferStatusEventHandler.Invoke(new TransferStatusEventArgs(
                        _dataTransfer.Id,
                        transferStatus,
                        false,
                        _cancellationTokenSource.Token)).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="bytesTransferred"></param>
        internal void ReportBytesWritten(long bytesTransferred)
        {
            _dataTransfer._state.UpdateTransferBytes(bytesTransferred);
        }

        /// <summary>
        /// Invokes Failed Argument
        /// </summary>
        internal async Task InvokeFailedArg(Exception ex)
        {
            if (TransferFailedEventHandler != null)
            {
                // TODO: change to RaiseAsync
                await TransferFailedEventHandler.Invoke(new TransferFailedEventArgs(
                    _dataTransfer.Id,
                    _sourceResource,
                    _destinationResource,
                    ex,
                    false,
                    _cancellationTokenSource.Token)).ConfigureAwait(false);
            }
            // Trigger job cancellation if the failed handler is enabled
            if (_errorHandling == ErrorHandlingOptions.StopOnAllFailures)
            {
                await TriggerCancellation().ConfigureAwait(false);
            }
        }
    }
}
