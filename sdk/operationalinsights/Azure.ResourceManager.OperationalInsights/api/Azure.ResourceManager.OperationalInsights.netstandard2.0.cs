namespace Azure.ResourceManager.OperationalInsights
{
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.OperationalInsights.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.OperationalInsights.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.AssociatedWorkspace> AssociatedWorkspaces { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.BillingType? BillingType { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.CapacityReservationProperties CapacityReservationProperties { get { throw null; } set { } }
        public string ClusterId { get { throw null; } }
        public string CreatedDate { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAvailabilityZonesEnabled { get { throw null; } set { } }
        public bool? IsDoubleEncryptionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public string LastModifiedDate { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.ClusterSku Sku { get { throw null; } set { } }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataExportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.DataExportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.DataExportResource>, System.Collections.IEnumerable
    {
        protected DataExportCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataExportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataExportName, Azure.ResourceManager.OperationalInsights.DataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataExportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataExportName, Azure.ResourceManager.OperationalInsights.DataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataExportResource> Get(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.DataExportResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.DataExportResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataExportResource>> GetAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.DataExportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.DataExportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.DataExportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.DataExportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataExportData : Azure.ResourceManager.Models.ResourceData
    {
        public DataExportData() { }
        public string CreatedDate { get { throw null; } set { } }
        public string DataExportId { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string LastModifiedDate { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TableNames { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.Type? TypePropertiesDestinationType { get { throw null; } }
    }
    public partial class DataExportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataExportResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.DataExportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataExportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataExportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataExportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataExportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.DataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataExportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.DataExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataSourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected DataSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataSourceName, Azure.ResourceManager.OperationalInsights.DataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataSourceName, Azure.ResourceManager.OperationalInsights.DataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource> Get(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.DataSourceResource> GetAll(string filter, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.DataSourceResource> GetAllAsync(string filter, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource>> GetAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataSourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DataSourceData(System.BinaryData properties, Azure.ResourceManager.OperationalInsights.Models.DataSourceKind kind) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.DataSourceKind Kind { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataSourceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataSourceResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.DataSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataSourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataSourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.DataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.DataSourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.DataSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>, System.Collections.IEnumerable
    {
        protected LinkedServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.OperationalInsights.LinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServiceName, Azure.ResourceManager.OperationalInsights.LinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> Get(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> GetAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkedServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public LinkedServiceData() { }
        public Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus? ProvisioningState { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string WriteAccessResourceId { get { throw null; } set { } }
    }
    public partial class LinkedServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkedServiceResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.LinkedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string linkedServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.LinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.LinkedServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedStorageAccountsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkedStorageAccountsResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkedStorageAccountsResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>, System.Collections.IEnumerable
    {
        protected LinkedStorageAccountsResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> Get(Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>> GetAsync(Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkedStorageAccountsResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LinkedStorageAccountsResourceData() { }
        public Azure.ResourceManager.OperationalInsights.Models.DataSourceType? DataSourceType { get { throw null; } }
        public System.Collections.Generic.IList<string> StorageAccountIds { get { throw null; } }
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
        public string ProvisioningState { get { throw null; } }
        public string QueryPackId { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeModified { get { throw null; } }
    }
    public partial class LogAnalyticsQueryPackQueryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>, System.Collections.IEnumerable
    {
        protected LogAnalyticsQueryPackQueryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> GetAll(long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> GetAllAsync(long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogAnalyticsQueryPackQueryData : Azure.ResourceManager.Models.ResourceData
    {
        public LogAnalyticsQueryPackQueryData() { }
        public string Author { get { throw null; } }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackQueryPropertiesRelated Related { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeModified { get { throw null; } }
    }
    public partial class LogAnalyticsQueryPackQueryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogAnalyticsQueryPackQueryResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string queryPackName, string id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> Update(Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryCollection GetLogAnalyticsQueryPackQueries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> GetLogAnalyticsQueryPackQuery(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource>> GetLogAnalyticsQueryPackQueryAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> SearchQueries(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackQuerySearchProperties querySearchProperties, long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource> SearchQueriesAsync(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackQuerySearchProperties querySearchProperties, long? top = default(long?), bool? includeBody = default(bool?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> Update(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OperationalInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> CreateOrUpdateWithoutNameQueryPack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> CreateOrUpdateWithoutNameQueryPackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.DataExportResource GetDataExportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.DataSourceResource GetDataSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LinkedServiceResource GetLinkedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource GetLinkedStorageAccountsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource>> GetLogAnalyticsQueryPackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string queryPackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackQueryResource GetLogAnalyticsQueryPackQueryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource GetLogAnalyticsQueryPackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackCollection GetLogAnalyticsQueryPacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.LogAnalyticsQueryPackResource> GetLogAnalyticsQueryPacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.SavedSearchResource GetSavedSearchResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.StorageInsightResource GetStorageInsightResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.TableResource GetTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspacesByDeletedWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspacesByDeletedWorkspace(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspacesByDeletedWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetWorkspacesByDeletedWorkspaceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SavedSearchCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.SavedSearchResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.SavedSearchResource>, System.Collections.IEnumerable
    {
        protected SavedSearchCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.SavedSearchResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string savedSearchId, Azure.ResourceManager.OperationalInsights.SavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.SavedSearchResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string savedSearchId, Azure.ResourceManager.OperationalInsights.SavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.SavedSearchResource> Get(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.SavedSearchResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.SavedSearchResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.SavedSearchResource>> GetAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.SavedSearchResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.SavedSearchResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.SavedSearchResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.SavedSearchResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SavedSearchData : Azure.ResourceManager.Models.ResourceData
    {
        public SavedSearchData(string category, string displayName, string query) { }
        public string Category { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string FunctionAlias { get { throw null; } set { } }
        public string FunctionParameters { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.Tag> Tags { get { throw null; } }
        public long? Version { get { throw null; } set { } }
    }
    public partial class SavedSearchResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SavedSearchResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.SavedSearchData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string savedSearchId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.SavedSearchResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.SavedSearchResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.SavedSearchResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.SavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.SavedSearchResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.SavedSearchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.OperationalInsights.Models.StorageAccount StorageAccount { get { throw null; } set { } }
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
    public partial class TableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.TableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.TableResource>, System.Collections.IEnumerable
    {
        protected TableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.TableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.OperationalInsights.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.TableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.OperationalInsights.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.TableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.TableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.TableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.TableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.TableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.TableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.TableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.TableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TableData : Azure.ResourceManager.Models.ResourceData
    {
        public TableData() { }
        public int? ArchiveRetentionInDays { get { throw null; } }
        public string LastPlanModifiedDate { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum? Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.RestoredLogs RestoredLogs { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.ResultStatistics ResultStatistics { get { throw null; } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault? RetentionInDaysAsDefault { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.Schema Schema { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.SearchResults SearchResults { get { throw null; } set { } }
        public int? TotalRetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault? TotalRetentionInDaysAsDefault { get { throw null; } }
    }
    public partial class TableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TableResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.TableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelSearch(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSearchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.TableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.TableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Migrate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MigrateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.TableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.TableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OperationalInsights.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OperationalInsights.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OperationalInsights.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.WorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OperationalInsights.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OperationalInsights.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OperationalInsights.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string CreatedDate { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public string DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceFeatures Features { get { throw null; } set { } }
        public bool? ForceCmkForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ModifiedDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.PrivateLinkScopedResource> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.OperationalInsights.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGateway(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGatewayAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableIntelligencePack(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableIntelligencePackAsync(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableIntelligencePack(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableIntelligencePackAsync(string intelligencePackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.AvailableServiceTier> GetAvailableServiceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.AvailableServiceTier> GetAvailableServiceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataExportResource> GetDataExport(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataExportResource>> GetDataExportAsync(string dataExportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.DataExportCollection GetDataExports() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource> GetDataSource(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.DataSourceResource>> GetDataSourceAsync(string dataSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.DataSourceCollection GetDataSources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.IntelligencePack> GetIntelligencePacks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.IntelligencePack> GetIntelligencePacksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource> GetLinkedService(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedServiceResource>> GetLinkedServiceAsync(string linkedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.LinkedServiceCollection GetLinkedServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource> GetLinkedStorageAccountsResource(Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResource>> GetLinkedStorageAccountsResourceAsync(Azure.ResourceManager.OperationalInsights.Models.DataSourceType dataSourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.LinkedStorageAccountsResourceCollection GetLinkedStorageAccountsResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.ManagementGroup> GetManagementGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.ManagementGroup> GetManagementGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeStatusResponse> GetPurgeStatusWorkspacePurge(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeStatusResponse>> GetPurgeStatusWorkspacePurgeAsync(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.SavedSearchResource> GetSavedSearch(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.SavedSearchResource>> GetSavedSearchAsync(string savedSearchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.SavedSearchCollection GetSavedSearches() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.SearchSchemaValue> GetSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.SearchSchemaValue> GetSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.SharedKeys> GetSharedKeysSharedKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.SharedKeys>> GetSharedKeysSharedKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource> GetStorageInsight(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.StorageInsightResource>> GetStorageInsightAsync(string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.StorageInsightCollection GetStorageInsights() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.TableResource> GetTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.TableResource>> GetTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OperationalInsights.TableCollection GetTables() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OperationalInsights.Models.UsageMetric> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OperationalInsights.Models.UsageMetric> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeResponse> PurgeWorkspacePurge(Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeResponse>> PurgeWorkspacePurgeAsync(Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.Models.SharedKeys> RegenerateSharedKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.Models.SharedKeys>> RegenerateSharedKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource> Update(Azure.ResourceManager.OperationalInsights.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OperationalInsights.WorkspaceResource>> UpdateAsync(Azure.ResourceManager.OperationalInsights.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OperationalInsights.Models
{
    public partial class AssociatedWorkspace
    {
        public AssociatedWorkspace() { }
        public string AssociateDate { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
    }
    public partial class AvailableServiceTier
    {
        internal AvailableServiceTier() { }
        public long? CapacityReservationLevel { get { throw null; } }
        public long? DefaultRetention { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public string LastSkuUpdate { get { throw null; } }
        public long? MaximumRetention { get { throw null; } }
        public long? MinimumRetention { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum? ServiceTier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.BillingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.BillingType Cluster { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.BillingType Workspaces { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.BillingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.BillingType left, Azure.ResourceManager.OperationalInsights.Models.BillingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.BillingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.BillingType left, Azure.ResourceManager.OperationalInsights.Models.BillingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationProperties
    {
        public CapacityReservationProperties() { }
        public string LastSkuUpdate { get { throw null; } }
        public long? MinCapacity { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterEntityStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterEntityStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus ProvisioningAccount { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.ClusterEntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public Azure.ResourceManager.OperationalInsights.Models.BillingType? BillingType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.ClusterSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ClusterSku
    {
        public ClusterSku() { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum? Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterSkuNameEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterSkuNameEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum CapacityReservation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum left, Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum left, Azure.ResourceManager.OperationalInsights.Models.ClusterSkuNameEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Column
    {
        public Column() { }
        public Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum? ColumnType { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum? DataTypeHint { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsDefaultDisplay { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ColumnDataTypeHintEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ColumnDataTypeHintEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum ArmPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum Guid { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum IP { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum left, Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum left, Azure.ResourceManager.OperationalInsights.Models.ColumnDataTypeHintEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ColumnTypeEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ColumnTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum Boolean { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum DateTime { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum Dynamic { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum Guid { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum Int { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum Long { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum Real { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum left, Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum left, Azure.ResourceManager.OperationalInsights.Models.ColumnTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataIngestionStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataIngestionStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus ApproachingQuota { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus ForceOff { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus ForceOn { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus OverQuota { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus RespectQuota { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus SubscriptionSuspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus left, Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus left, Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSourceKind : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.DataSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSourceKind(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind AzureActivityLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind AzureAuditLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingContentLocation { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingCustomPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingDataTypeConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingDefaultRegistry { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingLinuxPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingRegistry { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ChangeTrackingServices { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind CustomLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind CustomLogCollection { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind DnsAnalytics { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind IISLogs { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind ImportComputerGroup { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind Itsm { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind LinuxChangeTrackingPath { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind LinuxPerformanceCollection { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind LinuxPerformanceObject { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind LinuxSyslog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind LinuxSyslogCollection { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind NetworkMonitoring { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind Office365 { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind SecurityCenterSecurityWindowsBaselineConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind SecurityEventCollectionConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind SecurityInsightsSecurityEventCollectionConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind SecurityWindowsBaselineConfiguration { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind SqlDataClassification { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind WindowsEvent { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind WindowsPerformanceCounter { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.DataSourceKind WindowsTelemetry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.DataSourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.DataSourceKind left, Azure.ResourceManager.OperationalInsights.Models.DataSourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.DataSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.DataSourceKind left, Azure.ResourceManager.OperationalInsights.Models.DataSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DataSourceType
    {
        CustomLogs = 0,
        AzureWatson = 1,
        Query = 2,
        Ingestion = 3,
        Alerts = 4,
    }
    public partial class IntelligencePack
    {
        internal IntelligencePack() { }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public int? KeyRsaSize { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedServiceEntityStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedServiceEntityStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus ProvisioningAccount { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.LinkedServiceEntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsQueryPackPatch
    {
        public LogAnalyticsQueryPackPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogAnalyticsQueryPackQueryPropertiesRelated
    {
        public LogAnalyticsQueryPackQueryPropertiesRelated() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Solutions { get { throw null; } }
    }
    public partial class LogAnalyticsQueryPackQuerySearchProperties
    {
        public LogAnalyticsQueryPackQuerySearchProperties() { }
        public Azure.ResourceManager.OperationalInsights.Models.LogAnalyticsQueryPackQuerySearchPropertiesRelated Related { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
    }
    public partial class LogAnalyticsQueryPackQuerySearchPropertiesRelated
    {
        public LogAnalyticsQueryPackQuerySearchPropertiesRelated() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Solutions { get { throw null; } }
    }
    public partial class ManagementGroup
    {
        internal ManagementGroup() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public System.DateTimeOffset? DataReceived { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsGateway { get { throw null; } }
        public string Name { get { throw null; } }
        public int? ServerCount { get { throw null; } }
        public string Sku { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class MetricName
    {
        internal MetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PrivateLinkScopedResource
    {
        internal PrivateLinkScopedResource() { }
        public string ResourceId { get { throw null; } }
        public string ScopeId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum InProgress { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum left, Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum left, Azure.ResourceManager.OperationalInsights.Models.ProvisioningStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType left, Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType left, Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurgeState : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.PurgeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurgeState(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.PurgeState Completed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.PurgeState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.PurgeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.PurgeState left, Azure.ResourceManager.OperationalInsights.Models.PurgeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.PurgeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.PurgeState left, Azure.ResourceManager.OperationalInsights.Models.PurgeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoredLogs
    {
        public RestoredLogs() { }
        public string AzureAsyncOperationId { get { throw null; } }
        public System.DateTimeOffset? EndRestoreOn { get { throw null; } set { } }
        public string SourceTable { get { throw null; } set { } }
        public System.DateTimeOffset? StartRestoreOn { get { throw null; } set { } }
    }
    public partial class ResultStatistics
    {
        internal ResultStatistics() { }
        public int? IngestedRecords { get { throw null; } }
        public float? Progress { get { throw null; } }
        public float? ScannedGb { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionInDaysAsDefault : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionInDaysAsDefault(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault False { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault left, Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault left, Azure.ResourceManager.OperationalInsights.Models.RetentionInDaysAsDefault right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Schema
    {
        public Schema() { }
        public System.Collections.Generic.IReadOnlyList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.Column> Columns { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Solutions { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.SourceEnum? Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.Column> StandardColumns { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum? TableSubType { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum? TableType { get { throw null; } }
    }
    public partial class SearchResults
    {
        public SearchResults() { }
        public string AzureAsyncOperationId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndSearchOn { get { throw null; } set { } }
        public int? Limit { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string SourceTable { get { throw null; } }
        public System.DateTimeOffset? StartSearchOn { get { throw null; } set { } }
    }
    public partial class SearchSchemaValue
    {
        internal SearchSchemaValue() { }
        public string DisplayName { get { throw null; } }
        public bool Facet { get { throw null; } }
        public bool Indexed { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OwnerType { get { throw null; } }
        public string SearchSchemaValueType { get { throw null; } }
        public bool Stored { get { throw null; } }
    }
    public partial class SharedKeys
    {
        internal SharedKeys() { }
        public string PrimarySharedKey { get { throw null; } }
        public string SecondarySharedKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuNameEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuNameEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum CapacityReservation { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum Free { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum PerGB2018 { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum PerNode { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum Premium { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum Standalone { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum left, Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum left, Azure.ResourceManager.OperationalInsights.Models.SkuNameEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.SourceEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.SourceEnum Customer { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.SourceEnum Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.SourceEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.SourceEnum left, Azure.ResourceManager.OperationalInsights.Models.SourceEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.SourceEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.SourceEnum left, Azure.ResourceManager.OperationalInsights.Models.SourceEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccount
    {
        public StorageAccount(string id, string key) { }
        public string Id { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
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
    public readonly partial struct TablePlanEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TablePlanEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum Analytics { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum left, Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum left, Azure.ResourceManager.OperationalInsights.Models.TablePlanEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableSubTypeEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableSubTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum Any { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum Classic { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum DataCollectionRuleBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum left, Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum left, Azure.ResourceManager.OperationalInsights.Models.TableSubTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableTypeEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum CustomLog { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum Microsoft { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum RestoredLogs { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum SearchResults { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum left, Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum left, Azure.ResourceManager.OperationalInsights.Models.TableTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Tag
    {
        public Tag(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TotalRetentionInDaysAsDefault : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TotalRetentionInDaysAsDefault(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault False { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault left, Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault left, Azure.ResourceManager.OperationalInsights.Models.TotalRetentionInDaysAsDefault right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Type : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.Type>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Type(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.Type EventHub { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.Type StorageAccount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.Type other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.Type left, Azure.ResourceManager.OperationalInsights.Models.Type right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.Type (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.Type left, Azure.ResourceManager.OperationalInsights.Models.Type right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UsageMetric
    {
        internal UsageMetric() { }
        public double? CurrentValue { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class WorkspaceCapping
    {
        public WorkspaceCapping() { }
        public double? DailyQuotaGb { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.DataIngestionStatus? DataIngestionStatus { get { throw null; } }
        public string QuotaNextResetTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceEntityStatus : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceEntityStatus(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus ProvisioningAccount { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus left, Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceFeatures
    {
        public WorkspaceFeatures() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ClusterResourceId { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableDataExport { get { throw null; } set { } }
        public bool? EnableLogAccessUsingOnlyResourcePermissions { get { throw null; } set { } }
        public bool? ImmediatePurgeDataOn30Days { get { throw null; } set { } }
    }
    public partial class WorkspacePatch : Azure.ResourceManager.Models.ResourceData
    {
        public WorkspacePatch() { }
        public string CreatedDate { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public string DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceFeatures Features { get { throw null; } set { } }
        public bool? ForceCmkForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ModifiedDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OperationalInsights.Models.PrivateLinkScopedResource> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceEntityStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.PublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
    }
    public partial class WorkspacePurgeBody
    {
        public WorkspacePurgeBody(string table, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeBodyFilters> filters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.OperationalInsights.Models.WorkspacePurgeBodyFilters> Filters { get { throw null; } }
        public string Table { get { throw null; } }
    }
    public partial class WorkspacePurgeBodyFilters
    {
        public WorkspacePurgeBodyFilters() { }
        public string Column { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class WorkspacePurgeResponse
    {
        internal WorkspacePurgeResponse() { }
        public string OperationId { get { throw null; } }
    }
    public partial class WorkspacePurgeStatusResponse
    {
        internal WorkspacePurgeStatusResponse() { }
        public Azure.ResourceManager.OperationalInsights.Models.PurgeState Status { get { throw null; } }
    }
    public partial class WorkspaceSku
    {
        public WorkspaceSku(Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum name) { }
        public int? CapacityReservationLevel { get { throw null; } set { } }
        public string LastSkuUpdate { get { throw null; } }
        public Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceSkuNameEnum : System.IEquatable<Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceSkuNameEnum(string value) { throw null; }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum CapacityReservation { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum Free { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum LACluster { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum PerGB2018 { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum PerNode { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum Premium { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum Standalone { get { throw null; } }
        public static Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum left, Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum left, Azure.ResourceManager.OperationalInsights.Models.WorkspaceSkuNameEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
}
