// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The SocketAddressMatchConditionType. </summary>
    public readonly partial struct SocketAddressMatchConditionType : IEquatable<SocketAddressMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SocketAddressMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SocketAddressMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SocketAddressConditionValue = "DeliveryRuleSocketAddrConditionParameters";

        /// <summary> DeliveryRuleSocketAddrConditionParameters. </summary>
        public static SocketAddressMatchConditionType SocketAddressCondition { get; } = new SocketAddressMatchConditionType(SocketAddressConditionValue);
        /// <summary> Determines if two <see cref="SocketAddressMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(SocketAddressMatchConditionType left, SocketAddressMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SocketAddressMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(SocketAddressMatchConditionType left, SocketAddressMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SocketAddressMatchConditionType"/>. </summary>
        public static implicit operator SocketAddressMatchConditionType(string value) => new SocketAddressMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SocketAddressMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SocketAddressMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}