// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The KeyVaultCertificateSourceType. </summary>
    public readonly partial struct KeyVaultCertificateSourceType : IEquatable<KeyVaultCertificateSourceType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KeyVaultCertificateSourceType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KeyVaultCertificateSourceType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KeyVaultCertificateSourceValue = "KeyVaultCertificateSourceParameters";

        /// <summary> KeyVaultCertificateSourceParameters. </summary>
        public static KeyVaultCertificateSourceType KeyVaultCertificateSource { get; } = new KeyVaultCertificateSourceType(KeyVaultCertificateSourceValue);
        /// <summary> Determines if two <see cref="KeyVaultCertificateSourceType"/> values are the same. </summary>
        public static bool operator ==(KeyVaultCertificateSourceType left, KeyVaultCertificateSourceType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KeyVaultCertificateSourceType"/> values are not the same. </summary>
        public static bool operator !=(KeyVaultCertificateSourceType left, KeyVaultCertificateSourceType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KeyVaultCertificateSourceType"/>. </summary>
        public static implicit operator KeyVaultCertificateSourceType(string value) => new KeyVaultCertificateSourceType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyVaultCertificateSourceType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KeyVaultCertificateSourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}