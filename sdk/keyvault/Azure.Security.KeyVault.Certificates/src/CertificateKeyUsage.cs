// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Supported usages of a certificate key
    /// </summary>
    public readonly struct CertificateKeyUsage : IEquatable<CertificateKeyUsage>
    {
        internal const string DigitalSignatureValue = "digitalSignature";
        internal const string NonRepudiationValue = "nonRepudiation";
        internal const string KeyEnciphermentValue = "keyEncipherment";
        internal const string DataEnciphermentValue = "dataEncipherment";
        internal const string KeyAgreementValue = "keyAgreement";
        internal const string KeyCertSignValue = "keyCertSign";
        internal const string CrlSignValue = "crlSign";
        internal const string EncipherOnlyValue = "encipherOnly";
        internal const string DecipherOnlyValue = "decipherOnly";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateKeyUsage"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public CertificateKeyUsage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// The certificate key can be used as a digital signatures
        /// </summary>
        public static CertificateKeyUsage DigitalSignature { get; } = new CertificateKeyUsage(DigitalSignatureValue);

        /// <summary>
        /// The certificate key can be used for authentication
        /// </summary>
        public static CertificateKeyUsage NonRepudiation { get; } = new CertificateKeyUsage(NonRepudiationValue);

        /// <summary>
        /// The certificate key can be used for key encryption
        /// </summary>
        public static CertificateKeyUsage KeyEncipherment { get; } = new CertificateKeyUsage(KeyEnciphermentValue);

        /// <summary>
        /// The certificate key can be used for data encryption
        /// </summary>
        public static CertificateKeyUsage DataEncipherment { get; } = new CertificateKeyUsage(DataEnciphermentValue);

        /// <summary>
        /// The certificate key can be used to determine key agreement, such as a key created using the Diffie-Hellman key agreement algorithm.
        /// </summary>
        public static CertificateKeyUsage KeyAgreement { get; } = new CertificateKeyUsage(KeyAgreementValue);

        /// <summary>
        /// The certificate key can be used to sign certificates
        /// </summary>
        public static CertificateKeyUsage KeyCertSign { get; } = new CertificateKeyUsage(KeyCertSignValue);

        /// <summary>
        /// The certificate key can be used to sign a certificate revocation list
        /// </summary>
        public static CertificateKeyUsage CrlSign { get; } = new CertificateKeyUsage(CrlSignValue);

        /// <summary>
        /// The certificate key can be used for encryption only
        /// </summary>
        public static CertificateKeyUsage EncipherOnly { get; } = new CertificateKeyUsage(EncipherOnlyValue);

        /// <summary>
        /// The certificate key can be used for decryption only
        /// </summary>
        public static CertificateKeyUsage DecipherOnly { get; } = new CertificateKeyUsage(DecipherOnlyValue);

        /// <summary>
        /// Determines if two <see cref="CertificateKeyUsage"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateKeyUsage"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateKeyUsage"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CertificateKeyUsage left, CertificateKeyUsage right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CertificateKeyUsage"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateKeyUsage"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateKeyUsage"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CertificateKeyUsage left, CertificateKeyUsage right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="CertificateKeyUsage"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator CertificateKeyUsage(string value) => new CertificateKeyUsage(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertificateKeyUsage other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(CertificateKeyUsage other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
