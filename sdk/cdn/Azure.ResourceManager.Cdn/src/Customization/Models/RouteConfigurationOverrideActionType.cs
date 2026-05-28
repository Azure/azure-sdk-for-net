// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RouteConfigurationOverrideActionType. </summary>
    public readonly partial struct RouteConfigurationOverrideActionType : IEquatable<RouteConfigurationOverrideActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RouteConfigurationOverrideActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RouteConfigurationOverrideActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RouteConfigurationOverrideActionValue = "DeliveryRuleRouteConfigurationOverrideActionParameters";

        /// <summary> DeliveryRuleRouteConfigurationOverrideActionParameters. </summary>
        public static RouteConfigurationOverrideActionType RouteConfigurationOverrideAction { get; } = new RouteConfigurationOverrideActionType(RouteConfigurationOverrideActionValue);
        /// <summary> Determines if two <see cref="RouteConfigurationOverrideActionType"/> values are the same. </summary>
        public static bool operator ==(RouteConfigurationOverrideActionType left, RouteConfigurationOverrideActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RouteConfigurationOverrideActionType"/> values are not the same. </summary>
        public static bool operator !=(RouteConfigurationOverrideActionType left, RouteConfigurationOverrideActionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RouteConfigurationOverrideActionType"/>. </summary>
        public static implicit operator RouteConfigurationOverrideActionType(string value) => new RouteConfigurationOverrideActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RouteConfigurationOverrideActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RouteConfigurationOverrideActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}