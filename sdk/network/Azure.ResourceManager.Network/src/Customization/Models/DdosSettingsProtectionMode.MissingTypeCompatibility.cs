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
    /// <summary> DDoS settings protection mode. </summary>
    public readonly partial struct DdosSettingsProtectionMode : IEquatable<DdosSettingsProtectionMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosSettingsProtectionMode"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosSettingsProtectionMode(string value) => _value = value;

        /// <summary> VirtualNetworkInherited. </summary>
        public static DdosSettingsProtectionMode VirtualNetworkInherited { get; } = new DdosSettingsProtectionMode("VirtualNetworkInherited");
        /// <summary> Enabled. </summary>
        public static DdosSettingsProtectionMode Enabled { get; } = new DdosSettingsProtectionMode("Enabled");
        /// <summary> Disabled. </summary>
        public static DdosSettingsProtectionMode Disabled { get; } = new DdosSettingsProtectionMode("Disabled");

        /// <inheritdoc/>
        public bool Equals(DdosSettingsProtectionMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosSettingsProtectionMode other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosSettingsProtectionMode"/> values for equality. </summary>
        public static bool operator ==(DdosSettingsProtectionMode left, DdosSettingsProtectionMode right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosSettingsProtectionMode"/>. </summary>
        public static implicit operator DdosSettingsProtectionMode(string value) => new DdosSettingsProtectionMode(value);
        /// <summary> Compares two <see cref="DdosSettingsProtectionMode"/> values for inequality. </summary>
        public static bool operator !=(DdosSettingsProtectionMode left, DdosSettingsProtectionMode right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
