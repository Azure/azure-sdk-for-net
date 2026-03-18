// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.NetworkCloud
{
    // CodeGenSuppress for AadAdminGroupObjectIds: old API had a setter; new generated code is get-only.
    // After regeneration, only the custom property below will remain.
    [CodeGenSuppress("AadAdminGroupObjectIds")]
    public partial class NetworkCloudKubernetesClusterData
    {
        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudKubernetesClusterData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudKubernetesClusterData(AzureLocation location, ExtendedLocation extendedLocation, ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, IEnumerable<InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, KubernetesClusterNetworkConfiguration networkConfiguration)
            : this(location, controlPlaneNodeConfiguration, initialAgentPoolConfigurations, kubernetesVersion, networkConfiguration, extendedLocation) { }

        // Backward compat: old API had a setter for AadAdminGroupObjectIds.
        /// <summary> The list of Azure Active Directory group object IDs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterProperties();
                }
                var list = Properties.AadAdminGroupObjectIds;
                list.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        list.Add(item);
                    }
                }
            }
        }
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
