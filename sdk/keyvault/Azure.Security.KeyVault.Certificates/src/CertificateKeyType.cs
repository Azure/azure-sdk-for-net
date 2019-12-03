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
        internal const string EcValue = "EC";
        internal const string EcHsmValue = "EC-HSM";
        internal const string RsaValue = "RSA";
        internal const string RsaHsmValue = "RSA-HSM";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateKeyType"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public CertificateKeyType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// An Elliptic Curve Cryptographic (ECC) algorithm.
        /// </summary>
        public static CertificateKeyType Ec { get; } = new CertificateKeyType(EcValue);

        /// <summary>
        /// An Elliptic Curve Cryptographic (ECC) algorithm backed by HSM.
        /// </summary>
        public static CertificateKeyType EcHsm { get; } = new CertificateKeyType(EcHsmValue);

        /// <summary>
        /// An RSA cryptographic algorithm.
        /// </summary>
        public static CertificateKeyType Rsa { get; } = new CertificateKeyType(RsaValue);

        /// <summary>
        /// An RSA cryptographic algorithm backed by HSM.
        /// </summary>
        public static CertificateKeyType RsaHsm { get; } = new CertificateKeyType(RsaHsmValue);

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
