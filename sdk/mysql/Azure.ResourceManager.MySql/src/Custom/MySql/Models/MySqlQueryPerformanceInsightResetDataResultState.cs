// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Indicates result of the operation. </summary>
    public readonly partial struct MySqlQueryPerformanceInsightResetDataResultState : IEquatable<MySqlQueryPerformanceInsightResetDataResultState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlQueryPerformanceInsightResetDataResultState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlQueryPerformanceInsightResetDataResultState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";

        /// <summary> Succeeded. </summary>
        public static MySqlQueryPerformanceInsightResetDataResultState Succeeded { get; } = new MySqlQueryPerformanceInsightResetDataResultState(SucceededValue);
        /// <summary> Failed. </summary>
        public static MySqlQueryPerformanceInsightResetDataResultState Failed { get; } = new MySqlQueryPerformanceInsightResetDataResultState(FailedValue);
        /// <summary> Determines if two <see cref="MySqlQueryPerformanceInsightResetDataResultState"/> values are the same. </summary>
        public static bool operator ==(MySqlQueryPerformanceInsightResetDataResultState left, MySqlQueryPerformanceInsightResetDataResultState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlQueryPerformanceInsightResetDataResultState"/> values are not the same. </summary>
        public static bool operator !=(MySqlQueryPerformanceInsightResetDataResultState left, MySqlQueryPerformanceInsightResetDataResultState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlQueryPerformanceInsightResetDataResultState"/>. </summary>
        public static implicit operator MySqlQueryPerformanceInsightResetDataResultState(string value) => new MySqlQueryPerformanceInsightResetDataResultState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlQueryPerformanceInsightResetDataResultState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlQueryPerformanceInsightResetDataResultState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}