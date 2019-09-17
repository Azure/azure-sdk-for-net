// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Keys.Cryptography
{

    /// <summary>
    /// Describes the key wrap algorithm
    /// </summary>
    public readonly struct KeyWrapAlgorithm : IEquatable<KeyWrapAlgorithm>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyWrapAlgorithm"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public KeyWrapAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal const string RSAOAEP = "RSA-OAEP";
        internal const string RSA15 = "RSA-15";
        internal const string RSAOAEP256 = "RSA-OAEP-256";

        /// <summary>
        /// RSA-OAEP
        /// </summary>
        public static readonly KeyWrapAlgorithm RsaOaep = new KeyWrapAlgorithm(RSAOAEP);

        /// <summary>
        /// RSA-15
        /// </summary>
        public static readonly KeyWrapAlgorithm Rsa15 = new KeyWrapAlgorithm(RSA15);

        /// <summary>
        /// RSA-OAEP256
        /// </summary>
        public static readonly KeyWrapAlgorithm RsaOaep256 = new KeyWrapAlgorithm(RSAOAEP256);

        /// <summary>
        /// Determines if two <see cref="KeyWrapAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="a">The first <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyWrapAlgorithm a, KeyWrapAlgorithm b) => a.Equals(b);

        /// <summary>
        /// Determines if two <see cref="KeyWrapAlgorithm"/> values are different.
        /// </summary>
        /// <param name="a">The first <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <param name="b">The second <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyWrapAlgorithm a, KeyWrapAlgorithm b) => !a.Equals(b);

        /// <summary>
        /// Converts a string to a <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyWrapAlgorithm(string value) => new KeyWrapAlgorithm(value);

        /// <summary>
        /// Converts a <see cref="KeyWrapAlgorithm"/> to a string.
        /// </summary>
        /// <param name="value">The <see cref="KeyWrapAlgorithm"/> to convert.</param>
        public static implicit operator string(KeyWrapAlgorithm value) => value._value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyWrapAlgorithm other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(KeyWrapAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => _value;
    }
}
