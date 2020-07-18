// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

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
                return await TrimStreamInternal(content, originalRange, contentRange, pulledOutIV: false, async, cancellationToken).ConfigureAwait(false);
            }

            bool ivInStream = originalRange.Offset >= Constants.ClientSideEncryption.EncryptionBlockSize;

            // this method throws when key cannot be resolved. Blobs is intended to throw on this failure.
            var plaintext = await _decryptor.DecryptInternal(
                content,
                encryptionData,
                ivInStream,
                CanIgnorePadding(contentRange),
                async,
                cancellationToken).ConfigureAwait(false);

            return await TrimStreamInternal(plaintext, originalRange, contentRange, ivInStream, async, cancellationToken).ConfigureAwait(false);
        }

        private static async Task<Stream> TrimStreamInternal(
            Stream stream,
            HttpRange originalRange,
            ContentRange? receivedRange,
            bool pulledOutIV,
            bool async,
            CancellationToken cancellationToken)
        {
            // retrim start of stream to original requested location
            // keeping in mind whether we already pulled the IV out of the stream as well
            int gap = (int)(originalRange.Offset - (receivedRange?.Start ?? 0))
                - (pulledOutIV ? Constants.ClientSideEncryption.EncryptionBlockSize : 0);

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

        private static EncryptionData GetAndValidateEncryptionDataOrDefault(Metadata metadata)
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

            _ = encryptionData.ContentEncryptionIV ?? throw Errors.ClientSideEncryption.MissingEncryptionMetadata(
                nameof(EncryptionData.ContentEncryptionIV));
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

        internal static HttpRange GetEncryptedBlobRange(HttpRange originalRange)
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
}
