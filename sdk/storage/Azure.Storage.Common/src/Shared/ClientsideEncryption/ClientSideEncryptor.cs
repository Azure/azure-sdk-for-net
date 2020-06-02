// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography
{
    internal class ClientSideEncryptor
    {
        private readonly IKeyEncryptionKey _keyEncryptionKey;
        private readonly string _keyWrapAlgorithm;

        public ClientSideEncryptor(ClientSideEncryptionOptions options)
        {
            _keyEncryptionKey = options.KeyEncryptionKey;
            _keyWrapAlgorithm = options.KeyWrapAlgorithm;
        }

        /// <summary>
        /// Wraps the given read-stream in a CryptoStream and provides the metadata used to create
        /// that stream.
        /// </summary>
        /// <param name="plaintext">Stream to wrap.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The wrapped stream to read from and the encryption metadata for the wrapped stream.</returns>
        public async Task<(Stream ciphertext, EncryptionData encryptionData)> EncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            if (_keyEncryptionKey == default || _keyWrapAlgorithm == default)
            {
                throw Errors.ClientSideEncryption.MissingRequiredEncryptionResources(nameof(_keyEncryptionKey), nameof(_keyWrapAlgorithm));
            }

            var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            Stream ciphertext = default;

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {
                encryptionData = await EncryptionData.CreateInternalV1_0(
                    contentEncryptionIv: aesProvider.IV,
                    keyWrapAlgorithm: _keyWrapAlgorithm,
                    contentEncryptionKey: generatedKey,
                    keyEncryptionKey: _keyEncryptionKey,
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
        /// Encrypts the given stream and provides the metadata used to encrypt. This method writes to a memory stream,
        /// optimized for known-size data that will already be buffered in memory.
        /// </summary>
        /// <param name="plaintext">Stream to encrypt.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The encrypted data and the encryption metadata for the wrapped stream.</returns>
        public async Task<(byte[] ciphertext, EncryptionData encryptionData)> BufferedEncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            if (_keyEncryptionKey == default || _keyWrapAlgorithm == default)
            {
                throw Errors.ClientSideEncryption.MissingRequiredEncryptionResources(nameof(_keyEncryptionKey), nameof(_keyWrapAlgorithm));
            }

            var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            var ciphertext = new MemoryStream();
            byte[] bufferedCiphertext = default;

            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Key = generatedKey })
            {
                encryptionData = await EncryptionData.CreateInternalV1_0(
                    contentEncryptionIv: aesProvider.IV,
                    keyWrapAlgorithm: _keyWrapAlgorithm,
                    contentEncryptionKey: generatedKey,
                    keyEncryptionKey: _keyEncryptionKey,
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

        /// <summary>
        /// Securely generate a key.
        /// </summary>
        /// <param name="numBits">Key size.</param>
        /// <returns>The generated key bytes.</returns>
        private static byte[] CreateKey(int numBits)
        {
            using (var secureRng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBits / 8];
                secureRng.GetBytes(buff);
                return buff;
            }
        }
    }
}
