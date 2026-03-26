// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    [CodeGenSuppress("NetworkCloudClusterMetricsConfigurationData", typeof(AzureLocation), typeof(long), typeof(ExtendedLocation))]
    public partial class NetworkCloudClusterMetricsConfigurationData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudClusterMetricsConfigurationData"/>. </summary>
        public NetworkCloudClusterMetricsConfigurationData(AzureLocation location, ExtendedLocation extendedLocation, long collectionInterval)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Properties = new ClusterMetricsConfigurationProperties(collectionInterval);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
