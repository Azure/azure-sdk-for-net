// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography.Models;

using static Azure.Storage.Constants.ClientSideEncryption.V2;

namespace Azure.Storage.Cryptography
{
    internal class ClientSideEncryptorV2_0 : IClientSideEncryptor
    {
        private readonly IKeyEncryptionKey _keyEncryptionKey;
        private readonly string _keyWrapAlgorithm;

        public ClientSideEncryptorV2_0(ClientSideEncryptionOptions options)
        {
            _keyEncryptionKey = options.KeyEncryptionKey;
            _keyWrapAlgorithm = options.KeyWrapAlgorithm;
        }

        private void ValidateMembers()
        {
            if (_keyEncryptionKey == default || _keyWrapAlgorithm == default)
            {
                throw Errors.ClientSideEncryption.MissingRequiredEncryptionResources(nameof(_keyEncryptionKey), nameof(_keyWrapAlgorithm));
            }
        }

        public long ExpectedOutputContentLength(long plaintextLength)
        {
            long numBlocks = plaintextLength / EncryptionBlockSize;
            // partial block check
            if (plaintextLength % EncryptionBlockSize != 0)
            {
                numBlocks += 1;
            }

            return plaintextLength + (numBlocks * (NonceSize + TagSize));
        }

        /// <summary>
        /// Wraps the given read-stream in a CryptoStream and provides the metadata used to create
        /// that stream.
        /// </summary>
        /// <param name="plaintext">Stream to wrap.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The wrapped stream to read from and the encryption metadata for the wrapped stream.</returns>
        public Task<(Stream Ciphertext, EncryptionData EncryptionData)> EncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateMembers();

            //var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            //EncryptionData encryptionData = default;
            //Stream ciphertext = default;

            throw new NotImplementedException();

            //return (ciphertext, encryptionData);
        }

        /// <summary>
        /// Encrypts the given stream and provides the metadata used to encrypt. This method writes to a memory stream,
        /// optimized for known-size data that will already be buffered in memory.
        /// </summary>
        /// <param name="plaintext">Stream to encrypt.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The encrypted data and the encryption metadata for the wrapped stream.</returns>
        public Task<(byte[] Ciphertext, EncryptionData EncryptionData)> BufferedEncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateMembers();

            //var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            //EncryptionData encryptionData = default;
            //var ciphertext = new MemoryStream();
            //byte[] bufferedCiphertext = default;

            throw new NotImplementedException();

            //return (bufferedCiphertext, encryptionData);
        }

        /// <summary>
        /// Creates a crypto transform stream to write blob contents to.
        /// </summary>
        /// <param name="openWriteInternal">
        /// OpenWrite function that applies <see cref="EncryptionAgent"/> to the operation.
        /// </param>
        /// <param name="async">
        /// Whether to perform the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for the operation.
        /// </param>
        /// <returns>
        /// Content transform write stream and encryption metadata.
        /// </returns>
        public Task<Stream> EncryptedOpenWriteInternal(
            Func<EncryptionData, bool, CancellationToken, Task<Stream>> openWriteInternal,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateMembers();

            //var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            //EncryptionData encryptionData = default;
            //Stream writeStream = default;

            throw new NotImplementedException();

            //return writeStream;
        }

        /// <summary>
        /// Creates <see cref="EncryptionData"/> from this instance data and a given AES provider.
        /// </summary>
        private async Task<EncryptionData> CreateEncryptionDataInternal(
            AesCryptoServiceProvider aesProvider,
            bool async,
            CancellationToken cancellationToken)
            => await EncryptionData.CreateInternalV2_0(
                keyWrapAlgorithm: _keyWrapAlgorithm,
                contentEncryptionKey: aesProvider.Key,
                keyEncryptionKey: _keyEncryptionKey,
                async: async,
                cancellationToken: cancellationToken).ConfigureAwait(false);

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
