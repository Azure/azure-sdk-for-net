// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The encryption algorithm used to protect the exported key material.
    /// </summary>
    public readonly struct KeyExportEncryptionAlgorithm : IEquatable<KeyExportEncryptionAlgorithm>
    {
        internal const string CkmRsaAesKeyWrapValue = "CKM_RSA_AES_KEY_WRAP";
        internal const string RsaAesKeyWrap256Value = "RSA_AES_KEY_WRAP_256";
        internal const string RsaAesKeyWrap384Value = "RSA_AES_KEY_WRAP_384";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyExportEncryptionAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public KeyExportEncryptionAlgorithm(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary>
        /// Gets an CKM_RSA_AES_KEY_WRAP <see cref="KeyExportEncryptionAlgorithm"/>.
        /// </summary>
        public static KeyExportEncryptionAlgorithm CkmRsaAesKeyWrap { get; } = new KeyExportEncryptionAlgorithm(CkmRsaAesKeyWrapValue);

        /// <summary>
        /// Gets an RSA_AES_KEY_WRAP_256 <see cref="KeyExportEncryptionAlgorithm"/>.
        /// </summary>
        public static KeyExportEncryptionAlgorithm RsaAesKeyWrap256 { get; } = new KeyExportEncryptionAlgorithm(RsaAesKeyWrap256Value);

        /// <summary>
        /// Gets an RSA_AES_KEY_WRAP_384 <see cref="KeyExportEncryptionAlgorithm"/>.
        /// </summary>
        public static KeyExportEncryptionAlgorithm RsaAesKeyWrap384 { get; } = new KeyExportEncryptionAlgorithm(RsaAesKeyWrap384Value);

        /// <summary>
        /// Determines if two <see cref="KeyExportEncryptionAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyExportEncryptionAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyExportEncryptionAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyExportEncryptionAlgorithm left, KeyExportEncryptionAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyExportEncryptionAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyExportEncryptionAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyExportEncryptionAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyExportEncryptionAlgorithm left, KeyExportEncryptionAlgorithm right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="KeyExportEncryptionAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator KeyExportEncryptionAlgorithm(string value) => new KeyExportEncryptionAlgorithm(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyExportEncryptionAlgorithm other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(KeyExportEncryptionAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
