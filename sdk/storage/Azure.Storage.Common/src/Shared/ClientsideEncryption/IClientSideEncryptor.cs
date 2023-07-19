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
    internal interface IClientSideEncryptor
    {
        /// <summary>
        /// Calculates the expected length of the output content.
        /// </summary>
        /// <param name="plaintextLength">
        /// Length of the plaintext to be encrypted
        /// </param>
        /// <returns>
        /// Length of output ciphertext plus any additional data in the content stream
        /// such as nonces or authentication tags.
        /// </returns>
        long ExpectedOutputContentLength(long plaintextLength);

        /// <summary>
        /// Wraps the given read-stream in a cryptographic transformation stream and provides
        /// the metadata used to create that stream.
        /// </summary>
        /// <param name="plaintext">Stream to wrap.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The wrapped stream to read from and the encryption metadata for the wrapped stream.</returns>
        Task<(Stream Ciphertext, EncryptionData EncryptionData)> EncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken);

        /// <summary>
        /// Encrypts the given stream and provides the metadata used to encrypt.
        /// </summary>
        /// <param name="plaintext">Stream to encrypt.</param>
        /// <param name="async">Whether to wrap the content encryption key asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The encrypted data and the encryption metadata for the wrapped stream.</returns>
        Task<(byte[] Ciphertext, EncryptionData EncryptionData)> BufferedEncryptInternal(
            Stream plaintext,
            bool async,
            CancellationToken cancellationToken);

        /// <summary>
        /// Creates a cryptographic transformation stream to write plaintext contents to.
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
        Task<Stream> EncryptedOpenWriteInternal(
            Func<EncryptionData, bool, CancellationToken, Task<Stream>> openWriteInternal,
            bool async,
            CancellationToken cancellationToken);
    }
}
