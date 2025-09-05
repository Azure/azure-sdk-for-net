// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceJobPart : JobPartInternal, IAsyncDisposable
    {
        public delegate Task CommitBlockTaskInternal(CancellationToken cancellationToken);
        public CommitBlockTaskInternal CommitBlockTask { get; internal set; }

        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CommitChunkHandler _commitBlockHandler;

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private ServiceToServiceJobPart(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            long? length = default)
            : base(transferOperation: job._transferOperation,
                  partNumber: partNumber,
                  sourceResource: sourceResource,
                  destinationResource: destinationResource,
                  transferChunkSize: job._maximumTransferChunkSize,
                  initialTransferSize: job._initialTransferSize,
                  errorHandling: job._errorMode,
                  createMode: job._creationPreference,
                  checkpointer: job._checkpointer,
                  progressTracker: job._progressTracker,
                  arrayPool: job.UploadArrayPool,
                  jobPartEventHandler: job.GetJobPartStatusEventHandler(),
                  statusEventHandler: job.TransferStatusEventHandler,
                  failedEventHandler: job.TransferFailedEventHandler,
                  skippedEventHandler: job.TransferSkippedEventHandler,
                  singleTransferEventHandler: job.TransferItemCompletedEventHandler,
                  clientDiagnostics: job.ClientDiagnostics,
                  cancellationToken: job._cancellationToken,
                  jobPartStatus: default,
                  length: length)
        {
        }

        /// <summary>
        /// Creating transfer job based on a checkpoint file.
        /// </summary>
        private ServiceToServiceJobPart(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            TransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationMode createPreference)
            : base(transferOperation: job._transferOperation,
                  partNumber: partNumber,
                  sourceResource: sourceResource,
                  destinationResource: destinationResource,
                  transferChunkSize: transferChunkSize,
                  initialTransferSize: initialTransferSize,
                  errorHandling: job._errorMode,
                  createMode: createPreference,
                  checkpointer: job._checkpointer,
                  progressTracker: job._progressTracker,
                  arrayPool: job.UploadArrayPool,
                  jobPartEventHandler: job.GetJobPartStatusEventHandler(),
                  statusEventHandler: job.TransferStatusEventHandler,
                  failedEventHandler: job.TransferFailedEventHandler,
                  skippedEventHandler: job.TransferSkippedEventHandler,
                  singleTransferEventHandler: job.TransferItemCompletedEventHandler,
                  clientDiagnostics: job.ClientDiagnostics,
                  cancellationToken: job._cancellationToken,
                  jobPartStatus: jobPartStatus,
                  length: default)
        {
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeHandlersAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Called when creating a job part from a container transfer.
        /// </summary>
        public static async Task<JobPartInternal> CreateJobPartAsync(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource)
        {
            Argument.AssertNotNull(sourceResource, nameof(sourceResource));
            Argument.AssertNotNull(destinationResource, nameof(destinationResource));

            // Create Job Part file as we're initializing the job part
            ServiceToServiceJobPart part = new ServiceToServiceJobPart(
                job: job,
                partNumber: partNumber,
                sourceResource: sourceResource,
                destinationResource: destinationResource);
            await part.AddJobPartToCheckpointerAsync().ConfigureAwait(false);
            return part;
        }

        /// <summary>
        /// Called when creating a job part from a checkpoint file on resume.
        /// </summary>
        public static ServiceToServiceJobPart CreateJobPartFromCheckpoint(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            TransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationMode createPreference)
        {
            return new ServiceToServiceJobPart(
                job: job,
                partNumber: partNumber,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                jobPartStatus: jobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);
        }

        /// <summary>
        /// Processes the job part to chunks
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            try
            {
                // Continue only if job is in progress
                if (!await CheckTransferStateBeforeRunning().ConfigureAwait(false))
                {
                    return;
                }
                await OnTransferStateChangedAsync(TransferState.InProgress).ConfigureAwait(false);

                if (!await _sourceResource.ShouldItemTransferAsync(_cancellationToken).ConfigureAwait(false))
                {
                    await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
                    return;
                }

                StorageResourceItemProperties sourceProperties =
                    await _sourceResource.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                if (!sourceProperties.ResourceLength.HasValue)
                {
                    await InvokeFailedArgAsync(Errors.UnableToGetLength()).ConfigureAwait(false);
                    return;
                }
                long length = sourceProperties.ResourceLength.Value;

                await _destinationResource.SetPermissionsAsync(
                    _sourceResource,
                    sourceProperties,
                    _cancellationToken).ConfigureAwait(false);

                // Perform a single copy operation
                if (_initialTransferSize >= length)
                {
                    await QueueChunkToChannelAsync(
                        async () =>
                        await StartSingleCallCopy(length, sourceProperties: sourceProperties).ConfigureAwait(false))
                        .ConfigureAwait(false);
                    return;
                }

                // Perform a series of chunk copies followed by a commit
                long blockSize = _transferChunkSize;
                _commitBlockHandler = new CommitChunkHandler(
                    expectedLength: length,
                    blockSize: blockSize,
                    GetBlockListCommitHandlerBehaviors(this),
                    _destinationResource.TransferType,
                    sourceProperties,
                    _cancellationToken);

                // If we cannot copy in one shot, queue the rest of the chunks
                if (await CreateDestinationResource(length, blockSize).ConfigureAwait(false))
                {
                    IEnumerable<(long Offset, long Length)> ranges = GetRanges(length, blockSize, _destinationResource.MaxSupportedChunkCount);
                    if (_destinationResource.TransferType == TransferOrder.Unordered)
                    {
                        await QueueStageBlockRequests(ranges, length, sourceProperties).ConfigureAwait(false);
                    }
                    else // Sequential
                    {
                        // Queue the first partitioned block task
                        (long Offset, long Length) first = ranges.First();
                        await QueueStageBlockRequest(
                            first.Offset,
                            first.Length,
                            length,
                            sourceProperties).ConfigureAwait(false);
                    }
                }
                else
                {
                    await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        private async Task StartSingleCallCopy(long completeLength, StorageResourceItemProperties sourceProperties)
        {
            try
            {
                StorageResourceCopyFromUriOptions options =
                    await GetCopyFromUriOptionsAsync(_cancellationToken).ConfigureAwait(false);

                await _destinationResource.CopyFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                    completeLength: completeLength,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                await ReportBytesWrittenAsync(completeLength).ConfigureAwait(false);
                await CompleteTransferAsync(sourceProperties).ConfigureAwait(false);
                await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreationMode.SkipIfExists
                 && exception.ErrorCode == "BlobAlreadyExists")
            {
                await InvokeSkippedArgAsync().ConfigureAwait(false);
            }
            catch (InvalidOperationException ex)
            when (_createMode == StorageResourceCreationMode.SkipIfExists
                && ex.Message.Contains("Cannot overwrite file."))
            {
                await InvokeSkippedArgAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates the destination resource and performs the first copy call.
        /// Returns false if the copy is complete or this operation failed/skipped.
        /// </summary>
        private async Task<bool> CreateDestinationResource(long totalLength, long blockSize)
        {
            try
            {
                StorageResourceCopyFromUriOptions options =
                    await GetCopyFromUriOptionsAsync(_cancellationToken).ConfigureAwait(false);
                await _destinationResource.CopyBlockFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                    range: new HttpRange(0, blockSize),
                    completeLength: totalLength,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Report first chunk written to progress tracker
                await ReportBytesWrittenAsync(blockSize).ConfigureAwait(false);
                return true;
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreationMode.SkipIfExists
                 && exception.ErrorCode == "BlobAlreadyExists")
            {
                await InvokeSkippedArgAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }

            // Do not continue if we need to skip or there was an error.
            return false;
        }

        #region CommitChunkController
        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            ServiceToServiceJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                QueuePutBlockTask = jobPart.QueueStageBlockRequest,
                QueueCommitBlockTask = jobPart.QueueCompleteTransferAsync,
                ReportProgressInBytes = jobPart.ReportBytesWrittenAsync,
                InvokeFailedHandler = jobPart.InvokeFailedArgAsync,
            };
        }
        #endregion

        internal Task QueueCompleteTransferAsync(StorageResourceItemProperties sourceProperties) =>
            QueueChunkToChannelAsync(() => CompleteTransferAsync(sourceProperties));

        internal async Task CompleteTransferAsync(StorageResourceItemProperties sourceProperties)
        {
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(
                    overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                    completeTransferOptions: new() { SourceProperties = sourceProperties },
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                await DisposeHandlersAsync().ConfigureAwait(false);

                // Set completion status to completed
                await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        private async Task QueueStageBlockRequests(
            IEnumerable<(long Offset, long Size)> ranges,
            long expectedLength,
            StorageResourceItemProperties sourceProperties)
        {
            _queueingTasks = true;
            try
            {
                // Partition the stream into individual blocks
                foreach ((long Offset, long Length) block in ranges)
                {
                    CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

                    // Queue partitioned block task
                    await QueueStageBlockRequest(
                        block.Offset,
                        block.Length,
                        expectedLength,
                        sourceProperties).ConfigureAwait(false);
                }

                _queueingTasks = false;
                await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _queueingTasks = false;
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        private Task QueueStageBlockRequest(
            long offset,
            long blockSize,
            long expectedLength,
            StorageResourceItemProperties properties)
        {
            return QueueChunkToChannelAsync(
                async () =>
                await PutBlockFromUri(
                    offset,
                    blockSize,
                    expectedLength).ConfigureAwait(false));
        }

        internal async Task PutBlockFromUri(
            long offset,
            long blockLength,
            long expectedLength)
        {
            try
            {
                StorageResourceCopyFromUriOptions options =
                    await GetCopyFromUriOptionsAsync(_cancellationToken).ConfigureAwait(false);
                await _destinationResource.CopyBlockFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                    range: new HttpRange(offset, blockLength),
                    completeLength: expectedLength,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // The chunk handler may have been disposed in failure case
                if (_commitBlockHandler != null)
                {
                    // Queue result to increment bytes transferred and check for completion
                    await _commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                        offset: offset,
                        bytesTransferred: blockLength)).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex)
            when (_createMode == StorageResourceCreationMode.OverwriteIfExists
                    && ex.ErrorCode == "BlobAlreadyExists")
            {
                // For Block Blobs this is a one off case because we don't create the blob
                // before uploading to it.
                if (_createMode == StorageResourceCreationMode.FailIfExists)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                }
                else // (_createMode == StorageResourceCreateMode.Skip)
                {
                    await InvokeSkippedArgAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        public override async Task InvokeSkippedArgAsync()
        {
            await base.InvokeSkippedArgAsync().ConfigureAwait(false);
        }

        public override async Task InvokeFailedArgAsync(Exception ex)
        {
            await base.InvokeFailedArgAsync(ex).ConfigureAwait(false);
        }

        public override async Task DisposeHandlersAsync()
        {
            if (_commitBlockHandler != default)
            {
                await _commitBlockHandler.DisposeAsync().ConfigureAwait(false);
                _commitBlockHandler = null;
            }
        }

        private async Task<StorageResourceCopyFromUriOptions> GetCopyFromUriOptionsAsync(CancellationToken cancellationToken)
        {
            StorageResourceItemProperties properties = await _sourceResource.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);
            StorageResourceCopyFromUriOptions options = new()
            {
                SourceProperties = properties
            };
            HttpAuthorization authorization = await _sourceResource.GetCopyAuthorizationHeaderAsync(cancellationToken).ConfigureAwait(false);
            if (authorization != null)
            {
                options.SourceAuthentication = authorization;
            }
            return options;
        }
    }
}
