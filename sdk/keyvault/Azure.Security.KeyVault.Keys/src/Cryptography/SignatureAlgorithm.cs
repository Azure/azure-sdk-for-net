// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// An algorithm used for signing and verification.
    /// </summary>
    public readonly struct SignatureAlgorithm : IEquatable<SignatureAlgorithm>
    {
        internal const string RS256Value = "RS256";
        internal const string RS384Value = "RS384";
        internal const string RS512Value = "RS512";
        internal const string PS256Value = "PS256";
        internal const string PS384Value = "PS384";
        internal const string PS512Value = "PS512";
        internal const string ES256Value = "ES256";
        internal const string ES384Value = "ES384";
        internal const string ES512Value = "ES512";
        internal const string ES256KValue = "ES256K";
        internal const string HS256Value = "HS256";
        internal const string HS384Value = "HS384";
        internal const string HS512Value = "HS512";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public SignatureAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets an RSA SHA-256 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm RS256 { get; } = new SignatureAlgorithm(RS256Value);

        /// <summary>
        /// Gets an RSA SHA-384  <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm RS384 { get; } = new SignatureAlgorithm(RS384Value);

        /// <summary>
        /// Gets an RSA SHA-512  <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm RS512 { get; } = new SignatureAlgorithm(RS512Value);

        /// <summary>
        /// Gets an RSASSA-PSS using SHA-256 and MGF1 with SHA-256 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm PS256 { get; } = new SignatureAlgorithm(PS256Value);

        /// <summary>
        /// Gets an RSASSA-PSS using SHA-384 and MGF1 with SHA-384 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm PS384 { get; } = new SignatureAlgorithm(PS384Value);

        /// <summary>
        /// Gets an RSASSA-PSS using SHA-512 and MGF1 with SHA-512 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm PS512 { get; } = new SignatureAlgorithm(PS512Value);

        /// <summary>
        /// Gets an ECDSA with a P-256 curve <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm ES256 { get; } = new SignatureAlgorithm(ES256Value);

        /// <summary>
        /// Gets an ECDSA with a P-384 curve <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm ES384 { get; } = new SignatureAlgorithm(ES384Value);

        /// <summary>
        /// Gets an ECDSA with a P-521 curve <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm ES512 { get; } = new SignatureAlgorithm(ES512Value);

        /// <summary>
        /// Gets an ECDSA with a secp256k1 curve <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm ES256K { get; } = new SignatureAlgorithm(ES256KValue);

        /// <summary>
        /// Gets an HMAC using SHA-256 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm HS256 { get; } = new SignatureAlgorithm(HS256Value);

        /// <summary>
        /// Gets an HMAC using SHA-384 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm HS384 { get; } = new SignatureAlgorithm(HS384Value);

        /// <summary>
        /// Gets an HMAC using SHA-512 <see cref="SignatureAlgorithm"/> as described in <see href="https://tools.ietf.org/html/rfc7518"/>.
        /// </summary>
        public static SignatureAlgorithm HS512 { get; } = new SignatureAlgorithm(HS512Value);

        /// <summary>
        /// Determines if two <see cref="SignatureAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(SignatureAlgorithm left, SignatureAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="SignatureAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="SignatureAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(SignatureAlgorithm left, SignatureAlgorithm right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="SignatureAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator SignatureAlgorithm(string value) => new SignatureAlgorithm(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SignatureAlgorithm other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(SignatureAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        internal static SignatureAlgorithm FromHashAlgorithmName(HashAlgorithmName algorithm, RSASignaturePadding padding)
        {
            if (padding == RSASignaturePadding.Pkcs1)
            {
                if (algorithm == HashAlgorithmName.SHA256)
                {
                    return RS256;
                }

                if (algorithm == HashAlgorithmName.SHA384)
                {
                    return RS384;
                }

                if (algorithm == HashAlgorithmName.SHA512)
                {
                    return RS512;
                }
            }
            else if (padding == RSASignaturePadding.Pss)
            {
                if (algorithm == HashAlgorithmName.SHA256)
                {
                    return PS256;
                }

                if (algorithm == HashAlgorithmName.SHA384)
                {
                    return PS384;
                }

                if (algorithm == HashAlgorithmName.SHA512)
                {
                    return PS512;
                }
            }

            throw new NotSupportedException($"Hash algorithm {algorithm} with {padding} padding is not supported");
        }

        internal HashAlgorithm GetHashAlgorithm()
        {
            switch (_value)
            {
                case RS256Value:
                case PS256Value:
                case ES256Value:
                case ES256KValue:
                case HS256Value:
                    return SHA256.Create();

                case RS384Value:
                case PS384Value:
                case ES384Value:
                case HS384Value:
                    return SHA384.Create();

                case RS512Value:
                case PS512Value:
                case ES512Value:
                case HS512Value:
                    return SHA512.Create();

                default:
                    throw new InvalidOperationException("Invalid Algorithm");
            }
        }

        internal HashAlgorithmName GetHashAlgorithmName()
        {
            switch (_value)
            {
                case RS256Value:
                case PS256Value:
                case ES256Value:
                case ES256KValue:
                case HS256Value:
                    return HashAlgorithmName.SHA256;

                case RS384Value:
                case PS384Value:
                case ES384Value:
                case HS384Value:
                    return HashAlgorithmName.SHA384;

                case RS512Value:
                case PS512Value:
                case ES512Value:
                case HS512Value:
                    return HashAlgorithmName.SHA512;
                default:

                    return default;
            }
        }

        internal KeyCurveName GetEcKeyCurveName()
        {
            switch (_value)
            {
                case ES256Value:
                    return KeyCurveName.P256;

                case ES256KValue:
                    return KeyCurveName.P256K;

                case ES384Value:
                    return KeyCurveName.P384;

                case ES512Value:
                    return KeyCurveName.P521;

                default:
                    return default;
            }
        }

        internal RSASignaturePadding GetRsaSignaturePadding()
        {
            switch (_value)
            {
                case RS256Value:
                case RS384Value:
                case RS512Value:
                    return RSASignaturePadding.Pkcs1;

                case PS256Value:
                case PS384Value:
                case PS512Value:
                    return RSASignaturePadding.Pss;

                default:
                    return null;
            }
        }
    }
}
