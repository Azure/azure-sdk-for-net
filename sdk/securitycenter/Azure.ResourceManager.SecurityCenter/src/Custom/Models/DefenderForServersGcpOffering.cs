// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the DefenderForServersGcpOffering class.
    /// </summary>
    public partial class DefenderForServersGcpOffering
    {
        /// <summary>
        /// Gets or sets the VulnerabilityAssessmentAutoProvisioning value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning VulnerabilityAssessmentAutoProvisioning { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the AvailableSubPlanType value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType? AvailableSubPlanType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the IsArcAutoProvisioningEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsArcAutoProvisioningEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
