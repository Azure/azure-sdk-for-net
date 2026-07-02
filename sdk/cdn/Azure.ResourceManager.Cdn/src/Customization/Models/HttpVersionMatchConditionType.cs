// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file provides the complete definition of the HttpVersionMatchConditionType extensible enum type, which does not exist in the TypeSpec-generated code.
    // Reason: The old SDK wrapped the discriminator value "DeliveryRuleHttpVersionConditionParameters" as this type.
    // After the TypeSpec migration, discriminators are plain strings and this type is no longer generated.
    // The full type definition is preserved here to maintain backward compatibility with the old public API.

    /// <summary> The HttpVersionMatchConditionType. </summary>
    public readonly partial struct HttpVersionMatchConditionType : IEquatable<HttpVersionMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HttpVersionMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HttpVersionMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HttpVersionConditionValue = "DeliveryRuleHttpVersionConditionParameters";

        /// <summary> DeliveryRuleHttpVersionConditionParameters. </summary>
        public static HttpVersionMatchConditionType HttpVersionCondition { get; } = new HttpVersionMatchConditionType(HttpVersionConditionValue);
        /// <summary> Determines if two <see cref="HttpVersionMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(HttpVersionMatchConditionType left, HttpVersionMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HttpVersionMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(HttpVersionMatchConditionType left, HttpVersionMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="HttpVersionMatchConditionType"/>. </summary>
        public static implicit operator HttpVersionMatchConditionType(string value) => new HttpVersionMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HttpVersionMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HttpVersionMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
