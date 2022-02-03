namespace Azure.ResourceManager.CosmosDB
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.CosmosDB.CassandraKeyspace GetCassandraKeyspace(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraTable GetCassandraTable(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocation GetCosmosDBLocation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosTable GetCosmosTable(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccount GetDatabaseAccount(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting GetDatabaseAccountCassandraKeyspaceTableThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting GetDatabaseAccountCassandraKeyspaceThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting GetDatabaseAccountGremlinDatabaseGraphThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting GetDatabaseAccountGremlinDatabaseThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting GetDatabaseAccountMongodbDatabaseCollectionThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting GetDatabaseAccountMongodbDatabaseThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting GetDatabaseAccountSqlDatabaseContainerThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting GetDatabaseAccountSqlDatabaseThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting GetDatabaseAccountTableThroughputSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DataCenterResource GetDataCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinDatabase GetGremlinDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinGraph GetGremlinGraph(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBCollection GetMongoDBCollection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBDatabase GetMongoDBDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount GetRestorableDatabaseAccount(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.SqlContainer GetSqlContainer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.SqlDatabase GetSqlDatabase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.SqlStoredProcedure GetSqlStoredProcedure(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.SqlTrigger GetSqlTrigger(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction GetSqlUserDefinedFunction(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CassandraKeyspace : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraKeyspace() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableCollection GetCassandraTables() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting GetDatabaseAccountCassandraKeyspaceThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraKeyspaceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspace>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspace>, System.Collections.IEnumerable
    {
        protected CassandraKeyspaceCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string keyspaceName, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateUpdateOptions createUpdateCassandraKeyspaceParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string keyspaceName, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateUpdateOptions createUpdateCassandraKeyspaceParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace> Get(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraKeyspace> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraKeyspace> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> GetAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace> GetIfExists(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> GetIfExistsAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraKeyspace> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspace>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraKeyspace> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspace>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraKeyspaceData : Azure.ResourceManager.Models.TrackedResource
    {
        public CassandraKeyspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraKeyspacePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraKeyspacePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class CassandraTable : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraTable() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.CassandraTableDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.CassandraTableDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting GetDatabaseAccountCassandraKeyspaceTableThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraTableCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraTable>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraTable>, System.Collections.IEnumerable
    {
        protected CassandraTableCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string tableName, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateUpdateOptions createUpdateCassandraTableParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string tableName, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateUpdateOptions createUpdateCassandraTableParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraTable> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraTable> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraTable> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraTable>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraTable> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraTable>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraTableData : Azure.ResourceManager.Models.TrackedResource
    {
        public CassandraTableData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraTablePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraTablePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class ClusterResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ClusterResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.ClusterResourceDeallocateOperation Deallocate(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.ClusterResourceDeallocateOperation> DeallocateAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.ClusterResourceDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.ClusterResourceDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DataCenterResourceCollection GetDataCenterResources() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.ClusterResourceInvokeCommandOperation InvokeCommand(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.CommandPostBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.ClusterResourceInvokeCommandOperation> InvokeCommandAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.CommandPostBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.ClusterResourceStartOperation Start(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.ClusterResourceStartOperation> StartAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus> Status(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus>> StatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.ClusterResourceUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.CosmosDB.ClusterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.ClusterResourceUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.ClusterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterResourceCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.ClusterResourceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string clusterName, Azure.ResourceManager.CosmosDB.ClusterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.ClusterResourceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string clusterName, Azure.ResourceManager.CosmosDB.ClusterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterResourceData : Azure.ResourceManager.CosmosDB.Models.ManagedCassandraARMResourceProperties
    {
        public ClusterResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ClusterResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class CosmosDBLocation : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBLocation() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocation> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocation>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountCollection GetRestorableDatabaseAccounts() { throw null; }
    }
    public partial class CosmosDBLocationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocation>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocation>, System.Collections.IEnumerable
    {
        protected CosmosDBLocationCollection() { }
        public virtual Azure.Response<bool> Exists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocation> Get(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBLocation> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBLocation> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocation>> GetAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocation> GetIfExists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocation>> GetIfExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBLocation> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocation>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBLocation> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocation>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBLocationData : Azure.ResourceManager.Models.Resource
    {
        public CosmosDBLocationData() { }
        public Azure.ResourceManager.CosmosDB.Models.LocationProperties Properties { get { throw null; } set { } }
    }
    public partial class CosmosTable : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosTable() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.CosmosTableDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.CosmosTableDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting GetDatabaseAccountTableThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosTableCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosTable>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosTable>, System.Collections.IEnumerable
    {
        protected CosmosTableCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.CosmosTableCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string tableName, Azure.ResourceManager.CosmosDB.Models.TableCreateUpdateOptions createUpdateTableParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.CosmosTableCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string tableName, Azure.ResourceManager.CosmosDB.Models.TableCreateUpdateOptions createUpdateTableParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosTable> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosTable> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosTable> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosTable>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosTable> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosTable>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosTableData : Azure.ResourceManager.Models.TrackedResource
    {
        public CosmosTableData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosTablePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosTablePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class DatabaseAccount : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccount() { }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountFailoverPriorityChangeOperation FailoverPriorityChange(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.FailoverPolicies failoverParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountFailoverPriorityChangeOperation> FailoverPriorityChangeAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.FailoverPolicies failoverParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceCollection GetCassandraKeyspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountConnectionStringList> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountConnectionStringList>> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosTableCollection GetCosmosTables() { throw null; }
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
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseCollection GetMongoDBDatabases() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountReadOnlyKeyList> GetReadOnlyKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountReadOnlyKeyList>> GetReadOnlyKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.SqlDatabaseCollection GetSqlDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionUsage> GetUsagesCollectionPartitions(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionUsage> GetUsagesCollectionPartitionsAsync(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesCollections(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesCollectionsAsync(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesDatabases(string databaseRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.BaseUsage> GetUsagesDatabasesAsync(string databaseRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfflineRegionOperation OfflineRegion(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOffline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOfflineRegionOperation> OfflineRegionAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOffline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOnlineRegionOperation OnlineRegion(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOnline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountOnlineRegionOperation> OnlineRegionAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOnline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountRegenerateKeyOperation RegenerateKey(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountRegenerateKeyOptions keyToRegenerate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountRegenerateKeyOperation> RegenerateKeyAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountRegenerateKeyOptions keyToRegenerate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountUpdateOptions updateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountUpdateOptions updateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceTableThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountCassandraKeyspaceTableThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceTableThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceTableThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToAutoscaleOperation MigrateCassandraTableToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToAutoscaleOperation> MigrateCassandraTableToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToManualThroughputOperation MigrateCassandraTableToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToManualThroughputOperation> MigrateCassandraTableToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountCassandraKeyspaceThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToAutoscaleOperation MigrateCassandraKeyspaceToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToAutoscaleOperation> MigrateCassandraKeyspaceToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToManualThroughputOperation MigrateCassandraKeyspaceToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToManualThroughputOperation> MigrateCassandraKeyspaceToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccount>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccount>, System.Collections.IEnumerable
    {
        protected DatabaseAccountCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string accountName, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCreateUpdateOptions createUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string accountName, Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCreateUpdateOptions createUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.DatabaseAccount> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DatabaseAccount> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.DatabaseAccount> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccount>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.DatabaseAccount> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DatabaseAccount>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseAccountData : Azure.ResourceManager.Models.TrackedResource
    {
        public DatabaseAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageConfiguration AnalyticalStorageConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.Capacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public string DatabaseAccountOfferType { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IpAddressOrRange> IpRules { get { throw null; } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public string KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkAclBypassResourceIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> ReadLocations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.RestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> WriteLocations { get { throw null; } }
    }
    public partial class DatabaseAccountGremlinDatabaseGraphThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountGremlinDatabaseGraphThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseGraphThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseGraphThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string graphName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToAutoscaleOperation MigrateGremlinGraphToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToAutoscaleOperation> MigrateGremlinGraphToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToManualThroughputOperation MigrateGremlinGraphToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToManualThroughputOperation> MigrateGremlinGraphToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountGremlinDatabaseThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToAutoscaleOperation MigrateGremlinDatabaseToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToAutoscaleOperation> MigrateGremlinDatabaseToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToManualThroughputOperation MigrateGremlinDatabaseToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToManualThroughputOperation> MigrateGremlinDatabaseToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseCollectionThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountMongodbDatabaseCollectionThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseCollectionThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseCollectionThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string collectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToAutoscaleOperation MigrateMongoDBCollectionToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToAutoscaleOperation> MigrateMongoDBCollectionToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToManualThroughputOperation MigrateMongoDBCollectionToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToManualThroughputOperation> MigrateMongoDBCollectionToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountMongodbDatabaseThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToAutoscaleOperation MigrateMongoDBDatabaseToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToAutoscaleOperation> MigrateMongoDBDatabaseToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToManualThroughputOperation MigrateMongoDBDatabaseToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToManualThroughputOperation> MigrateMongoDBDatabaseToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseContainerThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountSqlDatabaseContainerThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseContainerThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseContainerThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToAutoscaleOperation MigrateSqlContainerToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToAutoscaleOperation> MigrateSqlContainerToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToManualThroughputOperation MigrateSqlContainerToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToManualThroughputOperation> MigrateSqlContainerToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountSqlDatabaseThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToAutoscaleOperation MigrateSqlDatabaseToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToAutoscaleOperation> MigrateSqlDatabaseToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToManualThroughputOperation MigrateSqlDatabaseToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToManualThroughputOperation> MigrateSqlDatabaseToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountTableThroughputSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseAccountTableThroughputSetting() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountTableThroughputSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountTableThroughputSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateOptions updateThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountTableThroughputSettingMigrateTableToAutoscaleOperation MigrateTableToAutoscale(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountTableThroughputSettingMigrateTableToAutoscaleOperation> MigrateTableToAutoscaleAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DatabaseAccountTableThroughputSettingMigrateTableToManualThroughputOperation MigrateTableToManualThroughput(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountTableThroughputSettingMigrateTableToManualThroughputOperation> MigrateTableToManualThroughputAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCenterResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataCenterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.DataCenterResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string dataCenterName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DataCenterResourceDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DataCenterResourceDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.DataCenterResourceUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.CosmosDB.DataCenterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DataCenterResourceUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.DataCenterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCenterResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>, System.Collections.IEnumerable
    {
        protected DataCenterResourceCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.DataCenterResourceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string dataCenterName, Azure.ResourceManager.CosmosDB.DataCenterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.DataCenterResourceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string dataCenterName, Azure.ResourceManager.CosmosDB.DataCenterResourceData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource> Get(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.DataCenterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DataCenterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> GetAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource> GetIfExists(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> GetIfExistsAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.DataCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.DataCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DataCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCenterResourceData : Azure.ResourceManager.Models.Resource
    {
        public DataCenterResourceData() { }
        public Azure.ResourceManager.CosmosDB.Models.DataCenterResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class GremlinDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GremlinDatabase() { }
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting GetDatabaseAccountGremlinDatabaseThroughputSetting() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphCollection GetGremlinGraphs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabase>, System.Collections.IEnumerable
    {
        protected GremlinDatabaseCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string databaseName, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateUpdateOptions createUpdateGremlinDatabaseParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string databaseName, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateUpdateOptions createUpdateGremlinDatabaseParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.GremlinDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.GremlinDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GremlinDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GremlinDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GremlinDatabaseData : Azure.ResourceManager.Models.TrackedResource
    {
        public GremlinDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.GremlinDatabasePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinDatabasePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class GremlinGraph : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GremlinGraph() { }
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string graphName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.GremlinGraphDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.GremlinGraphDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting GetDatabaseAccountGremlinDatabaseGraphThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinGraphCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraph>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraph>, System.Collections.IEnumerable
    {
        protected GremlinGraphCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string graphName, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateUpdateOptions createUpdateGremlinGraphParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string graphName, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateUpdateOptions createUpdateGremlinGraphParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph> Get(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.GremlinGraph> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.GremlinGraph> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> GetAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph> GetIfExists(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> GetIfExistsAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GremlinGraph> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraph>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GremlinGraph> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraph>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GremlinGraphData : Azure.ResourceManager.Models.TrackedResource
    {
        public GremlinGraphData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.GremlinGraphPropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinGraphPropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class MongoDBCollection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string collectionName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting GetDatabaseAccountMongodbDatabaseCollectionThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionRetrieveContinuousBackupInformationOperation RetrieveContinuousBackupInformation(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionRetrieveContinuousBackupInformationOperation> RetrieveContinuousBackupInformationAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBCollectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollection>, System.Collections.IEnumerable
    {
        protected MongoDBCollectionCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string collectionName, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateUpdateOptions createUpdateMongoDBCollectionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string collectionName, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateUpdateOptions createUpdateMongoDBCollectionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection> Get(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoDBCollection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoDBCollection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> GetAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection> GetIfExists(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> GetIfExistsAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBCollection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBCollection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBCollectionData : Azure.ResourceManager.Models.TrackedResource
    {
        public MongoDBCollectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionPropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionPropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class MongoDBDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBDatabase() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting GetDatabaseAccountMongodbDatabaseThroughputSetting() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionCollection GetMongoDBCollections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabase>, System.Collections.IEnumerable
    {
        protected MongoDBDatabaseCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string databaseName, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateUpdateOptions createUpdateMongoDBDatabaseParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string databaseName, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateUpdateOptions createUpdateMongoDBDatabaseParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoDBDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoDBDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBDatabaseData : Azure.ResourceManager.Models.TrackedResource
    {
        public MongoDBDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBDatabasePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBDatabasePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.CosmosDB.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.CosmosDB.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.CosmosDB.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.PrivateEndpointProperty PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.CosmosDB.PrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.PrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.PrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkResourceData : Azure.ResourceManager.Models.Resource
    {
        public PrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.CosmosDB.ClusterResourceCollection GetClusterResources(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DatabaseAccountCollection GetDatabaseAccounts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class RestorableDatabaseAccount : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDatabaseAccount() { }
        public virtual Azure.ResourceManager.CosmosDB.RestorableDatabaseAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbCollection> GetRestorableMongodbCollections(string restorableMongodbDatabaseRid = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbCollection> GetRestorableMongodbCollectionsAsync(string restorableMongodbDatabaseRid = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbDatabase> GetRestorableMongodbDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongodbDatabase> GetRestorableMongodbDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResource> GetRestorableMongodbResources(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResource> GetRestorableMongodbResourcesAsync(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer> GetRestorableSqlContainers(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer> GetRestorableSqlContainersAsync(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase> GetRestorableSqlDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase> GetRestorableSqlDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResource> GetRestorableSqlResources(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResource> GetRestorableSqlResourcesAsync(string restoreLocation = null, string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDatabaseAccountCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>, System.Collections.IEnumerable
    {
        protected RestorableDatabaseAccountCollection() { }
        public virtual Azure.Response<bool> Exists(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> Get(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>> GetAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> GetIfExists(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>> GetIfExistsAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDatabaseAccountData : Azure.ResourceManager.Models.Resource
    {
        internal RestorableDatabaseAccountData() { }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.ApiType? ApiType { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? DeletionTime { get { throw null; } }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.RestorableLocationResource> RestorableLocations { get { throw null; } }
    }
    public partial class SqlContainer : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlContainer() { }
        public virtual Azure.ResourceManager.CosmosDB.SqlContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlContainerDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlContainerDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting GetDatabaseAccountSqlDatabaseContainerThroughputSetting() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.SqlStoredProcedureCollection GetSqlStoredProcedures() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.SqlTriggerCollection GetSqlTriggers() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.SqlUserDefinedFunctionCollection GetSqlUserDefinedFunctions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlContainerRetrieveContinuousBackupInformationOperation RetrieveContinuousBackupInformation(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlContainerRetrieveContinuousBackupInformationOperation> RetrieveContinuousBackupInformationAsync(bool waitForCompletion, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlContainerCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlContainer>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlContainer>, System.Collections.IEnumerable
    {
        protected SqlContainerCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlContainerCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string containerName, Azure.ResourceManager.CosmosDB.Models.SqlContainerCreateUpdateOptions createUpdateSqlContainerParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlContainerCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string containerName, Azure.ResourceManager.CosmosDB.Models.SqlContainerCreateUpdateOptions createUpdateSqlContainerParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.SqlContainer> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.SqlContainer> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer> GetIfExists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> GetIfExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.SqlContainer> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlContainer>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.SqlContainer> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlContainer>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlContainerData : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlContainerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.SqlContainerPropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlContainerPropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class SqlDatabase : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlDatabase() { }
        public virtual Azure.ResourceManager.CosmosDB.SqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlDatabaseDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlDatabaseDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting GetDatabaseAccountSqlDatabaseThroughputSetting() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.SqlContainerCollection GetSqlContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlDatabaseCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlDatabase>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlDatabase>, System.Collections.IEnumerable
    {
        protected SqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlDatabaseCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string databaseName, Azure.ResourceManager.CosmosDB.Models.SqlDatabaseCreateUpdateOptions createUpdateSqlDatabaseParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlDatabaseCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string databaseName, Azure.ResourceManager.CosmosDB.Models.SqlDatabaseCreateUpdateOptions createUpdateSqlDatabaseParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.SqlDatabase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.SqlDatabase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.SqlDatabase> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlDatabase>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.SqlDatabase> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlDatabase>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlDatabaseData : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlDatabaseData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.SqlDatabasePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlDatabasePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class SqlStoredProcedure : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlStoredProcedure() { }
        public virtual Azure.ResourceManager.CosmosDB.SqlStoredProcedureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName, string storedProcedureName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlStoredProcedureCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>, System.Collections.IEnumerable
    {
        protected SqlStoredProcedureCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string storedProcedureName, Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureCreateUpdateOptions createUpdateSqlStoredProcedureParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string storedProcedureName, Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureCreateUpdateOptions createUpdateSqlStoredProcedureParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> Get(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> GetAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> GetIfExists(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> GetIfExistsAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.SqlStoredProcedure> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlStoredProcedureData : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlStoredProcedureData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedurePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class SqlTrigger : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlTrigger() { }
        public virtual Azure.ResourceManager.CosmosDB.SqlTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlTriggerDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlTriggerDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlTriggerCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlTrigger>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlTrigger>, System.Collections.IEnumerable
    {
        protected SqlTriggerCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlTriggerCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string triggerName, Azure.ResourceManager.CosmosDB.Models.SqlTriggerCreateUpdateOptions createUpdateSqlTriggerParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlTriggerCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string triggerName, Azure.ResourceManager.CosmosDB.Models.SqlTriggerCreateUpdateOptions createUpdateSqlTriggerParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.SqlTrigger> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.SqlTrigger> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger> GetIfExists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> GetIfExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.SqlTrigger> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlTrigger>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.SqlTrigger> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlTrigger>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlTriggerData : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlTriggerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.SqlTriggerPropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class SqlUserDefinedFunction : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlUserDefinedFunction() { }
        public virtual Azure.ResourceManager.CosmosDB.SqlUserDefinedFunctionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName, string userDefinedFunctionName) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlUserDefinedFunctionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>, System.Collections.IEnumerable
    {
        protected SqlUserDefinedFunctionCollection() { }
        public virtual Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string userDefinedFunctionName, Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionCreateUpdateOptions createUpdateSqlUserDefinedFunctionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string userDefinedFunctionName, Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionCreateUpdateOptions createUpdateSqlUserDefinedFunctionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> Get(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> GetAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> GetIfExists(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> GetIfExistsAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlUserDefinedFunctionData : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlUserDefinedFunctionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionPropertiesResource Resource { get { throw null; } set { } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetClusterResources(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.ClusterResource> GetClusterResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocationCollection GetCosmosDBLocations(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.DatabaseAccount> GetDatabaseAccounts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DatabaseAccount> GetDatabaseAccountsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> GetRestorableDatabaseAccounts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableDatabaseAccount> GetRestorableDatabaseAccountsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TenantExtensions
    {
        public static Azure.Response<bool> CheckNameExistsDatabaseAccount(this Azure.ResourceManager.Resources.Tenant tenant, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<bool>> CheckNameExistsDatabaseAccountAsync(this Azure.ResourceManager.Resources.Tenant tenant, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThroughputSettingsData : Azure.ResourceManager.Models.TrackedResource
    {
        public ThroughputSettingsData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsPropertiesResource Resource { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class AnalyticalStorageConfiguration
    {
        public AnalyticalStorageConfiguration() { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? SchemaType { get { throw null; } set { } }
    }
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
    public partial class ApiProperties
    {
        public ApiProperties() { }
        public Azure.ResourceManager.CosmosDB.Models.ServerVersion? ServerVersion { get { throw null; } set { } }
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
    public partial class AutoscaleSettings
    {
        public AutoscaleSettings() { }
        public int? MaxThroughput { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingsResource
    {
        public AutoscaleSettingsResource(int maxThroughput) { }
        public Azure.ResourceManager.CosmosDB.Models.AutoUpgradePolicyResource AutoUpgradePolicy { get { throw null; } set { } }
        public int MaxThroughput { get { throw null; } set { } }
        public int? TargetMaxThroughput { get { throw null; } }
    }
    public partial class AutoUpgradePolicyResource
    {
        public AutoUpgradePolicyResource() { }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyResource ThroughputPolicy { get { throw null; } set { } }
    }
    public partial class BackupInformation
    {
        internal BackupInformation() { }
        public Azure.ResourceManager.CosmosDB.Models.ContinuousBackupInformation ContinuousBackupInformation { get { throw null; } }
    }
    public partial class BackupPolicy
    {
        public BackupPolicy() { }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationState MigrationState { get { throw null; } set { } }
    }
    public partial class BackupPolicyMigrationState
    {
        public BackupPolicyMigrationState() { }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
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
    public partial class BaseMetric
    {
        internal BaseMetric() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.MetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
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
    public partial class Capacity
    {
        public Capacity() { }
        public int? TotalThroughputLimit { get { throw null; } set { } }
    }
    public partial class CassandraClusterPublicStatus
    {
        internal CassandraClusterPublicStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.ConnectionError> ConnectionErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatusDataCentersItem> DataCenters { get { throw null; } }
        public string ETag { get { throw null; } }
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
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class CassandraKeyspaceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.CassandraKeyspace>
    {
        protected CassandraKeyspaceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.CassandraKeyspace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraKeyspaceCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public CassandraKeyspaceCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceResource Resource { get { throw null; } set { } }
    }
    public partial class CassandraKeyspaceDeleteOperation : Azure.Operation
    {
        protected CassandraKeyspaceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraKeyspacePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public CassandraKeyspacePropertiesOptions() { }
    }
    public partial class CassandraKeyspacePropertiesResource : Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceResource
    {
        public CassandraKeyspacePropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class CassandraKeyspaceResource
    {
        public CassandraKeyspaceResource(string id) { }
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
    public partial class CassandraTableCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.CassandraTable>
    {
        protected CassandraTableCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.CassandraTable Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTable>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraTableCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public CassandraTableCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CassandraTableResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraTableResource Resource { get { throw null; } set { } }
    }
    public partial class CassandraTableDeleteOperation : Azure.Operation
    {
        protected CassandraTableDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraTablePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public CassandraTablePropertiesOptions() { }
    }
    public partial class CassandraTablePropertiesResource : Azure.ResourceManager.CosmosDB.Models.CassandraTableResource
    {
        public CassandraTablePropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class CassandraTableResource
    {
        public CassandraTableResource(string id) { }
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
    public partial class ClusterResourceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ClusterResource>
    {
        protected ClusterResourceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ClusterResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResourceDeallocateOperation : Azure.Operation
    {
        protected ClusterResourceDeallocateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResourceDeleteOperation : Azure.Operation
    {
        protected ClusterResourceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResourceInvokeCommandOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.Models.CommandOutput>
    {
        protected ClusterResourceInvokeCommandOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.Models.CommandOutput Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CommandOutput>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CommandOutput>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string DelegatedManagementSubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.Certificate> ExternalGossipCertificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.SeedNode> ExternalSeedNodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.Certificate> GossipCertificates { get { throw null; } }
        public int? HoursBetweenBackups { get { throw null; } set { } }
        public string InitialCassandraAdminPassword { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SeedNode PrometheusEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState? ProvisioningState { get { throw null; } set { } }
        public bool? RepairEnabled { get { throw null; } set { } }
        public string RestoreFromBackupId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.SeedNode> SeedNodes { get { throw null; } }
    }
    public partial class ClusterResourceStartOperation : Azure.Operation
    {
        protected ClusterResourceStartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResourceUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ClusterResource>
    {
        protected ClusterResourceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ClusterResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ClusterResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string HostID { get { throw null; } }
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
    public partial class ContinuousBackupInformation
    {
        internal ContinuousBackupInformation() { }
        public string LatestRestorableTimestamp { get { throw null; } }
    }
    public partial class ContinuousBackupRestoreLocation
    {
        public ContinuousBackupRestoreLocation() { }
        public string Location { get { throw null; } set { } }
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
    public partial class CosmosTableCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.CosmosTable>
    {
        protected CosmosTableCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.CosmosTable Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTable>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosTableDeleteOperation : Azure.Operation
    {
        protected CosmosTableDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosTablePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public CosmosTablePropertiesOptions() { }
    }
    public partial class CosmosTablePropertiesResource : Azure.ResourceManager.CosmosDB.Models.TableResource
    {
        public CosmosTablePropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CreatedByType left, Azure.ResourceManager.CosmosDB.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CreatedByType left, Azure.ResourceManager.CosmosDB.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CreateUpdateOptions
    {
        public CreateUpdateOptions() { }
        public Azure.ResourceManager.CosmosDB.Models.AutoscaleSettings AutoscaleSettings { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class DatabaseAccountCapability
    {
        public DatabaseAccountCapability() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DatabaseAccountCassandraKeyspaceTableThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>
    {
        protected DatabaseAccountCassandraKeyspaceTableThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceTableThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountCassandraKeyspaceTableThroughputSettingMigrateCassandraTableToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>
    {
        protected DatabaseAccountCassandraKeyspaceThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountCassandraKeyspaceThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountCassandraKeyspaceThroughputSettingMigrateCassandraKeyspaceToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountConnectionString
    {
        internal DatabaseAccountConnectionString() { }
        public string ConnectionString { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public partial class DatabaseAccountConnectionStringList
    {
        internal DatabaseAccountConnectionStringList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountConnectionString> ConnectionStrings { get { throw null; } }
    }
    public partial class DatabaseAccountCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccount>
    {
        protected DatabaseAccountCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccount Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public DatabaseAccountCreateUpdateOptions(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> locations) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageConfiguration AnalyticalStorageConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.Capacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public string DatabaseAccountOfferType { get { throw null; } set { } }
        public string DefaultIdentity { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableAnalyticalStorage { get { throw null; } set { } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableFreeTier { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IpAddressOrRange> IpRules { get { throw null; } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public string KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkAclBypassResourceIds { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.RestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DatabaseAccountDeleteOperation : Azure.Operation
    {
        protected DatabaseAccountDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountFailoverPriorityChangeOperation : Azure.Operation
    {
        protected DatabaseAccountFailoverPriorityChangeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseGraphThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>
    {
        protected DatabaseAccountGremlinDatabaseGraphThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseGraphThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountGremlinDatabaseGraphThroughputSettingMigrateGremlinGraphToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>
    {
        protected DatabaseAccountGremlinDatabaseThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountGremlinDatabaseThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountGremlinDatabaseThroughputSettingMigrateGremlinDatabaseToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DatabaseAccountMongodbDatabaseCollectionThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>
    {
        protected DatabaseAccountMongodbDatabaseCollectionThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseCollectionThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountMongodbDatabaseCollectionThroughputSettingMigrateMongoDBCollectionToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>
    {
        protected DatabaseAccountMongodbDatabaseThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountMongodbDatabaseThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountMongodbDatabaseThroughputSettingMigrateMongoDBDatabaseToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountOfflineRegionOperation : Azure.Operation
    {
        protected DatabaseAccountOfflineRegionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountOnlineRegionOperation : Azure.Operation
    {
        protected DatabaseAccountOnlineRegionOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountReadOnlyKeyList
    {
        internal DatabaseAccountReadOnlyKeyList() { }
        public string PrimaryReadonlyMasterKey { get { throw null; } }
        public string SecondaryReadonlyMasterKey { get { throw null; } }
    }
    public partial class DatabaseAccountRegenerateKeyOperation : Azure.Operation
    {
        protected DatabaseAccountRegenerateKeyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountRegenerateKeyOptions
    {
        public DatabaseAccountRegenerateKeyOptions(Azure.ResourceManager.CosmosDB.Models.KeyKind keyKind) { }
        public Azure.ResourceManager.CosmosDB.Models.KeyKind KeyKind { get { throw null; } }
    }
    public partial class DatabaseAccountSqlDatabaseContainerThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>
    {
        protected DatabaseAccountSqlDatabaseContainerThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseContainerThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountSqlDatabaseContainerThroughputSettingMigrateSqlContainerToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>
    {
        protected DatabaseAccountSqlDatabaseThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountSqlDatabaseThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountSqlDatabaseThroughputSettingMigrateSqlDatabaseToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountTableThroughputSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>
    {
        protected DatabaseAccountTableThroughputSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccountTableThroughputSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountTableThroughputSettingMigrateTableToAutoscaleOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountTableThroughputSettingMigrateTableToAutoscaleOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountTableThroughputSettingMigrateTableToManualThroughputOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>
    {
        protected DatabaseAccountTableThroughputSettingMigrateTableToManualThroughputOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.ThroughputSettingsData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.ThroughputSettingsData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DatabaseAccount>
    {
        protected DatabaseAccountUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DatabaseAccount Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DatabaseAccount>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseAccountUpdateOptions
    {
        public DatabaseAccountUpdateOptions() { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageConfiguration AnalyticalStorageConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.Capacity Capacity { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.IpAddressOrRange> IpRules { get { throw null; } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public string KeyVaultKeyUri { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NetworkAclBypassResourceIds { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DatabaseRestoreResource
    {
        public DatabaseRestoreResource() { }
        public System.Collections.Generic.IList<string> CollectionNames { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
    }
    public partial class DataCenterResourceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DataCenterResource>
    {
        protected DataCenterResourceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DataCenterResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCenterResourceDeleteOperation : Azure.Operation
    {
        protected DataCenterResourceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCenterResourceProperties
    {
        public DataCenterResourceProperties() { }
        public bool? AvailabilityZone { get { throw null; } set { } }
        public string BackupStorageCustomerKeyUri { get { throw null; } set { } }
        public string Base64EncodedCassandraYamlFragment { get { throw null; } set { } }
        public string DataCenterLocation { get { throw null; } set { } }
        public string DelegatedSubnetId { get { throw null; } set { } }
        public int? DiskCapacity { get { throw null; } set { } }
        public string DiskSku { get { throw null; } set { } }
        public string ManagedDiskCustomerKeyUri { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ManagedCassandraProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.SeedNode> SeedNodes { get { throw null; } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class DataCenterResourceUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.DataCenterResource>
    {
        protected DataCenterResourceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.DataCenterResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.DataCenterResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ExtendedResourceProperties
    {
        public ExtendedResourceProperties() { }
        public string Etag { get { throw null; } }
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
    public partial class GremlinDatabaseCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.GremlinDatabase>
    {
        protected GremlinDatabaseCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.GremlinDatabase Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabase>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinDatabaseCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public GremlinDatabaseCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResource Resource { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseDeleteOperation : Azure.Operation
    {
        protected GremlinDatabaseDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinDatabasePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public GremlinDatabasePropertiesOptions() { }
    }
    public partial class GremlinDatabasePropertiesResource : Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResource
    {
        public GremlinDatabasePropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class GremlinDatabaseResource
    {
        public GremlinDatabaseResource(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class GremlinGraphCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.GremlinGraph>
    {
        protected GremlinGraphCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.GremlinGraph Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraph>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinGraphCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public GremlinGraphCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.GremlinGraphResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinGraphResource Resource { get { throw null; } set { } }
    }
    public partial class GremlinGraphDeleteOperation : Azure.Operation
    {
        protected GremlinGraphDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinGraphPropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public GremlinGraphPropertiesOptions() { }
    }
    public partial class GremlinGraphPropertiesResource : Azure.ResourceManager.CosmosDB.Models.GremlinGraphResource
    {
        public GremlinGraphPropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class GremlinGraphResource
    {
        public GremlinGraphResource(string id) { }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy ConflictResolutionPolicy { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.IndexingPolicy IndexingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ContainerPartitionKey PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.UniqueKeyPolicy UniqueKeyPolicy { get { throw null; } set { } }
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
    public partial class IpAddressOrRange
    {
        public IpAddressOrRange() { }
        public string IpAddressOrRangeValue { get { throw null; } set { } }
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
    public partial class ManagedCassandraARMResourceProperties : Azure.ResourceManager.Models.TrackedResource
    {
        public ManagedCassandraARMResourceProperties(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedCassandraResourceIdentityType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedCassandraResourceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType left, Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType left, Azure.ResourceManager.CosmosDB.Models.ManagedCassandraResourceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
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
        public string ResourceUri { get { throw null; } }
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
    public partial class MongoDBCollectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.MongoDBCollection>
    {
        protected MongoDBCollectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.MongoDBCollection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBCollectionCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public MongoDBCollectionCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResource Resource { get { throw null; } set { } }
    }
    public partial class MongoDBCollectionDeleteOperation : Azure.Operation
    {
        protected MongoDBCollectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBCollectionPropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public MongoDBCollectionPropertiesOptions() { }
    }
    public partial class MongoDBCollectionPropertiesResource : Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResource
    {
        public MongoDBCollectionPropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class MongoDBCollectionResource
    {
        public MongoDBCollectionResource(string id) { }
        public int? AnalyticalStorageTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoIndex> Indexes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ShardKey { get { throw null; } }
    }
    public partial class MongoDBCollectionRetrieveContinuousBackupInformationOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.Models.BackupInformation>
    {
        protected MongoDBCollectionRetrieveContinuousBackupInformationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.Models.BackupInformation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.Models.BackupInformation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.Models.BackupInformation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBDatabaseCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.MongoDBDatabase>
    {
        protected MongoDBDatabaseCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.MongoDBDatabase Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabase>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBDatabaseCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public MongoDBDatabaseCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResource Resource { get { throw null; } set { } }
    }
    public partial class MongoDBDatabaseDeleteOperation : Azure.Operation
    {
        protected MongoDBDatabaseDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBDatabasePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public MongoDBDatabasePropertiesOptions() { }
    }
    public partial class MongoDBDatabasePropertiesResource : Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResource
    {
        public MongoDBDatabasePropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class MongoDBDatabaseResource
    {
        public MongoDBDatabaseResource(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class MongoIndex
    {
        public MongoIndex() { }
        public Azure.ResourceManager.CosmosDB.Models.MongoIndexKeys Key { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoIndexOptions Options { get { throw null; } set { } }
    }
    public partial class MongoIndexKeys
    {
        public MongoIndexKeys() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
    }
    public partial class MongoIndexOptions
    {
        public MongoIndexOptions() { }
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
    public partial class OptionsResource
    {
        public OptionsResource() { }
        public Azure.ResourceManager.CosmosDB.Models.AutoscaleSettings AutoscaleSettings { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
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
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.PercentileMetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
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
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointProperty
    {
        public PrivateEndpointProperty() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class PrivateLinkServiceConnectionStateProperty
    {
        public PrivateLinkServiceConnectionStateProperty() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
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
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public partial class RestorableLocationResource
    {
        internal RestorableLocationResource() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? DeletionTime { get { throw null; } }
        public string LocationName { get { throw null; } }
        public string RegionalDatabaseAccountInstanceId { get { throw null; } }
    }
    public partial class RestorableMongodbCollection : Azure.ResourceManager.Models.Resource
    {
        internal RestorableMongodbCollection() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableMongodbCollectionPropertiesResource Resource { get { throw null; } }
    }
    public partial class RestorableMongodbCollectionPropertiesResource
    {
        internal RestorableMongodbCollectionPropertiesResource() { }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class RestorableMongodbDatabase : Azure.ResourceManager.Models.Resource
    {
        internal RestorableMongodbDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableMongodbDatabasePropertiesResource Resource { get { throw null; } }
    }
    public partial class RestorableMongodbDatabasePropertiesResource
    {
        internal RestorableMongodbDatabasePropertiesResource() { }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class RestorableSqlContainer : Azure.ResourceManager.Models.Resource
    {
        internal RestorableSqlContainer() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainerPropertiesResource Resource { get { throw null; } }
    }
    public partial class RestorableSqlContainerPropertiesResource
    {
        internal RestorableSqlContainerPropertiesResource() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainerPropertiesResourceContainer Container { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class RestorableSqlContainerPropertiesResourceContainer : Azure.ResourceManager.CosmosDB.Models.SqlContainerResource
    {
        public RestorableSqlContainerPropertiesResourceContainer(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public string Self { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class RestorableSqlDatabase : Azure.ResourceManager.Models.Resource
    {
        internal RestorableSqlDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabasePropertiesResource Resource { get { throw null; } }
    }
    public partial class RestorableSqlDatabasePropertiesResource
    {
        internal RestorableSqlDatabasePropertiesResource() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabasePropertiesResourceDatabase Database { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.OperationType? OperationType { get { throw null; } }
        public string OwnerId { get { throw null; } }
        public string OwnerResourceId { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class RestorableSqlDatabasePropertiesResourceDatabase : Azure.ResourceManager.CosmosDB.Models.SqlDatabaseResource
    {
        public RestorableSqlDatabasePropertiesResourceDatabase(string id) : base (default(string)) { }
        public string Colls { get { throw null; } }
        public string Etag { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResource> DatabasesToRestore { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.RestoreMode? RestoreMode { get { throw null; } set { } }
        public string RestoreSource { get { throw null; } set { } }
        public System.DateTimeOffset? RestoreTimestampInUtc { get { throw null; } set { } }
    }
    public partial class SeedNode
    {
        public SeedNode() { }
        public string IpAddress { get { throw null; } set { } }
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
    public partial class SqlContainerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.SqlContainer>
    {
        protected SqlContainerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.SqlContainer Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlContainer>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlContainerCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlContainerCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.SqlContainerResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlContainerResource Resource { get { throw null; } set { } }
    }
    public partial class SqlContainerDeleteOperation : Azure.Operation
    {
        protected SqlContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlContainerPropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public SqlContainerPropertiesOptions() { }
    }
    public partial class SqlContainerPropertiesResource : Azure.ResourceManager.CosmosDB.Models.SqlContainerResource
    {
        public SqlContainerPropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class SqlContainerResource
    {
        public SqlContainerResource(string id) { }
        public long? AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy ConflictResolutionPolicy { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.IndexingPolicy IndexingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ContainerPartitionKey PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.UniqueKeyPolicy UniqueKeyPolicy { get { throw null; } set { } }
    }
    public partial class SqlContainerRetrieveContinuousBackupInformationOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.Models.BackupInformation>
    {
        protected SqlContainerRetrieveContinuousBackupInformationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.Models.BackupInformation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.Models.BackupInformation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.Models.BackupInformation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlDatabaseCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.SqlDatabase>
    {
        protected SqlDatabaseCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.SqlDatabase Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlDatabase>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlDatabaseCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlDatabaseCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.SqlDatabaseResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlDatabaseResource Resource { get { throw null; } set { } }
    }
    public partial class SqlDatabaseDeleteOperation : Azure.Operation
    {
        protected SqlDatabaseDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlDatabasePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.OptionsResource
    {
        public SqlDatabasePropertiesOptions() { }
    }
    public partial class SqlDatabasePropertiesResource : Azure.ResourceManager.CosmosDB.Models.SqlDatabaseResource
    {
        public SqlDatabasePropertiesResource(string id) : base (default(string)) { }
        public string Colls { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
        public string Users { get { throw null; } set { } }
    }
    public partial class SqlDatabaseResource
    {
        public SqlDatabaseResource(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class SqlStoredProcedureCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>
    {
        protected SqlStoredProcedureCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.SqlStoredProcedure Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlStoredProcedure>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlStoredProcedureCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlStoredProcedureCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureResource Resource { get { throw null; } set { } }
    }
    public partial class SqlStoredProcedureDeleteOperation : Azure.Operation
    {
        protected SqlStoredProcedureDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlStoredProcedurePropertiesResource : Azure.ResourceManager.CosmosDB.Models.SqlStoredProcedureResource
    {
        public SqlStoredProcedurePropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class SqlStoredProcedureResource
    {
        public SqlStoredProcedureResource(string id) { }
        public string Body { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class SqlTriggerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.SqlTrigger>
    {
        protected SqlTriggerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.SqlTrigger Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlTrigger>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlTriggerCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlTriggerCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.SqlTriggerResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlTriggerResource Resource { get { throw null; } set { } }
    }
    public partial class SqlTriggerDeleteOperation : Azure.Operation
    {
        protected SqlTriggerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlTriggerPropertiesResource : Azure.ResourceManager.CosmosDB.Models.SqlTriggerResource
    {
        public SqlTriggerPropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class SqlTriggerResource
    {
        public SqlTriggerResource(string id) { }
        public string Body { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.TriggerOperation? TriggerOperation { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.TriggerType? TriggerType { get { throw null; } set { } }
    }
    public partial class SqlUserDefinedFunctionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>
    {
        protected SqlUserDefinedFunctionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.CosmosDB.SqlUserDefinedFunction>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlUserDefinedFunctionCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public SqlUserDefinedFunctionCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionResource Resource { get { throw null; } set { } }
    }
    public partial class SqlUserDefinedFunctionDeleteOperation : Azure.Operation
    {
        protected SqlUserDefinedFunctionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlUserDefinedFunctionPropertiesResource : Azure.ResourceManager.CosmosDB.Models.SqlUserDefinedFunctionResource
    {
        public SqlUserDefinedFunctionPropertiesResource(string id) : base (default(string)) { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class SqlUserDefinedFunctionResource
    {
        public SqlUserDefinedFunctionResource(string id) { }
        public string Body { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class TableCreateUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public TableCreateUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.TableResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.CreateUpdateOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.TableResource Resource { get { throw null; } set { } }
    }
    public partial class TableResource
    {
        public TableResource(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class ThroughputPolicyResource
    {
        public ThroughputPolicyResource() { }
        public int? IncrementPercent { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class ThroughputSettingsPropertiesResource : Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResource
    {
        public ThroughputSettingsPropertiesResource() { }
        public string Etag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Ts { get { throw null; } }
    }
    public partial class ThroughputSettingsResource
    {
        public ThroughputSettingsResource() { }
        public Azure.ResourceManager.CosmosDB.Models.AutoscaleSettingsResource AutoscaleSettings { get { throw null; } set { } }
        public string MinimumThroughput { get { throw null; } }
        public string OfferReplacePending { get { throw null; } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class ThroughputSettingsUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public ThroughputSettingsUpdateOptions(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResource resource) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResource Resource { get { throw null; } set { } }
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
    public partial class UniqueKeyPolicy
    {
        public UniqueKeyPolicy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.UniqueKey> UniqueKeys { get { throw null; } }
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
