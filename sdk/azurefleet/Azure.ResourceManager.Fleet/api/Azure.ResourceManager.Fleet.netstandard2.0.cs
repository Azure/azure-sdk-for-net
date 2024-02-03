namespace Azure.ResourceManager.Fleet
{
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.Fleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.Fleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fleet.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) {  }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fleet.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetResource>.GetEnumerator() {  }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {  }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Fleet.Models.ComputeProfile ComputeProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.ProvisioningState? ProvisioningState { get {  } }
        public Azure.ResourceManager.Fleet.Models.RegularPriorityProfile RegularPriorityProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SpotPriorityProfile SpotPriorityProfile { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VmSizeProfile> VmSizesProfile { get {  } }
        public System.Collections.Generic.IList<string> Zones { get {  } }
    }
    public static partial class FleetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Fleet.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public static Azure.ResourceManager.Fleet.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) {  }
        public static Azure.ResourceManager.Fleet.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) {  }
        public static Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
    }
    public partial class FleetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.Fleet.FleetData Data { get {  } }
        public virtual bool HasData { get {  } }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) {  }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
    }
}
namespace Azure.ResourceManager.Fleet.Mocking
{
    public partial class MockableFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableFleetArmClient() { }
        public virtual Azure.ResourceManager.Fleet.FleetResource GetFleetResource(Azure.Core.ResourceIdentifier id) {  }
    }
    public partial class MockableFleetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFleetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> GetFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.ResourceManager.Fleet.FleetCollection GetFleets() {  }
    }
    public partial class MockableFleetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFleetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) {  }
    }
}
namespace Azure.ResourceManager.Fleet.Models
{
    public partial class AdditionalUnattendContent
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.Fleet.Models.ComponentName? ComponentName { get {  } set { } }
        public string Content { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.PassName? PassName { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SettingName? SettingName { get {  } set { } }
    }
    public static partial class ArmFleetModelFactory
    {
        public static Azure.ResourceManager.Fleet.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Fleet.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Fleet.Models.ProvisioningState?), Azure.ResourceManager.Fleet.Models.SpotPriorityProfile spotPriorityProfile = null, Azure.ResourceManager.Fleet.Models.RegularPriorityProfile regularPriorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.Fleet.Models.ComputeProfile computeProfile = null) {  }
        public static Azure.ResourceManager.Fleet.Models.ImageReference ImageReference(string id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) {  }
        public static Azure.ResourceManager.Fleet.Models.SubResourceReadOnly SubResourceReadOnly(string id = null) {  }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineExtension VirtualMachineExtension(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string forceUpdateTag = null, string publisher = null, string typePropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.Fleet.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) {  }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSet VirtualMachineScaleSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Fleet.Models.ProvisioningState provisioningState = default(Azure.ResourceManager.Fleet.Models.ProvisioningState)) {  }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtension VirtualMachineScaleSetExtension(string id = null, string name = null, string resourceType = null, string forceUpdateTag = null, string publisher = null, string typePropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null) {  }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile VirtualMachineScaleSetVmProfile(Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetOSProfile osProfile = null, Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetStorageProfile storageProfile = null, Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetNetworkProfile networkProfile = null, Azure.ResourceManager.Fleet.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Fleet.Models.BootDiagnostics bootDiagnostics = null, Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtensionProfile extensionProfile = null, string licenseType = null, Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType?), Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.ResourceManager.Fleet.Models.ScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.VmGalleryApplication> galleryApplications = null, Azure.ResourceManager.Fleet.Models.VmSizeProperties hardwareVmSizeProperties = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.ResourceManager.Fleet.Models.SecurityPostureReference securityPostureReference = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) {  }
    }
    public partial class BootDiagnostics
    {
        public BootDiagnostics() { }
        public bool? Enabled { get {  } set { } }
        public System.Uri StorageUri { get {  } set { } }
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
        public ComponentName(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.ComponentName MicrosoftWindowsShellSetup { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.ComponentName other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.ComponentName left, Azure.ResourceManager.Fleet.Models.ComponentName right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.ComponentName (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.ComponentName left, Azure.ResourceManager.Fleet.Models.ComponentName right) {  }
        public override string ToString() {  }
    }
    public partial class ComputeProfile
    {
        public ComputeProfile(Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile baseVirtualMachineProfile, string computeApiVersion) { }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile BaseVirtualMachineProfile { get {  } set { } }
        public string ComputeApiVersion { get { } set { } }
    }
    public partial class ComputeProfileUpdate
    {
        public ComputeProfileUpdate() { }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetVmProfile BaseVirtualMachineProfile { get {  } set { } }
        public string ComputeApiVersion { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOption : System.IEquatable<Azure.ResourceManager.Fleet.Models.DeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOption(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.DeleteOption Delete { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DeleteOption Detach { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DeleteOption other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DeleteOption left, Azure.ResourceManager.Fleet.Models.DeleteOption right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DeleteOption (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DeleteOption left, Azure.ResourceManager.Fleet.Models.DeleteOption right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.DiffDiskOption Local { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiffDiskOption other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiffDiskOption left, Azure.ResourceManager.Fleet.Models.DiffDiskOption right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiffDiskOption (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiffDiskOption left, Azure.ResourceManager.Fleet.Models.DiffDiskOption right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.DiffDiskPlacement CacheDisk { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DiffDiskPlacement ResourceDisk { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiffDiskPlacement other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiffDiskPlacement left, Azure.ResourceManager.Fleet.Models.DiffDiskPlacement right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiffDiskPlacement (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiffDiskPlacement left, Azure.ResourceManager.Fleet.Models.DiffDiskPlacement right) {  }
        public override string ToString() {  }
    }
    public partial class DiffDiskSettings
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.Fleet.Models.DiffDiskOption? Option { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DiffDiskPlacement? Placement { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.DiskCreateOptionType Attach { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DiskCreateOptionType Empty { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DiskCreateOptionType FromImage { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType left, Azure.ResourceManager.Fleet.Models.DiskCreateOptionType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiskCreateOptionType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType left, Azure.ResourceManager.Fleet.Models.DiskCreateOptionType right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType Delete { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType Detach { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType left, Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType left, Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType NoReuse { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType ResourceGroupReuse { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType SubscriptionReuse { get {  } }
        public static Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType TenantReuse { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType left, Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType left, Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicy : System.IEquatable<Azure.ResourceManager.Fleet.Models.EvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicy(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.EvictionPolicy Deallocate { get {  } }
        public static Azure.ResourceManager.Fleet.Models.EvictionPolicy Delete { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.EvictionPolicy other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.EvictionPolicy left, Azure.ResourceManager.Fleet.Models.EvictionPolicy right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.EvictionPolicy (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.EvictionPolicy left, Azure.ResourceManager.Fleet.Models.EvictionPolicy right) {  }
        public override string ToString() {  }
    }
    public partial class FleetPatch
    {
        public FleetPatch() { }
        public Azure.ResourceManager.Fleet.Models.ComputeProfileUpdate ComputeProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.RegularPriorityProfile RegularPriorityProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SpotPriorityProfile SpotPriorityProfile { get {  } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get {  } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VmSizeProfile> VmSizesProfile { get {  } }
        public System.Collections.Generic.IList<string> Zones { get {  } }
    }
    public partial class ImageReference : Azure.ResourceManager.Fleet.Models.SubResource
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get {  } set { } }
        public string ExactVersion { get {  } }
        public string Offer { get {  } set { } }
        public string Publisher { get {  } set { } }
        public string SharedGalleryImageId { get {  } set { } }
        public string Sku { get {  } set { } }
        public string Version { get {  } set { } }
    }
    public partial class InstanceViewStatus
    {
        public InstanceViewStatus() { }
        public string Code { get {  } set { } }
        public string DisplayStatus { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.StatusLevelType? Level { get {  } set { } }
        public string Message { get {  } set { } }
        public System.DateTimeOffset? Time { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersion : System.IEquatable<Azure.ResourceManager.Fleet.Models.IPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersion(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.IPVersion IPv4 { get {  } }
        public static Azure.ResourceManager.Fleet.Models.IPVersion IPv6 { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.IPVersion other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.IPVersion left, Azure.ResourceManager.Fleet.Models.IPVersion right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.IPVersion (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.IPVersion left, Azure.ResourceManager.Fleet.Models.IPVersion right) {  }
        public override string ToString() {  }
    }
    public partial class KeyVaultSecretReference
    {
        public KeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get {  } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get {  } set { } }
    }
    public partial class LinuxConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get {  } set { } }
        public bool? EnableVmAgentPlatformUpdates { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxPatchSettings PatchSettings { get {  } set { } }
        public bool? ProvisionVmAgent { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.SshPublicKey> SshPublicKeys { get {  } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get {  } }
        public static Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode ImageDefault { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode right) {  }
        public override string ToString() {  }
    }
    public partial class LinuxPatchSettings
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.Fleet.Models.LinuxPatchAssessmentMode? AssessmentMode { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode? PatchMode { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchAutomaticByPlatformRebootSetting(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Always { get {  } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get {  } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Never { get {  } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) {  }
        public override string ToString() {  }
    }
    public partial class LinuxVmGuestPatchAutomaticByPlatformSettings
    {
        public LinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchMode(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode AutomaticByPlatform { get {  } }
        public static Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode ImageDefault { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.LinuxVmGuestPatchMode right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.Fleet.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.Mode Audit { get {  } }
        public static Azure.ResourceManager.Fleet.Models.Mode Enforce { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.Mode other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.Mode left, Azure.ResourceManager.Fleet.Models.Mode right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.Mode (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.Mode left, Azure.ResourceManager.Fleet.Models.Mode right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkApiVersion : System.IEquatable<Azure.ResourceManager.Fleet.Models.NetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkApiVersion(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.NetworkApiVersion TwoThousandTwenty1101 { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NetworkApiVersion other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NetworkApiVersion left, Azure.ResourceManager.Fleet.Models.NetworkApiVersion right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NetworkApiVersion (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NetworkApiVersion left, Azure.ResourceManager.Fleet.Models.NetworkApiVersion right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliaryMode(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode AcceleratedConnections { get {  } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode Floating { get {  } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode None { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliarySku(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A1 { get {  } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A2 { get {  } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A4 { get {  } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku A8 { get {  } }
        public static Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku None { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku right) {  }
        public override string ToString() {  }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class OSImageNotificationProfile
    {
        public OSImageNotificationProfile() { }
        public bool? Enable { get {  } set { } }
        public string NotBeforeTimeout { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassName : System.IEquatable<Azure.ResourceManager.Fleet.Models.PassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassName(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.PassName OobeSystem { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.PassName other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.PassName left, Azure.ResourceManager.Fleet.Models.PassName right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.PassName (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.PassName left, Azure.ResourceManager.Fleet.Models.PassName right) {  }
        public override string ToString() {  }
    }
    public partial class PatchSettings
    {
        public PatchSettings() { }
        public Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode? AssessmentMode { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get {  } set { } }
        public bool? EnableHotpatching { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode? PatchMode { get {  } set { } }
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
        public ProvisioningState(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Canceled { get {  } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Creating { get {  } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Deleting { get {  } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Failed { get {  } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Migrating { get {  } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Succeeded { get {  } }
        public static Azure.ResourceManager.Fleet.Models.ProvisioningState Updating { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.ProvisioningState other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.ProvisioningState left, Azure.ResourceManager.Fleet.Models.ProvisioningState right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.ProvisioningState (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.ProvisioningState left, Azure.ResourceManager.Fleet.Models.ProvisioningState right) {  }
        public override string ToString() {  }
    }
    public partial class ProxyAgentSettings
    {
        public ProxyAgentSettings() { }
        public bool? Enabled { get {  } set { } }
        public int? KeyIncarnationId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.Mode? Mode { get {  } set { } }
    }
    public partial class PublicIPAddressSku
    {
        public PublicIPAddressSku() { }
        public Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName? Name { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier? Tier { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuName(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName Basic { get {  } }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName Standard { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuName right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuTier(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier Global { get {  } }
        public static Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier Regional { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Fleet.Models.PublicIPAddressSkuTier right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegularPriorityAllocationStrategy : System.IEquatable<Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegularPriorityAllocationStrategy(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy LowestPrice { get {  } }
        public static Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy Prioritized { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy right) {  }
        public override string ToString() {  }
    }
    public partial class RegularPriorityProfile
    {
        public RegularPriorityProfile() { }
        public Azure.ResourceManager.Fleet.Models.RegularPriorityAllocationStrategy? AllocationStrategy { get {  } set { } }
        public int? Capacity { get {  } set { } }
        public int? MinCapacity { get {  } set { } }
    }
    public partial class ScheduledEventsProfile
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.Fleet.Models.OSImageNotificationProfile OSImageNotificationProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.TerminateNotificationProfile TerminateNotificationProfile { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.SecurityEncryptionType DiskWithVmGuestState { get {  } }
        public static Azure.ResourceManager.Fleet.Models.SecurityEncryptionType NonPersistedTPM { get {  } }
        public static Azure.ResourceManager.Fleet.Models.SecurityEncryptionType VmGuestStateOnly { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.SecurityEncryptionType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.SecurityEncryptionType left, Azure.ResourceManager.Fleet.Models.SecurityEncryptionType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.SecurityEncryptionType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.SecurityEncryptionType left, Azure.ResourceManager.Fleet.Models.SecurityEncryptionType right) {  }
        public override string ToString() {  }
    }
    public partial class SecurityPostureReference
    {
        public SecurityPostureReference() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineExtension> ExcludeExtensions { get {  } }
        public string Id { get {  } set { } }
    }
    public partial class SecurityProfile
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.ProxyAgentSettings ProxyAgentSettings { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityType? SecurityType { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.UefiSettings UefiSettings { get {  } set { } }
        public string UserAssignedIdentityResourceId { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.Fleet.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.SecurityType ConfidentialVm { get {  } }
        public static Azure.ResourceManager.Fleet.Models.SecurityType TrustedLaunch { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.SecurityType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.SecurityType left, Azure.ResourceManager.Fleet.Models.SecurityType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.SecurityType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.SecurityType left, Azure.ResourceManager.Fleet.Models.SecurityType right) {  }
        public override string ToString() {  }
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
        public SpotAllocationStrategy(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy CapacityOptimized { get {  } }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy Diversified { get {  } }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy LowestPrice { get {  } }
        public static Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy PriceCapacityOptimized { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy right) {  }
        public override string ToString() {  }
    }
    public partial class SpotPriorityProfile
    {
        public SpotPriorityProfile() { }
        public Azure.ResourceManager.Fleet.Models.SpotAllocationStrategy? AllocationStrategy { get {  } set { } }
        public int? Capacity { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.EvictionPolicy? EvictionPolicy { get {  } set { } }
        public float? MaxPricePerVm { get {  } set { } }
        public int? MinCapacity { get {  } set { } }
    }
    public partial class SshPublicKey
    {
        public SshPublicKey() { }
        public string KeyData { get {  } set { } }
        public string Path { get {  } set { } }
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
        public StorageAccountType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType PremiumLRS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType PremiumV2LRS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType PremiumZRS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType StandardLRS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType StandardSSDLRS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType StandardSSDZRS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.StorageAccountType UltraSSDLRS { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.StorageAccountType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.StorageAccountType left, Azure.ResourceManager.Fleet.Models.StorageAccountType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.StorageAccountType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.StorageAccountType left, Azure.ResourceManager.Fleet.Models.StorageAccountType right) {  }
        public override string ToString() {  }
    }
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get {  } set { } }
    }
    public partial class SubResourceReadOnly
    {
        public SubResourceReadOnly() { }
        public string Id { get {  } }
    }
    public partial class TerminateNotificationProfile
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get {  } set { } }
        public string NotBeforeTimeout { get {  } set { } }
    }
    public partial class UefiSettings
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get {  } set { } }
        public bool? VTpmEnabled { get {  } set { } }
    }
    public partial class VaultCertificate
    {
        public VaultCertificate() { }
        public string CertificateStore { get {  } set { } }
        public System.Uri CertificateUri { get {  } set { } }
    }
    public partial class VaultSecretGroup
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VaultCertificate> VaultCertificates { get {  } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyType : System.IEquatable<Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType Deallocate { get {  } }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType Delete { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType right) {  }
        public override string ToString() {  }
    }
    public partial class VirtualMachineExtension : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineExtension(Azure.Core.AzureLocation location) { }
        public bool? AutoUpgradeMinorVersion { get {  } set { } }
        public bool? EnableAutomaticUpgrade { get {  } set { } }
        public string ForceUpdateTag { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineExtensionInstanceView InstanceView { get {  } set { } }
        public System.BinaryData ProtectedSettings { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get {  } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get {  } }
        public string ProvisioningState { get {  } }
        public string Publisher { get {  } set { } }
        public System.BinaryData Settings { get {  } set { } }
        public bool? SuppressFailures { get {  } set { } }
        public string TypeHandlerVersion { get {  } set { } }
        public string TypePropertiesType { get {  } set { } }
    }
    public partial class VirtualMachineExtensionInstanceView
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.InstanceViewStatus> Statuses { get {  } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.InstanceViewStatus> Substatuses { get {  } }
        public string TypeHandlerVersion { get {  } set { } }
        public string VirtualMachineExtensionInstanceViewType { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityType : System.IEquatable<Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityType(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType Low { get {  } }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType Regular { get {  } }
        public static Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType Spot { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType left, Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType left, Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType right) {  }
        public override string ToString() {  }
    }
    public partial class VirtualMachineScaleSet : Azure.ResourceManager.Models.ResourceData
    {
        internal VirtualMachineScaleSet() { }
        public Azure.ResourceManager.Fleet.Models.ProvisioningState ProvisioningState { get {  } }
    }
    public partial class VirtualMachineScaleSetDataDisk
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.Fleet.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Fleet.Models.CachingType? Caching { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskCreateOptionType CreateOption { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType? DeleteOption { get {  } set { } }
        public long? DiskIopsReadWrite { get {  } set { } }
        public long? DiskMBpsReadWrite { get {  } set { } }
        public int? DiskSizeGB { get {  } set { } }
        public int Lun { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetManagedDiskContent ManagedDisk { get {  } set { } }
        public string Name { get {  } set { } }
        public bool? WriteAcceleratorEnabled { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetExtension : Azure.ResourceManager.Fleet.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetExtension() { }
        public bool? AutoUpgradeMinorVersion { get {  } set { } }
        public bool? EnableAutomaticUpgrade { get {  } set { } }
        public string ForceUpdateTag { get {  } set { } }
        public string Name { get {  } set { } }
        public System.BinaryData ProtectedSettings { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get {  } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get {  } }
        public string ProvisioningState { get {  } }
        public string Publisher { get {  } set { } }
        public string ResourceType { get {  } }
        public System.BinaryData Settings { get {  } set { } }
        public bool? SuppressFailures { get {  } set { } }
        public string TypeHandlerVersion { get {  } set { } }
        public string TypePropertiesType { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionProfile
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtension> Extensions { get {  } }
        public string ExtensionsTimeBudget { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetIPConfiguration
    {
        public VirtualMachineScaleSetIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get {  } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get {  } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get {  } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get {  } }
        public string Name { get {  } set { } }
        public bool? Primary { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.IPVersion? PrivateIPAddressVersion { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get {  } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetIPTag
    {
        public VirtualMachineScaleSetIPTag() { }
        public string IPTagType { get {  } set { } }
        public string Tag { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetManagedDiskContent
    {
        public VirtualMachineScaleSetManagedDiskContent() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VmDiskSecurityProfile SecurityProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.StorageAccountType? StorageAccountType { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliaryMode? AuxiliaryMode { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.NetworkInterfaceAuxiliarySku? AuxiliarySku { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DeleteOption? DeleteOption { get {  } set { } }
        public bool? DisableTcpStateTracking { get {  } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get {  } }
        public bool? EnableAcceleratedNetworking { get {  } set { } }
        public bool? EnableFpga { get {  } set { } }
        public bool? EnableIPForwarding { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get {  } }
        public string Name { get {  } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get {  } set { } }
        public bool? Primary { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkProfile
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.NetworkApiVersion? NetworkApiVersion { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get {  } }
    }
    public partial class VirtualMachineScaleSetOSDisk
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.Fleet.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Fleet.Models.CachingType? Caching { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskCreateOptionType CreateOption { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DiskDeleteOptionType? DeleteOption { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DiffDiskSettings DiffDiskSettings { get {  } set { } }
        public int? DiskSizeGB { get {  } set { } }
        public System.Uri ImageUri { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetManagedDiskContent ManagedDisk { get {  } set { } }
        public string Name { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.OperatingSystemType? OSType { get {  } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get {  } }
        public bool? WriteAcceleratorEnabled { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetOSProfile
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get {  } set { } }
        public string AdminUsername { get {  } set { } }
        public bool? AllowExtensionOperations { get {  } set { } }
        public string ComputerNamePrefix { get {  } set { } }
        public string CustomData { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.LinuxConfiguration LinuxConfiguration { get {  } set { } }
        public bool? RequireGuestProvisionSignal { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VaultSecretGroup> Secrets { get {  } }
        public Azure.ResourceManager.Fleet.Models.WindowsConfiguration WindowsConfiguration { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Fleet.Models.DeleteOption? DeleteOption { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get {  } set { } }
        public int? IdleTimeoutInMinutes { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetIPTag> IPTags { get {  } }
        public string Name { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.IPVersion? PublicIPAddressVersion { get {  } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.PublicIPAddressSku Sku { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.DomainNameLabelScopeType? DomainNameLabelScope { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetStorageProfile
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetDataDisk> DataDisks { get {  } }
        public string DiskControllerType { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.ImageReference ImageReference { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetOSDisk OSDisk { get {  } set { } }
    }
    public partial class VirtualMachineScaleSetVmProfile
    {
        public VirtualMachineScaleSetVmProfile() { }
        public double? BillingMaxPrice { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.BootDiagnostics BootDiagnostics { get {  } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.VmGalleryApplication> GalleryApplications { get {  } }
        public Azure.ResourceManager.Fleet.Models.VmSizeProperties HardwareVmSizeProperties { get {  } set { } }
        public string LicenseType { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetOSProfile OSProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachinePriorityType? Priority { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.ScheduledEventsProfile ScheduledEventsProfile { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityPostureReference SecurityPostureReference { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityProfile SecurityProfile { get {  } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get {  } set { } }
        public System.DateTimeOffset? TimeCreated { get {  } }
        public string UserData { get {  } set { } }
    }
    public partial class VmDiskSecurityProfile
    {
        public VmDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.SecurityEncryptionType? SecurityEncryptionType { get {  } set { } }
    }
    public partial class VmGalleryApplication
    {
        public VmGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get {  } set { } }
        public bool? EnableAutomaticUpgrade { get {  } set { } }
        public int? Order { get {  } set { } }
        public string PackageReferenceId { get {  } set { } }
        public string Tags { get {  } set { } }
        public bool? TreatFailureAsDeploymentFailure { get {  } set { } }
    }
    public partial class VmSizeProfile
    {
        public VmSizeProfile(string name) { }
        public string Name { get {  } set { } }
    }
    public partial class VmSizeProperties
    {
        public VmSizeProperties() { }
        public int? VCPUsAvailable { get {  } set { } }
        public int? VCPUsPerCore { get {  } set { } }
    }
    public partial class WindowsConfiguration
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.AdditionalUnattendContent> AdditionalUnattendContent { get {  } }
        public bool? EnableAutomaticUpdates { get {  } set { } }
        public bool? EnableVmAgentPlatformUpdates { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.PatchSettings PatchSettings { get {  } set { } }
        public bool? ProvisionVmAgent { get {  } set { } }
        public string TimeZone { get {  } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.WinRMListener> WinRMListeners { get {  } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get {  } }
        public static Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode ImageDefault { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Fleet.Models.WindowsPatchAssessmentMode right) {  }
        public override string ToString() {  }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchAutomaticByPlatformRebootSetting(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Always { get {  } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get {  } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Never { get {  } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) {  }
        public override string ToString() {  }
    }
    public partial class WindowsVmGuestPatchAutomaticByPlatformSettings
    {
        public WindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get {  } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchMode(string value) {  }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode AutomaticByOS { get {  } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode AutomaticByPlatform { get {  } }
        public static Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode Manual { get {  } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode other) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) {  }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() {  }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode right) {  }
        public static implicit operator Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode (string value) {  }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.Fleet.Models.WindowsVmGuestPatchMode right) {  }
        public override string ToString() {  }
    }
    public partial class WinRMListener
    {
        public WinRMListener() { }
        public System.Uri CertificateUri { get {  } set { } }
        public Azure.ResourceManager.Fleet.Models.ProtocolType? Protocol { get {  } set { } }
    }
}
