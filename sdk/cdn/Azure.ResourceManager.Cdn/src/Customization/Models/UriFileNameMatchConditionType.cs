// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The UriFileNameMatchConditionType. </summary>
    public readonly partial struct UriFileNameMatchConditionType : IEquatable<UriFileNameMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UriFileNameMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UriFileNameMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UriFilenameConditionValue = "DeliveryRuleUrlFilenameConditionParameters";

        /// <summary> DeliveryRuleUrlFilenameConditionParameters. </summary>
        public static UriFileNameMatchConditionType UriFilenameCondition { get; } = new UriFileNameMatchConditionType(UriFilenameConditionValue);
        /// <summary> Determines if two <see cref="UriFileNameMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(UriFileNameMatchConditionType left, UriFileNameMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UriFileNameMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(UriFileNameMatchConditionType left, UriFileNameMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UriFileNameMatchConditionType"/>. </summary>
        public static implicit operator UriFileNameMatchConditionType(string value) => new UriFileNameMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UriFileNameMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UriFileNameMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}