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
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ComputeSku sku, ComputePlan plan, ManagedServiceIdentity identity, IEnumerable<string> zones, ExtendedLocation extendedLocation, string etag, VirtualMachineScaleSetUpgradePolicy upgradePolicy = null, ScheduledEventsPolicy scheduledEventsPolicy = null, AutomaticRepairsPolicy automaticRepairsPolicy = null, VirtualMachineScaleSetVmProfile virtualMachineProfile = null, string provisioningState = null, bool? overprovision = null, bool? doNotRunExtensionsOnOverprovisionedVms = null, string uniqueId = null, bool? singlePlacementGroup = null, bool? zoneBalance = null, int? platformFaultDomainCount = null, ResourceIdentifier proximityPlacementGroupId = null, ResourceIdentifier hostGroupId = null, AdditionalCapabilities additionalCapabilities = null, ScaleInPolicy scaleInPolicy = null, OrchestrationMode? orchestrationMode = null, SpotRestorePolicy spotRestorePolicy = null, VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy = null, DateTimeOffset? timeCreated = null, bool? isMaximumCapacityConstrained = null, ResiliencyPolicy resiliencyPolicy = null, ZonalPlatformFaultDomainAlignMode? zonalPlatformFaultDomainAlignMode = null, ComputeSkuProfile skuProfile = null)
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
        public static CapacityReservationGroupData CapacityReservationGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IEnumerable<string> zones, IEnumerable<SubResource> capacityReservations, IEnumerable<SubResource> virtualMachinesAssociated, IEnumerable<CapacityReservationInstanceViewWithName> instanceViewCapacityReservations)
            => CapacityReservationGroupData(id, name, resourceType, systemData, tags, location, zones, capacityReservations, virtualMachinesAssociated, null, null);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryInfo CommunityGalleryInfo(Uri publisherUri = null, string publisherContact = null, string eula = null, string publicNamePrefix = null, bool? communityGalleryEnabled = null, IEnumerable<string> publicNames = null)
            => CommunityGalleryInfo(publisherUri.AbsoluteUri, publisherContact, eula, publicNamePrefix, communityGalleryEnabled, publicNames?.ToList());

        /// <summary> Initializes a new instance of <see cref="Compute.VirtualMachineScaleSetVmData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="instanceId"> The virtual machine instance ID. </param>
        /// <param name="sku"> The virtual machine SKU. </param>
        /// <param name="plan"> Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**. </param>
        /// <param name="resources"> The virtual machine child extension resources. </param>
        /// <param name="zones"> The virtual machine zones. </param>
        /// <param name="identity"> The identity of the virtual machine, if configured. </param>
        /// <param name="etag"> Etag is property returned in Update/Get response of the VMSS VM, so that customer can supply it in the header to ensure optimistic updates. </param>
        /// <param name="latestModelApplied"> Specifies whether the latest model has been applied to the virtual machine. </param>
        /// <param name="vmId"> Azure VM unique ID. </param>
        /// <param name="instanceView"> The virtual machine instance view. </param>
        /// <param name="hardwareProfile"> Specifies the hardware settings for the virtual machine. </param>
        /// <param name="resilientVmDeletionStatus"> Specifies the resilient VM deletion status for the virtual machine. </param>
        /// <param name="storageProfile"> Specifies the storage settings for the virtual machine disks. </param>
        /// <param name="additionalCapabilities"> Specifies additional capabilities enabled or disabled on the virtual machine in the scale set. For instance: whether the virtual machine has the capability to support attaching managed data disks with UltraSSD_LRS storage account type. </param>
        /// <param name="osProfile"> Specifies the operating system settings for the virtual machine. </param>
        /// <param name="securityProfile"> Specifies the Security related profile settings for the virtual machine. </param>
        /// <param name="networkProfile"> Specifies the network interfaces of the virtual machine. </param>
        /// <param name="networkInterfaceConfigurations"> Specifies the network profile configuration of the virtual machine. </param>
        /// <param name="bootDiagnostics"> Specifies the boot diagnostic settings state. Minimum api-version: 2015-06-15. </param>
        /// <param name="availabilitySetId"> Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Availability sets overview](https://docs.microsoft.com/azure/virtual-machines/availability-set-overview). For more information on Azure planned maintenance, see [Maintenance and updates for Virtual Machines in Azure](https://docs.microsoft.com/azure/virtual-machines/maintenance-and-updates). Currently, a VM can only be added to availability set at creation time. An existing VM cannot be added to an availability set. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="licenseType"> Specifies that the image or disk that is being used was licensed on-premises. &lt;br&gt;&lt;br&gt; Possible values for Windows Server operating system are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; Possible values for Linux Server operating system are: &lt;br&gt;&lt;br&gt; RHEL_BYOS (for RHEL) &lt;br&gt;&lt;br&gt; SLES_BYOS (for SUSE) &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing) &lt;br&gt;&lt;br&gt; [Azure Hybrid Use Benefit for Linux Server](https://docs.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15. </param>
        /// <param name="modelDefinitionApplied"> Specifies whether the model applied to the virtual machine is the model of the virtual machine scale set or the customized model for the virtual machine. </param>
        /// <param name="protectionPolicy"> Specifies the protection policy of the virtual machine. </param>
        /// <param name="userData"> UserData for the VM, which must be base-64 encoded. Customer should not pass any secrets in here. Minimum api-version: 2021-03-01. </param>
        /// <param name="timeCreated"> Specifies the time at which the Virtual Machine resource was created. Minimum api-version: 2021-11-01. </param>
        /// <returns> A new <see cref="Compute.VirtualMachineScaleSetVmData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, ComputeSku sku, ComputePlan plan = null, IEnumerable<VirtualMachineExtensionData> resources = null, IEnumerable<string> zones = null, ManagedServiceIdentity identity = null, string etag = null, bool? latestModelApplied = null, string vmId = null, VirtualMachineScaleSetVmInstanceView instanceView = null, VirtualMachineHardwareProfile hardwareProfile = null, ResilientVmDeletionStatus? resilientVmDeletionStatus = null, VirtualMachineStorageProfile storageProfile = null, AdditionalCapabilities additionalCapabilities = null, VirtualMachineOSProfile osProfile = null, SecurityProfile securityProfile = null, VirtualMachineNetworkProfile networkProfile = null, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations = null, BootDiagnostics bootDiagnostics = null, ResourceIdentifier availabilitySetId = null, string provisioningState = null, string licenseType = null, string modelDefinitionApplied = null, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy = null, string userData = null, DateTimeOffset? timeCreated = null)
        {
            return VirtualMachineScaleSetVmData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                VirtualMachineScaleSetVmProperties(
                    latestModelApplied,
                    vmId,
                    instanceView,
                    hardwareProfile,
                    resilientVmDeletionStatus,
                    storageProfile,
                    additionalCapabilities,
                    osProfile,
                    securityProfile,
                    networkProfile,
                    networkInterfaceConfigurations,
                    bootDiagnostics,
                    availabilitySetId,
                    provisioningState,
                    licenseType,
                    modelDefinitionApplied,
                    protectionPolicy,
                    userData,
                    timeCreated),
                instanceId,
                sku,
                plan,
                resources?.ToList(),
                zones?.ToList(),
                identity,
                etag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, ComputeSku sku, VirtualMachineScaleSetVmProperties properties, ComputePlan plan = null, IEnumerable<VirtualMachineExtensionData> resources = null, IEnumerable<string> zones = null, ManagedServiceIdentity identity = null, string etag = null)
        {
            return VirtualMachineScaleSetVmData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                properties,
                instanceId,
                sku,
                plan,
                resources,
                zones,
                identity,
                etag);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="instanceId"> The virtual machine instance ID. </param>
        /// <param name="sku"> The virtual machine SKU. </param>
        /// <param name="plan"> Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**. </param>
        /// <param name="resources"> The virtual machine child extension resources. </param>
        /// <param name="zones"> The virtual machine zones. </param>
        /// <param name="identity"> The identity of the virtual machine, if configured. </param>
        /// <param name="etag"> Etag is property returned in Update/Get response of the VMSS VM, so that customer can supply it in the header to ensure optimistic updates. </param>
        /// <param name="latestModelApplied"> Specifies whether the latest model has been applied to the virtual machine. </param>
        /// <param name="vmId"> Azure VM unique ID. </param>
        /// <param name="instanceView"> The virtual machine instance view. </param>
        /// <param name="hardwareProfile"> Specifies the hardware settings for the virtual machine. </param>
        /// <param name="storageProfile"> Specifies the storage settings for the virtual machine disks. </param>
        /// <param name="additionalCapabilities"> Specifies additional capabilities enabled or disabled on the virtual machine in the scale set. For instance: whether the virtual machine has the capability to support attaching managed data disks with UltraSSD_LRS storage account type. </param>
        /// <param name="osProfile"> Specifies the operating system settings for the virtual machine. </param>
        /// <param name="securityProfile"> Specifies the Security related profile settings for the virtual machine. </param>
        /// <param name="networkProfile"> Specifies the network interfaces of the virtual machine. </param>
        /// <param name="networkInterfaceConfigurations"> Specifies the network profile configuration of the virtual machine. </param>
        /// <param name="bootDiagnostics"> Specifies the boot diagnostic settings state. Minimum api-version: 2015-06-15. </param>
        /// <param name="availabilitySetId"> Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Availability sets overview](https://docs.microsoft.com/azure/virtual-machines/availability-set-overview). For more information on Azure planned maintenance, see [Maintenance and updates for Virtual Machines in Azure](https://docs.microsoft.com/azure/virtual-machines/maintenance-and-updates). Currently, a VM can only be added to availability set at creation time. An existing VM cannot be added to an availability set. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="licenseType"> Specifies that the image or disk that is being used was licensed on-premises. &lt;br&gt;&lt;br&gt; Possible values for Windows Server operating system are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; Possible values for Linux Server operating system are: &lt;br&gt;&lt;br&gt; RHEL_BYOS (for RHEL) &lt;br&gt;&lt;br&gt; SLES_BYOS (for SUSE) &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing) &lt;br&gt;&lt;br&gt; [Azure Hybrid Use Benefit for Linux Server](https://docs.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15. </param>
        /// <param name="modelDefinitionApplied"> Specifies whether the model applied to the virtual machine is the model of the virtual machine scale set or the customized model for the virtual machine. </param>
        /// <param name="protectionPolicy"> Specifies the protection policy of the virtual machine. </param>
        /// <param name="userData"> UserData for the VM, which must be base-64 encoded. Customer should not pass any secrets in here. Minimum api-version: 2021-03-01. </param>
        /// <param name="timeCreated"> Specifies the time at which the Virtual Machine resource was created. Minimum api-version: 2021-11-01. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, ComputeSku sku, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, IEnumerable<string> zones, ManagedServiceIdentity identity, string etag, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVmInstanceView instanceView, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, VirtualMachineOSProfile osProfile, SecurityProfile securityProfile, VirtualMachineNetworkProfile networkProfile, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations, BootDiagnostics bootDiagnostics, ResourceIdentifier availabilitySetId, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy, string userData, DateTimeOffset? timeCreated)
        {
            return VirtualMachineScaleSetVmData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, instanceId: instanceId, sku: sku, plan: plan, resources: resources, zones: zones, identity: identity, etag: etag, latestModelApplied: latestModelApplied, vmId: vmId, instanceView: instanceView, hardwareProfile: hardwareProfile, resilientVmDeletionStatus: default, storageProfile: storageProfile, additionalCapabilities: additionalCapabilities, osProfile: osProfile, securityProfile: securityProfile, networkProfile: networkProfile, networkInterfaceConfigurations: networkInterfaceConfigurations, bootDiagnostics: bootDiagnostics, availabilitySetId: availabilitySetId, provisioningState: provisioningState, licenseType: licenseType, modelDefinitionApplied: modelDefinitionApplied, protectionPolicy: protectionPolicy, userData: userData, timeCreated: timeCreated);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, ComputeSku sku, ComputePlan plan, IEnumerable<VirtualMachineExtensionData> resources, IEnumerable<string> zones, ManagedServiceIdentity identity, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVmInstanceView instanceView, VirtualMachineHardwareProfile hardwareProfile, VirtualMachineStorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, VirtualMachineOSProfile osProfile, SecurityProfile securityProfile, VirtualMachineNetworkProfile networkProfile, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations, BootDiagnostics bootDiagnostics, ResourceIdentifier availabilitySetId, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy, string userData, DateTimeOffset? timeCreated)
        {
            return VirtualMachineScaleSetVmData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, instanceId: instanceId, sku: sku, plan: plan, resources: resources, zones: zones, identity: identity, etag: default, latestModelApplied: latestModelApplied, vmId: vmId, instanceView: instanceView, hardwareProfile: hardwareProfile, resilientVmDeletionStatus: default, storageProfile: storageProfile, additionalCapabilities: additionalCapabilities, osProfile: osProfile, securityProfile: securityProfile, networkProfile: networkProfile, networkInterfaceConfigurations: networkInterfaceConfigurations, bootDiagnostics: bootDiagnostics, availabilitySetId: availabilitySetId, provisioningState: provisioningState, licenseType: licenseType, modelDefinitionApplied: modelDefinitionApplied, protectionPolicy: protectionPolicy, userData: userData, timeCreated: timeCreated);
        }

        /// <summary> Initializes a new instance of <see cref="Models.VirtualMachineDataDisk"/>. </summary>
        /// <param name="lun"> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </param>
        /// <param name="name"> The disk name. </param>
        /// <param name="vhdUri"> The virtual hard disk. </param>
        /// <param name="imageUri"> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </param>
        /// <param name="caching"> Specifies the caching requirements. Possible values are: **None,** **ReadOnly,** **ReadWrite.** The defaulting behavior is: **None for Standard storage. ReadOnly for Premium storage.**. </param>
        /// <param name="writeAcceleratorEnabled"> Specifies whether writeAccelerator should be enabled or disabled on the disk. </param>
        /// <param name="createOption"> Specifies how the virtual machine disk should be created. Possible values are **Attach:** This value is used when you are using a specialized disk to create the virtual machine. **FromImage:** This value is used when you are using an image to create the virtual machine data disk. If you are using a platform image, you should also use the imageReference element described above. If you are using a marketplace image, you should also use the plan element previously described. **Empty:** This value is used when creating an empty data disk. **Copy:** This value is used to create a data disk from a snapshot or another disk. **Restore:** This value is used to create a data disk from a disk restore point. </param>
        /// <param name="diskSizeGB"> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. The property 'diskSizeGB' is the number of bytes x 1024^3 for the disk and the value cannot be larger than 1023. </param>
        /// <param name="managedDisk"> The managed disk parameters. </param>
        /// <param name="sourceResourceId"> The source resource identifier. It can be a snapshot, or disk restore point from which to create a disk. </param>
        /// <param name="toBeDetached"> Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset. </param>
        /// <param name="diskIopsReadWrite"> Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </param>
        /// <param name="diskMBpsReadWrite"> Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </param>
        /// <param name="detachOption"> Specifies the detach behavior to be used while detaching a disk or which is already in the process of detachment from the virtual machine. Supported values: **ForceDetach.** detachOption: **ForceDetach** is applicable only for managed data disks. If a previous detachment attempt of the data disk did not complete due to an unexpected failure from the virtual machine and the disk is still not released then use force-detach as a last resort option to detach the disk forcibly from the VM. All writes might not have been flushed when using this detach behavior. **This feature is still in preview**. To force-detach a data disk update toBeDetached to 'true' along with setting detachOption: 'ForceDetach'. </param>
        /// <param name="deleteOption"> Specifies whether data disk should be deleted or detached upon VM deletion. Possible values are: **Delete.** If this value is used, the data disk is deleted when VM is deleted. **Detach.** If this value is used, the data disk is retained after VM is deleted. The default value is set to **Detach**. </param>
        /// <returns> A new <see cref="Models.VirtualMachineDataDisk"/> instance for mocking. </returns>
        public static VirtualMachineDataDisk VirtualMachineDataDisk(int lun = default, string name = null, Uri vhdUri = null, Uri imageUri = null, CachingType? caching = null, bool? writeAcceleratorEnabled = null, DiskCreateOptionType createOption = default, int? diskSizeGB = null, VirtualMachineManagedDisk managedDisk = null, ResourceIdentifier sourceResourceId = null, bool? toBeDetached = null, long? diskIopsReadWrite = null, long? diskMBpsReadWrite = null, DiskDetachOptionType? detachOption = null, DiskDeleteOptionType? deleteOption = null)
        {
            return new VirtualMachineDataDisk(
                lun,
                name,
                vhdUri != null ? new VirtualHardDisk(vhdUri, serializedAdditionalRawData: null) : null,
                imageUri != null ? new VirtualHardDisk(imageUri, serializedAdditionalRawData: null) : null,
                caching,
                writeAcceleratorEnabled,
                createOption,
                diskSizeGB,
                managedDisk,
                sourceResourceId != null ? ResourceManagerModelFactory.WritableSubResource(sourceResourceId) : null,
                toBeDetached,
                diskIopsReadWrite,
                diskMBpsReadWrite,
                detachOption,
                deleteOption,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk" />. </summary>
        /// <param name="lun"> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </param>
        /// <param name="name"> The disk name. </param>
        /// <param name="vhdUri"> The virtual hard disk. </param>
        /// <param name="imageUri"> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </param>
        /// <param name="caching"> Specifies the caching requirements. Possible values are: **None,** **ReadOnly,** **ReadWrite.** The defaulting behavior is: **None for Standard storage. ReadOnly for Premium storage.**. </param>
        /// <param name="writeAcceleratorEnabled"> Specifies whether writeAccelerator should be enabled or disabled on the disk. </param>
        /// <param name="createOption"> Specifies how the virtual machine should be created. Possible values are: **Attach.** This value is used when you are using a specialized disk to create the virtual machine. **FromImage.** This value is used when you are using an image to create the virtual machine. If you are using a platform image, you should also use the imageReference element described above. If you are using a marketplace image, you should also use the plan element previously described. </param>
        /// <param name="diskSizeGB"> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. The property 'diskSizeGB' is the number of bytes x 1024^3 for the disk and the value cannot be larger than 1023. </param>
        /// <param name="managedDisk"> The managed disk parameters. </param>
        /// <param name="toBeDetached"> Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset. </param>
        /// <param name="diskIopsReadWrite"> Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </param>
        /// <param name="diskMBpsReadWrite"> Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </param>
        /// <param name="detachOption"> Specifies the detach behavior to be used while detaching a disk or which is already in the process of detachment from the virtual machine. Supported values: **ForceDetach.** detachOption: **ForceDetach** is applicable only for managed data disks. If a previous detachment attempt of the data disk did not complete due to an unexpected failure from the virtual machine and the disk is still not released then use force-detach as a last resort option to detach the disk forcibly from the VM. All writes might not have been flushed when using this detach behavior. **This feature is still in preview** mode and is not supported for VirtualMachineScaleSet. To force-detach a data disk update toBeDetached to 'true' along with setting detachOption: 'ForceDetach'. </param>
        /// <param name="deleteOption"> Specifies whether data disk should be deleted or detached upon VM deletion. Possible values are: **Delete.** If this value is used, the data disk is deleted when VM is deleted. **Detach.** If this value is used, the data disk is retained after VM is deleted. The default value is set to **Detach**. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualMachineDataDisk VirtualMachineDataDisk(int lun, string name, Uri vhdUri, Uri imageUri, CachingType? caching, bool? writeAcceleratorEnabled, DiskCreateOptionType createOption, int? diskSizeGB, VirtualMachineManagedDisk managedDisk, bool? toBeDetached, long? diskIopsReadWrite, long? diskMBpsReadWrite, DiskDetachOptionType? detachOption, DiskDeleteOptionType? deleteOption)
        {
            return VirtualMachineDataDisk(lun: lun, name: name, vhdUri: vhdUri, imageUri: imageUri, caching: caching, writeAcceleratorEnabled: writeAcceleratorEnabled, createOption: createOption, diskSizeGB: diskSizeGB, managedDisk: managedDisk, sourceResourceId: default, toBeDetached: toBeDetached, diskIopsReadWrite: diskIopsReadWrite, diskMBpsReadWrite: diskMBpsReadWrite, detachOption: detachOption, deleteOption: deleteOption);
        }
    }
}
