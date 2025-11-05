// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The type of administrator. </summary>
    public readonly partial struct MySqlAdministratorType : IEquatable<MySqlAdministratorType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlAdministratorType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlAdministratorType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ActiveDirectoryValue = "ActiveDirectory";

        /// <summary> ActiveDirectory. </summary>
        public static MySqlAdministratorType ActiveDirectory { get; } = new MySqlAdministratorType(ActiveDirectoryValue);
        /// <summary> Determines if two <see cref="MySqlAdministratorType"/> values are the same. </summary>
        public static bool operator ==(MySqlAdministratorType left, MySqlAdministratorType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlAdministratorType"/> values are not the same. </summary>
        public static bool operator !=(MySqlAdministratorType left, MySqlAdministratorType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlAdministratorType"/>. </summary>
        public static implicit operator MySqlAdministratorType(string value) => new MySqlAdministratorType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlAdministratorType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlAdministratorType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}