namespace Azure.ResourceManager.Dell.Storage
{
    public static partial class DellStorageExtensions
    {
        public static Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource GetLiftrBaseStorageFileSystemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetLiftrBaseStorageFileSystemResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> GetLiftrBaseStorageFileSystemResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceCollection GetLiftrBaseStorageFileSystemResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetLiftrBaseStorageFileSystemResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetLiftrBaseStorageFileSystemResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LiftrBaseStorageFileSystemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LiftrBaseStorageFileSystemResource() { }
        public virtual Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string filesystemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> Update(Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> UpdateAsync(Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LiftrBaseStorageFileSystemResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>, System.Collections.IEnumerable
    {
        protected LiftrBaseStorageFileSystemResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filesystemName, Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filesystemName, Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> Get(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> GetAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetIfExists(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> GetIfExistsAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LiftrBaseStorageFileSystemResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>
    {
        public LiftrBaseStorageFileSystemResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Dell.Storage.Mocking
{
    public partial class MockableDellStorageArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDellStorageArmClient() { }
        public virtual Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource GetLiftrBaseStorageFileSystemResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDellStorageResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDellStorageResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetLiftrBaseStorageFileSystemResource(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource>> GetLiftrBaseStorageFileSystemResourceAsync(string filesystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceCollection GetLiftrBaseStorageFileSystemResources() { throw null; }
    }
    public partial class MockableDellStorageSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDellStorageSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetLiftrBaseStorageFileSystemResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResource> GetLiftrBaseStorageFileSystemResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dell.Storage.Models
{
    public static partial class ArmDellStorageModelFactory
    {
        public static Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails LiftrBaseMarketplaceDetails(string marketplaceSubscriptionId = null, string planId = null, string offerId = null, string publisherId = null, string privateOfferId = null, string planName = null, Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus?), string endDate = null, string termUnit = null) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.LiftrBaseStorageFileSystemResourceData LiftrBaseStorageFileSystemResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties LiftrBaseStorageFileSystemResourceProperties(Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity capacity = null, Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails marketplace = null, Azure.ResourceManager.Dell.Storage.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Dell.Storage.Models.ProvisioningState?), string delegatedSubnetId = null, string delegatedSubnetCidr = null, string userEmail = null, string fileSystemId = null, string smartConnectFqdn = null, string oneFsUri = null, string dellReferenceNumber = null, Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties encryption = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionIdentityType : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType left, Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType left, Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiftrBaseEncryptionIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>
    {
        public LiftrBaseEncryptionIdentityProperties() { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseEncryptionIdentityUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>
    {
        public LiftrBaseEncryptionIdentityUpdateProperties() { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.EncryptionIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>
    {
        public LiftrBaseEncryptionProperties(Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType encryptionType) { }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityProperties EncryptionIdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType EncryptionType { get { throw null; } set { } }
        public string KeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseEncryptionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>
    {
        public LiftrBaseEncryptionUpdateProperties() { }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionIdentityUpdateProperties EncryptionIdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType? EncryptionType { get { throw null; } set { } }
        public string KeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>
    {
        public LiftrBaseMarketplaceDetails(string planId, string offerId, string planName) { }
        public string EndDate { get { throw null; } set { } }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseStorageCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>
    {
        public LiftrBaseStorageCapacity() { }
        public string Current { get { throw null; } set { } }
        public string Incremental { get { throw null; } set { } }
        public string Max { get { throw null; } set { } }
        public string Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseStorageFileSystemResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>
    {
        public LiftrBaseStorageFileSystemResourcePatch() { }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseStorageFileSystemResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>
    {
        public LiftrBaseStorageFileSystemResourceProperties(Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails marketplace, string delegatedSubnetId, string delegatedSubnetCidr, Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails user, string dellReferenceNumber, Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties encryption) { }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity Capacity { get { throw null; } set { } }
        public string DelegatedSubnetCidr { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public string DellReferenceNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionProperties Encryption { get { throw null; } set { } }
        public string FileSystemId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseMarketplaceDetails Marketplace { get { throw null; } set { } }
        public string OneFsUri { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SmartConnectFqdn { get { throw null; } set { } }
        public string UserEmail { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseStorageFileSystemResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>
    {
        public LiftrBaseStorageFileSystemResourceUpdateProperties() { }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageCapacity Capacity { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Dell.Storage.Models.LiftrBaseEncryptionUpdateProperties Encryption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageFileSystemResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseStorageManagedServiceIdentityUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>
    {
        public LiftrBaseStorageManagedServiceIdentityUpdate() { }
        public Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseStorageManagedServiceIdentityUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>
    {
        public LiftrBaseUserDetails(string email) { }
        public string Email { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dell.Storage.Models.LiftrBaseUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Dell.Storage.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Dell.Storage.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.ProvisioningState left, Azure.ResourceManager.Dell.Storage.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.ProvisioningState left, Azure.ResourceManager.Dell.Storage.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceEncryptionType : System.IEquatable<Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType CustomerManagedKeysCMK { get { throw null; } }
        public static Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType MicrosoftManagedKeysMMK { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType left, Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType left, Azure.ResourceManager.Dell.Storage.Models.ResourceEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
