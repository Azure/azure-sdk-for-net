// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The CacheExpirationActionType. </summary>
    public readonly partial struct CacheExpirationActionType : IEquatable<CacheExpirationActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CacheExpirationActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CacheExpirationActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CacheExpirationActionValue = "DeliveryRuleCacheExpirationActionParameters";

        /// <summary> DeliveryRuleCacheExpirationActionParameters. </summary>
        public static CacheExpirationActionType CacheExpirationAction { get; } = new CacheExpirationActionType(CacheExpirationActionValue);
        /// <summary> Determines if two <see cref="CacheExpirationActionType"/> values are the same. </summary>
        public static bool operator ==(CacheExpirationActionType left, CacheExpirationActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CacheExpirationActionType"/> values are not the same. </summary>
        public static bool operator !=(CacheExpirationActionType left, CacheExpirationActionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CacheExpirationActionType"/>. </summary>
        public static implicit operator CacheExpirationActionType(string value) => new CacheExpirationActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CacheExpirationActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CacheExpirationActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}