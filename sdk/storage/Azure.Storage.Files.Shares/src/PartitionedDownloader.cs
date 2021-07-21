// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares
{
    internal class PartitionedDownloader
    {
        /// <summary>
        /// The client used to download the file.
        /// </summary>
        private readonly ShareFileClient _client;

        /// <summary>
        /// The maximum number of simultaneous workers.
        /// </summary>
        private readonly int _maxWorkerCount;

        /// <summary>
        /// The size of the first range requested (which can be larger than the
        /// other ranges).
        /// </summary>
        private readonly long _initialRangeSize;

        /// <summary>
        /// The size of subsequent ranges.
        /// </summary>
        private readonly long _rangeSize;

        public PartitionedDownloader(
            ShareFileClient client,
            StorageTransferOptions transferOptions = default)
        {
            _client = client;

            // Set _maxWorkerCount
            if (transferOptions.MaximumConcurrency.HasValue
                && transferOptions.MaximumConcurrency > 0)
            {
                _maxWorkerCount = transferOptions.MaximumConcurrency.Value;
            }
            else
            {
                _maxWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }

            // Set _rangeSize
            if (transferOptions.MaximumTransferSize.HasValue
                && transferOptions.MaximumTransferSize.Value > 0)
            {
                _rangeSize = Math.Min(transferOptions.MaximumTransferSize.Value, Constants.Blob.Block.MaxDownloadBytes);
            }
            else
            {
                _rangeSize = Constants.DefaultBufferSize;
            }

            // Set _initialRangeSize
            if (transferOptions.InitialTransferSize.HasValue
                && transferOptions.InitialTransferSize.Value > 0)
            {
                _initialRangeSize = transferOptions.InitialTransferSize.Value;
            }
            else
            {
                _initialRangeSize = Constants.Blob.Block.DefaultInitalDownloadRangeSize;
            }
        }

        public async Task<Response> DownloadToAsync(
            Stream destination,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client.ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(ShareFileClient.DownloadTo)}");
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small file, we'll get the whole thing in one shot.  If it's
                // a large file, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Task<Response<ShareFileDownloadInfo>> initialResponseTask =
                    _client.DownloadAsync(
                        initialRange,
                        rangeGetContentHash: false,
                        conditions,
                        cancellationToken);

                Response<ShareFileDownloadInfo> initialResponse = null;
                try
                {
                    initialResponse = await initialResponseTask.ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == ShareErrorCode.InvalidRange)
                {
                    initialResponse = await _client.DownloadAsync(
                        range: default,
                        false,
                        conditions,
                        cancellationToken)
                        .ConfigureAwait(false);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // If the first segment was the entire file, we'll copy that to
                // the output stream and finish now
                long initialLength = initialResponse.Value.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    await CopyToAsync(
                        initialResponse,
                        destination,
                        cancellationToken)
                        .ConfigureAwait(false);
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and use it
                // later to ensure the file doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.GetRawResponse().Headers.ETag.GetValueOrDefault();

                // Create a queue of tasks that will each download one segment
                // of the file.  The queue maintains the order of the segments
                // so we can keep appending to the end of the destination
                // stream when each segment finishes.
                var runningTasks = new Queue<Task<Response<ShareFileDownloadInfo>>>();
                runningTasks.Enqueue(initialResponseTask);
                if (_maxWorkerCount <= 1)
                {
                    // consume initial task immediately if _maxWorkerCount is 1 (or less to be safe). Otherwise loop below would have 2 concurrent tasks.
                    await ConsumeQueuedTask().ConfigureAwait(false);
                }

                // Fill the queue with tasks to download each of the remaining
                // ranges in the file
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Add the next Task (which will start the download but
                    // return before it's completed downloading)
                    runningTasks.Enqueue(_client.DownloadAsync(
                        httpRange,
                        rangeGetContentHash: false,
                        conditions,
                        cancellationToken));

                    // If we have fewer tasks than alotted workers, then just
                    // continue adding tasks until we have _maxWorkerCount
                    // running in parallel
                    if (runningTasks.Count < _maxWorkerCount)
                    {
                        continue;
                    }

                    // Once all the workers are busy, wait for the first
                    // segment to finish downloading before we create more work
                    await ConsumeQueuedTask().ConfigureAwait(false);
                }

                // Wait for all of the remaining segments to download
                while (runningTasks.Count > 0)
                {
                    await ConsumeQueuedTask().ConfigureAwait(false);
                }

                return initialResponse.GetRawResponse();

                // Wait for the first segment in the queue of tasks to complete
                // downloading and copy it to the destination stream
                async Task ConsumeQueuedTask()
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    Response<ShareFileDownloadInfo> result =
                        await runningTasks.Dequeue().ConfigureAwait(false);

                    // Make sure the ETag for this chunk matches the originally
                    // recorded one
                    if (etag != result.GetRawResponse().Headers.ETag)
                    {
                        Console.WriteLine($"{etag} {result.GetRawResponse().Headers.ETag} {result.Value.Details.ContentRange}");
                        throw new ShareFileModifiedException(
                            "File has been modified concurrently",
                            _client.Uri, etag, result.GetRawResponse().Headers.ETag.GetValueOrDefault(), ParseRange(result.Value.Details.ContentRange));
                    }

                    using ShareFileDownloadInfo resultInfo =
                        result;

                    // Even though the BlobDownloadInfo is returned immediately,
                    // CopyToAsync causes ConsumeQueuedTask to wait until the
                    // download is complete
                    await CopyToAsync(
                        resultInfo,
                        destination,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        public Response DownloadTo(
            Stream destination,
            ShareFileRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client.ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(ShareFileClient)}.{nameof(ShareFileClient.DownloadTo)}");
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small file, we'll get the whole thing in one shot.  If it's
                // a large file, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Response<ShareFileDownloadInfo> initialResponse;

                try
                {
                    initialResponse = _client.Download(
                        initialRange,
                        rangeGetContentHash: false,
                        conditions,
                        cancellationToken);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == ShareErrorCode.InvalidRange)
                {
                    initialResponse = _client.Download(
                    range: default,
                    rangeGetContentHash: false,
                    conditions,
                    cancellationToken);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // Copy the first segment to the destination stream
                CopyTo(initialResponse, destination, cancellationToken);

                // If the first segment was the entire file, we're finished now
                long initialLength = initialResponse.Value.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and use it
                // later to ensure the file doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.Value.Details.ETag;

                // Download each of the remaining ranges in the file
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    Response<ShareFileDownloadInfo> result = _client.Download(
                        httpRange,
                        rangeGetContentHash: false,
                        conditions,
                        cancellationToken);

                    // Make sure the ETag for this chunk matches the originally
                    // recorded one
                    if (etag != result.GetRawResponse().Headers.ETag)
                    {
                        throw new ShareFileModifiedException(
                            "File has been modified concurrently",
                            _client.Uri, etag, result.GetRawResponse().Headers.ETag.GetValueOrDefault(), ParseRange(result.Value.Details.ContentRange));
                    }

                    CopyTo(result.Value, destination, cancellationToken);
                }

                return initialResponse.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
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
                throw ShareErrors.ParsingFullHttpRangeFailed(range);
            }
            return long.Parse(range.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        private static HttpRange ParseRange(string range)
        {
            if (range == null)
            {
                return new HttpRange(0, 0);
            }
            int lengthSeparator = range.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            if (lengthSeparator == -1)
            {
                throw ShareErrors.ParsingFullHttpRangeFailed(range);
            }
            string[] rangeBounds = range.Substring(6, lengthSeparator - 6).Split('-');
            return new HttpRange(
                long.Parse(rangeBounds[0], CultureInfo.InvariantCulture),
                long.Parse(rangeBounds[1], CultureInfo.InvariantCulture));
        }

        private static async Task CopyToAsync(
            ShareFileDownloadInfo result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            using Stream source = result.Content;

            await source.CopyToAsync(
                destination,
                Constants.DefaultDownloadCopyBufferSize,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private static void CopyTo(
            ShareFileDownloadInfo result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.Content.CopyTo(destination, Constants.DefaultDownloadCopyBufferSize);
            result.Content.Dispose();
        }

        private IEnumerable<HttpRange> GetRanges(long initialLength, long totalLength)
        {
            for (long offset = initialLength; offset < totalLength; offset += _rangeSize)
            {
                yield return new HttpRange(offset, Math.Min(totalLength - offset, _rangeSize));
            }
        }
    }
}
