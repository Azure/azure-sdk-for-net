// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudRackDefinition AggregatorOrSingleRackDefinition
        {
            get
            {
                NetworkCloudRackDefinition value = NetworkCloudPatchCompatibility.ToClassic(AggregatorOrSingleRackDefinitionPatch);
                if (value is not null)
                {
                    AggregatorOrSingleRackDefinitionPatch = NetworkCloudPatchCompatibility.ToPatch(value);
                }
                return value;
            }
            set
            {
                AggregatorOrSingleRackDefinitionPatch = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> Field Deprecated: Use managed identity to provide cluster privileges. The service principal to be used by the cluster during Arc Appliance installation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServicePrincipalInformation ClusterServicePrincipal
        {
            get
            {
                ServicePrincipalInformation value = NetworkCloudPatchCompatibility.ToClassic(ClusterServicePrincipalPatch);
                if (value is not null)
                {
                    ClusterServicePrincipalPatch = NetworkCloudPatchCompatibility.ToPatch(value);
                }
                return value;
            }
            set
            {
                ClusterServicePrincipalPatch = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> The validation threshold indicating the allowable failures of compute machines during environment validation and deployment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidationThreshold ComputeDeploymentThreshold
        {
            get
            {
                ValidationThreshold value = NetworkCloudPatchCompatibility.ToClassic(ComputeDeploymentThresholdPatch);
                if (value is not null)
                {
                    ComputeDeploymentThresholdPatch = NetworkCloudPatchCompatibility.ToPatch(value);
                }
                return value;
            }
            set
            {
                ComputeDeploymentThresholdPatch = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<NetworkCloudRackDefinition> ComputeRackDefinitions
        {
            get => new NetworkCloudRackDefinitionCompatList(ComputeRackDefinitionsPatch);
        }

        /// <summary> The configuration for use of a key vault to store secrets for later retrieval by the operator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClusterSecretArchive SecretArchive
        {
            get
            {
                ClusterSecretArchive value = NetworkCloudPatchCompatibility.ToClassic(SecretArchivePatch);
                if (value is not null)
                {
                    SecretArchivePatch = NetworkCloudPatchCompatibility.ToPatch(value);
                }
                return value;
            }
            set
            {
                SecretArchivePatch = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }

        /// <summary> The strategy for updating the cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClusterUpdateStrategy UpdateStrategy
        {
            get
            {
                ClusterUpdateStrategy value = NetworkCloudPatchCompatibility.ToClassic(UpdateStrategyPatch);
                if (value is not null)
                {
                    UpdateStrategyPatch = NetworkCloudPatchCompatibility.ToPatch(value);
                }
                return value;
            }
            set
            {
                UpdateStrategyPatch = NetworkCloudPatchCompatibility.ToPatch(value);
            }
        }
    }
}
