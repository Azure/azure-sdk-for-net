// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.IotOperations.Models
{
    /// <summary> CertManagerIssuerKind properties. </summary>
    public readonly partial struct CertManagerIssuerKind : IEquatable<CertManagerIssuerKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CertManagerIssuerKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CertManagerIssuerKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string IssuerValue = "Issuer";
        private const string ClusterIssuerValue = "ClusterIssuer";

        /// <summary> Issuer kind. </summary>
        public static CertManagerIssuerKind Issuer { get; } = new CertManagerIssuerKind(IssuerValue);
        /// <summary> ClusterIssuer kind. </summary>
        public static CertManagerIssuerKind ClusterIssuer { get; } = new CertManagerIssuerKind(ClusterIssuerValue);
        /// <summary> Determines if two <see cref="CertManagerIssuerKind"/> values are the same. </summary>
        public static bool operator ==(CertManagerIssuerKind left, CertManagerIssuerKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CertManagerIssuerKind"/> values are not the same. </summary>
        public static bool operator !=(CertManagerIssuerKind left, CertManagerIssuerKind right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CertManagerIssuerKind"/>. </summary>
        public static implicit operator CertManagerIssuerKind(string value) => new CertManagerIssuerKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertManagerIssuerKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CertManagerIssuerKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
