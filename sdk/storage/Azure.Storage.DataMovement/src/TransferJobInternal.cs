// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal abstract class TransferJobInternal : IDisposable
    {
        #region Delegates
        public delegate Task QueueChunkTaskInternal(Func<Task> uploadTask);
        #endregion
        public QueueChunkTaskInternal QueueChunkTask { get; internal set; }

        /// <summary>
        /// DataTransfer communicate when the transfer has finished and the progress
        /// </summary>
        internal DataTransfer _dataTransfer { get; set; }

        /// <summary>
        /// Plan file writer for the respective job
        /// </summary>
        internal TransferCheckpointer _checkpointer { get; set; }

        /// <summary>
        /// Internal progress tracker for tracking and reporting progress of the transfer
        /// </summary>
        internal TransferProgressTracker _progressTracker;

        /// <summary>
        /// Source resource
        /// </summary>
        internal StorageResource _sourceResource;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResource _destinationResource;

        /// <summary>
        /// Source resource
        /// </summary>
        internal StorageResourceContainer _sourceResourceContainer;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResourceContainer _destinationResourceContainer;

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
        internal long? _initialTransferSize { get; set; }

        /// <summary>
        /// Defines whether the transfer will be only a single transfer, or
        /// a container transfer
        /// </summary>
        internal bool _isSingleResource;

        /// <summary>
        /// The error handling options
        /// </summary>
        internal ErrorHandlingOptions _errorHandling;

        /// <summary>
        /// Determines how files are created or if they should be overwritten if they already exists
        /// </summary>
        internal StorageResourceCreateMode _createMode;

        private object _statusLock = new object();

        /// <summary>
        /// To help set the job status when all job parts have completed.
        /// </summary>
        internal bool _hasFailures;
        internal bool _hasSkipped;

        /// <summary>
        /// Considering if there's more than one job part, the transfer status will need to be set to
        /// completed all job parts have been set to completed.
        /// </summary>
        public event SyncAsyncEventHandler<TransferStatusEventArgs> JobPartStatusEvents;
        public SyncAsyncEventHandler<TransferStatusEventArgs> GetJobPartStatus() => JobPartStatusEvents;

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatusEventHandler { get; internal set; }

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferFailedEventArgs> TransferFailedEventHandler { get; internal set; }

        /// <summary>
        /// Number of single transfers skipped during Transfer due to no overwrite allowed as specified in
        /// <see cref="StorageResourceCreateMode.Skip"/>
        /// </summary>
        public SyncAsyncEventHandler<TransferSkippedEventArgs> TransferSkippedEventHandler { get; internal set; }

        /// <summary>
        /// If a single transfer within the resource contianer gets transferred successfully the event
        /// will get added to this handler
        /// </summary>
        public SyncAsyncEventHandler<SingleTransferCompletedEventArgs> SingleTransferCompletedEventHandler { get; internal set; }

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        public List<JobPartInternal> _jobParts;
        internal bool _enumerationComplete;

        public CancellationToken _cancellationToken { get; internal set; }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected TransferJobInternal()
        {
        }

        private TransferJobInternal(
            DataTransfer dataTransfer,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkPointer,
            ErrorHandlingOptions errorHandling,
            StorageResourceCreateMode createMode,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferFailedEventArgs> failedEventHandler,
            SyncAsyncEventHandler<TransferSkippedEventArgs> skippedEventHandler,
            SyncAsyncEventHandler<SingleTransferCompletedEventArgs> singleTransferEventHandler)
        {
            _dataTransfer = dataTransfer ?? throw Errors.ArgumentNull(nameof(dataTransfer));
            _dataTransfer._state.TrySetTransferStatus(StorageTransferStatus.Queued);
            _errorHandling = errorHandling;
            _createMode = createMode == StorageResourceCreateMode.None ? StorageResourceCreateMode.Fail : createMode;
            _checkpointer = checkPointer;
            QueueChunkTask = queueChunkTask;
            _hasFailures = false;
            _hasSkipped = false;
            _arrayPool = arrayPool;
            _jobParts = new List<JobPartInternal>();
            _enumerationComplete = false;
            _cancellationToken = dataTransfer._state.CancellationTokenSource.Token;

            JobPartStatusEvents += JobPartEvent;
            TransferStatusEventHandler = statusEventHandler;
            TransferFailedEventHandler = failedEventHandler;
            TransferSkippedEventHandler = skippedEventHandler;
            SingleTransferCompletedEventHandler = singleTransferEventHandler;
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            TransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : this(dataTransfer,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  transferOptions.CreateMode,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed(),
                  transferOptions.GetSkipped(),
                  default)
        {
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _isSingleResource = true;
            _initialTransferSize = transferOptions?.InitialTransferSize;
            _maximumTransferChunkSize = transferOptions?.MaximumTransferChunkSize;
            _progressTracker = new TransferProgressTracker(transferOptions?.ProgressHandler, transferOptions?.ProgressHandlerOptions);
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            TransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : this(dataTransfer,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  transferOptions.CreateMode,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed(),
                  transferOptions.GetSkipped(),
                  transferOptions.GetCompleted())
        {
            _sourceResourceContainer = sourceResource;
            _destinationResourceContainer = destinationResource;
            _isSingleResource = false;
            _initialTransferSize = transferOptions?.InitialTransferSize;
            _maximumTransferChunkSize = transferOptions?.MaximumTransferChunkSize;
            _progressTracker = new TransferProgressTracker(transferOptions?.ProgressHandler, transferOptions?.ProgressHandlerOptions);
        }

        public void Dispose()
        {
            DisposeHandlers();
        }

        public void DisposeHandlers()
        {
            if (JobPartStatusEvents != default)
            {
                JobPartStatusEvents -= JobPartEvent;
            }
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public abstract IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync();

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
        public async Task TriggerJobCancellationAsync()
        {
            if (!_dataTransfer._state.CancellationTokenSource.IsCancellationRequested)
            {
                await OnJobStatusChangedAsync(StorageTransferStatus.CancellationInProgress).ConfigureAwait(false);
                _dataTransfer._state.TriggerCancellation();
            }
        }

        /// <summary>
        /// Invokes Failed Argument Event.
        /// </summary>
        /// <param name="ex">The exception which caused the failed argument event to be raised.</param>
        /// <returns></returns>
        public async virtual Task InvokeFailedArgAsync(Exception ex)
        {
            if (ex is not OperationCanceledException)
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
                        _cancellationToken)).ConfigureAwait(false);
                }
            }
            // Trigger job cancellation if the failed handler is enabled
            await TriggerJobCancellationAsync().ConfigureAwait(false);

            // If we're failing from a Transfer Job point, it means we have aborted the job
            // at the listing phase. However it's possible that some job parts may be in flight
            // and we have to check if they're finished cleaning up yet.
            await CheckAndUpdateStatusAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// In order to properly propagate the transfer status events of each job part up
        /// until all job parts have completed.
        /// </summary>
        public async Task JobPartEvent(TransferStatusEventArgs args)
        {
            // NOTE: There is a chance this event can be triggered after the transfer has
            // completed if more job parts complete before the next instance of this event is handled.

            StorageTransferStatus jobPartStatus = args.StorageTransferStatus;
            StorageTransferStatus jobStatus = _dataTransfer._state.GetTransferStatus();

            // Cancel the entire job if one job part fails and StopOnFailure is set
            if (_errorHandling == ErrorHandlingOptions.StopOnAllFailures &&
                jobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers &&
                jobStatus != StorageTransferStatus.CancellationInProgress &&
                jobStatus != StorageTransferStatus.CompletedWithFailedTransfers &&
                jobStatus != StorageTransferStatus.CompletedWithSkippedTransfers &&
                jobStatus != StorageTransferStatus.Completed)
            {
                await TriggerJobCancellationAsync().ConfigureAwait(false);
                jobStatus = _dataTransfer._state.GetTransferStatus();
            }

            if ((jobPartStatus == StorageTransferStatus.Paused ||
                 jobPartStatus == StorageTransferStatus.Completed ||
                 jobPartStatus == StorageTransferStatus.CompletedWithSkippedTransfers ||
                 jobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers)
                && (jobStatus == StorageTransferStatus.Queued ||
                    jobStatus == StorageTransferStatus.InProgress ||
                    jobStatus == StorageTransferStatus.PauseInProgress ||
                    jobStatus == StorageTransferStatus.CancellationInProgress))
            {
                if (_enumerationComplete)
                {
                    await CheckAndUpdateStatusAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task OnJobStatusChangedAsync(StorageTransferStatus status)
        {
            bool statusChanged = false;
            lock (_statusLock)
            {
                statusChanged = _dataTransfer._state.TrySetTransferStatus(status);
            }
            if (statusChanged)
            {
                // If we are in a final state, dispose the JobPartEvent handlers
                if (status == StorageTransferStatus.Completed ||
                    status == StorageTransferStatus.CompletedWithSkippedTransfers ||
                    status == StorageTransferStatus.CompletedWithFailedTransfers ||
                    status == StorageTransferStatus.Paused)
                {
                    DisposeHandlers();
                }

                if (TransferStatusEventHandler != null)
                {
                    await TransferStatusEventHandler.Invoke(
                        new TransferStatusEventArgs(
                            transferId: _dataTransfer.Id,
                            transferStatus: status,
                            isRunningSynchronously: false,
                            cancellationToken: _cancellationToken)).ConfigureAwait(false);
                }
                await SetCheckpointerStatus(status).ConfigureAwait(false);
            }
        }

        public async Task OnJobPartStatusChangedAsync(StorageTransferStatus status)
        {
            //TODO: change to RaiseAsync after implementing ClientDiagnostics for TransferManager
            await JobPartStatusEvents.Invoke(
                new TransferStatusEventArgs(
                    transferId: _dataTransfer.Id,
                    transferStatus: status,
                    isRunningSynchronously: false,
                    cancellationToken: _cancellationToken)).ConfigureAwait(false);
        }

        internal async virtual Task SetCheckpointerStatus(StorageTransferStatus status)
        {
            await _checkpointer.SetJobTransferStatusAsync(
                transferId: _dataTransfer.Id,
                status: status).ConfigureAwait(false);
        }

        internal async Task OnEnumerationComplete()
        {
            // If there were no job parts enumerated and we haven't already aborted/completed the job.
            if (_jobParts.Count == 0 &&
                _dataTransfer.TransferStatus != StorageTransferStatus.Paused &&
                _dataTransfer.TransferStatus != StorageTransferStatus.CompletedWithSkippedTransfers &&
                _dataTransfer.TransferStatus != StorageTransferStatus.CompletedWithFailedTransfers &&
                _dataTransfer.TransferStatus != StorageTransferStatus.Completed)
            {
                if (_dataTransfer.TransferStatus == StorageTransferStatus.PauseInProgress)
                {
                    // If we paused before we were able to list, set the status properly.
                    await OnJobStatusChangedAsync(StorageTransferStatus.Paused).ConfigureAwait(false);
                }
                else if (_dataTransfer.TransferStatus == StorageTransferStatus.CancellationInProgress)
                {
                    // If we aborted before we were able to list, set the status properly.
                    await OnJobStatusChangedAsync(StorageTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
                else
                {
                    await OnJobStatusChangedAsync(StorageTransferStatus.Completed).ConfigureAwait(false);
                }
            }
            await CheckAndUpdateStatusAsync().ConfigureAwait(false);
        }

        internal async Task CheckAndUpdateStatusAsync()
        {
            // If we had a failure or pause during listing, we need to set the status correctly.
            // This is in the case that we weren't able to begin listing any job parts yet.
            if (_jobParts.Count == 0)
            {
                if (_dataTransfer.TransferStatus == StorageTransferStatus.PauseInProgress)
                {
                    await OnJobStatusChangedAsync(StorageTransferStatus.Paused).ConfigureAwait(false);
                }
                else if (_dataTransfer.TransferStatus == StorageTransferStatus.CancellationInProgress)
                {
                    await OnJobStatusChangedAsync(StorageTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
            }
            // If we have any job parts
            else if (_jobParts.All((JobPartInternal x) =>
                (x.JobPartStatus == StorageTransferStatus.Completed ||
                 x.JobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers ||
                 x.JobPartStatus == StorageTransferStatus.CompletedWithSkippedTransfers)))
            {
                // The respective job part has completed, however does not mean we set
                // the entire job to completed.
                if (_jobParts.Any((JobPartInternal x) =>
                    x.JobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers))
                {
                    await OnJobStatusChangedAsync(StorageTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
                else if (_jobParts.Any((JobPartInternal x) =>
                    x.JobPartStatus == StorageTransferStatus.CompletedWithSkippedTransfers))
                {
                    await OnJobStatusChangedAsync(StorageTransferStatus.CompletedWithSkippedTransfers).ConfigureAwait(false);
                }
                else
                {
                    await OnJobStatusChangedAsync(StorageTransferStatus.Completed).ConfigureAwait(false);
                }
            }
            else if (_jobParts.All((JobPartInternal x) =>
                (x.JobPartStatus == StorageTransferStatus.Paused ||
                 x.JobPartStatus == StorageTransferStatus.Completed ||
                 x.JobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers ||
                 x.JobPartStatus == StorageTransferStatus.CompletedWithSkippedTransfers)))
            {
                // We only set the status to Paused if all the job parts have all been paused or
                // have already completed.
                await OnJobStatusChangedAsync(StorageTransferStatus.Paused).ConfigureAwait(false);
            }
        }

        public void AppendJobPart(JobPartInternal jobPart)
        {
            _jobParts.Add(jobPart);
        }

        internal List<string> GetJobPartSourceResourcePaths()
        {
            return _jobParts.Select( x => x._sourceResource.Path ).ToList();
        }

        internal void QueueJobPart()
        {
            _progressTracker.IncrementQueuedFiles();
        }
    }
}
