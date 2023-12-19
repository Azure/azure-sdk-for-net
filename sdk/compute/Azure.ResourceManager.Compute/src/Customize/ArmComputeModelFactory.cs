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
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();

            return new VirtualMachineScaleSetData(id, name, resourceType, systemData, tags, location, sku, plan, identity, zones?.ToList(), extendedLocation, null, upgradePolicy, automaticRepairsPolicy, virtualMachineProfile, provisioningState, overprovision, doNotRunExtensionsOnOverprovisionedVms, uniqueId, singlePlacementGroup, zoneBalance, platformFaultDomainCount, proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, hostGroupId != null ? ResourceManagerModelFactory.WritableSubResource(hostGroupId) : null, additionalCapabilities, scaleInPolicy, orchestrationMode, spotRestorePolicy, priorityMixPolicy, timeCreated, isMaximumCapacityConstrained, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, ComputeSku sku, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, IEnumerable<string> zones, ManagedServiceIdentity identity, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVmInstanceView instanceView, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, VirtualMachineOSProfile osProfile, SecurityProfile securityProfile, VirtualMachineNetworkProfile networkProfile, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations, BootDiagnostics bootDiagnostics, ResourceIdentifier availabilitySetId, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy, string userData, DateTimeOffset? timeCreated)
        {
            tags ??= new Dictionary<string, string>();
            resources ??= new List<VirtualMachineExtensionData>();
            zones ??= new List<string>();
            networkInterfaceConfigurations ??= new List<VirtualMachineScaleSetNetworkConfiguration>();

            return new VirtualMachineScaleSetVmData(id, name, resourceType, systemData, tags, location, instanceId, sku, plan, resources?.ToList(), zones?.ToList(), identity, null, latestModelApplied, vmId, instanceView, hardwareProfile, storageProfile, additionalCapabilities, osProfile, securityProfile, networkProfile, networkInterfaceConfigurations != null ? new VirtualMachineScaleSetVmNetworkProfileConfiguration(networkInterfaceConfigurations?.ToList()) : null, bootDiagnostics != null ? new DiagnosticsProfile(bootDiagnostics) : null, availabilitySetId != null ? ResourceManagerModelFactory.WritableSubResource(availabilitySetId) : null, provisioningState, licenseType, modelDefinitionApplied, protectionPolicy, userData, timeCreated);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineData VirtualMachineData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, VirtualMachineOSProfile osProfile , VirtualMachineNetworkProfile networkProfile, SecurityProfile securityProfile, BootDiagnostics bootDiagnostics, ResourceIdentifier availabilitySetId, ResourceIdentifier virtualMachineScaleSetId, ResourceIdentifier proximityPlacementGroupId, VirtualMachinePriorityType? priority, VirtualMachineEvictionPolicyType? evictionPolicy, double? billingMaxPrice, ResourceIdentifier hostId, ResourceIdentifier hostGroupId, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ComputeScheduledEventsProfile scheduledEventsProfile, string userData, ResourceIdentifier capacityReservationGroupId, IEnumerable<VirtualMachineGalleryApplication> galleryApplications, DateTimeOffset? timeCreated)
        {
            tags ??= new Dictionary<string, string>();
            resources ??= new List<VirtualMachineExtensionData>();
            zones ??= new List<string>();
            galleryApplications ??= new List<VirtualMachineGalleryApplication>();

            return new VirtualMachineData(id, name, resourceType, systemData, tags, location, plan, resources?.ToList(), identity, zones?.ToList(), extendedLocation, null, null, hardwareProfile, storageProfile, additionalCapabilities, osProfile, networkProfile, securityProfile, bootDiagnostics != null ? new DiagnosticsProfile(bootDiagnostics) : null, availabilitySetId != null ? ResourceManagerModelFactory.WritableSubResource(availabilitySetId) : null, virtualMachineScaleSetId != null ? ResourceManagerModelFactory.WritableSubResource(virtualMachineScaleSetId) : null, proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, priority, evictionPolicy, billingMaxPrice != null ? new BillingProfile(billingMaxPrice) : null, hostId != null ? ResourceManagerModelFactory.WritableSubResource(hostId) : null, hostGroupId != null ? ResourceManagerModelFactory.WritableSubResource(hostGroupId) : null, provisioningState, instanceView, licenseType, vmId, extensionsTimeBudget, platformFaultDomain, scheduledEventsProfile, userData, capacityReservationGroupId != null ? new CapacityReservationProfile(ResourceManagerModelFactory.WritableSubResource(capacityReservationGroupId)) : null, galleryApplications != null ? new ApplicationProfile(galleryApplications?.ToList()) : null, timeCreated);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineInstanceView VirtualMachineInstanceView(int? platformUpdateDomain, int? platformFaultDomain, string computerName, string osName, string osVersion, HyperVGeneration? hyperVGeneration, string rdpThumbPrint, VirtualMachineAgentInstanceView vmAgent, MaintenanceRedeployStatus maintenanceRedeployStatus, IEnumerable<DiskInstanceView> disks, IEnumerable<VirtualMachineExtensionInstanceView> extensions, InstanceViewStatus vmHealthStatus, BootDiagnosticsInstanceView bootDiagnostics, string assignedHost, IEnumerable<InstanceViewStatus> statuses, VirtualMachinePatchStatus patchStatus)
        {
            disks ??= new List<DiskInstanceView>();
            extensions ??= new List<VirtualMachineExtensionInstanceView>();
            statuses ??= new List<InstanceViewStatus>();

            return new VirtualMachineInstanceView(platformUpdateDomain, platformFaultDomain, computerName, osName, osVersion, hyperVGeneration, rdpThumbPrint, vmAgent, maintenanceRedeployStatus, disks?.ToList(), extensions?.ToList(), vmHealthStatus != null ? new VirtualMachineHealthStatus(vmHealthStatus) : null, bootDiagnostics, assignedHost, statuses?.ToList(), patchStatus, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationGroupData CapacityReservationGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, IEnumerable<SubResource> capacityReservations, IEnumerable<SubResource> virtualMachinesAssociated, IEnumerable<CapacityReservationInstanceViewWithName> instanceViewCapacityReservations)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            capacityReservations ??= new List<SubResource>();
            virtualMachinesAssociated ??= new List<SubResource>();

            return new CapacityReservationGroupData(id, name, resourceType, systemData, tags, location, zones?.ToList(), capacityReservations?.ToList(), virtualMachinesAssociated?.ToList(), null, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GalleryImageVersionData GalleryImageVersionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, GalleryImageVersionPublishingProfile publishingProfile, GalleryProvisioningState? provisioningState, GalleryImageVersionStorageProfile storageProfile, GalleryImageVersionSafetyProfile safetyProfile, ReplicationStatus replicationStatus)
        {
            tags ??= new Dictionary<string, string>();

            return new GalleryImageVersionData(id, name, resourceType, systemData, tags, location, publishingProfile, provisioningState, storageProfile, safetyProfile, replicationStatus, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryData SharedGalleryData(string name, AzureLocation? location, string uniqueId)
        {
            return new SharedGalleryData(name, location, uniqueId, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageData SharedGalleryImageData(string name, AzureLocation? location, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, GalleryImageIdentifier identifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula)
        {
            disallowedDiskTypes ??= new List<string>();
            features ??= new List<GalleryImageFeature>();

            return new SharedGalleryImageData(name, location, uniqueId, osType, osState, endOfLifeOn, identifier, recommended, disallowedDiskTypes != null ? new Disallowed(disallowedDiskTypes?.ToList()) : null, hyperVGeneration, features?.ToList(), purchasePlan, architecture, privacyStatementUri, eula, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageVersionData SharedGalleryImageVersionData(string name, AzureLocation? location, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile)
        {
            return new SharedGalleryImageVersionData(name, location, uniqueId, publishedOn, endOfLifeOn, isExcludedFromLatest, storageProfile, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryData CommunityGalleryData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId)
        {
            return new CommunityGalleryData(name, location, resourceType, uniqueId, null, null, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageData CommunityGalleryImageData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, SupportedOperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, CommunityGalleryImageIdentifier imageIdentifier, RecommendedMachineConfiguration recommended, IEnumerable<string> disallowedDiskTypes, HyperVGeneration? hyperVGeneration, IEnumerable<GalleryImageFeature> features, ImagePurchasePlan purchasePlan, ArchitectureType? architecture, Uri privacyStatementUri, string eula)
        {
            disallowedDiskTypes ??= new List<string>();
            features ??= new List<GalleryImageFeature>();

            return new CommunityGalleryImageData(name, location, resourceType, uniqueId, osType, osState, endOfLifeOn, imageIdentifier, recommended, disallowedDiskTypes != null ? new Disallowed(disallowedDiskTypes?.ToList()) : null, hyperVGeneration, features?.ToList(), purchasePlan, architecture, privacyStatementUri, eula, null, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageVersionData CommunityGalleryImageVersionData(string name, AzureLocation? location, ResourceType? resourceType, string uniqueId, DateTimeOffset? publishedOn, DateTimeOffset? endOfLifeOn, bool? isExcludedFromLatest, SharedGalleryImageVersionStorageProfile storageProfile)
        {
            return new CommunityGalleryImageVersionData(name, location, resourceType, uniqueId, publishedOn, endOfLifeOn, isExcludedFromLatest, storageProfile, null, null);
        }
    }
}
