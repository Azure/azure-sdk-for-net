// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file provides the complete definition of the OriginGroupOverrideActionType extensible enum type, which does not exist in the TypeSpec-generated code.
    // Reason: The old SDK (AutoRest-generated) wrapped the polymorphic discriminator value
    // "DeliveryRuleOriginGroupOverrideActionParameters" as a standalone extensible enum type referenced in user code.
    // After the TypeSpec migration, discriminators are plain strings and this type is no longer generated.
    // The full type definition is preserved here to maintain backward compatibility with the old public API.

    /// <summary> The OriginGroupOverrideActionType. </summary>
    public readonly partial struct OriginGroupOverrideActionType : IEquatable<OriginGroupOverrideActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OriginGroupOverrideActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OriginGroupOverrideActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OriginGroupOverrideActionValue = "DeliveryRuleOriginGroupOverrideActionParameters";

        /// <summary> DeliveryRuleOriginGroupOverrideActionParameters. </summary>
        public static OriginGroupOverrideActionType OriginGroupOverrideAction { get; } = new OriginGroupOverrideActionType(OriginGroupOverrideActionValue);
        /// <summary> Determines if two <see cref="OriginGroupOverrideActionType"/> values are the same. </summary>
        public static bool operator ==(OriginGroupOverrideActionType left, OriginGroupOverrideActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OriginGroupOverrideActionType"/> values are not the same. </summary>
        public static bool operator !=(OriginGroupOverrideActionType left, OriginGroupOverrideActionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="OriginGroupOverrideActionType"/>. </summary>
        public static implicit operator OriginGroupOverrideActionType(string value) => new OriginGroupOverrideActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OriginGroupOverrideActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OriginGroupOverrideActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
