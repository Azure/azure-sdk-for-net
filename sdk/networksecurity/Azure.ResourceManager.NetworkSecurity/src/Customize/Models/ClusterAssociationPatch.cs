// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetworkSecurity.Models
{
    public partial class ClusterAssociationPatch
    {
        // The generated AddTag/SetTags/RemoveTag fallback calls `new ClusterAssociationPatch(current.Properties)`,
        // but the PATCH body uses ClusterAssociationUpdateProperties. Only carry over clusterResourceId, which
        // ARM needs for linked authorization; omitting sku and workloadClusterGatewayIP leaves them unchanged.
        internal ClusterAssociationPatch(ClusterAssociationProperties properties)
            : this(new ClusterAssociationUpdateProperties { ClusterResourceId = properties?.ClusterResourceId })
        {
        }
    }
}
