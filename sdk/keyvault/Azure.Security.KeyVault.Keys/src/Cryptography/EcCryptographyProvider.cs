// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class EcCryptographyProvider : ICryptographyProvider
    {
        private readonly KeyCurveName _curve;
        private readonly JsonWebKey _jwk;

        internal EcCryptographyProvider(JsonWebKey jwk)
        {
            Argument.AssertNotNull(jwk, nameof(jwk));

            // Only set the JWK if we support the algorithm locally.
            _curve = new KeyCurveName(jwk.CurveName);
            if (_curve.IsSupported)
            {
                // TODO: Log that we don't support the algorithm locally.
                _jwk = jwk;
            }
        }

        public bool ShouldRemote => _jwk.Id != null;

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
            if (_jwk.Id != null && !_jwk.HasPrivateKey)
            {
                // TODO: Log that we need a private key.
                return null;
            }

            ref readonly KeyCurveName algorithmCurve = ref algorithm.GetEcKeyCurveName();
            if (_curve.KeySize != algorithmCurve.KeySize)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key size {algorithmCurve.KeySize} does not match underlying key size {_curve.KeySize}");
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
                KeyId = _jwk.Id,
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

            // The JWK is not supported by this client. Send to the server.
            if (_jwk is null)
            {
                return null;
            }

            ref readonly KeyCurveName algorithmCurve = ref algorithm.GetEcKeyCurveName();
            if (_curve.KeySize != algorithmCurve.KeySize)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key size {algorithmCurve.KeySize} does not match underlying key size {_curve.KeySize}");
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
                KeyId = _jwk.Id,
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
