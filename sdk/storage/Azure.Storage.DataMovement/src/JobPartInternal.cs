// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement.JobPlan;

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

        private TransferProgressTracker _progressTracker;

        /// <summary>
        /// Specifies the source resource.
        /// </summary>
        internal StorageResourceItem _sourceResource;

        /// <summary>
        /// Specifies the destination resource.
        /// </summary>
        internal StorageResourceItem _destinationResource;

        /// <summary>
        /// Specifies the options for error handling.
        /// </summary>
        internal DataTransferErrorMode _errorHandling;

        /// <summary>
        /// Determines how files are created and overwrite behavior for files that already exists.
        /// </summary>
        internal StorageResourceCreationPreference _createMode;

        /// <summary>
        /// If a failure occurred during a job, this defines the type of failure.
        ///
        /// This assists in doing the proper cleanup to leave the storage resource container in the state
        /// it was in.
        /// </summary>
        internal JobPartFailureType _failureType;
        private object _failureTypeLock = new object();

        /// <summary>
        /// The chunk size to use for the transfer.
        /// </summary>
        internal long _transferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be Uploaded or Downloaded in a single request. Transfers larger than this
        /// limit will continue being downloaded or uploaded in chunks of size
        /// <see cref="_transferChunkSize"/>.
        /// </summary>
        internal long _initialTransferSize { get; set; }

        /// <summary>
        /// The current status of each job part.
        /// </summary>
        public DataTransferStatus JobPartStatus { get; set; }

        /// <summary>
        /// Optional. If the length is known, we log it instead of doing a GetProperties call on the
        /// storage resource. The length obtained during a listing call.
        /// </summary>
        internal long? Length;

        internal ClientDiagnostics ClientDiagnostics { get; }

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
        public SyncAsyncEventHandler<TransferItemSkippedEventArgs> TransferSkippedEventHandler { get; internal set; }

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferItemFailedEventArgs> TransferFailedEventHandler { get; internal set; }

        /// <summary>
        /// If a single transfer within the resource container gets transferred successfully the event
        /// will get added to this handler
        /// </summary>
        public SyncAsyncEventHandler<TransferItemCompletedEventArgs> SingleTransferCompletedEventHandler { get; internal set; }

        private List<Task<bool>> _chunkTasks;
        private List<TaskCompletionSource<bool>> _chunkTaskSources;
        protected bool _queueingTasks = false;

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        protected JobPartInternal() { }

        internal JobPartInternal(
            DataTransfer dataTransfer,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            long? transferChunkSize,
            long? initialTransferSize,
            DataTransferErrorMode errorHandling,
            StorageResourceCreationPreference createMode,
            TransferCheckpointer checkpointer,
            TransferProgressTracker progressTracker,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> jobPartEventHandler,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferItemFailedEventArgs> failedEventHandler,
            SyncAsyncEventHandler<TransferItemSkippedEventArgs> skippedEventHandler,
            SyncAsyncEventHandler<TransferItemCompletedEventArgs> singleTransferEventHandler,
            ClientDiagnostics clientDiagnostics,
            CancellationToken cancellationToken,
            DataTransferStatus jobPartStatus = default,
            long? length = default)
        {
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            // if default is passed, the job part status will be queued
            JobPartStatus = jobPartStatus ?? new DataTransferStatus();
            PartNumber = partNumber;
            _dataTransfer = dataTransfer;
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _errorHandling = errorHandling;
            _failureType = JobPartFailureType.None;
            _checkpointer = checkpointer;
            _progressTracker = progressTracker;
            _cancellationToken = cancellationToken;
            _arrayPool = arrayPool;
            PartTransferStatusEventHandler = jobPartEventHandler;
            TransferStatusEventHandler = statusEventHandler;
            TransferFailedEventHandler = failedEventHandler;
            TransferSkippedEventHandler = skippedEventHandler;
            SingleTransferCompletedEventHandler = singleTransferEventHandler;
            ClientDiagnostics = clientDiagnostics;

            // Set transfer sizes to user specified values or default
            // clamped to max supported chunk size for the destination.
            _initialTransferSize = Math.Min(
                initialTransferSize ?? DataMovementConstants.DefaultInitialTransferSize,
                _destinationResource.MaxSupportedChunkSize);
            _transferChunkSize = Math.Min(
                transferChunkSize ?? DataMovementConstants.DefaultChunkSize,
                _destinationResource.MaxSupportedChunkSize);
            // Set the default create mode
            _createMode = createMode == StorageResourceCreationPreference.Default ?
                StorageResourceCreationPreference.FailIfExists : createMode;

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
                    try
                    {
                        await Task.Run(chunkTask).ConfigureAwait(false);
                        chunkCompleted.SetResult(true);
                        await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        await InvokeFailedArg(ex).ConfigureAwait(false);
                    }
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
        /// If the status is set to <see cref="DataTransferState.Paused"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="DataTransferState.Pausing"/>
        /// until the chunks finish then it will be set to <see cref="DataTransferState.Paused"/>.
        ///
        /// If the part status is set to <see cref="DataTransferState.Completed"/> but has
        /// <see cref="DataTransferStatus.HasFailedItems"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="DataTransferState.Stopping"/>
        /// until the chunks finish then it will be set to <see cref="DataTransferState.Completed"/>.
        /// </summary>
        /// <returns>The task to wait until the cancellation has been triggered.</returns>
        internal async Task TriggerCancellationAsync()
        {
            // Set the status to Pause/CancellationInProgress
            if (DataTransferState.Pausing == _dataTransfer.TransferStatus.State)
            {
                // It's possible that the status hasn't propagated down to the job part
                // status yet here since we pause from the data transfer object.
                await OnTransferStateChangedAsync(DataTransferState.Pausing).ConfigureAwait(false);
            }
            else
            {
                // It's a cancellation if a pause wasn't called.
                await OnTransferStateChangedAsync(DataTransferState.Stopping).ConfigureAwait(false);
            }
            await CleanupAbortedJobPartAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferState"></param>
        internal async Task OnTransferStateChangedAsync(DataTransferState transferState)
        {
            if (JobPartStatus.TrySetTransferStateChange(transferState))
            {
                // Progress tracking, do before invoking the event below
                if (transferState == DataTransferState.InProgress)
                {
                    _progressTracker.IncrementInProgressFiles();
                }
                else if (JobPartStatus.HasCompletedSuccessfully)
                {
                    _progressTracker.IncrementCompletedFiles();
                    await InvokeSingleCompletedArg().ConfigureAwait(false);
                }

                // Set the status in the checkpointer
                await SetCheckpointerStatus().ConfigureAwait(false);

                await PartTransferStatusEventHandler.RaiseAsync(
                    new TransferStatusEventArgs(
                        _dataTransfer.Id,
                        JobPartStatus.DeepCopy(),
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(PartTransferStatusEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="bytesTransferred"></param>
        internal void ReportBytesWritten(long bytesTransferred)
        {
            _progressTracker.IncrementBytesTransferred(bytesTransferred);
        }

        public async virtual Task InvokeSingleCompletedArg()
        {
            if (SingleTransferCompletedEventHandler != null)
            {
                await SingleTransferCompletedEventHandler.RaiseAsync(
                    new TransferItemCompletedEventArgs(
                        _dataTransfer.Id,
                        _sourceResource,
                        _destinationResource,
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(SingleTransferCompletedEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
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
                await TransferSkippedEventHandler.RaiseAsync(
                    new TransferItemSkippedEventArgs(
                        _dataTransfer.Id,
                        _sourceResource,
                        _destinationResource,
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(TransferSkippedEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
            _progressTracker.IncrementSkippedFiles();

            // Update the JobPartStatus. If was already updated (e.g. there was a failed item before)
            // then don't raise the PartTransferStatusEventHandler
            if (JobPartStatus.TrySetSkippedItem())
            {
                await PartTransferStatusEventHandler.RaiseAsync(
                    new TransferStatusEventArgs(
                        _dataTransfer.Id,
                        JobPartStatus.DeepCopy(),
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(PartTransferStatusEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
            //TODO: figure out why we set the Completed state here and not just wait for all the chunks to finish
            await OnTransferStateChangedAsync(DataTransferState.Completed).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes Failed Argument Event.
        /// </summary>
        public async virtual Task InvokeFailedArg(Exception ex)
        {
            if (ex is not OperationCanceledException &&
                ex is not TaskCanceledException &&
                !ex.Message.Contains("The request was canceled."))
            {
                SetFailureType(ex.Message);
                if (TransferFailedEventHandler != null)
                {
                    await TransferFailedEventHandler.RaiseAsync(
                        new TransferItemFailedEventArgs(
                            _dataTransfer.Id,
                            _sourceResource,
                            _destinationResource,
                            ex,
                            false,
                            _cancellationToken),
                        nameof(JobPartInternal),
                        nameof(TransferFailedEventHandler),
                        ClientDiagnostics)
                        .ConfigureAwait(false);
                }
                _progressTracker.IncrementFailedFiles();

                // Update the JobPartStatus. If was already updated (e.g. there was a failed item before)
                // then don't raise the PartTransferStatusEventHandler
                if (JobPartStatus.TrySetFailedItem())
                {
                    await PartTransferStatusEventHandler.RaiseAsync(
                        new TransferStatusEventArgs(
                            _dataTransfer.Id,
                            JobPartStatus.DeepCopy(),
                            false,
                            _cancellationToken),
                        nameof(JobPartInternal),
                        nameof(PartTransferStatusEventHandler),
                        ClientDiagnostics)
                        .ConfigureAwait(false);
                }
            }

            try
            {
                // Trigger job cancellation if the failed handler is enabled
                await TriggerCancellationAsync().ConfigureAwait(false);
                await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
            }
            catch (Exception cancellationException)
            {
                // If an exception is thrown while trying to clean up,
                // raise the failed event and prevent the transfer from hanging
                await TransferFailedEventHandler.RaiseAsync(
                    new TransferItemFailedEventArgs(
                        _dataTransfer.Id,
                        _sourceResource,
                        _destinationResource,
                        cancellationException,
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(TransferFailedEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
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
        public async virtual Task AddJobPartToCheckpointerAsync()
        {
            JobPartPlanHeader header = this.ToJobPartPlanHeader();
            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);
                await _checkpointer.AddNewJobPartAsync(
                    transferId: _dataTransfer.Id,
                    partNumber: PartNumber,
                    headerStream: stream,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
            }
        }

        internal async virtual Task SetCheckpointerStatus()
        {
            await _checkpointer.SetJobPartTransferStatusAsync(
                transferId: _dataTransfer.Id,
                partNumber: PartNumber,
                status: JobPartStatus).ConfigureAwait(false);
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

            // TODO: divide up partitions based on how much array pool is left
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

        internal async Task CheckAndUpdateCancellationStateAsync()
        {
            if (JobPartStatus.State == DataTransferState.Pausing ||
                JobPartStatus.State == DataTransferState.Stopping)
            {
                if (!_queueingTasks && _chunkTasks.All((Task task) => (task.IsCompleted)))
                {
                    DataTransferState newState = JobPartStatus.State == DataTransferState.Pausing ?
                        DataTransferState.Paused :
                        DataTransferState.Completed;
                    await OnTransferStateChangedAsync(newState).ConfigureAwait(false);
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
