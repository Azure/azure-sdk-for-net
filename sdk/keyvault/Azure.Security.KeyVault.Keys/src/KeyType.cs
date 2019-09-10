// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="JsonWebKey"/> key types.
    /// </summary>
    public struct KeyType : IEquatable<KeyType>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyType"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public KeyType(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Elliptic curve cryptographic algorithm.
        /// </summary>
        public static readonly KeyType EllipticCurve = new KeyType("EC");

        /// <summary>
        /// Elliptic curve cryptographic algorithm backed by HSM.
        /// </summary>
        public static readonly KeyType EllipticCurveHsm = new KeyType("EC-HSM");

        /// <summary>
        /// RSA cryptographic algorithm.
        /// </summary>
        public static readonly KeyType Rsa = new KeyType("RSA");

        /// <summary>
        /// RSA cryptographic algorithm backed by HSM.
        /// </summary>
        public static readonly KeyType RsaHsm = new KeyType("RSA-HSM");

        /// <summary>
        /// AES cryptographic algorithm.
        /// </summary>
        public static readonly KeyType Octet = new KeyType("oct");

        /// <summary>
        /// Determines if two <see cref="KeyType"/> values are the same.
        /// </summary>
        /// <param name="a">The first <see cref="KeyType"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyType"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyType a, KeyType b) => a.Equals(b);

        /// <summary>
        /// Determines if two <see cref="KeyType"/> values are different.
        /// </summary>
        /// <param name="a">The first <see cref="KeyType"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyType"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyType a, KeyType b) => !a.Equals(b);

        /// <summary>
        /// Converts a string to a <see cref="KeyType"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyType(string value) => new KeyType(value);

        /// <summary>
        /// Converts a <see cref="KeyType"/> to a string.
        /// </summary>
        /// <param name="value">The <see cref="KeyType"/> to convert.</param>
        public static implicit operator string(KeyType value) => value._value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is KeyType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
