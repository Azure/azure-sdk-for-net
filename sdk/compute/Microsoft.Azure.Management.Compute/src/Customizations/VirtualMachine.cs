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
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, CapacityReservationProfile capacityReservation, ApplicationProfile applicationProfile, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity = default(VirtualMachineIdentity), IList<string> zones = default(IList<string>), ExtendedLocation extendedLocation = default(ExtendedLocation))
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
            ApplicationProfile = applicationProfile;
            Resources = resources;
            Identity = identity;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            CustomInit();
        }

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, CapacityReservationProfile capacityReservation, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones, ExtendedLocation extendedLocation)
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

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, CapacityReservationProfile capacityReservation, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones)
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
            CustomInit();
        }

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, CapacityReservationProfile capacityReservation, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity)
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
            CustomInit();
        }

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, CapacityReservationProfile capacityReservation, IList<VirtualMachineExtension> resources)
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
            CustomInit();
        }

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones, ExtendedLocation extendedLocation)
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

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones)
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

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, string userData, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity)
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
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones, ExtendedLocation extendedLocation)
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
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity, IList<string> zones)
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
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, IList<VirtualMachineExtension> resources, VirtualMachineIdentity identity)
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
        
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile, IList<VirtualMachineExtension> resources)
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
        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain, ScheduledEventsProfile scheduledEventsProfile)
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

        public VirtualMachine(string location, string id, string name, string type, IDictionary<string, string> tags, Plan plan, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, NetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, SubResource virtualMachineScaleSet, SubResource proximityPlacementGroup, string priority, string evictionPolicy, BillingProfile billingProfile, SubResource host, SubResource hostGroup, string provisioningState, VirtualMachineInstanceView instanceView, string licenseType, string vmId, string extensionsTimeBudget, int? platformFaultDomain)
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
            CustomInit();
        }

    }
}
