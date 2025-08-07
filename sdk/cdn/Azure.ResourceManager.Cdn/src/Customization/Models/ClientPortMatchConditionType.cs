// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The ClientPortMatchConditionType. </summary>
    public readonly partial struct ClientPortMatchConditionType : IEquatable<ClientPortMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ClientPortMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ClientPortMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ClientPortConditionValue = "DeliveryRuleClientPortConditionParameters";

        /// <summary> DeliveryRuleClientPortConditionParameters. </summary>
        public static ClientPortMatchConditionType ClientPortCondition { get; } = new ClientPortMatchConditionType(ClientPortConditionValue);
        /// <summary> Determines if two <see cref="ClientPortMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(ClientPortMatchConditionType left, ClientPortMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ClientPortMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(ClientPortMatchConditionType left, ClientPortMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ClientPortMatchConditionType"/>. </summary>
        public static implicit operator ClientPortMatchConditionType(string value) => new ClientPortMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ClientPortMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ClientPortMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}