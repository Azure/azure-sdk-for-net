// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec renamed or removed this extensible-enum type from the generated surface; keep the previous GA enum wrapper so existing signatures and constants remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertSimulatorBundleType structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertSimulatorBundleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAlertSimulatorBundleType"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public SecurityAlertSimulatorBundleType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Gets the AppServices value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType AppServices { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the CosmosDbs value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType CosmosDbs { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the Dns value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType Dns { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the KeyVaults value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType KeyVaults { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the KubernetesService value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType KubernetesService { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the ResourceManager value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType ResourceManager { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the SqlServers value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType SqlServers { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the StorageAccounts value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType StorageAccounts { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the VirtualMachines value preserved from the previous public API surface.
        /// </summary>
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType VirtualMachines { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetHashCode operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
