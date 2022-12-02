// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceJobPart : JobPartInternal
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
        /// <param name="job"></param>
        /// <param name="partNumber"></param>
        public ServiceToServiceJobPart(ServiceToServiceTransferJob job, int partNumber)
            : base(job._dataTransfer,
                  partNumber,
                  job._sourceResource,
                  job._destinationResource,
                  job._maximumTransferChunkSize,
                  job._initialTransferSize,
                  job._errorHandling,
                  job._createMode,
                  job._checkpointer,
                  job.UploadArrayPool,
                  job.GetJobPartStatus(),
                  job.TransferStatusEventHandler,
                  job.TransferFailedEventHandler,
                  job._cancellationTokenSource)
        {
        }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="partNumber"></param>
        /// <param name="length"></param>
        public ServiceToServiceJobPart(
            ServiceToServiceTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            long? length)
            : base(job._dataTransfer,
                  partNumber,
                  sourceResource,
                  destinationResource,
                  job._maximumTransferChunkSize,
                  job._initialTransferSize,
                  job._errorHandling,
                  job._createMode,
                  job._checkpointer,
                  job.UploadArrayPool,
                  job.GetJobPartStatus(),
                  job.TransferStatusEventHandler,
                  job.TransferFailedEventHandler,
                  job._cancellationTokenSource,
                  length)
        { }

        public override async Task ProcessPartToChunkAsync()
        {
            await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);
            if (_destinationResource.ServiceCopyMethod == TransferCopyMethod.AsyncCopy)
            {
                // Perform a one call method to copy the resource.
                await StartServiceAsyncCopy().ConfigureAwait(false);
            }
            else // For now we default to sync copy
            {
                // Attempt to get the length, it's possible the file could
                // not be accesible (or does not exist).
                long? fileLength = _sourceResource.Length;
                if (!fileLength.HasValue)
                {
                    try
                    {
                        StorageResourceProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
                        fileLength = properties.ContentLength;
                    }
                    catch (Exception ex)
                    {
                        // TODO: logging when given the event handler
                        await InvokeFailedArg(ex).ConfigureAwait(false);
                        return;
                    }
                }

                string operationName = $"{nameof(TransferManager.StartTransferAsync)}";
                if (fileLength.HasValue)
                {
                    long length = fileLength.Value;
                    if (length == 0)
                    {
                        // Copying over an empty blob is easier if we did an async copy
                        await StartServiceAsyncCopy().ConfigureAwait(false);
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
                        List<(long Offset, long Length)> commitBlockList = GetCommitBlockList(blockSize, length);
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
                else
                {
                    await InvokeFailedArg(Errors.UnableToGetLength()).ConfigureAwait(false);
                }
            }
        }

        internal async Task StartServiceAsyncCopy()
        {
            try
            {
                await _destinationResource.CopyFromUriAsync(
                        sourceResource: _sourceResource,
                        overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                        cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                _copyStatusHandler = GetCopyStatusController(this);
                await CopyStatusCheckAsync().ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreateMode.Overwrite
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
                cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);

                if (blockSize == length)
                {
                    await CompleteTransferAsync().ConfigureAwait(false);
                    return false;
                }
                return true;
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreateMode.Overwrite
                 && exception.ErrorCode == "BlobAlreadyExists")
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (IOException exception)
            when (_createMode == StorageResourceCreateMode.Overwrite
                && exception.Message.Contains("Cannot overwite file"))
            {
                // Skip this file
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (Exception ex)
            when (_createMode == StorageResourceCreateMode.Fail)
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
                UpdateTransferStatus = async (status)
                    => await jobPart.OnTransferStatusChanged(status).ConfigureAwait(false)
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
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);

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

        internal async Task CopyStatusCheckAsync()
        {
            // Determine the polling time we need to wait until we can queue
            // up the next GetProperties call.
            TimeSpan suggestedInterval = TimeSpan.FromSeconds(DataMovementConstants.StatusCheckInSec);
            await Task.Delay(suggestedInterval, _cancellationTokenSource.Token).ConfigureAwait(false);

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
                        _cancellationTokenSource.Token)).ConfigureAwait(false);
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
                        _cancellationTokenSource.Token)).ConfigureAwait(false);
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
                    cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                // Invoke event handler to keep track of all the stage blocks
                await _commitBlockHandler.InvokeEvent(
                    new StageChunkEventArgs(
                        _dataTransfer.Id,
                        true,
                        offset,
                        blockLength,
                        true,
                        _cancellationTokenSource.Token)).ConfigureAwait(false);
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
    }
}
