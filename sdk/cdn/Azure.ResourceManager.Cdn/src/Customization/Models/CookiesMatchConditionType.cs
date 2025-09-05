// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The CookiesMatchConditionType. </summary>
    public readonly partial struct CookiesMatchConditionType : IEquatable<CookiesMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CookiesMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CookiesMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CookiesConditionValue = "DeliveryRuleCookiesConditionParameters";

        /// <summary> DeliveryRuleCookiesConditionParameters. </summary>
        public static CookiesMatchConditionType CookiesCondition { get; } = new CookiesMatchConditionType(CookiesConditionValue);
        /// <summary> Determines if two <see cref="CookiesMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(CookiesMatchConditionType left, CookiesMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CookiesMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(CookiesMatchConditionType left, CookiesMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CookiesMatchConditionType"/>. </summary>
        public static implicit operator CookiesMatchConditionType(string value) => new CookiesMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CookiesMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CookiesMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}