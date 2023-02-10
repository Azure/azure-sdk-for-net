// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The role of the participant. </summary>
    public readonly partial struct Role : IEquatable<Role>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Role"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Role(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AgentValue = "agent";
        private const string CustomerValue = "customer";
        private const string GenericValue = "generic";

        /// <summary> agent. </summary>
        public static Role Agent { get; } = new Role(AgentValue);
        /// <summary> customer. </summary>
        public static Role Customer { get; } = new Role(CustomerValue);
        /// <summary> generic. </summary>
        public static Role Generic { get; } = new Role(GenericValue);
        /// <summary> Determines if two <see cref="Role"/> values are the same. </summary>
        public static bool operator ==(Role left, Role right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Role"/> values are not the same. </summary>
        public static bool operator !=(Role left, Role right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Role"/>. </summary>
        public static implicit operator Role(string value) => new Role(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Role other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Role other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
