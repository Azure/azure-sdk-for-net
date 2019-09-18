// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class EcCryptographyClient : ICryptographyProvider
    {
        private readonly KeyCurveName _curve;
        private readonly JsonWebKey _jwk;

        internal EcCryptographyClient(JsonWebKey jwk)
        {
            // Only set the JWK if we support the algorithm locally.
            _curve = KeyCurveName.Find(jwk.CurveName);
            if (_curve != default)
            {
                // TODO: Log that we don't support the algorithm locally.
                _jwk = jwk;
            }
        }

        // Types of exceptions:
        // * Argument exceptions - data is just wrong.
        // * Unsupported exceptions - we may not support a particular algorithm locally but Azure might.
        // * Server exceptions - server returned an error.

        public bool SupportsOperation(KeyOperation operation)
        {
            if (_jwk != null)
            {
                if (operation == KeyOperation.Sign || operation == KeyOperation.Verify)
                {
                    return _jwk.SupportsOperation(operation);
                }
            }

            return false;
        }

        public SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            // The JWK is not supported by this client. Send to the server.
            if (_jwk is null)
            {
                return null;
            }

            // A private key is required to sign. Send to the server.
            if (_jwk.KeyId != null && !_jwk.HasPrivateKey)
            {
                return null;
            }

            ref readonly KeyCurveName algorithmCurve = ref algorithm.GetKeyCurveName();
            if (_curve._keySize != algorithmCurve._keySize)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key size {algorithmCurve._keySize} does not match underlying key size {_curve._keySize}");
            }

            if (_curve != algorithmCurve)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key curve name does not correspond to underlying key curve name {_curve}");
            }

            using ECDsa ecdsa = _jwk.ToECDsa(true, false);
            if (ecdsa is null)
            {
                return null;
            }

            byte[] signature = ecdsa.SignHash(digest);
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
            // The JWK is not supported by this client. Send to the server.
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(signature, nameof(signature));

            if (_jwk is null)
            {
                return null;
            }

            ref readonly KeyCurveName algorithmCurve = ref algorithm.GetKeyCurveName();
            if (_curve._keySize != algorithmCurve._keySize)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key size {algorithmCurve._keySize} does not match underlying key size {_curve._keySize}");
            }

            if (_curve != algorithmCurve)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key curve name does not correspond to underlying key curve name {_curve}");
            }

            using ECDsa ecdsa = _jwk.ToECDsa(false, false);
            if (ecdsa is null)
            {
                return null;
            }

            bool isValid = ecdsa.VerifyHash(digest, signature);
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

        #region Unsupported operations
        DecryptResult ICryptographyProvider.Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        Task<DecryptResult> ICryptographyProvider.DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        EncryptResult ICryptographyProvider.Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        Task<EncryptResult> ICryptographyProvider.EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        UnwrapResult ICryptographyProvider.UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        Task<UnwrapResult> ICryptographyProvider.UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        WrapResult ICryptographyProvider.WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        Task<WrapResult> ICryptographyProvider.WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
