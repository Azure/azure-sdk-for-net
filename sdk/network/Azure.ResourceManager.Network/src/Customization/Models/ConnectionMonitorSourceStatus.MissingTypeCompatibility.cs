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

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Connection monitor source status. </summary>
    public readonly partial struct ConnectionMonitorSourceStatus : IEquatable<ConnectionMonitorSourceStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorSourceStatus"/>. </summary>
        /// <param name="value"> The value. </param>
        public ConnectionMonitorSourceStatus(string value) => _value = value;

        /// <inheritdoc/>
        public bool Equals(ConnectionMonitorSourceStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ConnectionMonitorSourceStatus other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="ConnectionMonitorSourceStatus"/> values for equality. </summary>
        public static bool operator ==(ConnectionMonitorSourceStatus left, ConnectionMonitorSourceStatus right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConnectionMonitorSourceStatus"/>. </summary>
        public static implicit operator ConnectionMonitorSourceStatus(string value) => new ConnectionMonitorSourceStatus(value);
        /// <summary> Compares two <see cref="ConnectionMonitorSourceStatus"/> values for inequality. </summary>
        public static bool operator !=(ConnectionMonitorSourceStatus left, ConnectionMonitorSourceStatus right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
