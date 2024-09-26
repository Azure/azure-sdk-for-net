// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Avs
{
    /// <summary>
    /// A class representing the AvsPrivateCloudCluster data model.
    /// A cluster resource.
    /// </summary>
    public partial class AvsPrivateCloudClusterData : ResourceData
    {
        /// <summary> The name of the SKU. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SkuName
        {
            get => Sku is null ? default : Sku.Name;
            set => Sku = new AvsSku(value);
        }

        /// <summary> Initializes a new instance of <see cref="AvsPrivateCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AvsPrivateCloudClusterData(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            ResourceManager.Models.SystemData systemData = null,
            AvsSku sku = null,
            int? clusterSize = null,
            AvsPrivateCloudClusterProvisioningState? provisioningState = null,
            int? clusterId = null,
            IList<string> hosts = null)
            : this(id, name, resourceType, systemData, sku, clusterSize, provisioningState, clusterId, hosts, null, null)
        {
        }
    }
}