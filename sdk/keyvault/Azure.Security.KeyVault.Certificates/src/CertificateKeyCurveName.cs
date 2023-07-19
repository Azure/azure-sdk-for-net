// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public readonly struct CertificateKeyCurveName : IEquatable<CertificateKeyCurveName>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateKeyCurveName"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public CertificateKeyCurveName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the NIST P-256 elliptic curve, AKA SECG curve SECP256R1
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static CertificateKeyCurveName P256 { get; } = new CertificateKeyCurveName("P-256");

        /// <summary>
        /// Gets the NIST P-384 elliptic curve, AKA SECG curve SECP384R1.
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static CertificateKeyCurveName P384 { get; } = new CertificateKeyCurveName("P-384");

        /// <summary>
        /// Gets the NIST P-521 elliptic curve, AKA SECG curve SECP521R1.
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static CertificateKeyCurveName P521 { get; } = new CertificateKeyCurveName("P-521");

        /// <summary>
        /// Gets the SECG SECP256K1 elliptic curve.
        /// For more information, see <see href="https://docs.microsoft.com/azure/key-vault/keys/about-keys#curve-types">Curve types</see>.
        /// </summary>
        public static CertificateKeyCurveName P256K { get; } = new CertificateKeyCurveName("P-256K");

        /// <summary>
        /// Determines if two <see cref="CertificateKeyCurveName"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateKeyCurveName"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateKeyCurveName"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CertificateKeyCurveName left, CertificateKeyCurveName right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CertificateKeyCurveName"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateKeyCurveName"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateKeyCurveName"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CertificateKeyCurveName left, CertificateKeyCurveName right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="CertificateKeyCurveName"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator CertificateKeyCurveName(string value) => new CertificateKeyCurveName(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertificateKeyCurveName other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(CertificateKeyCurveName other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
