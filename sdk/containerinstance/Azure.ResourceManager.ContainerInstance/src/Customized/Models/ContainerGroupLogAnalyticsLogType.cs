// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for LogAnalyticsLogType. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ContainerGroupLogAnalyticsLogType : IEquatable<ContainerGroupLogAnalyticsLogType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerGroupLogAnalyticsLogType"/>. </summary>
        /// <param name="value"> The string value. </param>
        public ContainerGroupLogAnalyticsLogType(string value) { _value = value; }

        /// <summary> ContainerInsights. </summary>
        public static ContainerGroupLogAnalyticsLogType ContainerInsights { get; } = new ContainerGroupLogAnalyticsLogType("ContainerInsights");
        /// <summary> ContainerInstanceLogs. </summary>
        public static ContainerGroupLogAnalyticsLogType ContainerInstanceLogs { get; } = new ContainerGroupLogAnalyticsLogType("ContainerInstanceLogs");

        /// <summary> Converts from <see cref="LogAnalyticsLogType"/>. </summary>
        public static implicit operator ContainerGroupLogAnalyticsLogType(LogAnalyticsLogType v) => new ContainerGroupLogAnalyticsLogType(v.ToString());
        /// <summary> Converts to <see cref="LogAnalyticsLogType"/>. </summary>
        public static implicit operator LogAnalyticsLogType(ContainerGroupLogAnalyticsLogType v) => new LogAnalyticsLogType(v._value);
        /// <summary> Converts from string. </summary>
        public static implicit operator ContainerGroupLogAnalyticsLogType(string value) => new ContainerGroupLogAnalyticsLogType(value);

        /// <summary> Determines equality. </summary>
        public static bool operator ==(ContainerGroupLogAnalyticsLogType left, ContainerGroupLogAnalyticsLogType right) => left.Equals(right);
        /// <summary> Determines inequality. </summary>
        public static bool operator !=(ContainerGroupLogAnalyticsLogType left, ContainerGroupLogAnalyticsLogType right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(ContainerGroupLogAnalyticsLogType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerGroupLogAnalyticsLogType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
