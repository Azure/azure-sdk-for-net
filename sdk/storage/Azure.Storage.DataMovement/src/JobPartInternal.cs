// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal abstract class JobPartInternal
    {
        public delegate ValueTask QueueChunkDelegate(Func<Task> item);
        public QueueChunkDelegate QueueChunk { get; internal set; }

        /// <summary>
        /// Part number of the current job part.
        /// </summary>
        public int PartNumber;

        internal TransferOperation _transferOperation { get; set; }

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
        internal ITransferCheckpointer _checkpointer { get; set; }

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
        internal TransferErrorMode _errorHandling;

        /// <summary>
        /// Determines how files are created and overwrite behavior for files that already exists.
        /// </summary>
        internal StorageResourceCreationMode _createMode;

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
        public TransferStatus JobPartStatus { get; set; }

        /// <summary>
        /// Optional. If the length is known, we log it instead of doing a GetProperties call on the
        /// storage resource. The length obtained during a listing call.
        /// </summary>
        internal long? Length;

        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// If the transfer status of the job part changes then the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<JobPartStatusEventArgs> PartTransferStatusEventHandler { get; internal set; }

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

        /// <summary>
        /// Represents the current state of the job part.
        /// </summary>
        private int _currentChunkCount;
        private int _completedChunkCount;
        protected bool _queueingTasks = false;

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        protected JobPartInternal() { }

        internal JobPartInternal(
            TransferOperation transferOperation,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            long? transferChunkSize,
            long? initialTransferSize,
            TransferErrorMode errorHandling,
            StorageResourceCreationMode createMode,
            ITransferCheckpointer checkpointer,
            TransferProgressTracker progressTracker,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<JobPartStatusEventArgs> jobPartEventHandler,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferItemFailedEventArgs> failedEventHandler,
            SyncAsyncEventHandler<TransferItemSkippedEventArgs> skippedEventHandler,
            SyncAsyncEventHandler<TransferItemCompletedEventArgs> singleTransferEventHandler,
            ClientDiagnostics clientDiagnostics,
            CancellationToken cancellationToken,
            TransferStatus jobPartStatus = default,
            long? length = default)
        {
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            // if default is passed, the job part status will be queued
            JobPartStatus = jobPartStatus ?? new TransferStatus();
            PartNumber = partNumber;
            _transferOperation = transferOperation;
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

            // Set transfer sizes to user specified values or default,
            // clamped to max supported chunk size for the destination.
            _initialTransferSize = Math.Min(
                initialTransferSize ?? DataMovementConstants.DefaultInitialTransferSize,
                _destinationResource.MaxSupportedSingleTransferSize);
            _transferChunkSize = Math.Min(
                transferChunkSize ?? DataMovementConstants.DefaultChunkSize,
                _destinationResource.MaxSupportedChunkSize);
            // Set the default create mode
            _createMode = createMode == StorageResourceCreationMode.Default ?
                StorageResourceCreationMode.FailIfExists : createMode;

            Length = length;
            _currentChunkCount = 0;
            _completedChunkCount = 0;
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
            Interlocked.Increment(ref _currentChunkCount);
            await QueueChunk(
                async () =>
                {
                    try
                    {
                        await Task.Run(chunkTask, _cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    }
                    Interlocked.Increment(ref _completedChunkCount);
                    await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
                }).ConfigureAwait(false);
        }

        /// <summary>
        /// Processes the job part to chunks
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public abstract Task ProcessPartToChunkAsync();

        /// <summary>
        /// Disposes of chunk handler.
        /// </summary>
        public abstract Task DisposeHandlersAsync();

        /// <summary>
        /// Triggers the cancellation for the Job Part.
        ///
        /// If the status is set to <see cref="TransferState.Paused"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="TransferState.Pausing"/>
        /// until the chunks finish then it will be set to <see cref="TransferState.Paused"/>.
        ///
        /// If the part status is set to <see cref="TransferState.Completed"/> but has
        /// <see cref="TransferStatus.HasFailedItems"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="TransferState.Stopping"/>
        /// until the chunks finish then it will be set to <see cref="TransferState.Completed"/>.
        /// </summary>
        /// <returns>The task to wait until the cancellation has been triggered.</returns>
        internal async Task TriggerCancellationAsync()
        {
            // Set the status to Pause/CancellationInProgress
            if (TransferState.Pausing == _transferOperation.Status.State)
            {
                // It's possible that the status hasn't propagated down to the job part
                // status yet here since we pause from the data transfer object.
                await OnTransferStateChangedAsync(TransferState.Pausing).ConfigureAwait(false);
            }
            else
            {
                // It's a cancellation if a pause wasn't called.
                await OnTransferStateChangedAsync(TransferState.Stopping).ConfigureAwait(false);
            }
            await CleanupAbortedJobPartAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferState"></param>
        internal async Task OnTransferStateChangedAsync(TransferState transferState)
        {
            if (JobPartStatus.SetTransferStateChange(transferState))
            {
                // Progress tracking, do before invoking the event below
                if (transferState == TransferState.InProgress)
                {
                    await _progressTracker.IncrementInProgressFilesAsync(_cancellationToken).ConfigureAwait(false);
                }
                else if (JobPartStatus.HasCompletedSuccessfully)
                {
                    await _progressTracker.IncrementCompletedFilesAsync(_cancellationToken).ConfigureAwait(false);
                    await InvokeSingleCompletedArgAsync().ConfigureAwait(false);
                }

                // Set the status in the checkpointer
                await SetCheckpointerStatusAsync().ConfigureAwait(false);

                await PartTransferStatusEventHandler.RaiseAsync(
                    new JobPartStatusEventArgs(
                        _transferOperation.Id,
                        PartNumber,
                        JobPartStatus.DeepCopy(),
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(PartTransferStatusEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
        }

        protected async ValueTask ReportBytesWrittenAsync(long bytesTransferred)
        {
            await _progressTracker.IncrementBytesTransferredAsync(bytesTransferred, _cancellationToken).ConfigureAwait(false);
        }

        public async virtual Task InvokeSingleCompletedArgAsync()
        {
            if (SingleTransferCompletedEventHandler != null)
            {
                await SingleTransferCompletedEventHandler.RaiseAsync(
                    new TransferItemCompletedEventArgs(
                        _transferOperation.Id,
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
        public async virtual Task InvokeSkippedArgAsync()
        {
            if (TransferSkippedEventHandler != null)
            {
                // TODO: change to RaiseAsync
                await TransferSkippedEventHandler.RaiseAsync(
                    new TransferItemSkippedEventArgs(
                        _transferOperation.Id,
                        _sourceResource,
                        _destinationResource,
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(TransferSkippedEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
            await _progressTracker.IncrementSkippedFilesAsync(_cancellationToken).ConfigureAwait(false);

            // Update the JobPartStatus. If was already updated (e.g. there was a failed item before)
            // then don't raise the PartTransferStatusEventHandler
            if (JobPartStatus.SetSkippedItem())
            {
                await PartTransferStatusEventHandler.RaiseAsync(
                    new JobPartStatusEventArgs(
                        _transferOperation.Id,
                        PartNumber,
                        JobPartStatus.DeepCopy(),
                        false,
                        _cancellationToken),
                    nameof(JobPartInternal),
                    nameof(PartTransferStatusEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
            }
            //TODO: figure out why we set the Completed state here and not just wait for all the chunks to finish
            await DisposeHandlersAsync().ConfigureAwait(false);
            await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes Failed Argument Event.
        /// </summary>
        public async virtual Task InvokeFailedArgAsync(Exception ex)
        {
            if (ex is not OperationCanceledException &&
                ex is not TaskCanceledException &&
                ex is not ChannelClosedException &&
                ex.InnerException is not TaskCanceledException &&
                !ex.Message.Contains("The request was canceled."))
            {
                if (ex is RequestFailedException requestFailedException)
                {
                    SetFailureType(requestFailedException.ErrorCode);
                }
                else
                {
                    SetFailureType(ex.Message);
                }
                if (TransferFailedEventHandler != null)
                {
                    await TransferFailedEventHandler.RaiseAsync(
                        new TransferItemFailedEventArgs(
                            _transferOperation.Id,
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
                await _progressTracker.IncrementFailedFilesAsync(_cancellationToken).ConfigureAwait(false);

                // Update the JobPartStatus. If was already updated (e.g. there was a failed item before)
                // then don't raise the PartTransferStatusEventHandler
                if (JobPartStatus.SetFailedItem())
                {
                    await PartTransferStatusEventHandler.RaiseAsync(
                        new JobPartStatusEventArgs(
                            _transferOperation.Id,
                            PartNumber,
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
                if (JobPartStatus.State != TransferState.Pausing &&
                    JobPartStatus.State != TransferState.Stopping)
                {
                    await TriggerCancellationAsync().ConfigureAwait(false);
                }
            }
            catch (Exception cancellationException)
            {
                // If an exception is thrown while trying to clean up,
                // raise the failed event and prevent the transfer from hanging
                await TransferFailedEventHandler.RaiseAsync(
                    new TransferItemFailedEventArgs(
                        _transferOperation.Id,
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

            // Whether or not we were able to trigger the cancellation and successfully clean up
            // we should always call CheckAndUpdateCancellationStateAsync to correctly make
            // sure the job part is in the correct state.
            try
            {
                await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
            }
            catch (Exception checkUpdateException)
            {
                // If an exception is thrown while trying to clean up,
                // raise the failed event and prevent the transfer from hanging
                await TransferFailedEventHandler.RaiseAsync(
                    new TransferItemFailedEventArgs(
                        _transferOperation.Id,
                        _sourceResource,
                        _destinationResource,
                        checkUpdateException,
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
            // If a Pause was called, we can remove the unfinished file.
            if (JobPartFailureType.Other == _failureType || TransferState.Pausing == JobPartStatus.State)
            {
                // If the job part is paused or ended with failures
                // delete the destination resource because it could be unfinished or corrupted
                // If we resume we would have to start from the beginning anyways.
                try
                {
                    // We can't pass the cancellation token
                    // here due to the fact that the job's cancellation token has already been called.
                    // We are cleaning up / deleting optimistically, which means that if
                    // the clean / delete attempt fails, then we continue on. The failure may be due
                    // to the overall reason why the job was cancelled in the first place.
                    await _destinationResource.DeleteIfExistsAsync().ConfigureAwait(false);
                }
                catch
                {
                    // We are cleaning up / deleting optimistically, move on if it fails.
                }
            }
        }

        /// <summary>
        /// Serializes the respective job part and adds it to the checkpointer.
        /// </summary>
        public async virtual Task AddJobPartToCheckpointerAsync()
        {
            await _checkpointer.AddNewJobPartAsync(
                transferId: _transferOperation.Id,
                partNumber: PartNumber,
                header: this.ToJobPartPlanHeader(),
                cancellationToken: _cancellationToken).ConfigureAwait(false);
        }

        internal async virtual Task SetCheckpointerStatusAsync()
        {
            await _checkpointer.SetJobPartStatusAsync(
                transferId: _transferOperation.Id,
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

        protected static IEnumerable<(long Offset, long Length)> GetRanges(
            long streamLength, // StreamLength needed to divide before hand
            long blockSize,
            int maxBlockCount)
        {
            // Destination may have a max block count
            // block size * block count limit = max data length to upload
            // if stream length is longer than specified max block size allows, can't upload
            long minRequiredBlockSize = (long)Math.Ceiling((double)streamLength / maxBlockCount);
            if (blockSize < minRequiredBlockSize)
            {
                throw Errors.InsufficientStorageTransferOptions(streamLength, blockSize, minRequiredBlockSize);
            }

            // Start the position at the first block size since the first block has potentially
            // been already staged.
            long absolutePosition = blockSize;
            long blockLength;

            // TODO: divide up partitions based on how much array pool is left
            while (absolutePosition < streamLength)
            {
                // Return based on the size of the stream divided up by the acceptable blocksize.
                blockLength = (absolutePosition + blockSize < streamLength) ?
                    blockSize :
                    streamLength - absolutePosition;
                yield return (absolutePosition, blockLength);
                absolutePosition += blockLength;
            }
        }

        internal async Task CheckAndUpdateCancellationStateAsync()
        {
            if (JobPartStatus.State == TransferState.Pausing ||
                JobPartStatus.State == TransferState.Stopping)
            {
                if (!_queueingTasks && _currentChunkCount == _completedChunkCount)
                {
                    TransferState newState = JobPartStatus.State == TransferState.Pausing ?
                        TransferState.Paused :
                        TransferState.Completed;
                    await DisposeHandlersAsync().ConfigureAwait(false);
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

        internal async Task<bool> CheckTransferStateBeforeRunning()
        {
            // If the main transfer has been stopped, do not process this part.
            if (_transferOperation.Status.State == TransferState.Pausing)
            {
                await OnTransferStateChangedAsync(TransferState.Paused).ConfigureAwait(false);
                return false;
            }
            else if (_transferOperation.Status.State == TransferState.Stopping)
            {
                await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
                return false;
            }
            return true;
        }
    }
}
