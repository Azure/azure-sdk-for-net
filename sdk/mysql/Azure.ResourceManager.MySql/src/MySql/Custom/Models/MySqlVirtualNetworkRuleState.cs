// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Virtual Network Rule State. </summary>
    public readonly partial struct MySqlVirtualNetworkRuleState : IEquatable<MySqlVirtualNetworkRuleState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlVirtualNetworkRuleState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlVirtualNetworkRuleState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InitializingValue = "Initializing";
        private const string InProgressValue = "InProgress";
        private const string ReadyValue = "Ready";
        private const string DeletingValue = "Deleting";
        private const string UnknownValue = "Unknown";

        /// <summary> Initializing. </summary>
        public static MySqlVirtualNetworkRuleState Initializing { get; } = new MySqlVirtualNetworkRuleState(InitializingValue);
        /// <summary> InProgress. </summary>
        public static MySqlVirtualNetworkRuleState InProgress { get; } = new MySqlVirtualNetworkRuleState(InProgressValue);
        /// <summary> Ready. </summary>
        public static MySqlVirtualNetworkRuleState Ready { get; } = new MySqlVirtualNetworkRuleState(ReadyValue);
        /// <summary> Deleting. </summary>
        public static MySqlVirtualNetworkRuleState Deleting { get; } = new MySqlVirtualNetworkRuleState(DeletingValue);
        /// <summary> Unknown. </summary>
        public static MySqlVirtualNetworkRuleState Unknown { get; } = new MySqlVirtualNetworkRuleState(UnknownValue);
        /// <summary> Determines if two <see cref="MySqlVirtualNetworkRuleState"/> values are the same. </summary>
        public static bool operator ==(MySqlVirtualNetworkRuleState left, MySqlVirtualNetworkRuleState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlVirtualNetworkRuleState"/> values are not the same. </summary>
        public static bool operator !=(MySqlVirtualNetworkRuleState left, MySqlVirtualNetworkRuleState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlVirtualNetworkRuleState"/>. </summary>
        public static implicit operator MySqlVirtualNetworkRuleState(string value) => new MySqlVirtualNetworkRuleState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlVirtualNetworkRuleState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlVirtualNetworkRuleState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}