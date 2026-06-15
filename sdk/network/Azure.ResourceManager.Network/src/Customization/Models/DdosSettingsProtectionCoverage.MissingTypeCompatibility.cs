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
    /// <summary> DDoS settings protection coverage. </summary>
    [Obsolete]
    public readonly partial struct DdosSettingsProtectionCoverage : IEquatable<DdosSettingsProtectionCoverage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosSettingsProtectionCoverage"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosSettingsProtectionCoverage(string value) => _value = value;

        /// <summary> VirtualNetworkInherited. </summary>
        public static DdosSettingsProtectionCoverage VirtualNetworkInherited { get; } = new DdosSettingsProtectionCoverage("VirtualNetworkInherited");
        /// <summary> Enabled. </summary>
        public static DdosSettingsProtectionCoverage Enabled { get; } = new DdosSettingsProtectionCoverage("Enabled");
        /// <summary> Disabled. </summary>
        public static DdosSettingsProtectionCoverage Disabled { get; } = new DdosSettingsProtectionCoverage("Disabled");

        /// <inheritdoc/>
        public bool Equals(DdosSettingsProtectionCoverage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosSettingsProtectionCoverage other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosSettingsProtectionCoverage"/> values for equality. </summary>
        public static bool operator ==(DdosSettingsProtectionCoverage left, DdosSettingsProtectionCoverage right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosSettingsProtectionCoverage"/>. </summary>
        public static implicit operator DdosSettingsProtectionCoverage(string value) => new DdosSettingsProtectionCoverage(value);
        /// <summary> Compares two <see cref="DdosSettingsProtectionCoverage"/> values for inequality. </summary>
        public static bool operator !=(DdosSettingsProtectionCoverage left, DdosSettingsProtectionCoverage right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
