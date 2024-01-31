namespace Azure.ResourceManager.ResourceMover
{
    public partial class MoverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MoverResource() { }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moverResourceSetName, string moverResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoverResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>, System.Collections.IEnumerable
    {
        protected MoverResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moverResourceName, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moverResourceName, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource> Get(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource>> GetAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceMover.MoverResource> GetIfExists(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceMover.MoverResource>> GetIfExistsAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceMover.MoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceMover.MoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MoverResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.MoverResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceData>
    {
        public MoverResourceData() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.MoverResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.MoverResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.MoverResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.MoverResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>, System.Collections.IEnumerable
    {
        protected MoverResourceSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moverResourceSetName, Azure.ResourceManager.ResourceMover.MoverResourceSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moverResourceSetName, Azure.ResourceManager.ResourceMover.MoverResourceSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> Get(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetAsync(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetIfExists(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetIfExistsAsync(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MoverResourceSetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>
    {
        public MoverResourceSetData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.MoverResourceSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.MoverResourceSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.MoverResourceSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MoverResourceSetResource() { }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> BulkRemove(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> BulkRemoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Commit(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverCommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> CommitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverCommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moverResourceSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Discard(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> DiscardAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource> GetMoverResource(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource>> GetMoverResourceAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceCollection GetMoverResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList> GetRequiredForResources(Azure.Core.ResourceIdentifier sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>> GetRequiredForResourcesAsync(Azure.Core.ResourceIdentifier sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency> GetUnresolvedDependencies(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel? dependencyLevel = default(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency> GetUnresolvedDependenciesAsync(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel? dependencyLevel = default(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> InitiateMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> InitiateMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Prepare(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> PrepareAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> ResolveDependencies(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> ResolveDependenciesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> Update(Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> UpdateAsync(Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceMoverExtensions
    {
        public static Azure.ResourceManager.ResourceMover.MoverResource GetMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetMoverResourceSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceMover.MoverResourceSetResource GetMoverResourceSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceMover.MoverResourceSetCollection GetMoverResourceSets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery> GetOperationsDiscoveries(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery> GetOperationsDiscoveriesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceMover.Mocking
{
    public partial class MockableResourceMoverArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceMoverArmClient() { }
        public virtual Azure.ResourceManager.ResourceMover.MoverResource GetMoverResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceSetResource GetMoverResourceSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourceMoverResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceMoverResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSet(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetMoverResourceSetAsync(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceSetCollection GetMoverResourceSets() { throw null; }
    }
    public partial class MockableResourceMoverSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceMoverSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourceMoverTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceMoverTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery> GetOperationsDiscoveries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery> GetOperationsDiscoveriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceMover.Models
{
    public partial class AffectedMoverResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>
    {
        internal AffectedMoverResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo> MoverResources { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourceMoverModelFactory
    {
        public static Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo AffectedMoverResourceInfo(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier sourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo> moverResources = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo MoverDisplayInfo(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo MoverOperationErrorAdditionalInfo(string operationErrorAdditionalInfoType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo> infoMoverResources = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery MoverOperationsDiscovery(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo display = null, string origin = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus MoverOperationStatus(Azure.Core.ResourceIdentifier id = null, string name = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError error = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError MoverOperationStatusError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError> details = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.MoverResourceData MoverResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency MoverResourceDependency(Azure.Core.ResourceIdentifier id = null, string resolutionStatus = null, Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType? resolutionType = default(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType?), Azure.ResourceManager.ResourceMover.Models.MoverDependencyType? dependencyType = default(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType?), Azure.Core.ResourceIdentifier manualResolutionTargetId = null, Azure.Core.ResourceIdentifier automaticResolutionResourceId = null, bool? isOptional = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus MoverResourceJobStatus(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName? jobName = default(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName?), string jobProgress = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties MoverResourceProperties(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState?), Azure.Core.ResourceIdentifier sourceId = null, Azure.Core.ResourceIdentifier targetId = null, Azure.Core.ResourceIdentifier existingTargetId = null, Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings resourceSettings = null, Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings sourceResourceSettings = null, Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus moveStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride> dependsOnOverrides = null, bool? isResolveRequired = default(bool?), Azure.ResponseError errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus MoverResourcePropertiesMoveStatus(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState? moveState = default(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState?), Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus jobStatus = null, Azure.ResponseError errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.MoverResourceSetData MoverResourceSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties MoverResourceSetProperties(Azure.Core.AzureLocation? sourceLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? targetLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? moveLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState?), string version = null, Azure.ResourceManager.ResourceMover.Models.MoveType? moveType = default(Azure.ResourceManager.ResourceMover.Models.MoveType?), Azure.ResponseError errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus MoverResourceStatus(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState? moveState = default(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState?), Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus jobStatus = null, Azure.ResponseError errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency MoverUnresolvedDependency(int? count = default(int?), Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList RequiredForResourcesList(System.Collections.Generic.IEnumerable<string> sourceIds = null) { throw null; }
    }
    public partial class DiskEncryptionSetResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>
    {
        public DiskEncryptionSetResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public DiskEncryptionSetResourceSettings(string targetResourceName) { }
        Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.DiskEncryptionSetResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>
    {
        public KeyVaultResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public KeyVaultResourceSettings(string targetResourceName) { }
        Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.KeyVaultResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerBackendAddressPoolReferenceInfo : Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>
    {
        public LoadBalancerBackendAddressPoolReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerBackendAddressPoolResourceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>
    {
        public LoadBalancerBackendAddressPoolResourceSettings() { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerFrontendIPConfigurationResourceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>
    {
        public LoadBalancerFrontendIPConfigurationResourceSettings() { }
        public string Name { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo Subnet { get { throw null; } set { } }
        public string Zones { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerNatRuleReferenceInfo : Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>
    {
        public LoadBalancerNatRuleReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>
    {
        public LoadBalancerResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public LoadBalancerResourceSettings(string targetResourceName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings> BackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings> FrontendIPConfigurations { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.LoadBalancerResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverAvailabilitySetResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>
    {
        public MoverAvailabilitySetResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MoverAvailabilitySetResourceSettings(string targetResourceName) { }
        public int? FaultDomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? UpdateDomain { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverAvailabilitySetResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverBulkRemoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>
    {
        public MoverBulkRemoveContent() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverCommitContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>
    {
        public MoverCommitContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverCommitContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverCommitContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverCommitContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverDependencyLevel : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverDependencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel Descendant { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverDependencyType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyType RequiredForMove { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyType RequiredForPrepare { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverDependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverDiscardContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>
    {
        public MoverDiscardContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverDisplayInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>
    {
        internal MoverDisplayInfo() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverOperationErrorAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>
    {
        internal MoverOperationErrorAdditionalInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo> InfoMoverResources { get { throw null; } }
        public string OperationErrorAdditionalInfoType { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverOperationsDiscovery : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>
    {
        internal MoverOperationsDiscovery() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>
    {
        internal MoverOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverOperationStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>
    {
        internal MoverOperationStatusError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError> Details { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverPrepareContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>
    {
        public MoverPrepareContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverProvisioningState : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState left, Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState left, Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>
    {
        internal MoverResourceDependency() { }
        public Azure.Core.ResourceIdentifier AutomaticResolutionResourceId { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverDependencyType? DependencyType { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsOptional { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManualResolutionTargetId { get { throw null; } }
        public string ResolutionStatus { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType? ResolutionType { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceDependencyOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>
    {
        public MoverResourceDependencyOverride() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceInputType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceInputType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType MoverResourceId { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType MoverResourceSourceId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceJobName : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceJobName(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName InitialSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName left, Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName left, Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceJobStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>
    {
        internal MoverResourceJobStatus() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName? JobName { get { throw null; } }
        public string JobProgress { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>
    {
        public MoverResourceMoveContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceMoveState : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState AssignmentPending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState CommitInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState CommitPending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState Committed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState DeleteSourcePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState DiscardFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState DiscardInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState MoveFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState MoveInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState MovePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState PrepareInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState PreparePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState ResourceMoveCompleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState left, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState left, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>
    {
        public MoverResourceProperties(Azure.Core.ResourceIdentifier sourceId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency> DependsOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride> DependsOnOverrides { get { throw null; } }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExistingTargetId { get { throw null; } set { } }
        public bool? IsResolveRequired { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus MoveStatus { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings ResourceSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings SourceResourceSettings { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourcePropertiesMoveStatus : Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>
    {
        internal MoverResourcePropertiesMoveStatus() { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceReferenceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>
    {
        public MoverResourceReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) { }
        public Azure.Core.ResourceIdentifier SourceArmResourceId { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceResolutionType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceResolutionType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceSetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>
    {
        public MoverResourceSetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceSetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>
    {
        public MoverResourceSetProperties() { }
        public MoverResourceSetProperties(Azure.Core.AzureLocation sourceRegion, Azure.Core.AzureLocation targetRegion) { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.Core.AzureLocation? MoveLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoveType? MoveType { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.AzureLocation? SourceLocation { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } set { } }
        public Azure.Core.AzureLocation? TargetLocation { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.AzureLocation TargetRegion { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MoverResourceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>
    {
        protected MoverResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected MoverResourceSettings(string targetResourceName) { }
        public string TargetResourceGroupName { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverResourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>
    {
        internal MoverResourceStatus() { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus JobStatus { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState? MoveState { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverTargetAvailabilityZone : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverTargetAvailabilityZone(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone NA { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone One { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone Three { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone Two { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone left, Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone left, Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverUnresolvedDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>
    {
        internal MoverUnresolvedDependency() { }
        public int? Count { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoverVirtualNetworkResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>
    {
        public MoverVirtualNetworkResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MoverVirtualNetworkResourceSettings(string targetResourceName) { }
        public System.Collections.Generic.IList<string> AddressSpace { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } set { } }
        public bool? EnableDdosProtection { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings> Subnets { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.MoverVirtualNetworkResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoveType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoveType RegionToRegion { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoveType RegionToZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoveType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoveType left, Azure.ResourceManager.ResourceMover.Models.MoveType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoveType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoveType left, Azure.ResourceManager.ResourceMover.Models.MoveType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>
    {
        public NetworkInterfaceResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NetworkInterfaceResourceSettings(string targetResourceName) { }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings> IPConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkInterfaceResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>
    {
        public NetworkSecurityGroupResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NetworkSecurityGroupResourceSettings(string targetResourceName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule> SecurityRules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupSecurityRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>
    {
        public NetworkSecurityGroupSecurityRule() { }
        public string Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DestinationAddressPrefix { get { throw null; } set { } }
        public string DestinationPortRange { get { throw null; } set { } }
        public string Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public string SourcePortRange { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NicIPConfigurationResourceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>
    {
        public NicIPConfigurationResourceSettings() { }
        public bool? IsPrimary { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo> LoadBalancerNatRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPSourceArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo Subnet { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProxyResourceReferenceInfo : Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>
    {
        public ProxyResourceReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicIPAddressResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>
    {
        public PublicIPAddressResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public PublicIPAddressResourceSettings(string targetResourceName) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public string PublicIPAllocationMethod { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.PublicIPAddressResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredForResourcesList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>
    {
        internal RequiredForResourcesList() { }
        public System.Collections.Generic.IReadOnlyList<string> SourceIds { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>
    {
        public ResourceGroupResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ResourceGroupResourceSettings(string targetResourceName) { }
        Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.ResourceGroupResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceZoneRedundantSetting : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceZoneRedundantSetting(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting Disable { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting left, Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting left, Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDatabaseResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>
    {
        public SqlDatabaseResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SqlDatabaseResourceSettings(string targetResourceName) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting? ZoneRedundant { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlDatabaseResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlElasticPoolResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>
    {
        public SqlElasticPoolResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SqlElasticPoolResourceSettings(string targetResourceName) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting? ZoneRedundant { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlElasticPoolResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>
    {
        public SqlServerResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SqlServerResourceSettings(string targetResourceName) { }
        Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SqlServerResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubnetReferenceInfo : Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>
    {
        public SubnetReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
        Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubnetResourceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>
    {
        public SubnetResourceSettings() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupSourceArmResourceId { get { throw null; } set { } }
        Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>
    {
        public VirtualMachineResourceSettings() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VirtualMachineResourceSettings(string targetResourceName) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone? TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> UserManagedIdentities { get { throw null; } }
        Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceMover.Models.VirtualMachineResourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
