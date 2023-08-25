namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a Virtual Machine Scale Set.
    /// </summary>
    public partial class VirtualMachineScaleSet : Resource
    {
        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode, SpotRestorePolicy spotRestorePolicy, PriorityMixPolicy priorityMixPolicy, System.DateTime? timeCreated, VirtualMachineScaleSetIdentity identity, IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
    : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = orchestrationMode;
            SpotRestorePolicy = spotRestorePolicy;
            PriorityMixPolicy = priorityMixPolicy;
            TimeCreated = timeCreated;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }
        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSet class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="sku">The virtual machine scale set sku.</param>
        /// <param name="plan">Specifies information about the marketplace
        /// image used to create the virtual machine. This element is only used
        /// for marketplace images. Before you can use a marketplace image from
        /// an API, you must enable the image for programmatic use.  In the
        /// Azure portal, find the marketplace image that you want to use and
        /// then click **Want to deploy programmatically, Get Started -&gt;**.
        /// Enter any required information and then click **Save**.</param>
        /// <param name="upgradePolicy">The upgrade policy.</param>
        /// <param name="automaticRepairsPolicy">Policy for automatic
        /// repairs.</param>
        /// <param name="virtualMachineProfile">The virtual machine
        /// profile.</param>
        /// <param name="provisioningState">The provisioning state, which only
        /// appears in the response.</param>
        /// <param name="overprovision">Specifies whether the Virtual Machine
        /// Scale Set should be overprovisioned.</param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVMs">When
        /// Overprovision is enabled, extensions are launched only on the
        /// requested number of VMs which are finally kept. This property will
        /// hence ensure that the extensions do not run on the extra
        /// overprovisioned VMs.</param>
        /// <param name="uniqueId">Specifies the ID which uniquely identifies a
        /// Virtual Machine Scale Set.</param>
        /// <param name="singlePlacementGroup">When true this limits the scale
        /// set to a single placement group, of max size 100 virtual machines.
        /// NOTE: If singlePlacementGroup is true, it may be modified to false.
        /// However, if singlePlacementGroup is false, it may not be modified
        /// to true.</param>
        /// <param name="zoneBalance">Whether to force strictly even Virtual
        /// Machine distribution cross x-zones in case there is zone
        /// outage.</param>
        /// <param name="platformFaultDomainCount">Fault Domain count for each
        /// placement group.</param>
        /// <param name="proximityPlacementGroup">Specifies information about
        /// the proximity placement group that the virtual machine scale set
        /// should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version:
        /// 2018-04-01.</param>
        /// <param name="hostGroup">Specifies information about the dedicated
        /// host group that the virtual machine scale set resides in.
        /// &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.</param>
        /// <param name="additionalCapabilities">Specifies additional
        /// capabilities enabled or disabled on the Virtual Machines in the
        /// Virtual Machine Scale Set. For instance: whether the Virtual
        /// Machines have the capability to support attaching managed data
        /// disks with UltraSSD_LRS storage account type.</param>
        /// <param name="scaleInPolicy">Specifies the scale-in policy that
        /// decides which virtual machines are chosen for removal when a
        /// Virtual Machine Scale Set is scaled-in.</param>
        /// <param name="identity">The identity of the virtual machine scale
        /// set, if configured.</param>
        /// <param name="zones">The virtual machine scale set zones. NOTE:
        /// Availability zones can only be set when you create the scale
        /// set</param>
        /// <param name="extendedLocation">The extended location of the Virtual
        /// Machine Scale Set.</param>
        ///

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode, SpotRestorePolicy spotRestorePolicy, VirtualMachineScaleSetIdentity identity, IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = orchestrationMode;
            SpotRestorePolicy = spotRestorePolicy;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode, VirtualMachineScaleSetIdentity identity, IList<string> zones, ExtendedLocation extendedLocation)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = OrchestrationMode;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode, VirtualMachineScaleSetIdentity identity, IList<string> zones)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = OrchestrationMode;
            Identity = identity;
            Zones = zones;
            CustomInit();
        }

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode, VirtualMachineScaleSetIdentity identity)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = OrchestrationMode;
            Identity = identity;
            CustomInit();
        }

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = OrchestrationMode;
            CustomInit();
        }

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, VirtualMachineScaleSetIdentity identity, IList<string> zones, ExtendedLocation extendedLocation)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }
        
        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSet class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="sku">The virtual machine scale set sku.</param>
        /// <param name="plan">Specifies information about the marketplace
        /// image used to create the virtual machine. This element is only used
        /// for marketplace images. Before you can use a marketplace image from
        /// an API, you must enable the image for programmatic use.  In the
        /// Azure portal, find the marketplace image that you want to use and
        /// then click **Want to deploy programmatically, Get Started -&gt;**.
        /// Enter any required information and then click **Save**.</param>
        /// <param name="upgradePolicy">The upgrade policy.</param>
        /// <param name="automaticRepairsPolicy">Policy for automatic
        /// repairs.</param>
        /// <param name="virtualMachineProfile">The virtual machine
        /// profile.</param>
        /// <param name="provisioningState">The provisioning state, which only
        /// appears in the response.</param>
        /// <param name="overprovision">Specifies whether the Virtual Machine
        /// Scale Set should be overprovisioned.</param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVMs">When
        /// Overprovision is enabled, extensions are launched only on the
        /// requested number of VMs which are finally kept. This property will
        /// hence ensure that the extensions do not run on the extra
        /// overprovisioned VMs.</param>
        /// <param name="uniqueId">Specifies the ID which uniquely identifies a
        /// Virtual Machine Scale Set.</param>
        /// <param name="singlePlacementGroup">When true this limits the scale
        /// set to a single placement group, of max size 100 virtual machines.
        /// NOTE: If singlePlacementGroup is true, it may be modified to false.
        /// However, if singlePlacementGroup is false, it may not be modified
        /// to true.</param>
        /// <param name="zoneBalance">Whether to force strictly even Virtual
        /// Machine distribution cross x-zones in case there is zone
        /// outage.</param>
        /// <param name="platformFaultDomainCount">Fault Domain count for each
        /// placement group.</param>
        /// <param name="proximityPlacementGroup">Specifies information about
        /// the proximity placement group that the virtual machine scale set
        /// should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version:
        /// 2018-04-01.</param>
        /// <param name="hostGroup">Specifies information about the dedicated
        /// host group that the virtual machine scale set resides in.
        /// &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.</param>
        /// <param name="additionalCapabilities">Specifies additional
        /// capabilities enabled or disabled on the Virtual Machines in the
        /// Virtual Machine Scale Set. For instance: whether the Virtual
        /// Machines have the capability to support attaching managed data
        /// disks with UltraSSD_LRS storage account type.</param>
        /// <param name="scaleInPolicy">Specifies the scale-in policy that
        /// decides which virtual machines are chosen for removal when a
        /// Virtual Machine Scale Set is scaled-in.</param>
        /// <param name="identity">The identity of the virtual machine scale
        /// set, if configured.</param>
        /// <param name="zones">The virtual machine scale set zones. NOTE:
        /// Availability zones can only be set when you create the scale
        /// set</param>
        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, VirtualMachineScaleSetIdentity identity, IList<string> zones)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            Identity = identity;
            Zones = zones;
            CustomInit();
        }
        
        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSet class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="sku">The virtual machine scale set sku.</param>
        /// <param name="plan">Specifies information about the marketplace
        /// image used to create the virtual machine. This element is only used
        /// for marketplace images. Before you can use a marketplace image from
        /// an API, you must enable the image for programmatic use.  In the
        /// Azure portal, find the marketplace image that you want to use and
        /// then click **Want to deploy programmatically, Get Started -&gt;**.
        /// Enter any required information and then click **Save**.</param>
        /// <param name="upgradePolicy">The upgrade policy.</param>
        /// <param name="automaticRepairsPolicy">Policy for automatic
        /// repairs.</param>
        /// <param name="virtualMachineProfile">The virtual machine
        /// profile.</param>
        /// <param name="provisioningState">The provisioning state, which only
        /// appears in the response.</param>
        /// <param name="overprovision">Specifies whether the Virtual Machine
        /// Scale Set should be overprovisioned.</param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVMs">When
        /// Overprovision is enabled, extensions are launched only on the
        /// requested number of VMs which are finally kept. This property will
        /// hence ensure that the extensions do not run on the extra
        /// overprovisioned VMs.</param>
        /// <param name="uniqueId">Specifies the ID which uniquely identifies a
        /// Virtual Machine Scale Set.</param>
        /// <param name="singlePlacementGroup">When true this limits the scale
        /// set to a single placement group, of max size 100 virtual machines.
        /// NOTE: If singlePlacementGroup is true, it may be modified to false.
        /// However, if singlePlacementGroup is false, it may not be modified
        /// to true.</param>
        /// <param name="zoneBalance">Whether to force strictly even Virtual
        /// Machine distribution cross x-zones in case there is zone
        /// outage.</param>
        /// <param name="platformFaultDomainCount">Fault Domain count for each
        /// placement group.</param>
        /// <param name="proximityPlacementGroup">Specifies information about
        /// the proximity placement group that the virtual machine scale set
        /// should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version:
        /// 2018-04-01.</param>
        /// <param name="hostGroup">Specifies information about the dedicated
        /// host group that the virtual machine scale set resides in.
        /// &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.</param>
        /// <param name="additionalCapabilities">Specifies additional
        /// capabilities enabled or disabled on the Virtual Machines in the
        /// Virtual Machine Scale Set. For instance: whether the Virtual
        /// Machines have the capability to support attaching managed data
        /// disks with UltraSSD_LRS storage account type.</param>
        /// <param name="scaleInPolicy">Specifies the scale-in policy that
        /// decides which virtual machines are chosen for removal when a
        /// Virtual Machine Scale Set is scaled-in.</param>
        /// <param name="identity">The identity of the virtual machine scale
        /// set, if configured.</param>
        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, VirtualMachineScaleSetIdentity identity)
            : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            Identity = identity;
            CustomInit();
        }

        public VirtualMachineScaleSet(string location, string id, string name, string type, IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVMProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, SubResource proximityPlacementGroup, SubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, string orchestrationMode, SpotRestorePolicy spotRestorePolicy, System.DateTime? timeCreated, VirtualMachineScaleSetIdentity identity = default(VirtualMachineScaleSetIdentity), IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
           : base(location, id, name, type, tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            OrchestrationMode = orchestrationMode;
            SpotRestorePolicy = spotRestorePolicy;
            TimeCreated = timeCreated;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }

    }
}
