namespace Azure.ResourceManager.OperationalInsights
{
    public partial class AzureResourceManagerOperationalInsightsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerOperationalInsightsContext() { }
        public static Azure.ResourceManager.OperationalInsights.AzureResourceManagerOperationalInsightsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class LogAnalyticsQueryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>, System.Collections.IEnumerable
    {
        protected LogAnalyticsQueryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> GetAll(long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> GetAllAsync(long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> GetIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>> GetIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogAnalyticsQueryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>
    {
        public LogAnalyticsQueryData() { }
        public System.Guid? ApplicationId { get { throw null; } }
        public string Author { get { throw null; } }
        public string Body { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata Related { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQueryPackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>, System.Collections.IEnumerable
    {
        protected LogAnalyticsQueryPackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string queryPackName, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string queryPackName, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> Get(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> GetAsync(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetIfExists(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> GetIfExistsAsync(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogAnalyticsQueryPackData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>
    {
        public LogAnalyticsQueryPackData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? QueryPackId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQueryPackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogAnalyticsQueryPackResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string queryPackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryCollection GetLogAnalyticsQueries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> GetLogAnalyticsQuery(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>> GetLogAnalyticsQueryAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> SearchQueries(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties querySearchProperties, long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> SearchQueriesAsync(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties querySearchProperties, long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> Update(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogAnalyticsQueryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogAnalyticsQueryResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string queryPackName, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> Update(Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>
    {
        public OperationalInsightsClusterData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace> AssociatedWorkspaces { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType? BillingType { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties CapacityReservationProperties { get { throw null; } set { } }
        public System.Guid? ClusterId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAvailabilityZonesEnabled { get { throw null; } set { } }
        public bool? IsDoubleEncryptionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties Replication { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsClusterResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsDataExportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsDataExportCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataExportName, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataExportName, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> Get(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>> GetAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> GetIfExists(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>> GetIfExistsAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsDataExportData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>
    {
        public OperationalInsightsDataExportData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Guid? DataExportId { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType? DestinationType { get { throw null; } }
        public string EventHubName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TableNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsDataExportResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsDataExportResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataExportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsDataSourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected OperationalInsightsDataSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataSourceName, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataSourceName, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> Get(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> GetAll(string filter, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> GetAllAsync(string filter, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> GetAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> GetIfExists(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> GetIfExistsAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsDataSourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>
    {
        public OperationalInsightsDataSourceData(System.BinaryData properties, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind kind) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind Kind { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsDataSourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsDataSourceResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataSourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OperationalInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> CreateOrUpdateWithoutNameQueryPack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> CreateOrUpdateWithoutNameQueryPackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation FailoverWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> GetLogAnalyticsQueryPackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource GetLogAnalyticsQueryPackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackCollection GetLogAnalyticsQueryPacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource GetLogAnalyticsQueryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetOperationalInsightsCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> GetOperationalInsightsClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource GetOperationalInsightsClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterCollection GetOperationalInsightsClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetOperationalInsightsClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetOperationalInsightsClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource GetOperationalInsightsDataExportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource GetOperationalInsightsDataSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource GetOperationalInsightsLinkedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource GetOperationalInsightsLinkedStorageAccountsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource GetOperationalInsightsSavedSearchResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource GetOperationalInsightsTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetOperationalInsightsWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> GetOperationalInsightsWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource GetOperationalInsightsWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceCollection GetOperationalInsightsWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetOperationalInsightsWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetOperationalInsightsWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.StorageInsightResource GetStorageInsightResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class OperationalInsightsLinkedServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsLinkedServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> Get(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> GetAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> GetIfExists(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> GetIfExistsAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsLinkedServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>
    {
        public OperationalInsightsLinkedServiceData() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus? ProvisioningState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier WriteAccessResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsLinkedServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsLinkedServiceResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string linkedServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsLinkedStorageAccountsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsLinkedStorageAccountsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> Get(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>> GetAsync(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> GetIfExists(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>> GetIfExistsAsync(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsLinkedStorageAccountsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>
    {
        public OperationalInsightsLinkedStorageAccountsData() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType? DataSourceType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> StorageAccountIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsLinkedStorageAccountsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsLinkedStorageAccountsResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsSavedSearchCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsSavedSearchCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string savedSearchId, Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string savedSearchId, Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> Get(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>> GetAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> GetIfExists(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>> GetIfExistsAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsSavedSearchData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>
    {
        public OperationalInsightsSavedSearchData(string category, string displayName, string query) { }
        public string Category { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string FunctionAlias { get { throw null; } set { } }
        public string FunctionParameters { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag> Tags { get { throw null; } }
        public long? Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsSavedSearchResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsSavedSearchResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string savedSearchId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsTableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsTableData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>
    {
        public OperationalInsightsTableData() { }
        public int? ArchiveRetentionInDays { get { throw null; } }
        public bool? IsRetentionInDaysAsDefault { get { throw null; } }
        public bool? IsTotalRetentionInDaysAsDefault { get { throw null; } }
        public string LastPlanModifiedDate { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan? Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs RestoredLogs { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics ResultStatistics { get { throw null; } }
        public int? RetentionInDays { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release, please use `IsRetentionInDaysAsDefault` instead", false)]
        public Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState? RetentionInDaysAsDefault { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema Schema { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults SearchResults { get { throw null; } set { } }
        public int? TotalRetentionInDays { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release, please use `IsTotalRetentionInDaysAsDefault` instead", false)]
        public Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState? TotalRetentionInDaysAsDefault { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsTableResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsTableResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelSearch(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSearchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Migrate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MigrateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationalInsightsWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>, System.Collections.IEnumerable
    {
        protected OperationalInsightsWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>
    {
        public OperationalInsightsWorkspaceData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid? CustomerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties Failover { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures Features { get { throw null; } set { } }
        public bool? ForceCmkForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties Replication { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsWorkspaceResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGateway(System.Guid gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGatewayAsync(System.Guid gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableIntelligencePack(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableIntelligencePackAsync(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableIntelligencePack(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableIntelligencePackAsync(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failback(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailbackAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsCollection GetAllOperationalInsightsLinkedStorageAccounts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier> GetAvailableServiceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier> GetAvailableServiceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack> GetIntelligencePacks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack> GetIntelligencePacksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup> GetManagementGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup> GetManagementGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> GetOperationalInsightsDataExport(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>> GetOperationalInsightsDataExportAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportCollection GetOperationalInsightsDataExports() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> GetOperationalInsightsDataSource(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> GetOperationalInsightsDataSourceAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceCollection GetOperationalInsightsDataSources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> GetOperationalInsightsLinkedService(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>> GetOperationalInsightsLinkedServiceAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceCollection GetOperationalInsightsLinkedServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> GetOperationalInsightsLinkedStorageAccounts(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>> GetOperationalInsightsLinkedStorageAccountsAsync(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> GetOperationalInsightsSavedSearch(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>> GetOperationalInsightsSavedSearchAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchCollection GetOperationalInsightsSavedSearches() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> GetOperationalInsightsTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>> GetOperationalInsightsTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsTableCollection GetOperationalInsightsTables() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult> GetPurgeStatus(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>> GetPurgeStatusAsync(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue> GetSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue> GetSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys> GetSharedKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>> GetSharedKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> GetStorageInsight(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> GetStorageInsightAsync(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.StorageInsightCollection GetStorageInsights() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult> Purge(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>> PurgeAsync(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys> RegenerateSharedKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>> RegenerateSharedKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> Update(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageInsightCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.StorageInsightResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.StorageInsightResource>, System.Collections.IEnumerable
    {
        protected StorageInsightCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.StorageInsightResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageInsightName, Azure.ResourceManager.OperationalInsights.StorageInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageInsightName, Azure.ResourceManager.OperationalInsights.StorageInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> Get(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.StorageInsightResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.StorageInsightResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> GetAsync(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.StorageInsightResource> GetIfExists(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> GetIfExistsAsync(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.StorageInsightResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.StorageInsightResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.StorageInsightResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.StorageInsightResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageInsightData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>
    {
        public StorageInsightData() { }
        public System.Collections.Generic.IList<string> Containers { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus Status { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount StorageAccount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tables { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.StorageInsightData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.StorageInsightData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageInsightResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageInsightResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.StorageInsightData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string storageInsightName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OperationalInsights.StorageInsightData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.StorageInsightData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.StorageInsightData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.StorageInsightResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.StorageInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.StorageInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OperationalInsights.Mocking
{
    public partial class MockableOperationalInsightsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableOperationalInsightsArmClient() { }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource GetLogAnalyticsQueryPackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource GetLogAnalyticsQueryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource GetOperationalInsightsClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource GetOperationalInsightsDataExportResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource GetOperationalInsightsDataSourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource GetOperationalInsightsLinkedServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource GetOperationalInsightsLinkedStorageAccountsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource GetOperationalInsightsSavedSearchResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource GetOperationalInsightsTableResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource GetOperationalInsightsWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.StorageInsightResource GetStorageInsightResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableOperationalInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOperationalInsightsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> CreateOrUpdateWithoutNameQueryPack(Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> CreateOrUpdateWithoutNameQueryPackAsync(Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FailoverWorkspace(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverWorkspaceAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPack(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> GetLogAnalyticsQueryPackAsync(string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackCollection GetLogAnalyticsQueryPacks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetOperationalInsightsCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>> GetOperationalInsightsClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterCollection GetOperationalInsightsClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetOperationalInsightsWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>> GetOperationalInsightsWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceCollection GetOperationalInsightsWorkspaces() { throw null; }
    }
    public partial class MockableOperationalInsightsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOperationalInsightsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPacks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPacksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetOperationalInsightsClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> GetOperationalInsightsClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetOperationalInsightsWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> GetOperationalInsightsWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OperationalInsights.Models
{
    public static partial class ArmOperationalInsightsModelFactory
    {
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryData LogAnalyticsQueryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? applicationId = default(System.Guid?), string displayName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string author = null, string description = null, string body = null, Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata related = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> tags = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData LogAnalyticsQueryPackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Guid? queryPackId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier OperationalInsightsAvailableServiceTier(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName? serviceTier = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName?), bool? isEnabled = default(bool?), long? minimumRetention = default(long?), long? maximumRetention = default(long?), long? defaultRetention = default(long?), long? capacityReservationLevel = default(long?), System.DateTimeOffset? lastSkuUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties OperationalInsightsCapacityReservationProperties(System.DateTimeOffset? lastSkuUpdatedOn = default(System.DateTimeOffset?), long? minCapacity = default(long?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace OperationalInsightsClusterAssociatedWorkspace(System.Guid? workspaceId = default(System.Guid?), string workspaceName = null, Azure.Core.ResourceIdentifier resourceId = null, System.DateTimeOffset? associatedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData OperationalInsightsClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku sku, System.Guid? clusterId, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus? provisioningState, bool? isDoubleEncryptionEnabled, bool? isAvailabilityZonesEnabled, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType? billingType, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties keyVaultProperties, System.DateTimeOffset? lastModifiedOn, System.DateTimeOffset? createdOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace> associatedWorkspaces, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties capacityReservationProperties) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterData OperationalInsightsClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku sku = null, System.Guid? clusterId = default(System.Guid?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus?), bool? isDoubleEncryptionEnabled = default(bool?), bool? isAvailabilityZonesEnabled = default(bool?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType? billingType = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties keyVaultProperties = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace> associatedWorkspaces = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties capacityReservationProperties = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties replication = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties OperationalInsightsClusterReplicationProperties(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), bool? isReplicationEnabled = default(bool?), bool? isAvailabilityZonesEnabled = default(bool?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn OperationalInsightsColumn(string name = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType? columnType = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint? dataTypeHint = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint?), string displayName = null, string description = null, bool? isDefaultDisplay = default(bool?), bool? isHidden = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportData OperationalInsightsDataExportData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataExportId = default(System.Guid?), System.Collections.Generic.IEnumerable<string> tableNames = null, bool? isEnabled = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType? destinationType = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType?), string eventHubName = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData OperationalInsightsDataSourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData properties = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind kind = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack OperationalInsightsIntelligencePack(string name = null, bool? isEnabled = default(bool?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceData OperationalInsightsLinkedServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier writeAccessResourceId = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsData OperationalInsightsLinkedStorageAccountsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType? dataSourceType = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> storageAccountIds = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup OperationalInsightsManagementGroup(int? serverCount = default(int?), bool? isGateway = default(bool?), string name = null, string id = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? dataReceivedOn = default(System.DateTimeOffset?), string version = null, string sku = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName OperationalInsightsMetricName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo OperationalInsightsPrivateLinkScopedResourceInfo(Azure.Core.ResourceIdentifier resourceId = null, string scopeId = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchData OperationalInsightsSavedSearchData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string category = null, string displayName = null, string query = null, string functionAlias = null, string functionParameters = null, long? version = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag> tags = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema OperationalInsightsSchema(string name = null, string displayName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn> columns = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn> standardColumns = null, System.Collections.Generic.IEnumerable<string> categories = null, System.Collections.Generic.IEnumerable<string> labels = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator? source = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType? tableType = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType? tableSubType = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType?), System.Collections.Generic.IEnumerable<string> solutions = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue OperationalInsightsSearchSchemaValue(string name = null, string displayName = null, string searchSchemaValueType = null, bool indexed = false, bool stored = false, bool facet = false, System.Collections.Generic.IEnumerable<string> ownerType = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData OperationalInsightsTableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? retentionInDays = default(int?), int? totalRetentionInDays = default(int?), int? archiveRetentionInDays = default(int?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults searchResults = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs restoredLogs = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics resultStatistics = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan? plan = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan?), string lastPlanModifiedDate = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema schema = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState?), Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState? retentionInDaysAsDefault = default(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState?), Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState? totalRetentionInDaysAsDefault = default(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsTableData OperationalInsightsTableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? retentionInDays = default(int?), int? totalRetentionInDays = default(int?), int? archiveRetentionInDays = default(int?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults searchResults = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs restoredLogs = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics resultStatistics = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan? plan = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan?), string lastPlanModifiedDate = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema schema = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState?), bool? isRetentionInDaysAsDefault = default(bool?), bool? isTotalRetentionInDaysAsDefault = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs OperationalInsightsTableRestoredLogs(System.DateTimeOffset? startRestoreOn = default(System.DateTimeOffset?), System.DateTimeOffset? endRestoreOn = default(System.DateTimeOffset?), string sourceTable = null, System.Guid? azureAsyncOperationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics OperationalInsightsTableResultStatistics(float? progress = default(float?), int? ingestedRecords = default(int?), float? scannedGB = default(float?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults OperationalInsightsTableSearchResults(string query = null, string description = null, int? limit = default(int?), System.DateTimeOffset? startSearchOn = default(System.DateTimeOffset?), System.DateTimeOffset? endSearchOn = default(System.DateTimeOffset?), string sourceTable = null, System.Guid? azureAsyncOperationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric OperationalInsightsUsageMetric(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName name = null, string unit = null, double? currentValue = default(double?), double? limit = default(double?), System.DateTimeOffset? nextResetOn = default(System.DateTimeOffset?), string quotaPeriod = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping OperationalInsightsWorkspaceCapping(double? dailyQuotaInGB = default(double?), string quotaNextResetTime = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus? dataIngestionStatus = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData OperationalInsightsWorkspaceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ETag? etag, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? provisioningState, System.Guid? customerId, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku sku, int? retentionInDays, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping workspaceCapping, System.DateTimeOffset? createdOn, System.DateTimeOffset? modifiedOn, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForIngestion, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForQuery, bool? forceCmkForQuery, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> privateLinkScopedResources, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures features, Azure.Core.ResourceIdentifier defaultDataCollectionRuleResourceId) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData OperationalInsightsWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus?), System.Guid? customerId = default(System.Guid?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku sku = null, int? retentionInDays = default(int?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping workspaceCapping = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForIngestion = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForQuery = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType?), bool? forceCmkForQuery = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> privateLinkScopedResources = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures features = null, Azure.Core.ResourceIdentifier defaultDataCollectionRuleResourceId = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties replication = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties failover = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties OperationalInsightsWorkspaceFailoverProperties(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState? state = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures OperationalInsightsWorkspaceFeatures(bool? isDataExportEnabled = default(bool?), bool? immediatePurgeDataOn30Days = default(bool?), bool? isLogAccessUsingOnlyResourcePermissionsEnabled = default(bool?), Azure.Core.ResourceIdentifier clusterResourceId = null, bool? isLocalAuthDisabled = default(bool?), bool? isUnifiedSentinelBillingOnly = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch OperationalInsightsWorkspacePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus?), System.Guid? customerId = default(System.Guid?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku sku = null, int? retentionInDays = default(int?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping workspaceCapping = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForIngestion = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForQuery = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType?), bool? forceCmkForQuery = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> privateLinkScopedResources = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures features = null, Azure.Core.ResourceIdentifier defaultDataCollectionRuleResourceId = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties replication = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties failover = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch OperationalInsightsWorkspacePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Models.ManagedServiceIdentity identity, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? provisioningState, System.Guid? customerId, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku sku, int? retentionInDays, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping workspaceCapping, System.DateTimeOffset? createdOn, System.DateTimeOffset? modifiedOn, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForIngestion, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? publicNetworkAccessForQuery, bool? forceCmkForQuery, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> privateLinkScopedResources, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures features, Azure.Core.ResourceIdentifier defaultDataCollectionRuleResourceId, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult OperationalInsightsWorkspacePurgeResult(string operationStringId = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult OperationalInsightsWorkspacePurgeStatusResult(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState status = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties OperationalInsightsWorkspaceReplicationProperties(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), bool? isReplicationEnabled = default(bool?), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState? provisioningState = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys OperationalInsightsWorkspaceSharedKeys(string primarySharedKey = null, string secondarySharedKey = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku OperationalInsightsWorkspaceSku(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName name = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName), Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapacityReservationLevel? capacityReservationLevel = default(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapacityReservationLevel?), System.DateTimeOffset? lastSkuUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.StorageInsightData StorageInsightData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> containers = null, System.Collections.Generic.IEnumerable<string> tables = null, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount storageAccount = null, Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus status = null) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus StorageInsightStatus(Azure.ResourceManager.OperationalInsights.Models.StorageInsightState state = default(Azure.ResourceManager.OperationalInsights.Models.StorageInsightState), string description = null) { throw null; }
    }
    public partial class LogAnalyticsQueryPackPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>
    {
        public LogAnalyticsQueryPackPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQueryRelatedMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>
    {
        public LogAnalyticsQueryRelatedMetadata() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Solutions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryRelatedMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQuerySearchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>
    {
        public LogAnalyticsQuerySearchProperties() { }
        public Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata Related { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQuerySearchRelatedMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>
    {
        public LogAnalyticsQuerySearchRelatedMetadata() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Solutions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsAvailableServiceTier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>
    {
        internal OperationalInsightsAvailableServiceTier() { }
        public long? CapacityReservationLevel { get { throw null; } }
        public long? DefaultRetention { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.DateTimeOffset? LastSkuUpdatedOn { get { throw null; } }
        public long? MaximumRetention { get { throw null; } }
        public long? MinimumRetention { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName? ServiceTier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsAvailableServiceTier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsBillingType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsBillingType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType Cluster { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType Workspaces { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsCapacityReservationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>
    {
        public OperationalInsightsCapacityReservationProperties() { }
        public System.DateTimeOffset? LastSkuUpdatedOn { get { throw null; } }
        public long? MinCapacity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsCapacityReservationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsClusterAssociatedWorkspace : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>
    {
        public OperationalInsightsClusterAssociatedWorkspace() { }
        public System.DateTimeOffset? AssociatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Guid? WorkspaceId { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterAssociatedWorkspace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OperationalInsightsClusterCapacity
    {
        FiveHundred = 0,
        TenHundred = 1,
        TwoThousand = 2,
        FiveThousand = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsClusterEntityStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsClusterEntityStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus ProvisioningAccount { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterEntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>
    {
        public OperationalInsightsClusterPatch() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType? BillingType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsClusterReplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>
    {
        public OperationalInsightsClusterReplicationProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsAvailabilityZonesEnabled { get { throw null; } set { } }
        public bool? IsReplicationEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsClusterReplicationState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsClusterReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState DisableRequested { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState Disabling { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState EnableRequested { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState Enabling { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState RollbackRequested { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState RollingBack { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsClusterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>
    {
        public OperationalInsightsClusterSku() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterCapacity? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName? Name { get { throw null; } set { } }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsClusterSkuName : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName CapacityReservation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>
    {
        public OperationalInsightsColumn() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType? ColumnType { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint? DataTypeHint { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsDefaultDisplay { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsColumnDataTypeHint : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsColumnDataTypeHint(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint ArmPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint Guid { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint IP { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsColumnType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsColumnType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType Boolean { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType DateTime { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType Dynamic { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType Guid { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType Int { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType Long { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType Real { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsDataExportDestinationType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsDataExportDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType EventHub { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType StorageAccount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataExportDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsDataIngestionStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsDataIngestionStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus ApproachingQuota { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus ForceOff { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus ForceOn { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus OverQuota { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus RespectQuota { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus SubscriptionSuspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsDataSourceKind : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsDataSourceKind(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind AzureActivityLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind AzureAuditLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingContentLocation { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingCustomPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingDataTypeConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingDefaultRegistry { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingLinuxPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingRegistry { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ChangeTrackingServices { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind CustomLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind CustomLogCollection { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind DnsAnalytics { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind IISLogs { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind ImportComputerGroup { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind Itsm { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind LinuxChangeTrackingPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind LinuxPerformanceCollection { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind LinuxPerformanceObject { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind LinuxSyslog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind LinuxSyslogCollection { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind NetworkMonitoring { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind Office365 { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind SecurityCenterSecurityWindowsBaselineConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind SecurityEventCollectionConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind SecurityInsightsSecurityEventCollectionConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind SecurityWindowsBaselineConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind SqlDataClassification { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind WindowsEvent { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind WindowsPerformanceCounter { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind WindowsTelemetry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperationalInsightsDataSourceType
    {
        CustomLogs = 0,
        AzureWatson = 1,
        Query = 2,
        Ingestion = 3,
        Alerts = 4,
    }
    public partial class OperationalInsightsIntelligencePack : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>
    {
        internal OperationalInsightsIntelligencePack() { }
        public string DisplayName { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsIntelligencePack>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>
    {
        public OperationalInsightsKeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public int? KeyRsaSize { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsLinkedServiceEntityStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsLinkedServiceEntityStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus ProvisioningAccount { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsManagementGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>
    {
        internal OperationalInsightsManagementGroup() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DataReceivedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsGateway { get { throw null; } }
        public string Name { get { throw null; } }
        public int? ServerCount { get { throw null; } }
        public string Sku { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsManagementGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsMetricName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>
    {
        internal OperationalInsightsMetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsPrivateLinkScopedResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>
    {
        internal OperationalInsightsPrivateLinkScopedResourceInfo() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ScopeId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsPublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsPublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsSchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>
    {
        public OperationalInsightsSchema() { }
        public System.Collections.Generic.IReadOnlyList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn> Columns { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Solutions { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator? Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumn> StandardColumns { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType? TableSubType { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType? TableType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsSearchSchemaValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>
    {
        internal OperationalInsightsSearchSchemaValue() { }
        public string DisplayName { get { throw null; } }
        public bool Facet { get { throw null; } }
        public bool Indexed { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OwnerType { get { throw null; } }
        public string SearchSchemaValueType { get { throw null; } }
        public bool Stored { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSearchSchemaValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsSkuName : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsSkuName(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName CapacityReservation { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName PerGB2018 { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName PerNode { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName Standalone { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsStorageAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>
    {
        public OperationalInsightsStorageAccount(Azure.Core.ResourceIdentifier id, string key) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsTableCreator : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsTableCreator(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator Customer { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableCreator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsTablePlan : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsTablePlan(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan Analytics { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsTableProvisioningState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsTableProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsTableRestoredLogs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>
    {
        public OperationalInsightsTableRestoredLogs() { }
        public System.Guid? AzureAsyncOperationId { get { throw null; } }
        public System.DateTimeOffset? EndRestoreOn { get { throw null; } set { } }
        public string SourceTable { get { throw null; } set { } }
        public System.DateTimeOffset? StartRestoreOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsTableResultStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>
    {
        internal OperationalInsightsTableResultStatistics() { }
        public int? IngestedRecords { get { throw null; } }
        public float? Progress { get { throw null; } }
        public float? ScannedGB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsTableSearchResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>
    {
        public OperationalInsightsTableSearchResults() { }
        public System.Guid? AzureAsyncOperationId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndSearchOn { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string SourceTable { get { throw null; } }
        public System.DateTimeOffset? StartSearchOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsTableSubType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsTableSubType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType Any { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType Classic { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType DataCollectionRuleBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSubType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsTableType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsTableType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType CustomLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType Microsoft { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType RestoredLogs { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType SearchResults { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>
    {
        public OperationalInsightsTag(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsUsageMetric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>
    {
        internal OperationalInsightsUsageMetric() { }
        public double? CurrentValue { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsUsageMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OperationalInsightsWorkspaceCapacityReservationLevel
    {
        OneHundred = 100,
        TwoHundred = 200,
        ThreeHundred = 300,
        FourHundred = 400,
        FiveHundred = 500,
        TenHundred = 1000,
        TwoThousand = 2000,
        FiveThousand = 5000,
        TenThousand = 10000,
        TwentyFiveThousand = 25000,
        FiftyThousand = 50000,
    }
    public partial class OperationalInsightsWorkspaceCapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>
    {
        public OperationalInsightsWorkspaceCapping() { }
        public double? DailyQuotaInGB { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus? DataIngestionStatus { get { throw null; } }
        public string QuotaNextResetTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsWorkspaceEntityStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsWorkspaceEntityStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus ProvisioningAccount { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsWorkspaceFailoverProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>
    {
        public OperationalInsightsWorkspaceFailoverProperties() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsWorkspaceFailoverState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsWorkspaceFailoverState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState Activating { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState Active { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState Deactivating { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsWorkspaceFeatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>
    {
        public OperationalInsightsWorkspaceFeatures() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public bool? ImmediatePurgeDataOn30Days { get { throw null; } set { } }
        public bool? IsDataExportEnabled { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsLogAccessUsingOnlyResourcePermissionsEnabled { get { throw null; } set { } }
        public bool? IsUnifiedSentinelBillingOnly { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspacePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>
    {
        public OperationalInsightsWorkspacePatch() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid? CustomerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFailoverProperties Failover { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures Features { get { throw null; } set { } }
        public bool? ForceCmkForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties Replication { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspacePurgeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>
    {
        public OperationalInsightsWorkspacePurgeContent(string table, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter> filters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter> Filters { get { throw null; } }
        public string Table { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspacePurgeFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>
    {
        public OperationalInsightsWorkspacePurgeFilter() { }
        public string Column { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspacePurgeResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>
    {
        internal OperationalInsightsWorkspacePurgeResult() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public System.Guid OperationId { get { throw null; } }
        public string OperationStringId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsWorkspacePurgeState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsWorkspacePurgeState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState Completed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsWorkspacePurgeStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>
    {
        internal OperationalInsightsWorkspacePurgeStatusResult() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspaceReplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>
    {
        public OperationalInsightsWorkspaceReplicationProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsReplicationEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsWorkspaceReplicationState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsWorkspaceReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState DisableRequested { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState Disabling { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState EnableRequested { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState Enabling { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState RollbackRequested { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState RollingBack { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationalInsightsWorkspaceSharedKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>
    {
        internal OperationalInsightsWorkspaceSharedKeys() { }
        public string PrimarySharedKey { get { throw null; } }
        public string SecondarySharedKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSharedKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalInsightsWorkspaceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>
    {
        public OperationalInsightsWorkspaceSku(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName name) { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapacityReservationLevel? CapacityReservationLevel { get { throw null; } set { } }
        public System.DateTimeOffset? LastSkuUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalInsightsWorkspaceSkuName : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalInsightsWorkspaceSkuName(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName CapacityReservation { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName LACluster { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName PerGB2018 { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName PerNode { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName Standalone { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName left, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionInDaysAsDefaultState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionInDaysAsDefaultState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState False { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState left, Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState left, Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageInsightState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.StorageInsightState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageInsightState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.StorageInsightState Error { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.StorageInsightState OK { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.StorageInsightState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.StorageInsightState left, Azure.ResourceManager.OperationalInsights.Models.StorageInsightState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.StorageInsightState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.StorageInsightState left, Azure.ResourceManager.OperationalInsights.Models.StorageInsightState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageInsightStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>
    {
        internal StorageInsightStatus() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.StorageInsightState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TotalRetentionInDaysAsDefaultState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TotalRetentionInDaysAsDefaultState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState False { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState left, Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState left, Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
