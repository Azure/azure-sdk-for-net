// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridCompute;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridCompute.Models
{
    public static partial class ArmHybridComputeModelFactory
    {
        // Backward-compat justification: the GA model factory exposed ArcSettings with Guid-based tenant IDs instead of ArcSettingsData.
        /// <summary>
        /// Creates an ArcSettings for mocking.
        /// This method preserves the AutoRest-generated model factory API for backward compatibility.
        /// Use <see cref="ArcSettingsData(ResourceIdentifier, string, ResourceType, Azure.ResourceManager.Models.SystemData, string, ResourceIdentifier)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArcSettings ArcSettings(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, Guid? tenantId = default, ResourceIdentifier gatewayResourceId = default)
            => new ArcSettings(id, name, resourceType, systemData, tenantId, gatewayResourceId, serializedAdditionalRawData: null);

        // Backward-compat justification: the GA model factory accepted ResourceIdentifier for privateEndpointId.
        /// <summary>
        /// Creates a HybridComputePrivateEndpointConnectionProperties for mocking.
        /// This overload accepts <see cref="ResourceIdentifier"/> for <paramref name="privateEndpointId"/> for backward compatibility.
        /// Use the overload that accepts a string privateEndpointId instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HybridComputePrivateEndpointConnectionProperties HybridComputePrivateEndpointConnectionProperties(ResourceIdentifier privateEndpointId = default, HybridComputePrivateLinkServiceConnectionStateProperty connectionState = default, string provisioningState = default, IEnumerable<string> groupIds = default)
            => new HybridComputePrivateEndpointConnectionProperties(new PrivateEndpointProperty(privateEndpointId, additionalBinaryDataProperties: null), connectionState, provisioningState, groupIds is null ? new List<string>() : new List<string>(groupIds), additionalBinaryDataProperties: null);

        // Backward-compat justification: the GA model factory exposed the private link scope properties without the generated serviceExtensions parameter.
        /// <summary>
        /// Creates a HybridComputePrivateLinkScopeProperties for mocking.
        /// This overload preserves the AutoRest-generated model factory API for backward compatibility.
        /// </summary>
        public static HybridComputePrivateLinkScopeProperties HybridComputePrivateLinkScopeProperties(HybridComputePublicNetworkAccessType? publicNetworkAccess = default, string provisioningState = default, string privateLinkScopeId = default, IEnumerable<PrivateEndpointConnectionDataModel> privateEndpointConnections = default)
        {
            privateEndpointConnections ??= new ChangeTrackingList<PrivateEndpointConnectionDataModel>();

            return new HybridComputePrivateLinkScopeProperties(
                publicNetworkAccess,
                provisioningState,
                privateLinkScopeId,
                new List<PrivateEndpointConnectionDataModel>(privateEndpointConnections),
                serviceExtensions: new ChangeTrackingList<HybridComputeServiceExtension>(),
                additionalBinaryDataProperties: null);
        }

        // Backward-compat justification: the GA model factory exposed Windows patch settings as flattened parameters.
        /// <summary> Creates a HybridComputeWindowsConfiguration for mocking. </summary>
        public static HybridComputeWindowsConfiguration HybridComputeWindowsConfiguration(AssessmentModeType? assessmentMode = default, PatchModeType? patchMode = default, bool? isHotpatchingEnabled = default, HybridComputePatchSettingsStatus status = default)
            => new HybridComputeWindowsConfiguration(assessmentMode is null && patchMode is null && isHotpatchingEnabled is null && status is null ? default : new PatchSettings(assessmentMode, patchMode, isHotpatchingEnabled, status, additionalBinaryDataProperties: null), additionalBinaryDataProperties: null);

        // Backward-compat justification: the GA model factory exposed Linux patch settings as flattened parameters.
        /// <summary> Creates a HybridComputeLinuxConfiguration for mocking. </summary>
        public static HybridComputeLinuxConfiguration HybridComputeLinuxConfiguration(AssessmentModeType? assessmentMode = default, PatchModeType? patchMode = default, bool? isHotpatchingEnabled = default, HybridComputePatchSettingsStatus status = default)
            => new HybridComputeLinuxConfiguration(assessmentMode is null && patchMode is null && isHotpatchingEnabled is null && status is null ? default : new PatchSettings(assessmentMode, patchMode, isHotpatchingEnabled, status, additionalBinaryDataProperties: null), additionalBinaryDataProperties: null);

        // Backward-compat justification: the GA model factory exposed assignedLicense on the ESU properties factory.
        /// <summary> Creates a LicenseProfileMachineInstanceViewEsuProperties for mocking. </summary>
        public static LicenseProfileMachineInstanceViewEsuProperties LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId = default, IEnumerable<EsuKey> esuKeys = default, EsuServerType? serverType = default, EsuEligibility? esuEligibility = default, EsuKeyState? esuKeyState = default, HybridComputeLicenseData assignedLicense = default, LicenseAssignmentState? licenseAssignmentState = default)
            => new LicenseProfileMachineInstanceViewEsuProperties(assignedLicenseImmutableId, esuKeys is null ? new ChangeTrackingList<EsuKey>() : new List<EsuKey>(esuKeys), additionalBinaryDataProperties: null, serverType, esuEligibility, esuKeyState, assignedLicense, licenseAssignmentState);

        // Backward-compat justification: the GA model factory exposed flattened machine properties instead of the generated nested shape.
        /// <summary> Creates a HybridComputeMachineData for mocking. </summary>
        public static HybridComputeMachineData HybridComputeMachineData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, IEnumerable<HybridComputeMachineExtensionData> resources = default, ManagedServiceIdentity identity = default, ArcKindEnum? kind = default, HybridComputeLocation locationData = default, AgentConfiguration agentConfiguration = default, HybridComputeServiceStatuses serviceStatuses = default, HybridComputeHardwareProfile hardwareProfile = default, IEnumerable<HybridComputeDisk> storageDisks = default, HybridComputeFirmwareProfile firmwareProfile = default, string cloudMetadataProvider = default, AgentUpgrade agentUpgrade = default, HybridComputeOSProfile osProfile = default, LicenseProfileMachineInstanceView licenseProfile = default, string provisioningState = default, HybridComputeStatusType? status = default, DateTimeOffset? lastStatusChange = default, IEnumerable<ResponseError> errorDetails = default, string agentVersion = default, Guid? vmId = default, string displayName = default, string machineFqdn = default, string clientPublicKey = default, string osName = default, string osVersion = default, string osType = default, Guid? vmUuid = default, IEnumerable<MachineExtensionInstanceView> extensions = default, string osSku = default, string osEdition = default, string domainName = default, string adFqdn = default, string dnsFqdn = default, ResourceIdentifier privateLinkScopeResourceId = default, ResourceIdentifier parentClusterResourceId = default, string msSqlDiscovered = default, IReadOnlyDictionary<string, string> detectedProperties = default, IEnumerable<HybridComputeNetworkInterface> networkInterfaces = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            resources ??= new ChangeTrackingList<HybridComputeMachineExtensionData>();

            MachineProperties properties = locationData is null && agentConfiguration is null && serviceStatuses is null && hardwareProfile is null && storageDisks is null && firmwareProfile is null && cloudMetadataProvider is null && agentUpgrade is null && osProfile is null && licenseProfile is null && provisioningState is null && status is null && lastStatusChange is null && errorDetails is null && agentVersion is null && vmId is null && displayName is null && machineFqdn is null && clientPublicKey is null && osName is null && osVersion is null && osType is null && vmUuid is null && extensions is null && osSku is null && osEdition is null && domainName is null && adFqdn is null && dnsFqdn is null && privateLinkScopeResourceId is null && parentClusterResourceId is null && msSqlDiscovered is null && detectedProperties is null && networkInterfaces is null ? default : new MachineProperties(
                locationData,
                agentConfiguration,
                serviceStatuses,
                hardwareProfile,
                new StorageProfile(storageDisks is null ? new ChangeTrackingList<HybridComputeDisk>() : new List<HybridComputeDisk>(storageDisks), additionalBinaryDataProperties: null),
                firmwareProfile,
                cloudMetadata: new HybridComputeCloudMetadata(cloudMetadataProvider, additionalBinaryDataProperties: null),
                agentUpgrade,
                osProfile,
                licenseProfile,
                provisioningState,
                status,
                lastStatusChange,
                errorDetails is null ? new ChangeTrackingList<ResponseError>() : new List<ResponseError>(errorDetails),
                agentVersion,
                vmId,
                displayName,
                machineFqdn,
                clientPublicKey,
                identityKeyStore: null,
                tpmEkCertificate: null,
                osName,
                osVersion,
                osType,
                vmUuid,
                extensions is null ? new ChangeTrackingList<MachineExtensionInstanceView>() : new List<MachineExtensionInstanceView>(extensions),
                osSku,
                osEdition,
                domainName,
                adFqdn,
                dnsFqdn,
                privateLinkScopeResourceId,
                parentClusterResourceId,
                hardwareResourceId: null,
                msSqlDiscovered,
                detectedProperties,
                new HybridComputeNetworkProfile(networkInterfaces is null ? new ChangeTrackingList<HybridComputeNetworkInterface>() : new List<HybridComputeNetworkInterface>(networkInterfaces), additionalBinaryDataProperties: null),
                additionalBinaryDataProperties: null);

            return new HybridComputeMachineData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                properties,
                new List<HybridComputeMachineExtensionData>(resources),
                identity,
                kind);
        }

        /// <summary>
        /// Creates a HybridComputeMachineData for mocking.
        /// This overload preserves the AutoRest-generated model factory API for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HybridComputeMachineData HybridComputeMachineData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<HybridComputeMachineExtensionData> resources, ManagedServiceIdentity identity, ArcKindEnum? kind, HybridComputeLocation locationData, AgentConfiguration agentConfiguration, HybridComputeServiceStatuses serviceStatuses, string cloudMetadataProvider, AgentUpgrade agentUpgrade, HybridComputeOSProfile osProfile, LicenseProfileMachineInstanceView licenseProfile, string provisioningState, HybridComputeStatusType? status, DateTimeOffset? lastStatusChange, IEnumerable<ResponseError> errorDetails, string agentVersion, Guid? vmId, string displayName, string machineFqdn, string clientPublicKey, string osName, string osVersion, string osType, Guid? vmUuid, IEnumerable<MachineExtensionInstanceView> extensions, string osSku, string osEdition, string domainName, string adFqdn, string dnsFqdn, ResourceIdentifier privateLinkScopeResourceId, ResourceIdentifier parentClusterResourceId, string msSqlDiscovered, IReadOnlyDictionary<string, string> detectedProperties, IEnumerable<HybridComputeNetworkInterface> networkInterfaces)
            => HybridComputeMachineData(id, name, resourceType, systemData, tags, location, resources, identity, kind, locationData, agentConfiguration, serviceStatuses, hardwareProfile: default, storageDisks: default, firmwareProfile: default, cloudMetadataProvider, agentUpgrade, osProfile, licenseProfile, provisioningState, status, lastStatusChange, errorDetails, agentVersion, vmId, displayName, machineFqdn, clientPublicKey, osName, osVersion, osType, vmUuid, extensions, osSku, osEdition, domainName, adFqdn, dnsFqdn, privateLinkScopeResourceId, parentClusterResourceId, msSqlDiscovered, detectedProperties, networkInterfaces);

        // Backward-compat justification: the GA model factory exposed the custom EsuKey licenseStatus constructor shape.
        /// <summary> Creates an EsuKey for mocking. </summary>
        public static EsuKey EsuKey(string sku = default, int? licenseStatus = default)
            => new EsuKey(sku, licenseStatus, additionalBinaryDataProperties: null);

        // Backward-compat justification: the GA model factory exposed HybridComputeLicense in the Models namespace.
        /// <summary> Creates a HybridComputeLicense for mocking. </summary>
        public static HybridComputeLicense HybridComputeLicense(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, HybridComputeProvisioningState? provisioningState = default, Guid? tenantId = default, HybridComputeLicenseType? licenseType = default, HybridComputeLicenseDetails licenseDetails = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new HybridComputeLicense(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && tenantId is null && licenseType is null && licenseDetails is null ? default : new LicenseProperties(provisioningState, tenantId, licenseType, licenseDetails, additionalBinaryDataProperties: null));
        }
        // Backward-compat justification: the GA model factory exposed license profile patch properties as flattened parameters.
        /// <summary> Creates a HybridComputeLicenseProfilePatch for mocking. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="softwareAssuranceCustomer"> Specifies if this machine is licensed as part of a Software Assurance agreement. </param>
        /// <param name="assignedLicense"> The resource id of the license. </param>
        /// <param name="subscriptionStatus"> Indicates the subscription status of the product. </param>
        /// <param name="productType"> Indicates the product type of the license. </param>
        /// <param name="productFeatures"> The list of product feature updates. </param>
        /// <returns> A new <see cref="Models.HybridComputeLicenseProfilePatch"/> instance for mocking. </returns>
        public static HybridComputeLicenseProfilePatch HybridComputeLicenseProfilePatch(IDictionary<string, string> tags = default, bool? softwareAssuranceCustomer = default, string assignedLicense = default, LicenseProfileSubscriptionStatusUpdate? subscriptionStatus = default, LicenseProfileProductType? productType = default, IEnumerable<HybridComputeProductFeatureUpdate> productFeatures = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new HybridComputeLicenseProfilePatch(tags, additionalBinaryDataProperties: null, softwareAssuranceCustomer is null && assignedLicense is null && subscriptionStatus is null && productType is null && productFeatures is null ? default : new LicenseProfileUpdateProperties(new LicenseProfileUpdatePropertiesSoftwareAssurance(softwareAssuranceCustomer, null), new EsuProfileUpdateProperties(assignedLicense, null), new ProductProfileUpdateProperties(subscriptionStatus, productType, productFeatures is null ? new ChangeTrackingList<HybridComputeProductFeatureUpdate>() : new List<HybridComputeProductFeatureUpdate>(productFeatures), null), null));
        }
    }
}
