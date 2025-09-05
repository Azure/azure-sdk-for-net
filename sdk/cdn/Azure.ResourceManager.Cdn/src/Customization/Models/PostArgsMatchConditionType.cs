// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The PostArgsMatchConditionType. </summary>
    public readonly partial struct PostArgsMatchConditionType : IEquatable<PostArgsMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PostArgsMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PostArgsMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PostArgsConditionValue = "DeliveryRulePostArgsConditionParameters";

        /// <summary> DeliveryRulePostArgsConditionParameters. </summary>
        public static PostArgsMatchConditionType PostArgsCondition { get; } = new PostArgsMatchConditionType(PostArgsConditionValue);
        /// <summary> Determines if two <see cref="PostArgsMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(PostArgsMatchConditionType left, PostArgsMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PostArgsMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(PostArgsMatchConditionType left, PostArgsMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="PostArgsMatchConditionType"/>. </summary>
        public static implicit operator PostArgsMatchConditionType(string value) => new PostArgsMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PostArgsMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PostArgsMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}