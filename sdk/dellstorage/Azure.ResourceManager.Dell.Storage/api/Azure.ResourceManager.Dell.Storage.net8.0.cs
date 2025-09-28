namespace Azure.ResourceManager.Dell.Storage
{
    public partial class AzureResourceManagerDellStorageContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDellStorageContext() { }
        public static Azure.ResourceManager.Dell.Storage.AzureResourceManagerDellStorageContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DellFileSystemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>, System.Collections.IEnumerable
    {
        protected DellFileSystemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filesystemName, Azure.ResourceManager.Dell.Storage.DellFileSystemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filesystemName, Azure.ResourceManager.Dell.Storage.DellFileSystemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> Get(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> GetAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetIfExists(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> GetIfExistsAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DellFileSystemData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>
    {
        public DellFileSystemData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.DellFileSystemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.DellFileSystemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DellFileSystemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DellFileSystemResource() { }
        public virtual Azure.ResourceManager.Dell.Storage.DellFileSystemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string filesystemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Dell.Storage.DellFileSystemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.DellFileSystemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.DellFileSystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> Update(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> UpdateAsync(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DellStorageExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetDellFileSystem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> GetDellFileSystemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.DellFileSystemResource GetDellFileSystemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.DellFileSystemCollection GetDellFileSystems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetDellFileSystems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetDellFileSystemsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dell.Storage.Mocking
{
    public partial class MockableDellStorageArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDellStorageArmClient() { }
        public virtual Azure.ResourceManager.Dell.Storage.DellFileSystemResource GetDellFileSystemResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDellStorageResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDellStorageResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetDellFileSystem(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.DellFileSystemResource>> GetDellFileSystemAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dell.Storage.DellFileSystemCollection GetDellFileSystems() { throw null; }
    }
    public partial class MockableDellStorageSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDellStorageSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetDellFileSystems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dell.Storage.DellFileSystemResource> GetDellFileSystemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dell.Storage.Models
{
    public static partial class ArmDellStorageModelFactory
    {
        public static Azure.ResourceManager.Dell.Storage.DellFileSystemData DellFileSystemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails DellFileSystemMarketplaceDetails(string marketplaceSubscriptionId = null, string planId = null, string offerId = null, string publisherId = null, string privateOfferId = null, string planName = null, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus?), string endDate = null, string termUnit = null) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch DellFileSystemPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties DellFileSystemProperties(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity capacity = null, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails marketplace = null, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState? provisioningState = default(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState?), Azure.Core.ResourceIdentifier delegatedSubnetId = null, string delegatedSubnetCidr = null, string userEmail = null, string fileSystemId = null, string smartConnectFqdn = null, System.Uri oneFsUri = null, string dellReferenceNumber = null, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties encryption = null) { throw null; }
    }
    public partial class DellFileSystemCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>
    {
        public DellFileSystemCapacity() { }
        public string Current { get { throw null; } set { } }
        public string Incremental { get { throw null; } set { } }
        public string Max { get { throw null; } set { } }
        public string Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DellFileSystemEncryptionIdentityPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>
    {
        public DellFileSystemEncryptionIdentityPatchProperties() { }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DellFileSystemEncryptionIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>
    {
        public DellFileSystemEncryptionIdentityProperties() { }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DellFileSystemEncryptionIdentityType : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DellFileSystemEncryptionIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DellFileSystemEncryptionPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>
    {
        public DellFileSystemEncryptionPatchProperties() { }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityPatchProperties EncryptionIdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType? EncryptionType { get { throw null; } set { } }
        public string KeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DellFileSystemEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>
    {
        public DellFileSystemEncryptionProperties(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType encryptionType) { }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionIdentityProperties EncryptionIdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType EncryptionType { get { throw null; } set { } }
        public string KeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DellFileSystemEncryptionType : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DellFileSystemEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType CustomerManagedKeysCmk { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType MicrosoftManagedKeysMmk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DellFileSystemMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>
    {
        public DellFileSystemMarketplaceDetails(string planId, string offerId, string planName) { }
        public string EndDate { get { throw null; } set { } }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DellFileSystemMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DellFileSystemMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DellFileSystemPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>
    {
        public DellFileSystemPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DellFileSystemPatchProperties
    {
        public DellFileSystemPatchProperties() { }
    }
    public partial class DellFileSystemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>
    {
        public DellFileSystemProperties(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails marketplace, Azure.Core.ResourceIdentifier delegatedSubnetId, string delegatedSubnetCidr, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails user, string dellReferenceNumber, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties encryption) { }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity Capacity { get { throw null; } set { } }
        public string DelegatedSubnetCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedSubnetId { get { throw null; } set { } }
        public string DellReferenceNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionProperties Encryption { get { throw null; } set { } }
        public string FileSystemId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemMarketplaceDetails Marketplace { get { throw null; } set { } }
        public System.Uri OneFsUri { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState? ProvisioningState { get { throw null; } }
        public string SmartConnectFqdn { get { throw null; } set { } }
        public string UserEmail { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DellFileSystemProvisioningState : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DellFileSystemProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState left, Azure.ResourceManager.Dell.Storage.Models.DellFileSystemProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DellFileSystemUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>
    {
        public DellFileSystemUserDetails(string email) { }
        public string Email { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.DellFileSystemUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSystemResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>
    {
        public FileSystemResourceUpdateProperties() { }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemCapacity Capacity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.DellFileSystemEncryptionPatchProperties Encryption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.FileSystemResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
