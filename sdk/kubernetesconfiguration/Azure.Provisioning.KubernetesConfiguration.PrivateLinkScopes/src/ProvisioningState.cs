// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes
{
    /// <summary> The provisioning state of the resource. </summary>
    [CodeGenType("ProvisioningState")]
    public enum ProvisioningState
    {
        /// <summary> Succeeded. </summary>
        Succeeded,
        /// <summary> Failed. </summary>
        Failed,
        /// <summary> Canceled. </summary>
        Canceled,
        /// <summary> Creating. </summary>
        Creating,
        /// <summary> Updating. </summary>
        Updating,
        /// <summary> Deleting. </summary>
        Deleting
    }
}
