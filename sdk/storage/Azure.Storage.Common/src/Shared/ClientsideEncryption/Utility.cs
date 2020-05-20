// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography
{
    internal static class Utility
    {
        public static ClientSideEncryptionOptions Clone(this ClientSideEncryptionOptions other)
            => new ClientSideEncryptionOptions(other.Version)
            {
                KeyEncryptionKey = other.KeyEncryptionKey,
                KeyResolver = other.KeyResolver,
                KeyWrapAlgorithm = other.KeyWrapAlgorithm,
            };

        /// <summary>
        /// Securely generate a key.
        /// </summary>
        /// <param name="numBits">Key size.</param>
        /// <returns>The generated key bytes.</returns>
        public static byte[] CreateKey(int numBits)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBits / 8];
                rng.GetBytes(buff);
                return buff;
            }
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
        /// <param name="keyResolver">
        /// Resolver to fetch the key encryption key.
        /// </param>
        /// <param name="potentialCachedKeyWrapper">
        /// Clients that can upload data have a key encryption key stored on them. Checking if
        /// a cached key exists and matches the <paramref name="encryptionData"/> saves a call
        /// to the external key resolver implementation when available.
        /// </param>
        /// <param name="noPadding">
        /// Whether to ignore padding. Generally for partial blob downloads where the end of
        /// the blob (where the padding occurs) was not downloaded.
        /// </param>
        /// <param name="async">Whether to perform this function asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Decrypted plaintext. If key could not be resolved, returns null.
        /// </returns>
        /// <exception cref="ClientSideEncryptionKeyNotFoundException">When key ID cannot be resolved.</exception>
        public static async Task<Stream> DecryptInternal(
            Stream ciphertext,
            EncryptionData encryptionData,
            bool ivInStream,
            IKeyEncryptionKeyResolver keyResolver,
            IKeyEncryptionKey potentialCachedKeyWrapper,
            bool noPadding,
            bool async,
            CancellationToken cancellationToken)
        {
            var contentEncryptionKey = await GetContentEncryptionKeyOrDefaultAsync(
                encryptionData,
                keyResolver,
                potentialCachedKeyWrapper,
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
                    IV = new byte[EncryptionConstants.EncryptionBlockSize];
                    if (async)
                    {
                        await ciphertext.ReadAsync(IV, 0, IV.Length, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        ciphertext.Read(IV, 0, IV.Length);
                    }
                    //read = IV.Length;
                }

                plaintext = WrapStream(
                    ciphertext,
                    contentEncryptionKey.ToArray(),
                    encryptionData,
                    IV,
                    noPadding);
            }
            else
            {
                plaintext = ciphertext;
            }

            return plaintext;
        }

#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// Returns the content encryption key for blob. First tries to get the key encryption key from KeyResolver,
        /// then falls back to IKey stored on this EncryptionPolicy. Unwraps the content encryption key with the
        /// correct key wrapper.
        /// </summary>
        /// <param name="encryptionData">The encryption data.</param>
        /// <param name="keyResolver"></param>
        /// <param name="potentiallyCachedKeyWrapper"></param>
        /// <param name="async">Whether to perform asynchronously.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Encryption key as a byte array.
        /// </returns>
        /// <exception cref="ClientSideEncryptionKeyNotFoundException">When key ID cannot be resolved.</exception>
        private static async Task<Memory<byte>> GetContentEncryptionKeyOrDefaultAsync(
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
            EncryptionData encryptionData,
            IKeyEncryptionKeyResolver keyResolver,
            IKeyEncryptionKey potentiallyCachedKeyWrapper,
            bool async,
            CancellationToken cancellationToken)
        {
            IKeyEncryptionKey key = default;

            // If we already have a local key and it is the correct one, use that.
            if (encryptionData.WrappedContentKey.KeyId == potentiallyCachedKeyWrapper?.KeyId)
            {
                key = potentiallyCachedKeyWrapper;
            }
            // Otherwise, use the resolver.
            else if (keyResolver != null)
            {
                key = async
                    ? await keyResolver.ResolveAsync(encryptionData.WrappedContentKey.KeyId, cancellationToken).ConfigureAwait(false)
                    : keyResolver.Resolve(encryptionData.WrappedContentKey.KeyId, cancellationToken);
            }

            if (key == default)
            {
                throw EncryptionErrors.KeyNotFound(encryptionData.WrappedContentKey.KeyId);
            }

            return async
                ? await key.UnwrapKeyAsync(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey).ConfigureAwait(false)
                : key.UnwrapKey(
                    encryptionData.WrappedContentKey.Algorithm,
                    encryptionData.WrappedContentKey.EncryptedKey);
        }

#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// Wraps a stream of ciphertext to stream plaintext.
        /// </summary>
        /// <param name="contentStream"></param>
        /// <param name="contentEncryptionKey"></param>
        /// <param name="encryptionData"></param>
        /// <param name="iv"></param>
        /// <param name="noPadding"></param>
        /// <returns></returns>
        private static Stream WrapStream(Stream contentStream, byte[] contentEncryptionKey,
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
            EncryptionData encryptionData, byte[] iv, bool noPadding)
        {
            if (encryptionData.EncryptionAgent.EncryptionAlgorithm == ClientSideEncryptionAlgorithm.AesCbc256)
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.IV = iv ?? encryptionData.ContentEncryptionIV;
                    aesProvider.Key = contentEncryptionKey;

                    if (noPadding)
                    {
                        aesProvider.Padding = PaddingMode.None;
                    }

                    return new CryptoStream(contentStream, aesProvider.CreateDecryptor(), CryptoStreamMode.Read);
                }
            }

            throw EncryptionErrors.BadEncryptionAlgorithm(encryptionData.EncryptionAgent.EncryptionAlgorithm.ToString());
        }

        /// <summary>
        /// Wraps the given read-stream in a CryptoStream and provides the metadata used to create
        /// that stream.
        /// </summary>
        /// <param name="plaintext">Stream to wrap.</param>
        /// <param name="keyWrapper">Key encryption key (KEK).</param>
        /// <param name="keyWrapAlgorithm">Algorithm to encrypt the content encryption key (CEK) with.</param>
        /// <param name="async">Whether to wrap the CEK asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The wrapped stream to read from and the encryption metadata for the wrapped stream.</returns>
        public static async Task<(Stream ciphertext, EncryptionData encryptionData)> EncryptInternal(
            Stream plaintext,
            IKeyEncryptionKey keyWrapper,
            string keyWrapAlgorithm,
            bool async,
            CancellationToken cancellationToken)
        {
            var generatedKey = CreateKey(EncryptionConstants.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            Stream ciphertext = default;

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {
                encryptionData = await EncryptionData.CreateInternalV1_0(
                    contentEncryptionIv: aesProvider.IV,
                    keyWrapAlgorithm: keyWrapAlgorithm,
                    contentEncryptionKey: generatedKey,
                    keyEncryptionKey: keyWrapper,
                    async: async,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                ciphertext = new CryptoStream(
                    plaintext,
                    aesProvider.CreateEncryptor(),
                    CryptoStreamMode.Read);
            }

            return (ciphertext, encryptionData);
        }

        /// <summary>
        /// Encrypts the given stream and provides the metadata used to encrypt.
        /// </summary>
        /// <param name="plaintext">Stream to encrypt.</param>
        /// <param name="keyWrapper">Key encryption key (KEK).</param>
        /// <param name="keyWrapAlgorithm">Algorithm to encrypt the content encryption key (CEK) with.</param>
        /// <param name="async">Whether to wrap the CEK asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The encrypted data and the encryption metadata for the wrapped stream.</returns>
        public static async Task<(byte[] ciphertext, EncryptionData encryptionData)> BufferedEncryptInternal(
            Stream plaintext,
            IKeyEncryptionKey keyWrapper,
            string keyWrapAlgorithm,
            bool async,
            CancellationToken cancellationToken)
        {
            var generatedKey = CreateKey(EncryptionConstants.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            var ciphertext = new MemoryStream();
            byte[] bufferedCiphertext = default;

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {
                encryptionData = await EncryptionData.CreateInternalV1_0(
                    contentEncryptionIv: aesProvider.IV,
                    keyWrapAlgorithm: keyWrapAlgorithm,
                    contentEncryptionKey: generatedKey,
                    keyEncryptionKey: keyWrapper,
                    async: async,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var transformStream = new CryptoStream(
                    ciphertext,
                    aesProvider.CreateEncryptor(),
                    CryptoStreamMode.Write);

                if (async)
                {
                    await plaintext.CopyToAsync(transformStream).ConfigureAwait(false);
                }
                else
                {
                    plaintext.CopyTo(transformStream);
                }

                transformStream.FlushFinalBlock();

                bufferedCiphertext = ciphertext.ToArray();
            }

            return (bufferedCiphertext, encryptionData);
        }
    }
}
