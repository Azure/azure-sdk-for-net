﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Model factory that enables mocking for the Key Vault Cryptography library.
    /// </summary>
    public static class CryptographyModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.DecryptResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="DecryptResult.KeyId"/> property.</param>
        /// <param name="plaintext">Sets the <see cref="DecryptResult.Plaintext"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="DecryptResult.Algorithm"/> property.</param>
        /// <returns>A new instance of the <see cref="Cryptography.DecryptResult"/> for mocking purposes.</returns>
        public static DecryptResult DecryptResult(string keyId = default, byte[] plaintext = default, EncryptionAlgorithm algorithm = default) => new DecryptResult
        {
            KeyId = keyId,
            Plaintext = plaintext,
            Algorithm = algorithm,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.EncryptResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="EncryptResult.KeyId"/> property.</param>
        /// <param name="ciphertext">Sets the <see cref="EncryptResult.Ciphertext"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="EncryptResult.Algorithm"/> property.</param>
        /// <returns>A new instance of the <see cref="Cryptography.EncryptResult"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EncryptResult EncryptResult(string keyId, byte[] ciphertext, EncryptionAlgorithm algorithm) => EncryptResult(keyId, ciphertext, algorithm, null);

        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.EncryptResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="EncryptResult.KeyId"/> property.</param>
        /// <param name="ciphertext">Sets the <see cref="EncryptResult.Ciphertext"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="EncryptResult.Algorithm"/> property.</param>
        /// <param name="iv">Sets the initialization vector for encryption.</param>
        /// <param name="authenticatedTag">Sets the authenticated tag resulting from encryption with a symmetric key using AES.</param>
        /// <param name="additionalAuthenticatedData">Sets additional data that is authenticated during decryption but not encrypted.</param>
        /// <returns>A new instance of the <see cref="Cryptography.EncryptResult"/> for mocking purposes.</returns>
        public static EncryptResult EncryptResult(string keyId = default, byte[] ciphertext = default, EncryptionAlgorithm algorithm = default, byte[] iv = default, byte[] authenticatedTag = default, byte[] additionalAuthenticatedData = default) => new EncryptResult
        {
            KeyId = keyId,
            Ciphertext = ciphertext,
            Algorithm = algorithm,
            Iv = iv,
            AuthenticationTag = authenticatedTag,
            AdditionalAuthenticatedData = additionalAuthenticatedData,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.SignResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="SignResult.KeyId"/> property.</param>
        /// <param name="signature">Sets the <see cref="SignResult.Signature"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="SignResult.Algorithm"/> property.</param>
        /// <returns>A new instance of the <see cref="Cryptography.SignResult"/> for mocking purposes.</returns>
        public static SignResult SignResult(string keyId = default, byte[] signature = default, SignatureAlgorithm algorithm = default) => new SignResult
        {
            KeyId = keyId,
            Signature = signature,
            Algorithm = algorithm,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.UnwrapResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="UnwrapResult.KeyId"/> property.</param>
        /// <param name="key">Sets the <see cref="UnwrapResult.Key"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="UnwrapResult.Algorithm"/> property.</param>
        /// <returns>A new instance of the <see cref="Cryptography.UnwrapResult"/> for mocking purposes.</returns>
        public static UnwrapResult UnwrapResult(string keyId = default, byte[] key = default, KeyWrapAlgorithm algorithm = default) => new UnwrapResult
        {
            KeyId = keyId,
            Key = key,
            Algorithm = algorithm,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.VerifyResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="VerifyResult.KeyId"/> property.</param>
        /// <param name="isValid">Sets the <see cref="VerifyResult.IsValid"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="VerifyResult.Algorithm"/> property.</param>
        /// <returns>A new instance of the <see cref="Cryptography.VerifyResult"/> for mocking purposes.</returns>
        public static VerifyResult VerifyResult(string keyId = default, bool isValid = default, SignatureAlgorithm algorithm = default) => new VerifyResult
        {
            KeyId = keyId,
            IsValid = isValid,
            Algorithm = algorithm,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Cryptography.WrapResult"/> for mocking purposes.
        /// </summary>
        /// <param name="keyId">Sets the <see cref="WrapResult.KeyId"/> property.</param>
        /// <param name="key">Sets the <see cref="WrapResult.EncryptedKey"/> property.</param>
        /// <param name="algorithm">Sets the <see cref="WrapResult.Algorithm"/> property.</param>
        /// <returns>A new instance of the <see cref="Cryptography.WrapResult"/> for mocking purposes.</returns>
        public static WrapResult WrapResult(string keyId = default, byte[] key = default, KeyWrapAlgorithm algorithm = default) => new WrapResult
        {
            KeyId = keyId,
            EncryptedKey = key,
            Algorithm = algorithm,
        };
    }
}
