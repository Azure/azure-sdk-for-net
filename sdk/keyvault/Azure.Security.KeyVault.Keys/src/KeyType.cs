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
        /// <param name="value">The string value of the instance.</param>
        public KeyType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// An Elliptic Curve Cryptographic (ECC) algorithm.
        /// </summary>
        public static KeyType Ec { get; } = new KeyType("EC");

        /// <summary>
        /// An Elliptic Curve Cryptographic (ECC) algorithm backed by HSM.
        /// </summary>
        public static KeyType EcHsm { get; } = new KeyType("EC-HSM");

        /// <summary>
        /// An RSA cryptographic algorithm.
        /// </summary>
        public static KeyType Rsa { get; } = new KeyType("RSA");

        /// <summary>
        /// An RSA cryptographic algorithm backed by HSM.
        /// </summary>
        public static KeyType RsaHsm { get; } = new KeyType("RSA-HSM");

        /// <summary>
        /// An AES cryptographic algorithm.
        /// </summary>
        public static KeyType Oct { get; } = new KeyType("oct");

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
