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
using Azure.Storage.Common;
using System.Linq;

namespace Azure.Storage.DataMovement
{
    internal class StreamToUriJobPart : JobPartInternal
    {
        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CommitChunkHandler _commitBlockHandler;

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private StreamToUriJobPart(
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
        private StreamToUriJobPart(
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
            StreamToUriJobPart part = new StreamToUriJobPart(
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
        public static StreamToUriJobPart CreateJobPartFromCheckpoint(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            TransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationMode createPreference)
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
        /// Processes the job part to chunks
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // Attempt to get the length, it's possible the file could
            // not be accessible (or does not exist).
            string operationName = $"{nameof(TransferManager.StartTransferAsync)}";
            try
            {
                // Continue only if job is in progress
                if (!await CheckTransferStateBeforeRunning().ConfigureAwait(false))
                {
                    return;
                }
                await OnTransferStateChangedAsync(TransferState.InProgress).ConfigureAwait(false);

                StorageResourceItemProperties sourceProperties =
                    await _sourceResource.GetPropertiesAsync(_cancellationToken).ConfigureAwait(false);
                if (!sourceProperties.ResourceLength.HasValue)
                {
                    await InvokeFailedArgAsync(Errors.UnableToGetLength()).ConfigureAwait(false);
                    return;
                }
                long length = sourceProperties.ResourceLength.Value;

                if (_initialTransferSize >= length)
                {
                    // If we can create the destination in one call
                    await QueueChunkToChannelAsync(
                        async () =>
                        await CreateDestinationResource(
                            blockSize: length,
                            length: length,
                            singleCall: true,
                            sourceProperties: sourceProperties).ConfigureAwait(false)).ConfigureAwait(false);
                    return;
                }
                long blockSize = _transferChunkSize;
                _commitBlockHandler = new CommitChunkHandler(
                    expectedLength: length,
                    blockSize: blockSize,
                    GetBlockListCommitHandlerBehaviors(this),
                    _destinationResource.TransferType,
                    sourceProperties,
                    _cancellationToken);

                bool destinationCreated = await CreateDestinationResource(
                    blockSize,
                    length,
                    false,
                    sourceProperties).ConfigureAwait(false);
                if (destinationCreated)
                {
                    // If we cannot upload in one shot, initiate the parallel block uploader
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
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates the destination resource and performs the first copy call.
        /// Returns false if the copy is complete or this operation failed.
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
            when (r.ErrorCode == "BlobAlreadyExists" && _createMode == StorageResourceCreationMode.SkipIfExists)
            {
                await InvokeSkippedArgAsync().ConfigureAwait(false);
            }
            catch (InvalidOperationException i)
            when (i.Message.Contains("Cannot overwrite file.") && _createMode == StorageResourceCreationMode.SkipIfExists)
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

                using (Stream stream = result.Content)
                {
                    await _destinationResource.CopyFromStreamAsync(
                        stream: stream,
                        overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                        streamLength: blockSize,
                        completeLength: expectedLength,
                        options: new()
                        {
                            SourceProperties = sourceProperties
                        },
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
                }

                // Report bytes written before completion
                await ReportBytesWrittenAsync(blockSize).ConfigureAwait(false);
                await CompleteTransferAsync(sourceProperties).ConfigureAwait(false);
                await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
            }
            else
            {
                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
                    position: 0,
                    length: blockSize,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                using (Stream contentStream = result.Content)
                using (Stream slicedStream = await GetOffsetPartitionInternal(
                    contentStream,
                    0L,
                    blockSize,
                    UploadArrayPool,
                    _cancellationToken).ConfigureAwait(false))
                {
                    await _destinationResource.CopyFromStreamAsync(
                        stream: slicedStream,
                        streamLength: blockSize,
                        overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                        completeLength: expectedLength,
                        options: new()
                        {
                            SourceProperties = sourceProperties,
                        },
                        cancellationToken: _cancellationToken).ConfigureAwait(false);
                }

                await ReportBytesWrittenAsync(blockSize).ConfigureAwait(false);
            }
        }

        #region CommitChunkController
        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            StreamToUriJobPart jobPart)
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

        internal async Task StageBlockInternal(
            long offset,
            long blockLength,
            long completeLength,
            StorageResourceItemProperties sourceProperties)
        {
            try
            {
                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
                    position: offset,
                    length: blockLength,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                using (Stream contentStream = result.Content)
                using (Stream slicedStream = await GetOffsetPartitionInternal(
                    contentStream,
                    offset,
                    blockLength,
                    UploadArrayPool,
                    _cancellationToken).ConfigureAwait(false))
                {
                    await _destinationResource.CopyFromStreamAsync(
                        stream: slicedStream,
                        streamLength: blockLength,
                        overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
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
                    // Queue result to increment bytes transferred and check for completion
                    await _commitBlockHandler.QueueChunkAsync(new QueueStageChunkArgs(
                        offset: offset,
                        bytesTransferred: blockLength)).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        internal Task QueueCompleteTransferAsync(StorageResourceItemProperties sourceProperties) =>
            QueueChunkToChannelAsync(() => CompleteTransferAsync(sourceProperties));

        internal async Task CompleteTransferAsync(StorageResourceItemProperties sourceProperties)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            // Apply necessary transfer completions on the destination.
            await _destinationResource.CompleteTransferAsync(
                overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                completeTransferOptions: new() { SourceProperties = sourceProperties },
                cancellationToken: _cancellationToken).ConfigureAwait(false);

            // Dispose the handlers
            await CleanUpHandlersAsync().ConfigureAwait(false);

            // Set completion status to completed
            await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
        }

        private async Task QueueStageBlockRequests(
            IEnumerable<(long Offset, long Size)> ranges,
            long completeLength,
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
                        completeLength,
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

        public override async Task InvokeSkippedArgAsync()
        {
            await base.InvokeSkippedArgAsync().ConfigureAwait(false);
        }

        public override async Task InvokeFailedArgAsync(Exception ex)
        {
            await base.InvokeFailedArgAsync(ex).ConfigureAwait(false);
        }

        public override async Task CleanUpHandlersAsync()
        {
            if (_commitBlockHandler != default)
            {
                await _commitBlockHandler.CleanUpAsync().ConfigureAwait(false);
                _commitBlockHandler = null;
            }
        }
    }
}
