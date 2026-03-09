// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> The reason why the given name is not available. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct PostgreSqlFlexibleServerNameUnavailableReason : IEquatable<PostgreSqlFlexibleServerNameUnavailableReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerNameUnavailableReason"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PostgreSqlFlexibleServerNameUnavailableReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidValue = "Invalid";
        private const string AlreadyExistsValue = "AlreadyExists";

        /// <summary> Invalid. </summary>
        public static PostgreSqlFlexibleServerNameUnavailableReason Invalid { get; } = new PostgreSqlFlexibleServerNameUnavailableReason(InvalidValue);
        /// <summary> AlreadyExists. </summary>
        public static PostgreSqlFlexibleServerNameUnavailableReason AlreadyExists { get; } = new PostgreSqlFlexibleServerNameUnavailableReason(AlreadyExistsValue);

        /// <summary> Converts from CheckNameAvailabilityReason. </summary>
        internal static PostgreSqlFlexibleServerNameUnavailableReason? FromCheckNameAvailabilityReason(CheckNameAvailabilityReason? reason)
        {
            if (reason == null) return null;
            return new PostgreSqlFlexibleServerNameUnavailableReason(reason.Value.ToString());
        }

        /// <inheritdoc />
        public static implicit operator PostgreSqlFlexibleServerNameUnavailableReason(string value) => new PostgreSqlFlexibleServerNameUnavailableReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PostgreSqlFlexibleServerNameUnavailableReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PostgreSqlFlexibleServerNameUnavailableReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(PostgreSqlFlexibleServerNameUnavailableReason left, PostgreSqlFlexibleServerNameUnavailableReason right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(PostgreSqlFlexibleServerNameUnavailableReason left, PostgreSqlFlexibleServerNameUnavailableReason right) => !left.Equals(right);
    }
}
