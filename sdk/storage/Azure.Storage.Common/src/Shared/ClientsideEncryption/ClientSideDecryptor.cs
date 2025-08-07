// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using Azure.Storage.Cryptography.Models;
using static Azure.Storage.Cryptography.Models.ClientSideEncryptionVersionExtensions;

namespace Azure.Storage.Cryptography
{
    internal class ClientSideDecryptor
    {
        /// <summary>
        /// A cache for encryption key if high level API spans across multiple service calls.
        /// </summary>
        private static readonly AsyncLocal<ContentEncryptionKeyCache> s_contentEncryptionKeyCache = new();

        /// <summary>
        /// Clients that can upload data have a key encryption key stored on them. Checking if
        /// a cached key exists and matches a given <see cref="EncryptionData"/> saves a call
        /// to the external key resolver implementation when available.
        /// </summary>
        private readonly IKeyEncryptionKey _potentialCachedIKeyEncryptionKey;

        /// <summary>
        /// Resolver to fetch the key encryption key.
        /// </summary>
        private readonly IKeyEncryptionKeyResolver _keyResolver;

        public ClientSideDecryptor(ClientSideEncryptionOptions options)
        {
            _potentialCachedIKeyEncryptionKey = options.KeyEncryptionKey;
            _keyResolver = options.KeyResolver;
        }

        /// <summary>
        /// Decrypts the given stream if decryption information is provided.
        /// Does not shave off unwanted start/end bytes, but will shave off padding.
        /// </summary>
        /// <param name="ciphertext">Stream to decrypt.</param>
        /// <param name="encryptionData">
        /// Encryption metadata and wrapped content encryption key.
        /// </param>
        /// <param name="ivInStream">
        /// Whether to use the first block of the stream for the IV instead of the value in
        /// <paramref name="encryptionData"/>. Generally for partial blob downloads where the
        /// previous block of the ciphertext is the IV for the next.
        /// </param>
        /// <param name="noPadding">
        /// Whether to ignore padding. Generally for partial blob downloads where the end of
        /// the blob (where the padding occurs) was not downloaded. V1 only.
        /// </param>
        /// <param name="async">Whether to perform this function asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Decrypted plaintext.
        /// </returns>
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
        public async Task<Stream> DecryptReadInternal(
            Stream ciphertext,
            EncryptionData encryptionData,
            bool ivInStream,
            bool noPadding,
            bool async,
            CancellationToken cancellationToken)
        {
            switch (encryptionData.EncryptionAgent.EncryptionVersion)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V1_0:
                    return await DecryptReadInternalV1_0(
                        ciphertext,
                        encryptionData,
                        ivInStream,
                        noPadding,
                        async,
                        cancellationToken).ConfigureAwait(false);
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V2_0:
                case ClientSideEncryptionVersionInternal.V2_1:
                    return await DecryptInternalV2_0(
                        ciphertext,
                        encryptionData,
                        CryptoStreamMode.Read,
                        async,
                        cancellationToken).ConfigureAwait(false);
                default:
                    throw Errors.ClientSideEncryption.BadEncryptionAgent(encryptionData.EncryptionAgent.EncryptionVersion.ToString());
            }
        }

        /// <summary>
        /// Wraps a write stream in a decryption stream.
        /// </summary>
        /// <param name="plaintextDestination">Stream to wrap.</param>
        /// <param name="encryptionData">
        /// Encryption metadata and wrapped content encryption key.
        /// </param>
        /// <param name="async">Whether to perform this function asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Decryption stream.
        /// </returns>
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
        /// <remarks>
        /// This method does not accept parameters situational to a ranged read. This library does not
        /// use a write paradigm for ranged reads, and so this extra support is being skipped.
        /// </remarks>
        public async Task<Stream> DecryptWholeContentWriteInternal(
            Stream plaintextDestination,
            EncryptionData encryptionData,
            bool async,
            CancellationToken cancellationToken)
        {
            switch (encryptionData.EncryptionAgent.EncryptionVersion)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V1_0:
                    return await DecryptWholeContentWriteInternalV1_0(
                        plaintextDestination,
                        encryptionData,
                        async,
                        cancellationToken).ConfigureAwait(false);
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V2_0:
                case ClientSideEncryptionVersionInternal.V2_1:
                    return await DecryptInternalV2_0(
                        plaintextDestination,
                        encryptionData,
                        CryptoStreamMode.Write,
                        async,
                        cancellationToken).ConfigureAwait(false);
                default:
                    throw Errors.ClientSideEncryption.BadEncryptionAgent(encryptionData.EncryptionAgent.EncryptionVersion.ToString());
            }
        }

        #region V2
        private async Task<Stream> DecryptInternalV2_0(
            Stream ciphertext,
            EncryptionData encryptionData,
            CryptoStreamMode mode,
            bool async,
            CancellationToken cancellationToken)
        {
            if (encryptionData.EncryptionAgent.EncryptionAlgorithm != ClientSideEncryptionAlgorithm.AesGcm256)
            {
                throw Errors.ClientSideEncryption.BadEncryptionAlgorithm(encryptionData.EncryptionAgent.EncryptionAlgorithm.ToString());
            }

            var contentEncryptionKey = await GetContentEncryptionKeyAsync(
                encryptionData,
                async,
                cancellationToken).ConfigureAwait(false);
            var authRegionDataLength = encryptionData.EncryptedRegionInfo.DataLength;

            return WrapStreamV2_0(ciphertext, mode, contentEncryptionKey.ToArray(), authRegionDataLength);
        }

        private static Stream WrapStreamV2_0(
            Stream contentStream,
            CryptoStreamMode mode,
            byte[] contentEncryptionKey,
            int authRegionPlaintextSize)
        {
            // gcm disposed by stream
            var gcm = new GcmAuthenticatedCryptographicTransform(contentEncryptionKey, TransformMode.Decrypt);
            return new AuthenticatedRegionCryptoStream(
                contentStream,
                gcm,
                authRegionPlaintextSize,
                mode);
        }
        #endregion

        #region V1
        /// <summary>
        /// Decrypts the given stream if decryption information is provided.
        /// Does not shave off unwanted start/end bytes, but will shave off padding.
        /// </summary>
        /// <param name="ciphertext">Stream to decrypt.</param>
        /// <param name="encryptionData">
        /// Encryption metadata and wrapped content encryption key.
        /// </param>
        /// <param name="ivInStream">
        /// Whether to use the first block of the stream for the IV instead of the value in
        /// <paramref name="encryptionData"/>. Generally for partial blob downloads where the
        /// previous block of the ciphertext is the IV for the next.
        /// </param>
        /// <param name="noPadding">
        /// Whether to ignore padding. Generally for partial blob downloads where the end of
        /// the blob (where the padding occurs) was not downloaded.
        /// </param>
        /// <param name="async">Whether to perform this function asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Decrypted plaintext.
        /// </returns>
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
        private async Task<Stream> DecryptReadInternalV1_0(
            Stream ciphertext,
            EncryptionData encryptionData,
            bool ivInStream,
            bool noPadding,
            bool async,
            CancellationToken cancellationToken)
        {
            var contentEncryptionKey = await GetContentEncryptionKeyAsync(
                encryptionData,
                async,
                cancellationToken).ConfigureAwait(false);

            Stream plaintext;
            //int read = 0;
            if (encryptionData != default)
            {
                byte[] IV;
                if (!ivInStream)
                {
                    IV = encryptionData.ContentEncryptionIV;
                }
                else
                {
                    IV = new byte[Constants.ClientSideEncryption.EncryptionBlockSize];
                    if (async)
                    {
                        await ciphertext.ReadAsync(IV, 0, IV.Length, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        int totalRead = 0;
                        while (totalRead < IV.Length)
                        {
                            //  Stream.Read may return fewer bytes than requested, resulting in unreliable code.
                            var bytesRead = ciphertext.Read(IV, totalRead, IV.Length - totalRead);
                            totalRead += bytesRead;
                            if (bytesRead == 0) break;
                        }
                    }
                    //read = IV.Length;
                }

                plaintext = WrapStreamV1_0(
                    ciphertext,
                    contentEncryptionKey.ToArray(),
                    encryptionData,
                    IV,
                    noPadding,
                    CryptoStreamMode.Read);
            }
            else
            {
                plaintext = ciphertext;
            }

            return plaintext;
        }

        /// <summary>
        /// Decrypts the given stream if decryption information is provided.
        /// Does not shave off unwanted start/end bytes, but will shave off padding.
        /// </summary>
        /// <param name="plaintextDestination">Stream to decrypt.</param>
        /// <param name="encryptionData">
        /// Encryption metadata and wrapped content encryption key.
        /// </param>
        /// <param name="async">Whether to perform this function asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Decrypted plaintext.
        /// </returns>
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
        private async Task<Stream> DecryptWholeContentWriteInternalV1_0(
            Stream plaintextDestination,
            EncryptionData encryptionData,
            bool async,
            CancellationToken cancellationToken)
        {
            if (encryptionData != default)
            {
                var contentEncryptionKey = await GetContentEncryptionKeyAsync(
                    encryptionData,
                    async,
                    cancellationToken).ConfigureAwait(false);

                plaintextDestination = WrapStreamV1_0(
                    plaintextDestination,
                    contentEncryptionKey.ToArray(),
                    encryptionData,
                    encryptionData.ContentEncryptionIV,
                    noPadding: false,
                    CryptoStreamMode.Write);
            }

            return plaintextDestination;
        }

        /// <summary>
        /// Wraps a stream to decrypt on reads or writes.
        /// </summary>
        private static Stream WrapStreamV1_0(
            Stream contentStream,
            byte[] contentEncryptionKey,
            EncryptionData encryptionData,
            byte[] iv,
            bool noPadding,
            CryptoStreamMode mode)
        {
            if (encryptionData.EncryptionAgent.EncryptionAlgorithm == ClientSideEncryptionAlgorithm.AesCbc256)
            {
#if NET6_0_OR_GREATER
                using (Aes aes = Aes.Create())
#else
                using (Aes aes = new AesCryptoServiceProvider())
#endif
                {
                    aes.IV = iv ?? encryptionData.ContentEncryptionIV;
                    aes.Key = contentEncryptionKey;

                    if (noPadding)
                    {
                        aes.Padding = PaddingMode.None;
                    }

                    // Buffer network stream. CryptoStream issues tiny (~16 byte) reads which can lead to resources churn.
                    // By default buffer is 4KB.
                    var bufferedContentStream = new BufferedStream(contentStream);

                    return new CryptoStream(bufferedContentStream, aes.CreateDecryptor(), mode);
                }
            }

            throw Errors.ClientSideEncryption.BadEncryptionAlgorithm(encryptionData.EncryptionAgent.EncryptionAlgorithm.ToString());
        }
        #endregion

        /// <summary>
        /// Returns the content encryption key for blob. First tries to get the key encryption key from KeyResolver,
        /// then falls back to IKey stored on this EncryptionPolicy. Unwraps the content encryption key with the
        /// correct key wrapper.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <param name="async">Whether to perform asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Encryption key as a byte array.
        /// </returns>
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
        internal async Task<Memory<byte>> GetContentEncryptionKeyAsync(
            EncryptionData encryptionData,
            bool async,
            CancellationToken cancellationToken)
        {
            if (s_contentEncryptionKeyCache.Value?.Key.HasValue ?? false)
            {
                return s_contentEncryptionKeyCache.Value.Key.Value;
            }

            IKeyEncryptionKey key = default;

            // If we already have a local key and it is the correct one, use that.
            if (encryptionData.WrappedContentKey.KeyId == _potentialCachedIKeyEncryptionKey?.KeyId)
            {
                key = _potentialCachedIKeyEncryptionKey;
            }
            // Otherwise, use the resolver.
            else if (_keyResolver != null)
            {
                key = async
                    ? await _keyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId, cancellationToken).ConfigureAwait(false)
                    : _keyResolver.Resolve(encryptionData.WrappedContentKey.KeyId, cancellationToken);
            }

            // We throw for every other reason that decryption couldn't happen. Throw a reasonable
            // exception here instead of nullref.
            if (key == default)
            {
                throw Errors.ClientSideEncryption.KeyNotFound(encryptionData.WrappedContentKey.KeyId);
            }

            byte[] unwrappedContent = async
                ? await key.UnwrapKeyAsync(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey,
                    cancellationToken).ConfigureAwait(false)
                : key.UnwrapKey(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey,
                    cancellationToken);

            Memory<byte> unwrappedKey;
            switch (encryptionData.EncryptionAgent.EncryptionVersion)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V1_0:
                    unwrappedKey = unwrappedContent;
                    break;
#pragma warning restore CS0618 // obsolete
                // v2.0 binds content encryption key with content encryption algorithm under a single keywrap.
                // Separate key from algorithm ID and validate ID match
                case ClientSideEncryptionVersionInternal.V2_0:
                case ClientSideEncryptionVersionInternal.V2_1:
                    string unwrappedProtocolString = Encoding.UTF8.GetString(
                        unwrappedContent,
                        index: 0,
                        count: Constants.ClientSideEncryption.V2.WrappedDataVersionLength)
                        // remove empty padding from fixed-length space for version string
                        .Trim('\0');
                    if (unwrappedProtocolString != encryptionData.EncryptionAgent.EncryptionVersion.Serialize())
                    {
                        throw new CryptographicException("Encryption metadata has been tampered.");
                    }
                    unwrappedKey = new Memory<byte>(unwrappedContent)
                        .Slice(Constants.ClientSideEncryption.V2.WrappedDataVersionLength).ToArray();
                    break;
                default:
                    throw Errors.InvalidArgument(nameof(encryptionData));
            }

            if (s_contentEncryptionKeyCache.Value != default)
            {
                s_contentEncryptionKeyCache.Value.Key = unwrappedKey;
            }

            return unwrappedKey;
        }

        internal static void BeginContentEncryptionKeyCaching(ContentEncryptionKeyCache cache = default)
        {
            s_contentEncryptionKeyCache.Value = cache ?? new ContentEncryptionKeyCache();
        }

        internal class ContentEncryptionKeyCache
        {
            public Memory<byte>? Key { get; set; }
        }
    }
}
