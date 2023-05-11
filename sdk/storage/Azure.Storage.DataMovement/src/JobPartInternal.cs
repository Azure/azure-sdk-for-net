﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;
using System.Linq;
using Azure.Storage.DataMovement.Models.JobPlan;
using System.Runtime.CompilerServices;

namespace Azure.Storage.DataMovement
{
    internal abstract class JobPartInternal
    {
        public delegate Task QueueChunkDelegate(Func<Task> item);
        public QueueChunkDelegate QueueChunk { get; internal set; }

        /// <summary>
        /// Part number of the current job part.
        /// </summary>
        public int PartNumber;

        /// <summary>
        /// DataTransfer object that communicates when the transfer completes and it's current progress.
        /// </summary>
        internal DataTransfer _dataTransfer { get; set; }

        /// <summary>
        /// Cancellation Token Source
        ///
        /// Will be initialized when the tasks are running.
        ///
        /// Will be disposed of once all tasks of the job have completed or have been cancelled.
        /// </summary>
        internal CancellationToken _cancellationToken { get; set; }

        /// <summary>
        /// Plan file writer for the respective job.
        /// </summary>
        internal TransferCheckpointer _checkpointer { get; set; }

        /// <summary>
        /// Specifies the source resource.
        /// </summary>
        internal StorageResource _sourceResource;

        /// <summary>
        /// Specifies the destination resource.
        /// </summary>
        internal StorageResource _destinationResource;

        /// <summary>
        /// Specifies the options for error handling.
        /// </summary>
        internal ErrorHandlingOptions _errorHandling;

        /// <summary>
        /// Determines how files are created and overwrite behavior for files that already exists.
        /// </summary>
        internal StorageResourceCreateMode _createMode;

        /// <summary>
        /// If a failure occurred during a job, this defines the type of failure.
        ///
        /// This assists in doing the proper cleanup to leave the storage resource container in the state
        /// it was in.
        /// </summary>
        internal JobPartFailureType _failureType;
        private object _failureTypeLock = new object();

        /// <summary>
        /// The maximum length of an transfer in bytes.
        ///
        /// On uploads, if the value is not set, it will be set at 4 MB if the total size is less than 100MB,
        /// or will default to 8 MB if the total size is greater than or equal to 100MB.
        /// </summary>
        internal long _maximumTransferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be uploaded or downloaded in a single request.
        /// Transfers larger than this limit will continue being downloaded or uploaded
        /// in chunks of size <see cref="_maximumTransferChunkSize"/>.
        ///
        /// On Uploads, if the value is not set, it will set at 256 MB.
        /// </summary>
        internal long _initialTransferSize { get; set; }

        /// <summary>
        /// The current status of each job part.
        /// </summary>
        public StorageTransferStatus JobPartStatus { get; set; }
        private object _statusLock = new object();

        /// <summary>
        /// Optional. If the length is known, we log it instead of doing a GetProperties call on the
        /// storage resource. The length obtained during a listing call.
        /// </summary>
        internal long? Length;

        /// <summary>
        /// Defines whether or not this was the final part in the list call. This would determine
        /// whether or not we needed to keep listing in the job.
        /// </summary>
        public bool IsFinalPart { get; internal set; }

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferStatusEventArgs> PartTransferStatusEventHandler { get; internal set; }

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
        /// If a single transfer within the resource contianer gets transferred successfully the event
        /// will get added to this handler
        /// </summary>
        public SyncAsyncEventHandler<SingleTransferCompletedEventArgs> SingleTransferCompletedEventHandler { get; internal set; }

        private List<Task<bool>> _chunkTasks;
        private List<TaskCompletionSource<bool>> _chunkTaskSources;

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
            long? initialTransferSize,
            ErrorHandlingOptions errorHandling,
            StorageResourceCreateMode createMode,
            TransferCheckpointer checkpointer,
            ArrayPool<byte> arrayPool,
            bool isFinalPart,
            SyncAsyncEventHandler<TransferStatusEventArgs> jobPartEventHandler,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferFailedEventArgs> failedEventHandler,
            SyncAsyncEventHandler<TransferSkippedEventArgs> skippedEventHandler,
            SyncAsyncEventHandler<SingleTransferCompletedEventArgs> singleTransferEventHandler,
            CancellationToken cancellationToken,
            StorageTransferStatus jobPartStatus = StorageTransferStatus.Queued,
            long? length = default)
        {
            JobPartStatus = jobPartStatus;
            PartNumber = partNumber;
            _dataTransfer = dataTransfer;
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _errorHandling = errorHandling;
            _createMode = createMode;
            _failureType = JobPartFailureType.None;
            _checkpointer = checkpointer;
            _cancellationToken = cancellationToken;
            _arrayPool = arrayPool;
            IsFinalPart = isFinalPart;
            PartTransferStatusEventHandler = jobPartEventHandler;
            TransferStatusEventHandler = statusEventHandler;
            TransferFailedEventHandler = failedEventHandler;
            TransferSkippedEventHandler = skippedEventHandler;
            SingleTransferCompletedEventHandler = singleTransferEventHandler;

            _initialTransferSize = _destinationResource.MaxChunkSize;
            if (initialTransferSize.HasValue)
            {
                _initialTransferSize = Math.Min(initialTransferSize.Value, _destinationResource.MaxChunkSize);
            }
            // If the maximum chunk size is not set, we will determine the chunk size
            // based on the file length later
            _maximumTransferChunkSize = _destinationResource.MaxChunkSize;
            if (maximumTransferChunkSize.HasValue)
            {
                _maximumTransferChunkSize = Math.Min(
                    maximumTransferChunkSize.Value,
                    _destinationResource.MaxChunkSize);
            }

            Length = length;
            _chunkTasks = new List<Task<bool>>();
            _chunkTaskSources = new List<TaskCompletionSource<bool>>();
        }

        public void SetQueueChunkDelegate(QueueChunkDelegate chunkDelegate)
        {
            QueueChunk = chunkDelegate;
        }

        /// <summary>
        /// Queues the task to the main chunk channel and also appends the tracking
        /// completion source to the task. So we know the state of each chunk especially
        /// when we're looking to stop/pause the job part.
        /// </summary>
        /// <returns></returns>
        public async Task QueueChunkToChannelAsync(Func<Task> chunkTask)
        {
            // Attach TaskCompletionSource
            TaskCompletionSource<bool> chunkCompleted = new TaskCompletionSource<bool>(
                false,
                TaskCreationOptions.RunContinuationsAsynchronously);
            _chunkTaskSources.Add(chunkCompleted);
            _chunkTasks.Add(chunkCompleted.Task);

            await QueueChunk(
                async () =>
                {
                    await Task.Run(chunkTask).ConfigureAwait(false);
                    chunkCompleted.SetResult(true);
                    await CheckAndUpdateCancellationStatusAsync().ConfigureAwait(false);
                }).ConfigureAwait(false);
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job chunks</returns>
        public abstract Task ProcessPartToChunkAsync();

        /// <summary>
        /// Triggers the cancellation for the Job Part.
        ///
        /// If the status is set to <see cref="StorageTransferStatus.Paused"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="StorageTransferStatus.PauseInProgress"/>
        /// until the chunks finish then it will be set to <see cref="StorageTransferStatus.Paused"/>.
        ///
        /// If the status is set to <see cref="StorageTransferStatus.CompletedWithFailedTransfers"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="StorageTransferStatus.CancellationInProgress"/>
        /// until the chunks finish then it will be set to <see cref="StorageTransferStatus.CompletedWithFailedTransfers"/>.
        /// </summary>
        /// <returns>The task to wait until the cancellation has been triggered.</returns>
        internal async Task TriggerCancellationAsync()
        {
            // If stop on failure specified, cancel entire job.
            if (_errorHandling == ErrorHandlingOptions.StopOnAllFailures)
            {
                if (!_cancellationToken.IsCancellationRequested)
                {
                    _dataTransfer._state.TriggerCancellation();
                }
                _dataTransfer._state.ResetTransferredBytes();
            }

            // Set the status to Pause/CancellationInProgress
            if (StorageTransferStatus.PauseInProgress == _dataTransfer.TransferStatus)
            {
                // It's possible that the status hasn't propagated down to the job part
                // status yet here since we pause from the data transfer object.
                await OnTransferStatusChanged(StorageTransferStatus.PauseInProgress).ConfigureAwait(false);
            }
            else
            {
                // It's a cancellation if a pause wasn't called.
                await OnTransferStatusChanged(StorageTransferStatus.CancellationInProgress).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferStatus"></param>
        internal async Task OnTransferStatusChanged(StorageTransferStatus transferStatus)
        {
            bool statusChanged = false;
            lock (_statusLock)
            {
                if (transferStatus != StorageTransferStatus.None
                    && JobPartStatus != transferStatus)
                {
                    statusChanged = true;
                    JobPartStatus = transferStatus;
                }
            }
            if (statusChanged)
            {
                if (JobPartStatus == StorageTransferStatus.Completed)
                {
                    await InvokeSingleCompletedArg().ConfigureAwait(false);
                }
                if (JobPartStatus == StorageTransferStatus.Paused ||
                    JobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers)
                {
                    await CleanupAbortedJobPartAsync().ConfigureAwait(false);
                }
                // Set the status in the checkpointer
                await SetCheckpointerStatus(transferStatus).ConfigureAwait(false);

                // TODO: change to RaiseAsync
                await PartTransferStatusEventHandler.Invoke(new TransferStatusEventArgs(
                    _dataTransfer.Id,
                    transferStatus,
                    false,
                    _cancellationToken)).ConfigureAwait(false);
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

        public async virtual Task InvokeSingleCompletedArg()
        {
            if (SingleTransferCompletedEventHandler != null)
            {
                await SingleTransferCompletedEventHandler.Invoke(
                    new SingleTransferCompletedEventArgs(
                        _dataTransfer.Id,
                        _sourceResource,
                        _destinationResource,
                        false,
                        _cancellationToken)).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Invokes Skipped Argument Event.
        /// </summary>
        public async virtual Task InvokeSkippedArg()
        {
            if (TransferSkippedEventHandler != null)
            {
                // TODO: change to RaiseAsync
                await TransferSkippedEventHandler.Invoke(new TransferSkippedEventArgs(
                    _dataTransfer.Id,
                    _sourceResource,
                    _destinationResource,
                    false,
                    _cancellationToken)).ConfigureAwait(false);
            }
            await OnTransferStatusChanged(StorageTransferStatus.CompletedWithSkippedTransfers).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes Failed Argument Event.
        /// </summary>
        public async virtual Task InvokeFailedArg(Exception ex)
        {
            if (ex is not OperationCanceledException)
            {
                SetFailureType(ex.Message);
                if (TransferFailedEventHandler != null)
                {
                    // TODO: change to RaiseAsync
                    await TransferFailedEventHandler.Invoke(new TransferFailedEventArgs(
                        _dataTransfer.Id,
                        _sourceResource,
                        _destinationResource,
                        ex,
                        false,
                        _cancellationToken)).ConfigureAwait(false);
                }
            }
            // Trigger job cancellation if the failed handler is enabled
            await TriggerCancellationAsync().ConfigureAwait(false);
            await CheckAndUpdateCancellationStatusAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cleans up the job part if it's in a state where the job part was aborted due to failure,
        /// or paused.
        /// </summary>
        /// <returns></returns>
        public async virtual Task CleanupAbortedJobPartAsync()
        {
            // If the failure occurred due to the file already existing or authentication,
            // and overwrite wasn't enabled, don't delete the existing file. We can remove
            // the unfinished file for other error types.
            if (JobPartFailureType.Other == _failureType)
            {
                // If the job part is paused or ended with failures
                // delete the destination resource because it could be unfinished or corrupted
                // If we resume we would have to start from the beginning anyways.
                await _destinationResource.DeleteIfExistsAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Serializes the respective job part and adds it to the checkpointer.
        /// </summary>
        /// <param name="chunksTotal">Number of chunks in the job part.</param>
        /// <param name="isFinalPart">Defines if this part is the last job part of the job.</param>
        /// <returns></returns>
        public async virtual Task AddJobPartToCheckpointerAsync(int chunksTotal, bool isFinalPart)
        {
            JobPartPlanHeader header = this.ToJobPartPlanHeader(
                jobStatus: StorageTransferStatus.InProgress,
                isFinalPart: isFinalPart);
            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);
                await _checkpointer.AddNewJobPartAsync(
                        transferId: _dataTransfer.Id,
                        partNumber: PartNumber,
                        chunksTotal: chunksTotal,
                        headerStream: stream,
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
            }
        }

        internal async virtual Task SetCheckpointerStatus(StorageTransferStatus status)
        {
            await _checkpointer.SetJobPartTransferStatusAsync(
                transferId: _dataTransfer.Id,
                partNumber: PartNumber,
                status: status).ConfigureAwait(false);
        }

        internal long CalculateBlockSize(long length)
        {
            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            if (_maximumTransferChunkSize > 0)
            {
                long assignedSize = Math.Min(
                    _destinationResource.MaxChunkSize,
                    _maximumTransferChunkSize);
                return Math.Min(assignedSize, length);
            }
            long blockSize = length < Constants.LargeUploadThreshold ?
                        Math.Min(Constants.DefaultBufferSize, _destinationResource.MaxChunkSize) :
                        Math.Min(Constants.LargeBufferSize, _destinationResource.MaxChunkSize);
            return Math.Min(blockSize, length);
        }

        internal static long ParseRangeTotalLength(string range)
        {
            if (range == null)
            {
                return 0;
            }
            int lengthSeparator = range.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            if (lengthSeparator == -1)
            {
                throw new ArgumentException("Could not obtain the total length from HTTP range " + range);
            }
            return long.Parse(range.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        internal static List<(long Offset, long Size)> GetRangeList(long blockSize, long fileLength)
        {
            // The list tracking blocks IDs we're going to commit
            List<(long Offset, long Size)> partitions = new List<(long, long)>();

            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in GetPartitionIndexes(fileLength, blockSize))
            {
                /* We need to do this first! Length is calculated on the fly based on stream buffer
                    * contents; We need to record the partition data first before consuming the stream
                    * asynchronously. */
                partitions.Add(block);
            }
            return partitions;
        }

        /// <summary>
        /// Partition a stream into a series of blocks buffered as needed by an array pool.
        /// </summary>
        private static IEnumerable<(long Offset, long Length)> GetPartitionIndexes(
            long streamLength, // StreamLength needed to divide before hand
            long blockSize)
        {
            // The minimum amount of data we'll accept from a stream before
            // splitting another block. Code that sets `blockSize` will always
            // set it to a positive number. Min() only avoids edge case where
            // user sets their block size to 1.
            long acceptableBlockSize = Math.Max(1, blockSize);

            // service has a max block count per blob
            // block size * block count limit = max data length to upload
            // if stream length is longer than specified max block size allows, can't upload
            long minRequiredBlockSize = (long)Math.Ceiling((double)streamLength / Constants.Blob.Block.MaxBlocks);
            if (blockSize < minRequiredBlockSize)
            {
                throw Errors.InsufficientStorageTransferOptions(streamLength, blockSize, minRequiredBlockSize);
            }
            // bring min up to our min required by the service
            acceptableBlockSize = Math.Max(acceptableBlockSize, minRequiredBlockSize);

            // Start the position at the first block size since the first block has potentially
            // been already staged.
            long absolutePosition = blockSize;
            long blockLength = acceptableBlockSize;

            // TODO: divide up paritions based on how much array pool is left
            while (absolutePosition < streamLength)
            {
                // Return based on the size of the stream divided up by the acceptable blocksize.
                blockLength = (absolutePosition + acceptableBlockSize < streamLength) ?
                    acceptableBlockSize :
                    streamLength - absolutePosition;
                yield return (absolutePosition, blockLength);
                absolutePosition += blockLength;
            }
        }

        internal async Task CheckAndUpdateCancellationStatusAsync()
        {
            if (_chunkTasks.All((Task task) => (task.IsCompleted)))
            {
                if (_dataTransfer.TransferStatus == StorageTransferStatus.PauseInProgress)
                {
                    await OnTransferStatusChanged(StorageTransferStatus.Paused).ConfigureAwait(false);
                }
                else if (_dataTransfer.TransferStatus == StorageTransferStatus.CancellationInProgress)
                {
                    await OnTransferStatusChanged(StorageTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
            }
        }

        private void SetFailureType(string exceptionMessage)
        {
            lock (_failureTypeLock)
            {
                if (_failureType == JobPartFailureType.None)
                {
                    foreach (string errorMessage in DataMovementConstants.ErrorCode.CannotOverwrite)
                    {
                        if (exceptionMessage.Contains(errorMessage))
                        {
                            _failureType = JobPartFailureType.CannotOvewrite;
                            return;
                        }
                    }

                    foreach (string errorMessage in DataMovementConstants.ErrorCode.AccessDenied)
                    {
                        if (exceptionMessage.Contains(errorMessage))
                        {
                            _failureType = JobPartFailureType.AccessDenied;
                            return;
                        }
                    }
                    _failureType = JobPartFailureType.Other;
                }
            }
        }
    }
}
