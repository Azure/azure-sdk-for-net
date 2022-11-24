// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
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
        /// Part Number
        /// </summary>
        public int PartNumber;

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
        /// Determines how files are created or if they should be overwritten if they already exists
        /// </summary>
        internal StorageResourceCreateMode _createMode;

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
        public SyncAsyncEventHandler<TransferSkippedEventArgs> TransferSkippedEventHandler { get; internal set; }

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
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            long? maximumTransferChunkSize,
            long initialTransferSize,
            ErrorHandlingOptions errorHandling,
            StorageResourceCreateMode createMode,
            TransferCheckpointer checkpointer,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferFailedEventArgs> failedEventHandler,
            CancellationTokenSource cancellationTokenSource)
        {
            JobPartStatus = StorageTransferStatus.Queued;
            PartNumber = partNumber;
            _dataTransfer = dataTransfer;
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _errorHandling = errorHandling;
            _createMode = createMode;
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

        internal async Task TriggerCancellation(StorageTransferStatus status)
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
            await OnTransferStatusChanged(status).ConfigureAwait(false);
            _dataTransfer._state.ResetTransferredBytes();
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferStatus"></param>
        internal async Task OnTransferStatusChanged(StorageTransferStatus transferStatus)
        {
            if (transferStatus != StorageTransferStatus.None
                && JobPartStatus != transferStatus)
            {
                JobPartStatus = transferStatus;
                // TODO: change to RaiseAsync
                if (TransferStatusEventHandler != null)
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
        internal async Task InvokeSkippedArg()
        {
            if (TransferSkippedEventHandler != null)
            {
                // TODO: change to RaiseAsync
                await TransferSkippedEventHandler.Invoke(new TransferSkippedEventArgs(
                    _dataTransfer.Id,
                    _sourceResource,
                    _destinationResource,
                    false,
                    _cancellationTokenSource.Token)).ConfigureAwait(false);
            }
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
            if (_errorHandling == ErrorHandlingOptions.StopOnAllFailures ||
                _createMode == StorageResourceCreateMode.Fail)
            {
                await TriggerCancellation(StorageTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
            }
        }

        internal async Task<bool> CreateDestinationResource(long length)
        {
            if (_createMode == StorageResourceCreateMode.Overwrite)
            {
                try
                {
                    await _destinationResource.CreateAsync(
                        overwrite: true,
                        size: length,
                        cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                    return true;
                }
                catch (NotSupportedException)
                {
                    // The following storage resource type does not require a Create call
                    return true;
                }
                catch (Exception ex)
                {
                    await InvokeFailedArg(ex).ConfigureAwait(false);
                }
                return false;
            }
            else if (_createMode == StorageResourceCreateMode.Skip)
            {
                try
                {
                    await _destinationResource.CreateAsync(
                        overwrite: false,
                        size: length,
                        cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                    return true;
                }
                catch (RequestFailedException exception)
                when (exception.ErrorCode == "BlobAlreadyExists")
                {
                    await InvokeSkippedArg().ConfigureAwait(false);
                }
                catch (IOException exception)
                when (exception.Message.Contains("Cannot overwite file"))
                {
                    // Skip this file
                    await InvokeSkippedArg().ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    // Any other exception found should be documented as failed
                    await InvokeFailedArg(exception).ConfigureAwait(false);
                }
                return false;
            }
            else // StorageResourceCreateMode.Fail
            {
                try
                {
                    await _destinationResource.CreateAsync(
                        overwrite: false,
                        size: length,
                        cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                    return true;
                }
                catch (Exception exception)
                {
                    // Any other exception found should be documented as failed
                    await InvokeFailedArg(exception).ConfigureAwait(false);
                }
                return false;
            }
        }

        internal long CalculateBlockSize(long length)
        {
            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            if (_maximumTransferChunkSize.HasValue
            && _maximumTransferChunkSize > 0)
            {
                return Math.Min(
                _destinationResource.MaxChunkSize,
                    _maximumTransferChunkSize.Value);
            }
            return length < Constants.LargeUploadThreshold ?
                        Math.Min(Constants.DefaultBufferSize, _destinationResource.MaxChunkSize) :
                        Math.Min(Constants.LargeBufferSize, _destinationResource.MaxChunkSize);
        }
    }
}
