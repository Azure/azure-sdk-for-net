// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
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
        /// Checksum algorithm to use for transfer validation.
        /// </summary>
        private readonly StorageChecksumAlgorithm _validationAlgorithm;
        private readonly int _checksumSize;
        private bool UseMasterCrc => _validationAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64;
        private StorageCrc64HashAlgorithm _masterCrcCalculator = null;

        /// <summary>
        /// The validation options to send to individual download requests.
        /// Tells the client not to perform the checksum validation, leaving
        /// it to this class to perform that work.
        /// </summary>
        private DownloadTransferValidationOptions ValidationOptions
            => new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = _validationAlgorithm,
                AutoValidateChecksum = false
            };

        private readonly IProgress<long> _progress;

        private readonly ArrayPool<byte> _arrayPool;

        public PartitionedDownloader(
            BlobBaseClient client,
            StorageTransferOptions transferOptions = default,
            DownloadTransferValidationOptions transferValidation = default,
            IProgress<long> progress = default,
            ArrayPool<byte> arrayPool = default)
        {
            _client = client;
            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;

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

            Argument.AssertNotNull(transferValidation, nameof(transferValidation));
            // the caller to this stream cannot defer validation, as they cannot access a returned hash
            if (!transferValidation.AutoValidateChecksum)
            {
                throw Errors.CannotDeferTransactionalHashVerification();
            }

            _validationAlgorithm = transferValidation.ChecksumAlgorithm;
            _checksumSize = ContentHasher.GetHashSizeInBytes(_validationAlgorithm);
            _progress = progress;

            /* Unlike partitioned upload, download cannot tell ahead of time if it will split and/or parallelize
             * after first call. Instead of applying progress handling to initial download stream after-the-fact,
             * wrap a given progress handler in an aggregator upfront and accept the overhead. */
            if (_progress != null && _progress is not AggregatingProgressIncrementer)
            {
                _progress = new AggregatingProgressIncrementer(_progress);
            }
        }

        public async Task<Response> DownloadToInternal(
            Stream destination,
            BlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            // Wrap the download range calls in a Download span for distributed
            // tracing
            DiagnosticScope scope = _client.ClientConfiguration.ClientDiagnostics.CreateScope(_operationName);
            using DisposableBucket disposables = new DisposableBucket();
            Queue<Task<Response<BlobDownloadStreamingResult>>> runningTasks = null;
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
                    initialResponse = await _client.DownloadStreamingInternal(
                        initialRange,
                        conditions,
                        ValidationOptions,
                        _progress,
                        _innerOperationName,
                        async,
                        cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.InvalidRange)
                {
                    // We expect the blob to be empty if we got this exception
                    Response<BlobProperties> properties = await _client.GetPropertiesInternal(
                            conditions: conditions,
                            async: async,
                            context: new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    bool isEmpty = properties.Value.ContentLength == 0;

                    if (!isEmpty)
                    {
                        throw new RequestFailedException("InvalidRange error, despite non-empty blob.", ex);
                    }

                    DownloadTransferValidationOptions validationOptionsForEmptyBlob = new()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.None
                    };

                    initialResponse = await _client.DownloadStreamingInternal(
                        range: default,
                        conditions,
                        validationOptionsForEmptyBlob,
                        _progress,
                        _innerOperationName,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    // Return early as the blob is empty and no further processing needed
                    return initialResponse.GetRawResponse();
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    return initialResponse.GetRawResponse();
                }

                // Destination wrapped in decrypt step if needed (determined by initial response)
                if (_client.UsingClientSideEncryption)
                {
                    if (initialResponse.Value.Details.Metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string rawEncryptiondata))
                    {
                        destination = await new BlobClientSideDecryptor(
                            new ClientSideDecryptor(_client.ClientSideEncryption)).DecryptWholeBlobWriteInternal(
                                destination,
                                initialResponse.Value.Details.Metadata,
                                async,
                                cancellationToken).ConfigureAwait(false);
                    }
                }

                // Destination wrapped in master crc step if needed (must wait until after encryption wrap check)
                Memory<byte> composedCrc = default;
                if (UseMasterCrc)
                {
                    _masterCrcCalculator = StorageCrc64HashAlgorithm.Create();
                    destination = ChecksumCalculatingStream.GetWriteStream(destination, _masterCrcCalculator.Append);
                    disposables.Add(_arrayPool.RentAsMemoryDisposable(
                        Constants.StorageCrc64SizeInBytes, out composedCrc));
                    composedCrc.Span.Clear();
                }

                // If the first segment was the entire blob, we'll copy that to
                // the output stream and finish now
                long initialLength = initialResponse.Value.Details.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    await HandleOneShotDownload(initialResponse, destination, async, cancellationToken)
                        .ConfigureAwait(false);
                    return initialResponse.GetRawResponse();
                }

                // Capture the etag from the first segment and construct
                // conditions to ensure the blob doesn't change while we're
                // downloading the remaining segments
                ETag etag = initialResponse.Value.Details.ETag;
                BlobRequestConditions conditionsWithEtag = conditions?.WithIfMatch(etag) ?? new BlobRequestConditions { IfMatch = etag };

#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                                // Rule checker cannot understand this section, but this
                                // massively reduces code duplication.
                int effectiveWorkerCount = async ? _maxWorkerCount : 1;
                if (effectiveWorkerCount > 1)
                {
                    runningTasks = new();
                    runningTasks.Enqueue(Task.FromResult(initialResponse));
                }
                else
                {
                    using (_arrayPool.RentAsMemoryDisposable(_checksumSize, out Memory<byte> partitionChecksum))
                    {
                        await CopyToInternal(initialResponse, destination, partitionChecksum, async, cancellationToken).ConfigureAwait(false);
                        if (UseMasterCrc)
                        {
                            StorageCrc64Composer.Compose(
                                (composedCrc.ToArray(), 0L),
                                (partitionChecksum.ToArray(), initialResponse.Value.Details.ContentLength)
                            ).CopyTo(composedCrc);
                        }
                    }
                }

                // Fill the queue with tasks to download each of the remaining
                // ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    ValueTask<Response<BlobDownloadStreamingResult>> responseValueTask = _client
                        .DownloadStreamingInternal(
                            httpRange,
                            conditionsWithEtag,
                            ValidationOptions,
                            _progress,
                            _innerOperationName,
                            async,
                            cancellationToken);
                    if (runningTasks != null)
                    {
                        // Add the next Task (which will start the download but
                        // return before it's completed downloading)
                        runningTasks.Enqueue(responseValueTask.AsTask());

                        // If we have fewer tasks than alotted workers, then just
                        // continue adding tasks until we have effectiveWorkerCount
                        // running in parallel
                        if (runningTasks.Count < effectiveWorkerCount)
                        {
                            continue;
                        }

                        // Once all the workers are busy, wait for the first
                        // segment to finish downloading before we create more work
                        await ConsumeQueuedTask().ConfigureAwait(false);
                    }
                    else
                    {
                        Response<BlobDownloadStreamingResult> result = await responseValueTask.ConfigureAwait(false);
                        using (_arrayPool.RentAsMemoryDisposable(_checksumSize, out Memory<byte> partitionChecksum))
                        {
                            await CopyToInternal(result, destination, partitionChecksum, async, cancellationToken).ConfigureAwait(false);
                            if (UseMasterCrc)
                            {
                                StorageCrc64Composer.Compose(
                                    (composedCrc.ToArray(), 0L),
                                    (partitionChecksum.ToArray(), result.Value.Details.ContentLength)
                                ).CopyTo(composedCrc);
                            }
                        }
                    }
                }

                // Wait for all of the remaining segments to download
                if (runningTasks != null)
                {
                    while (runningTasks.Count > 0)
                    {
                        await ConsumeQueuedTask().ConfigureAwait(false);
                    }
                }
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.

                await FinalizeDownloadInternal(destination, composedCrc, async, cancellationToken)
                    .ConfigureAwait(false);
                return initialResponse.GetRawResponse();

                // Wait for the first segment in the queue of tasks to complete
                // downloading and copy it to the destination stream
                async Task ConsumeQueuedTask()
                {
                    // Don't need to worry about 304s here because the ETag
                    // condition will turn into a 412 and throw a proper
                    // RequestFailedException
                    Response<BlobDownloadStreamingResult> response =
                        await runningTasks.Dequeue().ConfigureAwait(false);

                    // Even though the BlobDownloadInfo is returned immediately,
                    // CopyToAsync causes ConsumeQueuedTask to wait until the
                    // download is complete

                    using (_arrayPool.RentAsMemoryDisposable(_checksumSize, out Memory<byte> partitionChecksum))
                    {
                        await CopyToInternal(
                            response,
                            destination,
                            partitionChecksum,
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                            if (UseMasterCrc)
                            {
                                StorageCrc64Composer.Compose(
                                    (composedCrc.ToArray(), 0L),
                                    (partitionChecksum.ToArray(), response.Value.Details.ContentLength)
                                ).CopyTo(composedCrc);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
#pragma warning disable AZC0110
                if (runningTasks != null)
                {
                    async Task DisposeStreamAsync(Task<Response<BlobDownloadStreamingResult>> task)
                    {
                        Response<BlobDownloadStreamingResult> response = await task.ConfigureAwait(false);
                        response.Value.Content.Dispose();
                    }
                    await Task.WhenAll(runningTasks.Select(DisposeStreamAsync)).ConfigureAwait(false);
                }
#pragma warning restore AZC0110
                scope.Dispose();
            }
        }

        private async Task HandleOneShotDownload(
            Response<BlobDownloadStreamingResult> response,
            Stream destination,
            bool async,
            CancellationToken cancellationToken)
        {
            using var _ = _arrayPool.RentAsMemoryDisposable(_checksumSize, out Memory<byte> partitionChecksum);
            await CopyToInternal(
                response,
                destination,
                partitionChecksum,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            await FinalizeDownloadInternal(destination, partitionChecksum, async, cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task FinalizeDownloadInternal(
            Stream destination,
            Memory<byte> composedCrc,
            bool async,
            CancellationToken cancellationToken)
        {
            await FlushFinalIfNecessaryInternal(destination, async, cancellationToken).ConfigureAwait(false);

            if (UseMasterCrc)
            {
                using (_arrayPool.RentAsMemoryDisposable(Constants.StorageCrc64SizeInBytes, out Memory<byte> masterCrc))
                {
                    _masterCrcCalculator.GetCurrentHash(masterCrc.Span);
                    ValidateFinalCrc(composedCrc.Span);
                }
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

        private async Task CopyToInternal(
            Response<BlobDownloadStreamingResult> response,
            Stream destination,
            Memory<byte> checksumBuffer,
            bool async,
            CancellationToken cancellationToken)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            using IHasher hasher = ContentHasher.GetHasherFromAlgorithmId(_validationAlgorithm);
            using Stream rawSource = response.Value.Content;
            using Stream source = hasher != null
                ? ChecksumCalculatingStream.GetReadStream(rawSource, hasher.AppendHash)
                : rawSource;

            await source.CopyToInternal(
                destination,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            if (hasher != null)
            {
                hasher.GetFinalHash(checksumBuffer.Span);
                (ReadOnlyMemory<byte> checksum, StorageChecksumAlgorithm _)
                    = ContentHasher.GetResponseChecksumOrDefault(response.GetRawResponse());
                if (!checksumBuffer.Span.SequenceEqual(checksum.Span))
                {
                    throw Errors.HashMismatchOnStreamedDownload(response.Value.Details.ContentRange);
                }
            }
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

        private void ValidateFinalCrc(ReadOnlySpan<byte> composedCrc)
        {
            using var _ = _arrayPool.RentAsSpanDisposable(
                Constants.StorageCrc64SizeInBytes, out Span<byte> masterCrc);
            _masterCrcCalculator.GetCurrentHash(masterCrc);
            if (!masterCrc.SequenceEqual(composedCrc))
            {
                throw Errors.ChecksumMismatch(masterCrc, composedCrc);
            }
        }
    }
}
