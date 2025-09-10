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
    /// A class representing the NetworkCloudClusterMetricsConfiguration data model.
    /// ClusterMetricsConfiguration represents the metrics configuration of an on-premises Network Cloud cluster.
    /// </summary>
    public partial class NetworkCloudClusterMetricsConfigurationData : TrackedResourceData{
       // <summary> Initializes a new instance of <see cref="NetworkCloudClusterMetricsConfigurationData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="collectionInterval"> The interval in minutes by which metrics will be collected. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> is null. </exception>
        public NetworkCloudClusterMetricsConfigurationData(AzureLocation location, ExtendedLocation extendedLocation, long collectionInterval)
            : this(location, collectionInterval, extendedLocation)
        {
        }
    }
}
