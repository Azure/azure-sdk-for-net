// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The QueryStringMatchConditionType. </summary>
    public readonly partial struct QueryStringMatchConditionType : IEquatable<QueryStringMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QueryStringMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QueryStringMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string QueryStringConditionValue = "DeliveryRuleQueryStringConditionParameters";

        /// <summary> DeliveryRuleQueryStringConditionParameters. </summary>
        public static QueryStringMatchConditionType QueryStringCondition { get; } = new QueryStringMatchConditionType(QueryStringConditionValue);
        /// <summary> Determines if two <see cref="QueryStringMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(QueryStringMatchConditionType left, QueryStringMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QueryStringMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(QueryStringMatchConditionType left, QueryStringMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="QueryStringMatchConditionType"/>. </summary>
        public static implicit operator QueryStringMatchConditionType(string value) => new QueryStringMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QueryStringMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QueryStringMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}