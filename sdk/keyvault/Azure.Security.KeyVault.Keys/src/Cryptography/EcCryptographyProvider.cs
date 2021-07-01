// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class EcCryptographyProvider : LocalCryptographyProvider
    {
        private readonly KeyCurveName _curve;
        private readonly JsonWebKey _keyMaterial;

        internal EcCryptographyProvider(JsonWebKey keyMaterial, KeyProperties keyProperties, bool localOnly) : base(keyMaterial, keyProperties, localOnly)
        {
            // Unset the KeyMaterial since we want to conditionally set it if supported.
            KeyMaterial = null;

            // Only set the JWK if we support the algorithm locally.
            if (keyMaterial != null && keyMaterial.CurveName.HasValue)
            {
                // Save the key material to use for operational support validation.
                _keyMaterial = keyMaterial;

                _curve = keyMaterial.CurveName.Value;
                if (_curve.IsSupported)
                {
                    KeyMaterial = keyMaterial;
                }
            }
        }

        public override bool SupportsOperation(KeyOperation operation)
        {
            if (_keyMaterial != null)
            {
                if (operation == KeyOperation.Sign || operation == KeyOperation.Verify)
                {
                    return _keyMaterial.SupportsOperation(operation);
                }
            }

            return false;
        }

        public override SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            ThrowIfTimeInvalid();

            // The JWK is not supported by this client. Send to the server.
            if (KeyMaterial is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Sign), _curve);
                return null;
            }

            // A private key is required to sign. Send to the server.
            if (MustRemote)
            {
                KeysEventSource.Singleton.PrivateKeyRequired(nameof(Sign));
                return null;
            }

            KeyCurveName algorithmCurve = algorithm.GetEcKeyCurveName();
            if (_curve.KeySize != algorithmCurve.KeySize)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key size {algorithmCurve.KeySize} does not match underlying key size {_curve.KeySize}");
            }

            if (_curve != algorithmCurve)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key curve name does not correspond to underlying key curve name {_curve}");
            }

            using ECDsa ecdsa = KeyMaterial.ToECDsa(true, false);
            if (ecdsa is null)
            {
                return null;
            }

            byte[] signature = ecdsa.SignHash(digest);
            return new SignResult
            {
                Algorithm = algorithm,
                KeyId = KeyMaterial.Id,
                Signature = signature,
            };
        }

        public override VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            // The JWK is not supported by this client. Send to the server.
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(signature, nameof(signature));

            // The JWK is not supported by this client. Send to the server.
            if (KeyMaterial is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Verify), _curve);
                return null;
            }

            KeyCurveName algorithmCurve = algorithm.GetEcKeyCurveName();
            if (_curve.KeySize != algorithmCurve.KeySize)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key size {algorithmCurve.KeySize} does not match underlying key size {_curve.KeySize}");
            }

            if (_curve != algorithmCurve)
            {
                throw new ArgumentException($"Signature algorithm {algorithm} key curve name does not correspond to underlying key curve name {_curve}");
            }

            using ECDsa ecdsa = KeyMaterial.ToECDsa(false, false);
            if (ecdsa is null)
            {
                return null;
            }

            bool isValid = ecdsa.VerifyHash(digest, signature);
            return new VerifyResult
            {
                Algorithm = algorithm,
                IsValid = isValid,
                KeyId = KeyMaterial.Id,
            };
        }
    }
}
