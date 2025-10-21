// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> The primary aggregation type defining how metric values are displayed. </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SqlMetricPrimaryAggregationType : IEquatable<SqlMetricPrimaryAggregationType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SqlMetricPrimaryAggregationType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SqlMetricPrimaryAggregationType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string AverageValue = "Average";
        private const string CountValue = "Count";
        private const string MinimumValue = "Minimum";
        private const string MaximumValue = "Maximum";
        private const string TotalValue = "Total";

        /// <summary> None. </summary>
        public static SqlMetricPrimaryAggregationType None { get; } = new SqlMetricPrimaryAggregationType(NoneValue);
        /// <summary> Average. </summary>
        public static SqlMetricPrimaryAggregationType Average { get; } = new SqlMetricPrimaryAggregationType(AverageValue);
        /// <summary> Count. </summary>
        public static SqlMetricPrimaryAggregationType Count { get; } = new SqlMetricPrimaryAggregationType(CountValue);
        /// <summary> Minimum. </summary>
        public static SqlMetricPrimaryAggregationType Minimum { get; } = new SqlMetricPrimaryAggregationType(MinimumValue);
        /// <summary> Maximum. </summary>
        public static SqlMetricPrimaryAggregationType Maximum { get; } = new SqlMetricPrimaryAggregationType(MaximumValue);
        /// <summary> Total. </summary>
        public static SqlMetricPrimaryAggregationType Total { get; } = new SqlMetricPrimaryAggregationType(TotalValue);
        /// <summary> Determines if two <see cref="SqlMetricPrimaryAggregationType"/> values are the same. </summary>
        public static bool operator ==(SqlMetricPrimaryAggregationType left, SqlMetricPrimaryAggregationType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SqlMetricPrimaryAggregationType"/> values are not the same. </summary>
        public static bool operator !=(SqlMetricPrimaryAggregationType left, SqlMetricPrimaryAggregationType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SqlMetricPrimaryAggregationType"/>. </summary>
        public static implicit operator SqlMetricPrimaryAggregationType(string value) => new SqlMetricPrimaryAggregationType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SqlMetricPrimaryAggregationType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SqlMetricPrimaryAggregationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
