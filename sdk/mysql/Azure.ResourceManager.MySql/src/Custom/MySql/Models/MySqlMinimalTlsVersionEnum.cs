// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Enforce a minimal Tls version for the server. </summary>
    public readonly partial struct MySqlMinimalTlsVersionEnum : IEquatable<MySqlMinimalTlsVersionEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlMinimalTlsVersionEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlMinimalTlsVersionEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Tls1_0Value = "TLS1_0";
        private const string Tls1_1Value = "TLS1_1";
        private const string Tls1_2Value = "TLS1_2";
        private const string TLSEnforcementDisabledValue = "TLSEnforcementDisabled";
        /// <summary> TLS1_0. </summary>
        public static MySqlMinimalTlsVersionEnum Tls1_0 { get; } = new MySqlMinimalTlsVersionEnum(Tls1_0Value);
        /// <summary> TLS1_1. </summary>
        public static MySqlMinimalTlsVersionEnum Tls1_1 { get; } = new MySqlMinimalTlsVersionEnum(Tls1_1Value);
        /// <summary> TLS1_2. </summary>
        public static MySqlMinimalTlsVersionEnum Tls1_2 { get; } = new MySqlMinimalTlsVersionEnum(Tls1_2Value);
        /// <summary> TLSEnforcementDisabled. </summary>
        public static MySqlMinimalTlsVersionEnum TLSEnforcementDisabled { get; } = new MySqlMinimalTlsVersionEnum(TLSEnforcementDisabledValue);
        /// <summary> Determines if two <see cref="MySqlMinimalTlsVersionEnum"/> values are the same. </summary>
        public static bool operator ==(MySqlMinimalTlsVersionEnum left, MySqlMinimalTlsVersionEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlMinimalTlsVersionEnum"/> values are not the same. </summary>
        public static bool operator !=(MySqlMinimalTlsVersionEnum left, MySqlMinimalTlsVersionEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlMinimalTlsVersionEnum"/>. </summary>
        public static implicit operator MySqlMinimalTlsVersionEnum(string value) => new MySqlMinimalTlsVersionEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlMinimalTlsVersionEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlMinimalTlsVersionEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
