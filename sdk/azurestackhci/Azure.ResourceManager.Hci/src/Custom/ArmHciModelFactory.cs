// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserves [Obsolete] from previous API version on backward-compat overloads
    [CodeGenSuppress("HciExtensionInstanceView", typeof(string), typeof(string), typeof(string), typeof(ExtensionInstanceViewStatus))]
    [CodeGenSuppress("PerNodeExtensionState", typeof(string), typeof(string), typeof(string), typeof(NodeExtensionState?), typeof(HciExtensionInstanceView))]
    public static partial class ArmHciModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.HciExtensionInstanceView"/>. </summary>
        /// <param name="name"> The extension instance view name. </param>
        /// <param name="extensionInstanceViewType"> Specifies the type of the extension. </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="status"> Instance view status. </param>
        /// <returns> A new <see cref="Models.HciExtensionInstanceView"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static HciExtensionInstanceView HciExtensionInstanceView(string name, string extensionInstanceViewType, string typeHandlerVersion, ExtensionInstanceViewStatus status)
        {
            return new HciExtensionInstanceView(name, default, typeHandlerVersion, status, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PerNodeExtensionState"/>. </summary>
        /// <param name="name"> Name of the node in HCI Cluster. </param>
        /// <param name="extension"> Fully qualified resource ID for the particular Arc Extension on this node. </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="state"> State of Arc Extension in this node. </param>
        /// <param name="instanceView"> The extension instance view. </param>
        /// <returns> A new <see cref="Models.PerNodeExtensionState"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static PerNodeExtensionState PerNodeExtensionState(string name = default, string extension = default, string typeHandlerVersion = default, NodeExtensionState? state = default, HciExtensionInstanceView instanceView = default)
        {
            return new PerNodeExtensionState(
                name,
                extension,
                typeHandlerVersion,
                state,
                instanceView,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ArcExtensionInstanceView"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload moving forward.")]
        public static ArcExtensionInstanceView ArcExtensionInstanceView(string name, string arcExtensionInstanceViewType, string typeHandlerVersion, ArcExtensionInstanceViewStatus status)
        {
            return new ArcExtensionInstanceView(name, arcExtensionInstanceViewType, typeHandlerVersion, status, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ExtensionInstanceViewStatus"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceViewStatus` moving forward.")]
        public static ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = default, HciStatusLevelType? level = default, string displayStatus = default, string message = default, DateTimeOffset? time = default)
        {
            return new ExtensionInstanceViewStatus(code, level, displayStatus, message, time, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.RemoteSupportNodeSettings"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload moving forward.")]
        public static RemoteSupportNodeSettings RemoteSupportNodeSettings(ResourceIdentifier arcResourceId, string state = default, DateTimeOffset? createdOn = default, DateTimeOffset? updatedOn = default, string connectionStatus = default, string connectionErrorMessage = default, string transcriptLocation = default)
        {
            return new RemoteSupportNodeSettings(arcResourceId?.ToString(), state, createdOn, updatedOn, connectionStatus, connectionErrorMessage, transcriptLocation, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.OfferData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterOfferData` moving forward.")]
        public static OfferData OfferData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string publisherId = default, string content = default, string contentVersion = default, string provisioningState = default, IEnumerable<HciSkuMappings> skuMappings = default)
        {
            return new OfferData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, publisherId, content, contentVersion, provisioningState, skuMappings is null ? null : new List<HciSkuMappings>(skuMappings));
        }

        /// <summary> Initializes a new instance of <see cref="Hci.PublisherData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterPublisherData` moving forward.")]
        public static PublisherData PublisherData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string provisioningState = default)
        {
            return new PublisherData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.ArcSettingData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload with ArcConnectivityProperties moving forward.")]
        public static ArcSettingData ArcSettingData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            HciProvisioningState? provisioningState,
            string arcInstanceResourceGroup,
            Guid? arcApplicationClientId,
            Guid? arcApplicationTenantId,
            Guid? arcServicePrincipalObjectId,
            Guid? arcApplicationObjectId,
            ArcSettingAggregateState? aggregateState,
            IEnumerable<PerNodeArcState> perNodeDetails,
            BinaryData connectivityProperties,
            IEnumerable<ArcDefaultExtensionDetails> defaultExtensions = default)
        {
            // The old signature took BinaryData for connectivityProperties; new takes ArcConnectivityProperties.
            // Call the new signature with explicit null cast to avoid ambiguity.
            return ArcSettingData(id, name, resourceType, systemData, provisioningState, arcInstanceResourceGroup, arcApplicationClientId, arcApplicationTenantId, arcServicePrincipalObjectId, arcApplicationObjectId, aggregateState, perNodeDetails, (ArcConnectivityProperties)null, defaultExtensions);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.HciClusterDeploymentSettingData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload with IEnumerable<string> arcNodeResourceIds moving forward.")]
        public static HciClusterDeploymentSettingData HciClusterDeploymentSettingData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            HciProvisioningState? provisioningState,
            IEnumerable<ResourceIdentifier> arcNodeResourceIds,
            EceDeploymentMode? deploymentMode,
            HciClusterOperationType? operationType,
            HciClusterDeploymentConfiguration deploymentConfiguration,
            EceReportedProperties reportedProperties)
        {
            // Convert IEnumerable<ResourceIdentifier> to IEnumerable<string>
            var stringIds = arcNodeResourceIds == null ? null : new List<string>();
            if (arcNodeResourceIds != null)
            {
                foreach (var id2 in arcNodeResourceIds)
                    stringIds.Add(id2?.ToString());
            }
            return HciClusterDeploymentSettingData(id, name, resourceType, systemData, provisioningState, stringIds, deploymentMode, operationType, deploymentConfiguration, reportedProperties);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateData` moving forward.")]
        public static UpdateData UpdateData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            AzureLocation? location,
            HciProvisioningState? provisioningState,
            DateTimeOffset? installedOn,
            string description,
            HciUpdateState? state,
            IEnumerable<UpdatePrerequisite> prerequisites,
            IEnumerable<HciPackageVersionInfo> componentVersions,
            HciNodeRebootRequirement? rebootRequired,
            HciHealthState? healthState,
            IEnumerable<HciPrecheckResult> healthCheckResult,
            DateTimeOffset? healthCheckOn,
            string packagePath,
            float? packageSizeInMb,
            string displayName,
            string version,
            string publisher,
            string releaseLink,
            HciAvailabilityType? availabilityType,
            string packageType,
            string additionalProperties,
            float? progressPercentage,
            string notifyMessage)
        {
            // Convert IEnumerable<UpdatePrerequisite> to IEnumerable<HciClusterUpdatePrerequisite> (UpdatePrerequisite inherits from HciClusterUpdatePrerequisite)
            var hciPrereqs = prerequisites == null ? null : new List<HciClusterUpdatePrerequisite>();
            if (prerequisites != null)
            {
                foreach (var p in prerequisites)
                    hciPrereqs.Add(p);
            }
            return new UpdateData(
                HciClusterUpdateData(id, name, resourceType, systemData, location, provisioningState, installedOn, description, default, state, hciPrereqs, componentVersions, rebootRequired, healthState, healthCheckResult, healthCheckOn, packagePath, packageSizeInMb, displayName, version, publisher, releaseLink, availabilityType, packageType, additionalProperties, progressPercentage, notifyMessage));
        }

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateRunData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateRunData` moving forward.")]
        public static UpdateRunData UpdateRunData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            AzureLocation? location,
            HciProvisioningState? provisioningState,
            DateTimeOffset? timeStarted,
            DateTimeOffset? lastUpdatedOn,
            string duration,
            UpdateRunPropertiesState? state,
            string namePropertiesProgressName,
            string description,
            string errorMessage,
            string status,
            DateTimeOffset? startOn,
            DateTimeOffset? endOn,
            DateTimeOffset? lastCompletedOn,
            IEnumerable<HciUpdateStep> steps)
        {
            return new UpdateRunData(
                HciClusterUpdateRunData(id, name, resourceType, systemData, location, provisioningState, timeStarted, lastUpdatedOn, duration, state, namePropertiesProgressName, description, errorMessage, status, startOn, endOn, lastCompletedOn, default, steps));
        }

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateSummaryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateSummaryData` moving forward.")]
        public static UpdateSummaryData UpdateSummaryData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            AzureLocation? location,
            HciProvisioningState? provisioningState,
            string oemFamily,
            string currentOemVersion,
            IEnumerable<HciPackageVersionInfo> packageVersions,
            string currentVersion,
            DateTimeOffset? lastUpdatedOn,
            DateTimeOffset? lastCheckedOn,
            HciHealthState? healthState,
            IEnumerable<HciPrecheckResult> healthCheckResult,
            DateTimeOffset? healthCheckOn,
            UpdateSummariesPropertiesState? state)
        {
            // Convert UpdateSummariesPropertiesState to HciClusterUpdateState
            HciClusterUpdateState? hciState = state.HasValue ? (HciClusterUpdateState?)state.Value : null;
            return new UpdateSummaryData(
                HciClusterUpdateSummaryData(id, name, resourceType, systemData, location, provisioningState, oemFamily, currentOemVersion, default, packageVersions, currentVersion, default, lastUpdatedOn, lastCheckedOn, healthState, healthCheckResult, healthCheckOn, hciState));
        }
    }
}
