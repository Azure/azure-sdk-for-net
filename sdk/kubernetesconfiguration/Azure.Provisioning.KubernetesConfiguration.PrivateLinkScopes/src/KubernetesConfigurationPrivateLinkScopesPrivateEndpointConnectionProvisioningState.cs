// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes
{
    /// <summary> The current provisioning state. </summary>
    [CodeGenType("KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnectionProvisioningState")]
    public enum KubernetesConfigurationPrivateLinkScopesPrivateEndpointConnectionProvisioningState
    {
        /// <summary> Connection has been provisioned. </summary>
        Succeeded,
        /// <summary> Connection is being created. </summary>
        Creating,
        /// <summary> Connection is being deleted. </summary>
        Deleting,
        /// <summary> Connection provisioning has failed. </summary>
        Failed
    }
}
