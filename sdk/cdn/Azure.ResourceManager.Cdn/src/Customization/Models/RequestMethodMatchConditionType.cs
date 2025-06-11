// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RequestMethodMatchConditionType. </summary>
    public readonly partial struct RequestMethodMatchConditionType : IEquatable<RequestMethodMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestMethodMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestMethodMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RequestMethodConditionValue = "DeliveryRuleRequestMethodConditionParameters";

        /// <summary> DeliveryRuleRequestMethodConditionParameters. </summary>
        public static RequestMethodMatchConditionType RequestMethodCondition { get; } = new RequestMethodMatchConditionType(RequestMethodConditionValue);
        /// <summary> Determines if two <see cref="RequestMethodMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(RequestMethodMatchConditionType left, RequestMethodMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestMethodMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(RequestMethodMatchConditionType left, RequestMethodMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RequestMethodMatchConditionType"/>. </summary>
        public static implicit operator RequestMethodMatchConditionType(string value) => new RequestMethodMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestMethodMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestMethodMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}