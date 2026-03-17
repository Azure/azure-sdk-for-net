// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudClusterData
    {
        /// <summary> The mode of operation for runtime protection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RuntimeProtectionEnforcementLevel? RuntimeProtectionEnforcementLevel
        {
            get => RuntimeProtectionConfiguration?.EnforcementLevel;
            set
            {
                if (RuntimeProtectionConfiguration == null)
                    RuntimeProtectionConfiguration = new RuntimeProtectionConfiguration();
                RuntimeProtectionConfiguration.EnforcementLevel = value;
            }
        }

        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudClusterData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudClusterData(AzureLocation location, ExtendedLocation extendedLocation, NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, ClusterType clusterType, string clusterVersion, ResourceIdentifier networkFabricId)
            : this(location, aggregatorOrSingleRackDefinition, clusterType, clusterVersion, networkFabricId, extendedLocation) { }
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation
        {
            get => ExtendedLocationInternal is Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation custom
                ? custom
                : (ExtendedLocationInternal != null ? new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(ExtendedLocationInternal.Name, ExtendedLocationInternal.ExtendedLocationType?.ToString()) : null);
            set => ExtendedLocationInternal = value;
        }

        /// <summary> The extended location (custom location) that represents the cluster's control plane location. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ClusterExtendedLocation
        {
            get => ClusterExtendedLocationInternal is Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation custom
                ? custom
                : (ClusterExtendedLocationInternal != null ? new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(ClusterExtendedLocationInternal.Name, ClusterExtendedLocationInternal.ExtendedLocationType?.ToString()) : null);
        }

        /// <summary> Field Deprecated. The extended location (custom location) that represents the Hybrid AKS control plane location. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation HybridAksExtendedLocation
        {
            get => HybridAksExtendedLocationInternal is Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation custom
                ? custom
                : (HybridAksExtendedLocationInternal != null ? new Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation(HybridAksExtendedLocationInternal.Name, HybridAksExtendedLocationInternal.ExtendedLocationType?.ToString()) : null);
        }
    }
}
