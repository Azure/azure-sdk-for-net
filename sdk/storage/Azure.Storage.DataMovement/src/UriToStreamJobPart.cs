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
    internal class UriToStreamJobPart : JobPartInternal
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
                  job.TransferStatusEventHandler,
                  job.TransferFailedEventHandler,
                  job._cancellationTokenSource)
        { }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="partNumber"></param>
        public UriToStreamJobPart(
            UriToStreamTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource)
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
                  job.TransferStatusEventHandler,
                  job.TransferFailedEventHandler,
                  job._cancellationTokenSource)
        { }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            if (await CreateDownloadFilePath().ConfigureAwait(false))
            {
                await InitiateDownload().ConfigureAwait(false);
            }
        }

        #region PartitionedDownloader
        /// <summary>
        /// Initializes the temporary file path for the blob to be downloaded to.
        /// </summary>
        private async Task<bool> CreateDownloadFilePath()
        {
            try
            {
                string destinationPath = _destinationResource.Path;
                if (!File.Exists(destinationPath))
                {
                    File.Create(destinationPath).Close();
                    FileAttributes attributes = File.GetAttributes(destinationPath);
                    File.SetAttributes(destinationPath, attributes | FileAttributes.Temporary);
                    return true;
                }
                else
                {
                    // TODO: if there's an error handling enum to overwrite the file we have to check
                    // for that instead of throwing an error
                    await InvokeFailedArg(
                        new IOException($"File path `{destinationPath}` already exists. Cannot overwite file")).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
            return false;
        }

        /// <summary>
        /// Just start downloading using an initial range.  If it's a
        /// small blob, we'll get the whole thing in one shot.  If it's
        /// a large blob, we'll get its full size in Content-Range and
        /// can keep downloading it in segments.
        ///
        /// After this response comes back and there's more to download
        /// then we will trigger more to download since we now know the
        /// content length.
        /// </summary>
        internal async Task InitiateDownload()
        {
            await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);

            try
            {
                Task<ReadStreamStorageResourceInfo> initialTask = _sourceResource.ReadPartialStreamAsync(
                    offset: 0,
                    length: _initialTransferSize,
                    _cancellationTokenSource.Token);

                ReadStreamStorageResourceInfo initialResult = default;
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
                if (initialResult == default || initialLength == 0 )
                {
                    // Invoke event handler and progress handler
                    await QueueChunk(
                        async () =>
                        await CompleteFileDownload().ConfigureAwait(false))
                        .ConfigureAwait(false);
                    return;
                }

                // TODO: Change to use buffer instead of converting to stream
                await CopyToStreamInternal(0, initialLength, initialResult.Content).ConfigureAwait(false);
                ReportBytesWritten(initialLength);
                long totalLength = ParseRangeTotalLength(initialResult.ContentRange);
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
                    int rangeSize = Constants.DefaultBufferSize;
                    if (_maximumTransferChunkSize.HasValue
                        && _maximumTransferChunkSize.Value > 0)
                    {
                        rangeSize = Math.Min((int)_maximumTransferChunkSize.Value, Constants.Blob.Block.MaxDownloadBytes);
                    }

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
            // TODO: Expand Exception Handling
            catch (Exception ex)
            {
                // The file either does not exist any more, got moved, or renamed.
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task CompleteFileDownload()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

            try
            {
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
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
                ReadStreamStorageResourceInfo result = await _sourceResource.ReadPartialStreamAsync(
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
                await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        public async Task CopyToStreamInternal(long offset, long sourceLength, Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

            try
            {
                // TODO: change to custom offset based on chunk offset
                await _destinationResource.WriteStreamToOffsetAsync(
                    offset,
                    sourceLength,
                    source,
                    default,
                    _cancellationTokenSource.Token).ConfigureAwait(false);
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
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        // If Encryption is enabled this is required to flush
        private async Task FlushFinalCryptoStreamInternal()
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

            try
            {
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
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
                GetDownloadChunkHandlerBehaviors(jobPart),
                jobPart._cancellationTokenSource.Token);

        internal static DownloadChunkHandler.Behaviors GetDownloadChunkHandlerBehaviors(UriToStreamJobPart job)
        {
            return new DownloadChunkHandler.Behaviors()
            {
                CopyToDestinationFile = (offset, length, result) => job.CopyToStreamInternal(offset, length, result),
                CopyToChunkFile = (chunkFilePath, source) => job.WriteChunkToTempFile(chunkFilePath, source),
                ReportProgressInBytes= (progress) => job.ReportBytesWritten(progress),
                InvokeFailedHandler = async (ex) => await job.InvokeFailedArg(ex).ConfigureAwait(false),
                QueueCompleteFileDownload = () => job.QueueChunk(
                    async () => await job.CompleteFileDownload().ConfigureAwait(false))
            };
        }

        private static long ParseRangeTotalLength(string range)
        {
            if (range == null)
            {
                return 0;
            }
            int lengthSeparator = range.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            if (lengthSeparator == -1)
            {
                throw new ArgumentException("Could not obtain the total length from HTTP range " + range);
            }
            return long.Parse(range.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        private static IList<HttpRange> GetRangesList(long initialLength, long totalLength, int rangeSize)
        {
            IList<HttpRange> list = new List<HttpRange>();
            for (long offset = initialLength; offset < totalLength; offset += rangeSize)
            {
                list.Add(new HttpRange(offset, Math.Min(totalLength - offset, rangeSize)));
            }
            return list;
        }
        #endregion PartitionedDownloader
    }
}
