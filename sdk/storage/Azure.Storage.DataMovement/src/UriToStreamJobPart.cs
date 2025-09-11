// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Azure.Core;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class UriToStreamJobPart : JobPartInternal, IAsyncDisposable
    {
        public delegate Task CommitBlockTaskInternal(CancellationToken cancellationToken);
        public CommitBlockTaskInternal CommitBlockTask { get; internal set; }

        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private DownloadChunkHandler _downloadChunkHandler;

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private UriToStreamJobPart(
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
        private UriToStreamJobPart(
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
            UriToStreamJobPart part = new UriToStreamJobPart(
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
        public static UriToStreamJobPart CreateJobPartFromCheckpoint(
            TransferJobInternal job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            TransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationMode createPreference)
        {
            return new UriToStreamJobPart(
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
        ///
        /// Just start downloading using an initial range.  If it's a
        /// small blob, we'll get the whole thing in one shot.  If it's
        /// a large blob, we'll get its full size in Content-Range and
        /// can keep downloading it in segments.
        ///
        /// After this response comes back and there's more to download
        /// then we will trigger more to download since we now know the
        /// content length.
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // we can default the length to 0 because we know the destination is local and
            // does not require a length to be created.
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

                if (!_sourceResource.Length.HasValue)
                {
                    await UnknownLengthDownloadAsync().ConfigureAwait(false);
                }
                else
                {
                    await KnownLengthDownloadAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                // The file either does not exist any more, got moved, or renamed.
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        internal async Task UnknownLengthDownloadAsync()
        {
            try
            {
                StorageResourceReadStreamResult initialResult = default;
                try
                {
                    initialResult = await _sourceResource.ReadStreamAsync(
                        position: 0,
                        length: _initialTransferSize,
                        _cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                    // Range not accepted, we need to attempt to use a default range
                    // This can happen if the source is empty.
                    initialResult = await _sourceResource.ReadStreamAsync(
                        cancellationToken: _cancellationToken)
                        .ConfigureAwait(false);
                }

                long? initialLength = initialResult?.ContentLength;

                // There needs to be at least 1 chunk to create the blob even if the
                // length is 0 bytes.
                if (initialResult == default || (initialLength ?? 0) == 0)
                {
                    await QueueChunkToChannelAsync(ZeroLengthDownloadAsync).ConfigureAwait(false);
                    return;
                }

                // TODO: Change to use buffer instead of converting to stream
                long totalLength = initialResult.ResourceLength.Value;
                bool successfulInitialCopy = await CopyToStreamInternal(
                    offset: 0,
                    sourceLength: initialLength.Value,
                    source: initialResult.Content,
                    expectedLength: totalLength,
                    initial: true).ConfigureAwait(false);
                if (successfulInitialCopy)
                {
                    await ReportBytesWrittenAsync(initialLength.Value).ConfigureAwait(false);
                    if (totalLength == initialLength)
                    {
                        // Complete download since it was done in one go
                        await QueueCompleteFileDownload().ConfigureAwait(false);
                    }
                    else
                    {
                        await QueueChunksToChannel(initialLength.Value, totalLength).ConfigureAwait(false);
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

        internal async Task KnownLengthDownloadAsync()
        {
            long totalLength = _sourceResource.Length.Value;
            if (totalLength == 0)
            {
                await QueueChunkToChannelAsync(ZeroLengthDownloadAsync).ConfigureAwait(false);
            }
            // Download with a single GET
            else if (_initialTransferSize >= totalLength)
            {
                await QueueChunkToChannelAsync(
                    async () =>
                    await DownloadSingleAsync(totalLength).ConfigureAwait(false))
                    .ConfigureAwait(false);
            }
            // Download in chunks
            else
            {
                await QueueChunksToChannel(0, totalLength).ConfigureAwait(false);
            }
        }

        private async Task QueueChunksToChannel(long initialLength, long totalLength)
        {
            // Create Download Chunk event handler to manage when the ranges finish downloading
            _downloadChunkHandler = new DownloadChunkHandler(
                currentTransferred: initialLength,
                expectedLength: totalLength,
                GetDownloadChunkHandlerBehaviors(this),
                _cancellationToken);

            // Fill the queue with tasks to download each of the remaining
            // ranges in the file
            _queueingTasks = true;
            try
            {
                int chunkCount = 0;
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength, _transferChunkSize))
                {
                    CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

                    // Add the next Task (which will start the download but
                    // return before it's completed downloading)
                    await QueueChunkToChannelAsync(
                        async () =>
                        await DownloadChunkAsync(range: httpRange).ConfigureAwait(false))
                        .ConfigureAwait(false);
                    chunkCount++;
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

        internal async Task CompleteFileDownloadAsync()
        {
            try
            {
                CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(
                    overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                await DisposeHandlersAsync().ConfigureAwait(false);

                // Update the transfer status
                await OnTransferStateChangedAsync(TransferState.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        private async Task DownloadSingleAsync(long totalLength)
        {
            // To prevent requesting a range that is invalid when
            // we already know the length we can just make one get blob request.
            StorageResourceReadStreamResult result = await _sourceResource
                .ReadStreamAsync(length: totalLength, cancellationToken: _cancellationToken)
                .ConfigureAwait(false);

            long downloadLength = result.ContentLength.Value;
            // This should not occur but add a check just in case
            if (downloadLength != totalLength)
            {
                throw Errors.SingleDownloadLengthMismatch(totalLength, downloadLength);
            }

            bool successfulCopy = await CopyToStreamInternal(
                offset: 0,
                sourceLength: downloadLength,
                source: result.Content,
                expectedLength: totalLength,
                initial: true).ConfigureAwait(false);
            if (successfulCopy)
            {
                await ReportBytesWrittenAsync(downloadLength).ConfigureAwait(false);
                await CompleteFileDownloadAsync().ConfigureAwait(false);
            }
        }

        private async Task DownloadChunkAsync(HttpRange range)
        {
            try
            {
                // If the job part is not InProgress, we should just stop processing any queued chunks.
                if (JobPartStatus.State != TransferState.InProgress)
                {
                    return;
                }

                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
                    range.Offset,
                    (long)range.Length,
                    _cancellationToken).ConfigureAwait(false);

                // Stream the data from the network before queueing disk IO.
                MemoryStream content = new((int)result.ContentLength.Value);
                using (Stream dataStream = result.Content)
                {
                    await dataStream.CopyToAsync(
                        content,
                        DataMovementConstants.DefaultStreamCopyBufferSize,
                        _cancellationToken).ConfigureAwait(false);
                }
                content.Position = 0;

                // The chunk handler may have been disposed in failure case
                if (_downloadChunkHandler != null)
                {
                    await _downloadChunkHandler.QueueChunkAsync(new QueueDownloadChunkArgs(
                        offset: range.Offset,
                        length: (long)range.Length,
                        content: content)).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
            }
        }

        public async Task<bool> CopyToStreamInternal(
            long offset,
            long sourceLength,
            Stream source,
            long expectedLength,
            bool initial)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            try
            {
                // TODO: change to custom offset based on chunk offset
                await _destinationResource.CopyFromStreamAsync(
                    stream: source,
                    overwrite: _createMode == StorageResourceCreationMode.OverwriteIfExists,
                    streamLength: sourceLength,
                    completeLength: expectedLength,
                    options: new StorageResourceWriteToOffsetOptions()
                    {
                        Position = offset,
                        Initial = initial,
                    },
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch (IOException ex)
            when (_createMode == StorageResourceCreationMode.SkipIfExists &&
                ex.Message.Contains("Cannot overwrite file."))
            {
                // Skip file that already exists on the destination.
                await InvokeSkippedArgAsync().ConfigureAwait(false);
            }
            return false;
        }

        private static DownloadChunkHandler.Behaviors GetDownloadChunkHandlerBehaviors(UriToStreamJobPart jobPart)
        {
            return new DownloadChunkHandler.Behaviors()
            {
                CopyToDestinationFile = jobPart.CopyToStreamInternal,
                ReportProgressInBytes = jobPart.ReportBytesWrittenAsync,
                InvokeFailedHandler = jobPart.InvokeFailedArgAsync,
                QueueCompleteFileDownload = jobPart.QueueCompleteFileDownload
            };
        }

        private Task QueueCompleteFileDownload()
        {
            return QueueChunkToChannelAsync(CompleteFileDownloadAsync);
        }

        private static IEnumerable<HttpRange> GetRanges(long initialLength, long totalLength, long rangeSize)
        {
            for (long offset = initialLength; offset < totalLength; offset += rangeSize)
            {
                yield return new HttpRange(offset, Math.Min(totalLength - offset, rangeSize));
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
            if (_downloadChunkHandler != default)
            {
                await _downloadChunkHandler.DisposeAsync().ConfigureAwait(false);
                _downloadChunkHandler = null;
            }
        }

        private async Task ZeroLengthDownloadAsync()
        {
            // We just need to at minimum create the file
            bool successfulCreation = await CopyToStreamInternal(
                offset: 0,
                sourceLength: 0,
                source: default,
                expectedLength: 0,
                initial: true).ConfigureAwait(false);
            if (successfulCreation)
            {
                await CompleteFileDownloadAsync().ConfigureAwait(false);
            }
            else
            {
                await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
            }
        }
    }
}
