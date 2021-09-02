namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a Virtual Machine.
    /// </summary>
    public partial class VirtualMachine : Resource
    {
        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), string userData = default(string), CapacityReservationProfile capacityReservation = default(CapacityReservationProfile), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity), IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            UserData = userData;
            CapacityReservation = capacityReservation;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }

        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), string userData = default(string), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity), IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            UserData = userData;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }

        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), string userData = default(string), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity), IList<string> zones = default(IList<string>))
    : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            UserData = userData;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            CustomInit();
        }

        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), string userData = default(string), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity))
    : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            UserData = userData;
            Resources = resources;
            Identity = identity;
            CustomInit();
        }

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, IList<VirtualMachineExtension> resources)
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            Resources = resources;
            CustomInit();
        }
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones)
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            CustomInit();
        }
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity)
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            Resources = resources;
            Identity = identity;
            CustomInit();
        }
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget)
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            CustomInit();
        }
        
        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity), IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }
        
        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity), IList<string> zones = default(IList<string>))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            CustomInit();
        }
        
     
        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>), VirtualMachineIdentity identity = default(VirtualMachineIdentity))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            Resources = resources;
            Identity = identity;
            CustomInit();
        }
        
        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), IList<VirtualMachineExtension> resources = default(IList<VirtualMachineExtension>))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            Resources = resources;
            CustomInit();
        }

        public VirtualMachine(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Plan plan = default(Plan), HardwareProfile hardwareProfile = default(HardwareProfile), StorageProfile storageProfile = default(StorageProfile), AdditionalCapabilities additionalCapabilities = default(AdditionalCapabilities), OSProfile osProfile = default(OSProfile), NetworkProfile networkProfile = default(NetworkProfile), SecurityProfile securityProfile = default(SecurityProfile), DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), SubResource availabilitySet = default(SubResource), SubResource virtualMachineScaleSet = default(SubResource), SubResource proximityPlacementGroup = default(SubResource), string priority = default(string), string evictionPolicy = default(string), BillingProfile billingProfile = default(BillingProfile), SubResource host = default(SubResource), SubResource hostGroup = default(SubResource), string provisioningState = default(string), VirtualMachineInstanceView instanceView = default(VirtualMachineInstanceView), string licenseType = default(string), string vmId = default(string), string extensionsTimeBudget = default(string), int? platformFaultDomain = default(int?), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile))
            : base(location, id, name, type, tags)
        {
            Plan = plan;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            VirtualMachineScaleSet = virtualMachineScaleSet;
            ProximityPlacementGroup = proximityPlacementGroup;
            Priority = priority;
            EvictionPolicy = evictionPolicy;
            BillingProfile = billingProfile;
            Host = host;
            HostGroup = hostGroup;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            LicenseType = licenseType;
            VmId = vmId;
            ExtensionsTimeBudget = extensionsTimeBudget;
            PlatformFaultDomain = platformFaultDomain;
            ScheduledEventsProfile = scheduledEventsProfile;
            CustomInit();
        }
        
    }
}
