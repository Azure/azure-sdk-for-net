// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Cryptography;

namespace Azure.Storage.Blobs
{
    internal class PartitionedDownloader
    {
        private const string _operationName = nameof(BlobBaseClient) + "." + nameof(BlobBaseClient.DownloadTo);
        private const string _innerOperationName = nameof(BlobBaseClient) + "." + nameof(BlobBaseClient.DownloadStreaming);

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

        /// <summary>
        /// Validation options to specify on transactions for this download operation.
        /// This downloader may alter the options it sends to individual download requests,
        /// but will on obey the user-specified options on the overall download.
        /// </summary>
        private readonly DownloadTransferValidationOptions _validationOptions;

        private readonly IProgress<long> _progress;

        public PartitionedDownloader(
            BlobBaseClient client,
            StorageTransferOptions transferOptions = default,
            DownloadTransferValidationOptions transferValidation = default,
            IProgress<long> progress = default)
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
                _rangeSize = (transferValidation?.ChecksumAlgorithm ?? StorageChecksumAlgorithm.None) != StorageChecksumAlgorithm.None
                    ? Constants.MaxHashRequestDownloadRange
                    : Constants.DefaultBufferSize;
            }

            // Set _initialRangeSize
            if (transferOptions.InitialTransferSize.HasValue
                && transferOptions.InitialTransferSize.Value > 0)
            {
                _initialRangeSize = transferOptions.InitialTransferSize.Value;
            }
            else
            {
                _initialRangeSize = (transferValidation?.ChecksumAlgorithm ?? StorageChecksumAlgorithm.None) != StorageChecksumAlgorithm.None
                    ? Constants.MaxHashRequestDownloadRange
                    : Constants.Blob.Block.DefaultInitalDownloadRangeSize;
            }

            // the caller to this stream cannot defer validation, as they cannot access a returned hash
            if (!(transferValidation?.AutoValidateChecksum ?? true))
            {
                throw Errors.CannotDeferTransactionalHashVerification();
            }

            _validationOptions = transferValidation;
            _progress = progress;

            /* Unlike partitioned upload, download cannot tell ahead of time if it will split and/or parallelize
             * after first call. Instead of applying progress handling to initial download stream after-the-fact,
             * wrap a given progress handler in an aggregator upfront and accept the overhead. */
            if (_progress != null && _progress is not AggregatingProgressIncrementer)
            {
                _progress = new AggregatingProgressIncrementer(_progress);
            }
        }

        public async Task<Response> DownloadToAsync(
            Stream destination,
            BlobRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client.ClientConfiguration.ClientDiagnostics.CreateScope(_operationName);
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small blob, we'll get the whole thing in one shot.  If it's
                // a large blob, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Task<Response<BlobDownloadStreamingResult>> initialResponseTask =
                    _client.DownloadStreamingInternal(
                        initialRange,
                        conditions,
                        _validationOptions,
                        _progress,
                        _innerOperationName,
                        async: true,
                        cancellationToken).AsTask();

                Response<BlobDownloadStreamingResult> initialResponse = null;
                try
                {
                    initialResponse = await initialResponseTask.ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.InvalidRange)
                {
                    initialResponse = await _client.DownloadStreamingInternal(
                        range: default,
                        conditions,
                        _validationOptions,
                        _progress,
                        _innerOperationName,
                        async: true,
                        cancellationToken)
                        .ConfigureAwait(false);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // We deferred client-side encryption, so now we must handle it before anything
                // is written to destination
                if (_client.UsingClientSideEncryption)
                {
                    if (initialResponse.Value.Details.Metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string rawEncryptiondata))
                    {
                        destination = await new BlobClientSideDecryptor(
                            new ClientSideDecryptor(_client.ClientSideEncryption)).DecryptWholeBlobWriteInternal(
                                destination,
                                initialResponse.Value.Details.Metadata,
                                async: true,
                                cancellationToken).ConfigureAwait(false);
                    }
                }

                // If the first segment was the entire blob, we'll copy that to
                // the output stream and finish now
                long initialLength = initialResponse.Value.Details.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    await CopyToAsync(
                        initialResponse,
                        destination,
                        cancellationToken)
                        .ConfigureAwait(false);

                    await FlushFinalIfNecessaryInternal(destination, async: true, cancellationToken).ConfigureAwait(false);
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and construct
                // conditions to ensure the blob doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.Value.Details.ETag;
                BlobRequestConditions conditionsWithEtag = conditions?.WithIfMatch(etag) ?? new BlobRequestConditions { IfMatch = etag };

                // Create a queue of tasks that will each download one segment
                // of the blob.  The queue maintains the order of the segments
                // so we can keep appending to the end of the destination
                // stream when each segment finishes.
                var runningTasks = new Queue<Task<Response<BlobDownloadStreamingResult>>>();
                runningTasks.Enqueue(initialResponseTask);
                if (_maxWorkerCount <= 1)
                {
                    // consume initial task immediately if _maxWorkerCount is 1 (or less to be safe). Otherwise loop below would have 2 concurrent tasks.
                    await ConsumeQueuedTask().ConfigureAwait(false);
                }

                // Fill the queue with tasks to download each of the remaining
                // ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Add the next Task (which will start the download but
                    // return before it's completed downloading)
                    runningTasks.Enqueue(_client.DownloadStreamingInternal(
                        httpRange,
                        conditionsWithEtag,
                        _validationOptions,
                        _progress,
                        _innerOperationName,
                        async: true,
                        cancellationToken).AsTask());

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

                await FlushFinalIfNecessaryInternal(destination, async: true, cancellationToken).ConfigureAwait(false);
                return initialResponse.GetRawResponse();

                // Wait for the first segment in the queue of tasks to complete
                // downloading and copy it to the destination stream
                async Task ConsumeQueuedTask()
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    using BlobDownloadStreamingResult result =
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
            DiagnosticScope scope = _client.ClientConfiguration.ClientDiagnostics.CreateScope(_operationName);
            try
            {
                scope.Start();

                // Just start downloading using an initial range.  If it's a
                // small blob, we'll get the whole thing in one shot.  If it's
                // a large blob, we'll get its full size in Content-Range and
                // can keep downloading it in segments.
                var initialRange = new HttpRange(0, _initialRangeSize);
                Response<BlobDownloadStreamingResult> initialResponse;

                try
                {
                    initialResponse = _client.DownloadStreamingInternal(
                        initialRange,
                        conditions,
                        _validationOptions,
                        _progress,
                        _innerOperationName,
                        async: false,
                        cancellationToken).EnsureCompleted();
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.InvalidRange)
                {
                    initialResponse = _client.DownloadStreamingInternal(
                        range: default,
                        conditions,
                        _validationOptions,
                        _progress,
                        _innerOperationName,
                        async: false,
                        cancellationToken).EnsureCompleted();
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // We deferred client-side encryption, so now we must handle it before anything
                // is written to destination
                if (_client.UsingClientSideEncryption)
                {
                    if (initialResponse.Value.Details.Metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string rawEncryptiondata))
                    {
                        destination = new BlobClientSideDecryptor(
                            new ClientSideDecryptor(_client.ClientSideEncryption)).DecryptWholeBlobWriteInternal(
                                destination,
                                initialResponse.Value.Details.Metadata,
                                async: false,
                                cancellationToken).EnsureCompleted();
                    }
                }

                // Copy the first segment to the destination stream
                CopyTo(initialResponse, destination, cancellationToken);

                // If the first segment was the entire blob, we're finished now
                long initialLength = initialResponse.Value.Details.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    FlushFinalIfNecessaryInternal(destination, async: false, cancellationToken).EnsureCompleted();
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and construct
                // conditions to ensure the blob doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.Value.Details.ETag;
                BlobRequestConditions conditionsWithEtag = conditions?.WithIfMatch(etag) ?? new BlobRequestConditions { IfMatch = etag };

                // Download each of the remaining ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    Response<BlobDownloadStreamingResult> result = _client.DownloadStreamingInternal(
                        httpRange,
                        conditionsWithEtag,
                        _validationOptions,
                        _progress,
                        _innerOperationName,
                        async: false,
                        cancellationToken).EnsureCompleted();
                    CopyTo(result.Value, destination, cancellationToken);
                }

                FlushFinalIfNecessaryInternal(destination, async: false, cancellationToken).EnsureCompleted();

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

        private static async Task CopyToAsync(
            BlobDownloadStreamingResult result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            using Stream source = result.Content;

            await source.CopyToAsync(
                destination,
                Constants.DefaultDownloadCopyBufferSize,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private static void CopyTo(
            BlobDownloadStreamingResult result,
            Stream destination,
            CancellationToken cancellationToken)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            using Stream source = result.Content;

            source.CopyTo(
                destination,
                Constants.DefaultDownloadCopyBufferSize);
        }

        private IEnumerable<HttpRange> GetRanges(long initialLength, long totalLength)
        {
            for (long offset = initialLength; offset < totalLength; offset += _rangeSize)
            {
                yield return new HttpRange(offset, Math.Min(totalLength - offset, _rangeSize));
            }
        }

        /// <summary>
        /// Writing to a crypto stream requires a "flush final" invocation, as the stream needs to treat
        /// the final cipher block differently.
        /// </summary>
        /// <param name="destination">
        /// Destination stream this downloader is writing to.
        /// </param>
        /// <param name="async">
        /// Whether to operate asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellationtoken for the operation.
        /// </param>
        /// <returns>
        /// Task for completion status of the operation.
        /// </returns>
        private async Task FlushFinalIfNecessaryInternal(Stream destination, bool async, CancellationToken cancellationToken)
        {
            if (_client.UsingClientSideEncryption)
            {
                if (destination is System.Security.Cryptography.CryptoStream cryptoStream)
                {
                    cryptoStream.FlushFinalBlock();
                }
                else if (destination is Azure.Storage.Cryptography.AuthenticatedRegionCryptoStream authRegionCryptoStream)
                {
                    await authRegionCryptoStream.FlushFinalInternal(async: async, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
