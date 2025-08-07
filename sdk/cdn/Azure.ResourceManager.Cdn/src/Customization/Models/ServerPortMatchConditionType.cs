// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> The ServerPortMatchConditionType. </summary>
    public readonly partial struct ServerPortMatchConditionType : IEquatable<ServerPortMatchConditionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ServerPortMatchConditionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ServerPortMatchConditionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ServerPortConditionValue = "DeliveryRuleServerPortConditionParameters";

        /// <summary> DeliveryRuleServerPortConditionParameters. </summary>
        public static ServerPortMatchConditionType ServerPortCondition { get; } = new ServerPortMatchConditionType(ServerPortConditionValue);
        /// <summary> Determines if two <see cref="ServerPortMatchConditionType"/> values are the same. </summary>
        public static bool operator ==(ServerPortMatchConditionType left, ServerPortMatchConditionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ServerPortMatchConditionType"/> values are not the same. </summary>
        public static bool operator !=(ServerPortMatchConditionType left, ServerPortMatchConditionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ServerPortMatchConditionType"/>. </summary>
        public static implicit operator ServerPortMatchConditionType(string value) => new ServerPortMatchConditionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ServerPortMatchConditionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ServerPortMatchConditionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}