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
        internal const string RSAOAEPValue = "RSA-OAEP";
        internal const string RSA15Value = "RSA-15";
        internal const string RSAOAEP256Value = "RSA-OAEP-256";
        internal const string A128KWValue = "A128KW";
        internal const string A192KWValue = "A192KW";
        internal const string A256KWValue = "A256KW";

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
        public static readonly KeyWrapAlgorithm RSAOAEP = new KeyWrapAlgorithm(RSAOAEPValue);

        /// <summary>
        /// RSA-15
        /// </summary>
        public static readonly KeyWrapAlgorithm RSA15 = new KeyWrapAlgorithm(RSA15Value);

        /// <summary>
        /// RSA-OAEP-256
        /// </summary>
        public static readonly KeyWrapAlgorithm RSAOAEP256 = new KeyWrapAlgorithm(RSAOAEP256Value);

        /// <summary>
        /// AES 128 Key Wrap
        /// </summary>
        public static readonly KeyWrapAlgorithm A128KW = new KeyWrapAlgorithm(A128KWValue);

        /// <summary>
        /// AES 192 Key Wrap
        /// </summary>
        public static readonly KeyWrapAlgorithm A192KW = new KeyWrapAlgorithm(A192KWValue);

        /// <summary>
        /// AES 256 Key Wrap
        /// </summary>
        public static readonly KeyWrapAlgorithm A256KW = new KeyWrapAlgorithm(A256KWValue);

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

        internal int GetKeySize() => _value switch
        {
            KeyWrapAlgorithm.A128KWValue => 128,
            KeyWrapAlgorithm.A192KWValue => 192,
            KeyWrapAlgorithm.A256KWValue => 256,
            _ => 0,
        };
    }
}
