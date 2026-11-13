// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterApiServerAccessProfile
    {
        /// <summary> Whether to disable run command for the cluster or not. </summary>
        [WirePath("disableRunCommand")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableRunCommand { get => IsRunCommandDisabled; set => IsRunCommandDisabled = value; }

        /// <summary> Whether to create the cluster as a private cluster or not. </summary>
        [WirePath("enablePrivateCluster")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnablePrivateCluster { get => IsPrivateClusterEnabled; set => IsPrivateClusterEnabled = value; }

        /// <summary> Whether to create additional public FQDN for private cluster or not. </summary>
        [WirePath("enablePrivateClusterPublicFQDN")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnablePrivateClusterPublicFqdn { get => IsPrivateClusterPublicFqdnEnabled; set => IsPrivateClusterPublicFqdnEnabled = value; }

        /// <summary> Whether to enable apiserver vnet integration for the cluster or not. </summary>
        [WirePath("enableVnetIntegration")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableVnetIntegration { get => IsVnetIntegrationEnabled; set => IsVnetIntegrationEnabled = value; }
    }
}
