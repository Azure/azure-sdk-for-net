// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary>
    /// An enum describing the unit of usage measurement.
    /// This type is provided for backward compatibility — the new spec uses a string literal.
    /// </summary>
    public readonly partial struct ComputeUsageUnit : IEquatable<ComputeUsageUnit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ComputeUsageUnit"/>. </summary>
        /// <param name="value"> The value. </param>
        public ComputeUsageUnit(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        private const string CountValue = "Count";

        /// <summary> Count. </summary>
        public static ComputeUsageUnit Count { get; } = new(CountValue);

        /// <summary> Converts a string to a <see cref="ComputeUsageUnit"/>. </summary>
        public static implicit operator ComputeUsageUnit(string value) => new(value);

        /// <summary> Converts a <see cref="ComputeUsageUnit"/> to a string. </summary>
        public static implicit operator string(ComputeUsageUnit value) => value._value;

        /// <inheritdoc />
        public bool Equals(ComputeUsageUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ComputeUsageUnit other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
