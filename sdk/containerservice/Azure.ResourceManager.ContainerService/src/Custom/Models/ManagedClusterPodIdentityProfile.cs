// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterPodIdentityProfile
    {
        /// <summary> Whether pod identity is allowed to run on clusters with Kubenet networking. </summary>
        [WirePath("allowNetworkPluginKubenet")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? AllowNetworkPluginKubenet { get => IsKubenetNetworkPluginAllowed; set => IsKubenetNetworkPluginAllowed = value; }
    }
}
