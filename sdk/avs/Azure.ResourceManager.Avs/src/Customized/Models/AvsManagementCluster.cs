// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Avs.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ClusterSize", typeof(int?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ProvisioningState", typeof(AvsPrivateCloudClusterProvisioningState?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ClusterId", typeof(int?))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Hosts", typeof(IList<string>))]
    public partial class AvsManagementCluster : CommonClusterProperties
    {
        /// <summary> Name of the vsan datastore associated with the cluster. </summary>
        public string VsanDatastoreName { get; set; }
    }
}
