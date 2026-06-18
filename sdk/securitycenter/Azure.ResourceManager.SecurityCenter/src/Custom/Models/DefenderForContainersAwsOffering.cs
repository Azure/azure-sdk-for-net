// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the DefenderForContainersAwsOffering class.
    /// </summary>
    public partial class DefenderForContainersAwsOffering
    {
        /// <summary>
        /// Gets or sets the IsAutoProvisioningEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsAutoProvisioningEnabled { get; set; }
        /// <summary>
        /// Gets or sets the IsContainerVulnerabilityAssessmentEnabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsContainerVulnerabilityAssessmentEnabled { get; set; }
        /// <summary>
        /// Gets or sets the ContainerVulnerabilityAssessmentCloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ContainerVulnerabilityAssessmentCloudRoleArn { get; set; }
        /// <summary>
        /// Gets or sets the ContainerVulnerabilityAssessmentTaskCloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ContainerVulnerabilityAssessmentTaskCloudRoleArn { get; set; }
        /// <summary>
        /// Gets or sets the KubernetesScubaReaderCloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KubernetesScubaReaderCloudRoleArn { get; set; }
        /// <summary>
        /// Gets or sets the ScubaExternalId value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ScubaExternalId { get; set; }
    }
}
