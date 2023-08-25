// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Provides an implementation of the RSA algorithm backed by Azure Key Vault or Managed HSM.
    /// </summary>
    public class RSAKeyVault : RSA
    {
        private static readonly KeySizes[] s_legalKeySizes =
        {
            new(minSize: 2048, maxSize: 4096, skipSize: 1024),
        };

        private readonly CryptographyClient _client;
        private readonly RSA _key;

        internal RSAKeyVault(CryptographyClient client, string keyId, JsonWebKey keyMaterial)
        {
            _client = client;
            KeyId = keyId;

            if (keyMaterial != null)
            {
                _key = keyMaterial.ToRSA();
            }
        }

        /// <summary>
        /// Gets the <see cref="KeyVaultKey.Id"/> of the key used to perform cryptographic operations.
        /// </summary>
        public string KeyId { get; }

        /// <inheritdoc/>
        public override string KeyExchangeAlgorithm => _key?.KeyExchangeAlgorithm;

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">The key could not be downloaded so key size is unavailable.</exception>
        /// <exception cref="NotSupportedException">Changing the key size on this read-only provider is not supported.</exception>
        public override int KeySize
        {
            get => _key?.KeySize ?? throw new InvalidOperationException("Cannot download the key");
            set => throw new NotSupportedException("Cannot change the key size");
        }

        /// <inheritdoc/>
        public override KeySizes[] LegalKeySizes => s_legalKeySizes.Clone<KeySizes>();

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">The key could not be downloaded so exporting it is not supported.</exception>
        public override RSAParameters ExportParameters(bool includePrivateParameters) =>
            _key?.ExportParameters(includePrivateParameters) ?? throw new InvalidOperationException("Cannot download the key");

        /// <inheritdoc/>
        /// <exception cref="NotSupportedException">Importing a key into this read-only provider is not supported.</exception>
        public override void ImportParameters(RSAParameters parameters) => throw new NotSupportedException("Cannot import a key");

        /// <summary>
        /// Encrypts the input data using the specified padding mode.
        /// </summary>
        /// <param name="data">The data to encrypt.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns>The encrypted data.</returns>
        /// <exception cref="NotSupportedException">The <paramref name="padding"/> is not supported.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public override byte[] Encrypt(byte[] data, RSAEncryptionPadding padding)
        {
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.FromRsaEncryptionPadding(padding);
            EncryptResult result = _client.Encrypt(algorithm, data);

            return result.Ciphertext;
        }

        /// <summary>
        /// Decrypts the input data using the specified padding mode.
        /// </summary>
        /// <param name="data">The data to decrypt.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns>The decrypted data.</returns>
        /// <exception cref="NotSupportedException">The <paramref name="padding"/> is not supported.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public override byte[] Decrypt(byte[] data, RSAEncryptionPadding padding)
        {
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.FromRsaEncryptionPadding(padding);
            DecryptResult result = _client.Decrypt(algorithm, data);

            return result.Plaintext;
        }

        /// <summary>
        /// Computes the hash value of a specified portion of a byte array by using a specified hashing algorithm.
        /// </summary>
        /// <param name="data">The data to be hashed.</param>
        /// <param name="offset">The index of the first byte in data that is to be hashed.</param>
        /// <param name="count">The number of bytes to hash.</param>
        /// <param name="hashAlgorithm">The algorithm to use in hash the data.</param>
        /// <returns>The hashed data.</returns>
        /// <exception cref="NotSupportedException">The <paramref name="hashAlgorithm"/> is not supported.</exception>
        protected override byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm)
        {
            using HashAlgorithm algorithm = Create(hashAlgorithm);
            return algorithm.ComputeHash(data, offset, count);
        }

        /// <summary>
        /// Computes the hash value of a specified binary stream by using a specified hashing algorithm.
        /// </summary>
        /// <param name="data">The binary stream to hash.</param>
        /// <param name="hashAlgorithm">The algorithm to use in hash the data.</param>
        /// <returns>The hashed data.</returns>
        /// <exception cref="NotSupportedException">The <paramref name="hashAlgorithm"/> is not supported.</exception>
        protected override byte[] HashData(Stream data, HashAlgorithmName hashAlgorithm)
        {
            using HashAlgorithm algorithm = Create(hashAlgorithm);
            return algorithm.ComputeHash(data);
        }

        /// <summary>
        /// Computes the signature for the specified hash value by encrypting it with the private key using the specified padding.
        /// </summary>
        /// <param name="hash">The hash value of the data to be signed.</param>
        /// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the data.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>The RSA signature for the specified hash value.</returns>
        /// <exception cref="NotSupportedException">Hash algorithm <paramref name="hashAlgorithm"/> with <paramref name="padding"/> padding is not supported.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public override byte[] SignHash(byte[] hash, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            SignatureAlgorithm algorithm = Cryptography.SignatureAlgorithm.FromHashAlgorithmName(hashAlgorithm, padding);
            SignResult result = _client.Sign(algorithm, hash);

            return result.Signature;
        }

        /// <summary>
        /// Verifies that a digital signature is valid by determining the hash value in the signature using the specified hash algorithm and padding, and comparing it to the provided hash value.
        /// </summary>
        /// <param name="hash">The hash value of the signed data.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <param name="hashAlgorithm">The hash algorithm used to create the hash value.</param>
        /// <param name="padding">The padding mode.</param>
        /// <returns>true if the signature is valid; otherwise, false.</returns>
        /// <exception cref="NotSupportedException">Hash algorithm <paramref name="hashAlgorithm"/> with <paramref name="padding"/> padding is not supported.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public override bool VerifyHash(byte[] hash, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            SignatureAlgorithm algorithm = Cryptography.SignatureAlgorithm.FromHashAlgorithmName(hashAlgorithm, padding);
            VerifyResult result = _client.Verify(algorithm, hash, signature);

            return result.IsValid;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _key?.Dispose();
            }

            base.Dispose(disposing);
        }

        private static HashAlgorithm Create(HashAlgorithmName algorithm)
        {
            if (algorithm == HashAlgorithmName.SHA256)
            {
                return SHA256.Create();
            }

            if (algorithm == HashAlgorithmName.SHA384)
            {
                return SHA384.Create();
            }

            if (algorithm == HashAlgorithmName.SHA512)
            {
                return SHA512.Create();
            }

            throw new NotSupportedException($"{algorithm} is not supported");
        }
    }
}
