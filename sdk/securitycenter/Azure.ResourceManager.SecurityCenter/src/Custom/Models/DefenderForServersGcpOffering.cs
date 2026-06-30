// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the DefenderForServersGcpOffering class.
    /// </summary>
    public partial class DefenderForServersGcpOffering
    {
        /// <summary>
        /// Gets or sets the VulnerabilityAssessmentAutoProvisioning value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get; set; }
        /// <summary>
        /// Gets or sets the AvailableSubPlanType value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvailableSubPlanType? AvailableSubPlanType { get; set; }
        /// <summary>
        /// Gets or sets the IsArcAutoProvisioningEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsArcAutoProvisioningEnabled { get; set; }
    }
}
