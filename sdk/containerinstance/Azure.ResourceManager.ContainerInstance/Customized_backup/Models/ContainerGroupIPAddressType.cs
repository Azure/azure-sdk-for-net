// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ContainerGroupIpAddressType. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ContainerGroupIPAddressType : IEquatable<ContainerGroupIPAddressType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerGroupIPAddressType"/>. </summary>
        /// <param name="value"> The string value. </param>
        public ContainerGroupIPAddressType(string value) { _value = value; }

        /// <summary> Public. </summary>
        public static ContainerGroupIPAddressType Public { get; } = new ContainerGroupIPAddressType("Public");
        /// <summary> Private. </summary>
        public static ContainerGroupIPAddressType Private { get; } = new ContainerGroupIPAddressType("Private");

        /// <summary> Converts from <see cref="ContainerGroupIpAddressType"/>. </summary>
        public static implicit operator ContainerGroupIPAddressType(ContainerGroupIpAddressType v) => new ContainerGroupIPAddressType(v.ToString());
        /// <summary> Converts to <see cref="ContainerGroupIpAddressType"/>. </summary>
        public static implicit operator ContainerGroupIpAddressType(ContainerGroupIPAddressType v) => new ContainerGroupIpAddressType(v._value);
        /// <summary> Converts from string. </summary>
        public static implicit operator ContainerGroupIPAddressType(string value) => new ContainerGroupIPAddressType(value);

        /// <summary> Determines equality. </summary>
        public static bool operator ==(ContainerGroupIPAddressType left, ContainerGroupIPAddressType right) => left.Equals(right);
        /// <summary> Determines inequality. </summary>
        public static bool operator !=(ContainerGroupIPAddressType left, ContainerGroupIPAddressType right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(ContainerGroupIPAddressType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerGroupIPAddressType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
