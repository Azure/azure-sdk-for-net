namespace Azure.ResourceManager.Dell
{
    public static partial class DellExtensions
    {
        public static Azure.ResourceManager.Dell.FileSystemResource GetFileSystemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> GetFileSystemResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> GetFileSystemResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dell.FileSystemResourceCollection GetFileSystemResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dell.FileSystemResource> GetFileSystemResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dell.FileSystemResource> GetFileSystemResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileSystemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.FileSystemResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileSystemResource() { }
        public virtual Azure.ResourceManager.Dell.FileSystemResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string filesystemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Dell.FileSystemResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.FileSystemResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> Update(Azure.ResourceManager.Dell.Models.FileSystemResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> UpdateAsync(Azure.ResourceManager.Dell.Models.FileSystemResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileSystemResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dell.FileSystemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dell.FileSystemResource>, System.Collections.IEnumerable
    {
        protected FileSystemResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dell.FileSystemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filesystemName, Azure.ResourceManager.Dell.FileSystemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dell.FileSystemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filesystemName, Azure.ResourceManager.Dell.FileSystemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> Get(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dell.FileSystemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dell.FileSystemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> GetAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Dell.FileSystemResource> GetIfExists(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Dell.FileSystemResource>> GetIfExistsAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dell.FileSystemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dell.FileSystemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dell.FileSystemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dell.FileSystemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileSystemResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.FileSystemResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>
    {
        public FileSystemResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.FileSystemResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.FileSystemResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.FileSystemResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.FileSystemResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Dell.Mocking
{
    public partial class MockableDellArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDellArmClient() { }
        public virtual Azure.ResourceManager.Dell.FileSystemResource GetFileSystemResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDellResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDellResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Dell.FileSystemResource> GetFileSystemResource(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.FileSystemResource>> GetFileSystemResourceAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dell.FileSystemResourceCollection GetFileSystemResources() { throw null; }
    }
    public partial class MockableDellSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDellSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Dell.FileSystemResource> GetFileSystemResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dell.FileSystemResource> GetFileSystemResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dell.Models
{
    public static partial class ArmDellModelFactory
    {
        public static Azure.ResourceManager.Dell.FileSystemResourceData FileSystemResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Dell.Models.FileSystemResourceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Dell.Models.FileSystemResourceProperties FileSystemResourceProperties(Azure.ResourceManager.Dell.Models.Capacity capacity = null, Azure.ResourceManager.Dell.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.Dell.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Dell.Models.ProvisioningState?), string delegatedSubnetId = null, string delegatedSubnetCidr = null, string userEmail = null, string fileSystemId = null, string smartConnectFqdn = null, string oneFsUri = null, string dellReferenceNumber = null, Azure.ResourceManager.Dell.Models.EncryptionProperties encryption = null) { throw null; }
        public static Azure.ResourceManager.Dell.Models.MarketplaceDetails MarketplaceDetails(string marketplaceSubscriptionId = null, string planId = null, string offerId = null, string publisherId = null, string privateOfferId = null, string planName = null, Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus?), string endDate = null, string termUnit = null) { throw null; }
    }
    public partial class Capacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.Capacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.Capacity>
    {
        public Capacity() { }
        public string Current { get { throw null; } set { } }
        public string Incremental { get { throw null; } set { } }
        public string Max { get { throw null; } set { } }
        public string Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.Capacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.Capacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.Capacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.Capacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.Capacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.Capacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.Capacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>
    {
        public EncryptionIdentityProperties() { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.EncryptionIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionIdentityType : System.IEquatable<Azure.ResourceManager.Dell.Models.EncryptionIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Models.EncryptionIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.EncryptionIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Models.EncryptionIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Models.EncryptionIdentityType left, Azure.ResourceManager.Dell.Models.EncryptionIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Models.EncryptionIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Models.EncryptionIdentityType left, Azure.ResourceManager.Dell.Models.EncryptionIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionIdentityUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>
    {
        public EncryptionIdentityUpdateProperties() { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.EncryptionIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>
    {
        public EncryptionProperties(Azure.ResourceManager.Dell.Models.ResourceEncryptionType encryptionType) { }
        public Azure.ResourceManager.Dell.Models.EncryptionIdentityProperties EncryptionIdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.ResourceEncryptionType EncryptionType { get { throw null; } set { } }
        public string KeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>
    {
        public EncryptionUpdateProperties() { }
        public Azure.ResourceManager.Dell.Models.EncryptionIdentityUpdateProperties EncryptionIdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.ResourceEncryptionType? EncryptionType { get { throw null; } set { } }
        public string KeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSystemResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>
    {
        public FileSystemResourcePatch() { }
        public Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.FileSystemResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.FileSystemResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSystemResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>
    {
        public FileSystemResourceProperties(Azure.ResourceManager.Dell.Models.MarketplaceDetails marketplace, string delegatedSubnetId, string delegatedSubnetCidr, Azure.ResourceManager.Dell.Models.UserDetails user, string dellReferenceNumber, Azure.ResourceManager.Dell.Models.EncryptionProperties encryption) { }
        public Azure.ResourceManager.Dell.Models.Capacity Capacity { get { throw null; } set { } }
        public string DelegatedSubnetCidr { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public string DellReferenceNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public string FileSystemId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public string OneFsUri { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SmartConnectFqdn { get { throw null; } set { } }
        public string UserEmail { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.FileSystemResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.FileSystemResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSystemResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>
    {
        public FileSystemResourceUpdateProperties() { }
        public Azure.ResourceManager.Dell.Models.Capacity Capacity { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.EncryptionUpdateProperties Encryption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.FileSystemResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentityUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>
    {
        public ManagedServiceIdentityUpdate() { }
        public Azure.ResourceManager.Dell.Models.ManagedServiceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.ManagedServiceIdentityUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(string planId, string offerId, string planName) { }
        public string EndDate { get { throw null; } set { } }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Dell.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Dell.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Models.ProvisioningState left, Azure.ResourceManager.Dell.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Models.ProvisioningState left, Azure.ResourceManager.Dell.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceEncryptionType : System.IEquatable<Azure.ResourceManager.Dell.Models.ResourceEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Models.ResourceEncryptionType CustomerManagedKeysCMK { get { throw null; } }
        public static Azure.ResourceManager.Dell.Models.ResourceEncryptionType MicrosoftManagedKeysMMK { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Models.ResourceEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Models.ResourceEncryptionType left, Azure.ResourceManager.Dell.Models.ResourceEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Models.ResourceEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Models.ResourceEncryptionType left, Azure.ResourceManager.Dell.Models.ResourceEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.UserDetails>
    {
        public UserDetails(string email) { }
        public string Email { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
