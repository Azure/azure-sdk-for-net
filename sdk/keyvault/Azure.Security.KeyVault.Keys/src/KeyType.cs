// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="JsonWebKey"/> key types.
    /// </summary>
    public readonly struct KeyType : IEquatable<KeyType>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyType"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public KeyType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Elliptic curve cryptographic algorithm.
        /// </summary>
        public static readonly KeyType Ec = new KeyType("EC");

        /// <summary>
        /// Elliptic curve cryptographic algorithm backed by HSM.
        /// </summary>
        public static readonly KeyType EcHsm = new KeyType("EC-HSM");

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
        public static readonly KeyType Oct = new KeyType("oct");

        /// <summary>
        /// Determines if two <see cref="KeyType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyType"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyType left, KeyType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyType"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyType left, KeyType right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="KeyType"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyType(string value) => new KeyType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
