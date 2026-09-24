// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudClusterPatch
    {
        /// <summary> The mode of operation for runtime protection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RuntimeProtectionEnforcementLevel? RuntimeProtectionEnforcementLevel
        {
            get => RuntimeProtectionConfiguration?.EnforcementLevel;
            set
            {
                if (RuntimeProtectionConfiguration == null)
                    RuntimeProtectionConfiguration = new RuntimeProtectionConfigurationPatch();
                RuntimeProtectionConfiguration.EnforcementLevel = value;
            }
        }

        // NOTE: The following properties preserve the pre-1.4.0 public types for backward
        // compatibility. The underlying wire representation is unchanged; only the strongly-typed
        // "*Patch" shapes introduced by the generator differ, and are translated via
        // NetworkCloudPatchCompatibility.

        /// <summary> The rack definition that is intended to reflect only a single rack in a single rack cluster, or an aggregator rack in a multi-rack cluster. </summary>
        [CodeGenMember("AggregatorOrSingleRackDefinition")]
        public NetworkCloudRackDefinition AggregatorOrSingleRackDefinition
        {
            get => Properties is null ? null : NetworkCloudPatchCompatibility.ToClassic(Properties.AggregatorOrSingleRackDefinition);
            set
            {
                if (Properties is null)
                {
                    Properties = new ClusterPatchProperties();
                }
                Properties.AggregatorOrSingleRackDefinition = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> Field Deprecated: Use managed identity to provide cluster privileges. The service principal to be used by the cluster during Arc Appliance installation. </summary>
        [CodeGenMember("ClusterServicePrincipal")]
        public ServicePrincipalInformation ClusterServicePrincipal
        {
            get => Properties is null ? null : NetworkCloudPatchCompatibility.ToClassic(Properties.ClusterServicePrincipal);
            set
            {
                if (Properties is null)
                {
                    Properties = new ClusterPatchProperties();
                }
                Properties.ClusterServicePrincipal = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> The validation threshold indicating the allowable failures of compute machines during environment validation and deployment. </summary>
        [CodeGenMember("ComputeDeploymentThreshold")]
        public ValidationThreshold ComputeDeploymentThreshold
        {
            get => Properties is null ? null : NetworkCloudPatchCompatibility.ToClassic(Properties.ComputeDeploymentThreshold);
            set
            {
                if (Properties is null)
                {
                    Properties = new ClusterPatchProperties();
                }
                Properties.ComputeDeploymentThreshold = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster. </summary>
        [CodeGenMember("ComputeRackDefinitions")]
        public IList<NetworkCloudRackDefinition> ComputeRackDefinitions
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new ClusterPatchProperties();
                }
                return new NetworkCloudRackDefinitionCompatList(Properties.ComputeRackDefinitions);
            }
        }

        /// <summary> The configuration for use of a key vault to store secrets for later retrieval by the operator. </summary>
        [CodeGenMember("SecretArchive")]
        public ClusterSecretArchive SecretArchive
        {
            get => Properties is null ? null : NetworkCloudPatchCompatibility.ToClassic(Properties.SecretArchive);
            set
            {
                if (Properties is null)
                {
                    Properties = new ClusterPatchProperties();
                }
                Properties.SecretArchive = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> The strategy for updating the cluster. </summary>
        [CodeGenMember("UpdateStrategy")]
        public ClusterUpdateStrategy UpdateStrategy
        {
            get => Properties is null ? null : NetworkCloudPatchCompatibility.ToClassic(Properties.UpdateStrategy);
            set
            {
                if (Properties is null)
                {
                    Properties = new ClusterPatchProperties();
                }
                Properties.UpdateStrategy = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }
    }
}
