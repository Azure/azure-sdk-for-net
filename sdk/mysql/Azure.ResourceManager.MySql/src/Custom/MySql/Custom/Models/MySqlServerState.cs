// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> A state of a server that is visible to user. </summary>
    public readonly partial struct MySqlServerState : IEquatable<MySqlServerState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlServerState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlServerState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ReadyValue = "Ready";
        private const string DroppingValue = "Dropping";
        private const string DisabledValue = "Disabled";
        private const string InaccessibleValue = "Inaccessible";

        /// <summary> Ready. </summary>
        public static MySqlServerState Ready { get; } = new MySqlServerState(ReadyValue);
        /// <summary> Dropping. </summary>
        public static MySqlServerState Dropping { get; } = new MySqlServerState(DroppingValue);
        /// <summary> Disabled. </summary>
        public static MySqlServerState Disabled { get; } = new MySqlServerState(DisabledValue);
        /// <summary> Inaccessible. </summary>
        public static MySqlServerState Inaccessible { get; } = new MySqlServerState(InaccessibleValue);
        /// <summary> Determines if two <see cref="MySqlServerState"/> values are the same. </summary>
        public static bool operator ==(MySqlServerState left, MySqlServerState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlServerState"/> values are not the same. </summary>
        public static bool operator !=(MySqlServerState left, MySqlServerState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlServerState"/>. </summary>
        public static implicit operator MySqlServerState(string value) => new MySqlServerState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlServerState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlServerState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}