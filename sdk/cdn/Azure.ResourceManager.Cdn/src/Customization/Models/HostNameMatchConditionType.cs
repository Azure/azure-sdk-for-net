// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The HostNameMatchConditionType. </summary>
    public readonly partial struct HostNameMatchConditionType : IEquatable<HostNameMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HostNameMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HostNameMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HostNameConditionValue = "DeliveryRuleHostNameConditionParameters";

        /// <summary> DeliveryRuleHostNameConditionParameters. </summary>
        public static HostNameMatchConditionType HostNameCondition { get; } = new HostNameMatchConditionType(HostNameConditionValue);
        /// <summary> Determines if two <see cref="HostNameMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(HostNameMatchConditionType left, HostNameMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HostNameMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(HostNameMatchConditionType left, HostNameMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="HostNameMatchConditionType"/>. </summary>
        public static implicit operator HostNameMatchConditionType(string value) => new HostNameMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HostNameMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HostNameMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}