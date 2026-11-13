// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // The HciReportedProperties suppress is needed because the generated signature references
    // internal type ExtensionProfile (CS0051).
    // TODO: remove when https://github.com/Azure/azure-sdk-for-net/issues/57755 is resolved
    [CodeGenSuppress("HciReportedProperties", typeof(HciEdgeDeviceState?), typeof(ExtensionProfile), typeof(IDictionary<string, BinaryData>), typeof(HciNetworkProfile), typeof(HciOSProfile), typeof(SbeDeploymentPackageInfo), typeof(HciStorageProfile), typeof(HciHardwareProfile))]
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
        public static HciExtensionInstanceView HciExtensionInstanceView(string name = default, string extensionInstanceViewType = default, string typeHandlerVersion = default, ExtensionInstanceViewStatus status = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.");

        /// <summary> Initializes a new instance of <see cref="Models.PerNodeExtensionState"/>. </summary>
        /// <param name="name"> Name of the node in HCI Cluster. </param>
        /// <param name="extension"> Fully qualified resource ID for the particular Arc Extension on this node. </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="state"> State of Arc Extension in this node. </param>
        /// <param name="instanceView"> The extension instance view. </param>
        /// <returns> A new <see cref="Models.PerNodeExtensionState"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static PerNodeExtensionState PerNodeExtensionState(string name = default, string extension = default, string typeHandlerVersion = default, NodeExtensionState? state = default, HciExtensionInstanceView instanceView = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.");

        /// <summary> Initializes a new instance of <see cref="Models.ExtensionInstanceViewStatus"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceViewStatus` moving forward.")]
        public static ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = default, HciStatusLevelType? level = default, string displayStatus = default, string message = default, DateTimeOffset? time = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `ArcExtensionInstanceViewStatus` moving forward.");

        /// <summary> Initializes a new instance of <see cref="Models.RemoteSupportNodeSettings"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload moving forward.")]
        public static RemoteSupportNodeSettings RemoteSupportNodeSettings(ResourceIdentifier arcResourceId = default, string state = default, DateTimeOffset? createdOn = default, DateTimeOffset? updatedOn = default, string connectionStatus = default, string connectionErrorMessage = default, string transcriptLocation = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new overload moving forward.");

        /// <summary> Initializes a new instance of <see cref="Hci.OfferData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterOfferData` moving forward.")]
        public static OfferData OfferData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string provisioningState = default, string publisherId = default, string content = default, string contentVersion = default, IEnumerable<HciSkuMappings> skuMappings = default)
        {
            return new OfferData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, publisherId, content, contentVersion, provisioningState, skuMappings is null ? null : new List<HciSkuMappings>(skuMappings));
        }

        /// <summary> Initializes a new instance of <see cref="Hci.PublisherData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterPublisherData` moving forward.")]
        public static PublisherData PublisherData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string provisioningState = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `HciClusterPublisherData` moving forward.");

        // Publisher was removed from stable APIs starting with 2026-02-01 and is now preview-only.
        // This release targets a stable API, so its model factory is maintained as customization code.
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="provisioningState"> Provisioning State. </param>
        /// <returns> A new <see cref="Hci.HciClusterPublisherData"/> instance for mocking. </returns>
        public static HciClusterPublisherData HciClusterPublisherData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string provisioningState = default)
        {
            return new HciClusterPublisherData(
                id,
                name,
                resourceType,
                systemData,
                provisioningState is null ? default : new PublisherProperties(provisioningState, default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Hci.ArcSettingData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload with ArcConnectivityProperties moving forward.")]
        public static ArcSettingData ArcSettingData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            HciProvisioningState? provisioningState = default,
            string arcInstanceResourceGroup = default,
            Guid? arcApplicationClientId = default,
            Guid? arcApplicationTenantId = default,
            Guid? arcServicePrincipalObjectId = default,
            Guid? arcApplicationObjectId = default,
            ArcSettingAggregateState? aggregateState = default,
            IEnumerable<PerNodeArcState> perNodeDetails = default,
            BinaryData connectivityProperties = default,
            IEnumerable<ArcDefaultExtensionDetails> defaultExtensions = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new overload with ArcConnectivityProperties moving forward.");

        /// <summary> Initializes a new instance of <see cref="Hci.HciClusterDeploymentSettingData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new overload with IEnumerable<string> arcNodeResourceIds moving forward.")]
        public static HciClusterDeploymentSettingData HciClusterDeploymentSettingData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            HciProvisioningState? provisioningState = default,
            IEnumerable<ResourceIdentifier> arcNodeResourceIds = default,
            EceDeploymentMode? deploymentMode = default,
            HciClusterOperationType? operationType = default,
            HciClusterDeploymentConfiguration deploymentConfiguration = default,
            EceReportedProperties reportedProperties = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new overload with IEnumerable<string> arcNodeResourceIds moving forward.");

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateData` moving forward.")]
        public static UpdateData UpdateData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            AzureLocation? location = default,
            HciProvisioningState? provisioningState = default,
            DateTimeOffset? installedOn = default,
            string description = default,
            HciUpdateState? state = default,
            IEnumerable<UpdatePrerequisite> prerequisites = default,
            IEnumerable<HciPackageVersionInfo> componentVersions = default,
            HciNodeRebootRequirement? rebootRequired = default,
            HciHealthState? healthState = default,
            IEnumerable<HciPrecheckResult> healthCheckResult = default,
            DateTimeOffset? healthCheckOn = default,
            string packagePath = default,
            float? packageSizeInMb = default,
            string displayName = default,
            string version = default,
            string publisher = default,
            string releaseLink = default,
            HciAvailabilityType? availabilityType = default,
            string packageType = default,
            string additionalProperties = default,
            float? progressPercentage = default,
            string notifyMessage = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `HciClusterUpdateData` moving forward.");

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateRunData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateRunData` moving forward.")]
        public static UpdateRunData UpdateRunData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            AzureLocation? location = default,
            HciProvisioningState? provisioningState = default,
            DateTimeOffset? timeStarted = default,
            DateTimeOffset? lastUpdatedOn = default,
            string duration = default,
            UpdateRunPropertiesState? state = default,
            string namePropertiesProgressName = default,
            string description = default,
            string errorMessage = default,
            string status = default,
            DateTimeOffset? startTimeUtc = default,
            DateTimeOffset? endTimeUtc = default,
            DateTimeOffset? lastUpdatedTimeUtc = default,
            IEnumerable<HciUpdateStep> steps = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `HciClusterUpdateRunData` moving forward.");

        /// <summary> Initializes a new instance of <see cref="Hci.UpdateSummaryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `HciClusterUpdateSummaryData` moving forward.")]
        public static UpdateSummaryData UpdateSummaryData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            AzureLocation? location = default,
            HciProvisioningState? provisioningState = default,
            string oemFamily = default,
            string hardwareModel = default,
            IEnumerable<HciPackageVersionInfo> packageVersions = default,
            string currentVersion = default,
            DateTimeOffset? lastUpdated = default,
            DateTimeOffset? lastChecked = default,
            HciHealthState? healthState = default,
            IEnumerable<HciPrecheckResult> healthCheckResult = default,
            DateTimeOffset? healthCheckOn = default,
            UpdateSummariesPropertiesState? state = default)
         => throw new NotSupportedException("This method is now deprecated. Please use the new method `HciClusterUpdateSummaryData` moving forward.");
    }
}
