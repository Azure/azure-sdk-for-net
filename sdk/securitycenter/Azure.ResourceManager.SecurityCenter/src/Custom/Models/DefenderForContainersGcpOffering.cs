// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the DefenderForContainersGcpOffering class.
    /// </summary>
    public partial class DefenderForContainersGcpOffering
    {
        /// <summary>
        /// Gets or sets the IsAuditLogsAutoProvisioningEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsAuditLogsAutoProvisioningEnabled { get; set; }
        /// <summary>
        /// Gets or sets the IsDefenderAgentAutoProvisioningEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsDefenderAgentAutoProvisioningEnabled { get; set; }
        /// <summary>
        /// Gets or sets the IsPolicyAgentAutoProvisioningEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPolicyAgentAutoProvisioningEnabled { get; set; }
    }
}
