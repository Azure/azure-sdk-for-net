// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class PartitionedDownloader
    {
        /// <summary>
        /// The client used to download the blob.
        /// </summary>
        private readonly BlobBaseClient _client;

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
            BlobBaseClient client,
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
            BlobRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadTo)}");
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small blob, we'll get the whole thing in one shot.  If it's
                // a large blob, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Task<Response<BlobDownloadInfo>> initialResponseTask =
                    _client.DownloadAsync(
                        initialRange,
                        conditions,
                        rangeGetContentHash: false,
                        cancellationToken);

                Response<BlobDownloadInfo> initialResponse = null;
                try
                {
                    initialResponse = await initialResponseTask.ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.InvalidRange)
                {
                    initialResponse = await _client.DownloadAsync(
                        range: default,
                        conditions,
                        false,
                        cancellationToken)
                        .ConfigureAwait(false);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // If the first segment was the entire blob, we'll copy that to
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

                // Capture the etag from the first segment and construct
                // conditions to ensure the blob doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.Value.Details.ETag;
                BlobRequestConditions conditionsWithEtag = CreateConditionsWithEtag(conditions, etag);

                // Create a queue of tasks that will each download one segment
                // of the blob.  The queue maintains the order of the segments
                // so we can keep appending to the end of the destination
                // stream when each segment finishes.
                var runningTasks = new Queue<Task<Response<BlobDownloadInfo>>>();
                runningTasks.Enqueue(initialResponseTask);

                // Fill the queue with tasks to download each of the remaining
                // ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Add the next Task (which will start the download but
                    // return before it's completed downloading)
                    runningTasks.Enqueue(_client.DownloadAsync(
                        httpRange,
                        conditionsWithEtag,
                        rangeGetContentHash: false,
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
                    using BlobDownloadInfo result =
                        await runningTasks.Dequeue().ConfigureAwait(false);

                    // Even though the BlobDownloadInfo is returned immediately,
                    // CopyToAsync causes ConsumeQueuedTask to wait until the
                    // download is complete
                    await CopyToAsync(
                        result,
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
            BlobRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope($"{nameof(BlobBaseClient)}.{nameof(BlobBaseClient.DownloadTo)}");
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small blob, we'll get the whole thing in one shot.  If it's
                // a large blob, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Response<BlobDownloadInfo> initialResponse;

                try
                {
                    initialResponse = _client.Download(
                        initialRange,
                        conditions,
                        rangeGetContentHash: false,
                        cancellationToken);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.InvalidRange)
                {
                    initialResponse = _client.Download(
                    range: default,
                    conditions,
                    rangeGetContentHash: false,
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

                // If the first segment was the entire blob, we're finished now
                long initialLength = initialResponse.Value.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and construct
                // conditions to ensure the blob doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.Value.Details.ETag;
                BlobRequestConditions conditionsWithEtag = CreateConditionsWithEtag(conditions, etag);

                // Download each of the remaining ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    Response<BlobDownloadInfo> result = _client.Download(
                        httpRange,
                        conditionsWithEtag,
                        rangeGetContentHash: false,
                        cancellationToken);
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
                throw BlobErrors.ParsingFullHttpRangeFailed(range);
            }
            return long.Parse(range.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        private static BlobRequestConditions CreateConditionsWithEtag(BlobRequestConditions conditions, ETag etag) =>
            new BlobRequestConditions
            {
                LeaseId = conditions?.LeaseId,
                IfMatch = conditions?.IfMatch ?? etag,
                IfNoneMatch = conditions?.IfNoneMatch,
                IfModifiedSince = conditions?.IfModifiedSince,
                IfUnmodifiedSince = conditions?.IfUnmodifiedSince
            };

        private static async Task CopyToAsync(
            BlobDownloadInfo result,
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
            BlobDownloadInfo result,
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
