// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement;
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
        /// Cancellation Token Source
        ///
        /// Will be initialized when the tasks are running.
        ///
        /// Will be disposed of once all tasks of the job have completed or have been cancelled.
        /// </summary>
        internal CancellationTokenSource _cancellationTokenSource { get; set; }

        /// <summary>
        /// Plan file writer for the respective job
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

        /// <summary>
        /// Transfer Status for the job.
        /// </summary>
        internal StorageTransferStatus _transferStatus;
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

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected TransferJobInternal()
        {
        }

        internal TransferJobInternal(
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
            _errorHandling = errorHandling;
            _createMode = createMode;
            _checkpointer = checkPointer;
            QueueChunkTask = queueChunkTask;
            _transferStatus = StorageTransferStatus.Queued;
            _hasFailures = false;
            _hasSkipped = false;

            _cancellationTokenSource = new CancellationTokenSource();
            _arrayPool = arrayPool;
            _jobParts = new List<JobPartInternal>();
            _enumerationComplete = false;

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
            SingleTransferOptions transferOptions,
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
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            ContainerTransferOptions transferOptions,
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
        /// Pauses all job parts within the job.
        /// </summary>
        public async Task PauseTransferJobAsync()
        {
            TriggerJobCancellation();
            await OnJobStatusChangedAsync(StorageTransferStatus.Paused).ConfigureAwait(false);
        }

        /// <summary>
        /// Resume respective job
        /// </summary>
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential"></param>
        public abstract void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default);

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public abstract IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync();

        public void TriggerJobCancellation()
        {
            DisposeHandlers();
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// In order to properly propagate the transfer status events of each job part up
        /// until all job parts have completed.
        /// </summary>
        public async Task JobPartEvent(TransferStatusEventArgs args)
        {
            if (args.StorageTransferStatus == StorageTransferStatus.Completed
                && _transferStatus < StorageTransferStatus.Completed)
            {
                if (_enumerationComplete)
                {
                    await CheckAndUpdateCompletedStatus().ConfigureAwait(false);
                }
            }
            else if (args.StorageTransferStatus == StorageTransferStatus.Paused &&
                    _transferStatus == StorageTransferStatus.Paused)
            {
                await OnJobStatusChangedAsync(StorageTransferStatus.Paused).ConfigureAwait(false);
            }
            else if (args.StorageTransferStatus > _transferStatus)
            {
                await OnJobStatusChangedAsync(args.StorageTransferStatus).ConfigureAwait(false);
            }
        }

        public async Task OnJobStatusChangedAsync(StorageTransferStatus status)
        {
            bool statusChanged = false;
            lock (_statusLock)
            {
                //TODO: change to RaiseAsync after implementing ClientDiagnostics for TransferManager
                if (_transferStatus != status)
                {
                    statusChanged = true;
                    _transferStatus = status;
                }
                _dataTransfer._state.SetTransferStatus(status);
            }
            if (statusChanged)
            {
                if (TransferStatusEventHandler != null)
                {
                    await TransferStatusEventHandler.Invoke(
                        new TransferStatusEventArgs(
                            transferId: _dataTransfer.Id,
                            transferStatus: status,
                            isRunningSynchronously: false,
                            cancellationToken: _cancellationTokenSource.Token)).ConfigureAwait(false);
                }
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
                    cancellationToken: _cancellationTokenSource.Token)).ConfigureAwait(false);
        }

        internal async Task OnEnumerationComplete()
        {
            if (_jobParts.Count == 0)
            {
                // no files to perform a transfer.
                await OnJobStatusChangedAsync(StorageTransferStatus.Completed).ConfigureAwait(false);
            }
            await CheckAndUpdateCompletedStatus().ConfigureAwait(false);
        }

        internal async Task CheckAndUpdateCompletedStatus()
        {
            // The respective job part has completed, however does not mean we set
            // the entire job to completed.
            if (_jobParts.All((JobPartInternal x) =>
                (x.JobPartStatus == StorageTransferStatus.Completed ||
                 x.JobPartStatus == StorageTransferStatus.CompletedWithFailedTransfers ||
                 x.JobPartStatus == StorageTransferStatus.CompletedWithSkippedTransfers)))
            {
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
        }
    }
}
