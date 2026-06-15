// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Network connection state. </summary>
    public readonly partial struct NetworkConnectionState : IEquatable<NetworkConnectionState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetworkConnectionState"/>. </summary>
        /// <param name="value"> The value. </param>
        public NetworkConnectionState(string value) => _value = value;

        /// <summary> Reachable. </summary>
        public static NetworkConnectionState Reachable { get; } = new NetworkConnectionState("Reachable");
        /// <summary> Unreachable. </summary>
        public static NetworkConnectionState Unreachable { get; } = new NetworkConnectionState("Unreachable");
        /// <summary> Unknown. </summary>
        public static NetworkConnectionState Unknown { get; } = new NetworkConnectionState("Unknown");

        /// <inheritdoc/>
        public bool Equals(NetworkConnectionState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is NetworkConnectionState other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="NetworkConnectionState"/> values for equality. </summary>
        public static bool operator ==(NetworkConnectionState left, NetworkConnectionState right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="NetworkConnectionState"/>. </summary>
        public static implicit operator NetworkConnectionState(string value) => new NetworkConnectionState(value);
        /// <summary> Compares two <see cref="NetworkConnectionState"/> values for inequality. </summary>
        public static bool operator !=(NetworkConnectionState left, NetworkConnectionState right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
