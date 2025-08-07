// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RemoteAddressMatchConditionType. </summary>
    public readonly partial struct RemoteAddressMatchConditionType : IEquatable<RemoteAddressMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RemoteAddressMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RemoteAddressMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RemoteAddressConditionValue = "DeliveryRuleRemoteAddressConditionParameters";

        /// <summary> DeliveryRuleRemoteAddressConditionParameters. </summary>
        public static RemoteAddressMatchConditionType RemoteAddressCondition { get; } = new RemoteAddressMatchConditionType(RemoteAddressConditionValue);
        /// <summary> Determines if two <see cref="RemoteAddressMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(RemoteAddressMatchConditionType left, RemoteAddressMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RemoteAddressMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(RemoteAddressMatchConditionType left, RemoteAddressMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RemoteAddressMatchConditionType"/>. </summary>
        public static implicit operator RemoteAddressMatchConditionType(string value) => new RemoteAddressMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RemoteAddressMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RemoteAddressMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}