// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudCluster data model.
    /// Cluster represents the on-premises Network Cloud cluster.
    /// </summary>
    public partial class NetworkCloudClusterData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudClusterData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster manager associated with the cluster. </param>
        /// <param name="aggregatorOrSingleRackDefinition"> The rack definition that is intended to reflect only a single rack in a single rack cluster, or an aggregator rack in a multi-rack cluster. </param>
        /// <param name="clusterType"> The type of rack configuration for the cluster. </param>
        /// <param name="clusterVersion"> The current runtime version of the cluster. </param>
        /// <param name="networkFabricId"> The resource ID of the Network Fabric associated with the cluster. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="aggregatorOrSingleRackDefinition"/>, <paramref name="clusterVersion"/> or <paramref name="networkFabricId"/> is null. </exception>
        public NetworkCloudClusterData(AzureLocation location, ExtendedLocation extendedLocation, NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, ClusterType clusterType, string clusterVersion, ResourceIdentifier networkFabricId)
            : this(location, aggregatorOrSingleRackDefinition, clusterType, clusterVersion, networkFabricId, extendedLocation)
        {
        }
    }
}
