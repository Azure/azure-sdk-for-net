// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

// NOTE: These properties must remain virtual to preserve the prior public API.
// The generator currently emits non-virtual members for this model; remove this customization
// together with the model factory workaround when https://github.com/Azure/azure-sdk-for-net/issues/59326 is fixed.
namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> The common properties of a cluster. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("VsanDatastoreName", typeof(string))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ClusterSize", typeof(int?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ProvisioningState", typeof(AvsPrivateCloudClusterProvisioningState?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ClusterId", typeof(int?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Hosts", typeof(IList<string>))]
    public partial class CommonClusterProperties
    {
        /// <summary> The cluster size. </summary>
        public virtual int? ClusterSize { get; set; }

        /// <summary> The state of the cluster provisioning. </summary>
        public virtual AvsPrivateCloudClusterProvisioningState? ProvisioningState { get; private set; }

        /// <summary> The identity. </summary>
        public virtual int? ClusterId { get; private set; }

        /// <summary> The hosts. </summary>
        public virtual IList<string> Hosts { get; private set; }
    }
}
