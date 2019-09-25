// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public readonly struct CertificateKeyType : IEquatable<CertificateKeyType>
    {
        internal const string EC_KTY = "EC";
        internal const string EC_HSM_KTY = "EC-HSM";
        internal const string RSA_KTY = "RSA";
        internal const string RSA_HSM_KTY = "RSA-HSM";
        internal const string OCT_KTY = "oct";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateKeyType"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public CertificateKeyType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// An EC (EllipticCurve) key
        /// </summary>
        public static readonly CertificateKeyType EllipticCurve = new CertificateKeyType(EC_KTY);

        /// <summary>
        /// An HSM protected EC (EllipticCurve) key
        /// </summary>
        public static readonly CertificateKeyType EllipticCurveHsm = new CertificateKeyType(EC_HSM_KTY);

        /// <summary>
        /// A RSA key
        /// </summary>
        public static readonly CertificateKeyType Rsa = new CertificateKeyType(RSA_KTY);

        /// <summary>
        /// An HSM protected RSA key
        /// </summary>
        public static readonly CertificateKeyType RsaHsm = new CertificateKeyType(RSA_HSM_KTY);

        /// <summary>
        /// A octal (Symmetric) key
        /// </summary>
        public static readonly CertificateKeyType Oct = new CertificateKeyType(OCT_KTY);

        /// <summary>
        /// Determines if two <see cref="CertificateKeyType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateKeyType"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateKeyType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CertificateKeyType left, CertificateKeyType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CertificateKeyType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateKeyType"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateKeyType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CertificateKeyType left, CertificateKeyType right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="CertificateKeyType"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator CertificateKeyType(string value) => new CertificateKeyType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertificateKeyType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(CertificateKeyType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
