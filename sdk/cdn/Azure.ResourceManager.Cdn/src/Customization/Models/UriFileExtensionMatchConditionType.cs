// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file provides the complete definition of the UriFileExtensionMatchConditionType extensible enum type, which does not exist in the TypeSpec-generated code.
    // Reason: The old SDK wrapped the discriminator value "DeliveryRuleUrlFileExtensionMatchConditionParameters" as this type.
    // After the TypeSpec migration, discriminators are plain strings and this type is no longer generated.
    // The full type definition is preserved here to maintain backward compatibility with the old public API.

    /// <summary> The UriFileExtensionMatchConditionType. </summary>
    public readonly partial struct UriFileExtensionMatchConditionType : IEquatable<UriFileExtensionMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UriFileExtensionMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UriFileExtensionMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UriFileExtensionMatchConditionValue = "DeliveryRuleUrlFileExtensionMatchConditionParameters";

        /// <summary> DeliveryRuleUrlFileExtensionMatchConditionParameters. </summary>
        public static UriFileExtensionMatchConditionType UriFileExtensionMatchCondition { get; } = new UriFileExtensionMatchConditionType(UriFileExtensionMatchConditionValue);
        /// <summary> Determines if two <see cref="UriFileExtensionMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(UriFileExtensionMatchConditionType left, UriFileExtensionMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UriFileExtensionMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(UriFileExtensionMatchConditionType left, UriFileExtensionMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UriFileExtensionMatchConditionType"/>. </summary>
        public static implicit operator UriFileExtensionMatchConditionType(string value) => new UriFileExtensionMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UriFileExtensionMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UriFileExtensionMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
