// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    // Compatibility declaration preserving the extensible enum type referenced
    // by back-compat overloads in ArmNetworkModelFactory. The current API version
    // exposes enableOnlyIPv6Peering as a bool; this type retains the previously
    // shipped struct so existing callers continue to compile.
    /// <summary> Enable Only IPv6 Peering state. </summary>
    public readonly partial struct EnableOnlyIPv6PeeringState : IEquatable<EnableOnlyIPv6PeeringState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EnableOnlyIPv6PeeringState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EnableOnlyIPv6PeeringState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DisabledValue = "Disabled";
        private const string EnabledValue = "Enabled";

        /// <summary> Disabled. </summary>
        public static EnableOnlyIPv6PeeringState Disabled { get; } = new EnableOnlyIPv6PeeringState(DisabledValue);
        /// <summary> Enabled. </summary>
        public static EnableOnlyIPv6PeeringState Enabled { get; } = new EnableOnlyIPv6PeeringState(EnabledValue);

        /// <summary> Determines if two <see cref="EnableOnlyIPv6PeeringState"/> values are the same. </summary>
        public static bool operator ==(EnableOnlyIPv6PeeringState left, EnableOnlyIPv6PeeringState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EnableOnlyIPv6PeeringState"/> values are not the same. </summary>
        public static bool operator !=(EnableOnlyIPv6PeeringState left, EnableOnlyIPv6PeeringState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="EnableOnlyIPv6PeeringState"/>. </summary>
        public static implicit operator EnableOnlyIPv6PeeringState(string value) => new EnableOnlyIPv6PeeringState(value);
        /// <summary> Converts a <see cref="string"/> to a <see cref="EnableOnlyIPv6PeeringState"/>. </summary>
        public static implicit operator EnableOnlyIPv6PeeringState?(string value) => value == null ? null : (EnableOnlyIPv6PeeringState?)new EnableOnlyIPv6PeeringState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EnableOnlyIPv6PeeringState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EnableOnlyIPv6PeeringState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
