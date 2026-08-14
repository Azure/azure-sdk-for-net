// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudClusterMetricsConfigurationData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudClusterMetricsConfigurationData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="collectionInterval"> The interval in minutes by which metrics will be collected. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudClusterMetricsConfigurationData(AzureLocation location, ExtendedLocation extendedLocation, long collectionInterval) : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));

            Properties = new ClusterMetricsConfigurationProperties(collectionInterval);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
