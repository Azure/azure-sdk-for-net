namespace Azure.ResourceManager.CosmosDB
{
    public partial class CassandraKeyspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>, System.Collections.IEnumerable
    {
        protected CassandraKeyspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyspaceName, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyspaceName, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> Get(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> GetAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraKeyspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraKeyspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraKeyspacePropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCassandraKeyspaceResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CassandraKeyspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraKeyspaceResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> GetCassandraTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> GetCassandraTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableCollection GetCassandraTables() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource GetDatabaseAccountCassandraKeyspaceThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraTableResource>, System.Collections.IEnumerable
    {
        protected CassandraTableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraTableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraTableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraTableData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraTableData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraTablePropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCassandraTableResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CassandraTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraTableResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource GetDatabaseAccountCassandraKeyspaceTableThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ClusterResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource> GetDataCenterResource(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> GetDataCenterResourceAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DataCenterResourceCollection GetDataCenterResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CommandOutput> InvokeCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CommandPostBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CommandOutput>> InvokeCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CommandPostBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus> Status(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus>> StatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.ClusterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.ClusterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDB.ClusterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDB.ClusterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ClusterResourceProperties Properties { get { throw null; } set { } }
    }
    public static partial class CosmosDBExtensions
    {
        public static Azure.Response<bool> CheckNameExistsDatabaseAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<bool>> CheckNameExistsDatabaseAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource GetCassandraKeyspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraTableResource GetCassandraTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> GetClusterResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> GetClusterResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.ClusterResourceCollection GetClusterResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetClusterResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetClusterResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> GetCosmosDBLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetCosmosDBLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocationResource GetCosmosDBLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocationCollection GetCosmosDBLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource GetCosmosDBPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource GetCosmosDBPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource GetCosmosDBSqlContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource GetCosmosDBSqlDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource GetCosmosDBSqlRoleAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource GetCosmosDBSqlRoleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource GetCosmosDBSqlStoredProcedureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource GetCosmosDBSqlTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource GetCosmosDBSqlUserDefinedFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosTableResource GetCosmosTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> GetDatabaseAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> GetDatabaseAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource GetDatabaseAccountCassandraKeyspaceTableThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource GetDatabaseAccountCassandraKeyspaceThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource GetDatabaseAccountGremlinDatabaseGraphThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource GetDatabaseAccountGremlinDatabaseThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource GetDatabaseAccountMongodbDatabaseCollectionThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource GetDatabaseAccountMongodbDatabaseThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountResource GetDatabaseAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountCollection GetDatabaseAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> GetDatabaseAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> GetDatabaseAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource GetDatabaseAccountSqlDatabaseContainerThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource GetDatabaseAccountSqlDatabaseThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource GetDatabaseAccountTableThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DataCenterResource GetDataCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinDatabaseResource GetGremlinDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinGraphResource GetGremlinGraphResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBCollectionResource GetMongoDBCollectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource GetMongoDBDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource GetRestorableDatabaseAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> GetRestorableDatabaseAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> GetRestorableDatabaseAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>, System.Collections.IEnumerable
    {
        protected CosmosDBLocationCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> Get(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBLocationData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBLocationData() { }
        public Azure.ResourceManager.CosmosDB.Models.LocationProperties Properties { get { throw null; } set { } }
    }
    public partial class CosmosDBLocationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBLocationResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> GetRestorableDatabaseAccount(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>> GetRestorableDatabaseAccountAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountCollection GetRestorableDatabaseAccounts() { throw null; }
    }
    public partial class CosmosDBPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected CosmosDBPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public partial class CosmosDBPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBPrivateLinkResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected CosmosDBPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class CosmosDBSqlContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlContainerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlContainerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerPropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlContainerResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlContainerResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> GetCosmosDBSqlStoredProcedure(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> GetCosmosDBSqlStoredProcedureAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureCollection GetCosmosDBSqlStoredProcedures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> GetCosmosDBSqlTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> GetCosmosDBSqlTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerCollection GetCosmosDBSqlTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> GetCosmosDBSqlUserDefinedFunction(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> GetCosmosDBSqlUserDefinedFunctionAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionCollection GetCosmosDBSqlUserDefinedFunctions() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource GetDatabaseAccountSqlDatabaseContainerThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.BackupInformation> RetrieveContinuousBackupInformation(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.BackupInformation>> RetrieveContinuousBackupInformationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabasePropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlDatabaseResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlDatabaseResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> GetCosmosDBSqlContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> GetCosmosDBSqlContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerCollection GetCosmosDBSqlContainers() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource GetDatabaseAccountSqlDatabaseThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlRoleAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlRoleAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleAssignmentId, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleAssignmentId, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> Get(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> GetAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlRoleAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBSqlRoleAssignmentData() { }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlRoleAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlRoleAssignmentResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string roleAssignmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlRoleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlRoleDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleDefinitionId, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleDefinitionId, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> Get(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> GetAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlRoleDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBSqlRoleDefinitionData() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.Permission> Permissions { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.RoleDefinitionType? RoleDefinitionType { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlRoleDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlRoleDefinitionResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string roleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlStoredProcedureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlStoredProcedureCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storedProcedureName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storedProcedureName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> Get(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> GetAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlStoredProcedureData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlStoredProcedureData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlStoredProcedureResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlStoredProcedureResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlStoredProcedureResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName, string storedProcedureName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlTriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlTriggerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlTriggerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlTriggerResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlTriggerResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlUserDefinedFunctionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlUserDefinedFunctionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userDefinedFunctionName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userDefinedFunctionName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> Get(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> GetAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlUserDefinedFunctionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlUserDefinedFunctionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlUserDefinedFunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlUserDefinedFunctionResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName, string userDefinedFunctionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosTableResource>, System.Collections.IEnumerable
    {
        protected CosmosTableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.CosmosDB.Models.CosmosTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.CosmosDB.Models.CosmosTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosTableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosTableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosTableData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosTableData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosTablePropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosTableResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosTableResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource GetDatabaseAccountTableThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceTableThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountCassandraKeyspaceTableThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> MigrateCassandraTableToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> MigrateCassandraTableToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> MigrateCassandraTableToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> MigrateCassandraTableToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountCassandraKeyspaceThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> MigrateCassandraKeyspaceToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> MigrateCassandraKeyspaceToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> MigrateCassandraKeyspaceToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> MigrateCassandraKeyspaceToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>, System.Collections.IEnumerable
    {
        protected DatabaseAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DatabaseAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ServerVersion? ApiServerVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCapability> Capabilities { get { throw null; } }
        public int? CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType? DatabaseAccountOfferType { get { throw null; } }
        public string DefaultIdentity { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string DocumentEndpoint { get { throw null; } }
        public bool? EnableAnalyticalStorage { get { throw null; } set { } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableFreeTier { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.FailoverPolicy> FailoverPolicies { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IPAddressOrRange> IPRules { get { throw null; } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkAclBypassResourceIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> ReadLocations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.RestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> WriteLocations { get { throw null; } }
    }
    public partial class DatabaseAccountGremlinDatabaseGraphThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountGremlinDatabaseGraphThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string graphName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> MigrateGremlinGraphToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> MigrateGremlinGraphToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> MigrateGremlinGraphToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> MigrateGremlinGraphToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountGremlinDatabaseThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> MigrateGremlinDatabaseToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> MigrateGremlinDatabaseToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> MigrateGremlinDatabaseToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> MigrateGremlinDatabaseToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string collectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> MigrateMongoDBCollectionToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> MigrateMongoDBCollectionToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> MigrateMongoDBCollectionToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> MigrateMongoDBCollectionToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountMongodbDatabaseThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> MigrateMongoDBDatabaseToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> MigrateMongoDBDatabaseToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> MigrateMongoDBDatabaseToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> MigrateMongoDBDatabaseToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountResource() { }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FailoverPriorityChange(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.FailoverPolicies failoverParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverPriorityChangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.FailoverPolicies failoverParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> GetCassandraKeyspace(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> GetCassandraKeyspaceAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceCollection GetCassandraKeyspaces() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountConnectionString> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountConnectionString> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> GetCosmosDBPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> GetCosmosDBPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionCollection GetCosmosDBPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> GetCosmosDBPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>> GetCosmosDBPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResourceCollection GetCosmosDBPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> GetCosmosDBSqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> GetCosmosDBSqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseCollection GetCosmosDBSqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> GetCosmosDBSqlRoleAssignment(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> GetCosmosDBSqlRoleAssignmentAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentCollection GetCosmosDBSqlRoleAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> GetCosmosDBSqlRoleDefinition(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> GetCosmosDBSqlRoleDefinitionAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionCollection GetCosmosDBSqlRoleDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource> GetCosmosTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableResource>> GetCosmosTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosTableCollection GetCosmosTables() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> GetGremlinDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> GetGremlinDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseCollection GetGremlinDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeyList> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeyList>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.MetricDefinition> GetMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.MetricDefinition> GetMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.MetricDefinition> GetMetricDefinitionsCollections(string databaseRid, string collectionRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.MetricDefinition> GetMetricDefinitionsCollectionsAsync(string databaseRid, string collectionRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.MetricDefinition> GetMetricDefinitionsDatabases(string databaseRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.MetricDefinition> GetMetricDefinitionsDatabasesAsync(string databaseRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetrics(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitionRegions(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitionRegionsAsync(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitions(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitionsAsync(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsCollectionRegions(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsCollectionRegionsAsync(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsCollections(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsCollectionsAsync(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsDatabaseAccountRegions(string region, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsDatabaseAccountRegionsAsync(string region, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsDatabases(string databaseRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseMetric> GetMetricsDatabasesAsync(string databaseRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIdRegions(string region, string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIdRegionsAsync(string region, string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIds(string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIdsAsync(string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PercentileMetric> GetMetricsPercentiles(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PercentileMetric> GetMetricsPercentilesAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PercentileMetric> GetMetricsPercentileSourceTargets(string sourceRegion, string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PercentileMetric> GetMetricsPercentileSourceTargetsAsync(string sourceRegion, string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PercentileMetric> GetMetricsPercentileTargets(string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PercentileMetric> GetMetricsPercentileTargetsAsync(string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> GetMongoDBDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> GetMongoDBDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseCollection GetMongoDBDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountReadOnlyKeyList> GetReadOnlyKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountReadOnlyKeyList>> GetReadOnlyKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionUsage> GetUsagesCollectionPartitions(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionUsage> GetUsagesCollectionPartitionsAsync(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesCollections(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesCollectionsAsync(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesDatabases(string databaseRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesDatabasesAsync(string databaseRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation OfflineRegion(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOffline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> OfflineRegionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOffline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation OnlineRegion(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOnline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> OnlineRegionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOnline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseContainerThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountSqlDatabaseContainerThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> MigrateSqlContainerToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> MigrateSqlContainerToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> MigrateSqlContainerToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> MigrateSqlContainerToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountSqlDatabaseThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> MigrateSqlDatabaseToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> MigrateSqlDatabaseToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> MigrateSqlDatabaseToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> MigrateSqlDatabaseToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountTableThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountTableThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> MigrateTableToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> MigrateTableToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> MigrateTableToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> MigrateTableToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCenterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataCenterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.DataCenterResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string dataCenterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.DataCenterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.DataCenterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCenterResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>, System.Collections.IEnumerable
    {
        protected DataCenterResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataCenterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataCenterName, Azure.ResourceManager.CosmosDB.DataCenterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataCenterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataCenterName, Azure.ResourceManager.CosmosDB.DataCenterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource> Get(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.DataCenterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DataCenterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> GetAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.DataCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.DataCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCenterResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DataCenterResourceData() { }
        public Azure.ResourceManager.CosmosDB.Models.DataCenterResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>, System.Collections.IEnumerable
    {
        protected GremlinDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GremlinDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.GremlinDatabasePropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedGremlinDatabaseResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GremlinDatabaseResource() { }
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSettingResource GetDatabaseAccountGremlinDatabaseThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> GetGremlinGraph(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> GetGremlinGraphAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphCollection GetGremlinGraphs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinGraphCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraphResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraphResource>, System.Collections.IEnumerable
    {
        protected GremlinGraphCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string graphName, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string graphName, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> Get(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.GremlinGraphResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.GremlinGraphResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> GetAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GremlinGraphResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraphResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GremlinGraphResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraphResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GremlinGraphData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinGraphData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.GremlinGraphPropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedGremlinGraphResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class GremlinGraphResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GremlinGraphResource() { }
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string graphName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSettingResource GetDatabaseAccountGremlinDatabaseGraphThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBCollectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>, System.Collections.IEnumerable
    {
        protected MongoDBCollectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectionName, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectionName, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> Get(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> GetAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBCollectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBCollectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionPropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedMongoDBCollectionResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class MongoDBCollectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBCollectionResource() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string collectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSettingResource GetDatabaseAccountMongodbDatabaseCollectionThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.BackupInformation> RetrieveContinuousBackupInformation(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.BackupInformation>> RetrieveContinuousBackupInformationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>, System.Collections.IEnumerable
    {
        protected MongoDBDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBDatabasePropertiesConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedMongoDBDatabaseResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class MongoDBDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBDatabaseResource() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSettingResource GetDatabaseAccountMongodbDatabaseThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> GetMongoDBCollection(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> GetMongoDBCollectionAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionCollection GetMongoDBCollections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDatabaseAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>, System.Collections.IEnumerable
    {
        protected RestorableDatabaseAccountCollection() { }
        public virtual Azure.Response<bool> Exists(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> Get(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>> GetAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDatabaseAccountData : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableDatabaseAccountData() { }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.ApiType? ApiType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.RestorableLocationResourceInfo> RestorableLocations { get { throw null; } }
    }
    public partial class RestorableDatabaseAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDatabaseAccountResource() { }
        public virtual Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbCollection> GetRestorableMongodbCollections(string restorableMongodbDatabaseRid = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbCollection> GetRestorableMongodbCollectionsAsync(string restorableMongodbDatabaseRid = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbDatabase> GetRestorableMongodbDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbDatabase> GetRestorableMongodbDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableMongodbResources(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableMongodbResourcesAsync(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer> GetRestorableSqlContainers(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer> GetRestorableSqlContainersAsync(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase> GetRestorableSqlDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase> GetRestorableSqlDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableSqlResources(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableSqlResourcesAsync(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThroughputSettingsData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ThroughputSettingsData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedThroughputSettingsResourceInfo Resource { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.CosmosDB.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyticalStorageSchemaType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyticalStorageSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType FullFidelity { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType WellDefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType left, Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType left, Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ApiType Cassandra { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ApiType Gremlin { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ApiType GremlinV2 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ApiType MongoDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ApiType Sql { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ApiType Table { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ApiType left, Azure.ResourceManager.CosmosDB.Models.ApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ApiType left, Azure.ResourceManager.CosmosDB.Models.ApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationMethod : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod Cassandra { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod left, Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod left, Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoscaleSettingsResourceInfo
    {
        public AutoscaleSettingsResourceInfo(int maxThroughput) { }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyResourceInfo AutoUpgradeThroughputPolicy { get { throw null; } set { } }
        public int MaxThroughput { get { throw null; } set { } }
        public int? TargetMaxThroughput { get { throw null; } }
    }
    public partial class BackupInformation
    {
        internal BackupInformation() { }
        public string ContinuousBackupInformationLatestRestorableTimestamp { get { throw null; } }
    }
    public partial class BackupPolicy
    {
        public BackupPolicy() { }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationState MigrationState { get { throw null; } set { } }
    }
    public partial class BackupPolicyMigrationState
    {
        public BackupPolicyMigrationState() { }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicyType? TargetType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupPolicyMigrationStatus : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupPolicyMigrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus left, Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus left, Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupPolicyType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.BackupPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.BackupPolicyType Continuous { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.BackupPolicyType Periodic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.BackupPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.BackupPolicyType left, Azure.ResourceManager.CosmosDB.Models.BackupPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.BackupPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.BackupPolicyType left, Azure.ResourceManager.CosmosDB.Models.BackupPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy left, Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy left, Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseConfig
    {
        public BaseConfig() { }
        public int? AutoscaleMaxThroughput { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class BaseMetric
    {
        internal BaseMetric() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.MetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class BaseUsage
    {
        internal BaseUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MetricName Name { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class CassandraClusterPublicStatus
    {
        internal CassandraClusterPublicStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.ConnectionError> ConnectionErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatusDataCentersItem> DataCenters { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.ManagedCassandraReaperStatus ReaperStatus { get { throw null; } }
    }
    public partial class CassandraClusterPublicStatusDataCentersItem
    {
        internal CassandraClusterPublicStatusDataCentersItem() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.ComponentsM9L909SchemasCassandraclusterpublicstatusPropertiesDatacentersItemsPropertiesNodesItems> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SeedNodes { get { throw null; } }
    }
    public partial class CassandraColumn
    {
        public CassandraColumn() { }
        public string CassandraColumnType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class CassandraKeyspaceCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraKeyspaceCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class CassandraKeyspacePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public CassandraKeyspacePropertiesConfig() { }
    }
    public partial class CassandraKeyspaceResourceInfo
    {
        public CassandraKeyspaceResourceInfo(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class CassandraPartitionKey
    {
        public CassandraPartitionKey() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class CassandraSchema
    {
        public CassandraSchema() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.ClusterKey> ClusterKeys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraColumn> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraPartitionKey> PartitionKeys { get { throw null; } }
    }
    public partial class CassandraTableCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraTableCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CassandraTablePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public CassandraTablePropertiesConfig() { }
    }
    public partial class CassandraTableResourceInfo
    {
        public CassandraTableResourceInfo(string id) { }
        public int? AnalyticalStorageTtl { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraSchema Schema { get { throw null; } set { } }
    }
    public partial class Certificate
    {
        public Certificate() { }
        public string Pem { get { throw null; } set { } }
    }
    public partial class ClusterKey
    {
        public ClusterKey() { }
        public string Name { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
    }
    public partial class ClusterResourceProperties
    {
        public ClusterResourceProperties() { }
        public Azure.ResourceManager.CosmosDB.Models.AuthenticationMethod? AuthenticationMethod { get { throw null; } set { } }
        public bool? CassandraAuditLoggingEnabled { get { throw null; } set { } }
        public string CassandraVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.Certificate> ClientCertificates { get { throw null; } }
        public string ClusterNameOverride { get { throw null; } set { } }
        public bool? Deallocated { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedManagementSubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.Certificate> ExternalGossipCertificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.SeedNode> ExternalSeedNodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.Certificate> GossipCertificates { get { throw null; } }
        public int? HoursBetweenBackups { get { throw null; } set { } }
        public string InitialCassandraAdminPassword { get { throw null; } set { } }
        public string PrometheusEndpointIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState? ProvisioningState { get { throw null; } set { } }
        public bool? RepairEnabled { get { throw null; } set { } }
        public string RestoreFromBackupId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.SeedNode> SeedNodes { get { throw null; } }
    }
    public partial class CommandOutput
    {
        internal CommandOutput() { }
        public string CommandOutputValue { get { throw null; } }
    }
    public partial class CommandPostBody
    {
        public CommandPostBody(string command, string host) { }
        public System.Collections.Generic.IDictionary<string, string> Arguments { get { throw null; } }
        public bool? CassandraStopStart { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public string Host { get { throw null; } }
        public bool? Readwrite { get { throw null; } set { } }
    }
    public partial class ComponentsM9L909SchemasCassandraclusterpublicstatusPropertiesDatacentersItemsPropertiesNodesItems
    {
        internal ComponentsM9L909SchemasCassandraclusterpublicstatusPropertiesDatacentersItemsPropertiesNodesItems() { }
        public string Address { get { throw null; } }
        public double? CpuUsage { get { throw null; } }
        public long? DiskFreeKB { get { throw null; } }
        public long? DiskUsedKB { get { throw null; } }
        public string HostId { get { throw null; } }
        public string Load { get { throw null; } }
        public long? MemoryBuffersAndCachedKB { get { throw null; } }
        public long? MemoryFreeKB { get { throw null; } }
        public long? MemoryTotalKB { get { throw null; } }
        public long? MemoryUsedKB { get { throw null; } }
        public string Rack { get { throw null; } }
        public int? Size { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NodeState? State { get { throw null; } }
        public string Status { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
    }
    public partial class CompositePath
    {
        public CompositePath() { }
        public Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder? Order { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompositePathSortOrder : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompositePathSortOrder(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder Ascending { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder left, Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder left, Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConflictResolutionMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConflictResolutionMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode Custom { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode LastWriterWins { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode left, Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode left, Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConflictResolutionPolicy
    {
        public ConflictResolutionPolicy() { }
        public string ConflictResolutionPath { get { throw null; } set { } }
        public string ConflictResolutionProcedure { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionMode? Mode { get { throw null; } set { } }
    }
    public partial class ConnectionError
    {
        internal ConnectionError() { }
        public Azure.ResourceManager.CosmosDB.Models.ConnectionState? ConnectionState { get { throw null; } }
        public string Exception { get { throw null; } }
        public string IPFrom { get { throw null; } }
        public string IPTo { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectionState DatacenterToDatacenterNetworkError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectionState InternalError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectionState InternalOperatorToDataCenterCertificateError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectionState OK { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectionState OperatorToDataCenterNetworkError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ConnectionState left, Azure.ResourceManager.CosmosDB.Models.ConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ConnectionState left, Azure.ResourceManager.CosmosDB.Models.ConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorOffer : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ConnectorOffer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorOffer(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ConnectorOffer Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ConnectorOffer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ConnectorOffer left, Azure.ResourceManager.CosmosDB.Models.ConnectorOffer right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ConnectorOffer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ConnectorOffer left, Azure.ResourceManager.CosmosDB.Models.ConnectorOffer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsistencyPolicy
    {
        public ConsistencyPolicy(Azure.ResourceManager.CosmosDB.Models.DefaultConsistencyLevel defaultConsistencyLevel) { }
        public Azure.ResourceManager.CosmosDB.Models.DefaultConsistencyLevel DefaultConsistencyLevel { get { throw null; } set { } }
        public int? MaxIntervalInSeconds { get { throw null; } set { } }
        public long? MaxStalenessPrefix { get { throw null; } set { } }
    }
    public partial class ContainerPartitionKey
    {
        public ContainerPartitionKey() { }
        public Azure.ResourceManager.CosmosDB.Models.PartitionKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Paths { get { throw null; } }
        public bool? SystemKey { get { throw null; } }
        public int? Version { get { throw null; } set { } }
    }
    public partial class ContinuousBackupRestoreLocation
    {
        public ContinuousBackupRestoreLocation() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class ContinuousModeBackupPolicy : Azure.ResourceManager.CosmosDB.Models.BackupPolicy
    {
        public ContinuousModeBackupPolicy() { }
    }
    public partial class CorsPolicy
    {
        public CorsPolicy(string allowedOrigins) { }
        public string AllowedHeaders { get { throw null; } set { } }
        public string AllowedMethods { get { throw null; } set { } }
        public string AllowedOrigins { get { throw null; } set { } }
        public string ExposedHeaders { get { throw null; } set { } }
        public long? MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class CosmosDBPrivateLinkServiceConnectionStateProperty
    {
        public CosmosDBPrivateLinkServiceConnectionStateProperty() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlContainerCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerPropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public CosmosDBSqlContainerPropertiesConfig() { }
    }
    public partial class CosmosDBSqlContainerResourceInfo
    {
        public CosmosDBSqlContainerResourceInfo(string id) { }
        public long? AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy ConflictResolutionPolicy { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.IndexingPolicy IndexingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ContainerPartitionKey PartitionKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.UniqueKey> UniqueKeys { get { throw null; } }
    }
    public partial class CosmosDBSqlDatabaseCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlDatabaseCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlDatabasePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public CosmosDBSqlDatabasePropertiesConfig() { }
    }
    public partial class CosmosDBSqlDatabaseResourceInfo
    {
        public CosmosDBSqlDatabaseResourceInfo(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlRoleAssignmentCreateOrUpdateContent
    {
        public CosmosDBSqlRoleAssignmentCreateOrUpdateContent() { }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlRoleDefinitionCreateOrUpdateContent
    {
        public CosmosDBSqlRoleDefinitionCreateOrUpdateContent() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.Permission> Permissions { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.RoleDefinitionType? RoleDefinitionType { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlStoredProcedureCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlStoredProcedureCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlStoredProcedureResourceInfo
    {
        public CosmosDBSqlStoredProcedureResourceInfo(string id) { }
        public string Body { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlTriggerCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlTriggerCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlTriggerResourceInfo
    {
        public CosmosDBSqlTriggerResourceInfo(string id) { }
        public string Body { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.TriggerOperation? TriggerOperation { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.TriggerType? TriggerType { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlUserDefinedFunctionResourceInfo
    {
        public CosmosDBSqlUserDefinedFunctionResourceInfo(string id) { }
        public string Body { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class CosmosTableCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosTableCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class CosmosTablePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public CosmosTablePropertiesConfig() { }
    }
    public partial class CosmosTableResourceInfo
    {
        public CosmosTableResourceInfo(string id) { }
        public string Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CreateMode Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CreateMode left, Azure.ResourceManager.CosmosDB.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CreateMode left, Azure.ResourceManager.CosmosDB.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateUpdateConfig
    {
        public CreateUpdateConfig() { }
        public int? AutoscaleMaxThroughput { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class DatabaseAccountCapability
    {
        public DatabaseAccountCapability() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DatabaseAccountConnectionString
    {
        internal DatabaseAccountConnectionString() { }
        public string ConnectionString { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public partial class DatabaseAccountCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DatabaseAccountCreateOrUpdateContent(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> locations) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ServerVersion? ApiServerVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCapability> Capabilities { get { throw null; } }
        public int? CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType DatabaseAccountOfferType { get { throw null; } set { } }
        public string DefaultIdentity { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableAnalyticalStorage { get { throw null; } set { } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableFreeTier { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IPAddressOrRange> IPRules { get { throw null; } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkAclBypassResourceIds { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.RestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DatabaseAccountKeyList : Azure.ResourceManager.CosmosDB.Models.DatabaseAccountReadOnlyKeyList
    {
        internal DatabaseAccountKeyList() { }
        public string PrimaryMasterKey { get { throw null; } }
        public string SecondaryMasterKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseAccountKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseAccountKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind GlobalDocumentDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind MongoDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind Parse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind left, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind left, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseAccountLocation
    {
        public DatabaseAccountLocation() { }
        public string DocumentEndpoint { get { throw null; } }
        public int? FailoverPriority { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public string LocationName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseAccountOfferType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseAccountOfferType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType left, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType left, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfferType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseAccountPatch
    {
        public DatabaseAccountPatch() { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ServerVersion? ApiServerVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCapability> Capabilities { get { throw null; } }
        public int? CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CorsPolicy> Cors { get { throw null; } }
        public string DefaultIdentity { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableAnalyticalStorage { get { throw null; } set { } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableFreeTier { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IPAddressOrRange> IPRules { get { throw null; } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkAclBypassResourceIds { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DatabaseAccountReadOnlyKeyList
    {
        internal DatabaseAccountReadOnlyKeyList() { }
        public string PrimaryReadonlyMasterKey { get { throw null; } }
        public string SecondaryReadonlyMasterKey { get { throw null; } }
    }
    public partial class DatabaseAccountRegenerateKeyContent
    {
        public DatabaseAccountRegenerateKeyContent(Azure.ResourceManager.CosmosDB.Models.KeyKind keyKind) { }
        public Azure.ResourceManager.CosmosDB.Models.KeyKind KeyKind { get { throw null; } }
    }
    public partial class DatabaseRestoreResourceInfo
    {
        public DatabaseRestoreResourceInfo() { }
        public System.Collections.Generic.IList<string> CollectionNames { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
    }
    public partial class DataCenterResourceProperties
    {
        public DataCenterResourceProperties() { }
        public bool? AvailabilityZone { get { throw null; } set { } }
        public System.Uri BackupStorageCustomerKeyUri { get { throw null; } set { } }
        public string Base64EncodedCassandraYamlFragment { get { throw null; } set { } }
        public string DataCenterLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedSubnetId { get { throw null; } set { } }
        public int? DiskCapacity { get { throw null; } set { } }
        public string DiskSku { get { throw null; } set { } }
        public System.Uri ManagedDiskCustomerKeyUri { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.SeedNode> SeedNodes { get { throw null; } }
        public string Sku { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.DataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DataType LineString { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DataType MultiPolygon { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DataType Number { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DataType Point { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DataType Polygon { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DataType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.DataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.DataType left, Azure.ResourceManager.CosmosDB.Models.DataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.DataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.DataType left, Azure.ResourceManager.CosmosDB.Models.DataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DefaultConsistencyLevel
    {
        Eventual = 0,
        Session = 1,
        BoundedStaleness = 2,
        Strong = 3,
        ConsistentPrefix = 4,
    }
    public partial class ExcludedPath
    {
        public ExcludedPath() { }
        public string Path { get { throw null; } set { } }
    }
    public partial class ExtendedCassandraKeyspaceResourceInfo : Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceResourceInfo
    {
        public ExtendedCassandraKeyspaceResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedCassandraTableResourceInfo : Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo
    {
        public ExtendedCassandraTableResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlContainerResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo
    {
        public ExtendedCosmosDBSqlContainerResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlDatabaseResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo
    {
        public ExtendedCosmosDBSqlDatabaseResourceInfo(string id) : base (default(string)) { }
        public string Colls { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
        public string Users { get { throw null; } set { } }
    }
    public partial class ExtendedCosmosDBSqlStoredProcedureResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo
    {
        public ExtendedCosmosDBSqlStoredProcedureResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlTriggerResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo
    {
        public ExtendedCosmosDBSqlTriggerResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo
    {
        public ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedCosmosTableResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosTableResourceInfo
    {
        public ExtendedCosmosTableResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedGremlinDatabaseResourceInfo : Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResourceInfo
    {
        public ExtendedGremlinDatabaseResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedGremlinGraphResourceInfo : Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo
    {
        public ExtendedGremlinGraphResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedMongoDBCollectionResourceInfo : Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo
    {
        public ExtendedMongoDBCollectionResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedMongoDBDatabaseResourceInfo : Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResourceInfo
    {
        public ExtendedMongoDBDatabaseResourceInfo(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ExtendedRestorableMongodbCollectionResourceInfo
    {
        internal ExtendedRestorableMongodbCollectionResourceInfo() { }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableMongodbDatabaseResourceInfo
    {
        internal ExtendedRestorableMongodbDatabaseResourceInfo() { }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableSqlContainerResourceInfo
    {
        internal ExtendedRestorableSqlContainerResourceInfo() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainerPropertiesResourceContainer Container { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableSqlDatabaseResourceInfo
    {
        internal ExtendedRestorableSqlDatabaseResourceInfo() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabasePropertiesResourceDatabase Database { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedThroughputSettingsResourceInfo : Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo
    {
        public ExtendedThroughputSettingsResourceInfo() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class FailoverPolicies
    {
        public FailoverPolicies(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.FailoverPolicy> failoverPoliciesValue) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.FailoverPolicy> FailoverPoliciesValue { get { throw null; } }
    }
    public partial class FailoverPolicy
    {
        public FailoverPolicy() { }
        public int? FailoverPriority { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string LocationName { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinDatabaseCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class GremlinDatabasePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public GremlinDatabasePropertiesConfig() { }
    }
    public partial class GremlinDatabaseResourceInfo
    {
        public GremlinDatabaseResourceInfo(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class GremlinGraphCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinGraphCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class GremlinGraphPropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public GremlinGraphPropertiesConfig() { }
    }
    public partial class GremlinGraphResourceInfo
    {
        public GremlinGraphResourceInfo(string id) { }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy ConflictResolutionPolicy { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.IndexingPolicy IndexingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ContainerPartitionKey PartitionKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.UniqueKey> UniqueKeys { get { throw null; } }
    }
    public partial class IncludedPath
    {
        public IncludedPath() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.PathIndexes> Indexes { get { throw null; } }
        public string Path { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexingMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.IndexingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexingMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.IndexingMode Consistent { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.IndexingMode Lazy { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.IndexingMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.IndexingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.IndexingMode left, Azure.ResourceManager.CosmosDB.Models.IndexingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.IndexingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.IndexingMode left, Azure.ResourceManager.CosmosDB.Models.IndexingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexingPolicy
    {
        public IndexingPolicy() { }
        public bool? Automatic { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CompositePath>> CompositeIndexes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.ExcludedPath> ExcludedPaths { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IncludedPath> IncludedPaths { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.IndexingMode? IndexingMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.SpatialSpec> SpatialIndexes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.IndexKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.IndexKind Hash { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.IndexKind Range { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.IndexKind Spatial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.IndexKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.IndexKind left, Azure.ResourceManager.CosmosDB.Models.IndexKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.IndexKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.IndexKind left, Azure.ResourceManager.CosmosDB.Models.IndexKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAddressOrRange
    {
        public IPAddressOrRange() { }
        public string IPAddressOrRangeValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.KeyKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.KeyKind Primary { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.KeyKind PrimaryReadonly { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.KeyKind Secondary { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.KeyKind SecondaryReadonly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.KeyKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.KeyKind left, Azure.ResourceManager.CosmosDB.Models.KeyKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.KeyKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.KeyKind left, Azure.ResourceManager.CosmosDB.Models.KeyKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationProperties
    {
        public LocationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy> BackupStorageRedundancies { get { throw null; } }
        public bool? IsResidencyRestricted { get { throw null; } }
        public bool? SupportsAvailabilityZone { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedCassandraProvisioningState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedCassandraProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState left, Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState left, Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedCassandraReaperStatus
    {
        internal ManagedCassandraReaperStatus() { }
        public bool? Healthy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RepairRunIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RepairSchedules { get { throw null; } }
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public string Retention { get { throw null; } }
        public string TimeGrain { get { throw null; } }
    }
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MetricName Name { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class MetricName
    {
        internal MetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class MetricValue
    {
        internal MetricValue() { }
        public double? Average { get { throw null; } }
        public int? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public double? Total { get { throw null; } }
    }
    public partial class MongoDBCollectionCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBCollectionCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class MongoDBCollectionPropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public MongoDBCollectionPropertiesConfig() { }
    }
    public partial class MongoDBCollectionResourceInfo
    {
        public MongoDBCollectionResourceInfo(string id) { }
        public int? AnalyticalStorageTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoIndex> Indexes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ShardKey { get { throw null; } }
    }
    public partial class MongoDBDatabaseCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBDatabaseCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class MongoDBDatabasePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.BaseConfig
    {
        public MongoDBDatabasePropertiesConfig() { }
    }
    public partial class MongoDBDatabaseResourceInfo
    {
        public MongoDBDatabaseResourceInfo(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class MongoIndex
    {
        public MongoIndex() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MongoIndexConfig Options { get { throw null; } set { } }
    }
    public partial class MongoIndexConfig
    {
        public MongoIndexConfig() { }
        public int? ExpireAfterSeconds { get { throw null; } set { } }
        public bool? Unique { get { throw null; } set { } }
    }
    public enum NetworkAclBypass
    {
        None = 0,
        AzureServices = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.NodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.NodeState Joining { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.NodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.NodeState Moving { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.NodeState Normal { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.NodeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.NodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.NodeState left, Azure.ResourceManager.CosmosDB.Models.NodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.NodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.NodeState left, Azure.ResourceManager.CosmosDB.Models.NodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.OperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.OperationType Create { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.OperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.OperationType Replace { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.OperationType SystemOperation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.OperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.OperationType left, Azure.ResourceManager.CosmosDB.Models.OperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.OperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.OperationType left, Azure.ResourceManager.CosmosDB.Models.OperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartitionKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.PartitionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartitionKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PartitionKind Hash { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PartitionKind MultiHash { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PartitionKind Range { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.PartitionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.PartitionKind left, Azure.ResourceManager.CosmosDB.Models.PartitionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.PartitionKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.PartitionKind left, Azure.ResourceManager.CosmosDB.Models.PartitionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartitionMetric : Azure.ResourceManager.CosmosDB.Models.BaseMetric
    {
        internal PartitionMetric() { }
        public string PartitionId { get { throw null; } }
        public string PartitionKeyRangeId { get { throw null; } }
    }
    public partial class PartitionUsage : Azure.ResourceManager.CosmosDB.Models.BaseUsage
    {
        internal PartitionUsage() { }
        public string PartitionId { get { throw null; } }
        public string PartitionKeyRangeId { get { throw null; } }
    }
    public partial class PathIndexes
    {
        public PathIndexes() { }
        public Azure.ResourceManager.CosmosDB.Models.DataType? DataType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.IndexKind? Kind { get { throw null; } set { } }
        public int? Precision { get { throw null; } set { } }
    }
    public partial class PercentileMetric
    {
        internal PercentileMetric() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.PercentileMetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class PercentileMetricValue : Azure.ResourceManager.CosmosDB.Models.MetricValue
    {
        internal PercentileMetricValue() { }
        public double? P10 { get { throw null; } }
        public double? P25 { get { throw null; } }
        public double? P50 { get { throw null; } }
        public double? P75 { get { throw null; } }
        public double? P90 { get { throw null; } }
        public double? P95 { get { throw null; } }
        public double? P99 { get { throw null; } }
    }
    public partial class PeriodicModeBackupPolicy : Azure.ResourceManager.CosmosDB.Models.BackupPolicy
    {
        public PeriodicModeBackupPolicy() { }
        public Azure.ResourceManager.CosmosDB.Models.PeriodicModeProperties PeriodicModeProperties { get { throw null; } set { } }
    }
    public partial class PeriodicModeProperties
    {
        public PeriodicModeProperties() { }
        public int? BackupIntervalInMinutes { get { throw null; } set { } }
        public int? BackupRetentionIntervalInHours { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } set { } }
    }
    public partial class Permission
    {
        public Permission() { }
        public System.Collections.Generic.IList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotDataActions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrimaryAggregationType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrimaryAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType Last { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType Maximum { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType Minimum { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType None { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType left, Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType left, Azure.ResourceManager.CosmosDB.Models.PrimaryAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess left, Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess left, Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionForOnlineOffline
    {
        public RegionForOnlineOffline(string region) { }
        public string Region { get { throw null; } }
    }
    public partial class RestorableLocationResourceInfo
    {
        internal RestorableLocationResourceInfo() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string LocationName { get { throw null; } }
        public string RegionalDatabaseAccountInstanceId { get { throw null; } }
    }
    public partial class RestorableMongodbCollection : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableMongodbCollection() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongodbCollectionResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableMongodbDatabase : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableMongodbDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongodbDatabaseResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableSqlContainer : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableSqlContainer() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlContainerResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableSqlContainerPropertiesResourceContainer : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo
    {
        public RestorableSqlContainerPropertiesResourceContainer(string id) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public string Self { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class RestorableSqlDatabase : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableSqlDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlDatabaseResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableSqlDatabasePropertiesResourceDatabase : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo
    {
        public RestorableSqlDatabasePropertiesResourceDatabase(string id) : base (default(string)) { }
        public string Colls { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public string Self { get { throw null; } }
        public float? Ts { get { throw null; } }
        public string Users { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.RestoreMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestoreMode PointInTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.RestoreMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.RestoreMode left, Azure.ResourceManager.CosmosDB.Models.RestoreMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.RestoreMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.RestoreMode left, Azure.ResourceManager.CosmosDB.Models.RestoreMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreParameters
    {
        public RestoreParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> DatabasesToRestore { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.RestoreMode? RestoreMode { get { throw null; } set { } }
        public string RestoreSource { get { throw null; } set { } }
        public System.DateTimeOffset? RestoreTimestampInUtc { get { throw null; } set { } }
    }
    public enum RoleDefinitionType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public partial class SeedNode
    {
        public SeedNode() { }
        public string IPAddress { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerVersion : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ServerVersion Four0 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ServerVersion Three2 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ServerVersion Three6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ServerVersion left, Azure.ResourceManager.CosmosDB.Models.ServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ServerVersion left, Azure.ResourceManager.CosmosDB.Models.ServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpatialSpec
    {
        public SpatialSpec() { }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.SpatialType> Types { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpatialType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.SpatialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpatialType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.SpatialType LineString { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.SpatialType MultiPolygon { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.SpatialType Point { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.SpatialType Polygon { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.SpatialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.SpatialType left, Azure.ResourceManager.CosmosDB.Models.SpatialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.SpatialType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.SpatialType left, Azure.ResourceManager.CosmosDB.Models.SpatialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThroughputPolicyResourceInfo
    {
        public ThroughputPolicyResourceInfo() { }
        public int? IncrementPercent { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class ThroughputSettingsResourceInfo
    {
        public ThroughputSettingsResourceInfo() { }
        public Azure.ResourceManager.CosmosDB.Models.AutoscaleSettingsResourceInfo AutoscaleSettings { get { throw null; } set { } }
        public string MinimumThroughput { get { throw null; } }
        public string OfferReplacePending { get { throw null; } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class ThroughputSettingsUpdateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ThroughputSettingsUpdateData(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo Resource { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerOperation : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.TriggerOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerOperation(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerOperation All { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerOperation Create { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerOperation Replace { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerOperation Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.TriggerOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.TriggerOperation left, Azure.ResourceManager.CosmosDB.Models.TriggerOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.TriggerOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.TriggerOperation left, Azure.ResourceManager.CosmosDB.Models.TriggerOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.TriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerType Post { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.TriggerType Pre { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.TriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.TriggerType left, Azure.ResourceManager.CosmosDB.Models.TriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.TriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.TriggerType left, Azure.ResourceManager.CosmosDB.Models.TriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UniqueKey
    {
        public UniqueKey() { }
        public System.Collections.Generic.IList<string> Paths { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.UnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType Bytes { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType Count { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType Milliseconds { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType Percent { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.UnitType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.UnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.UnitType left, Azure.ResourceManager.CosmosDB.Models.UnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.UnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.UnitType left, Azure.ResourceManager.CosmosDB.Models.UnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule() { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVNetServiceEndpoint { get { throw null; } set { } }
    }
}
