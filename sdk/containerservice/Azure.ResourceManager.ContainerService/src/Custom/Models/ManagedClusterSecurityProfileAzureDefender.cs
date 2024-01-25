// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Azure Defender settings for the security profile. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ManagedClusterSecurityProfileAzureDefender
    {
        /// <summary> Initializes a new instance of ManagedClusterSecurityProfileAzureDefender. </summary>
        public ManagedClusterSecurityProfileAzureDefender()
        {
        }

        /// <summary> Whether to enable Azure Defender. </summary>
        public bool? IsEnabled { get; set; }
        /// <summary> Resource ID of the Log Analytics workspace to be associated with Azure Defender.  When Azure Defender is enabled, this field is required and must be a valid workspace resource ID. When Azure Defender is disabled, leave the field empty. </summary>
        public ResourceIdentifier LogAnalyticsWorkspaceResourceId { get; set; }
    }
}
