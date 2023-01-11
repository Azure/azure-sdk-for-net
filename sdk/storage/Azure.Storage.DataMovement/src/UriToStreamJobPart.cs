// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.DataMovement.Models;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Buffers;
using System.Globalization;
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
        /// <param name="job"></param>
        /// <param name="partNumber"></param>
        public UriToStreamJobPart(UriToStreamTransferJob job, int partNumber)
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
        { }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="partNumber"></param>
        /// <param name="length"></param>
        public UriToStreamJobPart(
            UriToStreamTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource,
            long? length)
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
                  cancellationTokenSource: job._cancellationTokenSource,
                  length: length)
        { }

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
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.None).ConfigureAwait(false);
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
                        _cancellationTokenSource.Token);

            ReadStreamStorageResourceResult initialResult = default;
            try
            {
                initialResult = await initialTask.ConfigureAwait(false);
            }
            catch // TODO: only catch initial range error.
            {
                // Range not accepted, we need to attempt to use a default range
                initialResult = await _sourceResource.ReadStreamAsync(
                    cancellationToken: _cancellationTokenSource.Token)
                    .ConfigureAwait(false);
            }
            // If the initial request returned no content (i.e., a 304),
            // we'll pass that back to the user immediately
            long initialLength = initialResult.Properties.ContentLength;
            if (initialResult == default || initialLength == 0)
            {
                // We just need to at minimum create the file
                await CopyToStreamInternal(
                    offset: 0,
                    sourceLength: 0,
                    source: default,
                    expectedLength: 0).ConfigureAwait(false);
                // Queue the work to end the download
                await QueueChunk(
                    async () =>
                    await CompleteFileDownload().ConfigureAwait(false))
                    .ConfigureAwait(false);
                return;
            }

            // TODO: Change to use buffer instead of converting to stream
            long totalLength = ParseRangeTotalLength(initialResult.ContentRange);
            await CopyToStreamInternal(
                offset: 0,
                sourceLength: initialLength,
                source: initialResult.Content,
                expectedLength: totalLength).ConfigureAwait(false);
            ReportBytesWritten(initialLength);
            if (totalLength == initialLength)
            {
                // Complete download since it was done in one go
                await QueueChunk(
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
                    await QueueChunk(async () =>
                        await DownloadStreamingInternal(range: httpRange).ConfigureAwait(false)).ConfigureAwait(false);
                }
            }
        }

        internal async Task LengthKnownDownloadInternal()
        {
            long totalLength = _sourceResource.Length.Value;
            if (_initialTransferSize <= totalLength)
            {
                // To prevent requesting a range that is invalid when
                // we already know the length we can just make one get blob request.
                ReadStreamStorageResourceResult result = await _sourceResource.
                    ReadStreamAsync(cancellationToken: _cancellationTokenSource.Token)
                    .ConfigureAwait(false);

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                long initialLength = result.Properties.ContentLength;
                if (result == default || initialLength == 0)
                {
                    // We just need to at minimum create the file
                    await CopyToStreamInternal(
                        offset: 0,
                        sourceLength: 0,
                        source: default,
                        expectedLength: 0).ConfigureAwait(false);
                    // Queue the work to end the download
                    await QueueChunk(
                        async () =>
                        await CompleteFileDownload().ConfigureAwait(false))
                        .ConfigureAwait(false);
                    return;
                }
            }
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
                    await QueueChunk(async () =>
                        await DownloadStreamingInternal(range: httpRange).ConfigureAwait(false)).ConfigureAwait(false);
                }
            }
        }

        #region PartitionedDownloader
        internal async Task CompleteFileDownload()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);
            try
            {
                // Apply necessary transfer completions on the destination.
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);

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
                    _cancellationTokenSource.Token).ConfigureAwait(false);
                await _downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                    transferId: _dataTransfer.Id,
                    success: true,
                    offset: range.Offset,
                    bytesTransferred: (long)range.Length,
                    result: result.Content,
                    false,
                    _cancellationTokenSource.Token)).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        public async Task CopyToStreamInternal(
            long offset,
            long sourceLength,
            Stream source,
            long expectedLength)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

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
                    cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (IOException ex)
            when (_createMode == StorageResourceCreateMode.Skip &&
                ex.Message.Contains("Cannot overwite file."))
            {
                // Skip file that already exsits on the destination.
                await InvokeSkippedArg().ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        public async Task WriteChunkToTempFile(string chunkFilePath, Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

            try
            {
                using (FileStream fileStream = File.OpenWrite(chunkFilePath))
                {
                    await source.CopyToAsync(
                        fileStream,
                        Constants.DefaultDownloadCopyBufferSize,
                        _cancellationTokenSource.Token)
                        .ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.None).ConfigureAwait(false);
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
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

            try
            {
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.None).ConfigureAwait(false);
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
                QueueCompleteFileDownload = () => job.QueueChunk(
                    async () => await job.CompleteFileDownload().ConfigureAwait(false))
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
    }
}
