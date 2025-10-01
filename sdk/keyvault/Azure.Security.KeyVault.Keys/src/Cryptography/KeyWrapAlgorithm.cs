// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// An algorithm used for key wrap and unwrap.
    /// </summary>
    public readonly struct KeyWrapAlgorithm : IEquatable<KeyWrapAlgorithm>
    {
        internal const string RsaOaepValue = "RSA-OAEP";
        internal const string Rsa15Value = "RSA1_5";
        internal const string RsaOaep256Value = "RSA-OAEP-256";
        internal const string A128KWValue = "A128KW";
        internal const string A192KWValue = "A192KW";
        internal const string A256KWValue = "A256KW";
        internal const string CkmAesKeyWrapValue = "CKM_AES_KEY_WRAP";
        internal const string CkmAesKeyWrapPadValue = "CKM_AES_KEY_WRAP_PAD";

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
        /// Gets an RSA-OAEP <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm RsaOaep { get; } = new KeyWrapAlgorithm(RsaOaepValue);

        /// <summary>
        /// Gets an RSA1_5 <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm Rsa15 { get; } = new KeyWrapAlgorithm(Rsa15Value);

        /// <summary>
        /// Gets an RSA-OAEP-256 <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm RsaOaep256 { get; } = new KeyWrapAlgorithm(RsaOaep256Value);

        /// <summary>
        /// Gets an AES 128 Key Wrap <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm A128KW { get; } = new KeyWrapAlgorithm(A128KWValue);

        /// <summary>
        /// Gets an AES 192 Key Wrap <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm A192KW { get; } = new KeyWrapAlgorithm(A192KWValue);

        /// <summary>
        /// Gets an AES 256 Key Wrap <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm A256KW { get; } = new KeyWrapAlgorithm(A256KWValue);

        /// <summary>
        /// Gets a CKM AES Key Wrap <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm CkmAesKeyWrap { get; } = new KeyWrapAlgorithm(CkmAesKeyWrapValue);

        /// <summary>
        /// Gets a CKM AES Key Wrap with padding <see cref="KeyWrapAlgorithm"/>.
        /// </summary>
        public static KeyWrapAlgorithm CkmAesKeyWrapPad { get; } = new KeyWrapAlgorithm(CkmAesKeyWrapPadValue);

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

        internal AesKw GetAesKeyWrapAlgorithm() => _value switch
        {
            A128KWValue => AesKw.Aes128Kw,
            A192KWValue => AesKw.Aes192Kw,
            A256KWValue => AesKw.Aes256Kw,
            _ => null,
        };
    }
}
