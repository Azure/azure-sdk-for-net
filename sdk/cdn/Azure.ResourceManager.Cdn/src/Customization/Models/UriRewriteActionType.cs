// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file provides the complete definition of the UriRewriteActionType extensible enum type, which does not exist in the TypeSpec-generated code.
    // Reason: The old SDK (AutoRest-generated) wrapped the polymorphic discriminator value
    // "DeliveryRuleUrlRewriteActionParameters" as a standalone extensible enum type referenced in user code.
    // After the TypeSpec migration, discriminators are plain strings and this type is no longer generated.
    // The full type definition is preserved here to maintain backward compatibility with the old public API.

    /// <summary> The UriRewriteActionType. </summary>
    public readonly partial struct UriRewriteActionType : IEquatable<UriRewriteActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UriRewriteActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UriRewriteActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UriRewriteActionValue = "DeliveryRuleUrlRewriteActionParameters";

        /// <summary> DeliveryRuleUrlRewriteActionParameters. </summary>
        public static UriRewriteActionType UriRewriteAction { get; } = new UriRewriteActionType(UriRewriteActionValue);
        /// <summary> Determines if two <see cref="UriRewriteActionType"/> values are the same. </summary>
        public static bool operator ==(UriRewriteActionType left, UriRewriteActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UriRewriteActionType"/> values are not the same. </summary>
        public static bool operator !=(UriRewriteActionType left, UriRewriteActionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UriRewriteActionType"/>. </summary>
        public static implicit operator UriRewriteActionType(string value) => new UriRewriteActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UriRewriteActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UriRewriteActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
