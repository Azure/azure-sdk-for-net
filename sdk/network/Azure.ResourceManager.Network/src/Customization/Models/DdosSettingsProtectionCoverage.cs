// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    // Retain the released value type required by the local-only DdosSettings.ProtectionCoverage API.
    // The current service model has no coverage field; these values do not map to ProtectionMode.
    // Basic/Standard were the obsolete 1.15 values; the mode values came from the incorrect 1.17 rename.
    /// <summary> The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and might be removed in a future version", false)]
    public readonly partial struct DdosSettingsProtectionCoverage : IEquatable<DdosSettingsProtectionCoverage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosSettingsProtectionCoverage"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosSettingsProtectionCoverage(string value) => _value = value;

        /// <summary> Basic. </summary>
        public static DdosSettingsProtectionCoverage Basic { get; } = new DdosSettingsProtectionCoverage("Basic");
        /// <summary> Standard. </summary>
        public static DdosSettingsProtectionCoverage Standard { get; } = new DdosSettingsProtectionCoverage("Standard");

        /// <summary> VirtualNetworkInherited. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value belongs to DdosSettingsProtectionMode. Please use DdosSettingsProtectionMode.VirtualNetworkInherited instead.")]
        public static DdosSettingsProtectionCoverage VirtualNetworkInherited { get; } = new DdosSettingsProtectionCoverage("VirtualNetworkInherited");
        /// <summary> Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value belongs to DdosSettingsProtectionMode. Please use DdosSettingsProtectionMode.Enabled instead.")]
        public static DdosSettingsProtectionCoverage Enabled { get; } = new DdosSettingsProtectionCoverage("Enabled");
        /// <summary> Disabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value belongs to DdosSettingsProtectionMode. Please use DdosSettingsProtectionMode.Disabled instead.")]
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
        /// <summary> Converts a string to a nullable <see cref="DdosSettingsProtectionCoverage"/>. </summary>
        public static implicit operator DdosSettingsProtectionCoverage?(string value) => value == null ? null : new DdosSettingsProtectionCoverage(value);
        /// <summary> Compares two <see cref="DdosSettingsProtectionCoverage"/> values for inequality. </summary>
        public static bool operator !=(DdosSettingsProtectionCoverage left, DdosSettingsProtectionCoverage right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
