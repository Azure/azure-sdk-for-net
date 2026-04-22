// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudClusterData(AzureLocation location, ExtendedLocation extendedLocation, NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, ClusterType clusterType, string clusterVersion, ResourceIdentifier networkFabricId) : base(location)
        {
            Argument.AssertNotNull(aggregatorOrSingleRackDefinition, nameof(aggregatorOrSingleRackDefinition));
            Argument.AssertNotNull(clusterVersion, nameof(clusterVersion));
            Argument.AssertNotNull(networkFabricId, nameof(networkFabricId));
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));

            Properties = new ClusterProperties(aggregatorOrSingleRackDefinition, clusterType, clusterVersion, networkFabricId);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The mode of operation for runtime protection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RuntimeProtectionEnforcementLevel? RuntimeProtectionEnforcementLevel
        {
            get => RuntimeProtectionConfiguration is null ? default : RuntimeProtectionConfiguration.EnforcementLevel;
            set
            {
                if (RuntimeProtectionConfiguration is null)
                    RuntimeProtectionConfiguration = new RuntimeProtectionConfiguration();
                RuntimeProtectionConfiguration.EnforcementLevel = value;
            }
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }

        /// <summary> The extended location (custom location) that represents the cluster's control plane location. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ClusterExtendedLocation
        {
            get
            {
                var baseLoc = Properties?.ClusterExtendedLocation;
                if (baseLoc == null) return null;
                return new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(baseLoc.Name, baseLoc.ExtendedLocationType?.ToString());
            }
        }

        /// <summary> Field Deprecated. The extended location (custom location) that represents the Hybrid AKS control plane location. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation HybridAksExtendedLocation
        {
            get
            {
                var baseLoc = Properties?.HybridAksExtendedLocation;
                if (baseLoc == null) return null;
                return new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(baseLoc.Name, baseLoc.ExtendedLocationType?.ToString());
            }
        }
    }
}
