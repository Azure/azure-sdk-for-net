// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The SslProtocolMatchConditionType. </summary>
    public readonly partial struct SslProtocolMatchConditionType : IEquatable<SslProtocolMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SslProtocolMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SslProtocolMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SslProtocolConditionValue = "DeliveryRuleSslProtocolConditionParameters";

        /// <summary> DeliveryRuleSslProtocolConditionParameters. </summary>
        public static SslProtocolMatchConditionType SslProtocolCondition { get; } = new SslProtocolMatchConditionType(SslProtocolConditionValue);
        /// <summary> Determines if two <see cref="SslProtocolMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(SslProtocolMatchConditionType left, SslProtocolMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SslProtocolMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(SslProtocolMatchConditionType left, SslProtocolMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SslProtocolMatchConditionType"/>. </summary>
        public static implicit operator SslProtocolMatchConditionType(string value) => new SslProtocolMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SslProtocolMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SslProtocolMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}