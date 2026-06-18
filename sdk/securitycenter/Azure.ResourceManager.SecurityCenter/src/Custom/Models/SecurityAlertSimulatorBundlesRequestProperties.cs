// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertSimulatorBundlesRequestProperties class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityAlertSimulatorBundlesRequestProperties : SecurityAlertSimulatorRequestProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAlertSimulatorBundlesRequestProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityAlertSimulatorBundlesRequestProperties() : base(default(SecurityCenterKind)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Gets the Bundles value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType> Bundles { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
