// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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

        /// <summary> Converts from <see cref="OperatingSystemTypes"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        public static implicit operator ContainerInstanceOperatingSystemType(OperatingSystemTypes osType)
            => new ContainerInstanceOperatingSystemType(osType.ToString());

        /// <summary> Converts to <see cref="OperatingSystemTypes"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        public static implicit operator OperatingSystemTypes(ContainerInstanceOperatingSystemType osType)
            => new OperatingSystemTypes(osType._value);

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
