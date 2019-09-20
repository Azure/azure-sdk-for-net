// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{

    /// <summary>
    /// A digital signature algorithm
    /// </summary>
    public readonly struct SignatureAlgorithm : IEquatable<SignatureAlgorithm>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAlgorithm"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public SignatureAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
        internal const string RS256 = "RS256";
        internal const string RS384 = "RS384";
        internal const string RS512 = "RS512";
        internal const string PS256 = "PS256";
        internal const string PS384 = "PS384";
        internal const string PS512 = "PS512";
        internal const string ES256 = "ES256";
        internal const string ES384 = "ES384";
        internal const string ES512 = "ES512";
        internal const string ES256K = "ES256K";

        /// <summary>
        /// RSA SHA-256 signature algorithim.
        /// </summary>
        public static readonly SignatureAlgorithm Rs256 = new SignatureAlgorithm(RS256);

        /// <summary>
        /// RSA SHA-384 signature algorithim.
        /// </summary>
        public static readonly SignatureAlgorithm Rs384 = new SignatureAlgorithm(RS384);

        /// <summary>
        /// RSA SHA-512 Signature algorithim.
        /// </summary>
        public static readonly SignatureAlgorithm Rs512 = new SignatureAlgorithm(RS512);

        /// <summary>
        /// RSASSA-PSS using SHA-256 and MGF1 with SHA-256.
        /// </summary>
        public static readonly SignatureAlgorithm Ps256 = new SignatureAlgorithm(PS256);

        /// <summary>
        /// RSASSA-PSS using SHA-384 and MGF1 with SHA-384.
        /// </summary>
        public static readonly SignatureAlgorithm Ps384 = new SignatureAlgorithm(PS384);

        /// <summary>
        /// RSASSA-PSS using SHA-512 and MGF1 with SHA-512.
        /// </summary>
        public static readonly SignatureAlgorithm Ps512 = new SignatureAlgorithm(PS512);

        /// <summary>
        /// ECDSA with a P-256 curve.
        /// </summary>
        public static readonly SignatureAlgorithm Es256 = new SignatureAlgorithm(ES256);

        /// <summary>
        /// ECDSA with a P-384 curve.
        /// </summary>
        public static readonly SignatureAlgorithm Es384 = new SignatureAlgorithm(ES384);

        /// <summary>
        /// ECDSA with a P-521 curve.
        /// </summary>
        public static readonly SignatureAlgorithm Es512 = new SignatureAlgorithm(ES512);

        /// <summary>
        /// ECDSA with a secp256k1 curve.
        /// </summary>
        public static readonly SignatureAlgorithm Es256K = new SignatureAlgorithm(ES256K);

        /// <summary>
        /// Determines if two <see cref="SignatureAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="a">The first <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <param name="b">The second <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are the same; otherwise, false.</returns>
        public static bool operator ==(SignatureAlgorithm a, SignatureAlgorithm b) => a.Equals(b);

        /// <summary>
        /// Determines if two <see cref="SignatureAlgorithm"/> values are different.
        /// </summary>
        /// <param name="a">The first <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <param name="b">The second <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are different; otherwise, false.</returns>
        public static bool operator !=(SignatureAlgorithm a, SignatureAlgorithm b) => !a.Equals(b);

        /// <summary>
        /// Converts a string to a <see cref="SignatureAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator SignatureAlgorithm(string value) => new SignatureAlgorithm(value);

        /// <summary>
        /// Converts a <see cref="SignatureAlgorithm"/> to a string.
        /// </summary>
        /// <param name="value">The <see cref="SignatureAlgorithm"/> to convert.</param>
        public static implicit operator string(SignatureAlgorithm value) => value._value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SignatureAlgorithm other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(SignatureAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => _value;

        internal HashAlgorithm GetHashAlgorithm()
        {
            switch (_value)
            {
                case SignatureAlgorithm.RS256:
                case SignatureAlgorithm.PS256:
                case SignatureAlgorithm.ES256:
                case SignatureAlgorithm.ES256K:
                    return SHA256.Create();
                case SignatureAlgorithm.RS384:
                case SignatureAlgorithm.PS384:
                case SignatureAlgorithm.ES384:
                    return SHA384.Create();
                case SignatureAlgorithm.RS512:
                case SignatureAlgorithm.PS512:
                case SignatureAlgorithm.ES512:
                    return SHA512.Create();
                default:
                    throw new InvalidOperationException("Invalid Algorithm");
            }
        }

    }
}
