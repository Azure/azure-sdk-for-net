// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes
{
    /// <summary> The private endpoint connection status. </summary>
    [CodeGenType("KubernetesConfigurationPrivateLinkScopesPrivateEndpointServiceConnectionStatus")]
    public enum KubernetesConfigurationPrivateLinkScopesPrivateEndpointServiceConnectionStatus
    {
        /// <summary> Connection waiting for approval or rejection. </summary>
        Pending,
        /// <summary> Connection approved. </summary>
        Approved,
        /// <summary> Connection rejected. </summary>
        Rejected
    }
}
