// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The UriSigningActionType. </summary>
    public readonly partial struct UriSigningActionType : IEquatable<UriSigningActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UriSigningActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UriSigningActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UriSigningActionValue = "DeliveryRuleUrlSigningActionParameters";

        /// <summary> DeliveryRuleUrlSigningActionParameters. </summary>
        public static UriSigningActionType UriSigningAction { get; } = new UriSigningActionType(UriSigningActionValue);
        /// <summary> Determines if two <see cref="UriSigningActionType"/> values are the same. </summary>
        public static bool operator ==(UriSigningActionType left, UriSigningActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UriSigningActionType"/> values are not the same. </summary>
        public static bool operator !=(UriSigningActionType left, UriSigningActionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UriSigningActionType"/>. </summary>
        public static implicit operator UriSigningActionType(string value) => new UriSigningActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UriSigningActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UriSigningActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}