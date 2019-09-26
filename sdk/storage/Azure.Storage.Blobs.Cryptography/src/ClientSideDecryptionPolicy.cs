// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Azure.Core.Cryptography;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> for appropriately downloading a blob using client-side encryption.
    /// Adjusts the download range requested, if any, to ensure enough info is present to decrypt, as well as
    /// pipes the returned content stream through a decryption stream.
    /// </summary>
    public class ClientSideBlobDecryptionPolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// The key resolver used to select the correct key for decrypting existing blobs.
        /// </summary>
        private IKeyEncryptionKeyResolver KeyResolver { get; }

        /// <summary>
        /// The wrapper is used to wrap/unwrap the content key during encryption.
        /// </summary>
        private IKeyEncryptionKey KeyWrapper { get; }

        /// <summary>
        /// Initializes a new instance of the {@link BlobEncryptionPolicy} class with the specified key and resolver.
        /// <para />
        /// If the generated policy is intended to be used for encryption, users are expected to provide a key at the
        /// minimum.The absence of key will cause an exception to be thrown during encryption. If the generated policy is
        /// intended to be used for decryption, users can provide a keyResolver.The client library will - 1. Invoke the key
        /// resolver if specified to get the key. 2. If resolver is not specified but a key is specified, match the key id on
        /// the key and use it.
        /// </summary>
        /// <param name="key">The decryption key. Should not be set if <paramref name="keyResolver"/> is set.</param>
        /// <param name="keyResolver">Key resolver for getting the decryption key. Should not be set if <paramref name="key"/> is set.</param>
        public ClientSideBlobDecryptionPolicy(IKeyEncryptionKey key = default, IKeyEncryptionKeyResolver keyResolver = default)
        {
            this.KeyWrapper = key;
            this.KeyResolver = keyResolver;
        }

        #region Process

        /// <summary>
        /// If the request is fetching a specific range from the blob, adjust that range to download the extra bytes
        /// needed for decryption. On return, pipe the content through a CryptoStream to decrypt the data.
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns></returns>
        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range);
            var encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));

            ProcessNext(message, pipeline);

            if (message.Response.ContentStream != null)
            {
                if (!message.Response.Headers.TryGetValue(Constants.HeaderNames.ContentRange, out string contentRange))
                {
                    throw new ArgumentException($"HTTP response with body content did not specify {Constants.HeaderNames.ContentLength}");
                }

                message.Response.ContentStream = DecryptBlob(
                    message.Response.ContentStream,
                    ExtractMetadata(message.Request.Headers),
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
            message.Request.Headers.TryGetValue(HttpHeader.Names.Range, out var range);
            var encryptedRange = new EncryptedBlobRange(ParseHttpRange(range));

            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);

            if (message.Response.ContentStream != null)
            {
                message.Response.ContentStream = await DecryptBlobAsync(
                    message.Response.ContentStream,
                    ExtractMetadata(message.Request.Headers),
                    encryptedRange,
                    IgnorePadding(message.Response.Headers)).ConfigureAwait(false);
            }
        }

        #endregion

        private void AssertKeyAccessPresent()
        {
            if (this.KeyWrapper == default && this.KeyResolver == default)
            {
                throw new InvalidOperationException("Key and KeyResolver cannot both be null");
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
            // end is the inclusive last byte; header "bytes 0-7/8" is the entire 8-byte blob
            var tokens = contentRange.Split(new char[] { ' ', '-', '/' }); // ["bytes", "<start>", "<end>", "<blobSize>"]

            // did we request the last block?
            if (long.Parse(tokens[3], System.Globalization.CultureInfo.InvariantCulture) -
                long.Parse(tokens[2], System.Globalization.CultureInfo.InvariantCulture) < 16)
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

            byte[] IV;
            int read = 0;
            if (encryptedBlobRange.AdjustedRange.Offset == 0)
            {
                IV = encryptionData.ContentEncryptionIV;
            }
            else
            {
                IV = new byte[EncryptionConstants.ENCRYPTION_BLOCK_SIZE];
                ciphertext.Read(IV, 0, IV.Length);
                read = IV.Length;
            }

            CryptoStream plaintext = WrapStream(ciphertext, GetKeyEncryptionKey(encryptionData).ToArray(), encryptionData, IV, noPadding);

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

            byte[] IV;
            int read = 0;
            if (encryptedBlobRange.AdjustedRange.Offset == 0)
            {
                IV = encryptionData.ContentEncryptionIV;
            }
            else
            {
                IV = new byte[EncryptionConstants.ENCRYPTION_BLOCK_SIZE];
                await ciphertext.ReadAsync(IV, 0, IV.Length).ConfigureAwait(false);
                read = IV.Length;
            }

            CryptoStream plaintext = WrapStream(ciphertext, (await GetKeyEncryptionKeyAsync(encryptionData).ConfigureAwait(false)).ToArray(), encryptionData, IV, noPadding);

            int gap;
            if ((gap = (int)(encryptedBlobRange.OriginalRange.Offset - encryptedBlobRange.AdjustedRange.Offset) - read) > 0)
            {
                await plaintext.ReadAsync(new byte[gap], 0, gap).ConfigureAwait(false);
            }

            return new LengthLimitingStream(plaintext, encryptedBlobRange.OriginalRange.Count);
        }

        #endregion

        private Metadata ExtractMetadata(RequestHeaders headers)
        {
            const string metadataPrefix = "x-ms-meta-";

            Metadata metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (HttpHeader header in headers)
            {
                if (header.Name.StartsWith(metadataPrefix, StringComparison.InvariantCulture))
                {
                    metadata[header.Name.Substring(metadataPrefix.Length)] = header.Value;
                }
            }

            return metadata;
        }

        /// <summary>
        /// Gets and validates a blob's encryption-related metadata
        /// </summary>
        /// <param name="metadata">The blob's metadata</param>
        /// <returns>The relevant metadata.</returns>
        private EncryptionData GetAndValidateEncryptionData(Metadata metadata)
        {
            _ = metadata ?? throw new InvalidOperationException();

            EncryptionData encryptionData;
            if (metadata.TryGetValue(EncryptionConstants.ENCRYPTION_DATA_KEY, out string encryptedDataString))
            {
                using (var reader = new StringReader(encryptedDataString))
                {
                    var serializer = new XmlSerializer(typeof(EncryptionData));
                    encryptionData = (EncryptionData)serializer.Deserialize(reader);
                }
            }
            else
            {
                throw new InvalidOperationException("Encryption data does not exist.");
            }

            _ = encryptionData.ContentEncryptionIV ?? throw new NullReferenceException();
            _ = encryptionData.WrappedContentKey.EncryptedKey ?? throw new NullReferenceException();

            // Throw if the encryption protocol on the message doesn't match the version that this client library
            // understands
            // and is able to decrypt.
            if (EncryptionConstants.ENCRYPTION_PROTOCOL_V1 != encryptionData.EncryptionAgent.Protocol) {
                throw new ArgumentException(
                    "Invalid Encryption Agent. This version of the client library does not understand the " +
                        $"Encryption Agent set on the queue message: {encryptionData.EncryptionAgent}");
            }

            return encryptionData;
        }

        #region GetKeyEncryptionKey

        /// <summary>
        /// Returns the key encryption key for blob. First tries to get key encryption key from KeyResolver, then
        /// falls back to IKey stored on this EncryptionPolicy.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <returns>Encryption key as a byte array.</returns>
        private Memory<byte> GetKeyEncryptionKey(EncryptionData encryptionData)
        {
            /*
             * 1. Invoke the key resolver if specified to get the key. If the resolver is specified but does not have a
             * mapping for the key id, an error should be thrown. This is important for key rotation scenario.
             * 2. If resolver is not specified but a key is specified, match the key id on the key and and use it.
             */

            IKeyEncryptionKey key;

            if (this.KeyResolver != null)
            {
                key = this.KeyResolver.Resolve(encryptionData.WrappedContentKey.KeyId);
            }
            else
            {
                if (/*encryptionData.WrappedContentKey.KeyId == this.KeyWrapper.KeyId*/ true) //TODO fix once KeyId is in the interface
                {
                    key = this.KeyWrapper;
                }
                else
                {
                    throw new ArgumentException("Key mismatch. The key id stored on " +
                        "the service does not match the specified key.");
                }
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
        private async Task<Memory<byte>> GetKeyEncryptionKeyAsync(EncryptionData encryptionData)
        {
            /*
             * 1. Invoke the key resolver if specified to get the key. If the resolver is specified but does not have a
             * mapping for the key id, an error should be thrown. This is important for key rotation scenario.
             * 2. If resolver is not specified but a key is specified, match the key id on the key and and use it.
             */

            IKeyEncryptionKey key;

            if (this.KeyResolver != null)
            {
                key = await this.KeyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId).ConfigureAwait(false);
            }
            else
            {
                if (/*encryptionData.WrappedContentKey.KeyId == this.KeyWrapper.KeyId*/ true) //TODO fix once KeyId is in the interface
                {
                    key = this.KeyWrapper;
                }
                else
                {
                    throw new ArgumentException("Key mismatch. The key id stored on " +
                        "the service does not match the specified key.");
                }
            }

            return await key.UnwrapKeyAsync(
                encryptionData.WrappedContentKey.Algorithm,
                encryptionData.WrappedContentKey.EncryptedKey).ConfigureAwait(false);
        }

        #endregion

        private CryptoStream WrapStream(Stream contentStream, byte[] contentEncryptionKey,
            EncryptionData encryptionData, byte[] iv, bool noPadding)
        {
            switch (encryptionData.EncryptionAgent.Algorithm)
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

                        return new CryptoStream(contentStream, aesProvider.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                default:
                    throw new ArgumentException(
                        "Invalid Encryption Algorithm found on the resource. This version of the client library " +
                            "does not support the specified encryption algorithm.");
            }
        }

        private static HttpRange ParseHttpRange(string serializedRange)
        {
            var rangeValues = serializedRange.Split('=')[1].Split('-');

            switch (rangeValues.Length)
            {
                case 1:
                    return new HttpRange(
                        long.Parse(rangeValues[0], System.Globalization.CultureInfo.InvariantCulture));

                case 2:
                    return new HttpRange(
                        long.Parse(rangeValues[0], System.Globalization.CultureInfo.InvariantCulture),
                        long.Parse(rangeValues[1], System.Globalization.CultureInfo.InvariantCulture));

                default:
                    throw new ArgumentException("Could not parse the serialized range.", nameof(serializedRange));
            }
        }
    }
}
