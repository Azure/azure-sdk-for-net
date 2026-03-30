// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.NetworkCloud
{
    // Customization: Suppresses the generated constructor (which uses ARM common ExtendedLocation)
    // and provides a custom constructor accepting the local ExtendedLocation type.
    // Also exposes a local ExtendedLocation property for backward compatibility.
    // AadAdminGroupObjectIds provides a flat getter delegating to
    // Properties.AadAdminGroupObjectIds, and a hidden setter that maps to
    // Properties.AadConfiguration.AdminGroupObjectIds.
    [CodeGenSuppress("NetworkCloudKubernetesClusterData", typeof(AzureLocation), typeof(ControlPlaneNodeConfiguration), typeof(IEnumerable<InitialAgentPoolConfiguration>), typeof(string), typeof(KubernetesClusterNetworkConfiguration), typeof(ExtendedLocation))]
    public partial class NetworkCloudKubernetesClusterData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudKubernetesClusterData"/>. </summary>
        public NetworkCloudKubernetesClusterData(AzureLocation location, ExtendedLocation extendedLocation, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, KubernetesClusterNetworkConfiguration networkConfiguration)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(controlPlaneNodeConfiguration, nameof(controlPlaneNodeConfiguration));
            Argument.AssertNotNull(initialAgentPoolConfigurations, nameof(initialAgentPoolConfigurations));
            Argument.AssertNotNull(kubernetesVersion, nameof(kubernetesVersion));
            Argument.AssertNotNull(networkConfiguration, nameof(networkConfiguration));
            Properties = new KubernetesClusterProperties(controlPlaneNodeConfiguration, initialAgentPoolConfigurations, kubernetesVersion, networkConfiguration);
            ExtendedLocation = extendedLocation;
        }

        // Flat accessor: getter delegates to Properties.AadAdminGroupObjectIds,
        // setter maps to Properties.AadConfiguration.AdminGroupObjectIds.
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
                // Re-create AadConfiguration with the provided value to avoid NullReferenceException
                // when the parameterless NetworkCloudAadConfiguration() constructor leaves AdminGroupObjectIds null.
                Properties.AadConfiguration = new NetworkCloudAadConfiguration(value ?? System.Array.Empty<string>());
            }
        }
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
