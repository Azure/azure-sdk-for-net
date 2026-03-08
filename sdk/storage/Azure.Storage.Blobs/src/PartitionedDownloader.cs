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

        private const int Crc64Len = Constants.StorageCrc64SizeInBytes;

        /// <summary>
        /// Holds the result of downloading and buffering a single range into memory.
        /// The caller is responsible for returning Buffer and PartitionChecksum to the ArrayPool.
        /// </summary>
        private readonly struct BufferedDownloadResult
        {
            public readonly byte[] Buffer;
            public readonly int BytesRead;
            public readonly byte[] PartitionChecksum;
            public readonly long ContentLength;

            public BufferedDownloadResult(byte[] buffer, int bytesRead, byte[] partitionChecksum, long contentLength)
            {
                Buffer = buffer;
                BytesRead = bytesRead;
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
        // TODO disabling master crc temporarily. segment CRCs still handled.
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
            Queue<Task<BufferedDownloadResult>> bufferedTasks = null;

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
                byte[] composedCrcBuf = default;
                if (UseMasterCrc)
                {
                    _masterCrcCalculator = StorageCrc64HashAlgorithm.Create();
                    destination = ChecksumCalculatingStream.GetWriteStream(destination, _masterCrcCalculator.Append);
                    disposables.Add(_arrayPool.RentDisposable(Crc64Len, out composedCrcBuf));
                    composedCrcBuf.Clear();
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

#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                // Rule checker cannot understand this section, but this
                // massively reduces code duplication.
                int effectiveWorkerCount = async ? _maxWorkerCount : 1;
                if (effectiveWorkerCount > 1)
                {
                    // Buffer the initial response into memory as a task
                    // (runs concurrently with subsequent download tasks)
                    bufferedTasks = new();
                    bufferedTasks.Enqueue(BufferResponseAsync(initialResponse, cancellationToken));
                }
                else
                {
                    using (_arrayPool.RentDisposable(_checksumSize, out byte[] partitionChecksum))
                    {
                        await CopyToInternal(initialResponse, destination, new(partitionChecksum, 0, _checksumSize), async, cancellationToken).ConfigureAwait(false);
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

                // Fill the queue with tasks to download each of the remaining
                // ranges in the blob
                foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
                {
                    if (bufferedTasks != null)
                    {
                        // Download and buffer the range data in parallel.
                        // Each task sends the HTTP request AND reads the full
                        // response body into a rented buffer, enabling true
                        // parallel network I/O across all workers.
                        bufferedTasks.Enqueue(DownloadAndBufferAsync(
                            httpRange, conditionsWithEtag, cancellationToken));

                        // If we have fewer tasks than allotted workers, then just
                        // continue adding tasks until we have effectiveWorkerCount
                        // running in parallel
                        if (bufferedTasks.Count < effectiveWorkerCount)
                        {
                            continue;
                        }

                        // Once all the workers are busy, wait for the first
                        // segment to finish and write it to the destination
                        await ConsumeBufferedTask().ConfigureAwait(false);
                    }
                    else
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
                        Response<BlobDownloadStreamingResult> result = await responseValueTask.ConfigureAwait(false);
                        using (_arrayPool.RentDisposable(_checksumSize, out byte[] partitionChecksum))
                        {
                            await CopyToInternal(result, destination, new(partitionChecksum, 0, _checksumSize), async, cancellationToken).ConfigureAwait(false);
                            if (UseMasterCrc)
                            {
                                StorageCrc64Composer.Compose(
                                    (composedCrcBuf, 0L),
                                    (partitionChecksum, result.Value.Details.ContentRange.GetContentRangeLengthOrDefault()
                                    ?? result.Value.Details.ContentLength)
                                ).AsSpan(0, Crc64Len).CopyTo(composedCrcBuf);
                            }
                        }
                    }
                }

                // Wait for all of the remaining segments to download
                if (bufferedTasks != null)
                {
                    while (bufferedTasks.Count > 0)
                    {
                        await ConsumeBufferedTask().ConfigureAwait(false);
                    }
                }
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.

                await FinalizeDownloadInternal(destination, composedCrcBuf?.AsMemory(0, Crc64Len) ?? default, async, cancellationToken)
                    .ConfigureAwait(false);
                return initialResponse.GetRawResponse();

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
                        await destination.WriteAsync(result.Buffer, 0, result.BytesRead, cancellationToken).ConfigureAwait(false);

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
                        _arrayPool.Return(result.Buffer);
                        if (result.PartitionChecksum != null)
                        {
                            _arrayPool.Return(result.PartitionChecksum);
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
                if (bufferedTasks != null)
                {
                    async Task ReturnBuffersAsync(Task<BufferedDownloadResult> task)
                    {
                        try
                        {
                            BufferedDownloadResult result = await task.ConfigureAwait(false);
                            _arrayPool.Return(result.Buffer);
                            if (result.PartitionChecksum != null)
                            {
                                _arrayPool.Return(result.PartitionChecksum);
                            }
                        }
                        catch
                        {
                            // Task faulted during download; no buffers to return
                        }
                    }
                    await Task.WhenAll(bufferedTasks.Select(ReturnBuffersAsync)).ConfigureAwait(false);
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
            // but we can still get the checksum out of the response object
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
        /// performing checksum validation during the read. This enables true
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
        /// Reads a download response fully into a rented buffer and validates its checksum.
        /// The caller is responsible for returning the rented Buffer and PartitionChecksum
        /// arrays to the ArrayPool when done.
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

            // Determine buffer size from response content length
            long contentLen = response.Value.Details.ContentLength;
            int bufferSize = contentLen > 0 ? (int)contentLen : (int)_rangeSize;

            byte[] buffer = _arrayPool.Rent(bufferSize);
            byte[] partitionChecksum = _checksumSize > 0 ? _arrayPool.Rent(_checksumSize) : null;

            try
            {
                // Read the full response body into the buffer
                int totalRead = 0;
                int bytesRead;
                while ((bytesRead = await source.ReadAsync(
                    buffer, totalRead, buffer.Length - totalRead, cancellationToken).ConfigureAwait(false)) > 0)
                {
                    totalRead += bytesRead;
                }

                // Calculate and validate per-chunk checksum
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
                    (ReadOnlyMemory<byte> checksum, StorageChecksumAlgorithm _)
                        = ContentHasher.GetResponseChecksumOrDefault(response.GetRawResponse());
                    if (!partitionChecksum.AsSpan(0, _checksumSize).SequenceEqual(checksum.Span))
                    {
                        throw Errors.HashMismatchOnStreamedDownload(response.Value.Details.ContentRange);
                    }
                }

                long chunkContentLength = response.Value.Details.ContentRange.GetContentRangeLengthOrDefault()
                    ?? response.Value.Details.ContentLength;

                return new BufferedDownloadResult(buffer, totalRead, partitionChecksum, chunkContentLength);
            }
            catch
            {
                _arrayPool.Return(buffer);
                if (partitionChecksum != null)
                {
                    _arrayPool.Return(partitionChecksum);
                }
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
