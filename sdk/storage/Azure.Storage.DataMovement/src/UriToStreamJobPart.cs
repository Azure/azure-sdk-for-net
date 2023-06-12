﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.DataMovement.Models;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Azure.Core;

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
        /// Creating job part based on a single transfer job
        /// </summary>
        private UriToStreamJobPart(
            UriToStreamTransferJob job,
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
        { }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        private UriToStreamJobPart(
            UriToStreamTransferJob job,
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
        { }

        public static async Task<UriToStreamJobPart> CreateJobPartAsync(
            UriToStreamTransferJob job,
            int partNumber,
            bool isFinalPart)
        {
            // Create Job Part file as we're intializing the job part
            UriToStreamJobPart part = new UriToStreamJobPart(
                job: job,
                partNumber: partNumber,
                isFinalPart: isFinalPart);
            await part.AddJobPartToCheckpointerAsync(
                chunksTotal: 1,
                isFinalPart: isFinalPart).ConfigureAwait(false); // For now we only store 1 chunk
            return part;
        }

        public static async Task<UriToStreamJobPart> CreateJobPartAsync(
            UriToStreamTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            bool isFinalPart,
            StorageTransferStatus jobPartStatus = default,
            long? length = default,
            bool partPlanFileExists = false)
        {
            // Create Job Part file as we're intializing the job part
            UriToStreamJobPart part = new UriToStreamJobPart(
                job: job,
                partNumber: partNumber,
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                isFinalPart: isFinalPart,
                length: length);
            if (!partPlanFileExists)
            {
                await part.AddJobPartToCheckpointerAsync(1, isFinalPart).ConfigureAwait(false); // For now we only store 1 chunk
            }
            return part;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeHandlers().ConfigureAwait(false);
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
            await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);

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
            Task<ReadStreamStorageResourceResult> initialTask = _sourceResource.ReadStreamAsync(
                        position: 0,
                        length: _initialTransferSize,
                        _cancellationToken);

            try
            {
                ReadStreamStorageResourceResult initialResult = default;
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
                long initialLength = initialResult.Properties.ContentLength;

                // There needs to be at least 1 chunk to create the blob even if the
                // length is 0 bytes.
                if (initialResult == default || initialLength == 0)
                {
                    await CreateZeroLengthDownload().ConfigureAwait(false);
                    return;
                }

                // TODO: Change to use buffer instead of converting to stream
                long totalLength = ParseRangeTotalLength(initialResult.ContentRange);
                bool succesfulInitialCopy = await CopyToStreamInternal(
                    offset: 0,
                    sourceLength: initialLength,
                    source: initialResult.Content,
                    expectedLength: totalLength).ConfigureAwait(false);
                if (succesfulInitialCopy)
                {
                    ReportBytesWritten(initialLength);
                    if (totalLength == initialLength)
                    {
                        // Complete download since it was done in one go
                        await QueueChunkToChannelAsync(
                            async () =>
                            await CompleteFileDownload().ConfigureAwait(false))
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        // Set rangeSize
                        long rangeSize = CalculateBlockSize(totalLength);

                        // Get list of ranges of the blob
                        IList<HttpRange> ranges = GetRangesList(initialLength, totalLength, rangeSize);
                        // Create Download Chunk event handler to manage when the ranges finish downloading
                        _downloadChunkHandler = GetDownloadChunkHandler(
                            currentTranferred: initialLength,
                            expectedLength: totalLength,
                            ranges: ranges,
                            jobPart: this);

                        // Fill the queue with tasks to download each of the remaining
                        // ranges in the blob
                        foreach (HttpRange httpRange in ranges)
                        {
                            // Add the next Task (which will start the download but
                            // return before it's completed downloading)
                            await QueueChunkToChannelAsync(
                                async () =>
                                await DownloadStreamingInternal(range: httpRange).ConfigureAwait(false))
                                .ConfigureAwait(false);
                        }
                    }
                }
                else
                {
                    await CheckAndUpdateCancellationStatusAsync().ConfigureAwait(false);
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
                ReadStreamStorageResourceResult result = await _sourceResource.
                    ReadStreamAsync(cancellationToken: _cancellationToken)
                    .ConfigureAwait(false);

                long downloadLength = result.Properties.ContentLength;
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
                    await QueueChunkToChannelAsync(
                        async () =>
                        await CompleteFileDownload().ConfigureAwait(false))
                        .ConfigureAwait(false);
                }
            }
            // Download in chunks
            else
            {
                // Set rangeSize
                long rangeSize = CalculateBlockSize(totalLength);

                // Get list of ranges of the blob
                IList<HttpRange> ranges = GetRangesList(0, totalLength, rangeSize);

                // Create Download Chunk event handler to manage when the ranges finish downloading
                _downloadChunkHandler = GetDownloadChunkHandler(
                    currentTranferred: 0,
                    expectedLength: totalLength,
                    ranges: ranges,
                    jobPart: this);

                // Fill the queue with tasks to download each of the remaining
                // ranges in the blob
                foreach (HttpRange httpRange in ranges)
                {
                    // Add the next Task (which will start the download but
                    // return before it's completed downloading)
                    await QueueChunkToChannelAsync(
                        async () =>
                        await DownloadStreamingInternal(range: httpRange).ConfigureAwait(false))
                        .ConfigureAwait(false);
                }
            }
        }

        #region PartitionedDownloader
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

        internal async Task DownloadStreamingInternal(HttpRange range)
        {
            try
            {
                ReadStreamStorageResourceResult result = await _sourceResource.ReadStreamAsync(
                    range.Offset,
                    (long) range.Length,
                    _cancellationToken).ConfigureAwait(false);
                await _downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                    transferId: _dataTransfer.Id,
                    success: true,
                    offset: range.Offset,
                    bytesTransferred: (long)range.Length,
                    result: result.Content,
                    false,
                    _cancellationToken)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                await InvokeFailedArg(ex).ConfigureAwait(false);
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
                await _destinationResource.WriteFromStreamAsync(
                    stream: source,
                    overwrite: _createMode == StorageResourceCreateMode.Overwrite,
                    position: offset,
                    streamLength: sourceLength,
                    completeLength: expectedLength,
                    options: default,
                    cancellationToken: _cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch (IOException ex)
            when (_createMode == StorageResourceCreateMode.Skip &&
                ex.Message.Contains("Cannot overwrite file."))
            {
                // Skip file that already exsits on the destination.
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
            return false;
        }

        public async Task WriteChunkToTempFile(string chunkFilePath, Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            try
            {
                using (FileStream fileStream = File.OpenWrite(chunkFilePath))
                {
                    await source.CopyToAsync(
                        fileStream,
                        Constants.DefaultDownloadCopyBufferSize,
                        _cancellationToken)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        // If Encryption is enabled this is required to flush
        // TODO: https://github.com/Azure/azure-sdk-for-net/issues/33016
        private async Task FlushFinalCryptoStreamInternal()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);

            try
            {
                await _destinationResource.CompleteTransferAsync(_cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal static DownloadChunkHandler GetDownloadChunkHandler(
            long currentTranferred,
            long expectedLength,
            IList<HttpRange> ranges,
            UriToStreamJobPart jobPart)
            => new DownloadChunkHandler(
                currentTranferred,
                expectedLength,
                ranges,
                GetDownloadChunkHandlerBehaviors(jobPart));

        internal static DownloadChunkHandler.Behaviors GetDownloadChunkHandlerBehaviors(UriToStreamJobPart job)
        {
            return new DownloadChunkHandler.Behaviors()
            {
                CopyToDestinationFile = (offset, length, result, expectedLength) => job.CopyToStreamInternal(offset, length, result, expectedLength),
                CopyToChunkFile = (chunkFilePath, source) => job.WriteChunkToTempFile(chunkFilePath, source),
                ReportProgressInBytes= (progress) => job.ReportBytesWritten(progress),
                InvokeFailedHandler = async (ex) => await job.InvokeFailedArg(ex).ConfigureAwait(false),
                QueueCompleteFileDownload = () => job.QueueChunkToChannelAsync(
                    async ()
                    => await job.CompleteFileDownload().ConfigureAwait(false))
            };
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
            if (_downloadChunkHandler != default)
            {
                await _downloadChunkHandler.DisposeAsync().ConfigureAwait(false);
            }
        }

        private async Task CreateZeroLengthDownload()
        {
            // We just need to at minimum create the file
            bool succesfulCreation = await CopyToStreamInternal(
                offset: 0,
                sourceLength: 0,
                source: default,
                expectedLength: 0).ConfigureAwait(false);
            if (succesfulCreation)
            {
                // Queue the work to end the download
                await QueueChunkToChannelAsync(
                    async () =>
                    await CompleteFileDownload().ConfigureAwait(false)).ConfigureAwait(false);
            }
            else
            {
                await CheckAndUpdateCancellationStatusAsync().ConfigureAwait(false);
            }
        }
    }
}
