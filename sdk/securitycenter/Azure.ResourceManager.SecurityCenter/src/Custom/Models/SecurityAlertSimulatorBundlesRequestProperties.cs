// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertSimulatorBundlesRequestProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityAlertSimulatorBundlesRequestProperties : SecurityAlertSimulatorRequestProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAlertSimulatorBundlesRequestProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityAlertSimulatorBundlesRequestProperties() : base(default(SecurityCenterKind)) { }
        /// <summary>
        /// Gets the Bundles value preserved from the previous public API surface.
        /// </summary>
        public IList<SecurityAlertSimulatorBundleType> Bundles { get; } = new List<SecurityAlertSimulatorBundleType>();
    }
}
