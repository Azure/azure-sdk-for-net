// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage
{
    internal class PartitionedDownloader<TServiceSpecificArgs, TCompleteDownloadReturn>
        where TCompleteDownloadReturn : IDisposable, IDownloadedContent
    {
        #region Definitions
        // Injected behaviors for services to use partitioned downloads
        public delegate Task<Response<TCompleteDownloadReturn>> SingleDownloadInternal(
            HttpRange range,
            TServiceSpecificArgs args,
            bool rangeGetContentHash,
            bool async,
            CancellationToken cancellationToken,
            ETag? etag = null);
        public delegate TServiceSpecificArgs ModifyConditions(
            TServiceSpecificArgs args,
            ETag etag);
        public delegate DiagnosticScope CreateScope(string operationName);

        public struct Behaviors
        {
            public SingleDownloadInternal SingleDownload { get; set; }
            public ModifyConditions ModifyConditions { get; set; }
            public CreateScope Scope { get; set; }
        }

        public static readonly ModifyConditions ModifyConditionsNoOp = (args, etag) => args;
        #endregion

        private readonly SingleDownloadInternal _singleDownloadInternal;
        private readonly ModifyConditions _modifyConditions;
        private readonly CreateScope _createScope;

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

        /// <summary>
        /// The name of the calling operaiton.
        /// </summary>
        private readonly string _operationName;

        public PartitionedDownloader(
            Behaviors behaviors,
            StorageTransferOptions transferOptions = default,
            string operationName = null)
        {
            // Modifying conditions to add Etag is only necessary for blobs,
            // files can use a no-op
            _modifyConditions = behaviors.ModifyConditions ?? ModifyConditionsNoOp;
            _singleDownloadInternal = behaviors.SingleDownload
                ?? throw Errors.ArgumentNull(nameof(behaviors.SingleDownload));
            _createScope = behaviors.Scope
                ?? throw Errors.ArgumentNull(nameof(behaviors.Scope));

            // Set instance variables according to user-specified options
             _maxWorkerCount = transferOptions.MaximumConcurrency.Value;
            _rangeSize = transferOptions.MaximumTransferSize.Value;
            _initialRangeSize = transferOptions.InitialTransferSize.Value;

            _operationName = operationName;
        }

        public async Task<Response> DownloadInternal(
            Stream destination,
            TServiceSpecificArgs conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _createScope(_operationName);
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small file, we'll get the whole thing in one shot.  If it's
                // a large file, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Response<TCompleteDownloadReturn> initialResponse = null;

                try
                {
                    initialResponse = await GetInitialResponse(
                            initialRange,
                            conditions,
                            rangeGetContentHash: false,
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == Constants.ErrorCodes.InvalidRange)
                {
                    initialResponse = await GetInitialResponse(
                            range: default,
                            conditions,
                            rangeGetContentHash: false,
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // If the first segment was the entire file, we'll write to
                // the output stream and finish now
                long initialLength = initialResponse.GetRawResponse().Headers.ContentLength.GetValueOrDefault();
                long totalLength = initialResponse.GetRawResponse().Headers.TryGetValue("Content-Range", out string value) ?
                    ParseRangeTotalLength(value) :
                    0;

                Console.WriteLine($"\n\n\nInitial Length: {initialLength}\nTotal Length: {totalLength}\n\n\n");

                if (async)
                {
                    await CopyToAsync(
                        initialResponse,
                        destination,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    CopyTo(initialResponse, destination, cancellationToken);
                }

                if (initialLength == totalLength)
                {
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and use it
                // later to ensure the file doesn't change while we're
                // downloading the remaining segments
                ETag? etag = initialResponse.GetRawResponse().Headers.ETag;
                TServiceSpecificArgs newConditions = _modifyConditions(conditions, etag.GetValueOrDefault());

                if (async)
                {
                    await DownloadRemainingInParallelAsync(
                        destination,
                        initialLength,
                        totalLength,
                        newConditions,
                        etag,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    DownloadRemainingInSequence(
                        destination,
                        initialLength,
                        totalLength,
                        newConditions,
                        etag,
                        cancellationToken);
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

        private async Task<Response<TCompleteDownloadReturn>> GetInitialResponse(
            HttpRange range,
            TServiceSpecificArgs conditions,
            bool rangeGetContentHash,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                return await _singleDownloadInternal(
                    range,
                    conditions,
                    rangeGetContentHash,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                return _singleDownloadInternal(
                    range,
                    conditions,
                    rangeGetContentHash,
                    async,
                    cancellationToken)
                    .EnsureCompleted();
            }
        }

        private async Task DownloadRemainingInParallelAsync(
            Stream destination,
            long initialLength,
            long totalLength,
            TServiceSpecificArgs conditions,
            ETag? etag,
            CancellationToken cancellationToken
            )
        {
            // Create a queue of tasks that will each download one segment
             // of the file.  The queue maintains the order of the segments
             // so we can keep appending to the end of the destination
             // stream when each segment finishes.
            var runningTasks = new Queue<Task<Response<TCompleteDownloadReturn>>>();

            // Fill the queue with tasks to download each of the remaining
            // ranges in the file
            foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
            {
                // Add the next Task (which will start the download but
                // return before it's completed downloading)
                runningTasks.Enqueue(_singleDownloadInternal(
                    httpRange,
                    conditions,
                    rangeGetContentHash: false,
                    async: true,
                    cancellationToken,
                    etag));

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

            // Wait for the first segment in the queue of tasks to complete
            // downloading and copy it to the destination stream
            async Task ConsumeQueuedTask()
            {
                // Don't need to worry about 304s here because the ETag
                // condition will turn into a 412 and throw a proper
                // RequestFailedException
                using TCompleteDownloadReturn result =
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

        private void DownloadRemainingInSequence(
            Stream destination,
            long initialLength,
            long totalLength,
            TServiceSpecificArgs conditions,
            ETag? etag,
            CancellationToken cancellationToken
            )
        {
            // Download each of the remaining ranges in the file
            foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
            {
                // Don't need to worry about 304s here because the ETag
                // condition will turn into a 412 and throw a proper
                // RequestFailedException
                Response<TCompleteDownloadReturn> result = _singleDownloadInternal(
                    httpRange,
                    conditions,
                    rangeGetContentHash: false,
                    async: false,
                    cancellationToken,
                    etag)
                    .EnsureCompleted();

                CopyTo(result.Value, destination, cancellationToken);
            }
        }
        private static async Task CopyToAsync(
            TCompleteDownloadReturn result,
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
            TCompleteDownloadReturn result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.Content.CopyTo(destination, Constants.DefaultDownloadCopyBufferSize);
            result.Content.Dispose();
        }

        private static long ParseRangeTotalLength(string range)
        {
            ContentRange? contentRange = string.IsNullOrWhiteSpace(range)
                ? default
                : ContentRange.Parse(range);

            return (long)contentRange?.Size.GetValueOrDefault();
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
