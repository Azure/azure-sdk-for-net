// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Interface
{
    using Azure.Security.KeyVault.Cryptography.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ICryptographyProvider
    {
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
        /// <param name="authenticationTag"></param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The plain text</returns>
        /// <remarks>If algorithm is not specified, an implementation should use its default algorithm.
        /// Not all algorithms require, or support, all parameters.</remarks>
        Task<byte[]> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, string algorithm, CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="algorithm"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<byte[]> DecryptAsync(Stream ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, string algorithm, CancellationToken token);

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
        Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, string algorithm, CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithm"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, string algorithm, CancellationToken token);

        /// <summary>
        /// Encrypts the specified key material.
        /// </summary>
        /// <param name="key">The key material to encrypt</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A Tuple consisting of the encrypted key and the algorithm used</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm</remarks>
        Task<Tuple<byte[], string>> WrapKeyAsync(byte[] key, string algorithm, CancellationToken token);

        /// <summary>
        /// Decrypts the specified key material.
        /// </summary>
        /// <param name="encryptedKey">The encrypted key material</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The decrypted key material</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm</remarks>
        Task<byte[]> UnwrapKeyAsync(byte[] encryptedKey, string algorithm, CancellationToken token);

        /// <summary>
        /// Signs the specified digest.
        /// </summary>
        /// <param name="digest">The digest to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A Tuple consisting of the signature and the algorithm used</returns>
        /// <remarks>If the algorithm is not specified, an implementation should use its default algorithm</remarks>
        Task<Tuple<byte[], string>> SignAsync(byte[] digest, string algorithm, CancellationToken token);

        /// <summary>
        /// Verifies the specified signature value
        /// </summary>
        /// <param name="digest">The digest</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A bool indicating whether the signature was successfully verified</returns>
        Task<bool> VerifyAsync(byte[] digest, byte[] signature, string algorithm, CancellationToken token);
    }
}
