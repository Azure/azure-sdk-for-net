// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> for appropriately downloading a blob using client-side encryption.
    /// Adjusts the download range requested, if any, to ensure enough info is present to decrypt, as well as
    /// pipes the returned content stream through a decryption stream. Should only be in pipelines for instances
    /// of <see cref="EncryptedBlobClient"/>
    /// </summary>
    internal class ClientSideDecryptionPolicy : HttpPipelinePolicy
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
        /// Initializes a new instance of the <see cref="ClientSideDecryptionPolicy"/> class with the specified key and resolver.
        /// <para />
        /// If <paramref name="key"/> is specified, that key will attempt to be used in decryption, provided it matches the
        /// content, before using the <paramref name="keyResolver"/> to find the correct key.
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
            LocalKey = key;
            KeyResolver = keyResolver;
        }

        #region Process

        /// <summary>
        /// If the request is fetching a specific range from the blob, adjust that range to download the extra bytes
        /// needed for decryption. On return, pipe the content through a CryptoStream to decrypt the data.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessImpl(message, pipeline, false).EnsureCompleted();
            //EncryptedBlobRange encryptedRange = default;
            //if (message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range))
            //{
            //    encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
            //    message.Request.Headers.SetValue(HttpHeader.Names.Range, encryptedRange.AdjustedRange.ToString());
            //}
            //else if (message.Request.Headers.TryGetValue(EncryptionConstants.XMsRange, out range))
            //{
            //    encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
            //    message.Request.Headers.SetValue(EncryptionConstants.XMsRange, encryptedRange.AdjustedRange.ToString());
            //}

            //ProcessNext(message, pipeline);

            //if (message.Request.Method == RequestMethod.Get &&
            //    message.Response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out var contentLength) &&
            //    long.Parse(contentLength, System.Globalization.CultureInfo.InvariantCulture) > 0)
            //{
            //    message.Response.ContentStream = DecryptBlobAsync(
            //        message.Response.ContentStream,
            //        ExtractMetadata(message.Response.Headers),
            //        encryptedRange,
            //        CanIgnorePadding(message.Response.Headers),
            //        false).EnsureCompleted();
            //}
        }

        /// <summary>
        /// If the request is fetching a specific range from the blob, adjust that range to download the extra bytes
        /// needed for decryption. On return, pipe the content through a CryptoStream to decrypt the data.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns></returns>
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessImpl(message, pipeline, false).ConfigureAwait(false);
            //EncryptedBlobRange encryptedRange = default;
            //if (message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range))
            //{
            //    encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
            //    message.Request.Headers.SetValue(HttpHeader.Names.Range, encryptedRange.AdjustedRange.ToString());
            //}
            //else if (message.Request.Headers.TryGetValue(EncryptionConstants.XMsRange, out range))
            //{
            //    encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
            //    message.Request.Headers.SetValue(EncryptionConstants.XMsRange, encryptedRange.AdjustedRange.ToString());
            //}

            //await ProcessNextAsync(message, pipeline).ConfigureAwait(false);

            //if (message.Request.Method != RequestMethod.Head &&
            //    message.Response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out var contentLength) &&
            //    long.Parse(contentLength, System.Globalization.CultureInfo.InvariantCulture) > 0)
            //{
            //    message.Response.ContentStream = await DecryptBlobAsync(
            //        message.Response.ContentStream,
            //        ExtractMetadata(message.Response.Headers),
            //        encryptedRange,
            //        CanIgnorePadding(message.Response.Headers),
            //        true).ConfigureAwait(false);
            //}
        }

        private async ValueTask ProcessImpl(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            EncryptedBlobRange encryptedRange = default;
            if (message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range))
            {
                encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
                message.Request.Headers.SetValue(HttpHeader.Names.Range, encryptedRange.AdjustedRange.ToString());
            }
            else if (message.Request.Headers.TryGetValue(EncryptionConstants.XMsRange, out range))
            {
                encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));
                message.Request.Headers.SetValue(EncryptionConstants.XMsRange, encryptedRange.AdjustedRange.ToString());
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            if (message.Request.Method != RequestMethod.Head &&
                message.Response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out var contentLength) &&
                long.Parse(contentLength, System.Globalization.CultureInfo.InvariantCulture) > 0)
            {
                var contentStreamTask = DecryptBlobAsync(
                    message.Response.ContentStream,
                    ExtractMetadata(message.Response.Headers),
                    encryptedRange,
                    CanIgnorePadding(message.Response.Headers),
                    async);

                message.Response.ContentStream = async
                    ? await contentStreamTask.ConfigureAwait(false)
                    : contentStreamTask.EnsureCompleted();
            }
        }

        #endregion

        private void AssertKeyAccessPresent()
        {
            if (LocalKey == default && KeyResolver == default)
            {
                throw EncryptionErrors.NoKeyAccessor(nameof(LocalKey), nameof(KeyResolver));
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
        private static bool CanIgnorePadding(ResponseHeaders headers)
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
                long.Parse(tokens[2], System.Globalization.CultureInfo.InvariantCulture) < EncryptionConstants.EncryptionBlockSize)
            {
                return false;
            }

            return true;
        }

        private async Task<Stream> DecryptBlobAsync(
            Stream ciphertext,
            Metadata metadata,
            EncryptedBlobRange encryptedBlobRange,
            bool noPadding,
            bool async)
        {
            AssertKeyAccessPresent();
            EncryptionData encryptionData = GetAndValidateEncryptionData(metadata);

            Stream plaintext;
            int read = 0;
            if (encryptionData != default)
            {
                byte[] IV;
                if (encryptedBlobRange.AdjustedRange.Offset == 0)
                {
                    IV = encryptionData.ContentEncryptionIV;
                }
                else
                {
                    IV = new byte[EncryptionConstants.EncryptionBlockSize];
                    if (async)
                    {
                        await ciphertext.ReadAsync(IV, 0, IV.Length).ConfigureAwait(false);
                    }
                    else
                    {
                        ciphertext.Read(IV, 0, IV.Length);
                    }
                    read = IV.Length;
                }

                var getKeyTask = GetContentEncryptionKeyAsync(encryptionData, async);
                var contentEncyptionKey = (async ? await getKeyTask.ConfigureAwait(false) : getKeyTask.EnsureCompleted()).ToArray();
                plaintext = WrapStream(
                    ciphertext,
                    contentEncyptionKey,
                    encryptionData,
                    IV,
                    noPadding);
            }
            else
            {
                plaintext = ciphertext;
            }

            // still need to readjust ranges even if we didn't decrypt anything, so keep this out of branch
            int gap = (int)(encryptedBlobRange.OriginalRange.Offset - encryptedBlobRange.AdjustedRange.Offset) - read;
            if (gap > 0)
            {
                // throw away initial bytes we want to trim off; stream cannot seek into future
                if (async)
                {
                    await plaintext.ReadAsync(new byte[gap], 0, gap).ConfigureAwait(false);
                }
                else
                {
                    plaintext.Read(new byte[gap], 0, gap);
                }
            }

            return new LengthLimitingStream(plaintext, encryptedBlobRange.OriginalRange.Length);
        }

        private static Metadata ExtractMetadata(ResponseHeaders headers)
        {
            Metadata metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (HttpHeader header in headers)
            {
                if (header.Name.StartsWith(Constants.HeaderNames.MetadataPrefix, StringComparison.OrdinalIgnoreCase))
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
        internal static EncryptionData GetAndValidateEncryptionData(Metadata metadata)
        {
            Debug.Assert(metadata != default);

            if (!metadata.TryGetValue(EncryptionConstants.EncryptionDataKey, out string encryptedDataString))
            {
                return default;
            }

            EncryptionData encryptionData = EncryptionData.Deserialize(encryptedDataString);

            _ = encryptionData.ContentEncryptionIV ?? throw EncryptionErrors.MissingEncryptionMetadata(
                nameof(EncryptionData.ContentEncryptionIV));
            _ = encryptionData.WrappedContentKey.EncryptedKey ?? throw EncryptionErrors.MissingEncryptionMetadata(
                nameof(EncryptionData.WrappedContentKey.EncryptedKey));

            // Throw if the encryption protocol on the message doesn't match the version that this client library
            // understands and is able to decrypt.
            if (EncryptionConstants.EncryptionProtocolV1 != encryptionData.EncryptionAgent.Protocol) {
                throw EncryptionErrors.BadEncryptionAgent(encryptionData.EncryptionAgent.Protocol);
            }

            return encryptionData;
        }

        /// <summary>
        /// Returns the key encryption key for blob. First tries to get key encryption key from KeyResolver, then
        /// falls back to IKey stored on this EncryptionPolicy.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <param name="async">Whether to perform asynchronously.</param>
        /// <returns>Encryption key as a byte array.</returns>
        private async Task<Memory<byte>> GetContentEncryptionKeyAsync(EncryptionData encryptionData, bool async)
        {
            IKeyEncryptionKey key;

            // If we already have a local key and it is the correct one, use that.
            if (encryptionData.WrappedContentKey.KeyId == LocalKey?.KeyId)
            {
                key = LocalKey;
            }
            // Otherwise, use the resolver.
            else if (KeyResolver != null)
            {
                var resolveTask = KeyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId);
                key = async
                    ? await KeyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId).ConfigureAwait(false)
                    : KeyResolver.Resolve(encryptionData.WrappedContentKey.KeyId);
            }
            else
            {
                throw EncryptionErrors.KeyNotFound(encryptionData.WrappedContentKey.KeyId);
            }

            if (key == default)
            {
                throw EncryptionErrors.NoKeyAccessor(nameof(LocalKey), nameof(KeyResolver));
            }

            return async
                ? await key.UnwrapKeyAsync(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey).ConfigureAwait(false)
                : key.UnwrapKey(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey);
        }

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

                        return new RollingBufferStream(
                            new CryptoStream(contentStream, aesProvider.CreateDecryptor(), CryptoStreamMode.Read),
                            EncryptionConstants.DefaultRollingBufferSize);
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
