// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// An operation that can be performed with the key.
    /// </summary>
    public struct KeyOperation : IEquatable<KeyOperation>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyOperation"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public KeyOperation(string value)
        {
            _value = value;
        }

        /// <summary>
        /// The key can be used to encrypt.
        /// </summary>
        public static readonly KeyOperation Encrypt = new KeyOperation("encrypt");

        /// <summary>
        /// The key can be used to decrypt.
        /// </summary>
        public static readonly KeyOperation Decrypt = new KeyOperation("decrypt");

        /// <summary>
        /// The key can be used to sign.
        /// </summary>
        public static readonly KeyOperation Sign = new KeyOperation("sign");

        /// <summary>
        /// The key can be used to verify.
        /// </summary>
        public static readonly KeyOperation Verify = new KeyOperation("verify");

        /// <summary>
        /// The key can be used to wrap another key.
        /// </summary>
        public static readonly KeyOperation WrapKey = new KeyOperation("wrapKey");

        /// <summary>
        /// The key can be used to unwrap another key.
        /// </summary>
        public static readonly KeyOperation UnwrapKey = new KeyOperation("unwrapKey");

        /// <summary>
        /// Determines if two <see cref="KeyOperation"/> values are the same.
        /// </summary>
        /// <param name="a">The first <see cref="KeyOperation"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyOperation"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyOperation a, KeyOperation b) => a.Equals(b);

        /// <summary>
        /// Determines if two <see cref="KeyOperation"/> values are different.
        /// </summary>
        /// <param name="a">The first <see cref="KeyOperation"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyOperation"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyOperation a, KeyOperation b) => !a.Equals(b);

        /// <summary>
        /// Converts a string to a <see cref="KeyOperation"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyOperation(string value) => new KeyOperation(value);

        /// <summary>
        /// Converts a <see cref="KeyOperation"/> to a string.
        /// </summary>
        /// <param name="value">The <see cref="KeyOperation"/> to convert.</param>
        public static implicit operator string(KeyOperation value) => value._value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is KeyOperation other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyOperation other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
