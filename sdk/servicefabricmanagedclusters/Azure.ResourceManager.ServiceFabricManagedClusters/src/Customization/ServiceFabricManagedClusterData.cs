// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
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

        // Customization rationale:
        //   The previous GA exposed `SkuName` (Nullable<ServiceFabricManagedClustersSkuName>) as a flattened
        //   property on this resource data class. The current emitter no longer flattens `Sku` (it remains
        //   an internal property), so we expose a public, non-nullable `ManagedClustersSkuName` flattened
        //   accessor as the new clean surface, and keep the legacy nullable `SkuName` as an [Obsolete]
        //   backward-compatibility shim.

        /// <summary> Sku Name. </summary>
        public ServiceFabricManagedClustersSkuName ManagedClustersSkuName
        {
            get => Sku is null ? default : Sku.Name;
            set => Sku = new ServiceFabricManagedClustersSku(value);
        }

        /// <summary>
        /// [Obsolete] Backward-compatibility shim. Use <see cref="ManagedClustersSkuName"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been renamed to ManagedClustersSkuName.")]
        public ServiceFabricManagedClustersSkuName? SkuName
        {
            get => Sku is null ? default(ServiceFabricManagedClustersSkuName?) : Sku.Name;
            set => Sku = value.HasValue ? new ServiceFabricManagedClustersSku(value.Value) : default;
        }
    }
}
