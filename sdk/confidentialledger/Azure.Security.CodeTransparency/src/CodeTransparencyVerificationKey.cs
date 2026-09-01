// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// A single public receipt-verification key exposed by a Code Transparency service.
    /// The key stores only public asymmetric key material and is decoupled from the JSON Web Key
    /// (JWK) and CBOR COSE_Key wire encodings used by the service.
    /// </summary>
    // A public constructor already enables mocking, so no model-factory method is required.
#pragma warning disable AZC0035
    public sealed class CodeTransparencyVerificationKey
#pragma warning restore AZC0035
    {
        // Only public EC parameters (named curve + public point Q) are ever stored.
        private readonly ECParameters _publicParameters;

        /// <summary>
        /// Initializes a new instance of <see cref="CodeTransparencyVerificationKey"/> by copying only the
        /// public parameters from <paramref name="publicKey"/>. Any private key material is discarded.
        /// </summary>
        /// <param name="keyId">The case-sensitive key ID that identifies this key within a key set.</param>
        /// <param name="publicKey">The ECDSA key whose public parameters are copied.</param>
        /// <exception cref="ArgumentException"><paramref name="keyId"/> is null or empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="publicKey"/> is null.</exception>
        /// <exception cref="NotSupportedException">The key uses an unsupported curve/size.</exception>
        public CodeTransparencyVerificationKey(string keyId, ECDsa publicKey)
        {
            if (string.IsNullOrEmpty(keyId))
            {
                throw new ArgumentException("Key ID must not be null or empty.", nameof(keyId));
            }
            if (publicKey == null)
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            // ExportParameters(false) requests only public parameters; private material is never copied.
            ECParameters exported = publicKey.ExportParameters(false);
            CoseAlgorithm = MapKeySizeToCoseAlgorithm(publicKey.KeySize);

            KeyId = keyId;
            _publicParameters = ClonePublicParameters(exported);
        }

        /// <summary>
        /// Gets the case-sensitive key ID.
        /// </summary>
        public string KeyId { get; }

        /// <summary>
        /// The COSE algorithm identifier (for example, -7 for ES256) implied by the key size/curve.
        /// </summary>
        internal int CoseAlgorithm { get; }

        /// <summary>
        /// The JWK/COSE curve name ("P-256", "P-384", or "P-521") implied by the key size/curve.
        /// </summary>
        internal string CurveName => CoseAlgorithm switch
        {
            -7 => "P-256",
            -35 => "P-384",
            -36 => "P-521",
            _ => throw new NotSupportedException($"Unsupported COSE algorithm '{CoseAlgorithm}'."),
        };

        /// <summary>
        /// Creates a new caller-owned <see cref="ECDsa"/> instance containing this public key.
        /// The returned instance is independent of this key and of any other returned instance.
        /// </summary>
        public ECDsa ToECDsa()
        {
            return ECDsa.Create(ClonePublicParameters(_publicParameters));
        }

        /// <summary>
        /// Returns an independent defensive copy of the public parameters for internal verification use.
        /// </summary>
        internal ECParameters ExportPublicParameters()
        {
            return ClonePublicParameters(_publicParameters);
        }

        /// <summary>
        /// Builds a verification key from a named curve and raw big-endian public coordinates, validating
        /// that the point is on the curve. Used by JWK and COSE_Key normalization.
        /// </summary>
        internal static CodeTransparencyVerificationKey FromPublicPoint(string keyId, ECCurve curve, byte[] x, byte[] y)
        {
            var parameters = new ECParameters
            {
                Curve = curve,
                Q = new ECPoint { X = x, Y = y },
            };

            ECDsa ecdsa;
            try
            {
                // ECDsa.Create validates that the supplied point lies on the curve. Depending on the platform,
                // an invalid point surfaces as CryptographicException, ArgumentException, or (on Windows CNG)
                // PlatformNotSupportedException wrapping a CryptographicException.
                ecdsa = ECDsa.Create(parameters);
            }
            catch (Exception ex) when (ex is CryptographicException || ex is ArgumentException || ex is PlatformNotSupportedException)
            {
                throw new FormatException($"The public key coordinates for key '{keyId}' are malformed or not on the curve.", ex);
            }

            using (ecdsa)
            {
                return new CodeTransparencyVerificationKey(keyId, ecdsa);
            }
        }

        private static ECParameters ClonePublicParameters(ECParameters source)
        {
            return new ECParameters
            {
                Curve = source.Curve,
                Q = new ECPoint
                {
                    X = source.Q.X == null ? null : (byte[])source.Q.X.Clone(),
                    Y = source.Q.Y == null ? null : (byte[])source.Q.Y.Clone(),
                },
                // D (private key) is intentionally never copied.
            };
        }

        private static int MapKeySizeToCoseAlgorithm(int keySize)
        {
            // COSE ECDSA algorithm identifiers, see https://www.iana.org/assignments/cose/cose.xhtml#algorithms
            return keySize switch
            {
                256 => -7, // ES256 with P-256
                384 => -35, // ES384 with P-384
                521 => -36, // ES512 with P-521
                _ => throw new NotSupportedException($"Unsupported ECDSA key size '{keySize}'. Only P-256, P-384, and P-521 are supported."),
            };
        }
    }
}
