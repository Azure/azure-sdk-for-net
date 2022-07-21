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

using static Azure.Storage.Constants.ClientSideEncryption.V2;

namespace Azure.Storage.Cryptography
{
    internal class ClientSideEncryptorV2_0 : IClientSideEncryptor
    {
        private readonly IKeyEncryptionKey _keyEncryptionKey;
        private readonly string _keyWrapAlgorithm;
        private readonly int _encryptionRegionDataSize;

        public ClientSideEncryptorV2_0(
            ClientSideEncryptionOptions options,
            int encryptionRegionDataSize = EncryptionRegionDataSize)
        {
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(options.KeyEncryptionKey, nameof(options.KeyEncryptionKey));
            Argument.AssertNotNull(options.KeyWrapAlgorithm, nameof(options.KeyWrapAlgorithm));
            if (options.EncryptionVersion != ClientSideEncryptionVersion.V2_0)
            {
                Errors.InvalidArgument(nameof(options.EncryptionVersion));
            }

            _keyEncryptionKey = options.KeyEncryptionKey;
            _keyWrapAlgorithm = options.KeyWrapAlgorithm;
            _encryptionRegionDataSize = encryptionRegionDataSize;
        }

        public long ExpectedOutputContentLength(long plaintextLength)
            => CalculateExpectedOutputContentLength(plaintextLength, _encryptionRegionDataSize);

        public static long CalculateExpectedOutputContentLength(long plaintextLength, int encryptionRegionDataSize)
        {
            long numBlocks = plaintextLength / encryptionRegionDataSize;
            // partial block check
            if (plaintextLength % encryptionRegionDataSize != 0)
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
        public async Task<(Stream Ciphertext, EncryptionData EncryptionData)> EncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken)
        {
            var generatedKey = ClientSideEncryptionValueGenerator.CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);

            // transform is disposable but gets disposed by the stream
            var gcm = new GcmAuthenticatedCryptographicTransform(generatedKey, TransformMode.Encrypt);
            EncryptionData encryptionData = await CreateEncryptionDataInternal(generatedKey, async, cancellationToken)
                .ConfigureAwait(false);

            Stream ciphertext = new AuthenticatedRegionCryptoStream(
                plaintext,
                gcm,
                _encryptionRegionDataSize,
                CryptoStreamMode.Read);

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
            var generatedKey = ClientSideEncryptionValueGenerator.CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            using var gcm = new GcmAuthenticatedCryptographicTransform(generatedKey, TransformMode.Encrypt);
            EncryptionData encryptionData = await CreateEncryptionDataInternal(generatedKey, async, cancellationToken)
                .ConfigureAwait(false);

            var ciphertext = new MemoryStream();
            var transformStream = new AuthenticatedRegionCryptoStream(
                    ciphertext,
                    gcm,
                    _encryptionRegionDataSize,
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

            await transformStream.FlushFinalInternal(async, cancellationToken).ConfigureAwait(false);

            return (ciphertext.ToArray(), encryptionData);
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
            var generatedKey = ClientSideEncryptionValueGenerator.CreateKey(Constants.ClientSideEncryption.EncryptionKeySizeBits);
            EncryptionData encryptionData = await CreateEncryptionDataInternal(generatedKey, async, cancellationToken)
                .ConfigureAwait(false);

            // transform is disposable but gets disposed by the stream
            var gcm = new GcmAuthenticatedCryptographicTransform(generatedKey, TransformMode.Encrypt);

            // TODO this stream has 4MB buffer, openwrite stream has 4MB buffer, can we combine these?
            Stream writeStream = new AuthenticatedRegionCryptoStream(
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                // analyzer struggles to recognize async pattern with a Func instead of a proper method.
                await openWriteInternal(encryptionData, async, cancellationToken).ConfigureAwait(false),
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                gcm,
                _encryptionRegionDataSize,
                CryptoStreamMode.Write);

            return writeStream;
        }

        /// <summary>
        /// Creates <see cref="EncryptionData"/> from this instance data and a given AES provider.
        /// </summary>
        private async Task<EncryptionData> CreateEncryptionDataInternal(
            byte[] key,
            bool async,
            CancellationToken cancellationToken)
            => await EncryptionData.CreateInternalV2_0(
                keyWrapAlgorithm: _keyWrapAlgorithm,
                contentEncryptionKey: key,
                keyEncryptionKey: _keyEncryptionKey,
                _encryptionRegionDataSize,
                async: async,
                cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
