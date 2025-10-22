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
    public readonly partial struct SqlMetricUnitType : IEquatable<SqlMetricUnitType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SqlMetricUnitType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SqlMetricUnitType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CountValue = "count";
        private const string BytesValue = "bytes";
        private const string SecondsValue = "seconds";
        private const string PercentValue = "percent";
        private const string CountPerSecondValue = "countPerSecond";
        private const string BytesPerSecondValue = "bytesPerSecond";

        /// <summary> count. </summary>
        public static SqlMetricUnitType Count { get; } = new SqlMetricUnitType(CountValue);
        /// <summary> bytes. </summary>
        public static SqlMetricUnitType Bytes { get; } = new SqlMetricUnitType(BytesValue);
        /// <summary> seconds. </summary>
        public static SqlMetricUnitType Seconds { get; } = new SqlMetricUnitType(SecondsValue);
        /// <summary> percent. </summary>
        public static SqlMetricUnitType Percent { get; } = new SqlMetricUnitType(PercentValue);
        /// <summary> countPerSecond. </summary>
        public static SqlMetricUnitType CountPerSecond { get; } = new SqlMetricUnitType(CountPerSecondValue);
        /// <summary> bytesPerSecond. </summary>
        public static SqlMetricUnitType BytesPerSecond { get; } = new SqlMetricUnitType(BytesPerSecondValue);
        /// <summary> Determines if two <see cref="SqlMetricUnitType"/> values are the same. </summary>
        public static bool operator ==(SqlMetricUnitType left, SqlMetricUnitType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SqlMetricUnitType"/> values are not the same. </summary>
        public static bool operator !=(SqlMetricUnitType left, SqlMetricUnitType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SqlMetricUnitType"/>. </summary>
        public static implicit operator SqlMetricUnitType(string value) => new SqlMetricUnitType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SqlMetricUnitType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SqlMetricUnitType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
