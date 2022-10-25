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
        /// Constructs the StreamToUriJobPart
        /// </summary>
        /// <param name="dataTransfer"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="maximumTransferChunkSize"></param>
        /// <param name="initialTransferSize"></param>
        /// <param name="errorHandling"></param>
        /// <param name="checkpointer"></param>
        /// <param name="uploadPool"></param>
        /// <param name="events"></param>
        /// <param name="cancellationTokenSource"></param>
        public UriToStreamJobPart(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            long? maximumTransferChunkSize,
            long initialTransferSize,
            ErrorHandlingOptions errorHandling,
            TransferCheckpointer checkpointer,
            ArrayPool<byte> uploadPool,
            TransferEventsInternal events,
            CancellationTokenSource cancellationTokenSource)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  maximumTransferChunkSize,
                  initialTransferSize,
                  errorHandling,
                  checkpointer,
                  uploadPool,
                  events,
                  cancellationTokenSource)
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
                string destinationPath = _destinationResource.Path.ToLocalPathString();
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
                Stream openWriteStream = await _sourceResource.OpenWriteStreamAsync().ConfigureAwait(false);

                byte[] buffer = new byte[_initialTransferSize];
                Task<int> initialTask = openWriteStream.ReadAsync(
                    buffer,
                    0,
                    (int)_initialTransferSize,
                    _cancellationTokenSource.Token);

                int? initialLength = default;
                try
                {
                    initialLength = await initialTask.ConfigureAwait(false);
                }
                catch // TODO: only catch initial range error.
                {
                    // Range not accepted, we need to attempt to use a default range
                    initialLength = await openWriteStream.ReadAsync(
                        buffer,
                        0,
                        (int)_initialTransferSize,
                        _cancellationTokenSource.Token)
                        .ConfigureAwait(false);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (!initialLength.HasValue)
                {
                    // Invoke event handler and progress handler
                    return;
                }

                // Check if that was the entire blob, if so finish now.
                // If the first segment was the entire blob, we'll copy that to
                // the output stream and finish now
                StorageResourceProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
                long totalLength = properties.ContentLength;

                // TODO: Change to use buffer instead of converting to stream
                await CopyToStreamInternal(new MemoryStream(buffer)).ConfigureAwait(false);
                ReportBytesWritten(initialLength.Value);
                if (initialLength.Value == totalLength)
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
                    IList<HttpRange> ranges = GetRangesList(initialLength.Value, totalLength, rangeSize);
                    // Create Download Chunk event handler to manage when the ranges finish downloading
                    _downloadChunkHandler = GetDownloadChunkHandler(
                        currentTranferred: initialLength.Value,
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
            }
            catch (Exception ex)
            {
                // The file either does not exist any more, got moved, or renamed.
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task DownloadStreamingInternal(
            HttpRange range)
        {
            try
            {
                Stream stream = await _sourceResource.OpenReadStreamAsync(range.Offset).ConfigureAwait(false);
                await _downloadChunkHandler.InvokeEvent(new DownloadRangeEventArgs(
                    transferId: _dataTransfer.Id,
                    success: true,
                    offset: range.Offset,
                    bytesTransferred: (long)range.Length,
                    result: stream,
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

        public async Task CopyToStreamInternal(Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(_cancellationTokenSource.Token);

            try
            {
                await _destinationResource.WriteStreamToOffsetAsync(
                    0,
                    source.Length,
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
                CopyToDestinationFile = (result) => job.CopyToStreamInternal(result),
                CopyToChunkFile = (chunkFilePath, source) => job.WriteChunkToTempFile(chunkFilePath, source),
                InvokeFailedHandler = async (ex) => await job.InvokeFailedArg(ex).ConfigureAwait(false),
                QueueCompleteFileDownload = () => job.QueueChunk(
                    async () =>
                    await job.CompleteFileDownload().ConfigureAwait(false))
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
