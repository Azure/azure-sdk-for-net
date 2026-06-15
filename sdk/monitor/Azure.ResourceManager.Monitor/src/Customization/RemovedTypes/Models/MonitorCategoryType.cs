// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> The type of diagnostic settings category. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public readonly partial struct MonitorCategoryType : IEquatable<MonitorCategoryType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MonitorCategoryType"/>. </summary>
        /// <param name="value"> The string value of the instance. </param>
        public MonitorCategoryType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Logs. </summary>
        public static MonitorCategoryType Logs { get; } = new MonitorCategoryType("Logs");

        /// <summary> Metrics. </summary>
        public static MonitorCategoryType Metrics { get; } = new MonitorCategoryType("Metrics");

        /// <inheritdoc/>
        public bool Equals(MonitorCategoryType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is MonitorCategoryType other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Converts a string to a <see cref="MonitorCategoryType"/>. </summary>
        /// <param name="value"> The string value. </param>
        public static implicit operator MonitorCategoryType(string value) => new MonitorCategoryType(value);

        /// <summary> Compares two <see cref="MonitorCategoryType"/> values for equality. </summary>
        public static bool operator ==(MonitorCategoryType left, MonitorCategoryType right) => left.Equals(right);

        /// <summary> Compares two <see cref="MonitorCategoryType"/> values for inequality. </summary>
        public static bool operator !=(MonitorCategoryType left, MonitorCategoryType right) => !left.Equals(right);
    }
}