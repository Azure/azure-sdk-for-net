// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes
{
    /// <summary> The network access policy for Azure Arc agents. </summary>
    [CodeGenType("PublicNetworkAccessType")]
    public enum PublicNetworkAccessType
    {
        /// <summary> Allows communication over public and private endpoints. </summary>
        Enabled,
        /// <summary> Requires communication over private endpoints. </summary>
        Disabled
    }
}
