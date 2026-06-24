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
    /// <summary> DDoS traffic type. </summary>
    public readonly partial struct DdosTrafficType : IEquatable<DdosTrafficType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosTrafficType"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosTrafficType(string value) => _value = value;

        /// <summary> Tcp. </summary>
        public static DdosTrafficType Tcp { get; } = new DdosTrafficType("Tcp");
        /// <summary> Udp. </summary>
        public static DdosTrafficType Udp { get; } = new DdosTrafficType("Udp");
        /// <summary> TcpSyn. </summary>
        public static DdosTrafficType TcpSyn { get; } = new DdosTrafficType("TcpSyn");

        /// <inheritdoc/>
        public bool Equals(DdosTrafficType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosTrafficType other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosTrafficType"/> values for equality. </summary>
        public static bool operator ==(DdosTrafficType left, DdosTrafficType right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosTrafficType"/>. </summary>
        public static implicit operator DdosTrafficType(string value) => new DdosTrafficType(value);
        /// <summary> Compares two <see cref="DdosTrafficType"/> values for inequality. </summary>
        public static bool operator !=(DdosTrafficType left, DdosTrafficType right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
