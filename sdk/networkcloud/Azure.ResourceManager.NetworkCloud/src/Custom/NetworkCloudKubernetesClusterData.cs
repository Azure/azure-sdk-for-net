// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudKubernetesClusterData(AzureLocation location, ExtendedLocation extendedLocation, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, KubernetesClusterNetworkConfiguration networkConfiguration) : base(location)
        {
            Argument.AssertNotNull(controlPlaneNodeConfiguration, nameof(controlPlaneNodeConfiguration));
            Argument.AssertNotNull(initialAgentPoolConfigurations, nameof(initialAgentPoolConfigurations));
            Argument.AssertNotNull(kubernetesVersion, nameof(kubernetesVersion));
            Argument.AssertNotNull(networkConfiguration, nameof(networkConfiguration));
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));

            Properties = new KubernetesClusterProperties(controlPlaneNodeConfiguration, initialAgentPoolConfigurations, kubernetesVersion, networkConfiguration);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The list of Azure Active Directory group object IDs. </summary>
        public IList<string> AadAdminGroupObjectIds
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterProperties();
                }
                return Properties.AadAdminGroupObjectIds;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterProperties();
                }
                Properties.AadConfiguration = new NetworkCloudAadConfiguration(value ?? System.Array.Empty<string>());
            }
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
