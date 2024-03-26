// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Buffers;
using Azure.Storage.Shared;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    internal class StreamToUriJobPart : JobPartInternal, IDisposable
    {
        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CommitChunkHandler _commitBlockHandler;

        /// <summary>
        /// Creating job part based on a single transfer job
        /// </summary>
        private StreamToUriJobPart(StreamToUriTransferJob job, int partNumber)
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
        private StreamToUriJobPart(
            StreamToUriTransferJob job,
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
        private StreamToUriJobPart(
            StreamToUriTransferJob job,
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
        public static async Task<StreamToUriJobPart> CreateJobPartAsync(
            StreamToUriTransferJob job,
            int partNumber)
        {
            // Create Job Part file as we're initializing the job part
            StreamToUriJobPart part = new StreamToUriJobPart(job, partNumber);
            await part.AddJobPartToCheckpointerAsync().ConfigureAwait(false);
            return part;
        }

        /// <summary>
        /// Called when creating a job part from a container transfer.
        /// </summary>
        public static async Task<StreamToUriJobPart> CreateJobPartAsync(
            StreamToUriTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            long? length = default)
        {
            // Create Job Part file as we're initializing the job part
            StreamToUriJobPart part = new StreamToUriJobPart(
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
        public static StreamToUriJobPart CreateJobPartFromCheckpoint(
            StreamToUriTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationPreference createPreference)
        {
            return new StreamToUriJobPart(
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
        /// Processes the job to job parts
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // Attempt to get the length, it's possible the file could
            // not be accessible (or does not exist).
            string operationName = $"{nameof(TransferManager.StartTransferAsync)}";
            await OnTransferStateChangedAsync(DataTransferState.InProgress).ConfigureAwait(false);
            long? fileLength = default;
            try
            {
                StorageResourceItemProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                fileLength = properties.ResourceLength;

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
                                singleCall: true,
                                sourceProperties: properties).ConfigureAwait(false)).ConfigureAwait(false);
                        return;
                    }
                    long blockSize = _transferChunkSize;

                    _commitBlockHandler = GetCommitController(
                        expectedLength: length,
                        blockSize: blockSize,
                        this,
                        _destinationResource.TransferType,
                        properties);

                    bool destinationCreated = await CreateDestinationResource(
                        blockSize,
                        length,
                        false,
                        properties).ConfigureAwait(false);
                    if (destinationCreated)
                    {
                        // If we cannot upload in one shot, initiate the parallel block uploader
                        List<(long Offset, long Length)> rangeList = GetRangeList(blockSize, length);
                        if (_destinationResource.TransferType == DataTransferOrder.Unordered)
                        {
                            await QueueStageBlockRequests(rangeList, length, properties).ConfigureAwait(false);
                        }
                        else // Sequential
                        {
                            // Queue the first partitioned block task
                            await QueueStageBlockRequest(
                                rangeList[0].Offset,
                                rangeList[0].Length,
                                length,
                                properties).ConfigureAwait(false);
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
        private async Task<bool> CreateDestinationResource(
            long blockSize,
            long length,
            bool singleCall,
            StorageResourceItemProperties sourceProperties)
        {
            try
            {
                await InitialUploadCall(
                    blockSize,
                    length,
                    singleCall,
                    sourceProperties).ConfigureAwait(false);
                // Whether or not we continue is up to whether this was single put call or not.
                return !singleCall;
            }
            catch (RequestFailedException r)
            when (r.ErrorCode == "BlobAlreadyExists" && _createMode == StorageResourceCreationPreference.SkipIfExists)
            {
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (InvalidOperationException i)
            when (i.Message.Contains("Cannot overwrite file.") && _createMode == StorageResourceCreationPreference.SkipIfExists)
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
        private async Task InitialUploadCall(
            long blockSize,
            long expectedLength,
            bool singleCall,
            StorageResourceItemProperties sourceProperties)
        {
            if (singleCall)
            {
                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                using Stream stream = result.Content;
                await _destinationResource.CopyFromStreamAsync(
                        stream: stream,
                        overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                        streamLength: blockSize,
                        completeLength: expectedLength,
                        options: new()
                        {
                            SourceProperties = sourceProperties
                        },
                        cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Report bytes written before completion
                ReportBytesWritten(blockSize);

                // Set completion status to completed
                await OnTransferStateChangedAsync(DataTransferState.Completed).ConfigureAwait(false);
            }
            else
            {
                Stream slicedStream = Stream.Null;
                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
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
                    await _destinationResource.CopyFromStreamAsync(
                        stream: slicedStream,
                        streamLength: blockSize,
                        overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                        completeLength: expectedLength,
                        options: new()
                        {
                            SourceProperties = sourceProperties,
                        },
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
                }

                ReportBytesWritten(blockSize);
            }
        }

        #region CommitChunkController
        internal CommitChunkHandler GetCommitController(
            long expectedLength,
            long blockSize,
            StreamToUriJobPart jobPart,
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
            StreamToUriJobPart jobPart)
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

        internal async Task StageBlockInternal(
            long offset,
            long blockLength,
            long completeLength,
            StorageResourceItemProperties sourceProperties)
        {
            try
            {
                Stream slicedStream = Stream.Null;
                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
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
                    await _destinationResource.CopyFromStreamAsync(
                        stream: slicedStream,
                        streamLength: blockLength,
                        overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                        completeLength: completeLength,
                        options: new StorageResourceWriteToOffsetOptions()
                        {
                            Position = offset,
                            SourceProperties = sourceProperties
                        },
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
                }

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

        internal async Task CompleteTransferAsync(StorageResourceItemProperties sourceProperties)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

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

        private async Task QueueStageBlockRequests(
            List<(long Offset, long Size)> rangeList,
            long completeLength,
            StorageResourceItemProperties sourceProperties)
        {
            _queueingTasks = true;
            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in rangeList)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                // Queue partitioned block task
                await QueueStageBlockRequest(
                    block.Offset,
                    block.Length,
                    completeLength,
                    sourceProperties).ConfigureAwait(false);
            }

            _queueingTasks = false;
            await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
        }

        private Task QueueStageBlockRequest(
            long offset,
            long blockSize,
            long expectedLength,
            StorageResourceItemProperties sourceProperties)
        {
            return QueueChunkToChannelAsync(
                async () =>
                await StageBlockInternal(
                    offset,
                    blockSize,
                    expectedLength,
                    sourceProperties).ConfigureAwait(false));
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
    }
}
