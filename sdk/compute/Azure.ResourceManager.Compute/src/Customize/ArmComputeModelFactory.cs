// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmComputeModelFactory
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, ComputePlan plan, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, VirtualMachineScaleSetUpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVmProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVms, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, ResourceIdentifier proximityPlacementGroupId, ResourceIdentifier hostGroupId, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, OrchestrationMode? orchestrationMode, SpotRestorePolicy spotRestorePolicy, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy, DateTimeOffset? timeCreated, bool? isMaximumCapacityConstrained)
            => VirtualMachineScaleSetData(id, name, resourceType, systemData, tags, location, sku, plan, identity, zones, extendedLocation, null, upgradePolicy, automaticRepairsPolicy, virtualMachineProfile, provisioningState, overprovision, doNotRunExtensionsOnOverprovisionedVms, uniqueId, singlePlacementGroup, zoneBalance, platformFaultDomainCount, proximityPlacementGroupId, hostGroupId, additionalCapabilities, scaleInPolicy, orchestrationMode, spotRestorePolicy, priorityMixPolicy, timeCreated, isMaximumCapacityConstrained, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, ComputeSku sku, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, IEnumerable<string> zones, ManagedServiceIdentity identity, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVmInstanceView instanceView, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, VirtualMachineOSProfile osProfile, SecurityProfile securityProfile, VirtualMachineNetworkProfile networkProfile, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations, BootDiagnostics bootDiagnostics, ResourceIdentifier availabilitySetId, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy, string userData, DateTimeOffset? timeCreated)
            => VirtualMachineScaleSetVmData(id, name, resourceType, systemData, tags, location, instanceId, sku, plan, resources, zones, identity, null, latestModelApplied, vmId, instanceView, hardwareProfile, storageProfile, additionalCapabilities, osProfile, securityProfile, networkProfile, networkInterfaceConfigurations, bootDiagnostics, availabilitySetId, provisioningState, licenseType, modelDefinitionApplied, protectionPolicy, userData, timeCreated);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineData VirtualMachineData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, VirtualMachineOSProfile osProfile , VirtualMachineNetworkProfile networkProfile, SecurityProfile securityProfile, BootDiagnostics bootDiagnostics, ResourceIdentifier availabilitySetId, ResourceIdentifier virtualMachineScaleSetId, ResourceIdentifier proximityPlacementGroupId, VirtualMachinePriorityType? priority, VirtualMachineEvictionPolicyType? evictionPolicy, double? billingMaxPrice, ResourceIdentifier hostId, ResourceIdentifier hostGroupId, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ComputeScheduledEventsProfile scheduledEventsProfile, string userData, ResourceIdentifier capacityReservationGroupId, IEnumerable<VirtualMachineGalleryApplication> galleryApplications, DateTimeOffset? timeCreated)
            => VirtualMachineData(id, name, resourceType, systemData, tags, location, plan, resources, identity, zones, extendedLocation, null, null, hardwareProfile, storageProfile, additionalCapabilities, osProfile, networkProfile, securityProfile, bootDiagnostics, availabilitySetId, virtualMachineScaleSetId, proximityPlacementGroupId, priority, evictionPolicy, billingMaxPrice, hostId, hostGroupId, provisioningState, instanceView, licenseType, vmId, extensionsTimeBudget, platformFaultDomain, scheduledEventsProfile, userData, capacityReservationGroupId, galleryApplications, timeCreated);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineInstanceView VirtualMachineInstanceView(int? platformUpdateDomain, int? platformFaultDomain, string computerName, string osName, string osVersion, HyperVGeneration? hyperVGeneration, string rdpThumbPrint, VirtualMachineAgentInstanceView vmAgent, MaintenanceRedeployStatus maintenanceRedeployStatus, IEnumerable<DiskInstanceView> disks, IEnumerable<VirtualMachineExtensionInstanceView> extensions, InstanceViewStatus vmHealthStatus, BootDiagnosticsInstanceView bootDiagnostics, string assignedHost, IEnumerable<InstanceViewStatus> statuses, VirtualMachinePatchStatus patchStatus)
            => VirtualMachineInstanceView(platformUpdateDomain, platformFaultDomain, computerName, osName, osVersion, hyperVGeneration, rdpThumbPrint, vmAgent, maintenanceRedeployStatus, disks, extensions, vmHealthStatus, bootDiagnostics, assignedHost, statuses, patchStatus, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationGroupData CapacityReservationGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, IEnumerable<SubResource> capacityReservations, IEnumerable<SubResource> virtualMachinesAssociated, IEnumerable<CapacityReservationInstanceViewWithName> instanceViewCapacityReservations)
            => CapacityReservationGroupData(id, name, resourceType, systemData, tags, location, zones, capacityReservations, virtualMachinesAssociated, null, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GalleryImageVersionData GalleryImageVersionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, GalleryImageVersionPublishingProfile publishingProfile, GalleryProvisioningState? provisioningState, GalleryImageVersionStorageProfile storageProfile, GalleryImageVersionSafetyProfile safetyProfile, ReplicationStatus replicationStatus)
            => GalleryImageVersionData(id, name, resourceType, systemData, tags, location, publishingProfile, provisioningState, storageProfile, safetyProfile, replicationStatus, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryData SharedGalleryData(string name, AzureLocation? location, string uniqueId)
            => SharedGalleryData(name, location, uniqueId, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageData SharedGalleryImageData(string name, AzureLocation? location, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, GalleryImageIdentifier identifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula)
            => SharedGalleryImageData(name, location, uniqueId, osType, osState, endOfLifeOn, identifier, recommended, disallowedDiskTypes, hyperVGeneration, features, purchasePlan, architecture, privacyStatementUri, eula, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageVersionData SharedGalleryImageVersionData(string name, AzureLocation? location, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile)
            => SharedGalleryImageVersionData(name, location, uniqueId, publishedOn, endOfLifeOn, isExcludedFromLatest, storageProfile, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryData CommunityGalleryData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId)
            => CommunityGalleryData(name, location, resourceType, uniqueId, null, null, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageData CommunityGalleryImageData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, CommunityGalleryImageIdentifier imageIdentifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula)
            => CommunityGalleryImageData(name, location, resourceType, uniqueId, osType, osState, endOfLifeOn, imageIdentifier, recommended, disallowedDiskTypes, hyperVGeneration, features, purchasePlan, architecture, privacyStatementUri, eula, null, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageVersionData CommunityGalleryImageVersionData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile)
            => CommunityGalleryImageVersionData(name, location, resourceType, uniqueId, publishedOn, endOfLifeOn, isExcludedFromLatest, storageProfile, null, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static  CommunityGalleryInfo CommunityGalleryInfo(Uri publisherUri = null, string publisherContact = null, string eula = null, string publicNamePrefix = null, bool? communityGalleryEnabled = null, IEnumerable<string> publicNames = null)
            => CommunityGalleryInfo(publisherUri.AbsoluteUri, publisherContact, eula, publicNamePrefix, communityGalleryEnabled, publicNames?.ToList());
    }
}
