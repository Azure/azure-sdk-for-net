// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The RequestBodyMatchConditionType. </summary>
    public readonly partial struct RequestBodyMatchConditionType : IEquatable<RequestBodyMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestBodyMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestBodyMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RequestBodyConditionValue = "DeliveryRuleRequestBodyConditionParameters";

        /// <summary> DeliveryRuleRequestBodyConditionParameters. </summary>
        public static RequestBodyMatchConditionType RequestBodyCondition { get; } = new RequestBodyMatchConditionType(RequestBodyConditionValue);
        /// <summary> Determines if two <see cref="RequestBodyMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(RequestBodyMatchConditionType left, RequestBodyMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestBodyMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(RequestBodyMatchConditionType left, RequestBodyMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RequestBodyMatchConditionType"/>. </summary>
        public static implicit operator RequestBodyMatchConditionType(string value) => new RequestBodyMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestBodyMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestBodyMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}