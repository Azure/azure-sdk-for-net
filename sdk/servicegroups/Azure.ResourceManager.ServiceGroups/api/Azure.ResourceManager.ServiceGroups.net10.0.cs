namespace Azure.ResourceManager.ServiceGroups
{
    public partial class AzureResourceManagerServiceGroupsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerServiceGroupsContext() { }
        public static Azure.ResourceManager.ServiceGroups.AzureResourceManagerServiceGroupsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ServiceGroupCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServiceGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceGroupName, Azure.ResourceManager.ServiceGroups.ServiceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceGroupName, Azure.ResourceManager.ServiceGroups.ServiceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> Get(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> GetAncestors(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> GetAncestorsAsync(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> GetAsync(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> GetIfExists(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> GetIfExistsAsync(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>
    {
        public ServiceGroupData() { }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceGroups.ServiceGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceGroups.ServiceGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceGroupResource() { }
        public virtual Azure.ResourceManager.ServiceGroups.ServiceGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceGroups.ServiceGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceGroups.ServiceGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.ServiceGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceGroups.ServiceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceGroups.ServiceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceGroupsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> GetServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> GetServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceGroups.ServiceGroupResource GetServiceGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceGroups.ServiceGroupCollection GetServiceGroups(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceGroups.Mocking
{
    public partial class MockableServiceGroupsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceGroupsArmClient() { }
        public virtual Azure.ResourceManager.ServiceGroups.ServiceGroupResource GetServiceGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableServiceGroupsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceGroupsTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource> GetServiceGroup(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceGroups.ServiceGroupResource>> GetServiceGroupAsync(string serviceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceGroups.ServiceGroupCollection GetServiceGroups() { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceGroups.Models
{
    public static partial class ArmServiceGroupsModelFactory
    {
        public static Azure.ResourceManager.ServiceGroups.ServiceGroupData ServiceGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties ServiceGroupProperties(Azure.ResourceManager.ServiceGroups.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceGroups.Models.ProvisioningState?), string displayName = null, Azure.Core.ResourceIdentifier parentResourceId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceGroups.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceGroups.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceGroups.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceGroups.Models.ProvisioningState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ServiceGroups.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ServiceGroups.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceGroups.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceGroups.Models.ProvisioningState left, Azure.ResourceManager.ServiceGroups.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceGroups.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceGroups.Models.ProvisioningState left, Azure.ResourceManager.ServiceGroups.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>
    {
        public ServiceGroupProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceGroups.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceGroups.Models.ServiceGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
