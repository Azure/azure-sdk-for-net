// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for OperatingSystemTypes. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ContainerInstanceOperatingSystemType : IEquatable<ContainerInstanceOperatingSystemType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerInstanceOperatingSystemType"/>. </summary>
        /// <param name="value"> The string value. </param>
        public ContainerInstanceOperatingSystemType(string value)
        {
            _value = value;
        }

        /// <summary> Linux. </summary>
        public static ContainerInstanceOperatingSystemType Linux { get; } = new ContainerInstanceOperatingSystemType("Linux");
        /// <summary> Windows. </summary>
        public static ContainerInstanceOperatingSystemType Windows { get; } = new ContainerInstanceOperatingSystemType("Windows");

        /// <summary> Converts from <see cref="OperatingSystemTypes"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        public static implicit operator ContainerInstanceOperatingSystemType(OperatingSystemTypes osType)
            => new ContainerInstanceOperatingSystemType(osType.ToString());

        /// <summary> Converts to <see cref="OperatingSystemTypes"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        public static implicit operator OperatingSystemTypes(ContainerInstanceOperatingSystemType osType)
            => new OperatingSystemTypes(osType._value);

        /// <summary> Converts from string. </summary>
        public static implicit operator ContainerInstanceOperatingSystemType(string value) => new ContainerInstanceOperatingSystemType(value);

        /// <summary> Determines equality. </summary>
        public static bool operator ==(ContainerInstanceOperatingSystemType left, ContainerInstanceOperatingSystemType right) => left.Equals(right);
        /// <summary> Determines inequality. </summary>
        public static bool operator !=(ContainerInstanceOperatingSystemType left, ContainerInstanceOperatingSystemType right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(ContainerInstanceOperatingSystemType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerInstanceOperatingSystemType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
