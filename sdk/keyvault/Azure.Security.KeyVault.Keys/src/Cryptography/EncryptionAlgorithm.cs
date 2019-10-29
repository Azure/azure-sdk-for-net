// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// An algorithm used for encryption and decryption.
    /// </summary>
    public readonly struct EncryptionAlgorithm : IEquatable<EncryptionAlgorithm>
    {
        internal const string Rsa15Value = "RSA1_5";
        internal const string RsaOaepValue = "RSA-OAEP";
        internal const string RsaOaep256Value = "RSA-OAEP-256";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptionAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public EncryptionAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets an RSA1_5 <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm Rsa15 { get; } = new EncryptionAlgorithm(Rsa15Value);

        /// <summary>
        /// Gets an RSA-OAEP <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm RsaOaep { get; } = new EncryptionAlgorithm(RsaOaepValue);

        /// <summary>
        /// Gets an RSA-OAEP256 <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm RsaOaep256 { get; } = new EncryptionAlgorithm(RsaOaep256Value);

        /// <summary>
        /// Determines if two <see cref="EncryptionAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="EncryptionAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="EncryptionAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(EncryptionAlgorithm left, EncryptionAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="EncryptionAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="EncryptionAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="EncryptionAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(EncryptionAlgorithm left, EncryptionAlgorithm right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator EncryptionAlgorithm(string value) => new EncryptionAlgorithm(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EncryptionAlgorithm other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(EncryptionAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        internal RSAEncryptionPadding GetRsaEncryptionPadding() => _value switch
        {
            Rsa15Value => RSAEncryptionPadding.Pkcs1,
            RsaOaepValue => RSAEncryptionPadding.OaepSHA1,
            RsaOaep256Value => RSAEncryptionPadding.OaepSHA256,
            _ => null,
        };
    }
}
