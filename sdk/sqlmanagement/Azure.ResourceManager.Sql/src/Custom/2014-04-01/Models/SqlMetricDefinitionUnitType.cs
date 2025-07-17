// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> The unit of the metric. </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SqlMetricDefinitionUnitType : IEquatable<SqlMetricDefinitionUnitType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SqlMetricDefinitionUnitType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SqlMetricDefinitionUnitType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CountValue = "Count";
        private const string BytesValue = "Bytes";
        private const string SecondsValue = "Seconds";
        private const string PercentValue = "Percent";
        private const string CountPerSecondValue = "CountPerSecond";
        private const string BytesPerSecondValue = "BytesPerSecond";

        /// <summary> Count. </summary>
        public static SqlMetricDefinitionUnitType Count { get; } = new SqlMetricDefinitionUnitType(CountValue);
        /// <summary> Bytes. </summary>
        public static SqlMetricDefinitionUnitType Bytes { get; } = new SqlMetricDefinitionUnitType(BytesValue);
        /// <summary> Seconds. </summary>
        public static SqlMetricDefinitionUnitType Seconds { get; } = new SqlMetricDefinitionUnitType(SecondsValue);
        /// <summary> Percent. </summary>
        public static SqlMetricDefinitionUnitType Percent { get; } = new SqlMetricDefinitionUnitType(PercentValue);
        /// <summary> CountPerSecond. </summary>
        public static SqlMetricDefinitionUnitType CountPerSecond { get; } = new SqlMetricDefinitionUnitType(CountPerSecondValue);
        /// <summary> BytesPerSecond. </summary>
        public static SqlMetricDefinitionUnitType BytesPerSecond { get; } = new SqlMetricDefinitionUnitType(BytesPerSecondValue);
        /// <summary> Determines if two <see cref="SqlMetricDefinitionUnitType"/> values are the same. </summary>
        public static bool operator ==(SqlMetricDefinitionUnitType left, SqlMetricDefinitionUnitType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SqlMetricDefinitionUnitType"/> values are not the same. </summary>
        public static bool operator !=(SqlMetricDefinitionUnitType left, SqlMetricDefinitionUnitType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SqlMetricDefinitionUnitType"/>. </summary>
        public static implicit operator SqlMetricDefinitionUnitType(string value) => new SqlMetricDefinitionUnitType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SqlMetricDefinitionUnitType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SqlMetricDefinitionUnitType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
