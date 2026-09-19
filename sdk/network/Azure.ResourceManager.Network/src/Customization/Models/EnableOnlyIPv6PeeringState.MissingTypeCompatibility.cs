// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The state of IPv6 peering. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and is no longer supported by the service.")]
    public readonly partial struct EnableOnlyIPv6PeeringState : IEquatable<EnableOnlyIPv6PeeringState>
    {
        private readonly string _value;
        private const string EnabledValue = "Enabled";
        private const string DisabledValue = "Disabled";

        /// <summary> Initializes a new instance of <see cref="EnableOnlyIPv6PeeringState"/>. </summary>
        /// <param name="value"> The value. </param>
        public EnableOnlyIPv6PeeringState(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> IPv6 peering is enabled. </summary>
        public static EnableOnlyIPv6PeeringState Enabled { get; } = new EnableOnlyIPv6PeeringState(EnabledValue);

        /// <summary> IPv6 peering is disabled. </summary>
        public static EnableOnlyIPv6PeeringState Disabled { get; } = new EnableOnlyIPv6PeeringState(DisabledValue);

        /// <inheritdoc/>
        public bool Equals(EnableOnlyIPv6PeeringState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EnableOnlyIPv6PeeringState other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <summary> Determines if two <see cref="EnableOnlyIPv6PeeringState"/> values are the same. </summary>
        public static bool operator ==(EnableOnlyIPv6PeeringState left, EnableOnlyIPv6PeeringState right) => left.Equals(right);

        /// <summary> Determines if two <see cref="EnableOnlyIPv6PeeringState"/> values are not the same. </summary>
        public static bool operator !=(EnableOnlyIPv6PeeringState left, EnableOnlyIPv6PeeringState right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="EnableOnlyIPv6PeeringState"/>. </summary>
        public static implicit operator EnableOnlyIPv6PeeringState(string value) => new EnableOnlyIPv6PeeringState(value);

        /// <summary> Converts a string to a nullable <see cref="EnableOnlyIPv6PeeringState"/>. </summary>
        public static implicit operator EnableOnlyIPv6PeeringState?(string value) => value == null ? null : new EnableOnlyIPv6PeeringState(value);

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
