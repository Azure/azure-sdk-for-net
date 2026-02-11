// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> State of the private endpoint connection. </summary>
    public readonly partial struct MySqlPrivateEndpointProvisioningState : IEquatable<MySqlPrivateEndpointProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlPrivateEndpointProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlPrivateEndpointProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ApprovingValue = "Approving";
        private const string ReadyValue = "Ready";
        private const string DroppingValue = "Dropping";
        private const string FailedValue = "Failed";
        private const string RejectingValue = "Rejecting";

        /// <summary> Approving. </summary>
        public static MySqlPrivateEndpointProvisioningState Approving { get; } = new MySqlPrivateEndpointProvisioningState(ApprovingValue);
        /// <summary> Ready. </summary>
        public static MySqlPrivateEndpointProvisioningState Ready { get; } = new MySqlPrivateEndpointProvisioningState(ReadyValue);
        /// <summary> Dropping. </summary>
        public static MySqlPrivateEndpointProvisioningState Dropping { get; } = new MySqlPrivateEndpointProvisioningState(DroppingValue);
        /// <summary> Failed. </summary>
        public static MySqlPrivateEndpointProvisioningState Failed { get; } = new MySqlPrivateEndpointProvisioningState(FailedValue);
        /// <summary> Rejecting. </summary>
        public static MySqlPrivateEndpointProvisioningState Rejecting { get; } = new MySqlPrivateEndpointProvisioningState(RejectingValue);
        /// <summary> Determines if two <see cref="MySqlPrivateEndpointProvisioningState"/> values are the same. </summary>
        public static bool operator ==(MySqlPrivateEndpointProvisioningState left, MySqlPrivateEndpointProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlPrivateEndpointProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(MySqlPrivateEndpointProvisioningState left, MySqlPrivateEndpointProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlPrivateEndpointProvisioningState"/>. </summary>
        public static implicit operator MySqlPrivateEndpointProvisioningState(string value) => new MySqlPrivateEndpointProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlPrivateEndpointProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlPrivateEndpointProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}