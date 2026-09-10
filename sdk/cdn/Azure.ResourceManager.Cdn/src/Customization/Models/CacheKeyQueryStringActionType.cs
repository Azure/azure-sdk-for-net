// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file provides the complete definition of the CacheKeyQueryStringActionType extensible enum type, which does not exist in the TypeSpec-generated code.
    // Reason: The old SDK (AutoRest-generated) wrapped the polymorphic discriminator value
    // "DeliveryRuleCacheKeyQueryStringBehaviorActionParameters" as a standalone extensible enum type referenced in user code.
    // After the TypeSpec migration, discriminators are plain strings and this type is no longer generated.
    // The full type definition is preserved here to maintain backward compatibility with the old public API.

    /// <summary> The CacheKeyQueryStringActionType. </summary>
    public readonly partial struct CacheKeyQueryStringActionType : IEquatable<CacheKeyQueryStringActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CacheKeyQueryStringActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CacheKeyQueryStringActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CacheKeyQueryStringBehaviorActionValue = "DeliveryRuleCacheKeyQueryStringBehaviorActionParameters";

        /// <summary> DeliveryRuleCacheKeyQueryStringBehaviorActionParameters. </summary>
        public static CacheKeyQueryStringActionType CacheKeyQueryStringBehaviorAction { get; } = new CacheKeyQueryStringActionType(CacheKeyQueryStringBehaviorActionValue);
        /// <summary> Determines if two <see cref="CacheKeyQueryStringActionType"/> values are the same. </summary>
        public static bool operator ==(CacheKeyQueryStringActionType left, CacheKeyQueryStringActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CacheKeyQueryStringActionType"/> values are not the same. </summary>
        public static bool operator !=(CacheKeyQueryStringActionType left, CacheKeyQueryStringActionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CacheKeyQueryStringActionType"/>. </summary>
        public static implicit operator CacheKeyQueryStringActionType(string value) => new CacheKeyQueryStringActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CacheKeyQueryStringActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CacheKeyQueryStringActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
