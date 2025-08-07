// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RequestSchemeMatchConditionType. </summary>
    public readonly partial struct RequestSchemeMatchConditionType : IEquatable<RequestSchemeMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestSchemeMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestSchemeMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RequestSchemeConditionValue = "DeliveryRuleRequestSchemeConditionParameters";

        /// <summary> DeliveryRuleRequestSchemeConditionParameters. </summary>
        public static RequestSchemeMatchConditionType RequestSchemeCondition { get; } = new RequestSchemeMatchConditionType(RequestSchemeConditionValue);
        /// <summary> Determines if two <see cref="RequestSchemeMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(RequestSchemeMatchConditionType left, RequestSchemeMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestSchemeMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(RequestSchemeMatchConditionType left, RequestSchemeMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RequestSchemeMatchConditionType"/>. </summary>
        public static implicit operator RequestSchemeMatchConditionType(string value) => new RequestSchemeMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestSchemeMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestSchemeMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}