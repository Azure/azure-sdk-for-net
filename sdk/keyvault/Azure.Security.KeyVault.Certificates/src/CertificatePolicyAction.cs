// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An action that will be executed.
    /// </summary>
    public readonly struct CertificatePolicyAction : IEquatable<CertificatePolicyAction>
    {
        internal const string AutoRenewValue = "AutoRenew";
        internal const string EmailContactsValue = "EmailContacts";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatePolicyAction"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public CertificatePolicyAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets a <see cref="CertificatePolicyAction"/> that will auto-renew a certificate.
        /// </summary>
        public static CertificatePolicyAction AutoRenew { get; } = new CertificatePolicyAction(AutoRenewValue);

        /// <summary>
        /// Gets a <see cref="CertificatePolicyAction"/> action that will email certificate contacts.
        /// </summary>
        public static CertificatePolicyAction EmailContacts { get; } = new CertificatePolicyAction(EmailContactsValue);

        /// <summary>
        /// Determines if two <see cref="CertificatePolicyAction"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CertificatePolicyAction"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificatePolicyAction"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CertificatePolicyAction left, CertificatePolicyAction right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CertificatePolicyAction"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CertificatePolicyAction"/> to compare.</param>
        /// <param name="right">The second <see cref="CertificatePolicyAction"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CertificatePolicyAction left, CertificatePolicyAction right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="CertificatePolicyAction"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator CertificatePolicyAction(string value) => new CertificatePolicyAction(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertificatePolicyAction other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(CertificatePolicyAction other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
