namespace Azure.ResourceManager.StorageDiscovery
{
    public partial class AzureResourceManagerStorageDiscoveryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStorageDiscoveryContext() { }
        public static Azure.ResourceManager.StorageDiscovery.AzureResourceManagerStorageDiscoveryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class StorageDiscoveryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetStorageDiscoveryWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> GetStorageDiscoveryWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource GetStorageDiscoveryWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceCollection GetStorageDiscoveryWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetStorageDiscoveryWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetStorageDiscoveryWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageDiscoveryWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>, System.Collections.IEnumerable
    {
        protected StorageDiscoveryWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageDiscoveryWorkspaceName, Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageDiscoveryWorkspaceName, Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> Get(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> GetAsync(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetIfExists(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> GetIfExistsAsync(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageDiscoveryWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>
    {
        public StorageDiscoveryWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDiscoveryWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageDiscoveryWorkspaceResource() { }
        public virtual Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageDiscoveryWorkspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> Update(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> UpdateAsync(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageDiscovery.Mocking
{
    public partial class MockableStorageDiscoveryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageDiscoveryArmClient() { }
        public virtual Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource GetStorageDiscoveryWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStorageDiscoveryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageDiscoveryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetStorageDiscoveryWorkspace(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource>> GetStorageDiscoveryWorkspaceAsync(string storageDiscoveryWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceCollection GetStorageDiscoveryWorkspaces() { throw null; }
    }
    public partial class MockableStorageDiscoverySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageDiscoverySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetStorageDiscoveryWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceResource> GetStorageDiscoveryWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageDiscovery.Models
{
    public static partial class ArmStorageDiscoveryModelFactory
    {
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope StorageDiscoveryScope(string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind> resourceTypes = null, System.Collections.Generic.IEnumerable<string> tagKeysOnly = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.StorageDiscoveryWorkspaceData StorageDiscoveryWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch StorageDiscoveryWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties StorageDiscoveryWorkspacePatchProperties(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku? sku = default(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku?), string description = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workspaceRoots = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope> scopes = null) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties StorageDiscoveryWorkspaceProperties(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku? sku = default(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku?), string description = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workspaceRoots = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope> scopes = null, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageDiscoveryProvisioningState : System.IEquatable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageDiscoveryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState left, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState left, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageDiscoveryResourceKind : System.IEquatable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageDiscoveryResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind StorageAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind left, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind left, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageDiscoveryScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>
    {
        public StorageDiscoveryScope(string displayName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind> resourceTypes) { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryResourceKind> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> TagKeysOnly { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageDiscoverySku : System.IEquatable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageDiscoverySku(string value) { throw null; }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku Free { get { throw null; } }
        public static Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku left, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku left, Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageDiscoveryWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>
    {
        public StorageDiscoveryWorkspacePatch() { }
        public Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDiscoveryWorkspacePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>
    {
        public StorageDiscoveryWorkspacePatchProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope> Scopes { get { throw null; } }
        public Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku? Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> WorkspaceRoots { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspacePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDiscoveryWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>
    {
        public StorageDiscoveryWorkspaceProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workspaceRoots, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope> scopes) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryScope> Scopes { get { throw null; } }
        public Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoverySku? Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> WorkspaceRoots { get { throw null; } }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageDiscovery.Models.StorageDiscoveryWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
