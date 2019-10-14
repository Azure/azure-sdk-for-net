// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized.Cryptography.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> for appropriately downloading a blob using client-side encryption.
    /// Adjusts the download range requested, if any, to ensure enough info is present to decrypt, as well as
    /// pipes the returned content stream through a decryption stream. Should only be in pipelines for instances
    /// of <see cref="EncryptedBlobClient"/>
    /// </summary>
    public class ClientSideDecryptionPolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// The key resolver used to select the correct key for decrypting existing blobs.
        /// </summary>
        private IKeyEncryptionKeyResolver KeyResolver { get; }

        /// <summary>
        /// An already locally existing IKeyEncryptionKey, for key-fetching optimizations.
        /// </summary>
        private IKeyEncryptionKey LocalKey { get; }

        /// <summary>
        /// Initializes a new instance of the {@link BlobEncryptionPolicy} class with the specified key and resolver.
        /// <para />
        /// If the generated policy is intended to be used for encryption, users are expected to provide a key at the
        /// minimum.The absence of key will cause an exception to be thrown during encryption. If the generated policy is
        /// intended to be used for decryption, users can provide a keyResolver.The client library will - 1. Invoke the key
        /// resolver if specified to get the key. 2. If resolver is not specified but a key is specified, match the key id on
        /// the key and use it.
        /// </summary>
        /// <param name="keyResolver">
        /// Key resolver for finding the appropriate <see cref="IKeyEncryptionKey"/> to unwrap the blob's content
        /// encryption key.
        /// </param>
        /// <param name="key">
        /// The <see cref="IKeyEncryptionKey"/> used by this pipeline's client to wrap encryption keys on uploads, if present.
        /// Used to skip a key fetch with <paramref name="keyResolver"/> if unnecessary.
        /// </param>
        public ClientSideDecryptionPolicy(IKeyEncryptionKeyResolver keyResolver = default, IKeyEncryptionKey key = default)
        {
            this.LocalKey = key;
            this.KeyResolver = keyResolver;
        }

        #region Process

        /// <summary>
        /// If the request is fetching a specific range from the blob, adjust that range to download the extra bytes
        /// needed for decryption. On return, pipe the content through a CryptoStream to decrypt the data.
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            EncryptedBlobRange encryptedRange = default;
            if (message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range))
            {
                encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
                message.Request.Headers.Add(encryptedRange.AdjustedRange.ToRangeHeader());
            }
            else if (message.Request.Headers.TryGetValue(EncryptionConstants.XMsRange, out range))
            {
                encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
                message.Request.Headers.Remove(EncryptionConstants.XMsRange); // the next line puts "Range", not "x-ms-range"
                message.Request.Headers.Add(encryptedRange.AdjustedRange.ToRangeHeader());
            }

            ProcessNext(message, pipeline);

            if (message.Request.Method != RequestMethod.Head &&
                message.Response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out var contentLength) &&
                long.Parse(contentLength, System.Globalization.CultureInfo.InvariantCulture) > 0)
            {
                message.Response.ContentStream = DecryptBlob(
                    message.Response.ContentStream,
                    ExtractMetadata(message.Response.Headers),
                    encryptedRange,
                    IgnorePadding(message.Response.Headers));
            }
        }

        /// <summary>
        /// If the request is fetching a specific range from the blob, adjust that range to download the extra bytes
        /// needed for decryption. On return, pipe the content through a CryptoStream to decrypt the data.
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns></returns>
        public override async ValueTask ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            EncryptedBlobRange encryptedRange = default;
            if (message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range))
            {
                encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
                message.Request.Headers.Add(encryptedRange.AdjustedRange.ToRangeHeader());
            }
            else if (message.Request.Headers.TryGetValue(EncryptionConstants.XMsRange, out range))
            {
                encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
                message.Request.Headers.Remove(EncryptionConstants.XMsRange); // the next line puts "Range", not "x-ms-range"
                message.Request.Headers.Add(encryptedRange.AdjustedRange.ToRangeHeader());
            }

            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);

            if (message.Request.Method != RequestMethod.Head &&
                message.Response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out var contentLength) &&
                long.Parse(contentLength, System.Globalization.CultureInfo.InvariantCulture) > 0)
            {
                message.Response.ContentStream = await DecryptBlobAsync(
                    message.Response.ContentStream,
                    ExtractMetadata(message.Response.Headers),
                    encryptedRange,
                    IgnorePadding(message.Response.Headers)).ConfigureAwait(false);
            }
        }

        #endregion

        private void AssertKeyAccessPresent()
        {
            if (this.LocalKey == default && this.KeyResolver == default)
            {
                throw EncryptionErrors.NoKeyAccessor();
            }
        }

        /// <summary>
        /// Gets whether to ignore padding options for decryption.
        /// </summary>
        /// <param name="headers">Response headers for the download.</param>
        /// <returns>True if we should ignore padding.</returns>
        /// <remarks>
        /// If the last cipher block of the blob was returned, we need the padding. Otherwise, we can ignore it.
        /// </remarks>
        private static bool IgnorePadding(ResponseHeaders headers)
        {
            // if Content-Range not present, we requested the whole blob
            if (!headers.TryGetValue(Constants.HeaderNames.ContentRange, out string contentRange))
            {
                return false;
            }

            // parse header value (e.g. "bytes <start>-<end>/<blobSize>")
            // end is the inclusive last byte; e.g. header "bytes 0-7/8" is the entire 8-byte blob
            var tokens = contentRange.Split(new char[] { ' ', '-', '/' }); // ["bytes", "<start>", "<end>", "<blobSize>"]

            // did we request the last block?
            if (long.Parse(tokens[3], System.Globalization.CultureInfo.InvariantCulture) -
                long.Parse(tokens[2], System.Globalization.CultureInfo.InvariantCulture) < EncryptionConstants.ENCRYPTION_BLOCK_SIZE)
            {
                return false;
            }

            return true;
        }

        #region DecryptBlob

        private Stream DecryptBlob(Stream ciphertext, Metadata metadata,
            EncryptedBlobRange encryptedBlobRange, bool noPadding)
        {
            AssertKeyAccessPresent();
            var encryptionData = GetAndValidateEncryptionData(metadata);

            Stream plaintext;
            int read = 0;
            if (encryptionData.HasValue)
            {
                byte[] IV;
                if (encryptedBlobRange.AdjustedRange.Offset == 0)
                {
                    IV = encryptionData.Value.ContentEncryptionIV;
                }
                else
                {
                    IV = new byte[EncryptionConstants.ENCRYPTION_BLOCK_SIZE];
                    ciphertext.Read(IV, 0, IV.Length);
                    read = IV.Length;
                }

                plaintext = WrapStream(
                    ciphertext,
                    GetContentEncryptionKey(encryptionData.Value).ToArray(),
                    encryptionData.Value,
                    IV,
                    noPadding);
            }
            else
            {
                plaintext = ciphertext;
            }

            int gap;
            if ((gap = (int)(encryptedBlobRange.OriginalRange.Offset - encryptedBlobRange.AdjustedRange.Offset) - read) > 0)
            {
                plaintext.Read(new byte[gap], 0, gap);
            }

            return new LengthLimitingStream(plaintext, encryptedBlobRange.OriginalRange.Count);
        }

        private async Task<Stream> DecryptBlobAsync(Stream ciphertext, Metadata metadata,
            EncryptedBlobRange encryptedBlobRange, bool noPadding)
        {
            AssertKeyAccessPresent();
            var encryptionData = GetAndValidateEncryptionData(metadata);

            Stream plaintext;
            int read = 0;
            if (encryptionData.HasValue)
            {
                byte[] IV;
                if (encryptedBlobRange.AdjustedRange.Offset == 0)
                {
                    IV = encryptionData.Value.ContentEncryptionIV;
                }
                else
                {
                    IV = new byte[EncryptionConstants.ENCRYPTION_BLOCK_SIZE];
                    await ciphertext.ReadAsync(IV, 0, IV.Length).ConfigureAwait(false);
                    read = IV.Length;
                }

                plaintext = WrapStream(
                    ciphertext,
                    (await GetContentEncryptionKeyAsync(encryptionData.Value).ConfigureAwait(false)).ToArray(),
                    encryptionData.Value,
                    IV,
                    noPadding);
            }
            else
            {
                plaintext = ciphertext;
            }

            // still need to readjust ranges even if we didn't decrypt anything, so keep this out of branch
            int gap;
            if ((gap = (int)(encryptedBlobRange.OriginalRange.Offset - encryptedBlobRange.AdjustedRange.Offset) - read) > 0)
            {
                await plaintext.ReadAsync(new byte[gap], 0, gap).ConfigureAwait(false);
            }

            return new LengthLimitingStream(plaintext, encryptedBlobRange.OriginalRange.Count);
        }

        #endregion

        private static Metadata ExtractMetadata(ResponseHeaders headers)
        {
            Metadata metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (HttpHeader header in headers)
            {
                if (header.Name.StartsWith(Constants.HeaderNames.MetadataPrefix, StringComparison.InvariantCulture))
                {
                    metadata[header.Name.Substring(Constants.HeaderNames.MetadataPrefix.Length)] = header.Value;
                }
            }

            return metadata;
        }

        /// <summary>
        /// Gets and validates a blob's encryption-related metadata
        /// </summary>
        /// <param name="metadata">The blob's metadata</param>
        /// <returns>The relevant metadata.</returns>
        private static EncryptionData? GetAndValidateEncryptionData(Metadata metadata)
        {
            _ = metadata ?? throw new InvalidOperationException();

            if (!metadata.TryGetValue(EncryptionConstants.ENCRYPTION_DATA_KEY, out string encryptedDataString))
            {
                return default;
            }

            EncryptionData encryptionData = EncryptionData.Deserialize(encryptedDataString);

            _ = encryptionData.ContentEncryptionIV ?? throw new NullReferenceException();
            _ = encryptionData.WrappedContentKey.EncryptedKey ?? throw new NullReferenceException();

            // Throw if the encryption protocol on the message doesn't match the version that this client library
            // understands and is able to decrypt.
            if (EncryptionConstants.ENCRYPTION_PROTOCOL_V1 != encryptionData.EncryptionAgent.Protocol) {
                throw EncryptionErrors.BadEncryptionAgent(encryptionData.EncryptionAgent.Protocol);
            }

            return encryptionData;
        }

        #region GetContentEncryptionKey

        /// <summary>
        /// Returns the key encryption key for blob. First tries to get key encryption key from KeyResolver, then
        /// falls back to IKey stored on this EncryptionPolicy.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <returns>Encryption key as a byte array.</returns>
        private Memory<byte> GetContentEncryptionKey(EncryptionData encryptionData)
        {
            IKeyEncryptionKey key;

            // If we already have a local key and it is the correct one, use that.
            if (encryptionData.WrappedContentKey.KeyId == this.LocalKey?.KeyId)
            {
                key = this.LocalKey;
            }
            // Otherwise, use the resolver.
            else
            {
                key = this.KeyResolver?.Resolve(encryptionData.WrappedContentKey.KeyId)
                    ?? throw EncryptionErrors.KeyNotFound(encryptionData.WrappedContentKey.KeyId);
            }

            return key.UnwrapKey(
                encryptionData.WrappedContentKey.Algorithm,
                encryptionData.WrappedContentKey.EncryptedKey);
        }

        /// <summary>
        /// Returns the key encryption key for blob. First tries to get key encryption key from KeyResolver, then
        /// falls back to IKey stored on this EncryptionPolicy.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <returns>Encryption key as a byte array.</returns>
        private async Task<Memory<byte>> GetContentEncryptionKeyAsync(EncryptionData encryptionData)
        {
            IKeyEncryptionKey key;

            // If we already have a local key and it is the correct one, use that.
            if (encryptionData.WrappedContentKey.KeyId == this.LocalKey?.KeyId)
            {
                key = this.LocalKey;
            }
            // Otherwise, use the resolver.
            else
            {
                key = await (this.KeyResolver?.ResolveAsync(encryptionData.WrappedContentKey.KeyId) ??
                    throw EncryptionErrors.KeyNotFound(encryptionData.WrappedContentKey.KeyId)).ConfigureAwait(false);
            }

            return await key.UnwrapKeyAsync(
                encryptionData.WrappedContentKey.Algorithm,
                encryptionData.WrappedContentKey.EncryptedKey).ConfigureAwait(false);
        }

        #endregion

        private static Stream WrapStream(Stream contentStream, byte[] contentEncryptionKey,
            EncryptionData encryptionData, byte[] iv, bool noPadding)
        {
            if (!Enum.TryParse(encryptionData.EncryptionAgent.EncryptionAlgorithm, out ClientsideEncryptionAlgorithm algorithm))
            {
                throw EncryptionErrors.BadEncryptionAlgorithm();
            }
            switch (algorithm)
            {
                case ClientsideEncryptionAlgorithm.AES_CBC_256:
                    using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                    {
                        aesProvider.IV = iv ?? encryptionData.ContentEncryptionIV;
                        aesProvider.Key = contentEncryptionKey;

                        if (noPadding)
                        {
                            aesProvider.Padding = PaddingMode.None;
                        }

                        return new RollingBufferStream(new CryptoStream(contentStream, aesProvider.CreateDecryptor(), CryptoStreamMode.Read), 10 * Constants.MB);
                    }
                default:
                    throw EncryptionErrors.BadEncryptionAlgorithm();
            }
        }

        private static HttpRange ParseHttpRange(string serializedRange)
        {
            var rangeValues = serializedRange.Split('=')[1].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            switch (rangeValues.Length)
            {
                case 1:
                    return new HttpRange(
                        long.Parse(rangeValues[0], System.Globalization.CultureInfo.InvariantCulture));

                case 2:
                    var firstByte = long.Parse(rangeValues[0], System.Globalization.CultureInfo.InvariantCulture);
                    var lastByteInclusive = long.Parse(rangeValues[1], System.Globalization.CultureInfo.InvariantCulture);
                    return new HttpRange(firstByte, lastByteInclusive - firstByte + 1);

                default:
                    throw Errors.ParsingHttpRangeFailed();
            }
        }
    }
}
