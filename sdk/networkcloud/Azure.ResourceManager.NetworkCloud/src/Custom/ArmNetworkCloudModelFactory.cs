// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // The generated factory retains the synthesized flattened name even when CodeGenMember renames the property.
    [CodeGenSuppress("NetworkCloudClusterManagerPatch", typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>), typeof(int?))]
    // Keep the released parameter prefix so null URI arguments do not become ambiguous with the new string parameter.
    [CodeGenSuppress("SecretArchiveSettings", typeof(ManagedServiceIdentitySelector), typeof(string), typeof(SecretArchiveProviderConfiguration), typeof(Uri))]
    // Append new fields and preserve released optionality instead of shifting positional arguments.
    [CodeGenSuppress("NetworkCloudClusterManagerData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ResourceIdentifier), typeof(IEnumerable<string>), typeof(IEnumerable<ClusterAvailableVersion>), typeof(ClusterManagerDetailedStatus?), typeof(string), typeof(ResourceIdentifier), typeof(ManagedResourceGroupConfiguration), typeof(Resources.Models.ExtendedLocation), typeof(ClusterManagerProvisioningState?), typeof(int?), typeof(string), typeof(ResourceIdentifier), typeof(ETag?), typeof(ManagedServiceIdentity), typeof(NetworkCloudDeploymentType?))]
    [CodeGenSuppress("NetworkCloudClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(NetworkCloudRackDefinition), typeof(AnalyticsOutputSettings), typeof(ResourceIdentifier), typeof(string), typeof(ServicePrincipalInformation), typeof(ClusterType), typeof(string), typeof(CommandOutputSettings), typeof(ValidationThreshold), typeof(IEnumerable<NetworkCloudRackDefinition>), typeof(ManagedResourceGroupConfiguration), typeof(ResourceIdentifier), typeof(RuntimeProtectionConfiguration), typeof(ClusterSecretArchive), typeof(SecretArchiveSettings), typeof(ClusterUpdateStrategy), typeof(IEnumerable<NetworkCloudActionState>), typeof(IEnumerable<ClusterAvailableUpgradeVersion>), typeof(ClusterCapacity), typeof(ClusterConnectionStatus?), typeof(Resources.Models.ExtendedLocation), typeof(ClusterManagerConnectionStatus?), typeof(ResourceIdentifier), typeof(ClusterDetailedStatus?), typeof(string), typeof(NetworkCloudCertificateInfo), typeof(Resources.Models.ExtendedLocation), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(long?), typeof(DateTimeOffset?), typeof(IEnumerable<ResourceIdentifier>), typeof(ClusterProvisioningState?), typeof(VulnerabilityScanningSettingsContainerScan?), typeof(ETag?), typeof(ExtendedLocation), typeof(ManagedServiceIdentity), typeof(NetworkCloudDeploymentType?))]
    public static partial class ArmNetworkCloudModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch"/>. </summary>
        /// <param name="identity"> The identity for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="rolloutRing"> The relative ordering group used to apply software updates to associated clusters. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch"/> instance for mocking. </returns>
        public static NetworkCloudClusterManagerPatch NetworkCloudClusterManagerPatch(ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default, int? rolloutRing = default)
        {
            return new NetworkCloudClusterManagerPatch(
                identity,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                rolloutRing is null ? default : new ClusterManagerPatchProperties(rolloutRing, default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings"/>. </summary>
        /// <param name="associatedIdentity"> The selection of the managed identity to use with this vault URI. The identity type must be either system assigned or user assigned. </param>
        /// <param name="vaultUri"> The URI of the secret archive endpoint. The URI must use the `https://` scheme. </param>
        /// <param name="encryptionPublicKey"> The public key used to encrypt secrets before they are written to the secret archive. Expected encoding is a PEM-encoded RSA public key with a minimum key size of 3072 bits. Additional key formats or sizes may be supported in future versions. </param>
        /// <param name="providerConfiguration"> The configuration indicating the use of self-supplied secret archive software. Specification of a provider configuration indicates that the provided configuration will be used. Exclusion of any providerConfiguration indicates the use of Azure Key Vault. If providerConfiguration is included in a PATCH, the body must be a complete, valid configuration for the chosen provider, including all fields required for that provider; omit providerConfiguration from PATCH bodies that do not change it. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings"/> instance for mocking. </returns>
        public static SecretArchiveSettings SecretArchiveSettings(ManagedServiceIdentitySelector associatedIdentity = default, Uri vaultUri = default, string encryptionPublicKey = default, SecretArchiveProviderConfiguration providerConfiguration = default)
        {
            return new SecretArchiveSettings(associatedIdentity, encryptionPublicKey, providerConfiguration, vaultUri, default);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="analyticsWorkspaceId"> The resource ID of the Log Analytics workspace that is used for the logs collection. </param>
        /// <param name="availabilityZones"> The Azure availability zones within the region that will be used to support the cluster manager resource. </param>
        /// <param name="clusterVersions"> The list of the cluster versions the manager supports. It is used as input in clusterVersion property of a cluster resource. </param>
        /// <param name="detailedStatus"> The detailed status that provides additional information about the cluster manager. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the current detailed status. </param>
        /// <param name="fabricControllerId"> The resource ID of the fabric controller that has one to one mapping with the cluster manager. </param>
        /// <param name="managedResourceGroupConfiguration"> The configuration of the managed resource group associated with the resource. </param>
        /// <param name="managerExtendedLocation"> The extended location (custom location) that represents the cluster manager's control plane location. This extended location is used when creating cluster and rack manifest resources. </param>
        /// <param name="provisioningState"> The provisioning state of the cluster manager. </param>
        /// <param name="vmSize"> The size of the Azure virtual machines to use for hosting the cluster manager resource. </param>
        /// <param name="relayNamespaceId"> The resource ID of the Azure relay namespace managed by the cluster manager. </param>
        /// <param name="eTag"> The entity tag used for comparing versions of the resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="kind"> The kind of the cluster manager. </param>
        /// <param name="rolloutRing"> The relative ordering group used to apply software updates to associated clusters. The minimum accepted value is 1; the service enforces the upper bound currently in effect, which may change over time. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData"/> instance for mocking. </returns>
        public static NetworkCloudClusterManagerData NetworkCloudClusterManagerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ResourceIdentifier analyticsWorkspaceId, IEnumerable<string> availabilityZones, IEnumerable<ClusterAvailableVersion> clusterVersions, ClusterManagerDetailedStatus? detailedStatus, string detailedStatusMessage, ResourceIdentifier fabricControllerId, ManagedResourceGroupConfiguration managedResourceGroupConfiguration, Resources.Models.ExtendedLocation managerExtendedLocation, ClusterManagerProvisioningState? provisioningState, string vmSize, ResourceIdentifier relayNamespaceId, ETag? eTag, ManagedServiceIdentity identity, NetworkCloudDeploymentType? kind = default, int? rolloutRing = default)
        {
            return new NetworkCloudClusterManagerData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                analyticsWorkspaceId is null && availabilityZones is null && clusterVersions is null && detailedStatus is null && detailedStatusMessage is null && fabricControllerId is null && managedResourceGroupConfiguration is null && managerExtendedLocation is null && provisioningState is null && relayNamespaceId is null && rolloutRing is null && vmSize is null ? default : new ClusterManagerProperties(
                    analyticsWorkspaceId,
                    (availabilityZones ?? new ChangeTrackingList<string>()).ToList(),
                    (clusterVersions ?? new ChangeTrackingList<ClusterAvailableVersion>()).ToList(),
                    detailedStatus,
                    detailedStatusMessage,
                    fabricControllerId,
                    managedResourceGroupConfiguration,
                    managerExtendedLocation,
                    provisioningState,
                    relayNamespaceId is null ? default : new ClusterManagerRelayConfiguration(relayNamespaceId, default),
                    rolloutRing,
                    vmSize,
                    default),
                eTag,
                identity,
                kind,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="aggregatorOrSingleRackDefinition"> The rack definition that is intended to reflect only a single rack in a single rack cluster, or an aggregator rack in a multi-rack cluster. </param>
        /// <param name="analyticsOutputSettings"> The settings for the log analytics workspace used for output of logs from this cluster. </param>
        /// <param name="analyticsWorkspaceId"> Field Deprecated. The resource ID of the Log Analytics Workspace that will be used for storing relevant logs. </param>
        /// <param name="clusterLocation"> The customer-provided location information to identify where the cluster resides. </param>
        /// <param name="clusterServicePrincipal"> Field Deprecated: Use managed identity to provide cluster privileges. The service principal to be used by the cluster during Arc Appliance installation. </param>
        /// <param name="clusterType"> The type of rack configuration for the cluster. </param>
        /// <param name="clusterVersion"> The current runtime version of the cluster. </param>
        /// <param name="commandOutputSettings"> The settings for commands run in this cluster, such as bare metal machine run read only commands and data extracts. </param>
        /// <param name="computeDeploymentThreshold"> The validation threshold indicating the allowable failures of compute machines during environment validation and deployment. </param>
        /// <param name="computeRackDefinitions"> The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster. </param>
        /// <param name="managedResourceGroupConfiguration"> The configuration of the managed resource group associated with the resource. </param>
        /// <param name="networkFabricId"> The resource ID of the Network Fabric associated with the cluster. </param>
        /// <param name="runtimeProtectionConfiguration"> The settings for cluster runtime protection. </param>
        /// <param name="secretArchive"> The configuration for use of a key vault to store secrets for later retrieval by the operator. </param>
        /// <param name="secretArchiveSettings"> The settings for the secret archive used to hold credentials for the cluster. </param>
        /// <param name="updateStrategy"> The strategy for updating the cluster. </param>
        /// <param name="actionStates"> The current state of any in progress or completed actions. The most recent known instance of each action type is shown. </param>
        /// <param name="availableUpgradeVersions"> The list of cluster runtime version upgrades available for this cluster. </param>
        /// <param name="clusterCapacity"> The capacity supported by this cluster. </param>
        /// <param name="clusterConnectionStatus"> The latest heartbeat status between the cluster manager and the cluster. </param>
        /// <param name="clusterExtendedLocation"> The extended location (custom location) that represents the cluster's control plane location. This extended location is used to route the requests of child objects of the cluster that are handled by the platform operator. </param>
        /// <param name="clusterManagerConnectionStatus"> The latest connectivity status between cluster manager and the cluster. </param>
        /// <param name="clusterManagerId"> The resource ID of the cluster manager that manages this cluster. This is set by the Cluster Manager when the cluster is created. </param>
        /// <param name="detailedStatus"> The current detailed status of the cluster. </param>
        /// <param name="detailedStatusMessage"> The descriptive message about the detailed status. </param>
        /// <param name="hybridAksExtendedLocation"> Field Deprecated. This field will not be populated in an upcoming version. The extended location (custom location) that represents the Hybrid AKS control plane location. This extended location is used when creating provisioned clusters (Hybrid AKS clusters). </param>
        /// <param name="lastSuccessfulVersionUpdateOn"> The date and time of the end of the last successful version update for the cluster. </param>
        /// <param name="managedCredentials"> The list of credentials that are managed for the cluster and can be rotated on-demand. </param>
        /// <param name="manualActionCount"> The count of Manual Action Taken (MAT) events that have not been validated. </param>
        /// <param name="supportExpireOn"> The support end date of the runtime version of the cluster. </param>
        /// <param name="workloadResourceIds"> The list of workload resource IDs that are hosted within this cluster. </param>
        /// <param name="provisioningState"> The provisioning state of the cluster. </param>
        /// <param name="vulnerabilityScanningContainerScan"> The mode selection for container vulnerability scanning. </param>
        /// <param name="eTag"> The entity tag used for comparing versions of the resource. </param>
        /// <param name="extendedLocation"> The extended location of the resource. This property is required when creating the resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="kind"> The type (kind) of the cluster. When specified, the value must exactly match the kind configured on the cluster manager that manages the cluster. If omitted, the service will default the value to the kind value of the cluster manager. </param>
        /// <param name="edgeManagementServiceCACertificate"> The CA certificate of the edge management service. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData"/> instance for mocking. </returns>
        public static NetworkCloudClusterData NetworkCloudClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, AnalyticsOutputSettings analyticsOutputSettings, ResourceIdentifier analyticsWorkspaceId, string clusterLocation, ServicePrincipalInformation clusterServicePrincipal, ClusterType clusterType, string clusterVersion = default, CommandOutputSettings commandOutputSettings = default, ValidationThreshold computeDeploymentThreshold = default, IEnumerable<NetworkCloudRackDefinition> computeRackDefinitions = default, ManagedResourceGroupConfiguration managedResourceGroupConfiguration = default, ResourceIdentifier networkFabricId = default, RuntimeProtectionConfiguration runtimeProtectionConfiguration = default, ClusterSecretArchive secretArchive = default, SecretArchiveSettings secretArchiveSettings = default, ClusterUpdateStrategy updateStrategy = default, IEnumerable<NetworkCloudActionState> actionStates = default, IEnumerable<ClusterAvailableUpgradeVersion> availableUpgradeVersions = default, ClusterCapacity clusterCapacity = default, ClusterConnectionStatus? clusterConnectionStatus = default, Resources.Models.ExtendedLocation clusterExtendedLocation = default, ClusterManagerConnectionStatus? clusterManagerConnectionStatus = default, ResourceIdentifier clusterManagerId = default, ClusterDetailedStatus? detailedStatus = default, string detailedStatusMessage = default, Resources.Models.ExtendedLocation hybridAksExtendedLocation = default, DateTimeOffset? lastSuccessfulVersionUpdateOn = default, IEnumerable<string> managedCredentials = default, long? manualActionCount = default, DateTimeOffset? supportExpireOn = default, IEnumerable<ResourceIdentifier> workloadResourceIds = default, ClusterProvisioningState? provisioningState = default, VulnerabilityScanningSettingsContainerScan? vulnerabilityScanningContainerScan = default, ETag? eTag = default, ExtendedLocation extendedLocation = default, ManagedServiceIdentity identity = default, NetworkCloudDeploymentType? kind = default, NetworkCloudCertificateInfo edgeManagementServiceCACertificate = default)
        {
            return new NetworkCloudClusterData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                new ClusterProperties(
                    aggregatorOrSingleRackDefinition,
                    analyticsOutputSettings,
                    analyticsWorkspaceId,
                    clusterLocation,
                    clusterServicePrincipal,
                    clusterType,
                    clusterVersion,
                    commandOutputSettings,
                    computeDeploymentThreshold,
                    (computeRackDefinitions ?? new ChangeTrackingList<NetworkCloudRackDefinition>()).ToList(),
                    managedResourceGroupConfiguration,
                    networkFabricId,
                    runtimeProtectionConfiguration,
                    secretArchive,
                    secretArchiveSettings,
                    updateStrategy,
                    vulnerabilityScanningContainerScan is null ? default : new VulnerabilityScanningSettings(vulnerabilityScanningContainerScan, default),
                    (actionStates ?? new ChangeTrackingList<NetworkCloudActionState>()).ToList(),
                    (availableUpgradeVersions ?? new ChangeTrackingList<ClusterAvailableUpgradeVersion>()).ToList(),
                    clusterCapacity,
                    clusterConnectionStatus,
                    clusterExtendedLocation,
                    clusterManagerConnectionStatus,
                    clusterManagerId,
                    detailedStatus,
                    detailedStatusMessage,
                    edgeManagementServiceCACertificate,
                    hybridAksExtendedLocation,
                    lastSuccessfulVersionUpdateOn,
                    (managedCredentials ?? new ChangeTrackingList<string>()).ToList(),
                    manualActionCount,
                    supportExpireOn,
                    (workloadResourceIds ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(),
                    provisioningState,
                    default),
                eTag,
                extendedLocation,
                identity,
                kind,
                default);
        }
    }
}
