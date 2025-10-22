// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RequestHeaderMatchConditionType. </summary>
    public readonly partial struct RequestHeaderMatchConditionType : IEquatable<RequestHeaderMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestHeaderMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestHeaderMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RequestHeaderConditionValue = "DeliveryRuleRequestHeaderConditionParameters";

        /// <summary> DeliveryRuleRequestHeaderConditionParameters. </summary>
        public static RequestHeaderMatchConditionType RequestHeaderCondition { get; } = new RequestHeaderMatchConditionType(RequestHeaderConditionValue);
        /// <summary> Determines if two <see cref="RequestHeaderMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(RequestHeaderMatchConditionType left, RequestHeaderMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestHeaderMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(RequestHeaderMatchConditionType left, RequestHeaderMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RequestHeaderMatchConditionType"/>. </summary>
        public static implicit operator RequestHeaderMatchConditionType(string value) => new RequestHeaderMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestHeaderMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestHeaderMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}