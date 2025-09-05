// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The CdnCertificateSourceType. </summary>
    public readonly partial struct CdnCertificateSourceType : IEquatable<CdnCertificateSourceType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CdnCertificateSourceType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CdnCertificateSourceType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CdnCertificateSourceValue = "CdnCertificateSourceParameters";

        /// <summary> CdnCertificateSourceParameters. </summary>
        public static CdnCertificateSourceType CdnCertificateSource { get; } = new CdnCertificateSourceType(CdnCertificateSourceValue);
        /// <summary> Determines if two <see cref="CdnCertificateSourceType"/> values are the same. </summary>
        public static bool operator ==(CdnCertificateSourceType left, CdnCertificateSourceType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CdnCertificateSourceType"/> values are not the same. </summary>
        public static bool operator !=(CdnCertificateSourceType left, CdnCertificateSourceType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CdnCertificateSourceType"/>. </summary>
        public static implicit operator CdnCertificateSourceType(string value) => new CdnCertificateSourceType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CdnCertificateSourceType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CdnCertificateSourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}