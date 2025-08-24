// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class TransferJobInternal
    {
        internal delegate Task<JobPartInternal> CreateJobPartAsync(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource);

        internal TransferOperation _transferOperation { get; set; }

        private readonly CreateJobPartAsync _createJobPartAsync;

        /// <summary>
        /// Plan file writer for the respective job
        /// </summary>
        internal ITransferCheckpointer _checkpointer { get; set; }

        /// <summary>
        /// Internal progress tracker for tracking and reporting progress of the transfer
        /// </summary>
        internal TransferProgressTracker _progressTracker;

        /// <summary>
        /// Source resource
        /// </summary>
        internal StorageResourceContainer _sourceResourceContainer;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResourceContainer _destinationResourceContainer;

        /// <summary>
        /// The maximum size to use for each chunk when transferring data in chunks.
        ///
        /// This is the user specified value from options bag.
        /// </summary>
        internal long? _maximumTransferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be Uploaded or Downloaded in a single request. Transfers larger than this
        /// limit will continue being downloaded or uploaded in chunks of size
        /// <see cref="_maximumTransferChunkSize"/>.
        ///
        /// This is the user specified value from options bag.
        /// </summary>
        internal long? _initialTransferSize { get; set; }

        /// <summary>
        /// The error handling options
        /// </summary>
        internal TransferErrorMode _errorMode;

        /// <summary>
        /// Determines how files are created or if they should be overwritten if they already exists
        /// </summary>
        internal StorageResourceCreationMode _creationPreference;

        /// <summary>
        /// Event handler for tracking status changes in job parts.
        /// </summary>
        public event SyncAsyncEventHandler<JobPartStatusEventArgs> JobPartStatusEvents;
        public SyncAsyncEventHandler<JobPartStatusEventArgs> GetJobPartStatusEventHandler() => JobPartStatusEvents;

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
        /// <see cref="StorageResourceCreationMode.SkipIfExists"/>
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

        public CancellationToken _cancellationToken { get; internal set; }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected TransferJobInternal()
        {
        }

        private TransferJobInternal(
            TransferOperation transferOperation,
            CreateJobPartAsync createJobPartAsync,
            ITransferCheckpointer checkPointer,
            TransferErrorMode errorHandling,
            long? initialTransferSize,
            long? maximumTransferChunkSize,
            StorageResourceCreationMode creationPreference,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferItemFailedEventArgs> failedEventHandler,
            SyncAsyncEventHandler<TransferItemSkippedEventArgs> skippedEventHandler,
            SyncAsyncEventHandler<TransferItemCompletedEventArgs> singleTransferEventHandler,
            ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _transferOperation = transferOperation ?? throw Errors.ArgumentNull(nameof(transferOperation));
            _transferOperation.Status.SetTransferStateChange(TransferState.Queued);
            _createJobPartAsync = createJobPartAsync;
            _checkpointer = checkPointer;
            _arrayPool = arrayPool;
            _jobParts = new List<JobPartInternal>();
            _enumerationComplete = false;
            _pendingJobParts = 0;
            _cancellationToken = transferOperation._state.CancellationTokenSource.Token;

            // These options come straight from user-provided options bags and are saved
            // as-is on the job. They may be adjusted with the defaults on job part
            // construction (regular or from checkpoint).
            _initialTransferSize = initialTransferSize;
            _maximumTransferChunkSize = maximumTransferChunkSize;
            _errorMode = errorHandling;
            _creationPreference = creationPreference;

            JobPartStatusEvents += JobPartStatusEventAsync;
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
            TransferOperation transferOperation,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            CreateJobPartAsync createJobPartAsync,
            TransferOptions transferOptions,
            ITransferCheckpointer checkpointer,
            TransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : this(transferOperation,
                  createJobPartAsync,
                  checkpointer,
                  errorHandling,
                  transferOptions.InitialTransferSize,
                  transferOptions.MaximumTransferChunkSize,
                  transferOptions.CreationMode,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed(),
                  transferOptions.GetSkipped(),
                  transferOptions.GetCompleted(),
                  clientDiagnostics)
        {
            _sourceResourceContainer = sourceResource;
            _destinationResourceContainer = destinationResource;
            _progressTracker = new TransferProgressTracker(transferOptions?.ProgressHandlerOptions);
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public virtual async IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync()
        {
            try
            {
                // only change state to 'InProgress' if it was 'Queued'
                // (this is to prevent 'Pausing' to be changed)
                if (_transferOperation.Status.State == TransferState.Queued)
                {
                    await OnJobStateChangedAsync(TransferState.InProgress).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                yield break;
            }

            // Starting brand new job
            if (_jobParts.Count == 0)
            {
                await foreach (JobPartInternal part in EnumerateAndCreateJobPartsAsync().ConfigureAwait(false))
                {
                    yield return part;
                }
            }
            // Resuming old job with existing job parts
            else
            {
                foreach (JobPartInternal part in _jobParts)
                {
                    if (!part.JobPartStatus.HasCompletedSuccessfully)
                    {
                        part.JobPartStatus.SetTransferStateChange(TransferState.Queued);
                        yield return part;
                    }
                }
                DataMovementEventSource.Singleton.ResumeEnumerationComplete(_transferOperation.Id, _jobParts.Count);

                bool isEnumerationComplete;
                try
                {
                    isEnumerationComplete = await _checkpointer.IsEnumerationCompleteAsync(_transferOperation.Id, _cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }

                if (!isEnumerationComplete)
                {
                    await foreach (JobPartInternal jobPartInternal in EnumerateAndCreateJobPartsAsync().ConfigureAwait(false))
                    {
                        yield return jobPartInternal;
                    }
                }
            }

            try
            {
                // Call regardless of the outcome of enumeration so job can pause/finish
                await OnEnumerationCompleteAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        private async IAsyncEnumerable<JobPartInternal> EnumerateAndCreateJobPartsAsync()
        {
            // Start the partNumber based on the last part number. If this is a new job,
            // the count will automatically be at 0 (the beginning).
            int partNumber = _jobParts.Count;
            HashSet<Uri> existingSources = GetJobPartSourceResourcePaths();
            // Call listing operation on the source container
            IAsyncEnumerator<StorageResource> enumerator;

            // Obtain enumerator and check for any point of failure before we attempt to list
            // and fail gracefully.
            try
            {
                enumerator = _sourceResourceContainer.GetStorageResourcesAsync(
                        destinationContainer: _destinationResourceContainer,
                        cancellationToken: _cancellationToken).GetAsyncEnumerator();
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                yield break;
            }

            // List the container in this specific way because MoveNext needs to be separately wrapped
            // in a try/catch as we can't yield return inside a try/catch.
            bool enumerationCompleted = false;
            while (!enumerationCompleted)
            {
                try
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                    if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        await OnAllResourcesEnumeratedAsync().ConfigureAwait(false);
                        enumerationCompleted = true;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }

                StorageResource current = enumerator.Current;

                if (current.IsContainer)
                {
                    // Create sub-container
                    string containerUriPath = _sourceResourceContainer.Uri.GetPath();
                    string subContainerPath = string.IsNullOrEmpty(containerUriPath)
                        ? current.Uri.GetPath()
                        : current.Uri.GetPath().Substring(containerUriPath.Length + 1);
                    // Decode the container name as it was pulled from encoded Uri and will be re-encoded on destination.
                    subContainerPath = Uri.UnescapeDataString(subContainerPath);
                    StorageResourceContainer subContainer =
                        _destinationResourceContainer.GetChildStorageResourceContainer(subContainerPath);

                    try
                    {
                        StorageResourceContainer sourceContainer = (StorageResourceContainer)current;
                        StorageResourceContainerProperties sourceProperties =
                            await sourceContainer.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                        bool overwrite = _creationPreference == StorageResourceCreationMode.OverwriteIfExists;
                        await subContainer.CreateAsync(overwrite, sourceProperties, _cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                        yield break;
                    }
                }
                else
                {
                    if (!existingSources.Contains(current.Uri))
                    {
                        JobPartInternal part;
                        try
                        {
                            string sourceName;
                            // For single item transfers, the container Uri will equal the item Uri.
                            // Set the source name to the full Uri.
                            if (_sourceResourceContainer.Uri == current.Uri)
                            {
                                sourceName = current.Uri.AbsoluteUri;
                            }
                            // Real container trasnfer
                            else
                            {
                                string containerUriPath = _sourceResourceContainer.Uri.GetPath();
                                sourceName = current.Uri.GetPath().Substring(containerUriPath.Length + 1);
                                // Decode the resource name as it was pulled from encoded Uri and will be re-encoded on destination.
                                sourceName = Uri.UnescapeDataString(sourceName);
                            }

                            StorageResourceItem sourceItem = (StorageResourceItem)current;
                            part = await _createJobPartAsync(
                                this,
                                partNumber,
                                sourceItem,
                                _destinationResourceContainer.GetStorageResourceReference(sourceName, sourceItem.ResourceId))
                                .ConfigureAwait(false);
                            AppendJobPart(part);
                        }
                        catch (Exception ex)
                        {
                            await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                            yield break;
                        }
                        yield return part;
                        partNumber++;
                    }
                }
            }
            DataMovementEventSource.Singleton.EnumerationComplete(_transferOperation.Id, _jobParts.Count);
        }

        /// <summary>
        /// Triggers the cancellation for the Job Part.
        ///
        /// If the cancellation token was called to cancelled, change the status to Stopping.
        /// </summary>
        /// <returns>The task to wait until the cancellation has been triggered.</returns>
        public async Task TriggerJobCancellationAsync()
        {
            if (!_transferOperation._state.CancellationTokenSource.IsCancellationRequested)
            {
                await OnJobStateChangedAsync(TransferState.Stopping).ConfigureAwait(false);
                _transferOperation._state.TriggerCancellation();
            }
        }

        /// <summary>
        /// Invokes Failed Argument Event.
        /// </summary>
        /// <param name="ex">The exception which caused the failed argument event to be raised.</param>
        /// <returns></returns>
        public async virtual Task InvokeFailedArgAsync(Exception ex)
        {
            if (ex is not OperationCanceledException &&
                ex is not TaskCanceledException &&
                !ex.Message.Contains("The request was canceled."))
            {
                if (TransferFailedEventHandler != null)
                {
                    await TransferFailedEventHandler.RaiseAsync(
                        new TransferItemFailedEventArgs(
                            _transferOperation.Id,
                            _sourceResourceContainer,
                            _destinationResourceContainer,
                            ex,
                            false,
                            _cancellationToken),
                        nameof(TransferJobInternal),
                        nameof(TransferFailedEventHandler),
                        ClientDiagnostics)
                        .ConfigureAwait(false);
                }
                _transferOperation.Status.SetFailedItem();
            }

            try
            {
                await TriggerJobCancellationAsync().ConfigureAwait(false);

                // If we're failing from a Transfer Job point, it means we have aborted the job
                // at the listing phase. However it's possible that some job parts may be in flight
                // and we have to check if they're finished cleaning up yet.
                await CheckAndUpdateStatusAsync().ConfigureAwait(false);
            }
            catch (Exception cancellationException)
            {
                if (TransferFailedEventHandler != null)
                {
                    await TransferFailedEventHandler.RaiseAsync(
                        new TransferItemFailedEventArgs(
                            _transferOperation.Id,
                            _sourceResourceContainer,
                            _destinationResourceContainer,
                            cancellationException,
                            false,
                            _cancellationToken),
                        nameof(TransferJobInternal),
                        nameof(TransferFailedEventHandler),
                        ClientDiagnostics)
                        .ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// In order to properly propagate the transfer status events of each job part up
        /// until all job parts have completed.
        /// </summary>
        public async Task JobPartStatusEventAsync(JobPartStatusEventArgs args)
        {
            TransferStatus jobPartStatus = args.TransferStatus;
            TransferState jobState = _transferOperation._state.GetTransferStatus().State;

            DataMovementEventSource.Singleton.JobPartStatus(_transferOperation.Id, args.PartNumber, jobPartStatus);

            // Keep track of paused, failed, and skipped which we will use to determine final job status
            // Since this is each Job Part coming in, the state of skipped or failed is mutually exclusive.
            if (jobPartStatus.State == TransferState.Paused)
            {
                _jobPartPaused = true;
            }
            else if (jobPartStatus.HasFailedItems)
            {
                if (_transferOperation._state.SetFailedItemsState())
                {
                    await SetCheckpointerStatusAsync().ConfigureAwait(false);
                    await OnJobPartStatusChangedAsync().ConfigureAwait(false);
                }
            }
            else if (jobPartStatus.HasSkippedItems)
            {
                if (_transferOperation._state.SetSkippedItemsState())
                {
                    await SetCheckpointerStatusAsync().ConfigureAwait(false);
                    await OnJobPartStatusChangedAsync().ConfigureAwait(false);
                }
            }

            // Cancel the entire job if one job part fails and StopOnFailure is set
            if (_errorMode == TransferErrorMode.StopOnAnyFailure &&
                jobPartStatus.HasFailedItems &&
                jobState != TransferState.Stopping &&
                jobState != TransferState.Completed)
            {
                await TriggerJobCancellationAsync().ConfigureAwait(false);
                jobState = _transferOperation._state.GetTransferStatus().State;
            }

            if ((jobPartStatus.State == TransferState.Paused ||
                 jobPartStatus.State == TransferState.Completed)
                && (jobState == TransferState.Queued ||
                    jobState == TransferState.InProgress ||
                    jobState == TransferState.Pausing ||
                    jobState == TransferState.Stopping))
            {
                Interlocked.Decrement(ref _pendingJobParts);

                if (_enumerationComplete)
                {
                    await CheckAndUpdateStatusAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task OnJobStateChangedAsync(TransferState state)
        {
            if (_transferOperation._state.SetTransferState(state))
            {
                // If we are in a final state, dispose the JobPartEvent handlers and complete the progress tracker.
                if (state == TransferState.Completed ||
                    state == TransferState.Paused)
                {
                    if (JobPartStatusEvents != default)
                    {
                        JobPartStatusEvents -= JobPartStatusEventAsync;
                    }
                    // This will block until all pending progress reports have gone out
                    await _progressTracker.TryCompleteAsync().ConfigureAwait(false);
                }

                await OnJobPartStatusChangedAsync().ConfigureAwait(false);
                await SetCheckpointerStatusAsync().ConfigureAwait(false);
            }
        }

        public async Task OnJobPartStatusChangedAsync()
        {
            if (TransferStatusEventHandler != null)
            {
                await TransferStatusEventHandler.RaiseAsync(
                    new TransferStatusEventArgs(
                        transferId: _transferOperation.Id,
                        transferStatus: _transferOperation.Status.DeepCopy(),
                        isRunningSynchronously: false,
                        cancellationToken: _cancellationToken),
                    nameof(TransferJobInternal),
                    nameof(TransferStatusEventHandler),
                    ClientDiagnostics).ConfigureAwait(false);
            }
        }

        internal async virtual Task SetCheckpointerStatusAsync()
        {
            await _checkpointer.SetJobStatusAsync(
                transferId: _transferOperation.Id,
                status: _transferOperation.Status).ConfigureAwait(false);
        }

        /// <summary>
        /// Called when enumeration is complete whether it finished successfully, failed, or was paused.
        /// All resources may or may not have been enumerated.
        /// </summary>
        protected async Task OnEnumerationCompleteAsync()
        {
            _enumerationComplete = true;

            // If there were no job parts enumerated and we haven't already aborted/completed the job.
            if (_jobParts.Count == 0 &&
                _transferOperation.Status.State != TransferState.Paused &&
                _transferOperation.Status.State != TransferState.Completed)
            {
                if (_transferOperation.Status.State == TransferState.Pausing)
                {
                    // If we paused before we were able to list, set the status properly.
                    await OnJobStateChangedAsync(TransferState.Paused).ConfigureAwait(false);
                }
                else
                {
                    await OnJobStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
                }
            }
            await CheckAndUpdateStatusAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Called when all resources have been enumerated successfully.
        /// </summary>
        protected async Task OnAllResourcesEnumeratedAsync()
        {
            await _checkpointer.SetEnumerationCompleteAsync(_transferOperation.Id, _cancellationToken).ConfigureAwait(false);
        }

        internal async Task CheckAndUpdateStatusAsync()
        {
            // If we had a failure or pause during listing, we need to set the status correctly.
            // This is in the case that we weren't able to begin listing any job parts yet.
            if (_jobParts.Count == 0)
            {
                if (_transferOperation.Status.State == TransferState.Pausing)
                {
                    await OnJobStateChangedAsync(TransferState.Paused).ConfigureAwait(false);
                }
                else if (_transferOperation.Status.State == TransferState.Stopping)
                {
                    await OnJobStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
                }
            }
            // If there are no more pending job parts, complete the job
            else if (_pendingJobParts == 0)
            {
                if (_jobPartPaused)
                {
                    await OnJobStateChangedAsync(TransferState.Paused).ConfigureAwait(false);
                }
                else
                {
                    await OnJobStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
                }
            }
        }

        public void AppendJobPart(JobPartInternal jobPart)
        {
            _jobParts.Add(jobPart);

            // Job parts can come from resuming a transfer and therefore may already be complete
            TransferStatus status = jobPart.JobPartStatus;
            if (status.State != TransferState.Completed)
            {
                Interlocked.Increment(ref _pendingJobParts);
            }
        }

        internal HashSet<Uri> GetJobPartSourceResourcePaths()
        {
            return new HashSet<Uri>(_jobParts.Select(x => x._sourceResource.Uri));
        }

        internal async ValueTask IncrementJobParts()
        {
            await _progressTracker.IncrementQueuedFilesAsync(_cancellationToken).ConfigureAwait(false);
        }
    }
}
