// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // The service now models versions as strings; retain the published extensible enum for compatibility.
    /// <summary> Major version of PostgreSQL database engine. </summary>
    public readonly partial struct PostgreSqlFlexibleServerVersion : IEquatable<PostgreSqlFlexibleServerVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerVersion"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PostgreSqlFlexibleServerVersion(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> PostgreSQL 18. </summary>
        public static PostgreSqlFlexibleServerVersion Eighteen { get; } = new PostgreSqlFlexibleServerVersion("18");

        /// <summary> PostgreSQL 17. </summary>
        public static PostgreSqlFlexibleServerVersion Seventeen { get; } = new PostgreSqlFlexibleServerVersion("17");

        /// <summary> PostgreSQL 16. </summary>
        public static PostgreSqlFlexibleServerVersion Sixteen { get; } = new PostgreSqlFlexibleServerVersion("16");

        /// <summary> PostgreSQL 15. </summary>
        public static PostgreSqlFlexibleServerVersion Ver15 { get; } = new PostgreSqlFlexibleServerVersion("15");

        /// <summary> PostgreSQL 14. </summary>
        public static PostgreSqlFlexibleServerVersion Ver14 { get; } = new PostgreSqlFlexibleServerVersion("14");

        /// <summary> PostgreSQL 13. </summary>
        public static PostgreSqlFlexibleServerVersion Ver13 { get; } = new PostgreSqlFlexibleServerVersion("13");

        /// <summary> PostgreSQL 12. </summary>
        public static PostgreSqlFlexibleServerVersion Ver12 { get; } = new PostgreSqlFlexibleServerVersion("12");

        /// <summary> PostgreSQL 11. </summary>
        public static PostgreSqlFlexibleServerVersion Ver11 { get; } = new PostgreSqlFlexibleServerVersion("11");

        /// <summary> Determines if two <see cref="PostgreSqlFlexibleServerVersion"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(PostgreSqlFlexibleServerVersion left, PostgreSqlFlexibleServerVersion right) => left.Equals(right);

        /// <summary> Determines if two <see cref="PostgreSqlFlexibleServerVersion"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(PostgreSqlFlexibleServerVersion left, PostgreSqlFlexibleServerVersion right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="PostgreSqlFlexibleServerVersion"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator PostgreSqlFlexibleServerVersion(string value) => new PostgreSqlFlexibleServerVersion(value);

        /// <summary> Converts a string to a <see cref="PostgreSqlFlexibleServerVersion"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator PostgreSqlFlexibleServerVersion?(string value) => value == null ? (PostgreSqlFlexibleServerVersion?)null : new PostgreSqlFlexibleServerVersion(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PostgreSqlFlexibleServerVersion other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(PostgreSqlFlexibleServerVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
