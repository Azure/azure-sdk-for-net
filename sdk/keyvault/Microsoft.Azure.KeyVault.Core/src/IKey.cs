// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Core
{
    /// <summary>
    /// Interface for Keys
    /// </summary>
    public interface IKey : IDisposable
    {
        /// <summary>
        /// The default encryption algorithm for this key
        /// </summary>
        string DefaultEncryptionAlgorithm { get; }

        /// <summary>
        /// The default key wrap algorithm for this key
        /// </summary>
        string DefaultKeyWrapAlgorithm { get; }

        /// <summary>
        /// The default signature algorithm for this key
        /// </summary>
        string DefaultSignatureAlgorithm { get; }

        /// <summary>
        /// The key identifier
        /// </summary>
        string Kid { get; }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="ciphertext">The cipher text to decrypt</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">The authentication data</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The plain text</returns>
        /// <remarks>If algorithm is not specified, an implementation should use its default algorithm.
        /// Not all algorithms require, or support, all parameters.</remarks>
        Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, string algorithm, CancellationToken token );

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text to encrypt</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">The authentication data</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A Tuple consisting of the cipher text, the authentication tag (if applicable), the algorithm used</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm.
        /// Not all algorithyms require, or support, all parameters.</remarks>
        Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv, byte[] authenticationData, string algorithm, CancellationToken token );

        /// <summary>
        /// Encrypts the specified key material.
        /// </summary>
        /// <param name="key">The key material to encrypt</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A Tuple consisting of the encrypted key and the algorithm used</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm</remarks>
        Task<Tuple<byte[], string>> WrapKeyAsync( byte[] key, string algorithm, CancellationToken token );

        /// <summary>
        /// Decrypts the specified key material.
        /// </summary>
        /// <param name="encryptedKey">The encrypted key material</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The decrypted key material</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm</remarks>
        Task<byte[]> UnwrapKeyAsync( byte[] encryptedKey, string algorithm, CancellationToken token );

        /// <summary>
        /// Signs the specified digest.
        /// </summary>
        /// <param name="digest">The digest to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A Tuple consisting of the signature and the algorithm used</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm</remarks>
        Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm, CancellationToken token );

        /// <summary>
        /// Verifies the specified signature value
        /// </summary>
        /// <param name="digest">The digest</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A bool indicating whether the signature was successfully verified</returns>
        Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm, CancellationToken token );
    }
}