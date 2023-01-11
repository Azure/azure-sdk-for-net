// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// <param name="job"></param>
        /// <param name="partNumber"></param>
        public StreamToUriJobPart(StreamToUriTransferJob job, int partNumber)
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
                  cancellationTokenSource: job._cancellationTokenSource)
        {
        }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        public StreamToUriJobPart(
            StreamToUriTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource)
            : base(dataTransfer: job._dataTransfer,
                  partNumber: partNumber,
                  sourceResource: sourceResource,
                  destinationResource: destinationResource,
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
                  cancellationTokenSource: job._cancellationTokenSource)
        {
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeHandlers().ConfigureAwait(false);
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
                StorageResourceProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
                fileLength = properties.ContentLength;
            }
            catch (Exception ex)
            {
                // TODO: logging when given the event handler
                await InvokeFailedArg(ex).ConfigureAwait(false);
                return;
            }

            if (fileLength.HasValue)
            {
                long length = fileLength.Value;
                if (_initialTransferSize >= length)
                {
                    // If we can create the destination in one call
                    await CreateDestinationResource(length, length, true).ConfigureAwait(false);
                    return;
                }
                long blockSize = CalculateBlockSize(length);

                _commitBlockHandler = GetCommitController(
                    expectedLength: length,
                    blockSize: blockSize,
                    this,
                    _destinationResource.TransferType);

                await CreateDestinationResource(blockSize, length, false).ConfigureAwait(false);

                // If we cannot upload in one shot, initiate the parallel block uploader
                List<(long Offset, long Length)> rangeList = GetRangeList(blockSize, length);
                if (_destinationResource.TransferType == TransferType.Concurrent)
                {
                    await QueueStageBlockRequests(rangeList, length).ConfigureAwait(false);
                }
                else // Sequential
                {
                    // Queue paritioned block task
                    await QueueChunk(async () =>
                    await StageBlockInternal(
                        rangeList[0].Offset,
                        rangeList[0].Length,
                        length).ConfigureAwait(false)).ConfigureAwait(false);
                }
            }
            else
            {
                // TODO: logging when given the event handler
                await InvokeFailedArg(Errors.UnableToGetLength()).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Return whether we need to do more after creating the destination resource
        /// </summary>
        internal async Task<bool> CreateDestinationResource(long blockSize, long length, bool singleCall)
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
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
            // Do not continue if we need to skip or there was an error.
            return false;
        }

        /// <summary>
        /// Made to do the initial creation of the blob (if needed). And also
        /// to make an write if necessary.
        /// </summary>
        internal async Task InitialUploadCall(long blockSize, long expectedlength, bool singleCall)
        {
            try
            {
                if (singleCall)
                {
                    ReadStreamStorageResourceResult result = await _sourceResource.ReadStreamAsync().ConfigureAwait(false);

                    using Stream stream = result.Content;
                    await _destinationResource.WriteFromStreamAsync(
                            stream: stream,
                            overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                            position: 0,
                            streamLength: blockSize,
                            completeLength: expectedlength,
                            options: default,
                            cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);

                    // Set completion status to completed
                    await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
                }
                else
                {
                    Stream slicedStream = Stream.Null;
                    ReadStreamStorageResourceResult result = await _sourceResource.ReadStreamAsync(
                        position: 0,
                        length: blockSize,
                        cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                    using (Stream stream = result.Content)
                    {
                        slicedStream = await GetOffsetPartitionInternal(
                            stream,
                            (int)0,
                            (int)blockSize,
                            UploadArrayPool,
                            _cancellationTokenSource.Token).ConfigureAwait(false);
                        await _destinationResource.WriteFromStreamAsync(
                            stream: slicedStream,
                            streamLength: blockSize,
                            overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                            position: 0,
                            completeLength: expectedlength,
                            default,
                            _cancellationTokenSource.Token).ConfigureAwait(false);
                    }
                }
                ReportBytesWritten(blockSize);
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
        internal static CommitChunkHandler GetCommitController(
            long expectedLength,
            long blockSize,
            StreamToUriJobPart jobPart,
            TransferType transferType)
        => new CommitChunkHandler(
            expectedLength,
            blockSize,
            GetBlockListCommitHandlerBehaviors(jobPart),
            transferType);

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
                    cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                using (Stream stream = result.Content)
                {
                    slicedStream = await GetOffsetPartitionInternal(
                        stream,
                        (int)offset,
                        (int)blockLength,
                        UploadArrayPool,
                        _cancellationTokenSource.Token).ConfigureAwait(false);
                    await _destinationResource.WriteFromStreamAsync(
                        stream: slicedStream,
                        streamLength: blockLength,
                        overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                        position: offset,
                        completeLength: completeLength,
                        default,
                        _cancellationTokenSource.Token).ConfigureAwait(false);
                }
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
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task CompleteTransferAsync()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);

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

        private async Task QueueStageBlockRequests(List<(long Offset, long Size)> rangeList, long completeLength)
        {
            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in rangeList)
            {
                // Queue paritioned block task
                await QueueChunk(async () =>
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
        private static async Task<SlicedStream> GetOffsetPartitionInternal(
            Stream stream,
            int offset,
            int length,
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
