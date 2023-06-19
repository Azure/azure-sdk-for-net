﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.DataMovement.Models;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Buffers;
using Azure.Storage.Shared;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    internal class StreamToUriJobPart : JobPartInternal, IAsyncDisposable
    {
        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CommitChunkHandler _commitBlockHandler;

        /// <summary>
        /// Creating job part based on a single transfer job
        /// </summary>
        private StreamToUriJobPart(
            StreamToUriTransferJob job,
            int partNumber,
            bool isFinalPart)
            : base(dataTransfer: job._dataTransfer,
                  partNumber: partNumber,
                  sourceResource: job._sourceResource,
                  destinationResource: job._destinationResource,
                  maximumTransferChunkSize: job._maximumTransferChunkSize,
                  initialTransferSize: job._initialTransferSize,
                  errorHandling: job._errorHandling,
                  createMode: job._createMode,
                  checkpointer: job._checkpointer,
                  progressTracker: job._progressTracker,
                  arrayPool: job.UploadArrayPool,
                  isFinalPart: isFinalPart,
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
        private StreamToUriJobPart(
            StreamToUriTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            bool isFinalPart,
            StorageTransferStatus jobPartStatus = StorageTransferStatus.Queued,
            long? length = default)
            : base(dataTransfer: job._dataTransfer,
                  partNumber: partNumber,
                  sourceResource: sourceResource,
                  destinationResource: destinationResource,
                  maximumTransferChunkSize: job._maximumTransferChunkSize,
                  initialTransferSize: job._initialTransferSize,
                  errorHandling: job._errorHandling,
                  createMode: job._createMode,
                  checkpointer: job._checkpointer,
                  progressTracker: job._progressTracker,
                  arrayPool: job.UploadArrayPool,
                  isFinalPart: isFinalPart,
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

        public static async Task<StreamToUriJobPart> CreateJobPartAsync(
            StreamToUriTransferJob job,
            int partNumber,
            bool isFinalPart)
        {
            // Create Job Part file as we're intializing the job part
            StreamToUriJobPart part = new StreamToUriJobPart(
                job: job,
                partNumber: partNumber,
                isFinalPart: isFinalPart);
            await part.AddJobPartToCheckpointerAsync(
                chunksTotal: 1, // For now we only store 1 chunk
                isFinalPart: isFinalPart).ConfigureAwait(false);
            return part;
        }

        public static async Task<StreamToUriJobPart> CreateJobPartAsync(
            StreamToUriTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            bool isFinalPart,
            StorageTransferStatus jobPartStatus = default,
            long? length = default,
            bool partPlanFileExists = false)
        {
            // Create Job Part file as we're intializing the job part
            StreamToUriJobPart part = new StreamToUriJobPart(
                job: job,
                partNumber: partNumber,
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                length: length,
                isFinalPart: isFinalPart);
            if (!partPlanFileExists)
            {
                await part.AddJobPartToCheckpointerAsync(
                    chunksTotal: 1,
                    isFinalPart: isFinalPart).ConfigureAwait(false); // For now we only store 1 chunk
            }
            return part;
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // Attempt to get the length, it's possible the file could
            // not be accesible (or does not exist).
            string operationName = $"{nameof(TransferManager.StartTransferAsync)}";
            await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);
            long? fileLength = default;
            try
            {
                StorageResourceProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                fileLength = properties.ContentLength;

                if (fileLength.HasValue)
                {
                    long length = fileLength.Value;
                    if (_initialTransferSize >= length)
                    {
                        // If we can create the destination in one call
                        await QueueChunkToChannelAsync(
                            async () =>
                            await CreateDestinationResource(
                                blockSize: length,
                                length: length,
                                singleCall: true).ConfigureAwait(false)).ConfigureAwait(false);
                        return;
                    }
                    long blockSize = CalculateBlockSize(length);

                    _commitBlockHandler = GetCommitController(
                        expectedLength: length,
                        blockSize: blockSize,
                        this,
                        _destinationResource.TransferType);

                    bool destinationCreated = await CreateDestinationResource(blockSize, length, false).ConfigureAwait(false);
                    if (destinationCreated)
                    {
                        // If we cannot upload in one shot, initiate the parallel block uploader
                        List<(long Offset, long Length)> rangeList = GetRangeList(blockSize, length);
                        if (_destinationResource.TransferType == TransferType.Concurrent)
                        {
                            await QueueStageBlockRequests(rangeList, length).ConfigureAwait(false);
                        }
                        else // Sequential
                        {
                            // Queue paritioned block task
                            await QueueChunkToChannelAsync(
                                async () =>
                                await StageBlockInternal(
                                    rangeList[0].Offset,
                                    rangeList[0].Length,
                                    length).ConfigureAwait(false)).ConfigureAwait(false);
                        }
                    }
                }
                else
                {
                    // TODO: logging when given the event handler
                    await InvokeFailedArg(Errors.UnableToGetLength()).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Return whether we need to do more after creating the destination resource
        /// </summary>
        private async Task<bool> CreateDestinationResource(long blockSize, long length, bool singleCall)
        {
            try
            {
                await InitialUploadCall(blockSize, length, singleCall).ConfigureAwait(false);
                // Whether or not we continue is up to whether this was single put call or not.
                return !singleCall;
            }
            catch (RequestFailedException exception)
                when (_createMode == StorageResourceCreateMode.Skip
                    && exception.ErrorCode == "BlobAlreadyExists")
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            // Do not continue if we need to skip or there was an error.
            return false;
        }

        /// <summary>
        /// Made to do the initial creation of the blob (if needed). And also
        /// to make an write if necessary.
        /// </summary>
        private async Task InitialUploadCall(long blockSize, long expectedLength, bool singleCall)
        {
            try
            {
                if (singleCall)
                {
                    ReadStreamStorageResourceResult result = await _sourceResource.ReadStreamAsync(
                        cancellationToken: _cancellationToken).ConfigureAwait(false);

                    using Stream stream = result.Content;
                    await _destinationResource.WriteFromStreamAsync(
                            stream: stream,
                            overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                            position: 0,
                            streamLength: blockSize,
                            completeLength: expectedLength,
                            options: default,
                            cancellationToken: _cancellationToken).ConfigureAwait(false);

                    // Report bytes written before completion
                    ReportBytesWritten(blockSize);

                    // Set completion status to completed
                    await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
                }
                else
                {
                    Stream slicedStream = Stream.Null;
                    ReadStreamStorageResourceResult result = await _sourceResource.ReadStreamAsync(
                        position: 0,
                        length: blockSize,
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
                    using (Stream stream = result.Content)
                    {
                        slicedStream = await GetOffsetPartitionInternal(
                            stream,
                            0L,
                            blockSize,
                            UploadArrayPool,
                            _cancellationToken).ConfigureAwait(false);
                        await _destinationResource.WriteFromStreamAsync(
                            stream: slicedStream,
                            streamLength: blockSize,
                            overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                            position: 0,
                            completeLength: expectedLength,
                            default,
                            _cancellationToken).ConfigureAwait(false);
                    }

                    ReportBytesWritten(blockSize);
                }
            }
            catch (RequestFailedException ex)
            when (ex.ErrorCode == "BlobAlreadyExists" && _createMode == StorageResourceCreateMode.Skip)
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        #region CommitChunkController
        internal CommitChunkHandler GetCommitController(
            long expectedLength,
            long blockSize,
            StreamToUriJobPart jobPart,
            TransferType transferType)
        => new CommitChunkHandler(
            expectedLength,
            blockSize,
            GetBlockListCommitHandlerBehaviors(jobPart),
            transferType,
            _cancellationToken);

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            StreamToUriJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                QueuePutBlockTask = async (long offset, long blockSize, long expectedLength) => await jobPart.StageBlockInternal(offset, blockSize, expectedLength).ConfigureAwait(false),
                QueueCommitBlockTask = async () => await jobPart.CompleteTransferAsync().ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) =>
                    jobPart.ReportBytesWritten(bytesWritten),
                InvokeFailedHandler = async (ex) => await jobPart.InvokeFailedArg(ex).ConfigureAwait(false),
            };
        }
        #endregion

        internal async Task StageBlockInternal(
            long offset,
            long blockLength,
            long completeLength)
        {
            try
            {
                Stream slicedStream = Stream.Null;
                ReadStreamStorageResourceResult result = await _sourceResource.ReadStreamAsync(
                    position: offset,
                    length: blockLength,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
                using (Stream stream = result.Content)
                {
                    slicedStream = await GetOffsetPartitionInternal(
                        stream,
                        offset,
                        blockLength,
                        UploadArrayPool,
                        _cancellationToken).ConfigureAwait(false);
                    await _destinationResource.WriteFromStreamAsync(
                        stream: slicedStream,
                        streamLength: blockLength,
                        overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                        position: offset,
                        completeLength: completeLength,
                        default,
                        _cancellationToken).ConfigureAwait(false);
                }
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

        internal async Task CompleteTransferAsync()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            // Apply necessary transfer completions on the destination.
            await _destinationResource.CompleteTransferAsync(
                overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                cancellationToken: _cancellationToken).ConfigureAwait(false);

            // Dispose the handlers
            await DisposeHandlers().ConfigureAwait(false);

            // Set completion status to completed
            await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
        }

        private async Task QueueStageBlockRequests(List<(long Offset, long Size)> rangeList, long completeLength)
        {
            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in rangeList)
            {
                // Queue paritioned block task
                await QueueChunkToChannelAsync(
                    async () =>
                    await StageBlockInternal(
                    block.Offset,
                    block.Length,
                    completeLength).ConfigureAwait(false)).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets a partition from the current location of the given stream.
        ///
        /// This partition is buffered and it is safe to get many before using any of them.
        /// </summary>
        /// <param name="stream">
        /// Stream to buffer a partition from.
        /// </param>
        /// <param name="offset">
        /// Minimum amount of data to wait on before finalizing buffer.
        /// </param>
        /// <param name="length">
        /// Max amount of data to buffer before cutting off for the next.
        /// </param>
        /// <param name="arrayPool">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        /// <returns>
        /// Task containing the buffered stream partition.
        /// </returns>
        private static async Task<Stream> GetOffsetPartitionInternal(
            Stream stream,
            long offset,
            long length,
            ArrayPool<byte> arrayPool,
            CancellationToken cancellationToken)
        {
            return await PartitionedStream.BufferStreamPartitionInternal(
                stream: stream,
                minCount: length,
                maxCount: length,
                absolutePosition: offset,
                arrayPool: arrayPool,
                maxArrayPoolRentalSize: default,
                async: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);
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
    }
}
