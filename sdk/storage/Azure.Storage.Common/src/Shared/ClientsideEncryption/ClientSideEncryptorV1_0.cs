// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography
{
    internal class ClientSideEncryptorV1_0 : IClientSideEncryptor
    {
        private readonly IKeyEncryptionKey _keyEncryptionKey;
        private readonly string _keyWrapAlgorithm;

        public ClientSideEncryptorV1_0(ClientSideEncryptionOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
#pragma warning disable CS0618 // obsolete
            if (options.EncryptionVersion != ClientSideEncryptionVersion.V1_0)
            {
                Errors.InvalidArgument(nameof(options.EncryptionVersion));
            }
#pragma warning restore CS0618 // obsolete

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

        public long ExpectedOutputContentLength(long plaintextLength) => CalculateExpectedOutputContentLength(plaintextLength);

        public static long CalculateExpectedOutputContentLength(long plaintextLength)
        {
            const int aesBlockSizeBytes = 16;

            // pkcs7 padding output length algorithm
            return plaintextLength + (aesBlockSizeBytes - (plaintextLength % aesBlockSizeBytes));
        }

        /// <summary>
        /// Wraps the given read-stream in a CryptoStream and provides the metadata used to create
        /// that stream.
        /// </summary>
        /// <param name="plaintext">Stream to wrap.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The wrapped stream to read from and the encryption metadata for the wrapped stream.</returns>
        public async Task<(Stream Ciphertext, EncryptionData EncryptionData)> EncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateMembers();

            var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            Stream ciphertext = default;

#if NET6_0_OR_GREATER
            using (Aes aes = Aes.Create())
#else
            using (Aes aes = new AesCryptoServiceProvider())
#endif
            {
                aes.Key = generatedKey;
                encryptionData = await CreateEncryptionDataInternal(aes, async, cancellationToken).ConfigureAwait(false);

                ciphertext = new CryptoStream(
                    plaintext,
                    aes.CreateEncryptor(),
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
        public async Task<(byte[] Ciphertext, EncryptionData EncryptionData)> BufferedEncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateMembers();

            var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            var ciphertext = new MemoryStream();
            byte[] bufferedCiphertext = default;

#if NET6_0_OR_GREATER
            using (Aes aes = Aes.Create())
#else
            using (Aes aes = new AesCryptoServiceProvider())
#endif
            {
                aes.Key = generatedKey;
                encryptionData = await CreateEncryptionDataInternal(aes, async, cancellationToken).ConfigureAwait(false);

                var transformStream = new CryptoStream(
                    ciphertext,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write);

                if (async)
                {
                    // constant comes from parameter documentation
                    const int copyToAsyncDefaultBufferSize = 80 * Constants.KB;
                    await plaintext.CopyToAsync(transformStream, copyToAsyncDefaultBufferSize, cancellationToken).ConfigureAwait(false);
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
        public async Task<Stream> EncryptedOpenWriteInternal(
            Func<EncryptionData, bool, CancellationToken, Task<Stream>> openWriteInternal,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateMembers();

            var generatedKey = CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            EncryptionData encryptionData = default;
            Stream writeStream = default;
#if NET6_0_OR_GREATER
            using (Aes aes = Aes.Create())
#else
            using (Aes aes = new AesCryptoServiceProvider())
#endif
            {
                aes.Key = generatedKey;
                encryptionData = await CreateEncryptionDataInternal(aes, async, cancellationToken).ConfigureAwait(false);

                writeStream = new CryptoStream(
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    // analyzer struggles to recognize async pattern with a Func instead of a proper method.
                    await openWriteInternal(encryptionData, async, cancellationToken).ConfigureAwait(false),
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write);
            }

            return writeStream;
        }

        /// <summary>
        /// Creates <see cref="EncryptionData"/> from this instance data and a given AES provider.
        /// </summary>
        private async Task<EncryptionData> CreateEncryptionDataInternal(Aes aes, bool async, CancellationToken cancellationToken)
            => await EncryptionData.CreateInternalV1_0(
                contentEncryptionIv: aes.IV,
                keyWrapAlgorithm: _keyWrapAlgorithm,
                contentEncryptionKey: aes.Key,
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
#if NET6_0_OR_GREATER
            return RandomNumberGenerator.GetBytes(numBits / 8);
#else
            using (var secureRng = new RNGCryptoServiceProvider())
            {
                var buff = new byte[numBits / 8];
                secureRng.GetBytes(buff);
                return buff;
            }
#endif
        }
    }
}
