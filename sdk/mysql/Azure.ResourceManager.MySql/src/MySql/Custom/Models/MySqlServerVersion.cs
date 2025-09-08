// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct MySqlServerVersion : IEquatable<MySqlServerVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlServerVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlServerVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Ver5_6Value = "5.6";
        private const string Ver5_7Value = "5.7";
        private const string Ver8_0Value = "8.0";
        /// <summary> 5.6. </summary>
        public static MySqlServerVersion Ver5_6 { get; } = new MySqlServerVersion(Ver5_6Value);
        /// <summary> 5.7. </summary>
        public static MySqlServerVersion Ver5_7 { get; } = new MySqlServerVersion(Ver5_7Value);
        /// <summary> 8.0. </summary>
        public static MySqlServerVersion Ver8_0 { get; } = new MySqlServerVersion(Ver8_0Value);
        /// <summary> Determines if two <see cref="MySqlServerVersion"/> values are the same. </summary>
        public static bool operator ==(MySqlServerVersion left, MySqlServerVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlServerVersion"/> values are not the same. </summary>
        public static bool operator !=(MySqlServerVersion left, MySqlServerVersion right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlServerVersion"/>. </summary>
        public static implicit operator MySqlServerVersion(string value) => new MySqlServerVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlServerVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlServerVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
