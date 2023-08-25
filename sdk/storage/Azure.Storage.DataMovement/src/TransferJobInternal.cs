// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

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
        internal StorageResourceItem _sourceResource;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResourceItem _destinationResource;

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
        internal DataTransferErrorMode _errorMode;

        /// <summary>
        /// Determines how files are created or if they should be overwritten if they already exists
        /// </summary>
        internal StorageResourceCreationPreference _creationPreference;

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
        public SyncAsyncEventHandler<TransferItemFailedEventArgs> TransferFailedEventHandler { get; internal set; }

        /// <summary>
        /// Number of single transfers skipped during Transfer due to no overwrite allowed as specified in
        /// <see cref="StorageResourceCreationPreference.SkipIfExists"/>
        /// </summary>
        public SyncAsyncEventHandler<TransferItemSkippedEventArgs> TransferSkippedEventHandler { get; internal set; }

        /// <summary>
        /// If a single transfer within the resource container gets transferred successfully the event
        /// will get added to this handler
        /// </summary>
        public SyncAsyncEventHandler<TransferItemCompletedEventArgs> TransferItemCompletedEventHandler { get; internal set; }

        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        public List<JobPartInternal> _jobParts;
        internal bool _enumerationComplete;
        private int _pendingJobParts;
        private bool _jobPartPaused;
        private bool _jobPartFailed;
        private bool _jobPartSkipped;

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
            DataTransferErrorMode errorHandling,
            StorageResourceCreationPreference creationPreference,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferItemFailedEventArgs> failedEventHandler,
            SyncAsyncEventHandler<TransferItemSkippedEventArgs> skippedEventHandler,
            SyncAsyncEventHandler<TransferItemCompletedEventArgs> singleTransferEventHandler,
            ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _dataTransfer = dataTransfer ?? throw Errors.ArgumentNull(nameof(dataTransfer));
            _dataTransfer._state.TrySetTransferStatus(DataTransferStatus.Queued);
            _errorMode = errorHandling;
            _checkpointer = checkPointer;
            _creationPreference = creationPreference;
            QueueChunkTask = queueChunkTask;
            _hasFailures = false;
            _hasSkipped = false;
            _arrayPool = arrayPool;
            _jobParts = new List<JobPartInternal>();
            _enumerationComplete = false;
            _pendingJobParts = 0;
            _cancellationToken = dataTransfer._state.CancellationTokenSource.Token;

            JobPartStatusEvents += JobPartEvent;
            TransferStatusEventHandler = statusEventHandler;
            TransferFailedEventHandler = failedEventHandler;
            TransferSkippedEventHandler = skippedEventHandler;
            TransferItemCompletedEventHandler = singleTransferEventHandler;
            ClientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : this(dataTransfer,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  transferOptions.CreationPreference,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed(),
                  transferOptions.GetSkipped(),
                  default,
                  clientDiagnostics)
        {
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _isSingleResource = true;
            _initialTransferSize = transferOptions?.InitialTransferSize;
            _maximumTransferChunkSize = transferOptions?.MaximumTransferChunkSize;
            _progressTracker = new TransferProgressTracker(transferOptions?.ProgressHandlerOptions);
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            DataTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : this(dataTransfer,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  transferOptions.CreationPreference,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed(),
                  transferOptions.GetSkipped(),
                  transferOptions.GetCompleted(),
                  clientDiagnostics)
        {
            _sourceResourceContainer = sourceResource;
            _destinationResourceContainer = destinationResource;
            _isSingleResource = false;
            _initialTransferSize = transferOptions?.InitialTransferSize;
            _maximumTransferChunkSize = transferOptions?.MaximumTransferChunkSize;
            _progressTracker = new TransferProgressTracker(transferOptions?.ProgressHandlerOptions);
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
        /// If the status is set to <see cref="DataTransferStatus.Paused"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="DataTransferStatus.PauseInProgress"/>
        /// until the chunks finish then it will be set to <see cref="DataTransferStatus.Paused"/>.
        ///
        /// If the status is set to <see cref="DataTransferStatus.CompletedWithFailedTransfers"/>
        /// and any chunks is still processing to be cancelled is will be set to <see cref="DataTransferStatus.CancellationInProgress"/>
        /// until the chunks finish then it will be set to <see cref="DataTransferStatus.CompletedWithFailedTransfers"/>.
        /// </summary>
        /// <returns>The task to wait until the cancellation has been triggered.</returns>
        public async Task TriggerJobCancellationAsync()
        {
            if (!_dataTransfer._state.CancellationTokenSource.IsCancellationRequested)
            {
                await OnJobStatusChangedAsync(DataTransferStatus.CancellationInProgress).ConfigureAwait(false);
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
                    await TransferFailedEventHandler.RaiseAsync(
                        new TransferItemFailedEventArgs(
                            _dataTransfer.Id,
                            _sourceResource,
                            _destinationResource,
                            ex,
                            false,
                            _cancellationToken),
                        nameof(TransferJobInternal),
                        nameof(TransferFailedEventHandler),
                        ClientDiagnostics)
                        .ConfigureAwait(false);
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
            DataTransferStatus jobPartStatus = args.StorageTransferStatus;
            DataTransferStatus jobStatus = _dataTransfer._state.GetTransferStatus();

            // Keep track of paused, failed, and skipped which we will use to determine final job status
            if (jobPartStatus == DataTransferStatus.Paused)
            {
                _jobPartPaused = true;
            }
            else if (jobPartStatus == DataTransferStatus.CompletedWithFailedTransfers)
            {
                _jobPartFailed = true;
            }
            else if (jobPartStatus == DataTransferStatus.CompletedWithSkippedTransfers)
            {
                _jobPartSkipped = true;
            }

            // Cancel the entire job if one job part fails and StopOnFailure is set
            if (_errorMode == DataTransferErrorMode.StopOnAnyFailure &&
                jobPartStatus == DataTransferStatus.CompletedWithFailedTransfers &&
                jobStatus != DataTransferStatus.CancellationInProgress &&
                jobStatus != DataTransferStatus.CompletedWithFailedTransfers &&
                jobStatus != DataTransferStatus.CompletedWithSkippedTransfers &&
                jobStatus != DataTransferStatus.Completed)
            {
                await TriggerJobCancellationAsync().ConfigureAwait(false);
                jobStatus = _dataTransfer._state.GetTransferStatus();
            }

            if ((jobPartStatus == DataTransferStatus.Paused ||
                 jobPartStatus == DataTransferStatus.Completed ||
                 jobPartStatus == DataTransferStatus.CompletedWithSkippedTransfers ||
                 jobPartStatus == DataTransferStatus.CompletedWithFailedTransfers)
                && (jobStatus == DataTransferStatus.Queued ||
                    jobStatus == DataTransferStatus.InProgress ||
                    jobStatus == DataTransferStatus.PauseInProgress ||
                    jobStatus == DataTransferStatus.CancellationInProgress))
            {
                Interlocked.Decrement(ref _pendingJobParts);

                if (_enumerationComplete)
                {
                    await CheckAndUpdateStatusAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task OnJobStatusChangedAsync(DataTransferStatus status)
        {
            bool statusChanged = false;
            lock (_statusLock)
            {
                statusChanged = _dataTransfer._state.TrySetTransferStatus(status);
            }
            if (statusChanged)
            {
                // If we are in a final state, dispose the JobPartEvent handlers
                if (status == DataTransferStatus.Completed ||
                    status == DataTransferStatus.CompletedWithSkippedTransfers ||
                    status == DataTransferStatus.CompletedWithFailedTransfers ||
                    status == DataTransferStatus.Paused)
                {
                    DisposeHandlers();
                }

                if (TransferStatusEventHandler != null)
                {
                    await TransferStatusEventHandler.RaiseAsync(
                        new TransferStatusEventArgs(
                            transferId: _dataTransfer.Id,
                            transferStatus: status,
                            isRunningSynchronously: false,
                            cancellationToken: _cancellationToken),
                        nameof(TransferJobInternal),
                        nameof(TransferStatusEventHandler),
                        ClientDiagnostics).ConfigureAwait(false);
                }
                await SetCheckpointerStatus(status).ConfigureAwait(false);
            }
        }

        public async Task OnJobPartStatusChangedAsync(DataTransferStatus status)
        {
            //TODO: change to RaiseAsync after implementing ClientDiagnostics for TransferManager
            await JobPartStatusEvents.RaiseAsync(
                new TransferStatusEventArgs(
                    transferId: _dataTransfer.Id,
                    transferStatus: status,
                    isRunningSynchronously: false,
                    cancellationToken: _cancellationToken),
                nameof(TransferJobInternal),
                nameof(JobPartStatusEvents),
                ClientDiagnostics)
                .ConfigureAwait(false);
        }

        internal async virtual Task SetCheckpointerStatus(DataTransferStatus status)
        {
            await _checkpointer.SetJobTransferStatusAsync(
                transferId: _dataTransfer.Id,
                status: status).ConfigureAwait(false);
        }

        internal async Task OnEnumerationComplete()
        {
            // If there were no job parts enumerated and we haven't already aborted/completed the job.
            if (_jobParts.Count == 0 &&
                _dataTransfer.TransferStatus != DataTransferStatus.Paused &&
                _dataTransfer.TransferStatus != DataTransferStatus.CompletedWithSkippedTransfers &&
                _dataTransfer.TransferStatus != DataTransferStatus.CompletedWithFailedTransfers &&
                _dataTransfer.TransferStatus != DataTransferStatus.Completed)
            {
                if (_dataTransfer.TransferStatus == DataTransferStatus.PauseInProgress)
                {
                    // If we paused before we were able to list, set the status properly.
                    await OnJobStatusChangedAsync(DataTransferStatus.Paused).ConfigureAwait(false);
                }
                else if (_dataTransfer.TransferStatus == DataTransferStatus.CancellationInProgress)
                {
                    // If we aborted before we were able to list, set the status properly.
                    await OnJobStatusChangedAsync(DataTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
                else
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.Completed).ConfigureAwait(false);
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
                if (_dataTransfer.TransferStatus == DataTransferStatus.PauseInProgress)
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.Paused).ConfigureAwait(false);
                }
                else if (_dataTransfer.TransferStatus == DataTransferStatus.CancellationInProgress)
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
                return;
            }

            // If there are no more pending job parts, complete the job
            if (_pendingJobParts == 0)
            {
                if (_jobPartPaused)
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.Paused).ConfigureAwait(false);
                }
                else if (_jobPartFailed)
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.CompletedWithFailedTransfers).ConfigureAwait(false);
                }
                else if (_jobPartSkipped)
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.CompletedWithSkippedTransfers).ConfigureAwait(false);
                }
                else
                {
                    await OnJobStatusChangedAsync(DataTransferStatus.Completed).ConfigureAwait(false);
                }
            }
        }

        public void AppendJobPart(JobPartInternal jobPart)
        {
            _jobParts.Add(jobPart);

            // Job parts can come from resuming a transfer and therefore may already be complete
            DataTransferStatus status = jobPart.JobPartStatus;
            if (status != DataTransferStatus.CompletedWithSkippedTransfers &&
                status != DataTransferStatus.CompletedWithFailedTransfers &&
                status != DataTransferStatus.Completed)
            {
                Interlocked.Increment(ref _pendingJobParts);
            }
        }

        internal List<string> GetJobPartSourceResourcePaths()
        {
            return _jobParts.Select( x => x._sourceResource.Uri.GetPath() ).ToList();
        }

        internal void QueueJobPart()
        {
            _progressTracker.IncrementQueuedFiles();
        }
    }
}
