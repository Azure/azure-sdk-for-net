// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertSimulatorBundleType structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertSimulatorBundleType : IEquatable<SecurityAlertSimulatorBundleType>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAlertSimulatorBundleType"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecurityAlertSimulatorBundleType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the AppServices value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType AppServices { get; } = new SecurityAlertSimulatorBundleType("AppServices");
        /// <summary>
        /// Gets the CosmosDbs value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType CosmosDbs { get; } = new SecurityAlertSimulatorBundleType("CosmosDbs");
        /// <summary>
        /// Gets the Dns value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType Dns { get; } = new SecurityAlertSimulatorBundleType("Dns");
        /// <summary>
        /// Gets the KeyVaults value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType KeyVaults { get; } = new SecurityAlertSimulatorBundleType("KeyVaults");
        /// <summary>
        /// Gets the KubernetesService value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType KubernetesService { get; } = new SecurityAlertSimulatorBundleType("KubernetesService");
        /// <summary>
        /// Gets the ResourceManager value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType ResourceManager { get; } = new SecurityAlertSimulatorBundleType("ResourceManager");
        /// <summary>
        /// Gets the SqlServers value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType SqlServers { get; } = new SecurityAlertSimulatorBundleType("SqlServers");
        /// <summary>
        /// Gets the StorageAccounts value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType StorageAccounts { get; } = new SecurityAlertSimulatorBundleType("StorageAccounts");
        /// <summary>
        /// Gets the VirtualMachines value preserved from the previous public API surface.
        /// </summary>
        public static SecurityAlertSimulatorBundleType VirtualMachines { get; } = new SecurityAlertSimulatorBundleType("VirtualMachines");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(SecurityAlertSimulatorBundleType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is SecurityAlertSimulatorBundleType other && Equals(other);
        /// <summary>
        /// Provides a compatibility shim for the GetHashCode operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator ==(SecurityAlertSimulatorBundleType left, SecurityAlertSimulatorBundleType right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator SecurityAlertSimulatorBundleType(string value) => new SecurityAlertSimulatorBundleType(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(SecurityAlertSimulatorBundleType left, SecurityAlertSimulatorBundleType right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
