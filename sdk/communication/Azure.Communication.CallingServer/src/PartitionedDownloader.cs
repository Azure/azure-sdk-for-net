// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Models;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    internal class PartitionedDownloader
    {
        /// <summary>
        /// The client used to download the blob.
        /// </summary>
        private readonly ConversationClient _client;

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

        internal PartitionedDownloader(
            ConversationClient client,
            ContentTransferOptions transferOptions = default)
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
                _maxWorkerCount = Constants.ContentDownloader.Partition.DefaultConcurrentTransfersCount;
            }

            // Set _rangeSize
            if (transferOptions.MaximumTransferSize.HasValue
                && transferOptions.MaximumTransferSize.Value > 0)
            {
                _rangeSize = Math.Min(transferOptions.MaximumTransferSize.Value, Constants.ContentDownloader.Partition.MaxDownloadBytes);
            }
            else
            {
                _rangeSize = Constants.ContentDownloader.Partition.DefaultBufferSize;
            }

            // Set _initialRangeSize
            if (transferOptions.InitialTransferSize.HasValue
                && transferOptions.InitialTransferSize.Value > 0)
            {
                _initialRangeSize = transferOptions.InitialTransferSize.Value;
            }
            else
            {
                _initialRangeSize = Constants.ContentDownloader.Partition.DefaultInitalDownloadRangeSize;
            }
        }

        internal async Task<Response> DownloadToAsync(
            Stream destination,
            Uri endpoint,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client._clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ConversationClient.DownloadTo)}");
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small blob, we'll get the whole thing in one shot.  If it's
                // a large blob, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Task<Response<Stream>> initialResponseTask =
                    _client.DownloadStreamingAsync(
                        endpoint,
                        initialRange,
                        cancellationToken);

                Response<Stream> initialResponse;
                try
                {
                    initialResponse = await initialResponseTask.ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == "Invalid Range")
                {
                    initialResponse = await _client.DownloadStreamingAsync(
                        endpoint,
                        range: default,
                        cancellationToken)
                        .ConfigureAwait(false);
                }

                // If the first segment was the entire blob, we'll copy that to
                // the output stream and finish now
                long initialLength = ParseResponseContentLength(initialResponse);
                long totalLength = ParseRangeTotalLength(initialResponse);
                if (initialLength == totalLength)
                {
                    await CopyToAsync(
                        initialResponse,
                        destination,
                        cancellationToken)
                        .ConfigureAwait(false);
                    return initialResponse.GetRawResponse();
                }

                // Create a queue of tasks that will each download one segment
                // of the blob.  The queue maintains the order of the segments
                // so we can keep appending to the end of the destination
                // stream when each segment finishes.
                var runningTasks = new Queue<Task<Response<Stream>>>();
                runningTasks.Enqueue(initialResponseTask);

                // Fill the queue with tasks to download each of the remaining
                // ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Add the next Task (which will start the download but
                    // return before it's completed downloading)
                    runningTasks.Enqueue(_client.DownloadStreamingAsync(
                        endpoint,
                        httpRange,
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
                    using Stream result =
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

        private static long ParseResponseContentLength(Response<Stream> initialResponse)
        {
            initialResponse.GetRawResponse().Headers.TryGetValue("Content-Length", out string initialContentLength);
            long initialLength = long.Parse(initialContentLength ?? "0", CultureInfo.InvariantCulture.NumberFormat);
            return initialLength;
        }

        internal Response DownloadTo(
            Stream destination,
            Uri endpoint,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client._clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ConversationClient.DownloadTo)}");
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small blob, we'll get the whole thing in one shot.  If it's
                // a large blob, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Response<Stream> initialResponse;

                try
                {
                    initialResponse = _client.DownloadStreaming(
                        endpoint,
                        initialRange,
                        cancellationToken);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == "Invalid Range")
                {
                    initialResponse = _client.DownloadStreaming(
                        endpoint,
                        range: default,
                        cancellationToken);
                }

                // Copy the first segment to the destination stream
                CopyTo(initialResponse, destination, cancellationToken);

                // If the first segment was the entire blob, we're finished now
                long initialLength = ParseResponseContentLength(initialResponse);
                long totalLength = ParseRangeTotalLength(initialResponse);
                if (initialLength == totalLength)
                {
                    return initialResponse.GetRawResponse();
                }

                // Download each of the remaining ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    Response<Stream> result = _client.DownloadStreaming(
                        endpoint,
                        httpRange,
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

        private static long ParseRangeTotalLength(Response<Stream> response)
        {
            response.GetRawResponse().Headers.TryGetValue("Content-Range", out string range);

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

        private static async Task CopyToAsync(
            Stream result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            await result.CopyToAsync(
                destination,
                100000,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private static void CopyTo(
            Stream result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.CopyTo(destination, 1000000);
            result.Dispose();
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
