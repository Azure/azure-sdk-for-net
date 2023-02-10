namespace Azure.ResourceManager.OperationalInsights
{
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogAnalyticsQueryData : Azure.ResourceManager.Models.ResourceData
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogAnalyticsQueryPackData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogAnalyticsQueryPackData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? QueryPackId { get { throw null; } }
    }
    public partial class LogAnalyticsQueryPackResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> Update(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogAnalyticsQueryResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OperationalInsightsClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku Sku { get { throw null; } set { } }
    }
    public partial class OperationalInsightsClusterResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataExportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsDataExportData : Azure.ResourceManager.Models.ResourceData
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
    }
    public partial class OperationalInsightsDataExportResource : Azure.ResourceManager.ArmResource
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
    }
    public partial class OperationalInsightsDataSourceData : Azure.ResourceManager.Models.ResourceData
    {
        public OperationalInsightsDataSourceData(System.BinaryData properties, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind kind) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceKind Kind { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OperationalInsightsDataSourceResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.OperationalInsightsDataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OperationalInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> CreateOrUpdateWithoutNameQueryPack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> CreateOrUpdateWithoutNameQueryPackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsLinkedServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public OperationalInsightsLinkedServiceData() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsLinkedServiceEntityStatus? ProvisioningState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier WriteAccessResourceId { get { throw null; } set { } }
    }
    public partial class OperationalInsightsLinkedServiceResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsLinkedStorageAccountsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsLinkedStorageAccountsData : Azure.ResourceManager.Models.ResourceData
    {
        public OperationalInsightsLinkedStorageAccountsData() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataSourceType? DataSourceType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> StorageAccountIds { get { throw null; } }
    }
    public partial class OperationalInsightsLinkedStorageAccountsResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsSavedSearchResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsSavedSearchData : Azure.ResourceManager.Models.ResourceData
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
    }
    public partial class OperationalInsightsSavedSearchResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsTableData : Azure.ResourceManager.Models.ResourceData
    {
        public OperationalInsightsTableData() { }
        public int? ArchiveRetentionInDays { get { throw null; } }
        public string LastPlanModifiedDate { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTablePlan? Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableRestoredLogs RestoredLogs { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableResultStatistics ResultStatistics { get { throw null; } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefaultState? RetentionInDaysAsDefault { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSchema Schema { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsTableSearchResults SearchResults { get { throw null; } set { } }
        public int? TotalRetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefaultState? TotalRetentionInDaysAsDefault { get { throw null; } }
    }
    public partial class OperationalInsightsTableResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationalInsightsWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OperationalInsightsWorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid? CustomerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures Features { get { throw null; } set { } }
        public bool? ForceCmkForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
    }
    public partial class OperationalInsightsWorkspaceResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.StorageInsightResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.StorageInsightResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.StorageInsightResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.StorageInsightResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageInsightData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageInsightData() { }
        public System.Collections.Generic.IList<string> Containers { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.StorageInsightStatus Status { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsStorageAccount StorageAccount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tables { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class StorageInsightResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.StorageInsightResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.StorageInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.StorageInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OperationalInsights.Models
{
    public partial class LogAnalyticsQueryPackPatch
    {
        public LogAnalyticsQueryPackPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogAnalyticsQueryRelatedMetadata
    {
        public LogAnalyticsQueryRelatedMetadata() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Solutions { get { throw null; } }
    }
    public partial class LogAnalyticsQuerySearchProperties
    {
        public LogAnalyticsQuerySearchProperties() { }
        public Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQuerySearchRelatedMetadata Related { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
    }
    public partial class LogAnalyticsQuerySearchRelatedMetadata
    {
        public LogAnalyticsQuerySearchRelatedMetadata() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Solutions { get { throw null; } }
    }
    public partial class OperationalInsightsAvailableServiceTier
    {
        internal OperationalInsightsAvailableServiceTier() { }
        public long? CapacityReservationLevel { get { throw null; } }
        public long? DefaultRetention { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.DateTimeOffset? LastSkuUpdatedOn { get { throw null; } }
        public long? MaximumRetention { get { throw null; } }
        public long? MinimumRetention { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsSkuName? ServiceTier { get { throw null; } }
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
    public partial class OperationalInsightsCapacityReservationProperties
    {
        public OperationalInsightsCapacityReservationProperties() { }
        public System.DateTimeOffset? LastSkuUpdatedOn { get { throw null; } }
        public long? MinCapacity { get { throw null; } }
    }
    public partial class OperationalInsightsClusterAssociatedWorkspace
    {
        public OperationalInsightsClusterAssociatedWorkspace() { }
        public System.DateTimeOffset? AssociatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Guid? WorkspaceId { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
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
    public partial class OperationalInsightsClusterPatch
    {
        public OperationalInsightsClusterPatch() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsBillingType? BillingType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OperationalInsightsClusterSku
    {
        public OperationalInsightsClusterSku() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterCapacity? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsClusterSkuName? Name { get { throw null; } set { } }
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
    public partial class OperationalInsightsColumn
    {
        public OperationalInsightsColumn() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnType? ColumnType { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsColumnDataTypeHint? DataTypeHint { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsDefaultDisplay { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public string Name { get { throw null; } set { } }
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
    public partial class OperationalInsightsIntelligencePack
    {
        internal OperationalInsightsIntelligencePack() { }
        public string DisplayName { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationalInsightsKeyVaultProperties
    {
        public OperationalInsightsKeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public int? KeyRsaSize { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
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
    public partial class OperationalInsightsManagementGroup
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
    }
    public partial class OperationalInsightsMetricName
    {
        internal OperationalInsightsMetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class OperationalInsightsPrivateLinkScopedResourceInfo
    {
        internal OperationalInsightsPrivateLinkScopedResourceInfo() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ScopeId { get { throw null; } }
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
    public partial class OperationalInsightsSchema
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
    }
    public partial class OperationalInsightsSearchSchemaValue
    {
        internal OperationalInsightsSearchSchemaValue() { }
        public string DisplayName { get { throw null; } }
        public bool Facet { get { throw null; } }
        public bool Indexed { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OwnerType { get { throw null; } }
        public string SearchSchemaValueType { get { throw null; } }
        public bool Stored { get { throw null; } }
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
    public partial class OperationalInsightsStorageAccount
    {
        public OperationalInsightsStorageAccount(Azure.Core.ResourceIdentifier id, string key) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
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
    public partial class OperationalInsightsTableRestoredLogs
    {
        public OperationalInsightsTableRestoredLogs() { }
        public System.Guid? AzureAsyncOperationId { get { throw null; } }
        public System.DateTimeOffset? EndRestoreOn { get { throw null; } set { } }
        public string SourceTable { get { throw null; } set { } }
        public System.DateTimeOffset? StartRestoreOn { get { throw null; } set { } }
    }
    public partial class OperationalInsightsTableResultStatistics
    {
        internal OperationalInsightsTableResultStatistics() { }
        public int? IngestedRecords { get { throw null; } }
        public float? Progress { get { throw null; } }
        public float? ScannedGB { get { throw null; } }
    }
    public partial class OperationalInsightsTableSearchResults
    {
        public OperationalInsightsTableSearchResults() { }
        public System.Guid? AzureAsyncOperationId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndSearchOn { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string SourceTable { get { throw null; } }
        public System.DateTimeOffset? StartSearchOn { get { throw null; } set { } }
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
    public partial class OperationalInsightsTag
    {
        public OperationalInsightsTag(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class OperationalInsightsUsageMetric
    {
        internal OperationalInsightsUsageMetric() { }
        public double? CurrentValue { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsMetricName Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public string Unit { get { throw null; } }
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
    }
    public partial class OperationalInsightsWorkspaceCapping
    {
        public OperationalInsightsWorkspaceCapping() { }
        public double? DailyQuotaInGB { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsDataIngestionStatus? DataIngestionStatus { get { throw null; } }
        public string QuotaNextResetTime { get { throw null; } }
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
    public partial class OperationalInsightsWorkspaceFeatures
    {
        public OperationalInsightsWorkspaceFeatures() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public bool? ImmediatePurgeDataOn30Days { get { throw null; } set { } }
        public bool? IsDataExportEnabled { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsLogAccessUsingOnlyResourcePermissionsEnabled { get { throw null; } set { } }
    }
    public partial class OperationalInsightsWorkspacePatch : Azure.ResourceManager.Models.ResourceData
    {
        public OperationalInsightsWorkspacePatch() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid? CustomerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceFeatures Features { get { throw null; } set { } }
        public bool? ForceCmkForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsPublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
    }
    public partial class OperationalInsightsWorkspacePurgeContent
    {
        public OperationalInsightsWorkspacePurgeContent(string table, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter> filters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeFilter> Filters { get { throw null; } }
        public string Table { get { throw null; } }
    }
    public partial class OperationalInsightsWorkspacePurgeFilter
    {
        public OperationalInsightsWorkspacePurgeFilter() { }
        public string Column { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class OperationalInsightsWorkspacePurgeResult
    {
        internal OperationalInsightsWorkspacePurgeResult() { }
        public System.Guid OperationId { get { throw null; } }
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
    public partial class OperationalInsightsWorkspacePurgeStatusResult
    {
        internal OperationalInsightsWorkspacePurgeStatusResult() { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspacePurgeState Status { get { throw null; } }
    }
    public partial class OperationalInsightsWorkspaceSharedKeys
    {
        internal OperationalInsightsWorkspaceSharedKeys() { }
        public string PrimarySharedKey { get { throw null; } }
        public string SecondarySharedKey { get { throw null; } }
    }
    public partial class OperationalInsightsWorkspaceSku
    {
        public OperationalInsightsWorkspaceSku(Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName name) { }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceCapacityReservationLevel? CapacityReservationLevel { get { throw null; } set { } }
        public System.DateTimeOffset? LastSkuUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSkuName Name { get { throw null; } set { } }
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
    public partial class StorageInsightStatus
    {
        internal StorageInsightStatus() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.StorageInsightState State { get { throw null; } }
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
