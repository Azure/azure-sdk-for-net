// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

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
        /// Creating job part based on a single transfer job
        /// </summary>
        private ServiceToServiceJobPart(ServiceToServiceTransferJob job, int partNumber)
            : base(dataTransfer: job._dataTransfer,
                  partNumber: partNumber,
                  sourceResource: job._sourceResource,
                  destinationResource: job._destinationResource,
                  transferChunkSize: job._maximumTransferChunkSize,
                  initialTransferSize: job._initialTransferSize,
                  errorHandling: job._errorMode,
                  createMode: job._creationPreference,
                  checkpointer: job._checkpointer,
                  progressTracker: job._progressTracker,
                  arrayPool: job.UploadArrayPool,
                  jobPartEventHandler: job.GetJobPartStatus(),
                  statusEventHandler: job.TransferStatusEventHandler,
                  failedEventHandler: job.TransferFailedEventHandler,
                  skippedEventHandler: job.TransferSkippedEventHandler,
                  singleTransferEventHandler: job.TransferItemCompletedEventHandler,
                  clientDiagnostics: job.ClientDiagnostics,
                  cancellationToken: job._cancellationToken)
        {
        }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private ServiceToServiceJobPart(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferStatus jobPartStatus = default,
            long? length = default,
            long? initialTransferSize = default,
            long? transferChunkSize = default)
            : base(dataTransfer: job._dataTransfer,
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
                  jobPartEventHandler: job.GetJobPartStatus(),
                  statusEventHandler: job.TransferStatusEventHandler,
                  failedEventHandler: job.TransferFailedEventHandler,
                  skippedEventHandler: job.TransferSkippedEventHandler,
                  singleTransferEventHandler: job.TransferItemCompletedEventHandler,
                  clientDiagnostics: job.ClientDiagnostics,
                  cancellationToken: job._cancellationToken,
                  jobPartStatus: jobPartStatus,
                  length: length)
        {
            // If transfer sizes null at the job level (from options bag) then
            // override the default with the provided values if present.
            // Else, they were set correctly by the base constructor.
            if (!job._maximumTransferChunkSize.HasValue && transferChunkSize.HasValue)
            {
                _transferChunkSize = transferChunkSize.Value;
            }
            if (!job._initialTransferSize.HasValue && initialTransferSize.HasValue)
            {
                _initialTransferSize = initialTransferSize.Value;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeHandlers().ConfigureAwait(false);
        }

        /// <summary>
        /// Called when creating a job part from a single transfer.
        /// </summary>
        public static async Task<ServiceToServiceJobPart> CreateJobPartAsync(
            ServiceToServiceTransferJob job,
            int partNumber)
        {
            // Create Job Part file as we're initializing the job part
            ServiceToServiceJobPart part = new ServiceToServiceJobPart(job, partNumber);
            await part.AddJobPartToCheckpointerAsync().ConfigureAwait(false);
            return part;
        }

        /// <summary>
        /// Called when creating a job part from a container transfer.
        /// </summary>
        public static async Task<ServiceToServiceJobPart> CreateJobPartAsync(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            long? length = default)
        {
            // Create Job Part file as we're initializing the job part
            ServiceToServiceJobPart part = new ServiceToServiceJobPart(
                job: job,
                partNumber: partNumber,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                length: length);
            await part.AddJobPartToCheckpointerAsync().ConfigureAwait(false);
            return part;
        }

        /// <summary>
        /// Called when creating a job part from a checkpoint file on resume.
        /// </summary>
        public static ServiceToServiceJobPart CreateJobPartFromCheckpoint(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize)
        {
            return new ServiceToServiceJobPart(
                job: job,
                partNumber: partNumber,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                jobPartStatus: jobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize);
        }

        public override async Task ProcessPartToChunkAsync()
        {
            await OnTransferStateChangedAsync(DataTransferState.InProgress).ConfigureAwait(false);

            // Attempt to get the length, it's possible the file could
            // not be accessible (or does not exist).
            long? fileLength = _sourceResource.Length;
            if (!fileLength.HasValue)
            {
                try
                {
                    StorageResourceProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                    fileLength = properties.ContentLength;
                }
                catch (Exception ex)
                {
                    // TODO: logging when given the event handler
                    await InvokeFailedArg(ex).ConfigureAwait(false);
                    return;
                }
            }
            if (!fileLength.HasValue)
            {
                await InvokeFailedArg(Errors.UnableToGetLength()).ConfigureAwait(false);
                return;
            }
            long length = fileLength.Value;

            // Perform a single copy operation
            if (_initialTransferSize >= length)
            {
                await QueueChunkToChannelAsync(
                    async () =>
                    await StartSingleCallCopy(length).ConfigureAwait(false))
                    .ConfigureAwait(false);
                return;
            }

            // Perform a series of chunk copies followed by a commit
            long blockSize = _transferChunkSize;

            _commitBlockHandler = GetCommitController(
                expectedLength: length,
                blockSize: blockSize,
                this,
                _destinationResource.TransferType);
            // If we cannot upload in one shot, initiate the parallel block uploader
            if (await CreateDestinationResource(length, blockSize).ConfigureAwait(false))
            {
                List<(long Offset, long Length)> commitBlockList = GetRangeList(blockSize, length);
                if (_destinationResource.TransferType == DataTransferOrder.Unordered)
                {
                    await QueueStageBlockRequests(commitBlockList, length).ConfigureAwait(false);
                }
                else // Sequential
                {
                    // Queue partitioned block task
                    await QueueChunkToChannelAsync(
                        async () =>
                        await PutBlockFromUri(
                            offset: commitBlockList[0].Offset,
                            blockLength: commitBlockList[0].Length,
                            expectedLength: length).ConfigureAwait(false)).ConfigureAwait(false);
                }
            }
            else
            {
                await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
            }
        }

        internal async Task StartSingleCallCopy(long completeLength)
        {
            try
            {
                StorageResourceCopyFromUriOptions options =
                    await GetCopyFromUriOptionsAsync(_cancellationToken).ConfigureAwait(false);
                await _destinationResource.CopyFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    completeLength: completeLength,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                ReportBytesWritten(completeLength);
                await OnTransferStateChangedAsync(DataTransferState.Completed).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreationPreference.SkipIfExists
                 && exception.ErrorCode == "BlobAlreadyExists")
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (InvalidOperationException ex)
            when (_createMode == StorageResourceCreationPreference.SkipIfExists
                && ex.Message.Contains("Cannot overwrite file."))
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates the destination if necessary, and overwrites if necessary.
        /// Will return false if no further upload of the blob is necessary
        /// </summary>
        /// <returns></returns>
        internal async Task<bool> CreateDestinationResource(long length, long blockSize)
        {
            try
            {
                StorageResourceCopyFromUriOptions options =
                    await GetCopyFromUriOptionsAsync(_cancellationToken).ConfigureAwait(false);
                await _destinationResource.CopyBlockFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    range: new HttpRange(0, blockSize),
                    completeLength: length,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Report first chunk written to progress tracker
                ReportBytesWritten(blockSize);

                if (blockSize == length)
                {
                    await CompleteTransferAsync().ConfigureAwait(false);
                    return false;
                }
                return true;
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreationPreference.SkipIfExists
                 && exception.ErrorCode == "BlobAlreadyExists")
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
            return false;
        }

        #region CommitChunkController
        internal CommitChunkHandler GetCommitController(
            long expectedLength,
            long blockSize,
            ServiceToServiceJobPart jobPart,
            DataTransferOrder transferType)
        => new CommitChunkHandler(
            expectedLength,
            blockSize,
            GetBlockListCommitHandlerBehaviors(jobPart),
            transferType,
            ClientDiagnostics,
            _cancellationToken);

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            ServiceToServiceJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                QueuePutBlockTask = async (long offset, long blockSize, long expectedLength) => await jobPart.PutBlockFromUri(offset, blockSize, expectedLength).ConfigureAwait(false),
                QueueCommitBlockTask = async () => await jobPart.CompleteTransferAsync().ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) => jobPart.ReportBytesWritten(bytesWritten),
                InvokeFailedHandler = async (ex) => await jobPart.InvokeFailedArg(ex).ConfigureAwait(false),
            };
        }
        #endregion

        internal async Task CompleteTransferAsync()
        {
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                await DisposeHandlers().ConfigureAwait(false);

                // Set completion status to completed
                await OnTransferStateChangedAsync(DataTransferState.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        private async Task QueueStageBlockRequests(List<(long Offset, long Size)> commitBlockList, long expectedLength)
        {
            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in commitBlockList)
            {
                // Queue partitioned block task
                await QueueChunkToChannelAsync(
                    async () =>
                    await PutBlockFromUri(
                        block.Offset,
                        block.Length,
                        expectedLength).ConfigureAwait(false)).ConfigureAwait(false);
            }
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
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    range: new HttpRange(offset, blockLength),
                    completeLength: expectedLength,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
                // Invoke event handler to keep track of all the stage blocks
                await _commitBlockHandler.InvokeEvent(
                    new StageChunkEventArgs(
                        transferId: _dataTransfer.Id,
                        success: true,
                        offset: offset,
                        bytesTransferred: blockLength,
                        exception: default,
                        isRunningSynchronously: true,
                        cancellationToken: _cancellationToken)).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            when (_createMode == StorageResourceCreationPreference.OverwriteIfExists
                    && ex.ErrorCode == "BlobAlreadyExists")
            {
                // For Block Blobs this is a one off case because we don't create the blob
                // before uploading to it.
                if (_createMode == StorageResourceCreationPreference.FailIfExists)
                {
                    await InvokeFailedArg(ex).ConfigureAwait(false);
                }
                else // (_createMode == StorageResourceCreateMode.Skip)
                {
                    await InvokeSkippedArg().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                if (_commitBlockHandler != null)
                {
                    await _commitBlockHandler.InvokeEvent(
                        new StageChunkEventArgs(
                            transferId: _dataTransfer.Id,
                            success: false,
                            offset: offset,
                            bytesTransferred: blockLength,
                            exception: ex,
                            isRunningSynchronously: true,
                            cancellationToken: _cancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    // If the _commitBlockHandler has been disposed before we call to it
                    // we should at least filter the exception to error handling just in case.
                    await InvokeFailedArg(ex).ConfigureAwait(false);
                }
            }
        }

        public override async Task InvokeSkippedArg()
        {
            await DisposeHandlers().ConfigureAwait(false);
            await base.InvokeSkippedArg().ConfigureAwait(false);
        }

        public override async Task InvokeFailedArg(Exception ex)
        {
            await DisposeHandlers().ConfigureAwait(false);
            await base.InvokeFailedArg(ex).ConfigureAwait(false);
        }

        internal async Task DisposeHandlers()
        {
            if (_commitBlockHandler != default)
            {
                await _commitBlockHandler.DisposeAsync().ConfigureAwait(false);
            }
        }

        private async Task<StorageResourceCopyFromUriOptions> GetCopyFromUriOptionsAsync(CancellationToken cancellationToken)
        {
            StorageResourceCopyFromUriOptions options = default;
            HttpAuthorization authorization = await _sourceResource.GetCopyAuthorizationHeaderAsync(cancellationToken).ConfigureAwait(false);
            if (authorization != null)
            {
                options = new StorageResourceCopyFromUriOptions()
                {
                    SourceAuthentication = authorization
                };
            }
            return options;
        }
    }
}
