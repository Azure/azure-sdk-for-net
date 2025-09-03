// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudKubernetesCluster data model.
    /// KubernetesCluster represents the Kubernetes cluster hosted on Network Cloud.
    /// </summary>
    public partial class NetworkCloudKubernetesClusterData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudKubernetesClusterData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="controlPlaneNodeConfiguration"> The defining characteristics of the control plane for this Kubernetes Cluster. </param>
        /// <param name="initialAgentPoolConfigurations"> The agent pools that are created with this Kubernetes cluster for running critical system services and workloads. This data in this field is only used during creation, and the field will be empty following the creation of the Kubernetes Cluster. After creation, the management of agent pools is done using the agentPools sub-resource. </param>
        /// <param name="kubernetesVersion"> The Kubernetes version for this cluster. </param>
        /// <param name="networkConfiguration"> The configuration of the Kubernetes cluster networking, including the attachment of networks that span the cluster. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="controlPlaneNodeConfiguration"/>, <paramref name="initialAgentPoolConfigurations"/>, <paramref name="kubernetesVersion"/> or <paramref name="networkConfiguration"/> is null. </exception>
        public NetworkCloudKubernetesClusterData(AzureLocation location, ExtendedLocation extendedLocation, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, KubernetesClusterNetworkConfiguration networkConfiguration)
            : this(location, controlPlaneNodeConfiguration, initialAgentPoolConfigurations, kubernetesVersion, networkConfiguration, extendedLocation)
        {
        }
    }
}
