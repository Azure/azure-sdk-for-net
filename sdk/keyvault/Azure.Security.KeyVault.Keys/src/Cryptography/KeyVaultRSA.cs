// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// RSA implementation that uses Azure Key Vault
    /// </summary>
    public sealed class KeyVaultRSA : RSA
    {
        private RSA _publicKey;
        /// <summary>
        /// <see cref="KeyVaultContext"/> that this instance is tied to.
        /// </summary>
        public KeyVaultContext Context { get; }

        /// <summary>
        /// Creates a new RSAKeyVault instance
        /// </summary>
        /// <param name="context">Context with parameters</param>
        public KeyVaultRSA(KeyVaultContext context)
        {
            if (!context.IsValid)
                throw new ArgumentException("Must not be the default", nameof(context));

            Context = context;
            _publicKey = context.PublicKey.ToRSA();
            KeySizeValue = _publicKey.KeySize;
            LegalKeySizesValue = new[] { new KeySizes(_publicKey.KeySize, _publicKey.KeySize, 0) };
        }

        /// <inheritdoc/>
        public override byte[] SignHash(byte[] hash, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            CheckDisposed();

            try
            {
                if (padding.Mode == RSASignaturePaddingMode.Pkcs1)
                {
                    return Context.SignDigest(hash, hashAlgorithm, KeyVaultSignatureAlgorithm.RSAPkcs15);
                }
                else if (padding.Mode == RSASignaturePaddingMode.Pss)
                {
                    return Context.SignDigest(hash, hashAlgorithm, KeyVaultSignatureAlgorithm.Pss);
                }

                throw new ArgumentOutOfRangeException(nameof(padding), "Only RSAPkcs15 and Pss are supported.");
            }
            catch (Exception e)
            {
                throw new CryptographicException("Error calling Key Vault", e);
            }
        }

        /// <inheritdoc/>
        public override bool VerifyHash(byte[] hash, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
        {
            CheckDisposed();

            // Verify can be done locally using the public key
            return _publicKey.VerifyHash(hash, signature, hashAlgorithm, padding);
        }

        /// <inheritdoc/>
        protected override byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm)
        {
            CheckDisposed();

            using (var digestAlgorithm = Create(hashAlgorithm))
            {
                return digestAlgorithm.ComputeHash(data, offset, count);
            }
        }

        /// <inheritdoc/>
        protected override byte[] HashData(Stream data, HashAlgorithmName hashAlgorithm)
        {
            CheckDisposed();

            using (var digestAlgorithm = Create(hashAlgorithm))
            {
                return digestAlgorithm.ComputeHash(data);
            }
        }

        /// <inheritdoc/>
        public override byte[] Decrypt(byte[] data, RSAEncryptionPadding padding)
        {
            CheckDisposed();

            try
            {
                return Context.DecryptData(data, padding);
            }
            catch (Exception e)
            {
                throw new CryptographicException("Error calling Key Vault", e);
            }
        }

        /// <inheritdoc/>
        public override byte[] Encrypt(byte[] data, RSAEncryptionPadding padding)
        {
            CheckDisposed();

            return _publicKey.Encrypt(data, padding);
        }

        /// <inheritdoc/>
        public override RSAParameters ExportParameters(bool includePrivateParameters)
        {
            CheckDisposed();

            if (includePrivateParameters)
                throw new CryptographicException("Private keys cannot be exported by this provider");

            return _publicKey.ExportParameters(includePrivateParameters);
        }

        /// <inheritdoc/>
        public override void ImportParameters(RSAParameters parameters)
        {
            throw new NotSupportedException();
        }

        private void CheckDisposed()
        {
            if (_publicKey == null)
                throw new ObjectDisposedException($"{nameof(KeyVaultRSA)} is disposed");
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _publicKey?.Dispose();
                _publicKey = null;
            }

            base.Dispose(disposing);
        }

        private static HashAlgorithm Create(HashAlgorithmName algorithm)
        {
            if (algorithm == HashAlgorithmName.SHA256)
                return SHA256.Create();

            if (algorithm == HashAlgorithmName.SHA384)
                return SHA384.Create();

            if (algorithm == HashAlgorithmName.SHA512)
                return SHA512.Create();

            throw new NotSupportedException("The specified algorithm is not supported.");
        }
    }
}
