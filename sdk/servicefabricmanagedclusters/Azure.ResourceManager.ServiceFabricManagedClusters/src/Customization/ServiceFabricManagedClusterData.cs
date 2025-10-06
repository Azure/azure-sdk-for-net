// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    /// <summary>
    /// A class representing the ServiceFabricManagedCluster data model.
    /// The managed cluster resource
    /// </summary>
    public partial class ServiceFabricManagedClusterData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ServiceFabricManagedClusterData. </summary>
        /// <param name="location"> The location. </param>
        public ServiceFabricManagedClusterData(AzureLocation location) : base(location)
        {
            Sku = new ServiceFabricManagedClustersSku(ServiceFabricManagedClustersSkuName.Basic);
            ClusterCertificateThumbprints = new ChangeTrackingList<BinaryData>();
            LoadBalancingRules = new ChangeTrackingList<ManagedClusterLoadBalancingRule>();
            NetworkSecurityRules = new ChangeTrackingList<ServiceFabricManagedNetworkSecurityRule>();
            Clients = new ChangeTrackingList<ManagedClusterClientCertificate>();
            FabricSettings = new ChangeTrackingList<ClusterFabricSettingsSection>();
            AddOnFeatures = new ChangeTrackingList<ManagedClusterAddOnFeature>();
            IPTags = new ChangeTrackingList<ManagedClusterIPTag>();
            AuxiliarySubnets = new ChangeTrackingList<ManagedClusterSubnet>();
            ServiceEndpoints = new ChangeTrackingList<ManagedClusterServiceEndpoint>();
        }
    }
}
