// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class RsaCryptographyProvider : ICryptographyProvider
    {
        private readonly JsonWebKey _jwk;

        internal RsaCryptographyProvider(JsonWebKey jwk)
        {
            _jwk = jwk ?? throw new ArgumentNullException(nameof(jwk));
        }

        public bool ShouldRemote => _jwk.KeyId != null;

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

        public EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(plaintext, nameof(plaintext));

            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            byte[] ciphertext = Encrypt(plaintext, padding);

            return new EncryptResult
            {
                Algorithm = algorithm,
                Ciphertext = ciphertext,
                KeyId = _jwk.KeyId,
            };
        }

        public Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            EncryptResult result = Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
            return Task.FromResult(result);
        }

        public DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(ciphertext, nameof(ciphertext));

            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            byte[] plaintext = Decrypt(ciphertext, padding);

            return new DecryptResult
            {
                Algorithm = algorithm,
                KeyId = _jwk.KeyId,
                Plaintext = plaintext,
            };
        }

        public Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            DecryptResult result = Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
            return Task.FromResult(result);
        }

        public SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            // A private key is required to sign. Send to the server.
            if (_jwk.KeyId != null && !_jwk.HasPrivateKey)
            {
                // TODO: Log that we need a private key.
                return null;
            }

            HashAlgorithmName hashAlgorithm = algorithm.GetHashAlgorithmName();
            if (hashAlgorithm == default)
            {
                // TODO: Log that we don't support the given algorithm.
                return null;
            }

            RSASignaturePadding padding = algorithm.GetRsaSignaturePadding();
            if (padding is null)
            {
                // TODO: Log that we don't support the given algorithm.
                return null;
            }

            using RSA rsa = _jwk.ToRSA(true);
            byte[] signature = rsa.SignHash(digest, hashAlgorithm, padding);

            return new SignResult
            {
                Algorithm = algorithm,
                KeyId = _jwk.KeyId,
                Signature = signature,
            };
        }

        public Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            SignResult result = Sign(algorithm, digest, cancellationToken);
            return Task.FromResult(result);
        }

        public VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(signature, nameof(signature));

            HashAlgorithmName hashAlgorithm = algorithm.GetHashAlgorithmName();
            if (hashAlgorithm == default)
            {
                // TODO: Log that we don't support the given algorithm.
                return null;
            }

            RSASignaturePadding padding = algorithm.GetRsaSignaturePadding();
            if (padding is null)
            {
                // TODO: Log that we don't support the given algorithm.
                return null;
            }

            using RSA rsa = _jwk.ToRSA();
            bool isValid = rsa.VerifyHash(digest, signature, hashAlgorithm, padding);

            return new VerifyResult
            {
                Algorithm = algorithm,
                IsValid = isValid,
                KeyId = _jwk.KeyId,
            };
        }

        public Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            VerifyResult result = Verify(algorithm, digest, signature, cancellationToken);
            return Task.FromResult(result);
        }

        public WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));

            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            byte[] encryptedKey = Encrypt(key, padding);

            return new WrapResult
            {
                Algorithm = algorithm,
                EncryptedKey = encryptedKey,
                KeyId = _jwk.KeyId,
            };
        }

        public Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            WrapResult result = WrapKey(algorithm, key, cancellationToken);
            return Task.FromResult(result);
        }

        public UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(encryptedKey, nameof(encryptedKey));

            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            byte[] key = Decrypt(encryptedKey, padding);

            return new UnwrapResult
            {
                Algorithm = algorithm,
                Key = key,
                KeyId = _jwk.KeyId,
            };
        }

        public Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            UnwrapResult result = UnwrapKey(algorithm, encryptedKey, cancellationToken);
            return Task.FromResult(result);
        }

        private byte[] Encrypt(byte[] data, RSAEncryptionPadding padding)
        {
            // A private key is required to encrypt. Send to the server.
            if (_jwk.KeyId != null && !_jwk.HasPrivateKey)
            {
                // TODO: Log that we need a private key.
                return null;
            }

            if (padding is null)
            {
                // TODO: Log that we don't support the given algorithm.
                return null;
            }

            using RSA rsa = _jwk.ToRSA(true);
            return rsa.Encrypt(data, padding);
        }

        private byte[] Decrypt(byte[] data, RSAEncryptionPadding padding)
        {
            if (padding is null)
            {
                // TODO: Log that we don't support the given algorithm.
                return null;
            }

            using RSA rsa = _jwk.ToRSA();
            return rsa.Decrypt(data, padding);
        }
    }
}
