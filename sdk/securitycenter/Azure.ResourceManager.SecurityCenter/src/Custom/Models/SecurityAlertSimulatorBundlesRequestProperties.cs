// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertSimulatorBundlesRequestProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
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
