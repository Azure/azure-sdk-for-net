// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Hci;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmHciModelFactory
    {
        /// <summary> Initializes a new instance of ArcSettingData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of the ArcSetting proxy resource. </param>
        /// <param name="arcInstanceResourceGroup"> The resource group that hosts the Arc agents, ie. Hybrid Compute Machine resources. </param>
        /// <param name="arcApplicationClientId"> App id of arc AAD identity. </param>
        /// <param name="arcApplicationTenantId"> Tenant id of arc AAD identity. </param>
        /// <param name="arcServicePrincipalObjectId"> Object id of arc AAD service principal. </param>
        /// <param name="arcApplicationObjectId"> Object id of arc AAD identity. </param>
        /// <param name="aggregateState"> Aggregate state of Arc agent across the nodes in this HCI cluster. </param>
        /// <param name="perNodeDetails"> State of Arc agent in each of the nodes. </param>
        /// <param name="connectivityProperties"> contains connectivity related configuration for ARC resources. </param>
        /// <returns> A new <see cref="Hci.ArcSettingData"/> instance for mocking. </returns>
        public static ArcSettingData ArcSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, HciProvisioningState? provisioningState, string arcInstanceResourceGroup, Guid? arcApplicationClientId, Guid? arcApplicationTenantId, Guid? arcServicePrincipalObjectId, Guid? arcApplicationObjectId, ArcSettingAggregateState? aggregateState, IEnumerable<PerNodeArcState> perNodeDetails, BinaryData connectivityProperties) => ArcSettingData(id, name, resourceType, systemData, provisioningState, arcInstanceResourceGroup, arcApplicationClientId, arcApplicationTenantId, arcServicePrincipalObjectId, arcApplicationObjectId, aggregateState, perNodeDetails?.ToList(), connectivityProperties, null);

        /// <summary> Initializes a new instance of ArcExtensionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of the Extension proxy resource. </param>
        /// <param name="aggregateState"> Aggregate state of Arc Extensions across the nodes in this HCI cluster. </param>
        /// <param name="perNodeExtensionDetails"> State of Arc Extension in each of the nodes. </param>
        /// <param name="forceUpdateTag"> How the extension handler should be forced to update even if the extension configuration has not changed. </param>
        /// <param name="publisher"> The name of the extension handler publisher. </param>
        /// <param name="arcExtensionType"> Specifies the type of the extension; an example is "CustomScriptExtension". </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. Latest version would be used if not specified. </param>
        /// <param name="shouldAutoUpgradeMinorVersion"> Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true. </param>
        /// <param name="settings"> Json formatted public settings for the extension. </param>
        /// <param name="protectedSettings"> Protected settings (may contain secrets). </param>
        /// <param name="enableAutomaticUpgrade"> Indicates whether the extension should be automatically upgraded by the platform if there is a newer version available. </param>
        /// <returns> A new <see cref="Hci.ArcExtensionData"/> instance for mocking. </returns>
        public static ArcExtensionData ArcExtensionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, HciProvisioningState? provisioningState, ArcExtensionAggregateState? aggregateState, IEnumerable<PerNodeExtensionState> perNodeExtensionDetails, string forceUpdateTag, string publisher, string arcExtensionType, string typeHandlerVersion, bool? shouldAutoUpgradeMinorVersion, BinaryData settings, BinaryData protectedSettings, bool? enableAutomaticUpgrade) => ArcExtensionData(id, name, resourceType, systemData, provisioningState, aggregateState, perNodeExtensionDetails?.ToList(), null, forceUpdateTag, publisher, arcExtensionType, typeHandlerVersion, shouldAutoUpgradeMinorVersion, settings, protectedSettings, enableAutomaticUpgrade);

        /// <summary> Initializes a new instance of HciClusterData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> Provisioning state. </param>
        /// <param name="status"> Status of the cluster agent. </param>
        /// <param name="cloudId"> Unique, immutable resource id. </param>
        /// <param name="cloudManagementEndpoint"> Endpoint configured for management from the Azure portal. </param>
        /// <param name="aadClientId"> App id of cluster AAD identity. </param>
        /// <param name="aadTenantId"> Tenant id of cluster AAD identity. </param>
        /// <param name="aadApplicationObjectId"> Object id of cluster AAD identity. </param>
        /// <param name="aadServicePrincipalObjectId"> Id of cluster identity service principal. </param>
        /// <param name="softwareAssuranceProperties"> Software Assurance properties of the cluster. </param>
        /// <param name="desiredProperties"> Desired properties of the cluster. </param>
        /// <param name="reportedProperties"> Properties reported by cluster agent. </param>
        /// <param name="trialDaysRemaining"> Number of days remaining in the trial period. </param>
        /// <param name="billingModel"> Type of billing applied to the resource. </param>
        /// <param name="registrationTimestamp"> First cluster sync timestamp. </param>
        /// <param name="lastSyncTimestamp"> Most recent cluster sync timestamp. </param>
        /// <param name="lastBillingTimestamp"> Most recent billing meter timestamp. </param>
        /// <param name="serviceEndpoint"> Region specific DataPath Endpoint of the cluster. </param>
        /// <param name="resourceProviderObjectId"> Object id of RP Service Principal. </param>
        /// <param name="principalId"> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="tenantId"> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="typeIdentityType"> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </param>
        /// <param name="userAssignedIdentities"> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </param>
        /// <returns> A new <see cref="Hci.HciClusterData"/> instance for mocking. </returns>
        public static HciClusterData HciClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, HciProvisioningState? provisioningState, HciClusterStatus? status, Guid? cloudId, string cloudManagementEndpoint, Guid? aadClientId, Guid? aadTenantId, Guid? aadApplicationObjectId, Guid? aadServicePrincipalObjectId, SoftwareAssuranceProperties softwareAssuranceProperties, HciClusterDesiredProperties desiredProperties, HciClusterReportedProperties reportedProperties, float? trialDaysRemaining, string billingModel, DateTimeOffset? registrationTimestamp, DateTimeOffset? lastSyncTimestamp, DateTimeOffset? lastBillingTimestamp, string serviceEndpoint, string resourceProviderObjectId, Guid? principalId, Guid? tenantId, HciManagedServiceIdentityType? typeIdentityType, IDictionary<string, UserAssignedIdentity> userAssignedIdentities) => HciClusterData(id, name, resourceType, systemData, tags, location, null, provisioningState, status, cloudId, cloudManagementEndpoint, aadClientId, aadTenantId, aadApplicationObjectId, aadServicePrincipalObjectId, softwareAssuranceProperties, desiredProperties, reportedProperties, trialDaysRemaining, billingModel, registrationTimestamp, lastSyncTimestamp, lastBillingTimestamp, serviceEndpoint, resourceProviderObjectId);

        /// <summary> Initializes a new instance of HciClusterNode. </summary>
        /// <param name="name"> Name of the cluster node. </param>
        /// <param name="id"> Id of the node in the cluster. </param>
        /// <param name="windowsServerSubscription"> State of Windows Server Subscription. </param>
        /// <param name="nodeType"> Type of the cluster node hardware. </param>
        /// <param name="ehcResourceId"> Edge Hardware Center Resource Id. </param>
        /// <param name="manufacturer"> Manufacturer of the cluster node hardware. </param>
        /// <param name="model"> Model name of the cluster node hardware. </param>
        /// <param name="osName"> Operating system running on the cluster node. </param>
        /// <param name="osVersion"> Version of the operating system running on the cluster node. </param>
        /// <param name="osDisplayVersion"> Display version of the operating system running on the cluster node. </param>
        /// <param name="serialNumber"> Immutable id of the cluster node. </param>
        /// <param name="coreCount"> Number of physical cores on the cluster node. </param>
        /// <param name="memoryInGiB"> Total available memory on the cluster node (in GiB). </param>
        /// <param name="lastLicensingTimestamp"> Most recent licensing timestamp. </param>
        /// <returns> A new <see cref="Models.HciClusterNode"/> instance for mocking. </returns>
        public static HciClusterNode HciClusterNode(string name, float? id, WindowsServerSubscription? windowsServerSubscription, ClusterNodeType? nodeType, string ehcResourceId, string manufacturer, string model, string osName, string osVersion, string osDisplayVersion, string serialNumber, float? coreCount, float? memoryInGiB, DateTimeOffset? lastLicensingTimestamp) =>  HciClusterNode(name, id, windowsServerSubscription, nodeType, ehcResourceId, manufacturer, model, osName, osVersion, osDisplayVersion, serialNumber, coreCount, memoryInGiB);

        /// <summary> Initializes a new instance of UpdateRunData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> Provisioning state of the UpdateRuns proxy resource. </param>
        /// <param name="timeStarted"> Timestamp of the update run was started. </param>
        /// <param name="lastUpdatedOn"> Timestamp of the most recently completed step in the update run. </param>
        /// <param name="duration"> Duration of the update run. </param>
        /// <param name="state"> State of the update run. </param>
        /// <param name="namePropertiesProgressName"> Name of the step. </param>
        /// <param name="description"> More detailed description of the step. </param>
        /// <param name="errorMessage"> Error message, specified if the step is in a failed state. </param>
        /// <param name="status"> Status of the step, bubbled up from the ECE action plan for installation attempts. Values are: 'Success', 'Error', 'InProgress', and 'Unknown status'. </param>
        /// <param name="startTimeUtc"> When the step started, or empty if it has not started executing. </param>
        /// <param name="endTimeUtc"> When the step reached a terminal state. </param>
        /// <param name="lastUpdatedTimeUtc"> Completion time of this step or the last completed sub-step. </param>
        /// <param name="steps"> Recursive model for child steps of this step. </param>
        /// <returns> A new <see cref="Hci.UpdateRunData"/> instance for mocking. </returns>
        public static UpdateRunData UpdateRunData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, HciProvisioningState? provisioningState, DateTimeOffset? timeStarted, DateTimeOffset? lastUpdatedOn, string duration, UpdateRunPropertiesState? state, string namePropertiesProgressName, string description, string errorMessage, string status, DateTimeOffset? startTimeUtc, DateTimeOffset? endTimeUtc, DateTimeOffset? lastUpdatedTimeUtc, IEnumerable<HciUpdateStep> steps) => UpdateRunData(id, name, resourceType, systemData, location, provisioningState, timeStarted, lastUpdatedOn, duration, state, namePropertiesProgressName, description, errorMessage, status, startTimeUtc, endTimeUtc, lastUpdatedTimeUtc, default, steps?.ToList());

        /// <summary> Initializes a new instance of UpdateSummaryData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> Provisioning state of the UpdateSummaries proxy resource. </param>
        /// <param name="oemFamily"> OEM family name. </param>
        /// <param name="hardwareModel"> Name of the hardware model. </param>
        /// <param name="packageVersions"> Current version of each updatable component. </param>
        /// <param name="currentVersion"> Current Solution Bundle version of the stamp. </param>
        /// <param name="lastUpdated"> Last time an update installation completed successfully. </param>
        /// <param name="lastChecked"> Last time the update service successfully checked for updates. </param>
        /// <param name="healthState"> Overall health state for update-specific health checks. </param>
        /// <param name="healthCheckResult"> An array of pre-check result objects. </param>
        /// <param name="healthCheckOn"> Last time the package-specific checks were run. </param>
        /// <param name="state"> Overall update state of the stamp. </param>
        /// <returns> A new <see cref="Hci.UpdateSummaryData"/> instance for mocking. </returns>
        public static UpdateSummaryData UpdateSummaryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, HciProvisioningState? provisioningState, string oemFamily, string hardwareModel, IEnumerable<HciPackageVersionInfo> packageVersions, string currentVersion, DateTimeOffset? lastUpdated, DateTimeOffset? lastChecked, HciHealthState? healthState, IEnumerable<HciPrecheckResult> healthCheckResult, DateTimeOffset? healthCheckOn, UpdateSummariesPropertiesState? state) => UpdateSummaryData(id, name, resourceType, systemData, location, provisioningState, oemFamily, null, hardwareModel, packageVersions?.ToList(), currentVersion, lastUpdated, lastChecked, healthState, healthCheckResult?.ToList(), healthCheckOn, state);
    }
}
