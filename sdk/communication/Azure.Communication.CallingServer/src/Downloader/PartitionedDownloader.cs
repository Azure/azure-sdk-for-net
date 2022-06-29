// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallingServer
{
    internal class PartitionedDownloader
    {
        /// <summary>
        /// The client used to download the blob.
        /// </summary>
        private readonly CallingServerClient _client;

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
            CallingServerClient client,
            ContentTransferOptions transferOptions = default)
        {
            _client = client;
            _maxWorkerCount = transferOptions.MaximumConcurrency;
            _rangeSize = Math.Min(transferOptions.MaximumTransferSize, Constants.ContentDownloader.Partition.MaxDownloadBytes);
            _initialRangeSize = transferOptions.InitialTransferSize;
        }

        internal async Task<Response> DownloadToAsync(
            Stream destination,
            Uri endpoint,
            CancellationToken cancellationToken)
        {
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
            catch (RequestFailedException ex) when (ex.Status == 416) //Invalid Range
            {
                initialResponseTask = _client.DownloadStreamingAsync(
                    endpoint,
                    range: default,
                    cancellationToken);
                initialResponse = await initialResponseTask.ConfigureAwait(false);
            }

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

            var runningTasks = new Queue<Task<Response<Stream>>>();
            runningTasks.Enqueue(initialResponseTask);

            foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
            {
                runningTasks.Enqueue(_client.DownloadStreamingAsync(
                    endpoint,
                    httpRange,
                    cancellationToken));

                if (runningTasks.Count >= _maxWorkerCount)
                {
                    await ConsumeQueuedTask().ConfigureAwait(false);
                }
            }

            while (runningTasks.Count > 0)
            {
                await ConsumeQueuedTask().ConfigureAwait(false);
            }

            return initialResponse.GetRawResponse();

            async Task ConsumeQueuedTask()
            {
                using Stream result =
                    await runningTasks.Dequeue().ConfigureAwait(false);

                await CopyToAsync(
                    result,
                    destination,
                    cancellationToken)
                    .ConfigureAwait(false);
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
            var initialRange = new HttpRange(0, _initialRangeSize);
            Response<Stream> initialResponse;

            try
            {
                initialResponse = _client.DownloadStreaming(
                    endpoint,
                    initialRange,
                    cancellationToken);
            }
            catch (RequestFailedException ex) when (ex.Status == 416) // Invalid Range
            {
                initialResponse = _client.DownloadStreaming(
                    endpoint,
                    range: default,
                    cancellationToken);
            }

            CopyTo(initialResponse, destination, cancellationToken);

            long initialLength = ParseResponseContentLength(initialResponse);
            long totalLength = ParseRangeTotalLength(initialResponse);
            if (initialLength == totalLength)
            {
                return initialResponse.GetRawResponse();
            }

            foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
            {
                Response<Stream> result = _client.DownloadStreaming(
                    endpoint,
                    httpRange,
                    cancellationToken);
                CopyTo(result.Value, destination, cancellationToken);
            }

            return initialResponse.GetRawResponse();
        }

        private static long ParseRangeTotalLength(Response<Stream> response)
        {
            response.GetRawResponse().Headers.TryGetValue("Content-Range", out string range);

            if (range == null)
            {
                return ParseResponseContentLength(response);
            }
            int lengthSeparator = range.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            if (lengthSeparator == -1)
            {
                throw new SystemException("Could not obtain the total length from HTTP range " + range);
            }
            return long.Parse(range.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        private async Task CopyToAsync(
            Stream result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            await result.CopyToAsync(
                destination,
                (int)_rangeSize,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private static void CopyTo(
            Stream result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.CopyTo(destination);
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
