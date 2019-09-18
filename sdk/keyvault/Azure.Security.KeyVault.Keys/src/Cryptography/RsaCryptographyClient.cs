// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class RsaCryptographyClient : ICryptographyProvider
    {
        private readonly JsonWebKey _jwk;

        internal RsaCryptographyClient(JsonWebKey jwk)
        {
            _jwk = jwk;
        }

        public bool SupportsOperation(KeyOperation operation)
        {
            if (_jwk != null)
            {
                if (operation == KeyOperation.Encrypt || operation == KeyOperation.Decrypt || operation == KeyOperation.Sign || operation == KeyOperation.Verify || operation == KeyOperation.WrapKey || operation == KeyOperation.UnwrapKey)
                {
                    return _jwk.SupportsOperation(operation);
                }
            }

            return false;
        }

        public DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            DecryptResult result = Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
            return Task.FromResult(result);
        }

        public EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            EncryptResult result = Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
            return Task.FromResult(result);
        }

        public SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            SignResult result = Sign(algorithm, digest, cancellationToken);
            return Task.FromResult(result);
        }

        public UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            UnwrapResult result = UnwrapKey(algorithm, encryptedKey, cancellationToken);
            return Task.FromResult(result);
        }

        public VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            VerifyResult result = Verify(algorithm, digest, signature, cancellationToken);
            return Task.FromResult(result);
        }

        public WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            WrapResult result = WrapKey(algorithm, key, cancellationToken);
            return Task.FromResult(result);
        }
    }
}
