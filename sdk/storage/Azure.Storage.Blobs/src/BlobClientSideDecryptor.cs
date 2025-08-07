// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Blobs
{
    internal class BlobClientSideDecryptor
    {
        private readonly ClientSideDecryptor _decryptor;

        public BlobClientSideDecryptor(ClientSideDecryptor decryptor)
        {
            _decryptor = decryptor;
        }

        public async Task<Stream> DecryptInternal(
            Stream content,
            Metadata metadata,
            HttpRange originalRange,
            string receivedContentRange,
            bool async,
            CancellationToken cancellationToken)
        {
            ContentRange? contentRange = string.IsNullOrWhiteSpace(receivedContentRange)
                ? default
                : ContentRange.Parse(receivedContentRange);

            EncryptionData encryptionData = GetAndValidateEncryptionDataOrDefault(metadata);
            if (encryptionData == default)
            {
                return await TrimStreamInternal(content, originalRange, contentRange, alreadyTrimmedOffsetAmount: 0, async, cancellationToken).ConfigureAwait(false);
            }

            bool ivInStream = originalRange.Offset >= Constants.ClientSideEncryption.EncryptionBlockSize;

            // this method throws when key cannot be resolved. Blobs is intended to throw on this failure.
            var plaintext = await _decryptor.DecryptReadInternal(
                content,
                encryptionData,
                ivInStream,
                CanIgnorePadding(contentRange),
                async,
                cancellationToken).ConfigureAwait(false);

            int v2StartRegion0Indexed = (int)((contentRange?.Start / encryptionData.EncryptedRegionInfo?.GetTotalRegionLength()) ?? 0);
            int alreadyTrimmedOffset = encryptionData.EncryptionAgent.EncryptionVersion switch
            {
#pragma warning disable CS0618 // obsolete
                ClientSideEncryptionVersionInternal.V1_0 => ivInStream ? Constants.ClientSideEncryption.EncryptionBlockSize : 0,
#pragma warning restore CS0618 // obsolete
                // first block is special case where we don't want to communicate a trim. Otherwise communicate nonce length * 1-indexed start region + tag length * 0-indexed region
                ClientSideEncryptionVersionInternal.V2_0 or ClientSideEncryptionVersionInternal.V2_1 => contentRange?.Start > 0
                    ? (-encryptionData.EncryptedRegionInfo.NonceLength * (v2StartRegion0Indexed)) - (Constants.ClientSideEncryption.V2.TagSize * v2StartRegion0Indexed)
                    : 0,
                _ => throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported()
            };
            return await TrimStreamInternal(plaintext, originalRange, contentRange, alreadyTrimmedOffset, async, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Stream> DecryptWholeBlobWriteInternal(
            Stream plaintextDestination,
            Metadata metadata,
            bool async,
            CancellationToken cancellationToken)
        {
            EncryptionData encryptionData = GetAndValidateEncryptionDataOrDefault(metadata);
            if (encryptionData == default)
            {
                return plaintextDestination;
            }

            return await _decryptor.DecryptWholeContentWriteInternal(
                plaintextDestination,
                encryptionData,
                async,
                cancellationToken).ConfigureAwait(false);
        }

        private static async Task<Stream> TrimStreamInternal(
            Stream stream,
            HttpRange originalRange,
            ContentRange? receivedRange,
            // iv or nonce in stream could have already been trimmed during decryption
            int alreadyTrimmedOffsetAmount,
            bool async,
            CancellationToken cancellationToken)
        {
            // retrim start of stream to original requested location
            // keeping in mind whether we already trimmed due to an IV or nonce
            int gap = (int)(originalRange.Offset - (receivedRange?.Start ?? 0)) - alreadyTrimmedOffsetAmount;

            int read = 0;
            while (gap > read)
            {
                int toRead = gap - read;
                // throw away initial bytes we want to trim off; stream cannot seek into future
                if (async)
                {
                    read += await stream.ReadAsync(new byte[toRead], 0, toRead, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    read += stream.Read(new byte[toRead], 0, toRead);
                }
            }

            if (originalRange.Length.HasValue)
            {
                stream = WindowStream.GetWindow(stream, originalRange.Length.Value);
            }

            return stream;
        }

        internal static EncryptionData GetAndValidateEncryptionDataOrDefault(Metadata metadata)
        {
            if (metadata == default)
            {
                return default;
            }
            if (!metadata.TryGetValue(Constants.ClientSideEncryption.EncryptionDataKey, out string encryptedDataString))
            {
                return default;
            }

            EncryptionData encryptionData = EncryptionDataSerializer.Deserialize(encryptedDataString);

            switch (encryptionData.EncryptionAgent.EncryptionVersion)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V1_0:
                    _ = encryptionData.ContentEncryptionIV ?? throw Errors.ClientSideEncryption.MissingEncryptionMetadata(
                        nameof(EncryptionData.ContentEncryptionIV));
                    break;
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V2_0:
                case ClientSideEncryptionVersionInternal.V2_1:
                    _ = encryptionData.EncryptedRegionInfo ?? throw Errors.ClientSideEncryption.MissingEncryptionMetadata(
                        nameof(EncryptionData.EncryptedRegionInfo));
                    break;
                default:
                    throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported();
            }
            _ = encryptionData.WrappedContentKey.EncryptedKey ?? throw Errors.ClientSideEncryption.MissingEncryptionMetadata(
                nameof(EncryptionData.WrappedContentKey.EncryptedKey));

            return encryptionData;
        }

        /// <summary>
        /// Gets whether to ignore padding options for decryption.
        /// </summary>
        /// <param name="contentRange">Downloaded content range.</param>
        /// <returns>True if we should ignore padding.</returns>
        /// <remarks>
        /// If the last cipher block of the blob was returned, we need the padding. Otherwise, we can ignore it.
        /// </remarks>
        private static bool CanIgnorePadding(ContentRange? contentRange)
        {
            // if Content-Range not present, we requested the whole blob
            if (contentRange == null)
            {
                return false;
            }

            // if range is wildcard, we requested the whole blob
            if (!contentRange.Value.End.HasValue)
            {
                return false;
            }

            // blob storage will always return ContentRange.Size
            // we don't have to worry about the impossible decision of what to do if it doesn't

            // did we request the last block?
            // end is inclusive/0-index, so end = n and size = n+1 means we requested the last block
            if (contentRange.Value.Size - contentRange.Value.End == 1)
            {
                return false;
            }

            return true;
        }

        internal static HttpRange GetEncryptedBlobRange(HttpRange originalRange, string rawEncryptionData)
        {
            Argument.AssertNotNull(rawEncryptionData, nameof(rawEncryptionData));
            EncryptionData encryptionData = EncryptionDataSerializer.Deserialize(rawEncryptionData);
            return GetEncryptedBlobRange(originalRange, encryptionData);
        }

        internal static HttpRange GetEncryptedBlobRange(HttpRange originalRange, EncryptionData encryptionData)
        {
            if (encryptionData == default)
            {
                return originalRange;
            }

            switch (encryptionData.EncryptionAgent.EncryptionVersion)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V1_0:
                    return GetEncryptedBlobRangeV1_0(originalRange);
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V2_0:
                case ClientSideEncryptionVersionInternal.V2_1:
                    return GetEncryptedBlobRangeV2_0(originalRange, encryptionData);
                default:
                    throw Errors.InvalidArgument(nameof(encryptionData));
            }
        }

        private static HttpRange GetEncryptedBlobRangeV2_0(HttpRange originalRange, EncryptionData encryptionData)
        {
            int encryptedRegionDataSize = encryptionData.EncryptedRegionInfo.DataLength;
            int totalEncryptedRegionSize = encryptionData.EncryptedRegionInfo.NonceLength
                + encryptionData.EncryptedRegionInfo.DataLength
                + Constants.ClientSideEncryption.V2.TagSize;

            long newOffset = 0;
            long? newCount = null;

            if (originalRange.Offset != 0)
            {
                // determine region number range start resides in, set offset to start of that total region
                long regionNum = originalRange.Offset / encryptedRegionDataSize;
                newOffset = regionNum * totalEncryptedRegionSize;
            }

            if (originalRange.Length != null)
            {
                // determine region number range end resides in, set count to finish at end of that total region
                long regionNum = (originalRange.Offset + originalRange.Length.Value - 1) / encryptedRegionDataSize;
                newCount = (regionNum + 1) * totalEncryptedRegionSize - newOffset;
            }

            return new HttpRange(newOffset, newCount);
        }

        private static HttpRange GetEncryptedBlobRangeV1_0(HttpRange originalRange)
        {
            int offsetAdjustment = 0;
            long? adjustedDownloadCount = originalRange.Length;

            // Calculate offsetAdjustment.
            if (originalRange.Offset != 0)
            {
                // Align with encryption block boundary.
                int diff;
                if ((diff = (int)(originalRange.Offset % Constants.ClientSideEncryption.EncryptionBlockSize)) != 0)
                {
                    offsetAdjustment += diff;
                    if (adjustedDownloadCount != default)
                    {
                        adjustedDownloadCount += diff;
                    }
                }

                // Account for IV.
                if (originalRange.Offset >= Constants.ClientSideEncryption.EncryptionBlockSize)
                {
                    offsetAdjustment += Constants.ClientSideEncryption.EncryptionBlockSize;
                    // Increment adjustedDownloadCount if necessary.
                    if (adjustedDownloadCount != default)
                    {
                        adjustedDownloadCount += Constants.ClientSideEncryption.EncryptionBlockSize;
                    }
                }
            }

            // Align adjustedDownloadCount with encryption block boundary at the end of the range. Note that it is impossible
            // to adjust past the end of the blob as an encrypted blob was padded to align to an encryption block boundary.
            if (adjustedDownloadCount != null)
            {
                adjustedDownloadCount += (
                    Constants.ClientSideEncryption.EncryptionBlockSize - (int)(adjustedDownloadCount
                    % Constants.ClientSideEncryption.EncryptionBlockSize)
                ) % Constants.ClientSideEncryption.EncryptionBlockSize;
            }

            return new HttpRange(originalRange.Offset - offsetAdjustment, adjustedDownloadCount);
        }
    }

    internal static class EncryptionRangeExtensions
    {
        public static int GetTotalRegionLength(this EncryptedRegionInfo info)
        {
            return info.NonceLength + info.DataLength + Constants.ClientSideEncryption.V2.TagSize;
        }
    }
}
