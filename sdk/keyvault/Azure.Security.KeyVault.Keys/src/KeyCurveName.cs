// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public readonly struct KeyCurveName : IEquatable<KeyCurveName>
    {
        private const string P256Value = "P-256";
        private const string P256KValue = "P-256K";
        private const string P384Value = "P-384";
        private const string P521Value = "P-521";

        private const string P256OidValue = "1.2.840.10045.3.1.7";
        private const string P256KOidValue = "1.3.132.0.10";
        private const string P384OidValue = "1.3.132.0.34";
        private const string P521OidValue = "1.3.132.0.35";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyCurveName"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public KeyCurveName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the NIST P-256 elliptic curve, AKA SECG curve SECP256R1
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static KeyCurveName P256 { get; } = new KeyCurveName(P256Value);

        /// <summary>
        /// Gets the SECG SECP256K1 elliptic curve.
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static KeyCurveName P256K { get; } = new KeyCurveName(P256KValue);

        /// <summary>
        /// Gets the NIST P-384 elliptic curve, AKA SECG curve SECP384R1.
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static KeyCurveName P384 { get; } = new KeyCurveName(P384Value);

        /// <summary>
        /// Gets the NIST P-521 elliptic curve, AKA SECG curve SECP521R1.
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static KeyCurveName P521 { get; } = new KeyCurveName(P521Value);

        /// <summary>
        /// Determines if two <see cref="KeyCurveName"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyCurveName"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyCurveName"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyCurveName left, KeyCurveName right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyCurveName"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyCurveName"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyCurveName"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyCurveName left, KeyCurveName right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="KeyCurveName"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyCurveName(string value) => new KeyCurveName(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyCurveName other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyCurveName other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        internal static KeyCurveName FromOid(Oid oid, int keySize = 0)
        {
            if (!string.IsNullOrEmpty(oid?.Value))
            {
                if (string.Equals(oid.Value, P521OidValue, StringComparison.Ordinal))
                {
                    return P521;
                }

                if (string.Equals(oid.Value, P384OidValue, StringComparison.Ordinal))
                {
                    return P384;
                }

                if (string.Equals(oid.Value, P256KOidValue, StringComparison.Ordinal))
                {
                    return P256K;
                }

                if (string.Equals(oid.Value, P256OidValue, StringComparison.Ordinal))
                {
                    return P256;
                }
            }

            if (!string.IsNullOrEmpty(oid?.FriendlyName))
            {
                switch (keySize)
                {
                    case 521 when string.Equals(oid.FriendlyName, "nistP521", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp521r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P521", StringComparison.OrdinalIgnoreCase):
                        return P521;

                    case 384 when string.Equals(oid.FriendlyName, "nistP384", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp384r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P384", StringComparison.OrdinalIgnoreCase):
                        return P384;

                    case 256 when string.Equals(oid.FriendlyName, "secp256k1", StringComparison.OrdinalIgnoreCase):
                        return P256K;

                    case 256 when string.Equals(oid.FriendlyName, "nistP256", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp256r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P256", StringComparison.OrdinalIgnoreCase):
                        return P256;
                }
            }

            return default;
        }

        internal bool IsSupported
        {
            get
            {
                switch (_value)
                {
                    case P256Value:
                    case P256KValue:
                    case P384Value:
                    case P521Value:
                        return true;

                    default:
                        return false;
                }
            }
        }

        internal int KeyParameterSize => _value switch
        {
            P256Value => 32,
            P256KValue => 32,
            P384Value => 48,
            P521Value => 66,
            _ => 0,
        };
        internal int KeySize => _value switch
        {
            P256Value => 256,
            P256KValue => 256,
            P384Value => 384,
            P521Value => 521,
            _ => 0,
        };

        internal Oid Oid => _value switch
        {
            P256Value => new Oid(P256OidValue),
            P256KValue => new Oid(P256KOidValue),
            P384Value => new Oid(P384OidValue),
            P521Value => new Oid(P521OidValue),
            _ => null,
        };
    }
}
