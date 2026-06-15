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
    /// <summary> Type of connection monitor. </summary>
    public readonly partial struct ConnectionMonitorType : IEquatable<ConnectionMonitorType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorType"/>. </summary>
        /// <param name="value"> The value. </param>
        public ConnectionMonitorType(string value) => _value = value;

        /// <summary> MultiEndpoint. </summary>
        public static ConnectionMonitorType MultiEndpoint { get; } = new ConnectionMonitorType("MultiEndpoint");
        /// <summary> SingleSourceDestination. </summary>
        public static ConnectionMonitorType SingleSourceDestination { get; } = new ConnectionMonitorType("SingleSourceDestination");

        /// <inheritdoc/>
        public bool Equals(ConnectionMonitorType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ConnectionMonitorType other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="ConnectionMonitorType"/> values for equality. </summary>
        public static bool operator ==(ConnectionMonitorType left, ConnectionMonitorType right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConnectionMonitorType"/>. </summary>
        public static implicit operator ConnectionMonitorType(string value) => new ConnectionMonitorType(value);
        /// <summary> Compares two <see cref="ConnectionMonitorType"/> values for inequality. </summary>
        public static bool operator !=(ConnectionMonitorType left, ConnectionMonitorType right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
