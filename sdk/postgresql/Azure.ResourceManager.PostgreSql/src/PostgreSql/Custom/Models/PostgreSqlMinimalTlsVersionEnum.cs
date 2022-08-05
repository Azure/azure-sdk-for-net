// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("PostgreSqlMinimalTlsVersionEnum")]
namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> Enforce a minimal Tls version for the server. </summary>
    public readonly partial struct PostgreSqlMinimalTlsVersionEnum : IEquatable<PostgreSqlMinimalTlsVersionEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PostgreSqlMinimalTlsVersionEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PostgreSqlMinimalTlsVersionEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
#pragma warning disable CA1707
        private const string Tls1_0Value = "TLS1_0";
        private const string Tls1_1Value = "TLS1_1";
        private const string Tls1_2Value = "TLS1_2";
        private const string TLSEnforcementDisabledValue = "TLSEnforcementDisabled";

        /// <summary> TLS1_0. </summary>
        public static PostgreSqlMinimalTlsVersionEnum Tls1_0 { get; } = new PostgreSqlMinimalTlsVersionEnum(Tls1_0Value);
        /// <summary> TLS1_1. </summary>
        public static PostgreSqlMinimalTlsVersionEnum Tls1_1 { get; } = new PostgreSqlMinimalTlsVersionEnum(Tls1_1Value);
        /// <summary> TLS1_2. </summary>
        public static PostgreSqlMinimalTlsVersionEnum Tls1_2 { get; } = new PostgreSqlMinimalTlsVersionEnum(Tls1_2Value);
#pragma warning restore CA1707
        /// <summary> TLSEnforcementDisabled. </summary>
        public static PostgreSqlMinimalTlsVersionEnum TLSEnforcementDisabled { get; } = new PostgreSqlMinimalTlsVersionEnum(TLSEnforcementDisabledValue);
        /// <summary> Determines if two <see cref="PostgreSqlMinimalTlsVersionEnum"/> values are the same. </summary>
        public static bool operator ==(PostgreSqlMinimalTlsVersionEnum left, PostgreSqlMinimalTlsVersionEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PostgreSqlMinimalTlsVersionEnum"/> values are not the same. </summary>
        public static bool operator !=(PostgreSqlMinimalTlsVersionEnum left, PostgreSqlMinimalTlsVersionEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PostgreSqlMinimalTlsVersionEnum"/>. </summary>
        public static implicit operator PostgreSqlMinimalTlsVersionEnum(string value) => new PostgreSqlMinimalTlsVersionEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PostgreSqlMinimalTlsVersionEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PostgreSqlMinimalTlsVersionEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
