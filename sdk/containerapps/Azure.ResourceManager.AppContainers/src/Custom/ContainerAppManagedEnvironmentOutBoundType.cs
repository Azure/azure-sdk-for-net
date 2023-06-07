// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> Outbound type for the cluster. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerAppManagedEnvironmentOutBoundType : IEquatable<ContainerAppManagedEnvironmentOutBoundType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerAppManagedEnvironmentOutBoundType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ContainerAppManagedEnvironmentOutBoundType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LoadBalancerValue = "LoadBalancer";
        private const string UserDefinedRoutingValue = "UserDefinedRouting";

        /// <summary> LoadBalancer. </summary>
        public static ContainerAppManagedEnvironmentOutBoundType LoadBalancer { get; } = new ContainerAppManagedEnvironmentOutBoundType(LoadBalancerValue);
        /// <summary> UserDefinedRouting. </summary>
        public static ContainerAppManagedEnvironmentOutBoundType UserDefinedRouting { get; } = new ContainerAppManagedEnvironmentOutBoundType(UserDefinedRoutingValue);
        /// <summary> Determines if two <see cref="ContainerAppManagedEnvironmentOutBoundType"/> values are the same. </summary>
        public static bool operator ==(ContainerAppManagedEnvironmentOutBoundType left, ContainerAppManagedEnvironmentOutBoundType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ContainerAppManagedEnvironmentOutBoundType"/> values are not the same. </summary>
        public static bool operator !=(ContainerAppManagedEnvironmentOutBoundType left, ContainerAppManagedEnvironmentOutBoundType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ContainerAppManagedEnvironmentOutBoundType"/>. </summary>
        public static implicit operator ContainerAppManagedEnvironmentOutBoundType(string value) => new ContainerAppManagedEnvironmentOutBoundType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContainerAppManagedEnvironmentOutBoundType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContainerAppManagedEnvironmentOutBoundType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
