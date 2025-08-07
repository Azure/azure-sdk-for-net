// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The connection state. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct NetworkConnectionState : IEquatable<NetworkConnectionState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetworkConnectionState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NetworkConnectionState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ReachableValue = "Reachable";
        private const string UnreachableValue = "Unreachable";
        private const string UnknownValue = "Unknown";

        /// <summary> Reachable. </summary>
        public static NetworkConnectionState Reachable { get; } = new NetworkConnectionState(ReachableValue);
        /// <summary> Unreachable. </summary>
        public static NetworkConnectionState Unreachable { get; } = new NetworkConnectionState(UnreachableValue);
        /// <summary> Unknown. </summary>
        public static NetworkConnectionState Unknown { get; } = new NetworkConnectionState(UnknownValue);
        /// <summary> Determines if two <see cref="NetworkConnectionState"/> values are the same. </summary>
        public static bool operator ==(NetworkConnectionState left, NetworkConnectionState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NetworkConnectionState"/> values are not the same. </summary>
        public static bool operator !=(NetworkConnectionState left, NetworkConnectionState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="NetworkConnectionState"/>. </summary>
        public static implicit operator NetworkConnectionState(string value) => new NetworkConnectionState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NetworkConnectionState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NetworkConnectionState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
