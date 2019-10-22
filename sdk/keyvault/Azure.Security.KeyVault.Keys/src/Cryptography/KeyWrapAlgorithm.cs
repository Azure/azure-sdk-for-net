﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal const string A128KWValue = "A128KW";
        internal const string A192KWValue = "A192KW";
        internal const string A256KWValue = "A256KW";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyWrapAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public KeyWrapAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// RSA-OAEP
        /// </summary>
        public static KeyWrapAlgorithm RsaOaep { get; } = new KeyWrapAlgorithm(RsaOaepValue);

        /// <summary>
        /// RSA1_5
        /// </summary>
        public static KeyWrapAlgorithm Rsa15 { get; } = new KeyWrapAlgorithm(Rsa15Value);

        /// <summary>
        /// RSA-OAEP-256
        /// </summary>
        public static KeyWrapAlgorithm RsaOaep256 { get; } = new KeyWrapAlgorithm(RsaOaep256Value);

        /// <summary>
        /// AES 128 Key Wrap
        /// </summary>
        public static KeyWrapAlgorithm A128KW { get; } = new KeyWrapAlgorithm(A128KWValue);

        /// <summary>
        /// AES 192 Key Wrap
        /// </summary>
        public static KeyWrapAlgorithm A192KW { get; } = new KeyWrapAlgorithm(A192KWValue);

        /// <summary>
        /// AES 256 Key Wrap
        /// </summary>
        public static KeyWrapAlgorithm A256KW { get; } = new KeyWrapAlgorithm(A256KWValue);

        /// <summary>
        /// Determines if two <see cref="KeyWrapAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(KeyWrapAlgorithm left, KeyWrapAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="KeyWrapAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="KeyWrapAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(KeyWrapAlgorithm left, KeyWrapAlgorithm right) => !left.Equals(right);

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

        internal RSAEncryptionPadding GetRsaEncryptionPadding() => _value switch
        {
            Rsa15Value => RSAEncryptionPadding.Pkcs1,
            RsaOaepValue => RSAEncryptionPadding.OaepSHA1,
            RsaOaep256Value => RSAEncryptionPadding.OaepSHA256,
            _ => null,
        };

        internal int GetKeySizeInBits() => _value switch
        {
            A128KWValue => 128,
            A192KWValue => 192,
            A256KWValue => 256,
            _ => 0,
        };

        internal int GetKeySizeInBytes() => GetKeySizeInBits() >> 3;
    }
}
