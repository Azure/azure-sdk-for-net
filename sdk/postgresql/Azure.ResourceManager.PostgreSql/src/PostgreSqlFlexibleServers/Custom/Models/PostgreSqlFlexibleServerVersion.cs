// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("PostgreSqlFlexibleServerVersion")]
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct PostgreSqlFlexibleServerVersion : IEquatable<PostgreSqlFlexibleServerVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PostgreSqlFlexibleServerVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Ver14Value = "14";
        private const string Ver13Value = "13";
        private const string Ver12Value = "12";
        private const string Ver11Value = "11";

        /// <summary> 14. </summary>
        public static PostgreSqlFlexibleServerVersion Ver14 { get; } = new PostgreSqlFlexibleServerVersion(Ver14Value);
        /// <summary> 13. </summary>
        public static PostgreSqlFlexibleServerVersion Ver13 { get; } = new PostgreSqlFlexibleServerVersion(Ver13Value);
        /// <summary> 12. </summary>
        public static PostgreSqlFlexibleServerVersion Ver12 { get; } = new PostgreSqlFlexibleServerVersion(Ver12Value);
        /// <summary> 11. </summary>
        public static PostgreSqlFlexibleServerVersion Ver11 { get; } = new PostgreSqlFlexibleServerVersion(Ver11Value);
        /// <summary> Determines if two <see cref="PostgreSqlFlexibleServerVersion"/> values are the same. </summary>
        public static bool operator ==(PostgreSqlFlexibleServerVersion left, PostgreSqlFlexibleServerVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PostgreSqlFlexibleServerVersion"/> values are not the same. </summary>
        public static bool operator !=(PostgreSqlFlexibleServerVersion left, PostgreSqlFlexibleServerVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PostgreSqlFlexibleServerVersion"/>. </summary>
        public static implicit operator PostgreSqlFlexibleServerVersion(string value) => new PostgreSqlFlexibleServerVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PostgreSqlFlexibleServerVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PostgreSqlFlexibleServerVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
