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
        internal const string A128GcmValue = "A128GCM";
        internal const string A192GcmValue = "A192GCM";
        internal const string A256GcmValue = "A256GCM";
        internal const string A128CbcValue = "A128CBC";
        internal const string A192CbcValue = "A192CBC";
        internal const string A256CbcValue = "A256CBC";
        internal const string A128CbcPadValue = "A128CBCPAD";
        internal const string A192CbcPadValue = "A192CBCPAD";
        internal const string A256CbcPadValue = "A256CBCPAD";
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
        /// <para>
        /// <b>[Not recommended]</b>
        /// Gets an RSA1_5 <see cref="EncryptionAlgorithm"/>.
        /// </para><para>
        /// Microsoft recommends using <see cref="EncryptionAlgorithm.RsaOaep256"/> or stronger algorithms for enhanced security.
        /// Microsoft does <b>not</b> recommend <see cref="EncryptionAlgorithm.Rsa15"/>, which is included solely for backwards compatibility.
        /// Cryptographic standards no longer consider RSA with the PKCS#1 v1.5 padding scheme secure for encryption.
        /// </para>
        /// </summary>
        public static EncryptionAlgorithm Rsa15 { get; } = new EncryptionAlgorithm(Rsa15Value);

        /// <summary>
        /// <para>
        /// <b>[Not recommended]</b>
        /// Gets an RSA-OAEP <see cref="EncryptionAlgorithm"/>.
        /// </para><para>
        /// Microsoft recommends using <see cref="EncryptionAlgorithm.RsaOaep256"/> or stronger algorithms for enhanced security.
        /// Microsoft does <b>not</b> recommend <see cref="EncryptionAlgorithm.RsaOaep"/>, which is included solely for backwards compatibility.
        /// <see cref="EncryptionAlgorithm.RsaOaep"/> utilizes SHA1, which has known collision problems.
        /// </para>
        /// </summary>
        public static EncryptionAlgorithm RsaOaep { get; } = new EncryptionAlgorithm(RsaOaepValue);

        /// <summary>
        /// Gets an RSA-OAEP256 <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm RsaOaep256 { get; } = new EncryptionAlgorithm(RsaOaep256Value);

        /// <summary>
        /// Gets a 128-bit AES-GCM <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm A128Gcm { get; } = new EncryptionAlgorithm(A128GcmValue);

        /// <summary>
        /// Gets a 192-bit AES-GCM <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm A192Gcm { get; } = new EncryptionAlgorithm(A192GcmValue);

        /// <summary>
        /// Gets a 256-bit AES-GCM <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm A256Gcm { get; } = new EncryptionAlgorithm(A256GcmValue);

        /// <summary>
        /// Gets a 128-bit AES-CBC <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm A128Cbc { get; } = new EncryptionAlgorithm(A128CbcValue);

        /// <summary>
        /// Gets a 192-bit AES-CBC <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm A192Cbc { get; } = new EncryptionAlgorithm(A192CbcValue);

        /// <summary>
        /// Gets a 256-bit AES-CBC <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public static EncryptionAlgorithm A256Cbc { get; } = new EncryptionAlgorithm(A256CbcValue);

        /// <summary>
        /// Gets a 128-bit AES-CBC <see cref="EncryptionAlgorithm"/> with PKCS padding.
        /// </summary>
        public static EncryptionAlgorithm A128CbcPad { get; } = new EncryptionAlgorithm(A128CbcPadValue);

        /// <summary>
        /// Gets a 192-bit AES-CBC <see cref="EncryptionAlgorithm"/> with PKCS padding.
        /// </summary>
        public static EncryptionAlgorithm A192CbcPad { get; } = new EncryptionAlgorithm(A192CbcPadValue);

        /// <summary>
        /// Gets a 256-bit AES-CBC <see cref="EncryptionAlgorithm"/> with PKCS padding.
        /// </summary>
        public static EncryptionAlgorithm A256CbcPad { get; } = new EncryptionAlgorithm(A256CbcPadValue);

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

        internal static EncryptionAlgorithm FromRsaEncryptionPadding(RSAEncryptionPadding padding) => padding.Mode switch
        {
            RSAEncryptionPaddingMode.Pkcs1 => Rsa15,
            RSAEncryptionPaddingMode.Oaep when padding.OaepHashAlgorithm == HashAlgorithmName.SHA1 => RsaOaep,
            RSAEncryptionPaddingMode.Oaep when padding.OaepHashAlgorithm == HashAlgorithmName.SHA256 => RsaOaep256,
            _ => throw new NotSupportedException($"{padding} is not supported"),
        };

        internal RSAEncryptionPadding GetRsaEncryptionPadding() => _value switch
        {
            Rsa15Value => RSAEncryptionPadding.Pkcs1,
            RsaOaepValue => RSAEncryptionPadding.OaepSHA1,
            RsaOaep256Value => RSAEncryptionPadding.OaepSHA256,
            _ => null,
        };

        internal AesCbc GetAesCbcEncryptionAlgorithm() => _value switch
        {
            A128CbcValue => AesCbc.Aes128Cbc,
            A192CbcValue => AesCbc.Aes192Cbc,
            A256CbcValue => AesCbc.Aes256Cbc,

            A128CbcPadValue => AesCbc.Aes128CbcPad,
            A192CbcPadValue => AesCbc.Aes192CbcPad,
            A256CbcPadValue => AesCbc.Aes256CbcPad,

            _ => null,
        };
    }
}
