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
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    internal class PartitionedDownloader
    {
        private const string _operationName = nameof(BlobBaseClient) + "." + nameof(BlobBaseClient.DownloadTo);
        private const string _innerOperationName = nameof(BlobBaseClient) + "." + nameof(BlobBaseClient.DownloadStreaming);

        private const int Crc64Len = Constants.StorageCrc64SizeInBytes;

        /// <summary>
        /// Holds the result of downloading and buffering a single range into memory.
        /// The caller is responsible for disposing BufferedStream, which returns its
        /// rented ArrayPool buffers.
        /// </summary>
        private readonly struct BufferedDownloadResult
        {
            public readonly PooledMemoryStream BufferedStream;
            public readonly byte[] PartitionChecksum;
            public readonly long ContentLength;

            public BufferedDownloadResult(PooledMemoryStream bufferedStream, byte[] partitionChecksum, long contentLength)
            {
                BufferedStream = bufferedStream;
                PartitionChecksum = partitionChecksum;
                ContentLength = contentLength;
            }
        }

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
        private StorageCrc64HashAlgorithm _masterCrcCalculator;

        /// <summary>
        /// The validation options to send to individual download requests.
        /// Tells the client not to perform the responseChecksum validation, leaving
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

        private readonly int DefaultConcurrentTransfersCount = Math.Min(Math.Max(Environment.ProcessorCount * 2, 8), 32);

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
                _maxWorkerCount = CompatSwitches.UseLegacyDefaultConcurrency
                    ? Constants.Blob.Block.LegacyDefaultConcurrentTransfersCount
                    : DefaultConcurrentTransfersCount;
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
            _masterCrcCalculator = UseMasterCrc ? StorageCrc64HashAlgorithm.Create() : null;
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
            using DiagnosticScope scope = _client.ClientConfiguration.ClientDiagnostics.CreateScope(_operationName);

            conditions.ValidateConditionsNotPresent(
                invalidConditions:
                    BlobRequestConditionProperty.AccessTierIfModifiedSince
                    | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                operationName: nameof(BlobBaseClient.DownloadTo),
                parameterName: nameof(conditions));

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
                    // We expect the blob to be empty if we got InvalidRange exception

                    DownloadTransferValidationOptions validationOptionsNone = new()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.None
                    };

                    initialResponse = await _client.DownloadStreamingInternal(
                        range: default,
                        conditions,
                        validationOptionsNone,
                        _progress,
                        _innerOperationName,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    if (ValidationOptions.ChecksumAlgorithm != StorageChecksumAlgorithm.None && initialResponse.Value.Details.ContentLength != 0)
                    {
                        throw BlobErrors.InvalidRangeWithNonEmptyBlob(ex);
                    }

                    if (initialResponse.Value.Details.ContentLength == 0)
                    {
                        // Return early as the blob is empty and no further processing needed
                        return initialResponse.GetRawResponse();
                    }
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
                if (UseMasterCrc)
                {
                    destination = ChecksumCalculatingStream.GetWriteStream(destination, _masterCrcCalculator.Append);
                }

                // If the first segment was the entire blob, we'll copy that to
                // the output stream and finish now
                long initialLength;
                long totalLength;
                // Get blob content length downloaded from content range when available to handle transit encoding
                if (string.IsNullOrWhiteSpace(initialResponse.Value.Details.ContentRange))
                {
                    initialLength = initialResponse.Value.Details.ContentLength;
                    totalLength = 0;
                }
                else
                {
                    ContentRange recievedRange = ContentRange.Parse(initialResponse.Value.Details.ContentRange);
                    initialLength = recievedRange.GetRangeLength();
                    totalLength = recievedRange.TotalResourceLength.Value;
                }
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
                IEnumerable<HttpRange> ranges = GetRanges(initialLength, totalLength);

                // Rule checker cannot understand this section, but this
                // massively reduces code duplication.
                int effectiveWorkerCount = async ? _maxWorkerCount : 1;
                if (effectiveWorkerCount > 1)
                {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    await ParallelDownloadToAsync(
                        destination, effectiveWorkerCount, initialResponse, ranges, conditionsWithEtag, cancellationToken)
                        .ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                }
                else
                {
                    await SequentialDownloadToInternal(
                        destination, initialResponse, ranges, conditionsWithEtag, async, cancellationToken)
                        .ConfigureAwait(false);
                }

                return initialResponse.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task ParallelDownloadToAsync(
            Stream destination,
            int parallel,
            Response<BlobDownloadStreamingResult> initialResponse,
            IEnumerable<HttpRange> ranges,
            BlobRequestConditions conditionsWithEtag,
            CancellationToken cancellationToken)
        {
            if (parallel <= 1)
            {
                throw new ArgumentException("Parallel must be greater than 1 for parallel download.", nameof(parallel));
            }
            Queue<Task<BufferedDownloadResult>> bufferedTasks = new();

            // Easiest to rent whether or not we need it. It's just 8 bytes.
            using IDisposable _ = _arrayPool.RentDisposable(Crc64Len, out byte[] composedCrcBuf);
            composedCrcBuf.Clear();

            // Kick off downloads for subsequent ranges immediately.
            // They will download and buffer in the background while we stream the initial response below.
            // It is okay if some of these complete before we finish streaming the initial response. Due to
            // the sequential nature of this download, we cannot consume their output or begin new buffers
            // until we are done with the initial response.
            using IEnumerator<HttpRange> remainingRanges = ranges.GetEnumerator();
            // -1 makes space for the initial response handles separately
            while (bufferedTasks.Count < parallel-1 && remainingRanges.MoveNext())
            {
                bufferedTasks.Enqueue(DownloadAndBufferAsync(
                    remainingRanges.Current, conditionsWithEtag, cancellationToken));
            }

            // Stream the initial response directly to the destination
            // without buffering content into a rented array.
            using (_arrayPool.RentDisposable(_checksumSize, out byte[] partitionChecksum))
            {
                await CopyToInternal(initialResponse, destination, new(partitionChecksum, 0, _checksumSize), async: true, cancellationToken).ConfigureAwait(false);
                if (UseMasterCrc)
                {
                    StorageCrc64Composer.Compose(
                        (composedCrcBuf, 0L),
                        (partitionChecksum, initialResponse.Value.Details.ContentRange.GetContentRangeLengthOrDefault()
                            ?? initialResponse.Value.Details.ContentLength)
                    ).AsSpan(0, Crc64Len).CopyTo(composedCrcBuf);
                }
            }

            // Fill the queue with tasks to download each of the remaining
            // ranges in the blob
            while (remainingRanges.MoveNext())
            {
                while (bufferedTasks.Count >= parallel)
                {
                    await ConsumeBufferedTask().ConfigureAwait(false);
                }
                bufferedTasks.Enqueue(DownloadAndBufferAsync(
                    remainingRanges.Current, conditionsWithEtag, cancellationToken));
            }

            while (bufferedTasks.Count > 0)
            {
                await ConsumeBufferedTask().ConfigureAwait(false);
            }

            await FinalizeDownloadInternal(destination, composedCrcBuf?.AsMemory(0, Crc64Len) ?? default, async: true, cancellationToken)
                .ConfigureAwait(false);

            // Wait for the first buffered segment in the queue to complete,
            // write its data to the destination, and return buffers to the pool
            async Task ConsumeBufferedTask()
            {
                BufferedDownloadResult result = await bufferedTasks.Dequeue().ConfigureAwait(false);
                try
                {
                    // Write the fully-buffered data to the destination stream.
                    // Since the data is already in memory, this is very fast
                    // compared to streaming from the network.
                    result.BufferedStream.Position = 0;
                    await result.BufferedStream.CopyToInternal(destination, async: true, cancellationToken).ConfigureAwait(false);

                    if (UseMasterCrc && result.PartitionChecksum != null)
                    {
                        StorageCrc64Composer.Compose(
                            (composedCrcBuf, 0L),
                            (result.PartitionChecksum, result.ContentLength)
                        ).AsSpan(0, Crc64Len).CopyTo(composedCrcBuf);
                    }
                }
                finally
                {
                    result.BufferedStream.Dispose();
                }
            }
        }

        private async Task SequentialDownloadToInternal(
            Stream destination,
            Response<BlobDownloadStreamingResult> initialResponse,
            IEnumerable<HttpRange> ranges,
            BlobRequestConditions conditionsWithEtag,
            bool async,
            CancellationToken cancellationToken)
        {
            // Easiest to rent whether or not we need it. It's just 8 bytes.
            using IDisposable _composedCrc = _arrayPool.RentDisposable(Crc64Len, out byte[] composedCrcBuf);
            using IDisposable _partition = _arrayPool.RentDisposable(_checksumSize, out byte[] partitionChecksum);
            composedCrcBuf.Clear();

            List<Func<Task<Response<BlobDownloadStreamingResult>>>> allResponses = [() => Task.FromResult(initialResponse)];
            allResponses.AddRange(ranges.Select<HttpRange, Func<Task<Response<BlobDownloadStreamingResult>>>>(
                range => async () => await _client.DownloadStreamingInternal(
                    range,
                    conditionsWithEtag,
                    ValidationOptions,
                    _progress,
                    _innerOperationName,
                    async,
                    cancellationToken).ConfigureAwait(false)
                ));

            foreach (Func<Task<Response<BlobDownloadStreamingResult>>> getResponse in allResponses)
            {
                partitionChecksum.Clear();
                await CopyToInternal(await getResponse().ConfigureAwait(false), destination, new(partitionChecksum, 0, _checksumSize), async, cancellationToken).ConfigureAwait(false);
                if (UseMasterCrc)
                {
                    StorageCrc64Composer.Compose(
                        (composedCrcBuf, 0L),
                        (partitionChecksum, initialResponse.Value.Details.ContentRange.GetContentRangeLengthOrDefault()
                            ?? initialResponse.Value.Details.ContentLength)
                    ).AsSpan(0, Crc64Len).CopyTo(composedCrcBuf);
                }
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
            ReadOnlyMemory<byte> composedCrc,
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

        private async Task CopyToInternal(
            Response<BlobDownloadStreamingResult> response,
            Stream destination,
            Memory<byte> checksumBuffer,
            bool async,
            CancellationToken cancellationToken)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // if structured message, this crc is validated in the decoding process. don't decode it here.
            bool structuredMessage = response.GetRawResponse().Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader);
            using IHasher hasher = structuredMessage ? null : ContentHasher.GetHasherFromAlgorithmId(_validationAlgorithm);
            using Stream rawSource = response.Value.Content;
            using Stream source = hasher != null
                ? ChecksumCalculatingStream.GetReadStream(rawSource, hasher.AppendHash)
                : rawSource;

            await source.CopyToInternal(
                destination,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            // with structured message, the message integrity will already be validated,
            // but we can still get the responseChecksum out of the response object
            if (structuredMessage)
            {
                response.Value.Details.ContentCrc?.CopyTo(checksumBuffer.Span);
            }
            else if (hasher != null)
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

        /// <summary>
        /// Downloads a range and buffers the full response body into memory,
        /// performing responseChecksum validation during the read. This enables true
        /// parallel network I/O since each task fully consumes its HTTP response.
        /// </summary>
        private async Task<BufferedDownloadResult> DownloadAndBufferAsync(
            HttpRange range,
            BlobRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            Response<BlobDownloadStreamingResult> response = await _client.DownloadStreamingInternal(
                range,
                conditions,
                ValidationOptions,
                _progress,
                _innerOperationName,
                async: true,
                cancellationToken).ConfigureAwait(false);

            return await BufferResponseAsync(response, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads a download response fully into a <see cref="PooledMemoryStream"/> and
        /// validates its responseChecksum. The caller is responsible for disposing the
        /// returned stream, which returns its rented ArrayPool buffers.
        /// </summary>
        private async Task<BufferedDownloadResult> BufferResponseAsync(
            Response<BlobDownloadStreamingResult> response,
            CancellationToken cancellationToken)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            bool structuredMessage = response.GetRawResponse().Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader);
            using IHasher hasher = structuredMessage ? null : ContentHasher.GetHasherFromAlgorithmId(_validationAlgorithm);
            using Stream rawSource = response.Value.Content;
            using Stream source = hasher != null
                ? ChecksumCalculatingStream.GetReadStream(rawSource, hasher.AppendHash)
                : rawSource;

            long contentLen = response.Value.Details.ContentLength;
            PooledMemoryStream bufferedStream = new PooledMemoryStream(_arrayPool, Constants.MB);
            byte[] partitionChecksum = _checksumSize > 0 ? new byte[_checksumSize] : null;

            try
            {
                await source.CopyToExactInternal(bufferedStream, contentLen, async: true, cancellationToken)
                    .ConfigureAwait(false);

                // Ensure there is no additional data beyond the declared Content-Length.
                // Probe into a tiny dedicated buffer (not the data buffer) so that an upstream
                // bug returning a stale extraByte count can't silently corrupt payload bytes.
                using (_arrayPool.RentDisposable(1, out byte[] extraBuffer))
                {
                    int extraByte = await source.ReadAsync(extraBuffer, 0, 1, cancellationToken).ConfigureAwait(false);
                    if (extraByte > 0)
                    {
                        throw new InvalidOperationException("The response contained more data than was indicated by the Content-Length header.");
                    }
                }

                // Calculate and validate per-chunk responseChecksum
                if (structuredMessage)
                {
                    if (partitionChecksum != null)
                    {
                        response.Value.Details.ContentCrc?.CopyTo(partitionChecksum.AsSpan());
                    }
                }
                else if (hasher != null && partitionChecksum != null)
                {
                    hasher.GetFinalHash(partitionChecksum.AsSpan(0, _checksumSize));
                    (ReadOnlyMemory<byte> responseChecksum, StorageChecksumAlgorithm _)
                        = ContentHasher.GetResponseChecksumOrDefault(response.GetRawResponse());
                    if (!partitionChecksum.AsSpan(0, _checksumSize).SequenceEqual(responseChecksum.Span))
                    {
                        throw Errors.HashMismatchOnStreamedDownload(response.Value.Details.ContentRange);
                    }
                }

                long chunkContentLength = response.Value.Details.ContentRange.GetContentRangeLengthOrDefault()
                    ?? response.Value.Details.ContentLength;

                return new BufferedDownloadResult(bufferedStream, partitionChecksum, chunkContentLength);
            }
            catch
            {
                bufferedStream.Dispose();
                throw;
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
