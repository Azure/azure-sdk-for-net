// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Cryptography
{
    /// <summary>
    /// A key which is used to encrypt, or wrap, another key.
    /// </summary>
    public interface IKeyEncryptionKey
    {
        /// <summary>
        /// The Id of the key used to perform cryptographic operations for the client.
        /// </summary>
        string KeyId { get; }

        /// <summary>
        /// Encrypts the specified key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The key wrap algorithm used to encrypt the specified key.</param>
        /// <param name="key">The key to be encrypted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The encrypted key bytes.</returns>
        byte[] WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Encrypts the specified key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The key wrap algorithm used to encrypt the specified key.</param>
        /// <param name="key">The key to be encrypted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The encrypted key bytes.</returns>
        Task<byte[]> WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Decrypts the specified encrypted key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The key wrap algorithm which was used to encrypt the specified encrypted key.</param>
        /// <param name="encryptedKey">The encrypted key to be decrypted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The decrypted key bytes.</returns>
        byte[] UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// Decrypts the specified encrypted key using the specified algorithm.
        /// </summary>
        /// <param name="algorithm">The key wrap algorithm which was used to encrypt the specified encrypted key.</param>
        /// <param name="encryptedKey">The encrypted key to be decrypted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The decrypted key bytes.</returns>
        Task<byte[]> UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default);
    }
}
