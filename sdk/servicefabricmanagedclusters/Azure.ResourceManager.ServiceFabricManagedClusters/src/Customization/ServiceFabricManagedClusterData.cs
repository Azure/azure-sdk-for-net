// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedClusterData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ServiceFabricManagedClusterData. </summary>
        /// <param name="location"> The location. </param>
        public ServiceFabricManagedClusterData(AzureLocation location) : this(location, new ServiceFabricManagedClustersSku(ServiceFabricManagedClustersSkuName.Basic))
        {
        }

        /// <summary> Initializes a new instance of ServiceFabricManagedClusterData. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The SKU. </param>
        public ServiceFabricManagedClusterData(AzureLocation location, ServiceFabricManagedClustersSku sku) : base(location)
        {
            Properties = new ManagedClusterProperties();
            Sku = sku;
        }
    }
}
