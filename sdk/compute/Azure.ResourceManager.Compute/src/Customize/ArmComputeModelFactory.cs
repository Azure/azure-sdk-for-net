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
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ComputeSku sku = null, ComputePlan plan = null, ManagedServiceIdentity identity = null, IEnumerable<string> zones = null, ExtendedLocation extendedLocation = null, VirtualMachineScaleSetUpgradePolicy upgradePolicy = null, AutomaticRepairsPolicy automaticRepairsPolicy = null, VirtualMachineScaleSetVmProfile virtualMachineProfile = null, string provisioningState = null, bool? overprovision = null, bool? doNotRunExtensionsOnOverprovisionedVms = null, string uniqueId = null, bool? singlePlacementGroup = null, bool? zoneBalance = null, int? platformFaultDomainCount = null, ResourceIdentifier proximityPlacementGroupId = null, ResourceIdentifier hostGroupId = null, AdditionalCapabilities additionalCapabilities = null, ScaleInPolicy scaleInPolicy = null, OrchestrationMode? orchestrationMode = null, SpotRestorePolicy spotRestorePolicy = null, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy = null, DateTimeOffset? timeCreated = null, bool? isMaximumCapacityConstrained = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();

            return new VirtualMachineScaleSetData(id, name, resourceType, systemData, tags, location, sku, plan, identity, zones?.ToList(), extendedLocation, null, upgradePolicy, automaticRepairsPolicy, virtualMachineProfile, provisioningState, overprovision, doNotRunExtensionsOnOverprovisionedVms, uniqueId, singlePlacementGroup, zoneBalance, platformFaultDomainCount, proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, hostGroupId != null ? ResourceManagerModelFactory.WritableSubResource(hostGroupId) : null, additionalCapabilities, scaleInPolicy, orchestrationMode, spotRestorePolicy, priorityMixPolicy, timeCreated, isMaximumCapacityConstrained, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string instanceId = null, ComputeSku sku = null, ComputePlan plan = null, IEnumerable<VirtualMachineExtensionData> resources = null, IEnumerable<string> zones = null, ManagedServiceIdentity identity = null, bool? latestModelApplied = null, string vmId = null, VirtualMachineScaleSetVmInstanceView instanceView = null, VirtualMachineHardwareProfile hardwareProfile = null, VirtualMachineStorageProfile storageProfile = null, AdditionalCapabilities additionalCapabilities = null, VirtualMachineOSProfile osProfile = null, SecurityProfile securityProfile = null, VirtualMachineNetworkProfile networkProfile = null, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations = null, BootDiagnostics bootDiagnostics = null, ResourceIdentifier availabilitySetId = null, string provisioningState = null, string licenseType = null, string modelDefinitionApplied = null, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy = null, string userData = null, DateTimeOffset? timeCreated = null)
        {
            tags ??= new Dictionary<string, string>();
            resources ??= new List<VirtualMachineExtensionData>();
            zones ??= new List<string>();
            networkInterfaceConfigurations ??= new List<VirtualMachineScaleSetNetworkConfiguration>();

            return new VirtualMachineScaleSetVmData(id, name, resourceType, systemData, tags, location, instanceId, sku, plan, resources?.ToList(), zones?.ToList(), identity, null, latestModelApplied, vmId, instanceView, hardwareProfile, storageProfile, additionalCapabilities, osProfile, securityProfile, networkProfile, networkInterfaceConfigurations != null ? new VirtualMachineScaleSetVmNetworkProfileConfiguration(networkInterfaceConfigurations?.ToList()) : null, bootDiagnostics != null ? new DiagnosticsProfile(bootDiagnostics) : null, availabilitySetId != null ? ResourceManagerModelFactory.WritableSubResource(availabilitySetId) : null, provisioningState, licenseType, modelDefinitionApplied, protectionPolicy, userData, timeCreated);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineData VirtualMachineData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities , VirtualMachineOSProfile osProfile , VirtualMachineNetworkProfile networkProfile, SecurityProfile securityProfile = null, BootDiagnostics bootDiagnostics = null, ResourceIdentifier availabilitySetId = null, ResourceIdentifier virtualMachineScaleSetId = null, ResourceIdentifier proximityPlacementGroupId = null, VirtualMachinePriorityType? priority = null, VirtualMachineEvictionPolicyType? evictionPolicy = null, double? billingMaxPrice = null, ResourceIdentifier hostId = null, ResourceIdentifier hostGroupId = null, string provisioningState = null, VirtualMachineInstanceView instanceView = null, string licenseType = null, string vmId = null, string extensionsTimeBudget = null, int? platformFaultDomain = null, ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, ResourceIdentifier capacityReservationGroupId = null, IEnumerable<VirtualMachineGalleryApplication> galleryApplications = null, DateTimeOffset? timeCreated = null)
        {
            tags ??= new Dictionary<string, string>();
            resources ??= new List<VirtualMachineExtensionData>();
            zones ??= new List<string>();
            galleryApplications ??= new List<VirtualMachineGalleryApplication>();

            return new VirtualMachineData(id, name, resourceType, systemData, tags, location, plan, resources?.ToList(), identity, zones?.ToList(), extendedLocation, null, null, hardwareProfile, storageProfile, additionalCapabilities, osProfile, networkProfile, securityProfile, bootDiagnostics != null ? new DiagnosticsProfile(bootDiagnostics) : null, availabilitySetId != null ? ResourceManagerModelFactory.WritableSubResource(availabilitySetId) : null, virtualMachineScaleSetId != null ? ResourceManagerModelFactory.WritableSubResource(virtualMachineScaleSetId) : null, proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, priority, evictionPolicy, billingMaxPrice != null ? new BillingProfile(billingMaxPrice) : null, hostId != null ? ResourceManagerModelFactory.WritableSubResource(hostId) : null, hostGroupId != null ? ResourceManagerModelFactory.WritableSubResource(hostGroupId) : null, provisioningState, instanceView, licenseType, vmId, extensionsTimeBudget, platformFaultDomain, scheduledEventsProfile, userData, capacityReservationGroupId != null ? new CapacityReservationProfile(ResourceManagerModelFactory.WritableSubResource(capacityReservationGroupId)) : null, galleryApplications != null ? new ApplicationProfile(galleryApplications?.ToList()) : null, timeCreated);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineInstanceView VirtualMachineInstanceView(int? platformUpdateDomain = null, int? platformFaultDomain = null, string computerName = null, string osName = null, string osVersion = null, HyperVGeneration? hyperVGeneration = null, string rdpThumbPrint = null, VirtualMachineAgentInstanceView vmAgent = null, MaintenanceRedeployStatus maintenanceRedeployStatus = null, IEnumerable<DiskInstanceView> disks = null, IEnumerable<VirtualMachineExtensionInstanceView> extensions = null, InstanceViewStatus vmHealthStatus = null, BootDiagnosticsInstanceView bootDiagnostics = null, string assignedHost = null, IEnumerable<InstanceViewStatus> statuses = null, VirtualMachinePatchStatus patchStatus = null)
        {
            disks ??= new List<DiskInstanceView>();
            extensions ??= new List<VirtualMachineExtensionInstanceView>();
            statuses ??= new List<InstanceViewStatus>();

            return new VirtualMachineInstanceView(platformUpdateDomain, platformFaultDomain, computerName, osName, osVersion, hyperVGeneration, rdpThumbPrint, vmAgent, maintenanceRedeployStatus, disks?.ToList(), extensions?.ToList(), vmHealthStatus != null ? new VirtualMachineHealthStatus(vmHealthStatus) : null, bootDiagnostics, assignedHost, statuses?.ToList(), patchStatus, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityReservationGroupData CapacityReservationGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, IEnumerable<string> zones = null, IEnumerable<SubResource> capacityReservations = null, IEnumerable<SubResource> virtualMachinesAssociated = null, IEnumerable<CapacityReservationInstanceViewWithName> instanceViewCapacityReservations = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            capacityReservations ??= new List<SubResource>();
            virtualMachinesAssociated ??= new List<SubResource>();

            return new CapacityReservationGroupData(id, name, resourceType, systemData, tags, location, zones?.ToList(), capacityReservations?.ToList(), virtualMachinesAssociated?.ToList(), null, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GalleryImageVersionData GalleryImageVersionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, GalleryImageVersionPublishingProfile publishingProfile = null, GalleryProvisioningState? provisioningState = null, GalleryImageVersionStorageProfile storageProfile = null, GalleryImageVersionSafetyProfile safetyProfile = null, ReplicationStatus replicationStatus = null)
        {
            tags ??= new Dictionary<string, string>();

            return new GalleryImageVersionData(id, name, resourceType, systemData, tags, location, publishingProfile, provisioningState, storageProfile, safetyProfile, replicationStatus, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryData SharedGalleryData(string name = null, AzureLocation? location = null, string uniqueId = null)
        {
            return new SharedGalleryData(name, location, uniqueId, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageData SharedGalleryImageData(string name = null, AzureLocation? location = null, string uniqueId = null, SupportedOperatingSystemType? osType = null, OperatingSystemStateType? osState = null, DateTimeOffset? endOfLifeOn = null, GalleryImageIdentifier identifier = null, RecommendedMachineConfiguration recommended = null, IEnumerable<string> disallowedDiskTypes = null, HyperVGeneration? hyperVGeneration = null, IEnumerable<GalleryImageFeature> features = null, ImagePurchasePlan purchasePlan = null, ArchitectureType? architecture = null, Uri privacyStatementUri = null, string eula = null)
        {
            disallowedDiskTypes ??= new List<string>();
            features ??= new List<GalleryImageFeature>();

            return new SharedGalleryImageData(name, location, uniqueId, osType, osState, endOfLifeOn, identifier, recommended, disallowedDiskTypes != null ? new Disallowed(disallowedDiskTypes?.ToList()) : null, hyperVGeneration, features?.ToList(), purchasePlan, architecture, privacyStatementUri, eula, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageVersionData SharedGalleryImageVersionData(string name = null, AzureLocation? location = null, string uniqueId = null, DateTimeOffset? publishedOn = null, DateTimeOffset? endOfLifeOn = null, bool? isExcludedFromLatest = null, SharedGalleryImageVersionStorageProfile storageProfile = null)
        {
            return new SharedGalleryImageVersionData(name, location, uniqueId, publishedOn, endOfLifeOn, isExcludedFromLatest, storageProfile, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryData CommunityGalleryData(string name = null, AzureLocation? location = null, ResourceType? resourceType = null, string uniqueId = null)
        {
            return new CommunityGalleryData(name, location, resourceType, uniqueId, null, null, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageData CommunityGalleryImageData(string name = null, AzureLocation? location = null, ResourceType? resourceType = null, string uniqueId = null, SupportedOperatingSystemType? osType = null, OperatingSystemStateType? osState = null, DateTimeOffset? endOfLifeOn = null, CommunityGalleryImageIdentifier imageIdentifier = null, RecommendedMachineConfiguration recommended = null, IEnumerable<string> disallowedDiskTypes = null, HyperVGeneration? hyperVGeneration = null, IEnumerable<GalleryImageFeature> features = null, ImagePurchasePlan purchasePlan = null, ArchitectureType? architecture = null, Uri privacyStatementUri = null, string eula = null)
        {
            disallowedDiskTypes ??= new List<string>();
            features ??= new List<GalleryImageFeature>();

            return new CommunityGalleryImageData(name, location, resourceType, uniqueId, osType, osState, endOfLifeOn, imageIdentifier, recommended, disallowedDiskTypes != null ? new Disallowed(disallowedDiskTypes?.ToList()) : null, hyperVGeneration, features?.ToList(), purchasePlan, architecture, privacyStatementUri, eula, null, null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageVersionData CommunityGalleryImageVersionData(string name = null, AzureLocation? location = null, ResourceType? resourceType = null, string uniqueId = null, DateTimeOffset? publishedOn = null, DateTimeOffset? endOfLifeOn = null, bool? isExcludedFromLatest = null, SharedGalleryImageVersionStorageProfile storageProfile = null)
        {
            return new CommunityGalleryImageVersionData(name, location, resourceType, uniqueId, publishedOn, endOfLifeOn, isExcludedFromLatest, storageProfile, null, null);
        }
    }
}
