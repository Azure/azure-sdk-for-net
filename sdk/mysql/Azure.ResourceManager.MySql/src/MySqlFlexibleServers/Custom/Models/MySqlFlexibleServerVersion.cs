// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("MySqlFlexibleServerVersion")]
namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct MySqlFlexibleServerVersion : IEquatable<MySqlFlexibleServerVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlFlexibleServerVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlFlexibleServerVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
#pragma warning disable CA1707
        private const string Ver5_7Value = "5.7";
        private const string Ver8_0_21Value = "8.0.21";

        /// <summary> 5.7. </summary>
        public static MySqlFlexibleServerVersion Ver5_7 { get; } = new MySqlFlexibleServerVersion(Ver5_7Value);
        /// <summary> 8.0.21. </summary>
        public static MySqlFlexibleServerVersion Ver8_0_21 { get; } = new MySqlFlexibleServerVersion(Ver8_0_21Value);
#pragma warning restore CA1707
        /// <summary> Determines if two <see cref="MySqlFlexibleServerVersion"/> values are the same. </summary>
        public static bool operator ==(MySqlFlexibleServerVersion left, MySqlFlexibleServerVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlFlexibleServerVersion"/> values are not the same. </summary>
        public static bool operator !=(MySqlFlexibleServerVersion left, MySqlFlexibleServerVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MySqlFlexibleServerVersion"/>. </summary>
        public static implicit operator MySqlFlexibleServerVersion(string value) => new MySqlFlexibleServerVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlFlexibleServerVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlFlexibleServerVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
