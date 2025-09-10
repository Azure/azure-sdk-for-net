// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        internal readonly ConcurrentDictionary<string, TransferOperation> _transfers = new();

        /// <summary>
        /// Designated checkpointer for the respective transfer manager.
        ///
        /// If unspecified will default to LocalTransferCheckpointer at {currentpath}/.azstoragedml
        /// </summary>
        private readonly ITransferCheckpointer _checkpointer;

        private readonly List<StorageResourceProvider> _resumeProviders;

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
            ChannelProcessing.NewProcessor<TransferJobInternal>(readers: 1),
            ChannelProcessing.NewProcessor<JobPartInternal>(
                readers: DataMovementConstants.Channels.MaxJobPartReaders,
                capacity: DataMovementConstants.Channels.JobPartCapacity),
            ChannelProcessing.NewProcessor<Func<Task>>(
                readers: options?.MaximumConcurrency ?? DataMovementConstants.Channels.MaxJobChunkReaders,
                capacity: DataMovementConstants.Channels.JobChunkCapacity),
            new(ArrayPool<byte>.Shared,
                options?.ErrorMode ?? TransferErrorMode.StopOnAnyFailure,
                new ClientDiagnostics(options?.ClientOptions ?? ClientOptions.Default)),
                CheckpointerExtensions.BuildCheckpointer(options?.CheckpointStoreOptions),
                options?.ProvidersForResuming != null ? new List<StorageResourceProvider>(options.ProvidersForResuming) : new(),
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
            ITransferCheckpointer checkpointer,
            ICollection<StorageResourceProvider> resumeProviders,
            Func<string> generateTransferId = default)
        {
            _jobsProcessor = jobsProcessor;
            _partsProcessor = partsProcessor;
            _chunksProcessor = chunksProcessor;
            _jobBuilder = jobBuilder;
            _resumeProviders = new(resumeProviders ?? new List<StorageResourceProvider>());
            _resumeProviders.Add(new LocalFilesStorageResourceProvider());
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

        private async Task ProcessJobAsync(TransferJobInternal job)
        {
            await foreach (JobPartInternal partItem in job.ProcessJobToJobPartAsync().ConfigureAwait(false))
            {
                await job.IncrementJobParts().ConfigureAwait(false);
                await _partsProcessor.QueueAsync(partItem).ConfigureAwait(false);
            }
        }
        private async Task ProcessPartAsync(JobPartInternal part)
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
        public virtual async Task PauseTransferAsync(string transferId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            if (!_transfers.TryGetValue(transferId, out TransferOperation transfer))
            {
                throw Errors.InvalidTransferId(nameof(PauseTransferAsync), transferId);
            }
            else
            {
                await transfer.PauseAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the current transfers stored in the <see cref="TransferManager"/>.
        /// </summary>
        /// <param name="filterByStatus">
        /// If specified, the returned list of transfers will have only have the transfers
        /// of which match the status specified.
        ///
        /// If not specified or specified to <see cref="TransferState.None"/>,
        /// all transfers will be returned regardless of status.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public virtual async IAsyncEnumerable<TransferOperation> GetTransfersAsync(
            ICollection<TransferStatus> filterByStatus = default,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await PopulateTransfersAsync(cancellationToken).ConfigureAwait(false);
            IEnumerable<TransferOperation> totalTransfers;
            if (filterByStatus == default || filterByStatus.Count == 0)
            {
                totalTransfers = _transfers.Select(d => d.Value);
            }
            else
            {
                totalTransfers = _transfers
                    .Select(d => d.Value)
                    .Where(x => filterByStatus.Contains(x.Status)).ToList();
            }
            foreach (TransferOperation transfer in totalTransfers)
            {
                yield return transfer;
            }
        }

        /// <summary>
        /// Lists all the transfers stored in the checkpointer that can be resumed.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// List of <see cref="TransferProperties"/> objects that can be used to rebuild resources
        /// to resume with.
        /// </returns>
        public virtual async IAsyncEnumerable<TransferProperties> GetResumableTransfersAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            List<string> storedTransfers = await _checkpointer.GetStoredTransfersAsync(cancellationToken).ConfigureAwait(false);
            foreach (string transferId in storedTransfers)
            {
                if (!await _checkpointer.IsResumableAsync(transferId, cancellationToken).ConfigureAwait(false))
                {
                    continue;
                }

                TransferProperties properties = await _checkpointer.GetTransferPropertiesAsync(
                    transferId, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task<List<TransferOperation>> ResumeAllTransfersAsync(
            TransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            if (_checkpointer is DisabledTransferCheckpointer)
            {
                throw Errors.CheckpointerDisabled("ResumeAllTransfersAsync");
            }

            List<TransferOperation> transfers = new();
            await foreach (TransferProperties properties in GetResumableTransfersAsync(cancellationToken).ConfigureAwait(false))
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
        /// <returns>Returns a <see cref="TransferOperation"/> for tracking this transfer.</returns>
        public virtual async Task<TransferOperation> ResumeTransferAsync(
            string transferId,
            TransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Argument.AssertNotNullOrWhiteSpace(transferId, nameof(transferId));
            if (_checkpointer is DisabledTransferCheckpointer)
            {
                throw Errors.CheckpointerDisabled("ResumeTransferAsync");
            }

            if (!await _checkpointer.IsResumableAsync(transferId, cancellationToken).ConfigureAwait(false))
            {
                return null;
            }

            TransferProperties properties = await _checkpointer.GetTransferPropertiesAsync(
                    transferId, cancellationToken).ConfigureAwait(false);

            return await ResumeTransferAsync(properties, transferOptions, cancellationToken).ConfigureAwait(false);
        }

        private async Task<TransferOperation> ResumeTransferAsync(
            TransferProperties transferProperties,
            TransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            bool TryGetStorageResourceProvider(TransferProperties properties, bool getSource, out StorageResourceProvider resourceProvider)
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

            transferOptions ??= new TransferOptions();

            // Remove the stale TransferOperation so we can pass a new TransferOperation object
            // to the user and also track the transfer from the TransferOperation object
            // No need to check if we were able to remove the transfer or not.
            // If there's no stale TransferOperation to remove, move on.
            _transfers.TryRemove(transferProperties.TransferId, out TransferOperation transfer);

            if (!TryGetStorageResourceProvider(transferProperties, getSource: true, out StorageResourceProvider sourceProvider))
            {
                throw Errors.NoResourceProviderFound(true, transferProperties.SourceProviderId);
            }
            if (!TryGetStorageResourceProvider(transferProperties, getSource: false, out StorageResourceProvider destinationProvider))
            {
                throw Errors.NoResourceProviderFound(false, transferProperties.DestinationProviderId);
            }

            StorageResource source = await sourceProvider.FromSourceAsync(transferProperties, cancellationToken).ConfigureAwait(false);
            StorageResource destination = await destinationProvider.FromDestinationAsync(transferProperties, cancellationToken).ConfigureAwait(false);
            TransferOperation transferOperation = await BuildAndAddTransferJobAsync(
                source,
                destination,
                transferOptions,
                transferProperties.TransferId,
                true,
                cancellationToken).ConfigureAwait(false);

            DataMovementEventSource.Singleton.ResumeTransfer(transferOperation.Id, source, destination);
            return transferOperation;
        }

        /// <summary>
        /// Attempts to pause all the ongoing transfers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal virtual async Task PauseAllRunningTransfersAsync(CancellationToken cancellationToken = default)
        {
            await Task.WhenAll(_transfers.Values
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
        internal virtual bool TryRemoveTransfer(string id)
        {
            return _transfers.TryRemove(id, out TransferOperation transfer);
        }
        #endregion Transfer Job Management

        #region Start Transfer
        /// <summary>
        /// Starts a transfer from the given source resource to the given destination resource.
        /// Ensure <see cref="StorageResource"/> instances are built with <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/README.md#permissions">appropriate permissions</see>.
        /// </summary>
        /// <param name="sourceResource">A <see cref="StorageResource"/> representing the source.</param>
        /// <param name="destinationResource">A <see cref="StorageResource"/> representing the destination.</param>
        /// <param name="transferOptions">Options specific to this transfer.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns a <see cref="TransferOperation"/> for tracking this transfer.</returns>
        public virtual async Task<TransferOperation> StartTransferAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            TransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Argument.AssertNotNull(sourceResource, nameof(sourceResource));
            Argument.AssertNotNull(destinationResource, nameof(destinationResource));

            string transferId = _generateTransferId();
            await destinationResource.ValidateTransferAsync(transferId, sourceResource, cancellationToken).ConfigureAwait(false);

            transferOptions ??= new TransferOptions();
            try
            {
                await _checkpointer.AddNewJobAsync(
                    transferId,
                    sourceResource,
                    destinationResource,
                    cancellationToken).ConfigureAwait(false);

                TransferOperation transferOperation = await BuildAndAddTransferJobAsync(
                    sourceResource,
                    destinationResource,
                    transferOptions,
                    transferId,
                    false,
                    cancellationToken).ConfigureAwait(false);

                DataMovementEventSource.Singleton.TransferQueued(transferId, sourceResource, destinationResource);
                return transferOperation;
            }
            catch (Exception ex)
            {
                // cleanup any state for a job that didn't even start
                try
                {
                    // No need to check if we were able to remove the transfer or not.
                    // If there's no stale TransferOperation to remove, move on, because this is a cleanup
                    _transfers.TryRemove(transferId, out TransferOperation transfer);
                    await _checkpointer.TryRemoveStoredTransferAsync(transferId, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception cleanupEx)
                {
                    throw new AggregateException(ex, cleanupEx);
                }
                throw;
            }
        }

        private async Task<TransferOperation> BuildAndAddTransferJobAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            TransferOptions transferOptions,
            string transferId,
            bool resumeJob,
            CancellationToken cancellationToken)
        {
            (TransferOperation transfer, TransferJobInternal transferJobInternal) = await _jobBuilder.BuildJobAsync(
                sourceResource,
                destinationResource,
                transferOptions,
                _checkpointer,
                transferId,
                resumeJob,
                TryRemoveTransfer,
                cancellationToken)
            .ConfigureAwait(false);

            transfer.TransferManager = this;
            if (!_transfers.TryAdd(transfer.Id, transfer))
            {
                throw Errors.CollisionTransferId(transfer.Id);
            }
            await _jobsProcessor.QueueAsync(transferJobInternal).ConfigureAwait(false);
            return transfer;
        }
        #endregion

        private async Task PopulateTransfersAsync(CancellationToken cancellationToken = default)
        {
            _transfers.Clear();

            List<string> storedTransfers = await _checkpointer.GetStoredTransfersAsync(cancellationToken).ConfigureAwait(false);
            foreach (string transferId in storedTransfers)
            {
                TransferStatus jobStatus = await _checkpointer.GetJobStatusAsync(transferId, cancellationToken).ConfigureAwait(false);
                // If TryAdd fails here, we need to check if in other places where we are
                // adding that every transferId is unique.
                if (!_transfers.TryAdd(transferId, new TransferOperation(
                    removeTransferDelegate: TryRemoveTransfer,
                    id: transferId,
                    status: jobStatus)))
                {
                    throw Errors.CollisionTransferId(transferId);
                }
            }
        }

        /// <summary>
        /// Disposes TransferManager and all its resources.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> of disposing the <see cref="TransferManager"/>.</returns>
        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (_jobsProcessor != default)
            {
                await _jobsProcessor.TryCompleteAsync().ConfigureAwait(false);
            }
            if (_partsProcessor != default)
            {
                await _partsProcessor.TryCompleteAsync().ConfigureAwait(false);
            }
            if (_chunksProcessor != default)
            {
                await _chunksProcessor.TryCompleteAsync().ConfigureAwait(false);
            }
            GC.SuppressFinalize(this);
        }
    }
}
