// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceJobPart : JobPartInternal, IDisposable
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
            long? length = default)
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
                  jobPartStatus: default,
                  length: length)
        {
        }

        /// <summary>
        /// Creating transfer job based on a checkpoint file.
        /// </summary>
        private ServiceToServiceJobPart(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationPreference createPreference)
            : base(dataTransfer: job._dataTransfer,
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
                  jobPartEventHandler: job.GetJobPartStatus(),
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

        public void Dispose()
        {
            DisposeHandlers();
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
            long transferChunkSize,
            StorageResourceCreationPreference createPreference)
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

        public override async Task ProcessPartToChunkAsync()
        {
            await OnTransferStateChangedAsync(DataTransferState.InProgress).ConfigureAwait(false);

            long? fileLength = _sourceResource.Length;
            StorageResourceItemProperties sourceProperties = default;
            try
            {
                sourceProperties = await _sourceResource.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                fileLength = sourceProperties.ResourceLength;
            }
            catch (Exception ex)
            {
                // TODO: logging when given the event handler
                await InvokeFailedArg(ex).ConfigureAwait(false);
                return;
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
                _destinationResource.TransferType,
                sourceProperties);
            // If we cannot upload in one shot, initiate the parallel block uploader
            if (await CreateDestinationResource(length, blockSize).ConfigureAwait(false))
            {
                List<(long Offset, long Length)> commitBlockList = GetRangeList(blockSize, length);
                if (_destinationResource.TransferType == DataTransferOrder.Unordered)
                {
                    await QueueStageBlockRequests(commitBlockList, length, sourceProperties).ConfigureAwait(false);
                }
                else // Sequential
                {
                    // Queue the first partitioned block task
                    await QueueStageBlockRequest(
                        commitBlockList[0].Offset,
                        commitBlockList[0].Length,
                        length,
                        sourceProperties).ConfigureAwait(false);
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
                    await CompleteTransferAsync(options.SourceProperties).ConfigureAwait(false);
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
            DataTransferOrder transferType,
            StorageResourceItemProperties sourceProperties)
        => new CommitChunkHandler(
            expectedLength,
            blockSize,
            GetBlockListCommitHandlerBehaviors(jobPart),
            transferType,
            ClientDiagnostics,
            sourceProperties,
            _cancellationToken);

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            ServiceToServiceJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                QueuePutBlockTask = jobPart.QueueStageBlockRequest,
                QueueCommitBlockTask = jobPart.CompleteTransferAsync,
                ReportProgressInBytes = jobPart.ReportBytesWritten,
                InvokeFailedHandler = jobPart.InvokeFailedArg,
            };
        }
        #endregion

        internal async Task CompleteTransferAsync(StorageResourceItemProperties sourceProperties)
        {
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    completeTransferOptions: new() { SourceProperties = sourceProperties },
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                DisposeHandlers();

                // Set completion status to completed
                await OnTransferStateChangedAsync(DataTransferState.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        private async Task QueueStageBlockRequests(
            List<(long Offset, long Size)> commitBlockList,
            long expectedLength,
            StorageResourceItemProperties sourceProperties)
        {
            _queueingTasks = true;
            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in commitBlockList)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    break;
                }

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
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    range: new HttpRange(offset, blockLength),
                    completeLength: expectedLength,
                    options: options,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // The chunk handler may have been disposed in failure case
                if (_commitBlockHandler != null)
                {
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
            DisposeHandlers();
            await base.InvokeSkippedArg().ConfigureAwait(false);
        }

        public override async Task InvokeFailedArg(Exception ex)
        {
            DisposeHandlers();
            await base.InvokeFailedArg(ex).ConfigureAwait(false);
        }

        internal void DisposeHandlers()
        {
            if (_commitBlockHandler != default)
            {
                _commitBlockHandler.Dispose();
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
                options = new StorageResourceCopyFromUriOptions()
                {
                    SourceAuthentication = authorization
                };
            }
            return options;
        }
    }
}
