namespace Azure.ResourceManager.StoragePool
{
    public partial class AzureResourceManagerStoragePoolContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStoragePoolContext() { }
        public static Azure.ResourceManager.StoragePool.AzureResourceManagerStoragePoolContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DiskPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>, System.Collections.IEnumerable
    {
        protected DiskPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskPoolName, Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskPoolName, Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> Get(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StoragePool.DiskPoolResource> GetIfExists(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetIfExistsAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StoragePool.DiskPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StoragePool.DiskPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>
    {
        public DiskPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState provisioningState, System.Collections.Generic.IEnumerable<string> availabilityZones, Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus status, Azure.Core.ResourceIdentifier subnetId) { }
        public System.Collections.Generic.IList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Status { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.DiskPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.DiskPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskPoolIscsiTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>, System.Collections.IEnumerable
    {
        protected DiskPoolIscsiTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string iscsiTargetName, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string iscsiTargetName, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> Get(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>> GetAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> GetIfExists(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>> GetIfExistsAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskPoolIscsiTargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>
    {
        public DiskPoolIscsiTargetData(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode aclMode, string targetIqn, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState provisioningState, Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus status) { }
        public Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode AclMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sessions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl> StaticAcls { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Status { get { throw null; } set { } }
        public string TargetIqn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskPoolIscsiTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskPoolIscsiTargetResource() { }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskPoolName, string iscsiTargetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskPoolResource() { }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource> GetDiskPoolIscsiTarget(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource>> GetDiskPoolIscsiTargetAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetCollection GetDiskPoolIscsiTargets() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StoragePool.DiskPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.DiskPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.DiskPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.DiskPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.DiskPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StoragePoolExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetDiskPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource GetDiskPoolIscsiTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolResource GetDiskPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolCollection GetDiskPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo> GetResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo> GetResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StoragePool.Mocking
{
    public partial class MockableStoragePoolArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStoragePoolArmClient() { }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetResource GetDiskPoolIscsiTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolResource GetDiskPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStoragePoolResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStoragePoolResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPool(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetDiskPoolAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolCollection GetDiskPools() { throw null; }
    }
    public partial class MockableStoragePoolSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStoragePoolSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZones(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZonesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo> GetResourceSkus(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo> GetResourceSkusAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StoragePool.Models
{
    public static partial class ArmStoragePoolModelFactory
    {
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent DiskPoolCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StoragePool.Models.StoragePoolSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string managedBy = null, System.Collections.Generic.IEnumerable<string> managedByExtended = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> disks = null, Azure.Core.ResourceIdentifier subnetId = null, System.Collections.Generic.IEnumerable<string> additionalCapabilities = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolData DiskPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StoragePool.Models.StoragePoolSku sku = null, string managedBy = null, System.Collections.Generic.IEnumerable<string> managedByExtended = null, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState provisioningState = default(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState), System.Collections.Generic.IEnumerable<string> availabilityZones = null, Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus status = default(Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> disks = null, Azure.Core.ResourceIdentifier subnetId = null, System.Collections.Generic.IEnumerable<string> additionalCapabilities = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent DiskPoolIscsiTargetCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string managedBy = null, System.Collections.Generic.IEnumerable<string> managedByExtended = null, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode aclMode = default(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode), string targetIqn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl> staticAcls = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun> luns = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolIscsiTargetData DiskPoolIscsiTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string managedBy = null, System.Collections.Generic.IEnumerable<string> managedByExtended = null, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode aclMode = default(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl> staticAcls = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun> luns = null, string targetIqn = null, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState provisioningState = default(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState), Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus status = default(Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus), System.Collections.Generic.IEnumerable<string> endpoints = null, int? port = default(int?), System.Collections.Generic.IEnumerable<string> sessions = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch DiskPoolIscsiTargetPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string managedBy = null, System.Collections.Generic.IEnumerable<string> managedByExtended = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl> staticAcls = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun> luns = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo DiskPoolZoneInfo(System.Collections.Generic.IEnumerable<string> availabilityZones = null, System.Collections.Generic.IEnumerable<string> additionalCapabilities = null, Azure.ResourceManager.StoragePool.Models.StoragePoolSku sku = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun ManagedDiskIscsiLun(string name = null, Azure.Core.ResourceIdentifier managedDiskAzureResourceId = null, int? lun = default(int?)) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency OutboundEndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail OutboundEndpointDetail(System.Net.IPAddress ipAddress = null, int? port = default(int?), double? latencyInMs = default(double?), bool? isAccessible = default(bool?)) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment StoragePoolOutboundEnvironment(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability StoragePoolSkuCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo StoragePoolSkuInfo(string apiVersion = null, string resourceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability> capabilities = null, Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo locationInfo = null, string name = null, string tier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo StoragePoolSkuLocationInfo(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails> zoneDetails = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo StoragePoolSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions StoragePoolSkuRestrictions(Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails StoragePoolSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability> capabilities = null) { throw null; }
    }
    public partial class DiskPoolCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>
    {
        public DiskPoolCreateOrUpdateContent(Azure.ResourceManager.StoragePool.Models.StoragePoolSku sku, Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier subnetId) { }
        public System.Collections.Generic.IList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskPoolIscsiTargetAclMode : System.IEquatable<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskPoolIscsiTargetAclMode(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode Dynamic { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode left, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode left, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPoolIscsiTargetCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>
    {
        public DiskPoolIscsiTargetCreateOrUpdateContent(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode aclMode) { }
        public Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetAclMode AclMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl> StaticAcls { get { throw null; } }
        public string TargetIqn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskPoolIscsiTargetPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>
    {
        public DiskPoolIscsiTargetPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl> StaticAcls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskPoolIscsiTargetPortalGroupAcl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>
    {
        public DiskPoolIscsiTargetPortalGroupAcl(string initiatorIqn, System.Collections.Generic.IEnumerable<string> mappedLuns) { }
        public string InitiatorIqn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MappedLuns { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetPortalGroupAcl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskPoolIscsiTargetProvisioningState : System.IEquatable<Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskPoolIscsiTargetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState left, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState left, Azure.ResourceManager.StoragePool.Models.DiskPoolIscsiTargetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>
    {
        public DiskPoolPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskPoolZoneInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>
    {
        internal DiskPoolZoneInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedDiskIscsiLun : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>
    {
        public ManagedDiskIscsiLun(string name, Azure.Core.ResourceIdentifier managedDiskAzureResourceId) { }
        public int? Lun { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedDiskAzureResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.ManagedDiskIscsiLun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutboundEndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>
    {
        internal OutboundEndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutboundEndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>
    {
        internal OutboundEndpointDetail() { }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public bool? IsAccessible { get { throw null; } }
        public double? LatencyInMs { get { throw null; } }
        public int? Port { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePoolOperationalStatus : System.IEquatable<Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePoolOperationalStatus(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Running { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus StoppedDeallocated { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus left, Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus left, Azure.ResourceManager.StoragePool.Models.StoragePoolOperationalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StoragePoolOutboundEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>
    {
        internal StoragePoolOutboundEnvironment() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.OutboundEndpointDependency> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolOutboundEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>
    {
        public StoragePoolSku(string name) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>
    {
        internal StoragePoolSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolSkuInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>
    {
        internal StoragePoolSkuInfo() { }
        public string ApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo LocationInfo { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>
    {
        internal StoragePoolSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>
    {
        internal StoragePoolSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>
    {
        internal StoragePoolSkuRestrictions() { }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StoragePoolSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum StoragePoolSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class StoragePoolSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>
    {
        internal StoragePoolSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StoragePool.Models.StoragePoolSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
