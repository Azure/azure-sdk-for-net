// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> The WorkloadNetworkName. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct WorkloadNetworkName : IEquatable<WorkloadNetworkName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="WorkloadNetworkName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public WorkloadNetworkName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }
        private const string DefaultValue = "default";

        /// <summary> default. </summary>
        public static WorkloadNetworkName Default { get; } = new WorkloadNetworkName(DefaultValue);
        /// <summary> Determines if two <see cref="WorkloadNetworkName"/> values are the same. </summary>
        public static bool operator ==(WorkloadNetworkName left, WorkloadNetworkName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="WorkloadNetworkName"/> values are not the same. </summary>
        public static bool operator !=(WorkloadNetworkName left, WorkloadNetworkName right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="WorkloadNetworkName"/>. </summary>
        public static implicit operator WorkloadNetworkName(string value) => new WorkloadNetworkName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is WorkloadNetworkName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(WorkloadNetworkName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
