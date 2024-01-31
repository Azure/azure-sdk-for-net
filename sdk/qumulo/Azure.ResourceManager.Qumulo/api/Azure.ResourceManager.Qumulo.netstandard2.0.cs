namespace Azure.ResourceManager.Qumulo
{
    public static partial class QumuloExtensions
    {
        public static Azure.ResourceManager.Qumulo.QumuloFileSystemResource GetQumuloFileSystemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> GetQumuloFileSystemResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloFileSystemResourceCollection GetQumuloFileSystemResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloFileSystemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloFileSystemResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fileSystemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloFileSystemResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>, System.Collections.IEnumerable
    {
        protected QumuloFileSystemResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileSystemName, Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileSystemName, Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> Get(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> GetAsync(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetIfExists(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> GetIfExistsAsync(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloFileSystemResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>
    {
        public QumuloFileSystemResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Qumulo.Models.MarketplaceDetails marketplaceDetails, Azure.ResourceManager.Qumulo.Models.StorageSku storageSku, Azure.ResourceManager.Qumulo.Models.QumuloUserDetails userDetails, string delegatedSubnetId, string adminPassword, int initialCapacity) { }
        public string AdminPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public System.Uri ClusterLoginUri { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int InitialCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> PrivateIPs { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.StorageSku StorageSku { get { throw null; } set { } }
        public string UserDetailsEmail { get { throw null; } set { } }
        Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Qumulo.Mocking
{
    public partial class MockableQumuloArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableQumuloArmClient() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloFileSystemResource GetQumuloFileSystemResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableQumuloResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQumuloResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResource(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> GetQumuloFileSystemResourceAsync(string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloFileSystemResourceCollection GetQumuloFileSystemResources() { throw null; }
    }
    public partial class MockableQumuloSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQumuloSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Qumulo.Models
{
    public static partial class ArmQumuloModelFactory
    {
        public static Azure.ResourceManager.Qumulo.Models.MarketplaceDetails MarketplaceDetails(string marketplaceSubscriptionId = null, string planId = null, string offerId = null, string publisherId = null, Azure.ResourceManager.Qumulo.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Qumulo.Models.MarketplaceSubscriptionStatus?)) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData QumuloFileSystemResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Qumulo.Models.MarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?), Azure.ResourceManager.Qumulo.Models.StorageSku storageSku = Azure.ResourceManager.Qumulo.Models.StorageSku.Standard, string userDetailsEmail = null, string delegatedSubnetId = null, System.Uri clusterLoginUri = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> privateIPs = null, string adminPassword = null, int initialCapacity = 0, string availabilityZone = null) { throw null; }
    }
    public partial class FileSystemResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>
    {
        public FileSystemResourceUpdateProperties() { }
        public System.Uri ClusterLoginUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrivateIPs { get { throw null; } }
        public string UserDetailsEmail { get { throw null; } set { } }
        Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(string planId, string offerId, string publisherId) { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        Azure.ResourceManager.Qumulo.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MarketplaceSubscriptionStatus
    {
        PendingFulfillmentStart = 0,
        Subscribed = 1,
        Suspended = 2,
        Unsubscribed = 3,
    }
    public partial class QumuloFileSystemResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>
    {
        public QumuloFileSystemResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum QumuloProvisioningState
    {
        NotSpecified = 0,
        Accepted = 1,
        Creating = 2,
        Updating = 3,
        Deleting = 4,
        Succeeded = 5,
        Failed = 6,
        Canceled = 7,
        Deleted = 8,
    }
    public partial class QumuloUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>
    {
        public QumuloUserDetails() { }
        public string Email { get { throw null; } set { } }
        Azure.ResourceManager.Qumulo.Models.QumuloUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.QumuloUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageSku
    {
        Standard = 0,
        Performance = 1,
    }
}
