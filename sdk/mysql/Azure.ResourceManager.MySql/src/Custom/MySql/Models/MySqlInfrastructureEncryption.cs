// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Add a second layer of encryption for your data using new encryption algorithm which gives additional data protection. Value is optional but if passed in, must be 'Disabled' or 'Enabled'. </summary>
    public readonly partial struct MySqlInfrastructureEncryption : IEquatable<MySqlInfrastructureEncryption>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlInfrastructureEncryption"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlInfrastructureEncryption(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "Enabled";
        private const string DisabledValue = "Disabled";

        /// <summary> Default value for single layer of encryption for data at rest. </summary>
        public static MySqlInfrastructureEncryption Enabled { get; } = new MySqlInfrastructureEncryption(EnabledValue);
        /// <summary> Additional (2nd) layer of encryption for data at rest. </summary>
        public static MySqlInfrastructureEncryption Disabled { get; } = new MySqlInfrastructureEncryption(DisabledValue);
        /// <summary> Determines if two <see cref="MySqlInfrastructureEncryption"/> values are the same. </summary>
        public static bool operator ==(MySqlInfrastructureEncryption left, MySqlInfrastructureEncryption right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlInfrastructureEncryption"/> values are not the same. </summary>
        public static bool operator !=(MySqlInfrastructureEncryption left, MySqlInfrastructureEncryption right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlInfrastructureEncryption"/>. </summary>
        public static implicit operator MySqlInfrastructureEncryption(string value) => new MySqlInfrastructureEncryption(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlInfrastructureEncryption other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlInfrastructureEncryption other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}