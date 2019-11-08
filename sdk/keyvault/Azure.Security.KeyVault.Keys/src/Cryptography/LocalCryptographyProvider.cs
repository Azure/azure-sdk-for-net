// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal abstract class LocalCryptographyProvider : ICryptographyProvider
    {
        private readonly KeyVaultKey _key;

        public LocalCryptographyProvider(KeyVaultKey key)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));

            KeyMaterial = key.Key;
        }

        public bool ShouldRemote => KeyMaterial?.Id != null;

        protected JsonWebKey KeyMaterial { get; set; }

        protected bool MustRemote => ShouldRemote && !KeyMaterial.HasPrivateKey;

        public abstract bool SupportsOperation(KeyOperation operation);

        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public virtual Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default)
        {
            DecryptResult result = Decrypt(algorithm, ciphertext, cancellationToken);
            return Task.FromResult(result);
        }

        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public virtual Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default)
        {
            EncryptResult result = Encrypt(algorithm, plaintext, cancellationToken);
            return Task.FromResult(result);
        }

        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public virtual Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            SignResult result = Sign(algorithm, digest, cancellationToken);
            return Task.FromResult(result);
        }

        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public virtual Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            UnwrapResult result = UnwrapKey(algorithm, encryptedKey, cancellationToken);
            return Task.FromResult(result);
        }

        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public virtual Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            VerifyResult result = Verify(algorithm, digest, signature, cancellationToken);
            return Task.FromResult(result);
        }

        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public virtual Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            WrapResult result = WrapKey(algorithm, key, cancellationToken);
            return Task.FromResult(result);
        }

        protected void ThrowIfTimeInvalid()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            if (_key.Properties.NotBefore.HasValue && now < _key.Properties.NotBefore.Value)
            {
                throw new InvalidOperationException($"The key \"{_key.Name}\" is not valid before {_key.Properties.NotBefore.Value:r}.");
            }

            if (_key.Properties.ExpiresOn.HasValue && now > _key.Properties.ExpiresOn.Value)
            {
                throw new InvalidOperationException($"The key \"{_key.Name}\" is not valid after {_key.Properties.ExpiresOn.Value:r}.");
            }
        }
    }
}
