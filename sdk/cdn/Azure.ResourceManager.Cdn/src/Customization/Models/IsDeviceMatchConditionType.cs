// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The IsDeviceMatchConditionType. </summary>
    public readonly partial struct IsDeviceMatchConditionType : IEquatable<IsDeviceMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="IsDeviceMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public IsDeviceMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string IsDeviceConditionValue = "DeliveryRuleIsDeviceConditionParameters";

        /// <summary> DeliveryRuleIsDeviceConditionParameters. </summary>
        public static IsDeviceMatchConditionType IsDeviceCondition { get; } = new IsDeviceMatchConditionType(IsDeviceConditionValue);
        /// <summary> Determines if two <see cref="IsDeviceMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(IsDeviceMatchConditionType left, IsDeviceMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IsDeviceMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(IsDeviceMatchConditionType left, IsDeviceMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="IsDeviceMatchConditionType"/>. </summary>
        public static implicit operator IsDeviceMatchConditionType(string value) => new IsDeviceMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IsDeviceMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IsDeviceMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}