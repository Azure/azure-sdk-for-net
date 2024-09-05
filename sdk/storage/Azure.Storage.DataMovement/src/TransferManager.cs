// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The main class for starting and controlling all types of transfers.
    /// </summary>
    public class TransferManager : IAsyncDisposable
    {
        private readonly IProcessor<TransferJobInternal> _jobsProcessor;
        private readonly IProcessor<JobPartInternal> _partsProcessor;
        private readonly IProcessor<Func<Task>> _chunksProcessor;

        /// <summary>
        /// Ongoing transfers indexed at the transfer id.
        /// </summary>
        internal readonly Dictionary<string, DataTransfer> _dataTransfers = new();

        /// <summary>
        /// Designated checkpointer for the respective transfer manager.
        ///
        /// If unspecified will default to LocalTransferCheckpointer at {currentpath}/.azstoragedml
        /// </summary>
        internal TransferCheckpointer _checkpointer;

        internal readonly List<StorageResourceProvider> _resumeProviders;

        /// <summary>
        /// Defines the error handling method to follow when an error is seen. Defaults to
        /// <see cref="DataTransferErrorMode.StopOnAnyFailure"/>.
        ///
        /// See <see cref="DataTransferErrorMode"/>.
        /// </summary>
        internal DataTransferErrorMode _errorHandling;

        /// <summary>
        /// Cancels the channels operations when disposing.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = new();
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        private readonly ArrayPool<byte> _arrayPool;

        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected TransferManager()
        { }

        /// <summary>
        /// Constructor to create a TransferManager.
        /// </summary>
        /// <param name="options">Options that will apply to all transfers started by this TransferManager.</param>
        public TransferManager(TransferManagerOptions options = default)
        {
            _jobsProcessor = ChannelProcessing.NewProcessor<TransferJobInternal>(parallelism: 1);
            _partsProcessor = ChannelProcessing.NewProcessor<JobPartInternal>(DataMovementConstants.MaxJobPartReaders);
            _chunksProcessor = ChannelProcessing.NewProcessor<Func<Task>>(options?.MaximumConcurrency ?? DataMovementConstants.MaxJobChunkTasks);
            TransferCheckpointStoreOptions checkpointerOptions = options?.CheckpointerOptions != default ? new TransferCheckpointStoreOptions(options.CheckpointerOptions) : default;
            _checkpointer = checkpointerOptions != default ? checkpointerOptions.GetCheckpointer() : CreateDefaultCheckpointer();
            _resumeProviders = options?.ResumeProviders != null ? new(options.ResumeProviders) : new();
            _arrayPool = ArrayPool<byte>.Shared;
            _errorHandling = options?.ErrorHandling != default ? options.ErrorHandling : DataTransferErrorMode.StopOnAnyFailure;
            ClientDiagnostics = new ClientDiagnostics(options?.ClientOptions ?? ClientOptions.Default);

            ConfigureProcessorCallbacks();
        }

        /// <summary>
        /// Dependency injection constructor.
        /// </summary>
        internal TransferManager(
            IProcessor<TransferJobInternal> jobsProcessor,
            IProcessor<JobPartInternal> partsProcessor,
            IProcessor<Func<Task>> chunksProcessor,
            TransferCheckpointer checkpointer,
            ICollection<StorageResourceProvider> resumeProviders,
            ArrayPool<byte> arrayPool,
            DataTransferErrorMode errorhandling,
            ClientDiagnostics clientDiagnostics)
        {
            _jobsProcessor = jobsProcessor;
            _partsProcessor = partsProcessor;
            _chunksProcessor = chunksProcessor;
            _checkpointer = checkpointer;
            _resumeProviders = new(resumeProviders);
            _arrayPool = arrayPool;
            _errorHandling = errorhandling;
            ClientDiagnostics = clientDiagnostics;

            ConfigureProcessorCallbacks();
        }

        private void ConfigureProcessorCallbacks()
        {
            _jobsProcessor.Process = ProcessJobAsync;
            _partsProcessor.Process = ProcessPartAsync;
            _chunksProcessor.Process = Task.Run;
        }

        private async Task ProcessJobAsync(TransferJobInternal job, CancellationToken _)
        {
            await foreach (JobPartInternal partItem in job.ProcessJobToJobPartAsync().ConfigureAwait(false))
            {
                job.IncrementJobParts();
                await _partsProcessor.QueueAsync(partItem).ConfigureAwait(false);
            }
        }
        private async Task ProcessPartAsync(JobPartInternal part, CancellationToken _)
        {
            part.SetQueueChunkDelegate(_chunksProcessor.QueueAsync);
            await part.ProcessPartToChunkAsync().ConfigureAwait(false);
        }

        #region Transfer Job Management
        /// <summary>
        /// Attempts to pause the transfer of the respective id.
        /// </summary>
        /// <param name="transferId">The id of the transfer to pause.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Return true once the transfer has been successfully paused or false if the transfer
        /// was already completed.
        /// </returns>
        public virtual async Task PauseTransferIfRunningAsync(string transferId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            if (!_dataTransfers.TryGetValue(transferId, out DataTransfer transfer))
            {
                throw Errors.InvalidTransferId(nameof(PauseTransferIfRunningAsync), transferId);
            }
            await transfer.PauseAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the current transfers stored in the <see cref="TransferManager"/>.
        /// </summary>
        /// <param name="filterByStatus">
        /// If specified, the returned list of transfers will have only have the transfers
        /// of which match the status specified.
        ///
        /// If not specified or specified to <see cref="DataTransferState.None"/>,
        /// all transfers will be returned regardless of status.
        /// </param>
        /// <returns></returns>
        public virtual async IAsyncEnumerable<DataTransfer> GetTransfersAsync(
            params DataTransferStatus[] filterByStatus)
        {
            await SetDataTransfers().ConfigureAwait(false);
            IEnumerable<DataTransfer> totalTransfers;
            if (filterByStatus == default || filterByStatus.Length == 0)
            {
                totalTransfers = _dataTransfers.Select(d => d.Value);
            }
            else
            {
                totalTransfers = _dataTransfers
                    .Select(d => d.Value)
                    .Where(x => filterByStatus.Contains(x.TransferStatus)).ToList();
            }
            foreach (DataTransfer transfer in totalTransfers)
            {
                yield return transfer;
            }
        }

        /// <summary>
        /// Lists all the transfers stored in the checkpointer that can be resumed.
        /// </summary>
        /// <returns>
        /// List of <see cref="DataTransferProperties"/> objects that can be used to rebuild resources
        /// to resume with.
        /// </returns>
        public virtual async IAsyncEnumerable<DataTransferProperties> GetResumableTransfersAsync()
        {
            List<string> storedTransfers = await _checkpointer.GetStoredTransfersAsync().ConfigureAwait(false);
            foreach (string transferId in storedTransfers)
            {
                if (!await _checkpointer.IsResumableAsync(transferId, _cancellationToken).ConfigureAwait(false))
                {
                    continue;
                }

                DataTransferProperties properties = await _checkpointer.GetDataTransferPropertiesAsync(
                    transferId, _cancellationToken).ConfigureAwait(false);
                yield return properties;
            }
        }

        /// <summary>
        /// Resumes all the transfers stored in the checkpointer that can be resumed.
        /// </summary>
        /// <param name="transferOptions">
        /// Options to apply to each resumed transfer.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public virtual async Task<List<DataTransfer>> ResumeAllTransfersAsync(
            DataTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            List<DataTransfer> transfers = new();
            await foreach (DataTransferProperties properties in GetResumableTransfersAsync().ConfigureAwait(false))
            {
                transfers.Add(await ResumeTransferAsync(properties, transferOptions, cancellationToken).ConfigureAwait(false));
            }
            return transfers;
        }

        /// <summary>
        /// Resumes a transfer that has been paused or is in a completed state with failed or skipped transfers.
        /// </summary>
        /// <param name="transferId">The transfer ID of the transfer attempting to be resumed.</param>
        /// <param name="transferOptions">Options specific to this transfer.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns a <see cref="DataTransfer"/> for tracking this transfer.</returns>
        public virtual async Task<DataTransfer> ResumeTransferAsync(
            string transferId,
            DataTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Argument.AssertNotNullOrWhiteSpace(transferId, nameof(transferId));

            if (!await _checkpointer.IsResumableAsync(transferId, cancellationToken).ConfigureAwait(false))
            {
                return null;
            }

            DataTransferProperties properties = await _checkpointer.GetDataTransferPropertiesAsync(
                    transferId, cancellationToken).ConfigureAwait(false);

            return await ResumeTransferAsync(properties, transferOptions, cancellationToken).ConfigureAwait(false);
        }

        private async Task<DataTransfer> ResumeTransferAsync(
            DataTransferProperties dataTransferProperties,
            DataTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            bool TryGetStorageResourceProvider(DataTransferProperties properties, bool getSource, out StorageResourceProvider resourceProvider)
            {
                foreach (StorageResourceProvider provider in _resumeProviders)
                {
                    if (provider.ProviderId == (getSource ? properties.SourceProviderId : properties.DestinationProviderId))
                    {
                        resourceProvider = provider;
                        return true;
                    }
                }
                resourceProvider = null;
                return false;
            }

            transferOptions ??= new DataTransferOptions();

            if (_dataTransfers.ContainsKey(dataTransferProperties.TransferId))
            {
                // Remove the stale DataTransfer so we can pass a new DataTransfer object
                // to the user and also track the transfer from the DataTransfer object
                _dataTransfers.Remove(dataTransferProperties.TransferId);
            }

            if (!TryGetStorageResourceProvider(dataTransferProperties, getSource: true, out StorageResourceProvider sourceProvider))
            {
                throw Errors.NoResourceProviderFound(true, dataTransferProperties.SourceProviderId);
            }
            if (!TryGetStorageResourceProvider(dataTransferProperties, getSource: false, out StorageResourceProvider destinationProvider))
            {
                throw Errors.NoResourceProviderFound(false, dataTransferProperties.DestinationProviderId);
            }

            DataTransfer dataTransfer = await BuildAndAddTransferJobAsync(
                await sourceProvider.FromSourceAsync(dataTransferProperties, cancellationToken).ConfigureAwait(false),
                await destinationProvider.FromDestinationAsync(dataTransferProperties, cancellationToken).ConfigureAwait(false),
                transferOptions,
                dataTransferProperties.TransferId,
                true,
                cancellationToken).ConfigureAwait(false);

            return dataTransfer;
        }

        /// <summary>
        /// Attempts to pause all the ongoing transfers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal virtual async Task PauseAllRunningTransfersAsync(CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(_dataTransfers.Values
                .Where(transfer => transfer.CanPause())
                .Select(transfer => transfer.PauseAsync(cancellationToken)))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Attempts to remove the transfer of the respective id. Will remove it does exist and has not completed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal virtual Task<bool> TryRemoveTransferAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion Transfer Job Management

        #region Start Transfer
        /// <summary>
        /// Starts a transfer from the given source resource to the given destination resource.
        /// </summary>
        /// <param name="sourceResource">A <see cref="StorageResource"/> representing the source.</param>
        /// <param name="destinationResource">A <see cref="StorageResource"/> representing the destination.</param>
        /// <param name="transferOptions">Options specific to this transfer.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns a <see cref="DataTransfer"/> for tracking this transfer.</returns>
        public virtual async Task<DataTransfer> StartTransferAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            DataTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Argument.AssertNotNull(sourceResource, nameof(sourceResource));
            Argument.AssertNotNull(destinationResource, nameof(destinationResource));

            transferOptions ??= new DataTransferOptions();

            string transferId = Guid.NewGuid().ToString();
            await _checkpointer.AddNewJobAsync(
                transferId,
                sourceResource,
                destinationResource,
                _cancellationToken).ConfigureAwait(false);

            DataTransfer dataTransfer = await BuildAndAddTransferJobAsync(
                sourceResource,
                destinationResource,
                transferOptions,
                transferId,
                false,
                cancellationToken).ConfigureAwait(false);

            return dataTransfer;
        }

        private async Task<DataTransfer> BuildAndAddTransferJobAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            DataTransferOptions transferOptions,
            string transferId,
            bool resumeJob,
            CancellationToken cancellationToken)
        {
            DataTransfer dataTransfer = new DataTransfer(id: transferId, transferManager: this);
            _dataTransfers.Add(dataTransfer.Id, dataTransfer);

            TransferJobInternal transferJobInternal;

            // Single transfer
            if (sourceResource is StorageResourceItem &&
                destinationResource is StorageResourceItem)
            {
                transferJobInternal = await BuildSingleTransferJob(
                    (StorageResourceItem)sourceResource,
                    (StorageResourceItem)destinationResource,
                    transferOptions,
                    dataTransfer,
                    resumeJob).ConfigureAwait(false);
            }
            // Container transfer
            else if (sourceResource is StorageResourceContainer &&
                destinationResource is StorageResourceContainer)
            {
                transferJobInternal = await BuildContainerTransferJob(
                    (StorageResourceContainer)sourceResource,
                    (StorageResourceContainer)destinationResource,
                    transferOptions,
                    dataTransfer,
                    resumeJob).ConfigureAwait(false);
            }
            // Invalid transfer
            else
            {
                throw Errors.InvalidTransferResourceTypes();
            }
            // Queue Job
            await _jobsProcessor.QueueAsync(transferJobInternal, _cancellationToken).ConfigureAwait(false);

            return dataTransfer;
        }

        private async Task<TransferJobInternal> BuildSingleTransferJob(
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferOptions transferOptions,
            DataTransfer dataTransfer,
            bool resumeJob)
        {
            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            if (sourceResource.IsLocalResource())
            {
                if (!destinationResource.IsLocalResource())
                {
                    // Stream to Uri job (Upload Job)
                    StreamToUriTransferJob streamToUriJob = new StreamToUriTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        checkpointer: _checkpointer,
                        errorHandling: _errorHandling,
                        arrayPool: _arrayPool,
                        clientDiagnostics: ClientDiagnostics);

                    if (resumeJob)
                    {
                        using (Stream stream = await _checkpointer.ReadJobPartPlanFileAsync(
                            transferId: dataTransfer.Id,
                            partNumber: 0,
                            offset: 0,
                            length: 0,
                            cancellationToken: _cancellationToken).ConfigureAwait(false))
                        {
                            streamToUriJob.AppendJobPart(
                                streamToUriJob.ToJobPartAsync(
                                    stream,
                                    sourceResource,
                                    destinationResource));
                        }
                    }
                    return streamToUriJob;
                }
                else // Invalid argument that both resources do not produce a Uri
                {
                    throw Errors.InvalidSourceDestinationParams();
                }
            }
            else
            {
                // Source is remote
                if (!destinationResource.IsLocalResource())
                {
                    // Service to Service Job (Copy job)
                    ServiceToServiceTransferJob serviceToServiceJob = new ServiceToServiceTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        CheckPointFolderPath: _checkpointer,
                        errorHandling: _errorHandling,
                        arrayPool: _arrayPool,
                        clientDiagnostics: ClientDiagnostics);

                    if (resumeJob)
                    {
                        using (Stream stream = await _checkpointer.ReadJobPartPlanFileAsync(
                            transferId: dataTransfer.Id,
                            partNumber: 0,
                            offset: 0,
                            length: 0,
                            cancellationToken: _cancellationToken).ConfigureAwait(false))
                        {
                            serviceToServiceJob.AppendJobPart(
                                serviceToServiceJob.ToJobPartAsync(
                                    stream,
                                    sourceResource,
                                    destinationResource));
                        }
                    }
                    return serviceToServiceJob;
                }
                else
                {
                    // Download to local operation
                    // Service to Local job (Download Job)
                    UriToStreamTransferJob uriToStreamJob = new UriToStreamTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        checkpointer: _checkpointer,
                        errorHandling: _errorHandling,
                        arrayPool: _arrayPool,
                        clientDiagnostics: ClientDiagnostics);

                    if (resumeJob)
                    {
                        using (Stream stream = await _checkpointer.ReadJobPartPlanFileAsync(
                            transferId: dataTransfer.Id,
                            partNumber: 0,
                            offset: 0,
                            length: 0,
                            cancellationToken: _cancellationToken).ConfigureAwait(false))
                        {
                            uriToStreamJob.AppendJobPart(
                                uriToStreamJob.ToJobPartAsync(
                                    stream,
                                    sourceResource,
                                    destinationResource));
                        }
                    }
                    return uriToStreamJob;
                }
            }
        }

        private async Task<TransferJobInternal> BuildContainerTransferJob(
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            DataTransferOptions transferOptions,
            DataTransfer dataTransfer,
            bool resumeJob)
        {
            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            if (sourceResource.IsLocalResource())
            {
                if (!destinationResource.IsLocalResource())
                {
                    // Stream to Uri job (Upload Job)
                    StreamToUriTransferJob streamToUriJob = new StreamToUriTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        checkpointer: _checkpointer,
                        errorHandling: _errorHandling,
                        arrayPool: _arrayPool,
                        clientDiagnostics: ClientDiagnostics);

                    if (resumeJob)
                    {
                        // Iterate through all job parts and append to the job
                        int jobPartCount = await _checkpointer.CurrentJobPartCountAsync(
                            transferId: dataTransfer.Id,
                            cancellationToken: _cancellationToken).ConfigureAwait(false);
                        for (var currentJobPart = 0; currentJobPart < jobPartCount; currentJobPart++)
                        {
                            using (Stream stream = await _checkpointer.ReadJobPartPlanFileAsync(
                                transferId: dataTransfer.Id,
                                partNumber: currentJobPart,
                                offset: 0,
                                length: 0,
                                cancellationToken: _cancellationToken).ConfigureAwait(false))
                            {
                                streamToUriJob.AppendJobPart(
                                    streamToUriJob.ToJobPartAsync(
                                        stream,
                                        sourceResource,
                                        destinationResource));
                            }
                        }
                    }
                    return streamToUriJob;
                }
                else // Invalid argument that both resources do not produce a Uri
                {
                    throw Errors.InvalidSourceDestinationParams();
                }
            }
            else
            {
                // Source is remote
                if (!destinationResource.IsLocalResource())
                {
                    // Service to Service Job (Copy job)
                    ServiceToServiceTransferJob serviceToServiceJob = new ServiceToServiceTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        checkpointer: _checkpointer,
                        errorHandling: _errorHandling,
                        arrayPool: _arrayPool,
                        clientDiagnostics: ClientDiagnostics);

                    if (resumeJob)
                    {
                        // Iterate through all job parts and append to the job
                        int jobPartCount = await _checkpointer.CurrentJobPartCountAsync(
                            transferId: dataTransfer.Id,
                            cancellationToken: _cancellationToken).ConfigureAwait(false);
                        for (var currentJobPart = 0; currentJobPart < jobPartCount; currentJobPart++)
                        {
                            using (Stream stream = await _checkpointer.ReadJobPartPlanFileAsync(
                                transferId: dataTransfer.Id,
                                partNumber: currentJobPart,
                                offset: 0,
                                length: 0,
                                cancellationToken: _cancellationToken).ConfigureAwait(false))
                            {
                                serviceToServiceJob.AppendJobPart(
                                    serviceToServiceJob.ToJobPartAsync(
                                        stream,
                                        sourceResource,
                                        destinationResource));
                            }
                        }
                    }
                    return serviceToServiceJob;
                }
                else
                {
                    // Download to local operation
                    // Service to Local job (Download Job)
                    UriToStreamTransferJob uriToStreamJob = new UriToStreamTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        checkpointer: _checkpointer,
                        errorHandling: _errorHandling,
                        arrayPool: _arrayPool,
                        clientDiagnostics: ClientDiagnostics);

                    if (resumeJob)
                    {
                        // Iterate through all job parts and append to the job
                        int jobPartCount = await _checkpointer.CurrentJobPartCountAsync(
                            transferId: dataTransfer.Id,
                            cancellationToken: _cancellationToken).ConfigureAwait(false);
                        for (var currentJobPart = 0; currentJobPart < jobPartCount; currentJobPart++)
                        {
                            using (Stream stream = await _checkpointer.ReadJobPartPlanFileAsync(
                                transferId: dataTransfer.Id,
                                partNumber: currentJobPart,
                                offset: 0,
                                length: 0,
                                cancellationToken: _cancellationToken).ConfigureAwait(false))
                            {
                                uriToStreamJob.AppendJobPart(
                                    uriToStreamJob.ToJobPartAsync(
                                        stream,
                                        sourceResource,
                                        destinationResource));
                            }
                        }
                    }
                    return uriToStreamJob;
                }
            }
        }
        #endregion

        /// <summary>
        /// Returns a default checkpointer if not specified by the user already.
        ///
        /// By default a local folder will be used to store the job transfer files.
        /// </summary>
        /// <returns>
        /// A <see cref="LocalTransferCheckpointer"/> using the folder
        /// where the application is stored with and making a new folder called
        /// .azstoragedml to store all the job plan files.
        /// </returns>
        private static LocalTransferCheckpointer CreateDefaultCheckpointer()
        {
            // Return checkpointer
            return new LocalTransferCheckpointer(default);
        }

        private async Task SetDataTransfers()
        {
            _dataTransfers.Clear();

            List<string> storedTransfers = await _checkpointer.GetStoredTransfersAsync().ConfigureAwait(false);
            foreach (string transferId in storedTransfers)
            {
                DataTransferStatus jobStatus = await _checkpointer.GetJobStatusAsync(transferId).ConfigureAwait(false);
                _dataTransfers.Add(transferId, new DataTransfer(
                    id: transferId,
                    transferManager: this,
                    status: jobStatus));
            }
        }

        /// <summary>
        /// Disposes.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> of disposing the <see cref="TransferManager"/>.</returns>
        ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
            _jobsProcessor?.Dispose();
            _partsProcessor?.Dispose();
            _chunksProcessor?.Dispose();
            GC.SuppressFinalize(this);
            return default;
        }
    }
}
