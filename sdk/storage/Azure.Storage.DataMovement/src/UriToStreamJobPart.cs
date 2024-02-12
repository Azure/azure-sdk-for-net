// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    internal class UriToStreamJobPart : JobPartInternal, IDisposable
    {
        public delegate Task CommitBlockTaskInternal(CancellationToken cancellationToken);
        public CommitBlockTaskInternal CommitBlockTask { get; internal set; }

        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private DownloadChunkHandler _downloadChunkHandler;

        /// <summary>
        /// Creating job part based on a single transfer job
        /// </summary>
        private UriToStreamJobPart(
            UriToStreamTransferJob job,
            int partNumber)
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
        { }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private UriToStreamJobPart(
            UriToStreamTransferJob job,
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
        private UriToStreamJobPart(
            UriToStreamTransferJob job,
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
        public static async Task<UriToStreamJobPart> CreateJobPartAsync(
            UriToStreamTransferJob job,
            int partNumber)
        {
            // Create Job Part file as we're initializing the job part
            UriToStreamJobPart part = new UriToStreamJobPart(job, partNumber);
            await part.AddJobPartToCheckpointerAsync().ConfigureAwait(false);
            return part;
        }

        /// <summary>
        /// Called when creating a job part from a container transfer.
        /// </summary>
        public static async Task<UriToStreamJobPart> CreateJobPartAsync(
            UriToStreamTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            long? length = default)
        {
            // Create Job Part file as we're initializing the job part
            UriToStreamJobPart part = new UriToStreamJobPart(
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
        public static UriToStreamJobPart CreateJobPartFromCheckpoint(
            UriToStreamTransferJob job,
            int partNumber,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferStatus jobPartStatus,
            long initialTransferSize,
            long transferChunkSize,
            StorageResourceCreationPreference createPreference)
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
        /// Processes the job to job parts
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
            await OnTransferStateChangedAsync(DataTransferState.InProgress).ConfigureAwait(false);

            try
            {
                if (!_sourceResource.Length.HasValue)
                {
                    await UnknownDownloadInternal().ConfigureAwait(false);
                }
                else
                {
                    await LengthKnownDownloadInternal().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                // The file either does not exist any more, got moved, or renamed.
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task UnknownDownloadInternal()
        {
            Task<StorageResourceReadStreamResult> initialTask = _sourceResource.ReadStreamAsync(
                        position: 0,
                        length: _initialTransferSize,
                        _cancellationToken);

            try
            {
                StorageResourceReadStreamResult initialResult = default;
                try
                {
                    initialResult = await initialTask.ConfigureAwait(false);
                }
                catch
                {
                    // Range not accepted, we need to attempt to use a default range
                    initialResult = await _sourceResource.ReadStreamAsync(
                        cancellationToken: _cancellationToken)
                        .ConfigureAwait(false);
                }
                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                long? initialLength = initialResult?.ContentLength;

                // There needs to be at least 1 chunk to create the blob even if the
                // length is 0 bytes.
                if (initialResult == default || (initialLength ?? 0) == 0)
                {
                    await CreateZeroLengthDownload().ConfigureAwait(false);
                    return;
                }

                // TODO: Change to use buffer instead of converting to stream
                long totalLength = initialResult.ResourceLength.Value;
                bool successfulInitialCopy = await CopyToStreamInternal(
                    offset: 0,
                    sourceLength: initialLength.Value,
                    source: initialResult.Content,
                    expectedLength: totalLength).ConfigureAwait(false);
                if (successfulInitialCopy)
                {
                    ReportBytesWritten(initialLength.Value);
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
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task LengthKnownDownloadInternal()
        {
            long totalLength = _sourceResource.Length.Value;
            if (totalLength == 0)
            {
                await CreateZeroLengthDownload().ConfigureAwait(false);
            }
            // Download with a single GET
            else if (_initialTransferSize >= totalLength)
            {
                // To prevent requesting a range that is invalid when
                // we already know the length we can just make one get blob request.
                StorageResourceReadStreamResult result = await _sourceResource.
                    ReadStreamAsync(cancellationToken: _cancellationToken)
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
                    expectedLength: totalLength).ConfigureAwait(false);
                if (successfulCopy)
                {
                    ReportBytesWritten(downloadLength);
                    // Queue the work to end the download
                    await QueueCompleteFileDownload().ConfigureAwait(false);
                }
            }
            // Download in chunks
            else
            {
                await QueueChunksToChannel(0, totalLength).ConfigureAwait(false);
            }
        }

        #region PartitionedDownloader
        private async Task QueueChunksToChannel(long initialLength, long totalLength)
        {
            // Get list of ranges of the blob
            IList<HttpRange> ranges = GetRangesList(initialLength, totalLength, _transferChunkSize);

            // Create Download Chunk event handler to manage when the ranges finish downloading
            _downloadChunkHandler = GetDownloadChunkHandler(
                currentTransferred: initialLength,
                expectedLength: totalLength,
                ranges: ranges,
                jobPart: this);

            // Fill the queue with tasks to download each of the remaining
            // ranges in the file
            _queueingTasks = true;
            foreach (HttpRange httpRange in ranges)
            {
                if (_cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                // Add the next Task (which will start the download but
                // return before it's completed downloading)
                await QueueChunkToChannelAsync(
                    async () =>
                    await DownloadStreamingInternal(range: httpRange).ConfigureAwait(false))
                    .ConfigureAwait(false);
            }

            _queueingTasks = false;
            await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
        }

        internal async Task CompleteFileDownload()
        {
            try
            {
                CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);

                // Dispose the handlers
                DisposeHandlers();

                // Update the transfer status
                await OnTransferStateChangedAsync(DataTransferState.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task DownloadStreamingInternal(HttpRange range)
        {
            try
            {
                // If the job part is not InProgress, we should just stop processing any queued chunks.
                if (JobPartStatus.State != DataTransferState.InProgress)
                {
                    return;
                }

                StorageResourceReadStreamResult result = await _sourceResource.ReadStreamAsync(
                    range.Offset,
                    (long)range.Length,
                    _cancellationToken).ConfigureAwait(false);

                // The chunk handler may have been disposed in failure case
                if (_downloadChunkHandler != null)
                {
                    await _downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                        transferId: _dataTransfer.Id,
                        success: true,
                        offset: range.Offset,
                        bytesTransferred: (long)range.Length,
                        result: result.Content,
                        exception: default,
                        false,
                        _cancellationToken)).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                if (_downloadChunkHandler != null)
                {
                    await _downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                        transferId: _dataTransfer.Id,
                        success: false,
                        offset: range.Offset,
                        bytesTransferred: (long)range.Length,
                        result: default,
                        exception: ex,
                        false,
                        _cancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    // If the _downloadChunkHandler has been disposed before we call to it
                    // we should at least filter the exception to error handling just in case.
                    await InvokeFailedArg(ex).ConfigureAwait(false);
                }
            }
        }

        public async Task<bool> CopyToStreamInternal(
            long offset,
            long sourceLength,
            Stream source,
            long expectedLength)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            try
            {
                // TODO: change to custom offset based on chunk offset
                await _destinationResource.CopyFromStreamAsync(
                    stream: source,
                    overwrite: _createMode == StorageResourceCreationPreference.OverwriteIfExists,
                    streamLength: sourceLength,
                    completeLength: expectedLength,
                    options: new StorageResourceWriteToOffsetOptions()
                    {
                        Position = offset,
                    },
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch (IOException ex)
            when (_createMode == StorageResourceCreationPreference.SkipIfExists &&
                ex.Message.Contains("Cannot overwrite file."))
            {
                // Skip file that already exists on the destination.
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            return false;
        }

        public async Task WriteChunkToTempFile(string chunkFilePath, Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            using (FileStream fileStream = File.OpenWrite(chunkFilePath))
            {
                await source.CopyToAsync(
                    fileStream,
                    Constants.DefaultDownloadCopyBufferSize,
                    _cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        internal DownloadChunkHandler GetDownloadChunkHandler(
            long currentTransferred,
            long expectedLength,
            IList<HttpRange> ranges,
            UriToStreamJobPart jobPart)
            => new DownloadChunkHandler(
                currentTransferred,
                expectedLength,
                ranges,
                GetDownloadChunkHandlerBehaviors(jobPart),
                ClientDiagnostics,
                _cancellationToken);

        internal static DownloadChunkHandler.Behaviors GetDownloadChunkHandlerBehaviors(UriToStreamJobPart job)
        {
            return new DownloadChunkHandler.Behaviors()
            {
                CopyToDestinationFile = job.CopyToStreamInternal,
                CopyToChunkFile = job.WriteChunkToTempFile,
                ReportProgressInBytes = job.ReportBytesWritten,
                InvokeFailedHandler = job.InvokeFailedArg,
                QueueCompleteFileDownload = job.QueueCompleteFileDownload
            };
        }

        private Task QueueCompleteFileDownload()
        {
            return QueueChunkToChannelAsync(CompleteFileDownload);
        }

        private static IList<HttpRange> GetRangesList(long initialLength, long totalLength, long rangeSize)
        {
            IList<HttpRange> list = new List<HttpRange>();
            for (long offset = initialLength; offset < totalLength; offset += rangeSize)
            {
                list.Add(new HttpRange(offset, Math.Min(totalLength - offset, rangeSize)));
            }
            return list;
        }
        #endregion PartitionedDownloader

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
            if (_downloadChunkHandler != default)
            {
                _downloadChunkHandler.Dispose();
                _downloadChunkHandler = null;
            }
        }

        private async Task CreateZeroLengthDownload()
        {
            // We just need to at minimum create the file
            bool successfulCreation = await CopyToStreamInternal(
                offset: 0,
                sourceLength: 0,
                source: default,
                expectedLength: 0).ConfigureAwait(false);
            if (successfulCreation)
            {
                // Queue the work to end the download
                await QueueCompleteFileDownload().ConfigureAwait(false);
            }
            else
            {
                await CheckAndUpdateCancellationStateAsync().ConfigureAwait(false);
            }
        }
    }
}
