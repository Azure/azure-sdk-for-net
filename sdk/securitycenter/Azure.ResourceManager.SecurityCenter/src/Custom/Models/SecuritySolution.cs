// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the SecuritySolution class.
    /// </summary>
    public partial class SecuritySolution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySolution"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecuritySolution() { }
        /// <summary>
        /// Gets or sets the SecurityFamily value preserved from the previous public API surface.
        /// </summary>
        public SecurityFamily? SecurityFamily { get; set; }
        /// <summary>
        /// Gets or sets the ProvisioningState value preserved from the previous public API surface.
        /// </summary>
        public SecurityFamilyProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// Gets or sets the Template value preserved from the previous public API surface.
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Gets or sets the ProtectionStatus value preserved from the previous public API surface.
        /// </summary>
        public string ProtectionStatus { get; set; }
    }
}
