// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmHciModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.PerNodeExtensionState"/>. </summary>
        /// <param name="name"> Name of the node in HCI Cluster. </param>
        /// <param name="extension"> Fully qualified resource ID for the particular Arc Extension on this node. </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="state"> State of Arc Extension in this node. </param>
        /// <param name="instanceView"> The extension instance view. </param>
        /// <returns> A new <see cref="Models.PerNodeExtensionState"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, NodeExtensionState? state = null, HciExtensionInstanceView instanceView = null)
        {
            return new PerNodeExtensionState(
                name,
                extension,
                typeHandlerVersion,
                state,
                new ArcExtensionInstanceView(instanceView.Name,
                                             instanceView.ExtensionInstanceViewType,
                                             instanceView.TypeHandlerVersion,
                                             new ArcExtensionInstanceViewStatus(instanceView.Status.Code,
                                                                                instanceView.Status.Level,
                                                                                instanceView.Status.DisplayStatus,
                                                                                instanceView.Status.Message,
                                                                                instanceView.Status.Time,
                                                                                null),
                                             null),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.HciExtensionInstanceView"/>. </summary>
        /// <param name="name"> The extension name. </param>
        /// <param name="extensionInstanceViewType"> Specifies the type of the extension; an example is "MicrosoftMonitoringAgent". </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="status"> Instance view status. </param>
        /// <returns> A new <see cref="Models.HciExtensionInstanceView"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciExtensionInstanceView HciExtensionInstanceView(string name = null, string extensionInstanceViewType = null, string typeHandlerVersion = null, ExtensionInstanceViewStatus status = null)
        {
            return new HciExtensionInstanceView(name, extensionInstanceViewType, typeHandlerVersion, status, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ExtensionInstanceViewStatus"/>. </summary>
        /// <param name="code"> The status code. </param>
        /// <param name="level"> The level code. </param>
        /// <param name="displayStatus"> The short localizable label for the status. </param>
        /// <param name="message"> The detailed status message, including for alerts and error messages. </param>
        /// <param name="time"> The time of the status. </param>
        /// <returns> A new <see cref="Models.ExtensionInstanceViewStatus"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceViewStatus` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = null, HciStatusLevelType? level = null, string displayStatus = null, string message = null, DateTimeOffset? time = null)
        {
            return new ExtensionInstanceViewStatus(
                code,
                level,
                displayStatus,
                message,
                time,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.OfferData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning State. </param>
        /// <param name="publisherId"> Identifier of the Publisher for the offer. </param>
        /// <param name="content"> JSON serialized catalog content of the offer. </param>
        /// <param name="contentVersion"> The API version of the catalog service used to serve the catalog content. </param>
        /// <param name="skuMappings"> Array of SKU mappings. </param>
        /// <returns> A new <see cref="Hci.OfferData"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterOfferData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OfferData OfferData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, IEnumerable<HciSkuMappings> skuMappings = null)
        {
            skuMappings ??= new List<HciSkuMappings>();

            return new OfferData(
                id,
                name,
                resourceType,
                systemData,
                provisioningState,
                publisherId,
                content,
                contentVersion,
                skuMappings?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.PublisherData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning State. </param>
        /// <returns> A new <see cref="Hci.PublisherData"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterPublisherData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PublisherData PublisherData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, string provisioningState = null)
        {
            return new PublisherData(
                id,
                name,
                resourceType,
                systemData,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateRunData"/>. </summary>
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
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateRunData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateRunData UpdateRunData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, HciProvisioningState? provisioningState = null, DateTimeOffset? timeStarted = null, DateTimeOffset? lastUpdatedOn = null, string duration = null, UpdateRunPropertiesState? state = null, string namePropertiesProgressName = null, string description = null, string errorMessage = null, string status = null, DateTimeOffset? startTimeUtc = null, DateTimeOffset? endTimeUtc = null, DateTimeOffset? lastUpdatedTimeUtc = null, IEnumerable<HciUpdateStep> steps = null)
        {
            steps ??= new List<HciUpdateStep>();

            return new UpdateRunData(
                id,
                name,
                resourceType,
                systemData,
                location,
                provisioningState,
                timeStarted,
                lastUpdatedOn,
                duration,
                state,
                namePropertiesProgressName,
                description,
                errorMessage,
                status,
                startTimeUtc,
                endTimeUtc,
                lastUpdatedTimeUtc,
                steps?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateSummaryData"/>. </summary>
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
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateSummaryData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateSummaryData UpdateSummaryData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, HciProvisioningState? provisioningState = null, string oemFamily = null, string hardwareModel = null, IEnumerable<HciPackageVersionInfo> packageVersions = null, string currentVersion = null, DateTimeOffset? lastUpdated = null, DateTimeOffset? lastChecked = null, HciHealthState? healthState = null, IEnumerable<HciPrecheckResult> healthCheckResult = null, DateTimeOffset? healthCheckOn = null, UpdateSummariesPropertiesState? state = null)
        {
            packageVersions ??= new List<HciPackageVersionInfo>();
            healthCheckResult ??= new List<HciPrecheckResult>();

            return new UpdateSummaryData(
                id,
                name,
                resourceType,
                systemData,
                location,
                provisioningState,
                oemFamily,
                hardwareModel,
                packageVersions?.ToList(),
                currentVersion,
                lastUpdated,
                lastChecked,
                healthState,
                healthCheckResult?.ToList(),
                healthCheckOn,
                state,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> Provisioning state of the Updates proxy resource. </param>
        /// <param name="installedOn"> Date that the update was installed. </param>
        /// <param name="description"> Description of the update. </param>
        /// <param name="state"> State of the update as it relates to this stamp. </param>
        /// <param name="prerequisites"> If update State is HasPrerequisite, this property contains an array of objects describing prerequisite updates before installing this update. Otherwise, it is empty. </param>
        /// <param name="componentVersions"> An array of component versions for a Solution Bundle update, and an empty array otherwise.  </param>
        /// <param name="rebootRequired"></param>
        /// <param name="healthState"> Overall health state for update-specific health checks. </param>
        /// <param name="healthCheckResult"> An array of PrecheckResult objects. </param>
        /// <param name="healthCheckOn"> Last time the package-specific checks were run. </param>
        /// <param name="packagePath"> Path where the update package is available. </param>
        /// <param name="packageSizeInMb"> Size of the package. This value is a combination of the size from update metadata and size of the payload that results from the live scan operation for OS update content. </param>
        /// <param name="displayName"> Display name of the Update. </param>
        /// <param name="version"> Version of the update. </param>
        /// <param name="publisher"> Publisher of the update package. </param>
        /// <param name="releaseLink"> Link to release notes for the update. </param>
        /// <param name="availabilityType"> Indicates the way the update content can be downloaded. </param>
        /// <param name="packageType"> Customer-visible type of the update. </param>
        /// <param name="additionalProperties"> Extensible KV pairs serialized as a string. This is currently used to report the stamp OEM family and hardware model information when an update is flagged as Invalid for the stamp based on OEM type. </param>
        /// <param name="progressPercentage"> Progress percentage of ongoing operation. Currently this property is only valid when the update is in the Downloading state, where it maps to how much of the update content has been downloaded. </param>
        /// <param name="notifyMessage"> Brief message with instructions for updates of AvailabilityType Notify. </param>
        /// <returns> A new <see cref="Hci.UpdateData"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateData` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateData UpdateData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, HciProvisioningState? provisioningState = null, DateTimeOffset? installedOn = null, string description = null, HciUpdateState? state = null, IEnumerable<UpdatePrerequisite> prerequisites = null, IEnumerable<HciPackageVersionInfo> componentVersions = null, HciNodeRebootRequirement? rebootRequired = null, HciHealthState? healthState = null, IEnumerable<HciPrecheckResult> healthCheckResult = null, DateTimeOffset? healthCheckOn = null, string packagePath = null, float? packageSizeInMb = null, string displayName = null, string version = null, string publisher = null, string releaseLink = null, HciAvailabilityType? availabilityType = null, string packageType = null, string additionalProperties = null, float? progressPercentage = null, string notifyMessage = null)
        {
            prerequisites ??= new List<UpdatePrerequisite>();
            componentVersions ??= new List<HciPackageVersionInfo>();
            healthCheckResult ??= new List<HciPrecheckResult>();

            return new UpdateData(
                id,
                name,
                resourceType,
                systemData,
                location,
                provisioningState,
                installedOn,
                description,
                state,
                prerequisites?.ToList(),
                componentVersions?.ToList(),
                rebootRequired,
                healthState,
                healthCheckResult?.ToList(),
                healthCheckOn,
                packagePath,
                packageSizeInMb,
                displayName,
                version,
                publisher,
                releaseLink,
                availabilityType,
                packageType,
                additionalProperties,
                progressPercentage,
                notifyMessage,
                serializedAdditionalRawData: null);
        }

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
        /// <returns> A new <see cref="T:Azure.ResourceManager.Hci.HciClusterData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterData HciClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, HciProvisioningState? provisioningState, HciClusterStatus? status, Guid? cloudId, string cloudManagementEndpoint, Guid? aadClientId, Guid? aadTenantId, Guid? aadApplicationObjectId, Guid? aadServicePrincipalObjectId, SoftwareAssuranceProperties softwareAssuranceProperties, HciClusterDesiredProperties desiredProperties, HciClusterReportedProperties reportedProperties, float? trialDaysRemaining, string billingModel, DateTimeOffset? registrationTimestamp, DateTimeOffset? lastSyncTimestamp, DateTimeOffset? lastBillingTimestamp, string serviceEndpoint, string resourceProviderObjectId, Guid? principalId, Guid? tenantId, HciManagedServiceIdentityType? typeIdentityType, IDictionary<string, UserAssignedIdentity> userAssignedIdentities)
        {
            return HciClusterData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, provisioningState: provisioningState, status: status, connectivityStatus: default, cloudId: cloudId, cloudManagementEndpoint: cloudManagementEndpoint, aadClientId: aadClientId, aadTenantId: aadTenantId, aadApplicationObjectId: aadApplicationObjectId, aadServicePrincipalObjectId: aadServicePrincipalObjectId, softwareAssuranceProperties: softwareAssuranceProperties, logCollectionProperties: default, remoteSupportProperties: default, desiredProperties: desiredProperties, reportedProperties: reportedProperties, isolatedVmAttestationConfiguration: default, trialDaysRemaining: trialDaysRemaining, billingModel: billingModel, registrationTimestamp: registrationTimestamp, lastSyncTimestamp: lastSyncTimestamp, lastBillingTimestamp: lastBillingTimestamp, serviceEndpoint: serviceEndpoint, resourceProviderObjectId: resourceProviderObjectId, principalId: principalId, tenantId: tenantId, typeIdentityType: typeIdentityType, userAssignedIdentities: userAssignedIdentities);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.HciClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> Provisioning state. </param>
        /// <param name="status"> Status of the cluster agent. </param>
        /// <param name="connectivityStatus"> Overall connectivity status for the cluster resource. </param>
        /// <param name="cloudId"> Unique, immutable resource id. </param>
        /// <param name="cloudManagementEndpoint"> Endpoint configured for management from the Azure portal. </param>
        /// <param name="aadClientId"> App id of cluster AAD identity. </param>
        /// <param name="aadTenantId"> Tenant id of cluster AAD identity. </param>
        /// <param name="aadApplicationObjectId"> Object id of cluster AAD identity. </param>
        /// <param name="aadServicePrincipalObjectId"> Id of cluster identity service principal. </param>
        /// <param name="softwareAssuranceProperties"> Software Assurance properties of the cluster. </param>
        /// <param name="logCollectionProperties"> Log Collection properties of the cluster. </param>
        /// <param name="remoteSupportProperties"> RemoteSupport properties of the cluster. </param>
        /// <param name="desiredProperties"> Desired properties of the cluster. </param>
        /// <param name="reportedProperties"> Properties reported by cluster agent. </param>
        /// <param name="isolatedVmAttestationConfiguration"> Attestation configurations for isolated VM (e.g. TVM, CVM) of the cluster. </param>
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterData HciClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, HciProvisioningState? provisioningState = null, HciClusterStatus? status = null, HciClusterConnectivityStatus? connectivityStatus = null, Guid? cloudId = null, string cloudManagementEndpoint = null, Guid? aadClientId = null, Guid? aadTenantId = null, Guid? aadApplicationObjectId = null, Guid? aadServicePrincipalObjectId = null, SoftwareAssuranceProperties softwareAssuranceProperties = null, LogCollectionProperties logCollectionProperties = null, RemoteSupportProperties remoteSupportProperties = null, HciClusterDesiredProperties desiredProperties = null, HciClusterReportedProperties reportedProperties = null, IsolatedVmAttestationConfiguration isolatedVmAttestationConfiguration = null, float? trialDaysRemaining = null, string billingModel = null, DateTimeOffset? registrationTimestamp = null, DateTimeOffset? lastSyncTimestamp = null, DateTimeOffset? lastBillingTimestamp = null, string serviceEndpoint = null, string resourceProviderObjectId = null, Guid? principalId = null, Guid? tenantId = null, HciManagedServiceIdentityType? typeIdentityType = null, IDictionary<string, UserAssignedIdentity> userAssignedIdentities = null)
        {
            return HciClusterData(id, name, resourceType, systemData, tags, location, kind: default, principalId, tenantId, typeIdentityType, userAssignedIdentities, provisioningState, status, connectivityStatus, supportStatus: default, cloudId, ring: default, cloudManagementEndpoint, aadClientId, aadTenantId, aadApplicationObjectId, aadServicePrincipalObjectId, softwareAssuranceProperties, isManagementCluster: default, logCollectionProperties, remoteSupportProperties, desiredProperties);
        }

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
        /// <returns> A new <see cref="T:Azure.ResourceManager.Hci.ArcExtensionData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArcExtensionData ArcExtensionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, HciProvisioningState? provisioningState, ArcExtensionAggregateState? aggregateState, IEnumerable<PerNodeExtensionState> perNodeExtensionDetails, string forceUpdateTag, string publisher, string arcExtensionType, string typeHandlerVersion, bool? shouldAutoUpgradeMinorVersion, BinaryData settings, BinaryData protectedSettings, bool? enableAutomaticUpgrade)
        {
            return ArcExtensionData(id: id, name: name, resourceType: resourceType, systemData: systemData, provisioningState: provisioningState, aggregateState: aggregateState, perNodeExtensionDetails: perNodeExtensionDetails, managedBy: default, forceUpdateTag: forceUpdateTag, publisher: publisher, arcExtensionType: arcExtensionType, typeHandlerVersion: typeHandlerVersion, shouldAutoUpgradeMinorVersion: shouldAutoUpgradeMinorVersion, settings: settings, protectedSettings: protectedSettings, enableAutomaticUpgrade: enableAutomaticUpgrade);
        }

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
        /// <returns> A new <see cref="T:Azure.ResourceManager.Hci.ArcSettingData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArcSettingData ArcSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, HciProvisioningState? provisioningState, string arcInstanceResourceGroup, Guid? arcApplicationClientId, Guid? arcApplicationTenantId, Guid? arcServicePrincipalObjectId, Guid? arcApplicationObjectId, ArcSettingAggregateState? aggregateState, IEnumerable<PerNodeArcState> perNodeDetails, BinaryData connectivityProperties)
        {
            return ArcSettingData(id: id, name: name, resourceType: resourceType, systemData: systemData, provisioningState: provisioningState, arcInstanceResourceGroup: arcInstanceResourceGroup, arcApplicationClientId: arcApplicationClientId, arcApplicationTenantId: arcApplicationTenantId, arcServicePrincipalObjectId: arcServicePrincipalObjectId, arcApplicationObjectId: arcApplicationObjectId, aggregateState: aggregateState, perNodeDetails: perNodeDetails, connectivityProperties: connectivityProperties, defaultExtensions: default);
        }

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
        /// <returns> A new <see cref="T:Azure.ResourceManager.Hci.Models.HciClusterNode" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterNode HciClusterNode(string name, float? id, WindowsServerSubscription? windowsServerSubscription, ClusterNodeType? nodeType, string ehcResourceId, string manufacturer, string model, string osName, string osVersion, string osDisplayVersion, string serialNumber, float? coreCount, float? memoryInGiB, DateTimeOffset? lastLicensingTimestamp)
        {
            return HciClusterNode(name: name, id: id, windowsServerSubscription: windowsServerSubscription, nodeType: nodeType, ehcResourceId: ehcResourceId, manufacturer: manufacturer, model: model, osName: osName, osVersion: osVersion, osDisplayVersion: osDisplayVersion, serialNumber: serialNumber, coreCount: coreCount, memoryInGiB: memoryInGiB, lastLicensingTimestamp: lastLicensingTimestamp, oemActivation: default);
        }

        /// <summary> Initializes a new instance of HciClusterReportedProperties. </summary>
        /// <param name="clusterName"> Name of the on-prem cluster connected to this resource. </param>
        /// <param name="clusterId"> Unique id generated by the on-prem cluster. </param>
        /// <param name="clusterVersion"> Version of the cluster software. </param>
        /// <param name="nodes"> List of nodes reported by the cluster. </param>
        /// <param name="lastUpdatedOn"> Last time the cluster reported the data. </param>
        /// <param name="imdsAttestation"> IMDS attestation status of the cluster. </param>
        /// <param name="diagnosticLevel"> Level of diagnostic data emitted by the cluster. </param>
        /// <param name="supportedCapabilities"> Capabilities supported by the cluster. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Hci.Models.HciClusterReportedProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterReportedProperties HciClusterReportedProperties(string clusterName, Guid? clusterId, string clusterVersion, IEnumerable<HciClusterNode> nodes, DateTimeOffset? lastUpdatedOn, ImdsAttestationState? imdsAttestation, HciClusterDiagnosticLevel? diagnosticLevel, IEnumerable<string> supportedCapabilities)
        {
            return HciClusterReportedProperties(clusterName: clusterName, clusterId: clusterId, clusterVersion: clusterVersion, nodes: nodes, lastUpdatedOn: lastUpdatedOn, imdsAttestation: imdsAttestation, diagnosticLevel: diagnosticLevel, supportedCapabilities: supportedCapabilities, clusterType: default, manufacturer: default, oemActivation: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.HciClusterReportedProperties"/>. </summary>
        /// <param name="clusterName"> Name of the on-prem cluster connected to this resource. </param>
        /// <param name="clusterId"> Unique id generated by the on-prem cluster. </param>
        /// <param name="clusterVersion"> Version of the cluster software. </param>
        /// <param name="nodes"> List of nodes reported by the cluster. </param>
        /// <param name="lastUpdatedOn"> Last time the cluster reported the data. </param>
        /// <param name="imdsAttestation"> IMDS attestation status of the cluster. </param>
        /// <param name="diagnosticLevel"> Level of diagnostic data emitted by the cluster. </param>
        /// <param name="supportedCapabilities"> Capabilities supported by the cluster. </param>
        /// <param name="clusterType"> The node type of all the nodes of the cluster. </param>
        /// <param name="manufacturer"> The manufacturer of all the nodes of the cluster. </param>
        /// <param name="oemActivation"> OEM activation status of the cluster. </param>
        /// <returns> A new <see cref="Models.HciClusterReportedProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterReportedProperties HciClusterReportedProperties(string clusterName, Guid? clusterId, string clusterVersion, IEnumerable<HciClusterNode> nodes, DateTimeOffset? lastUpdatedOn, ImdsAttestationState? imdsAttestation, HciClusterDiagnosticLevel? diagnosticLevel, IEnumerable<string> supportedCapabilities = null, ClusterNodeType? clusterType = null, string manufacturer = null, OemActivation? oemActivation = null)
        {
            return HciClusterReportedProperties(clusterName, clusterId, clusterVersion, nodes, lastUpdatedOn, msiExpirationTimeStamp: default, imdsAttestation, diagnosticLevel, supportedCapabilities, clusterType, manufacturer, oemActivation, hardwareClass: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.HciNicDetail"/>. </summary>
        /// <param name="adapterName"> Adapter Name of NIC. </param>
        /// <param name="interfaceDescription"> Interface Description of NIC. </param>
        /// <param name="componentId"> Component Id of NIC. </param>
        /// <param name="driverVersion"> Driver Version of NIC. </param>
        /// <param name="ipv4Address"> Subnet Mask of NIC. </param>
        /// <param name="subnetMask"> Subnet Mask of NIC. </param>
        /// <param name="defaultGateway"> Default Gateway of NIC. </param>
        /// <param name="dnsServers"> DNS Servers for NIC. </param>
        /// <param name="defaultIsolationId"> Default Isolation of Management NIC. </param>
        /// <param name="macAddress"> MAC address information of NIC. </param>
        /// <param name="slot"> The slot attached to the NIC. </param>
        /// <param name="switchName"> The switch attached to the NIC, if any. </param>
        /// <param name="nicType"> The type of NIC, physical, virtual, management. </param>
        /// <param name="vlanId"> The VLAN ID of the physical NIC. </param>
        /// <param name="nicStatus"> The status of NIC, up, disconnected. </param>
        /// <returns> A new <see cref="Models.HciNicDetail"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciNicDetail HciNicDetail(string adapterName, string interfaceDescription, string componentId = null, string driverVersion = null, string ipv4Address = null, string subnetMask = null, string defaultGateway = null, IEnumerable<string> dnsServers = null, string defaultIsolationId = null, string macAddress = null, string slot = null, string switchName = null, string nicType = null, string vlanId = null, string nicStatus = null)
        {
            return HciNicDetail(adapterName, interfaceDescription, componentId, driverVersion, ipv4Address, subnetMask, defaultGateway, dnsServers, defaultIsolationId, macAddress, slot, switchName, nicType, vlanId, nicStatus, rdmaCapability: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.HciReportedProperties"/>. </summary>
        /// <param name="deviceState"> edge device state. </param>
        /// <param name="extensions"> Extensions details for edge device. </param>
        /// <param name="networkProfile"> HCI device network information. </param>
        /// <param name="osProfile"> HCI device OS specific information. </param>
        /// <param name="sbeDeploymentPackageInfo"> Solution builder extension (SBE) deployment package information. </param>
        /// <returns> A new <see cref="Models.HciReportedProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciReportedProperties HciReportedProperties(HciEdgeDeviceState? deviceState, IEnumerable<HciEdgeDeviceArcExtension> extensions, HciNetworkProfile networkProfile = null, HciOSProfile osProfile = null, SbeDeploymentPackageInfo sbeDeploymentPackageInfo = null)
        {
            return HciReportedProperties(deviceState, extensions, networkProfile, osProfile, sbeDeploymentPackageInfo, storagePoolableDisksCount: default, hardwareProcessorType: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.LogCollectionSession"/>. </summary>
        /// <param name="logStartOn"> Start Time of the logs when it was collected. </param>
        /// <param name="logEndOn"> End Time of the logs when it was collected. </param>
        /// <param name="timeCollected"> Duration of logs collected. </param>
        /// <param name="logSize"> Size of the logs collected. </param>
        /// <param name="logCollectionStatus"> LogCollection status. </param>
        /// <param name="logCollectionJobType"> LogCollection job type. </param>
        /// <param name="correlationId"> CorrelationId of the log collection. </param>
        /// <param name="endTimeCollected"> End Time of the logs when it was collected. </param>
        /// <param name="logCollectionError"> Log Collection Error details of the cluster. </param>
        /// <returns> A new <see cref="Models.LogCollectionSession"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LogCollectionSession LogCollectionSession(DateTimeOffset? logStartOn, DateTimeOffset? logEndOn, DateTimeOffset? timeCollected, long? logSize, LogCollectionStatus? logCollectionStatus, LogCollectionJobType? logCollectionJobType, string correlationId, DateTimeOffset? endTimeCollected = null, LogCollectionError logCollectionError = null)
        {
            return LogCollectionSession(logStartOn, logEndOn, timeCollected, logSize, logCollectionStatus, correlationId, logCollectionJobType, endTimeCollected, logCollectionError);
        }

        /// <summary> Initializes a new instance of PerNodeArcState. </summary>
        /// <param name="name"> Name of the Node in HCI Cluster. </param>
        /// <param name="arcInstance"> Fully qualified resource ID for the Arc agent of this node. </param>
        /// <param name="state"> State of Arc agent in this node. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Hci.Models.PerNodeArcState" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PerNodeArcState PerNodeArcState(string name, string arcInstance, NodeArcState? state)
        {
            return PerNodeArcState(name: name, arcInstance: arcInstance, arcNodeServicePrincipalObjectId: default, state: state);
        }
    }
}
