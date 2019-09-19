// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Describes the key wrap algorithm
    /// </summary>
    public readonly struct KeyWrapAlgorithm : IEquatable<KeyWrapAlgorithm>
    {
        internal const string RsaOaepValue = "RSA-OAEP";
        internal const string Rsa15Value = "RSA1_5";
        internal const string RsaOaep256Value = "RSA-OAEP-256";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyWrapAlgorithm"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public KeyWrapAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// RSA-OAEP
        /// </summary>
        public static readonly KeyWrapAlgorithm RsaOaep = new KeyWrapAlgorithm(RsaOaepValue);

        /// <summary>
        /// RSA1_5
        /// </summary>
        public static readonly KeyWrapAlgorithm Rsa15 = new KeyWrapAlgorithm(Rsa15Value);

        /// <summary>
        /// RSA-OAEP-256
        /// </summary>
        public static readonly KeyWrapAlgorithm RsaOaep256 = new KeyWrapAlgorithm(RsaOaep256Value);

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

        internal RSAEncryptionPadding GetEncryptionPadding()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
