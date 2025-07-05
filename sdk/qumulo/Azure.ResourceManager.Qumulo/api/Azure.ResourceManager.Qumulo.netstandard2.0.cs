namespace Azure.ResourceManager.Qumulo
{
    public partial class AzureResourceManagerQumuloContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerQumuloContext() { }
        public static Azure.ResourceManager.Qumulo.AzureResourceManagerQumuloContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class QumuloExtensions
    {
        public static Azure.ResourceManager.Qumulo.QumuloFileSystemResource GetQumuloFileSystemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloFileSystemResource>> GetQumuloFileSystemResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fileSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloFileSystemResourceCollection GetQumuloFileSystemResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloFileSystemResource> GetQumuloFileSystemResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloFileSystemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>
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
        Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public QumuloFileSystemResourceData(Azure.Core.AzureLocation location) { }
        public string AdminPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public string ClusterLoginUri { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrivateIPs { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StorageSku { get { throw null; } set { } }
        public string UserDetailsEmail { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.Qumulo.QumuloFileSystemResourceData QumuloFileSystemResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.Qumulo.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.ProvisioningState?), string storageSku = null, string userDetailsEmail = null, string delegatedSubnetId = null, string clusterLoginUri = null, System.Collections.Generic.IEnumerable<string> privateIPs = null, string adminPassword = null, string availabilityZone = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails QumuloMarketplaceDetails(string marketplaceSubscriptionId = null, string planId = null, string offerId = null, string publisherId = null, string termUnit = null, Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus?)) { throw null; }
    }
    public partial class FileSystemResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>
    {
        public FileSystemResourceUpdateProperties() { }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public string UserDetailsEmail { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Qumulo.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.ProvisioningState left, Azure.ResourceManager.Qumulo.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.ProvisioningState left, Azure.ResourceManager.Qumulo.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QumuloFileSystemResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>
    {
        public QumuloFileSystemResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.FileSystemResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloFileSystemResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QumuloMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>
    {
        public QumuloMarketplaceDetails(string planId, string offerId) { }
        public QumuloMarketplaceDetails(string planId, string offerId, string publisherId) { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus left, Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus left, Azure.ResourceManager.Qumulo.Models.QumuloMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
