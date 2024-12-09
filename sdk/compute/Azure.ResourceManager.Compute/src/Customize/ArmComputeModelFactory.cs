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

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmComputeModelFactory
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, ComputePlan plan, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, VirtualMachineScaleSetUpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVmProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVms, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, ResourceIdentifier proximityPlacementGroupId, ResourceIdentifier hostGroupId, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, OrchestrationMode? orchestrationMode, SpotRestorePolicy spotRestorePolicy, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy, DateTimeOffset? timeCreated, bool? isMaximumCapacityConstrained)
            => VirtualMachineScaleSetData(id, name, resourceType, systemData, tags, location, sku, plan, identity, zones, extendedLocation, null, upgradePolicy, automaticRepairsPolicy, virtualMachineProfile, provisioningState, overprovision, doNotRunExtensionsOnOverprovisionedVms, uniqueId, singlePlacementGroup, zoneBalance, platformFaultDomainCount, proximityPlacementGroupId, hostGroupId, additionalCapabilities, scaleInPolicy, orchestrationMode, spotRestorePolicy, priorityMixPolicy, timeCreated, isMaximumCapacityConstrained, null);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.VirtualMachineScaleSetData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The virtual machine scale set sku. </param>
        /// <param name="plan"> Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**. </param>
        /// <param name="identity"> The identity of the virtual machine scale set, if configured. </param>
        /// <param name="zones"> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </param>
        /// <param name="extendedLocation"> The extended location of the Virtual Machine Scale Set. </param>
        /// <param name="etag"> Etag is property returned in Create/Update/Get response of the VMSS, so that customer can supply it in the header to ensure optimistic updates. </param>
        /// <param name="upgradePolicy"> The upgrade policy. </param>
        /// <param name="scheduledEventsPolicy"> The ScheduledEventsPolicy. </param>
        /// <param name="automaticRepairsPolicy"> Policy for automatic repairs. </param>
        /// <param name="virtualMachineProfile"> The virtual machine profile. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="overprovision"> Specifies whether the Virtual Machine Scale Set should be overprovisioned. </param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVms"> When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs. </param>
        /// <param name="uniqueId"> Specifies the ID which uniquely identifies a Virtual Machine Scale Set. </param>
        /// <param name="singlePlacementGroup"> When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true. </param>
        /// <param name="zoneBalance"> Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage. zoneBalance property can only be set if the zones property of the scale set contains more than one zone. If there are no zones or only one zone specified, then zoneBalance property should not be set. </param>
        /// <param name="platformFaultDomainCount"> Fault Domain count for each placement group. </param>
        /// <param name="proximityPlacementGroupId"> Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. Minimum api-version: 2018-04-01. </param>
        /// <param name="hostGroupId"> Specifies information about the dedicated host group that the virtual machine scale set resides in. Minimum api-version: 2020-06-01. </param>
        /// <param name="additionalCapabilities"> Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type. </param>
        /// <param name="scaleInPolicy"> Specifies the policies applied when scaling in Virtual Machines in the Virtual Machine Scale Set. </param>
        /// <param name="orchestrationMode"> Specifies the orchestration mode for the virtual machine scale set. </param>
        /// <param name="spotRestorePolicy"> Specifies the Spot Restore properties for the virtual machine scale set. </param>
        /// <param name="priorityMixPolicy"> Specifies the desired targets for mixing Spot and Regular priority VMs within the same VMSS Flex instance. </param>
        /// <param name="timeCreated"> Specifies the time at which the Virtual Machine Scale Set resource was created. Minimum api-version: 2021-11-01. </param>
        /// <param name="isMaximumCapacityConstrained"> Optional property which must either be set to True or omitted. </param>
        /// <param name="resiliencyPolicy"> Policy for Resiliency. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.VirtualMachineScaleSetData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, ComputePlan plan, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, string etag, VirtualMachineScaleSetUpgradePolicy upgradePolicy, ScheduledEventsPolicy scheduledEventsPolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVmProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVms, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, ResourceIdentifier proximityPlacementGroupId, ResourceIdentifier hostGroupId, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, OrchestrationMode? orchestrationMode, SpotRestorePolicy spotRestorePolicy, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy, DateTimeOffset? timeCreated, bool? isMaximumCapacityConstrained, ResiliencyPolicy resiliencyPolicy)
        {
            return VirtualMachineScaleSetData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, sku: sku, plan: plan, identity: identity, zones: zones, extendedLocation: extendedLocation, etag: etag, upgradePolicy: upgradePolicy, scheduledEventsPolicy: scheduledEventsPolicy, automaticRepairsPolicy: automaticRepairsPolicy, virtualMachineProfile: virtualMachineProfile, provisioningState: provisioningState, overprovision: overprovision, doNotRunExtensionsOnOverprovisionedVms: doNotRunExtensionsOnOverprovisionedVms, uniqueId: uniqueId, singlePlacementGroup: singlePlacementGroup, zoneBalance: zoneBalance, platformFaultDomainCount: platformFaultDomainCount, proximityPlacementGroupId: proximityPlacementGroupId, hostGroupId: hostGroupId, additionalCapabilities: additionalCapabilities, scaleInPolicy: scaleInPolicy, orchestrationMode: orchestrationMode, spotRestorePolicy: spotRestorePolicy, priorityMixPolicy: priorityMixPolicy, timeCreated: timeCreated, isMaximumCapacityConstrained: isMaximumCapacityConstrained, resiliencyPolicy: resiliencyPolicy, zonalPlatformFaultDomainAlignMode: default, skuProfile: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.VirtualMachineScaleSetData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The virtual machine scale set sku. </param>
        /// <param name="plan"> Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**. </param>
        /// <param name="identity"> The identity of the virtual machine scale set, if configured. </param>
        /// <param name="zones"> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </param>
        /// <param name="extendedLocation"> The extended location of the Virtual Machine Scale Set. </param>
        /// <param name="etag"> Etag is property returned in Create/Update/Get response of the VMSS, so that customer can supply it in the header to ensure optimistic updates. </param>
        /// <param name="upgradePolicy"> The upgrade policy. </param>
        /// <param name="automaticRepairsPolicy"> Policy for automatic repairs. </param>
        /// <param name="virtualMachineProfile"> The virtual machine profile. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="overprovision"> Specifies whether the Virtual Machine Scale Set should be overprovisioned. </param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVms"> When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs. </param>
        /// <param name="uniqueId"> Specifies the ID which uniquely identifies a Virtual Machine Scale Set. </param>
        /// <param name="singlePlacementGroup"> When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true. </param>
        /// <param name="zoneBalance"> Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage. zoneBalance property can only be set if the zones property of the scale set contains more than one zone. If there are no zones or only one zone specified, then zoneBalance property should not be set. </param>
        /// <param name="platformFaultDomainCount"> Fault Domain count for each placement group. </param>
        /// <param name="proximityPlacementGroupId"> Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. Minimum api-version: 2018-04-01. </param>
        /// <param name="hostGroupId"> Specifies information about the dedicated host group that the virtual machine scale set resides in. Minimum api-version: 2020-06-01. </param>
        /// <param name="additionalCapabilities"> Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type. </param>
        /// <param name="scaleInPolicy"> Specifies the policies applied when scaling in Virtual Machines in the Virtual Machine Scale Set. </param>
        /// <param name="orchestrationMode"> Specifies the orchestration mode for the virtual machine scale set. </param>
        /// <param name="spotRestorePolicy"> Specifies the Spot Restore properties for the virtual machine scale set. </param>
        /// <param name="priorityMixPolicy"> Specifies the desired targets for mixing Spot and Regular priority VMs within the same VMSS Flex instance. </param>
        /// <param name="timeCreated"> Specifies the time at which the Virtual Machine Scale Set resource was created. Minimum api-version: 2021-11-01. </param>
        /// <param name="isMaximumCapacityConstrained"> Optional property which must either be set to True or omitted. </param>
        /// <param name="resiliencyPolicy"> Policy for Resiliency. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.VirtualMachineScaleSetData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, ComputePlan plan, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, string etag, VirtualMachineScaleSetUpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVmProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVms, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, ResourceIdentifier proximityPlacementGroupId, ResourceIdentifier hostGroupId, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, OrchestrationMode? orchestrationMode, SpotRestorePolicy spotRestorePolicy, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy, DateTimeOffset? timeCreated, bool? isMaximumCapacityConstrained, ResiliencyPolicy resiliencyPolicy)
        {
            return VirtualMachineScaleSetData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, sku: sku, plan: plan, identity: identity, zones: zones, extendedLocation: extendedLocation, etag: etag, upgradePolicy: upgradePolicy, scheduledEventsPolicy: default, automaticRepairsPolicy: automaticRepairsPolicy, virtualMachineProfile: virtualMachineProfile, provisioningState: provisioningState, overprovision: overprovision, doNotRunExtensionsOnOverprovisionedVms: doNotRunExtensionsOnOverprovisionedVms, uniqueId: uniqueId, singlePlacementGroup: singlePlacementGroup, zoneBalance: zoneBalance, platformFaultDomainCount: platformFaultDomainCount, proximityPlacementGroupId: proximityPlacementGroupId, hostGroupId: hostGroupId, additionalCapabilities: additionalCapabilities, scaleInPolicy: scaleInPolicy, orchestrationMode: orchestrationMode, spotRestorePolicy: spotRestorePolicy, priorityMixPolicy: priorityMixPolicy, timeCreated: timeCreated, isMaximumCapacityConstrained: isMaximumCapacityConstrained, resiliencyPolicy: resiliencyPolicy, zonalPlatformFaultDomainAlignMode: default, skuProfile: default);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ComputeSku sku = null, ComputePlan plan = null, ManagedServiceIdentity identity = null, IEnumerable<string> zones = null, ExtendedLocation extendedLocation = null, string etag = null, VirtualMachineScaleSetUpgradePolicy upgradePolicy = null, ScheduledEventsPolicy scheduledEventsPolicy = null, AutomaticRepairsPolicy automaticRepairsPolicy = null, VirtualMachineScaleSetVmProfile virtualMachineProfile = null, string provisioningState = null, bool? overprovision = null, bool? doNotRunExtensionsOnOverprovisionedVms = null, string uniqueId = null, bool? singlePlacementGroup = null, bool? zoneBalance = null, int? platformFaultDomainCount = null, ResourceIdentifier proximityPlacementGroupId = null, ResourceIdentifier hostGroupId = null, AdditionalCapabilities additionalCapabilities = null, ScaleInPolicy scaleInPolicy = null, OrchestrationMode? orchestrationMode = null, SpotRestorePolicy spotRestorePolicy = null, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy = null, DateTimeOffset? timeCreated = null, bool? isMaximumCapacityConstrained = null, ResiliencyPolicy resiliencyPolicy = null, ZonalPlatformFaultDomainAlignMode? zonalPlatformFaultDomainAlignMode = null, ComputeSkuProfile skuProfile = null)
        {
            return VirtualMachineScaleSetData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                sku: sku,
                plan: plan,
                properties: VirtualMachineScaleSetProperties(
                    upgradePolicy: upgradePolicy,
                    scheduledEventsPolicy: scheduledEventsPolicy,
                    automaticRepairsPolicy: automaticRepairsPolicy,
                    virtualMachineProfile: virtualMachineProfile,
                    provisioningState: provisioningState,
                    overprovision: overprovision,
                    doNotRunExtensionsOnOverprovisionedVms: doNotRunExtensionsOnOverprovisionedVms,
                    uniqueId: uniqueId,
                    singlePlacementGroup: singlePlacementGroup,
                    zoneBalance: zoneBalance,
                    platformFaultDomainCount: platformFaultDomainCount,
                    proximityPlacementGroupId: proximityPlacementGroupId,
                    hostGroupId: hostGroupId,
                    additionalCapabilities: additionalCapabilities,
                    scaleInPolicy: scaleInPolicy,
                    orchestrationMode: orchestrationMode,
                    spotRestorePolicy: spotRestorePolicy,
                    priorityMixPolicy: priorityMixPolicy,
                    timeCreated: timeCreated,
                    isMaximumCapacityConstrained: isMaximumCapacityConstrained,
                    resiliencyPolicy: resiliencyPolicy,
                    zonalPlatformFaultDomainAlignMode: zonalPlatformFaultDomainAlignMode,
                    skuProfile: skuProfile),
                identity: identity,
                zones: zones,
                extendedLocation: extendedLocation,
                etag: etag);
        }

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
