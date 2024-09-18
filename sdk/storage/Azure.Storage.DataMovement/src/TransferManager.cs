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

        private readonly JobBuilder _jobBuilder;

        /// <summary>
        /// Ongoing transfers indexed at the transfer id.
        /// </summary>
        internal readonly Dictionary<string, DataTransfer> _dataTransfers = new();

        /// <summary>
        /// Designated checkpointer for the respective transfer manager.
        ///
        /// If unspecified will default to LocalTransferCheckpointer at {currentpath}/.azstoragedml
        /// </summary>
        private readonly TransferCheckpointer _checkpointer;

        private readonly List<StorageResourceProvider> _resumeProviders;

        /// <summary>
        /// Cancels the channels operations when disposing.
        /// </summary>
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;

        private readonly Func<string> _generateTransferId;

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
            : this(
            ChannelProcessing.NewProcessor<TransferJobInternal>(parallelism: 1),
            ChannelProcessing.NewProcessor<JobPartInternal>(DataMovementConstants.MaxJobPartReaders),
            ChannelProcessing.NewProcessor<Func<Task>>(options?.MaximumConcurrency ?? DataMovementConstants.MaxJobChunkTasks),
            new(ArrayPool<byte>.Shared,
                options?.ErrorHandling ?? DataTransferErrorMode.StopOnAnyFailure,
                new ClientDiagnostics(options?.ClientOptions ?? ClientOptions.Default)),
                (options?.CheckpointerOptions != default ? new TransferCheckpointStoreOptions(options.CheckpointerOptions) : default)
                    ?.GetCheckpointer() ?? CreateDefaultCheckpointer(),
                options?.ResumeProviders != null ? new List<StorageResourceProvider>(options.ResumeProviders) : new(),
                default)
        {}

        /// <summary>
        /// Dependency injection constructor.
        /// </summary>
        internal TransferManager(
            IProcessor<TransferJobInternal> jobsProcessor,
            IProcessor<JobPartInternal> partsProcessor,
            IProcessor<Func<Task>> chunksProcessor,
            JobBuilder jobBuilder,
            TransferCheckpointer checkpointer,
            ICollection<StorageResourceProvider> resumeProviders,
            Func<string> generateTransferId = default)
        {
            _jobsProcessor = jobsProcessor;
            _partsProcessor = partsProcessor;
            _chunksProcessor = chunksProcessor;
            _jobBuilder = jobBuilder;
            _resumeProviders = new(resumeProviders ?? new List<StorageResourceProvider>());
            _checkpointer = checkpointer;
            _generateTransferId = generateTransferId ?? (() => Guid.NewGuid().ToString());

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
            cancellationToken = LinkCancellation(cancellationToken);
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
            cancellationToken = LinkCancellation(cancellationToken);
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
            cancellationToken = LinkCancellation(cancellationToken);
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
            cancellationToken = LinkCancellation(cancellationToken);
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
            cancellationToken = LinkCancellation(cancellationToken);
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
            cancellationToken = LinkCancellation(cancellationToken);
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Argument.AssertNotNull(sourceResource, nameof(sourceResource));
            Argument.AssertNotNull(destinationResource, nameof(destinationResource));

            transferOptions ??= new DataTransferOptions();

            string transferId = _generateTransferId();
            await _checkpointer.AddNewJobAsync(
                transferId,
                sourceResource,
                destinationResource,
                cancellationToken).ConfigureAwait(false);

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
            cancellationToken = LinkCancellation(cancellationToken);
            (DataTransfer transfer, TransferJobInternal transferJobInternal) = await _jobBuilder.BuildJobAsync(
                sourceResource,
                destinationResource,
                transferOptions,
                _checkpointer,
                transferId,
                resumeJob,
                cancellationToken)
                .ConfigureAwait(false);

            transfer.TransferManager = this;
            _dataTransfers.Add(transfer.Id, transfer);
            await _jobsProcessor.QueueAsync(transferJobInternal, cancellationToken).ConfigureAwait(false);

            return transfer;
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
                    status: jobStatus)
                {
                    TransferManager = this,
                });
            }
        }

        private CancellationToken LinkCancellation(CancellationToken cancellationToken)
            => CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cancellationToken).Token;

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
