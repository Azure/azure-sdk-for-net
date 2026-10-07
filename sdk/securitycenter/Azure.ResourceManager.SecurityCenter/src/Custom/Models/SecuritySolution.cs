// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    /// <summary>
    /// Provides a compatibility shim for the SecuritySolution class.
    /// </summary>
    public partial class SecuritySolution : ResourceData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySolution"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecuritySolution() { }

        internal SecuritySolution(SecuritySolutionData data) : base(data?.Id, data?.Name, data?.ResourceType ?? default, data?.SystemData)
        {
            Location = data?.Location;
            SecurityFamily = data?.SecurityFamily;
            ProvisioningState = data?.ProvisioningState is null ? default : new SecurityFamilyProvisioningState(data.ProvisioningState.Value.ToString());
            Template = data?.Template;
            ProtectionStatus = data?.ProtectionStatus;
        }

        /// <summary> Location where the resource is stored. </summary>
        public AzureLocation? Location { get; }

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
