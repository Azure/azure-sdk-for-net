// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Provides an implementation of the ECDsa algorithm backed by Azure Key Vault or Managed HSM.
    /// </summary>
    public class ECDsaKeyVault : ECDsa
    {
        private static readonly KeySizes[] s_legalKeySizes =
        {
            new(minSize: 256, maxSize: 384, skipSize: 128),
            new(minSize: 521, maxSize: 521, skipSize: 0),
        };

        private readonly CryptographyClient _client;
        private readonly KeyCurveName? _curveName;

        internal ECDsaKeyVault(CryptographyClient client, JsonWebKey keyMaterial)
        {
            _client = client;
            if (keyMaterial != null)
            {
                _curveName = keyMaterial.CurveName;
                Key = keyMaterial.ToECDsa();
            }
        }

        /// <summary>
        /// Gets the <see cref="ECDsa"/> public key if downloaded.
        /// </summary>
        public ECDsa Key { get; }

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">The key could not be downloaded so key size is unavailable.</exception>
        /// <exception cref="NotSupportedException">Changing the key size on this read-only provider is not supported.</exception>
        public override int KeySize
        {
            get => Key?.KeySize ?? throw new InvalidOperationException("Cannot download the key");
            set => throw new NotSupportedException("Cannot change the key size");
        }

        /// <inheritdoc/>
        public override KeySizes[] LegalKeySizes => s_legalKeySizes.Clone<KeySizes>();

        /// <summary>
        /// Computes the signature for the specified hash value by encrypting it with the private key using the specified padding.
        /// </summary>
        /// <param name="hash">The hash value of the data to be signed.</param>
        /// <returns>The RSA signature for the specified hash value.</returns>
        /// <exception cref="InvalidOperationException">The key could not be downloaded so the signature algorithm could not be determined.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public override byte[] SignHash(byte[] hash)
        {
            SignatureAlgorithm algorithm = GetAlgorithm();
            SignResult result = _client.Sign(algorithm, hash);

            return result.Signature;
        }

        /// <summary>
        /// Verifies that a digital signature is valid by determining the hash value in the signature using the specified hash algorithm and padding, and comparing it to the provided hash value.
        /// </summary>
        /// <param name="hash">The hash value of the signed data.</param>
        /// <param name="signature">The signature data to be verified.</param>
        /// <returns>true if the signature is valid; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">The key could not be downloaded so the signature algorithm could not be determined.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public override bool VerifyHash(byte[] hash, byte[] signature)
        {
            SignatureAlgorithm algorithm = GetAlgorithm();
            VerifyResult result = _client.Verify(algorithm, hash, signature);

            return result.IsValid;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Key?.Dispose();
            }

            base.Dispose(disposing);
        }

        private Cryptography.SignatureAlgorithm GetAlgorithm() => _curveName?.SignatureAlgorithm ?? throw new InvalidOperationException("Cannot download the key");
    }
}
