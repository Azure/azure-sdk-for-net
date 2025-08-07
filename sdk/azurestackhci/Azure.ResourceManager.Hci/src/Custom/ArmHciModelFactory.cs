// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

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
    }
}
