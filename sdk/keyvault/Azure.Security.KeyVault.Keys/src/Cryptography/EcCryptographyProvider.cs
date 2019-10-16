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

        internal EcCryptographyProvider(Key key) : base(key)
        {
            // Unset the KeyMaterial since we want to conditionally set it if supported.
            KeyMaterial = null;

            // Only set the JWK if we support the algorithm locally.
            JsonWebKey keyMaterial = key.KeyMaterial;
            if (keyMaterial != null && keyMaterial.CurveName.HasValue)
            {
                _curve = keyMaterial.CurveName.Value;
                if (_curve.IsSupported)
                {
                    KeyMaterial = keyMaterial;
                }
                else
                {
                    // TODO: Log that we don't support the algorithm locally.
                }
            }
        }

        public override bool SupportsOperation(KeyOperation operation)
        {
            if (KeyMaterial != null)
            {
                if (operation == KeyOperation.Sign || operation == KeyOperation.Verify)
                {
                    return KeyMaterial.SupportsOperation(operation);
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
                return null;
            }

            // A private key is required to sign. Send to the server.
            if (MustRemote)
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
