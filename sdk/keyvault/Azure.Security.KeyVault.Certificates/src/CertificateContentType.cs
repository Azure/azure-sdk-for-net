// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Content type of the certificate when the managed secret is downloaded using a <c>SecretClient</c>.
    /// </summary>
    public readonly struct CertificateContentType : IEquatable<CertificateContentType>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateContentType"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public CertificateContentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a value indicating that content is downloaded in pkcs12 (PFX) format.
        /// </summary>
        public static CertificateContentType Pkcs12 { get; } = new CertificateContentType("application/x-pkcs12");

        /// <summary>
        /// Gets a value indicating that content is downloaded in PEM format.
        /// </summary>
        public static CertificateContentType Pem { get; } = new CertificateContentType("application/x-pem-file");

        /// <summary>
        /// Determines if two <see cref="CertificateContentType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateContentType"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateContentType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CertificateContentType left, CertificateContentType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CertificateContentType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CertificateContentType"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificateContentType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CertificateContentType left, CertificateContentType right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="CertificateContentType"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator CertificateContentType(string value) => new CertificateContentType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertificateContentType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(CertificateContentType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
