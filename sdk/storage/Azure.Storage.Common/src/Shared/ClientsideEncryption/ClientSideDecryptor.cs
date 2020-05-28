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
    internal static class ClientSideDecryptor
    {
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
        /// Decrypted plaintext.
        /// </returns>
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
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
            var contentEncryptionKey = await GetContentEncryptionKeyAsync(
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
        /// <exception cref="Exception">
        /// Exceptions thrown based on implementations of <see cref="IKeyEncryptionKey"/> and
        /// <see cref="IKeyEncryptionKeyResolver"/>.
        /// </exception>
        private static async Task<Memory<byte>> GetContentEncryptionKeyAsync(
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

            // We throw for every other reason that decryption couldn't happen. Throw a reasonable
            // exception here instead of nullref.
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
    }
}
