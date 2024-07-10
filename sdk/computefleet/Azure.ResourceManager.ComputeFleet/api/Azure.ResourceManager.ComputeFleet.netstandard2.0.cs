namespace Azure.ResourceManager.ComputeFleet
{
    public static partial class ComputeFleetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ComputeFleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ComputeFleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeFleet.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeFleet.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeFleet.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeFleet.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>
    {
        public FleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.FleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.ComputeFleet.FleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeFleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeFleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeFleet.Mocking
{
    public partial class MockableComputeFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetArmClient() { }
        public virtual Azure.ResourceManager.ComputeFleet.FleetResource GetFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeFleetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeFleet.FleetCollection GetFleets() { throw null; }
    }
    public partial class MockableComputeFleetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class ApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>
    {
        internal ApiError() { }
        Azure.ResourceManager.ComputeFleet.Models.ApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmComputeFleetModelFactory
    {
        public static Azure.ResourceManager.ComputeFleet.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeFleet.Models.FleetProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.FleetProperties FleetProperties(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState?), Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile spotPriorityProfile = null, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile regularPriorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeProfile computeProfile = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity ManagedServiceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet VirtualMachineScaleSet(string id = null, string type = null, Azure.ResourceManager.ComputeFleet.Models.ProvisioningState operationStatus = default(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState), Azure.ResourceManager.ComputeFleet.Models.ApiError error = null) { throw null; }
    }
    public partial class BaseVirtualMachineProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>
    {
        public BaseVirtualMachineProfile() { }
        Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>
    {
        public ComputeProfile(Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile baseVirtualMachineProfile) { }
        public Azure.ResourceManager.ComputeFleet.Models.BaseVirtualMachineProfile BaseVirtualMachineProfile { get { throw null; } set { } }
        public string ComputeApiVersion { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy left, Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy left, Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>
    {
        public FleetPatch() { }
        public Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.FleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.FleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.FleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>
    {
        public FleetProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> vmSizesProfile, Azure.ResourceManager.ComputeFleet.Models.ComputeProfile computeProfile) { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile RegularPriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile SpotPriorityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.FleetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.FleetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>
    {
        public ManagedServiceIdentity(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType SystemAndUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType left, Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType left, Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentityUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>
    {
        public ManagedServiceIdentityUpdate() { }
        public Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState left, Azure.ResourceManager.ComputeFleet.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState left, Azure.ResourceManager.ComputeFleet.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegularPriorityAllocationStrategy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegularPriorityAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegularPriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>
    {
        public RegularPriorityProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpotAllocationStrategy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpotAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy PriceCapacityOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpotPriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>
    {
        public SpotPriorityProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public bool? Maintain { get { throw null; } set { } }
        public float? MaxPricePerVm { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>
    {
        internal VirtualMachineScaleSet() { }
        public Azure.ResourceManager.ComputeFleet.Models.ApiError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ProvisioningState OperationStatus { get { throw null; } }
        public string Type { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>
    {
        public VmSizeProfile(string name) { }
        public string Name { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
