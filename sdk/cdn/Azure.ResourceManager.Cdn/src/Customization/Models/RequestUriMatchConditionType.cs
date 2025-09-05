// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RequestUriMatchConditionType. </summary>
    public readonly partial struct RequestUriMatchConditionType : IEquatable<RequestUriMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestUriMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestUriMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RequestUriConditionValue = "DeliveryRuleRequestUriConditionParameters";

        /// <summary> DeliveryRuleRequestUriConditionParameters. </summary>
        public static RequestUriMatchConditionType RequestUriCondition { get; } = new RequestUriMatchConditionType(RequestUriConditionValue);
        /// <summary> Determines if two <see cref="RequestUriMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(RequestUriMatchConditionType left, RequestUriMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestUriMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(RequestUriMatchConditionType left, RequestUriMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RequestUriMatchConditionType"/>. </summary>
        public static implicit operator RequestUriMatchConditionType(string value) => new RequestUriMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestUriMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestUriMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}