namespace Azure.ResourceManager.Fleet
{
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.Fleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.Fleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fleet.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fleet.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Fleet.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.RegularPriorityProfile RegularPriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SpotPriorityProfile SpotPriorityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public static partial class FleetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Fleet.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.Fleet.FleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Fleet.Mocking
{
    public partial class MockableFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableFleetArmClient() { }
        public virtual Azure.ResourceManager.Fleet.FleetResource GetFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableFleetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFleetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> GetFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Fleet.FleetCollection GetFleets() { throw null; }
    }
    public partial class MockableFleetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFleetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Fleet.Models
{
    public partial class AdditionalUnattendContent
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.Fleet.Models.ComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.PassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SettingName? SettingName { get { throw null; } set { } }
    }
    public static partial class ArmFleetModelFactory
    {
        public static Azure.ResourceManager.Fleet.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Fleet.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Fleet.Models.ProvisioningState?), Azure.ResourceManager.Fleet.Models.SpotPriorityProfile spotPriorityProfile = null, Azure.ResourceManager.Fleet.Models.RegularPriorityProfile regularPriorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.Fleet.Models.ComputeProfile computeProfile = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.ImageReference ImageReference(string id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.SubResourceReadOnly SubResourceReadOnly(string id = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineExtension VirtualMachineExtension(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string forceUpdateTag = null, string publisher = null, string typePropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.Fleet.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSet VirtualMachineScaleSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Fleet.Models.ProvisioningState provisioningState = default(Azure.ResourceManager.Fleet.Models.ProvisioningState)) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtension VirtualMachineScaleSetExtension(string id = null, string name = null, string resourceType = null, string forceUpdateTag = null, string publisher = null, string typePropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile VirtualMachineScaleSetVmProfile(Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetOSProfile osProfile = null, Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetStorageProfile storageProfile = null, Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetNetworkProfile networkProfile = null, Azure.ResourceManager.Fleet.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Fleet.Models.BootDiagnostics bootDiagnostics = null, Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtensionProfile extensionProfile = null, string licenseType = null, Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType?), Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.ResourceManager.Fleet.Models.ScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.VmGalleryApplication> galleryApplications = null, Azure.ResourceManager.Fleet.Models.VmSizeProperties hardwareVmSizeProperties = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.ResourceManager.Fleet.Models.SecurityPostureReference securityPostureReference = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class BootDiagnostics
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
    }
    public enum CachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentName : System.IEquatable<Azure.ResourceManager.Fleet.Models.ComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentName(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.ComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.ComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.ComponentName left, Azure.ResourceManager.Fleet.Models.ComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.ComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.ComponentName left, Azure.ResourceManager.Fleet.Models.ComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeProfile
    {
        public ComputeProfile(Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile baseVirtualMachineProfile, string computeApiVersion) { }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile BaseVirtualMachineProfile { get { throw null; } set { } }
        public string ComputeApiVersion { get { throw null; } set { } }
    }
    public partial class ComputeProfileUpdate
    {
        public ComputeProfileUpdate() { }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile BaseVirtualMachineProfile { get { throw null; } set { } }
        public string ComputeApiVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOption : System.IEquatable<Azure.ResourceManager.Fleet.Models.DeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.DeleteOption Delete { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DeleteOption Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DeleteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DeleteOption left, Azure.ResourceManager.Fleet.Models.DeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DeleteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DeleteOption left, Azure.ResourceManager.Fleet.Models.DeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.DiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiffDiskOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiffDiskOption left, Azure.ResourceManager.Fleet.Models.DiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiffDiskOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiffDiskOption left, Azure.ResourceManager.Fleet.Models.DiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiffDiskPlacement left, Azure.ResourceManager.Fleet.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiffDiskPlacement left, Azure.ResourceManager.Fleet.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.Fleet.Models.DiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.DiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DiskCreateOptionType FromImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType left, Azure.ResourceManager.Fleet.Models.DiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiskCreateOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType left, Azure.ResourceManager.Fleet.Models.DiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType left, Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType left, Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType left, Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType left, Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicy : System.IEquatable<Azure.ResourceManager.Fleet.Models.EvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.EvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.EvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.EvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.EvictionPolicy left, Azure.ResourceManager.Fleet.Models.EvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.EvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.EvictionPolicy left, Azure.ResourceManager.Fleet.Models.EvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetPatch
    {
        public FleetPatch() { }
        public Azure.ResourceManager.Fleet.Models.ComputeProfileUpdate ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.RegularPriorityProfile RegularPriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SpotPriorityProfile SpotPriorityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ImageReference : Azure.ResourceManager.Fleet.Models.SubResource
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class InstanceViewStatus
    {
        public InstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.StatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersion : System.IEquatable<Azure.ResourceManager.Fleet.Models.IPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersion(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.IPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.IPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.IPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.IPVersion left, Azure.ResourceManager.Fleet.Models.IPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.IPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.IPVersion left, Azure.ResourceManager.Fleet.Models.IPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultSecretReference
    {
        public KeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class LinuxConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? EnableVmAgentPlatformUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxPatchSettings
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode? PatchMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxVmGuestPatchAutomaticByPlatformSettings
    {
        public LinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.Fleet.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.Mode Audit { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.Mode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.Mode left, Azure.ResourceManager.Fleet.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.Mode left, Azure.ResourceManager.Fleet.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkApiVersion : System.IEquatable<Azure.ResourceManager.Fleet.Models.NetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.NetworkApiVersion TwoThousandTwenty1101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NetworkApiVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NetworkApiVersion left, Azure.ResourceManager.Fleet.Models.NetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NetworkApiVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NetworkApiVersion left, Azure.ResourceManager.Fleet.Models.NetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class OSImageNotificationProfile
    {
        public OSImageNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassName : System.IEquatable<Azure.ResourceManager.Fleet.Models.PassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassName(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.PassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.PassName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.PassName left, Azure.ResourceManager.Fleet.Models.PassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.PassName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.PassName left, Azure.ResourceManager.Fleet.Models.PassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchSettings
    {
        public PatchSettings() { }
        public Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode? PatchMode { get { throw null; } set { } }
    }
    public enum ProtocolType
    {
        Http = 0,
        Https = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Fleet.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.ProvisioningState left, Azure.ResourceManager.Fleet.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.ProvisioningState left, Azure.ResourceManager.Fleet.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyAgentSettings
    {
        public ProxyAgentSettings() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.Mode? Mode { get { throw null; } set { } }
    }
    public partial class PublicIPAddressSku
    {
        public PublicIPAddressSku() { }
        public Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegularPriorityAllocationStrategy : System.IEquatable<Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegularPriorityAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegularPriorityProfile
    {
        public RegularPriorityProfile() { }
        public Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
    }
    public partial class ScheduledEventsProfile
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.Fleet.Models.OSImageNotificationProfile OSImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.SecurityEncryptionType DiskWithVmGuestState { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.SecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.SecurityEncryptionType VmGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.SecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.SecurityEncryptionType left, Azure.ResourceManager.Fleet.Models.SecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.SecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.SecurityEncryptionType left, Azure.ResourceManager.Fleet.Models.SecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPostureReference
    {
        public SecurityPostureReference() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineExtension> ExcludeExtensions { get { throw null; } }
        public string Id { get { throw null; } set { } }
    }
    public partial class SecurityProfile
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.UefiSettings UefiSettings { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.Fleet.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.SecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.SecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.SecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.SecurityType left, Azure.ResourceManager.Fleet.Models.SecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.SecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.SecurityType left, Azure.ResourceManager.Fleet.Models.SecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SettingName
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpotAllocationStrategy : System.IEquatable<Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpotAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy Diversified { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy PriceCapacityOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpotPriorityProfile
    {
        public SpotPriorityProfile() { }
        public Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public float? MaxPricePerVm { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
    }
    public partial class SshPublicKey
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public enum StatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Fleet.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType PremiumV2LRS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType StandardSSDZRS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.StorageAccountType left, Azure.ResourceManager.Fleet.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.StorageAccountType left, Azure.ResourceManager.Fleet.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class SubResourceReadOnly
    {
        public SubResourceReadOnly() { }
        public string Id { get { throw null; } }
    }
    public partial class TerminateNotificationProfile
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
    }
    public partial class UefiSettings
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
    }
    public partial class VaultCertificate
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
    }
    public partial class VaultSecretGroup
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VaultCertificate> VaultCertificates { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyType : System.IEquatable<Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineExtension : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineExtension(Azure.Core.AzureLocation location) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionInstanceView
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.InstanceViewStatus> Substatuses { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineExtensionInstanceViewType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityType : System.IEquatable<Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType Low { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType Regular { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType left, Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType left, Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSet : Azure.ResourceManager.Models.ResourceData
    {
        internal VirtualMachineScaleSet() { }
        public Azure.ResourceManager.Fleet.Models.ProvisioningState ProvisioningState { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetDataDisk
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.Fleet.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Fleet.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetManagedDiskContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtension : Azure.ResourceManager.Fleet.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetExtension() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionProfile
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtension> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetIPConfiguration
    {
        public VirtualMachineScaleSetIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetIPTag
    {
        public VirtualMachineScaleSetIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetManagedDiskContent
    {
        public VirtualMachineScaleSetManagedDiskContent() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VmDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DeleteOption? DeleteOption { get { throw null; } set { } }
        public bool? DisableTcpStateTracking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkProfile
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetOSDisk
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Fleet.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetManagedDiskContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetOSProfile
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Fleet.Models.DeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetStorageProfile
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public string DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVmProfile
    {
        public VirtualMachineScaleSetVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VmGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.VmSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityPostureReference SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
    }
    public partial class VmDiskSecurityProfile
    {
        public VmDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
    }
    public partial class VmGalleryApplication
    {
        public VmGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
    }
    public partial class VmSizeProfile
    {
        public VmSizeProfile(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class VmSizeProperties
    {
        public VmSizeProperties() { }
        public int? VCPUsAvailable { get { throw null; } set { } }
        public int? VCPUsPerCore { get { throw null; } set { } }
    }
    public partial class WindowsConfiguration
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? EnableVmAgentPlatformUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.PatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.WinRMListener> WinRMListeners { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsVmGuestPatchAutomaticByPlatformSettings
    {
        public WindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WinRMListener
    {
        public WinRMListener() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ProtocolType? Protocol { get { throw null; } set { } }
    }
}
