// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// An algorithm used for secure key wrap and unwrap operations.
    /// </summary>
    /// <remarks>
    /// This type is only available with API version 2026-01-01-preview and newer.
    /// Secure key wrap and unwrap operations are only supported remotely and cannot be performed locally.
    /// </remarks>
    public readonly struct SecureKeyWrapAlgorithm : IEquatable<SecureKeyWrapAlgorithm>
    {
        internal const string RsaOaep256Value = "RSA-OAEP-256";
        internal const string A128KWValue = "A128KW";
        internal const string A192KWValue = "A192KW";
        internal const string A256KWValue = "A256KW";
        internal const string A128KWPadValue = "A128KWPAD";
        internal const string A192KWPadValue = "A192KWPAD";
        internal const string A256KWPadValue = "A256KWPAD";
        internal const string CkmAesKeyWrapValue = "CKM_AES_KEY_WRAP";
        internal const string CkmAesKeyWrapPadValue = "CKM_AES_KEY_WRAP_PAD";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecureKeyWrapAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public SecureKeyWrapAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets an RSA-OAEP-256 <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm RsaOaep256 { get; } = new SecureKeyWrapAlgorithm(RsaOaep256Value);

        /// <summary>
        /// Gets an AES 128 Key Wrap <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm A128KW { get; } = new SecureKeyWrapAlgorithm(A128KWValue);

        /// <summary>
        /// Gets an AES 192 Key Wrap <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm A192KW { get; } = new SecureKeyWrapAlgorithm(A192KWValue);

        /// <summary>
        /// Gets an AES 256 Key Wrap <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm A256KW { get; } = new SecureKeyWrapAlgorithm(A256KWValue);

        /// <summary>
        /// Gets an AES 128 Key Wrap with padding <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm A128KWPad { get; } = new SecureKeyWrapAlgorithm(A128KWPadValue);

        /// <summary>
        /// Gets an AES 192 Key Wrap with padding <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm A192KWPad { get; } = new SecureKeyWrapAlgorithm(A192KWPadValue);

        /// <summary>
        /// Gets an AES 256 Key Wrap with padding <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm A256KWPad { get; } = new SecureKeyWrapAlgorithm(A256KWPadValue);

        /// <summary>
        /// Gets a CKM AES Key Wrap <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm CkmAesKeyWrap { get; } = new SecureKeyWrapAlgorithm(CkmAesKeyWrapValue);

        /// <summary>
        /// Gets a CKM AES Key Wrap with padding <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        public static SecureKeyWrapAlgorithm CkmAesKeyWrapPad { get; } = new SecureKeyWrapAlgorithm(CkmAesKeyWrapPadValue);

        /// <summary>
        /// Determines if two <see cref="SecureKeyWrapAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="SecureKeyWrapAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="SecureKeyWrapAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(SecureKeyWrapAlgorithm left, SecureKeyWrapAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="SecureKeyWrapAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="SecureKeyWrapAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="SecureKeyWrapAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(SecureKeyWrapAlgorithm left, SecureKeyWrapAlgorithm right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="SecureKeyWrapAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator SecureKeyWrapAlgorithm(string value) => new SecureKeyWrapAlgorithm(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SecureKeyWrapAlgorithm other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(SecureKeyWrapAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => _value;
    }
}
