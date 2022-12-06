// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("PostgreSqlServerVersion")]
namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> The version of a server. </summary>
    public readonly partial struct PostgreSqlServerVersion : IEquatable<PostgreSqlServerVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PostgreSqlServerVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PostgreSqlServerVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
#pragma warning disable CA1707
        private const string Ver9_5Value = "9.5";
        private const string Ver9_6Value = "9.6";
        private const string Ver10Value = "10";
        private const string Ver10_0Value = "10.0";
        private const string Ver10_2Value = "10.2";
        private const string Ver11Value = "11";

        /// <summary> 9.5. </summary>
        public static PostgreSqlServerVersion Ver9_5 { get; } = new PostgreSqlServerVersion(Ver9_5Value);
        /// <summary> 9.6. </summary>
        public static PostgreSqlServerVersion Ver9_6 { get; } = new PostgreSqlServerVersion(Ver9_6Value);
        /// <summary> 10. </summary>
        public static PostgreSqlServerVersion Ver10 { get; } = new PostgreSqlServerVersion(Ver10Value);
        /// <summary> 10.0. </summary>
        public static PostgreSqlServerVersion Ver10_0 { get; } = new PostgreSqlServerVersion(Ver10_0Value);
        /// <summary> 10.2. </summary>
        public static PostgreSqlServerVersion Ver10_2 { get; } = new PostgreSqlServerVersion(Ver10_2Value);
        /// <summary> 11. </summary>
        public static PostgreSqlServerVersion Ver11 { get; } = new PostgreSqlServerVersion(Ver11Value);
#pragma warning restore CA1707
        /// <summary> Determines if two <see cref="PostgreSqlServerVersion"/> values are the same. </summary>
        public static bool operator ==(PostgreSqlServerVersion left, PostgreSqlServerVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PostgreSqlServerVersion"/> values are not the same. </summary>
        public static bool operator !=(PostgreSqlServerVersion left, PostgreSqlServerVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PostgreSqlServerVersion"/>. </summary>
        public static implicit operator PostgreSqlServerVersion(string value) => new PostgreSqlServerVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PostgreSqlServerVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PostgreSqlServerVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
