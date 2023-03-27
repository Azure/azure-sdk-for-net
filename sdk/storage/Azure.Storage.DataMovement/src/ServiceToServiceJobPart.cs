// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

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
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CopyStatusHandler _copyStatusHandler;

        /// <summary>
        /// Creating job part based on a single transfer job
        /// </summary>
        private ServiceToServiceJobPart(ServiceToServiceTransferJob job, int partNumber)
            : base(dataTransfer: job._dataTransfer,
                  partNumber: partNumber,
                  sourceResource: job._sourceResource,
                  destinationResource: job._destinationResource,
                  maximumTransferChunkSize: job._maximumTransferChunkSize,
                  initialTransferSize: job._initialTransferSize,
                  errorHandling: job._errorHandling,
                  createMode: job._createMode,
                  checkpointer: job._checkpointer,
                  arrayPool: job.UploadArrayPool,
                  jobPartEventHandler: job.GetJobPartStatus(),
                  statusEventHandler: job.TransferStatusEventHandler,
                  failedEventHandler: job.TransferFailedEventHandler,
                  skippedEventHandler: job.TransferSkippedEventHandler,
                  singleTransferEventHandler: job.SingleTransferCompletedEventHandler,
                  cancellationToken: job._cancellationToken)
        {
        }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private ServiceToServiceJobPart(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            StorageTransferStatus jobPartStatus = StorageTransferStatus.Queued,
            long? length = default)
            : base(dataTransfer: job._dataTransfer,
                  partNumber: partNumber,
                  sourceResource: sourceResource,
                  destinationResource :destinationResource,
                  maximumTransferChunkSize: job._maximumTransferChunkSize,
                  initialTransferSize: job._initialTransferSize,
                  errorHandling: job._errorHandling,
                  createMode: job._createMode,
                  checkpointer: job._checkpointer,
                  arrayPool: job.UploadArrayPool,
                  jobPartEventHandler: job.GetJobPartStatus(),
                  statusEventHandler: job.TransferStatusEventHandler,
                  failedEventHandler: job.TransferFailedEventHandler,
                  skippedEventHandler: job.TransferSkippedEventHandler,
                  singleTransferEventHandler: job.SingleTransferCompletedEventHandler,
                  cancellationToken: job._cancellationToken,
                  jobPartStatus: jobPartStatus,
                  length: length)
        {
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeHandlers().ConfigureAwait(false);
        }

        public static async Task<ServiceToServiceJobPart> CreateJobPartAsync(
            ServiceToServiceTransferJob job,
            int partNumber)
        {
            // Create Job Part file as we're intializing the job part
            ServiceToServiceJobPart part = new ServiceToServiceJobPart(
                job: job,
                partNumber: partNumber);
            await part.AddJobPartToCheckpointer(1).ConfigureAwait(false); // For now we only store 1 chunk
            return part;
        }

        public static async Task<ServiceToServiceJobPart> CreateJobPartAsync(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            StorageTransferStatus jobPartStatus = default,
            long? length = default)
        {
            // Create Job Part file as we're intializing the job part
            ServiceToServiceJobPart part = new ServiceToServiceJobPart(
                job: job,
                partNumber: partNumber,
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                length: length);
            await part.AddJobPartToCheckpointer(1).ConfigureAwait(false); // For now we only store 1 chunk
            return part;
        }

        public override async Task ProcessPartToChunkAsync()
        {
            await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);

            // Attempt to get the length, it's possible the file could
            // not be accesible (or does not exist).
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

            if (_destinationResource.ServiceCopyMethod == TransferCopyMethod.AsyncCopy)
            {
                // Perform a one call method to copy the resource.
                await StartSingleCallCopy(length, true).ConfigureAwait(false);
            }
            else // For now we default to sync copy
            {
                if (_initialTransferSize >= length)
                {
                    await StartSingleCallCopy(length, false).ConfigureAwait(false);
                    return;
                }
                long blockSize = CalculateBlockSize(length);

                _commitBlockHandler = GetCommitController(
                    expectedLength: length,
                    blockSize: blockSize,
                    this,
                    _destinationResource.TransferType);
                // If we cannot upload in one shot, initiate the parallel block uploader
                if (await CreateDestinationResource(length, blockSize).ConfigureAwait(false))
                {
                    List<(long Offset, long Length)> commitBlockList = GetRangeList(blockSize, length);
                    if (_destinationResource.TransferType == TransferType.Concurrent)
                    {
                        await QueueStageBlockRequests(commitBlockList, length).ConfigureAwait(false);
                    }
                    else // Sequential
                    {
                        // Queue paritioned block task
                        await QueueChunk(async () =>
                            await PutBlockFromUri(
                                commitBlockList[0].Offset,
                                commitBlockList[0].Length,
                                length).ConfigureAwait(false)).ConfigureAwait(false);
                    }
                }
            }
        }

        internal async Task StartSingleCallCopy(long completeLength, bool asyncCopy)
        {
            try
            {
                await _destinationResource.CopyFromUriAsync(
                        sourceResource: _sourceResource,
                        overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                        completeLength: completeLength,
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
                if (asyncCopy)
                {
                    _copyStatusHandler = GetCopyStatusController(this);
                    await CopyStatusCheckAsync(false).ConfigureAwait(false);
                }
                else
                {
                    await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreateMode.Skip
                 && exception.ErrorCode == "BlobAlreadyExists")
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
                await _destinationResource.CopyBlockFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                    range: new HttpRange(0, blockSize),
                    completeLength: length,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                if (blockSize == length)
                {
                    await CompleteTransferAsync().ConfigureAwait(false);
                    return false;
                }
                return true;
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreateMode.Skip
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
        internal static CommitChunkHandler GetCommitController(
            long expectedLength,
            long blockSize,
            ServiceToServiceJobPart jobPart,
            TransferType transferType)
        => new CommitChunkHandler(
            expectedLength,
            blockSize,
            GetBlockListCommitHandlerBehaviors(jobPart),
            transferType);

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            ServiceToServiceJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                QueuePutBlockTask = async (long offset, long blockSize, long expectedLength) => await jobPart.PutBlockFromUri(offset, blockSize, expectedLength).ConfigureAwait(false),
                QueueCommitBlockTask = async () => await jobPart.CompleteTransferAsync().ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) =>
                    jobPart.ReportBytesWritten(bytesWritten),
                InvokeFailedHandler = async (ex) => await jobPart.InvokeFailedArg(ex).ConfigureAwait(false),
            };
        }
        #endregion

        #region AsyncCopyStatusController
        internal static CopyStatusHandler GetCopyStatusController(
            ServiceToServiceJobPart jobPart)
        => new CopyStatusHandler(GetCopyStatusBehaviors(jobPart));

        internal static CopyStatusHandler.Behaviors GetCopyStatusBehaviors(
            ServiceToServiceJobPart jobPart)
        {
            return new CopyStatusHandler.Behaviors
            {
                QueueGetPropertiesTask = async () => await jobPart.CopyStatusCheckAsync().ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) => jobPart.ReportBytesWritten(bytesWritten),
                InvokeFailedHandler = async (ex) => await jobPart.InvokeFailedArg(ex).ConfigureAwait(false),
                UpdateTransferStatus = async (status) => await jobPart.OnTransferStatusChanged(status).ConfigureAwait(false)
            };
        }
        #endregion

        internal async Task CompleteTransferAsync()
        {
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(_cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                await DisposeHandlers().ConfigureAwait(false);

                // Set completion status to completed
                await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
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
                // Queue paritioned block task
                await QueueChunk(async () =>
                    await PutBlockFromUri(
                        block.Offset,
                        block.Length,
                        expectedLength).ConfigureAwait(false)).ConfigureAwait(false);
            }
        }

        internal async Task CopyStatusCheckAsync(bool waitEnabled = true)
        {
            // Determine the polling time we need to wait until we can queue
            // up the next GetProperties call.
            if (waitEnabled)
            {
                TimeSpan suggestedInterval = TimeSpan.FromSeconds(DataMovementConstants.StatusCheckInSec);
                await Task.Delay(suggestedInterval, _cancellationToken).ConfigureAwait(false);
            }

            // Call GetProperties
            try
            {
                StorageResourceProperties properties = await _destinationResource.GetPropertiesAsync().ConfigureAwait(false);
                if (properties != default && properties.CopyStatus.HasValue)
                {
                    await _copyStatusHandler.InvokeEvent(new CopyStatusEventArgs(
                        _dataTransfer.Id,
                        properties.CopyStatus.Value,
                        properties.CopyId,
                        ParseRangeTotalLength(properties.CopyProgress),
                        false,
                        _cancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await InvokeFailedArg(
                        new Exception("Get properties failed to return copy progress on the destination.")).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task QueueGetPropertiesAsync()
        {
            try
            {
                StorageResourceProperties properties = await _destinationResource.GetPropertiesAsync().ConfigureAwait(false);
                if (properties.CopyStatus.HasValue)
                {
                    await _copyStatusHandler.InvokeEvent(new CopyStatusEventArgs(
                        _dataTransfer.Id,
                        properties.CopyStatus.Value,
                        properties.CopyId,
                        ParseRangeTotalLength(properties.CopyProgress),
                        false,
                        _cancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await InvokeFailedArg(new Exception("Error: Get Properties request does not contain a copy status on the destination.")).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task PutBlockFromUri(
            long offset,
            long blockLength,
            long expectedLength)
        {
            try
            {
                await _destinationResource.CopyBlockFromUriAsync(
                    sourceResource: _sourceResource,
                    overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                    range: new HttpRange(offset, blockLength),
                    completeLength: expectedLength,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
                // Invoke event handler to keep track of all the stage blocks
                await _commitBlockHandler.InvokeEvent(
                    new StageChunkEventArgs(
                        _dataTransfer.Id,
                        true,
                        offset,
                        blockLength,
                        true,
                        _cancellationToken)).ConfigureAwait(false);
            }
            // If we fail to stage a block, we need to make sure the rest of the stage blocks are cancelled
            // (Core already performs the retry policy on the one stage block request
            // which means the rest are not worth to continue)
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await TriggerCancellation(StorageTransferStatus.None).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            when (_createMode == StorageResourceCreateMode.Overwrite
                    && ex.ErrorCode == "BlobAlreadyExists")
            {
                // For Block Blobs this is a one off case because we don't create the blob
                // before uploading to it.
                if (_createMode == StorageResourceCreateMode.Fail)
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
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task CompleteFileDownload()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(_cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                await DisposeHandlers().ConfigureAwait(false);

                // Update the transfer status
                await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // The file either does not exist any more, got moved, or renamed.
                await InvokeFailedArg(ex).ConfigureAwait(false);
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
            if (_copyStatusHandler != default)
            {
                _copyStatusHandler.Dispose();
            }
            if (_commitBlockHandler != default)
            {
                await _commitBlockHandler.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
