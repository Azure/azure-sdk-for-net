namespace Azure.ResourceManager.ResourceGraph
{
    public partial class AzureResourceManagerResourceGraphContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourceGraphContext() { }
        public static Azure.ResourceManager.ResourceGraph.AzureResourceManagerResourceGraphContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ResourceGraphExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetails(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetailsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList> GetResourceChanges(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>> GetResourceChangesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.ResourceGraphQueryCollection GetResourceGraphQueries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQuery(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetResourceGraphQueryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource GetResourceGraphQueryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public static Azure.Response<System.BinaryData> GetResourceHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourceHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult> GetResources(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>> GetResourcesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>> GetResourcesHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>>> GetResourcesHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGraphQueryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>, System.Collections.IEnumerable
    {
        protected ResourceGraphQueryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGraphQueryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>
    {
        public ResourceGraphQueryData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultKind? ResultKind { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGraphQueryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGraphQueryResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> Update(Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> UpdateAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Mocking
{
    public partial class MockableResourceGraphArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphArmClient() { }
        public virtual Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource GetResourceGraphQueryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourceGraphResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphResourceGroupResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.ResourceGraphQueryCollection GetResourceGraphQueries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQuery(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetResourceGraphQueryAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourceGraphSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourceGraphTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetails(Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetailsAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList> GetResourceChanges(Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>> GetResourceChangesAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public virtual Azure.Response<System.BinaryData> GetResourceHistory(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourceHistoryAsync(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult> GetResources(Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>> GetResourcesAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>> GetResourcesHistory(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>>> GetResourcesHistoryAsync(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Models
{
    public static partial class ArmResourceGraphModelFactory
    {
        public static Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval DateTimeInterval(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.Facet Facet(string expression = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetError FacetError(string expression = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails> errors = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails FacetErrorDetails(string code = null, string message = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetRequest FacetRequest(string expression = null, Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions options = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions FacetRequestOptions(string sortBy = null, Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder? sortOrder = default(Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder?), string filter = null, int? top = default(int?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetResult FacetResult(string expression = null, long totalRecords = (long)0, int count = 0, System.BinaryData data = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData ResourceChangeData(string resourceId = null, string changeId = null, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot beforeSnapshot = null, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot afterSnapshot = null, Azure.ResourceManager.ResourceGraph.Models.ChangeType? changeType = default(Azure.ResourceManager.ResourceGraph.Models.ChangeType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange> propertyChanges = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot ResourceChangeDataAfterSnapshot(string snapshotId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot ResourceChangeDataBeforeSnapshot(string snapshotId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters ResourceChangeDetailsRequestParameters(System.Collections.Generic.IEnumerable<string> resourceIds = null, System.Collections.Generic.IEnumerable<string> changeIds = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList ResourceChangeList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> changes = null, System.BinaryData skipToken = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters ResourceChangesRequestParameters(System.Collections.Generic.IEnumerable<string> resourceIds = null, string subscriptionId = null, Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval interval = null, string skipToken = null, int? top = default(int?), string table = null, bool? fetchPropertyChanges = default(bool?), bool? fetchSnapshots = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval ResourceChangesRequestParametersInterval(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData ResourceGraphQueryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string description = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResultKind? resultKind = default(Azure.ResourceManager.ResourceGraph.Models.ResultKind?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch ResourceGraphQueryPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ETag? eTag = default(Azure.ETag?), string description = null, string query = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange ResourcePropertyChange(string propertyName = null, string beforeValue = null, string afterValue = null, Azure.ResourceManager.ResourceGraph.Models.ChangeCategory changeCategory = Azure.ResourceManager.ResourceGraph.Models.ChangeCategory.User, Azure.ResourceManager.ResourceGraph.Models.PropertyChangeType propertyChangeType = Azure.ResourceManager.ResourceGraph.Models.PropertyChangeType.Insert) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent ResourceQueryContent(System.Collections.Generic.IEnumerable<string> subscriptions = null, System.Collections.Generic.IEnumerable<string> managementGroups = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions options = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> facets = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions ResourceQueryRequestOptions(string skipToken = null, int? top = default(int?), int? skip = default(int?), Azure.ResourceManager.ResourceGraph.Models.ResultFormat? resultFormat = default(Azure.ResourceManager.ResourceGraph.Models.ResultFormat?), bool? allowPartialScopes = default(bool?), Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter? authorizationScopeFilter = default(Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult ResourceQueryResult(long totalRecords = (long)0, long count = (long)0, Azure.ResourceManager.ResourceGraph.Models.ResultTruncated resultTruncated = Azure.ResourceManager.ResourceGraph.Models.ResultTruncated.True, string skipToken = null, System.BinaryData data = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.Facet> facets = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest ResourcesHistoryRequest(System.Collections.Generic.IEnumerable<string> subscriptions = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions options = null, System.Collections.Generic.IEnumerable<string> managementGroups = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions ResourcesHistoryRequestOptions(Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval interval = null, int? top = default(int?), int? skip = default(int?), string skipToken = null, Azure.ResourceManager.ResourceGraph.Models.ResultFormat? resultFormat = default(Azure.ResourceManager.ResourceGraph.Models.ResultFormat?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData ResourceSnapshotData(string snapshotId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), System.BinaryData content = null) { throw null; }
    }
    public enum AuthorizationScopeFilter
    {
        AtScopeAndBelow = 0,
        AtScopeAndAbove = 1,
        AtScopeExact = 2,
        AtScopeAboveAndBelow = 3,
    }
    public enum ChangeCategory
    {
        User = 0,
        System = 1,
    }
    public enum ChangeType
    {
        Create = 0,
        Update = 1,
        Delete = 2,
    }
    public partial class DateTimeInterval : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>
    {
        public DateTimeInterval(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Facet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>
    {
        protected Facet(string expression) { }
        public string Expression { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.Facet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.Facet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.Facet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.Facet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetError : Azure.ResourceManager.ResourceGraph.Models.Facet, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>
    {
        internal FacetError() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails> Errors { get { throw null; } }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>
    {
        internal FacetErrorDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>
    {
        public FacetRequest(string expression) { }
        public string Expression { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions Options { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetRequestOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>
    {
        public FacetRequestOptions() { }
        public string Filter { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder? SortOrder { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetResult : Azure.ResourceManager.ResourceGraph.Models.Facet, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>
    {
        internal FacetResult() : base (default(string)) { }
        public int Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public long TotalRecords { get { throw null; } }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FacetSortOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public enum PropertyChangeType
    {
        Insert = 0,
        Update = 1,
        Remove = 2,
    }
    public partial class ResourceChangeData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>
    {
        internal ResourceChangeData() { }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot AfterSnapshot { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot BeforeSnapshot { get { throw null; } }
        public string ChangeId { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ChangeType? ChangeType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange> PropertyChanges { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeDataAfterSnapshot : Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>
    {
        internal ResourceChangeDataAfterSnapshot() { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeDataBeforeSnapshot : Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>
    {
        internal ResourceChangeDataBeforeSnapshot() { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeDetailsRequestParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>
    {
        public ResourceChangeDetailsRequestParameters(System.Collections.Generic.IEnumerable<string> resourceIds, System.Collections.Generic.IEnumerable<string> changeIds) { }
        public System.Collections.Generic.IList<string> ChangeIds { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>
    {
        internal ResourceChangeList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> Changes { get { throw null; } }
        public System.BinaryData SkipToken { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangesRequestParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>
    {
        public ResourceChangesRequestParameters(Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval interval) { }
        public bool? FetchPropertyChanges { get { throw null; } set { } }
        public bool? FetchSnapshots { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval Interval { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangesRequestParametersInterval : Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>
    {
        public ResourceChangesRequestParametersInterval(System.DateTimeOffset startOn, System.DateTimeOffset endOn) : base (default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGraphQueryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>
    {
        public ResourceGraphQueryPatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcePropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>
    {
        internal ResourcePropertyChange() { }
        public string AfterValue { get { throw null; } }
        public string BeforeValue { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ChangeCategory ChangeCategory { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.PropertyChangeType PropertyChangeType { get { throw null; } }
        public string PropertyName { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>
    {
        public ResourceQueryContent(string query) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> Facets { get { throw null; } }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryRequestOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>
    {
        public ResourceQueryRequestOptions() { }
        public bool? AllowPartialScopes { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter? AuthorizationScopeFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>
    {
        internal ResourceQueryResult() { }
        public long Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.Facet> Facets { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultTruncated ResultTruncated { get { throw null; } }
        public string SkipToken { get { throw null; } }
        public long TotalRecords { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>
    {
        public ResourcesHistoryContent() { }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>
    {
        public ResourcesHistoryRequest() { }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryRequestOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>
    {
        public ResourcesHistoryRequestOptions() { }
        public Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval Interval { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSnapshotData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>
    {
        internal ResourceSnapshotData() { }
        public System.BinaryData Content { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResultFormat
    {
        Table = 0,
        ObjectArray = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResultKind : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.ResultKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResultKind(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResultKind Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.ResultKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.ResultKind left, Azure.ResourceManager.ResourceGraph.Models.ResultKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ResultKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ResultKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.ResultKind left, Azure.ResourceManager.ResourceGraph.Models.ResultKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResultTruncated
    {
        True = 0,
        False = 1,
    }
}
