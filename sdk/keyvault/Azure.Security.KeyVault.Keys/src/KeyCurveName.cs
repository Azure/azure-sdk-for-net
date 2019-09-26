// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys
{

    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public readonly struct KeyCurveName : IEquatable<KeyCurveName>
    {
        internal readonly Oid _oid;
        internal readonly int _keySize;
        internal readonly int _keyParameterSize;
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyCurveName"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public KeyCurveName(string value)
        {
            ref readonly KeyCurveName curveName = ref Find(value);

            _value = curveName._value ?? value;
            _oid = curveName._oid;
            _keySize = curveName._keySize;
            _keyParameterSize = curveName._keyParameterSize;
        }

        private KeyCurveName(string value, Oid oid, int keySize, int keyParameterSize)
        {
            _value = value;

            _oid = oid;
            _keySize = keySize;
            _keyParameterSize = keyParameterSize;
        }

        /// <summary>
        /// The NIST P-256 elliptic curve, AKA SECG curve SECP256R1
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        public static readonly KeyCurveName P256 = new KeyCurveName("P-256", new Oid("1.2.840.10045.3.1.7"), 256, 32);
        /// <summary>
        /// The NIST P-384 elliptic curve, AKA SECG curve SECP384R1.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        public static readonly KeyCurveName P256K = new KeyCurveName("P-256K", new Oid("1.3.132.0.10"), 256, 32);
        /// <summary>
        /// The NIST P-521 elliptic curve, AKA SECG curve SECP521R1.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        public static readonly KeyCurveName P384 = new KeyCurveName("P-384", new Oid("1.3.132.0.34"), 384, 48);
        /// <summary>
        /// The SECG SECP256K1 elliptic curve.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        public static readonly KeyCurveName P521 = new KeyCurveName("P-521", new Oid("1.3.132.0.35"), 521, 66);

        internal static readonly KeyCurveName s_default = default;

        /// <summary>
        /// Determines if two <see cref="KeyCurveName"/> values are the same.
        /// </summary>
        /// <param name="a">The first <see cref="KeyCurveName"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyCurveName"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyCurveName a, KeyCurveName b) => a.Equals(b);

        /// <summary>
        /// Determines if two <see cref="KeyCurveName"/> values are different.
        /// </summary>
        /// <param name="a">The first <see cref="KeyCurveName"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyCurveName"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyCurveName a, KeyCurveName b) => !a.Equals(b);

        /// <summary>
        /// Converts a string to a <see cref="KeyCurveName"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyCurveName(string value) => new KeyCurveName(value);

        internal static ref readonly KeyCurveName Find(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (string.Equals(P521._value, name, StringComparison.Ordinal))
                {
                    return ref P521;
                }

                if (string.Equals(P384._value, name, StringComparison.Ordinal))
                {
                    return ref P384;
                }

                if (string.Equals(P256K._value, name, StringComparison.Ordinal))
                {
                    return ref P256K;
                }

                if (string.Equals(P256._value, name, StringComparison.Ordinal))
                {
                    return ref P256;
                }
            }

            return ref s_default;
        }

        internal static ref readonly KeyCurveName Find(Oid oid, int keySize)
        {
            if (!string.IsNullOrEmpty(oid?.Value))
            {
                if (string.Equals(oid.Value, P521._oid.Value, StringComparison.Ordinal))
                {
                    return ref P521;
                }

                if (string.Equals(oid.Value, P384._oid.Value, StringComparison.Ordinal))
                {
                    return ref P384;
                }

                if (string.Equals(oid.Value, P256K._oid.Value, StringComparison.Ordinal))
                {
                    return ref P256K;
                }

                if (string.Equals(oid.Value, P256._oid.Value, StringComparison.Ordinal))
                {
                    return ref P256;
                }
            }

            if (!string.IsNullOrEmpty(oid?.FriendlyName))
            {
                switch (keySize)
                {
                    case 521 when string.Equals(oid.FriendlyName, "nistP521", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp521r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P521", StringComparison.OrdinalIgnoreCase):
                        return ref P521;

                    case 384 when string.Equals(oid.FriendlyName, "nistP384", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp384r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P384", StringComparison.OrdinalIgnoreCase):
                        return ref P384;

                    case 256 when string.Equals(oid.FriendlyName, "secp256k1", StringComparison.OrdinalIgnoreCase):
                        return ref P256K;

                    case 256 when string.Equals(oid.FriendlyName, "nistP256", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp256r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P256", StringComparison.OrdinalIgnoreCase):
                        return ref P256;
                }
            }

            return ref s_default;
        }

        /// <summary>
        /// Converts a <see cref="KeyCurveName"/> to a string.
        /// </summary>
        /// <param name="value">The <see cref="KeyCurveName"/> to convert.</param>
        public static implicit operator string(KeyCurveName value) => value._value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is KeyCurveName other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyCurveName other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
