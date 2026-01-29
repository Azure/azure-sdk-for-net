// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The MySqlSecurityAlertPolicyName. </summary>
    public readonly partial struct MySqlSecurityAlertPolicyName : IEquatable<MySqlSecurityAlertPolicyName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlSecurityAlertPolicyName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlSecurityAlertPolicyName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "Default";

        /// <summary> Default. </summary>
        public static MySqlSecurityAlertPolicyName Default { get; } = new MySqlSecurityAlertPolicyName(DefaultValue);
        /// <summary> Determines if two <see cref="MySqlSecurityAlertPolicyName"/> values are the same. </summary>
        public static bool operator ==(MySqlSecurityAlertPolicyName left, MySqlSecurityAlertPolicyName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlSecurityAlertPolicyName"/> values are not the same. </summary>
        public static bool operator !=(MySqlSecurityAlertPolicyName left, MySqlSecurityAlertPolicyName right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlSecurityAlertPolicyName"/>. </summary>
        public static implicit operator MySqlSecurityAlertPolicyName(string value) => new MySqlSecurityAlertPolicyName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlSecurityAlertPolicyName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlSecurityAlertPolicyName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}