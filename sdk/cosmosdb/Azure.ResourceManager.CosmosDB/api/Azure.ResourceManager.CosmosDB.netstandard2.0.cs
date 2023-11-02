namespace Azure.ResourceManager.CosmosDB
{
    public partial class CassandraClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraClusterResource>, System.Collections.IEnumerable
    {
        protected CassandraClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDB.CassandraClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDB.CassandraClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraClusterProperties Properties { get { throw null; } set { } }
    }
    public partial class CassandraClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraClusterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, bool? xMsForceDeallocate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, bool? xMsForceDeallocate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupResourceInfo> GetBackup(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupResourceInfo>> GetBackupAsync(string backupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupResourceInfo> GetBackups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupResourceInfo> GetBackupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> GetCassandraDataCenter(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>> GetCassandraDataCenterAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraDataCenterCollection GetCassandraDataCenters() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CassandraCommandOutput> InvokeCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraCommandPostBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CassandraCommandOutput>> InvokeCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraCommandPostBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus> Status(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus>> StatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CassandraClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CassandraClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraDataCenterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>, System.Collections.IEnumerable
    {
        protected CassandraDataCenterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataCenterName, Azure.ResourceManager.CosmosDB.CassandraDataCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataCenterName, Azure.ResourceManager.CosmosDB.CassandraDataCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> Get(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>> GetAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> GetIfExists(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>> GetIfExistsAsync(string dataCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraDataCenterData : Azure.ResourceManager.Models.ResourceData
    {
        public CassandraDataCenterData() { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterProperties Properties { get { throw null; } set { } }
    }
    public partial class CassandraDataCenterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraDataCenterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraDataCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string dataCenterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CassandraDataCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraDataCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CassandraDataCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> GetIfExists(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> GetIfExistsAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraKeyspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraKeyspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource GetCassandraKeyspaceThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> GetCassandraTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> GetCassandraTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableCollection GetCassandraTables() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> GetCassandraViewGetResult(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> GetCassandraViewGetResultAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraViewGetResultCollection GetCassandraViewGetResults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraKeyspaceThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraKeyspaceThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> MigrateCassandraKeyspaceToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> MigrateCassandraKeyspaceToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> MigrateCassandraKeyspaceToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> MigrateCassandraKeyspaceToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraTableResource> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraTableResource>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraTableData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraTableData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource GetCassandraTableThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraTableThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraTableThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> MigrateCassandraTableToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> MigrateCassandraTableToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> MigrateCassandraTableToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> MigrateCassandraTableToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraViewGetResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>, System.Collections.IEnumerable
    {
        protected CassandraViewGetResultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CosmosDB.Models.CassandraViewGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CosmosDB.Models.CassandraViewGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> Get(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> GetAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> GetIfExists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> GetIfExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CassandraViewGetResultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraViewGetResultData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraViewGetPropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraViewGetPropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class CassandraViewGetResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraViewGetResultResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraViewGetResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string viewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource GetCassandraViewThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraViewGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CassandraViewGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CassandraViewThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CassandraViewThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string keyspaceName, string viewName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> MigrateCassandraViewToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> MigrateCassandraViewToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> MigrateCassandraViewToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> MigrateCassandraViewToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>, System.Collections.IEnumerable
    {
        protected CosmosDBAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion? ApiServerVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCapability> Capabilities { get { throw null; } }
        public int? CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus? CustomerManagedKeyStatus { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType? DatabaseAccountOfferType { get { throw null; } }
        public string DefaultIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel? DefaultPriorityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery? DiagnosticLogEnableFullTextQuery { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string DocumentEndpoint { get { throw null; } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableBurstCapacity { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableMaterializedViews { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public bool? EnablePartitionMerge { get { throw null; } set { } }
        public bool? EnablePriorityBasedExecution { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicy> FailoverPolicies { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? InstanceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBIPAddressOrRange> IPRules { get { throw null; } }
        public bool? IsAnalyticalStorageEnabled { get { throw null; } set { } }
        public bool? IsFreeTierEnabled { get { throw null; } set { } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeysMetadata KeysMetadata { get { throw null; } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> NetworkAclBypassResourceIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> ReadLocations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> WriteLocations { get { throw null; } }
    }
    public partial class CosmosDBAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBAccountResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FailoverPriorityChange(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicies failoverParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverPriorityChangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicies failoverParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource> GetCassandraKeyspace(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource>> GetCassandraKeyspaceAsync(string keyspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceCollection GetCassandraKeyspaces() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountConnectionString> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountConnectionString> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> GetCosmosDBPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> GetCosmosDBPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionCollection GetCosmosDBPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> GetCosmosDBPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>> GetCosmosDBPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResourceCollection GetCosmosDBPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> GetCosmosDBService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>> GetCosmosDBServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBServiceCollection GetCosmosDBServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> GetCosmosDBSqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> GetCosmosDBSqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseCollection GetCosmosDBSqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> GetCosmosDBSqlRoleAssignment(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> GetCosmosDBSqlRoleAssignmentAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentCollection GetCosmosDBSqlRoleAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> GetCosmosDBSqlRoleDefinition(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> GetCosmosDBSqlRoleDefinitionAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionCollection GetCosmosDBSqlRoleDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> GetCosmosDBTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> GetCosmosDBTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBTableCollection GetCosmosDBTables() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> GetDataTransferJobGetResult(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> GetDataTransferJobGetResultAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DataTransferJobGetResultCollection GetDataTransferJobGetResults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> GetGraphResourceGetResult(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> GetGraphResourceGetResultAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GraphResourceGetResultCollection GetGraphResourceGetResults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> GetGremlinDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> GetGremlinDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseCollection GetGremlinDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyList> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyList>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition> GetMetricDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition> GetMetricDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition> GetMetricDefinitionsCollections(string databaseRid, string collectionRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition> GetMetricDefinitionsCollectionsAsync(string databaseRid, string collectionRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition> GetMetricDefinitionsDatabases(string databaseRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition> GetMetricDefinitionsDatabasesAsync(string databaseRid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetrics(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitionRegions(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitionRegionsAsync(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitions(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsCollectionPartitionsAsync(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsCollectionRegions(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsCollectionRegionsAsync(string region, string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsCollections(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsCollectionsAsync(string databaseRid, string collectionRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsDatabaseAccountRegions(string region, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsDatabaseAccountRegionsAsync(string region, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsDatabases(string databaseRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric> GetMetricsDatabasesAsync(string databaseRid, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIdRegions(string region, string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIdRegionsAsync(string region, string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIds(string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionMetric> GetMetricsPartitionKeyRangeIdsAsync(string databaseRid, string collectionRid, string partitionKeyRangeId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric> GetMetricsPercentiles(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric> GetMetricsPercentilesAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric> GetMetricsPercentileSourceTargets(string sourceRegion, string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric> GetMetricsPercentileSourceTargetsAsync(string sourceRegion, string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric> GetMetricsPercentileTargets(string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric> GetMetricsPercentileTargetsAsync(string targetRegion, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> GetMongoDBDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> GetMongoDBDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseCollection GetMongoDBDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> GetMongoDBRoleDefinition(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>> GetMongoDBRoleDefinitionAsync(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionCollection GetMongoDBRoleDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> GetMongoDBUserDefinition(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>> GetMongoDBUserDefinitionAsync(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionCollection GetMongoDBUserDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountReadOnlyKeyList> GetReadOnlyKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountReadOnlyKeyList>> GetReadOnlyKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.PartitionUsage> GetUsagesCollectionPartitions(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.PartitionUsage> GetUsagesCollectionPartitionsAsync(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage> GetUsagesCollections(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage> GetUsagesCollectionsAsync(string databaseRid, string collectionRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage> GetUsagesDatabases(string databaseRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage> GetUsagesDatabasesAsync(string databaseRid, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation OfflineRegion(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOffline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> OfflineRegionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOffline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation OnlineRegion(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOnline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> OnlineRegionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RegionForOnlineOffline regionParameterForOnline, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CosmosDBExtensions
    {
        public static Azure.Response<bool> CheckNameExistsDatabaseAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<bool>> CheckNameExistsDatabaseAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetCassandraCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> GetCassandraClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraClusterResource GetCassandraClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraClusterCollection GetCassandraClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetCassandraClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetCassandraClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraDataCenterResource GetCassandraDataCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource GetCassandraKeyspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource GetCassandraKeyspaceThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraTableResource GetCassandraTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource GetCassandraTableThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource GetCassandraViewGetResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource GetCassandraViewThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetCosmosDBAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> GetCosmosDBAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBAccountResource GetCosmosDBAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBAccountCollection GetCosmosDBAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetCosmosDBAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetCosmosDBAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource GetCosmosDBFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> GetCosmosDBLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetCosmosDBLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocationResource GetCosmosDBLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocationCollection GetCosmosDBLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource GetCosmosDBPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource GetCosmosDBPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBServiceResource GetCosmosDBServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource GetCosmosDBSqlClientEncryptionKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource GetCosmosDBSqlContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource GetCosmosDBSqlContainerThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource GetCosmosDBSqlDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource GetCosmosDBSqlDatabaseThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource GetCosmosDBSqlRoleAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource GetCosmosDBSqlRoleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource GetCosmosDBSqlStoredProcedureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource GetCosmosDBSqlTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource GetCosmosDBSqlUserDefinedFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBTableResource GetCosmosDBTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource GetCosmosTableThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource GetDataTransferJobGetResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource GetGraphResourceGetResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinDatabaseResource GetGremlinDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource GetGremlinDatabaseThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinGraphResource GetGremlinGraphResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource GetGremlinGraphThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetMongoCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> GetMongoClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoClusterResource GetMongoClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoClusterCollection GetMongoClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetMongoClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetMongoClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBCollectionResource GetMongoDBCollectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource GetMongoDBCollectionThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource GetMongoDBDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource GetMongoDBDatabaseThroughputSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource GetMongoDBRoleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource GetMongoDBUserDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource GetRestorableCosmosDBAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetRestorableCosmosDBAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetRestorableCosmosDBAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected CosmosDBFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBFirewallRuleData(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class CosmosDBFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBFirewallRuleResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> GetIfExists(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBLocationData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBLocationData() { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBLocationProperties Properties { get { throw null; } set { } }
    }
    public partial class CosmosDBLocationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBLocationResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.CheckCosmosDBNameAvailabilityResponse> CheckMongoClusterNameAailability(Azure.ResourceManager.CosmosDB.Models.CheckCosmosDBNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.CheckCosmosDBNameAvailabilityResponse>> CheckMongoClusterNameAailabilityAsync(Azure.ResourceManager.CosmosDB.Models.CheckCosmosDBNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetRestorableCosmosDBAccount(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>> GetRestorableCosmosDBAccountAsync(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountCollection GetRestorableCosmosDBAccounts() { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CosmosDBServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>, System.Collections.IEnumerable
    {
        protected CosmosDBServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBServiceData() { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class CosmosDBServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBServiceResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlClientEncryptionKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>, System.Collections.IEnumerable
    {
        protected CosmosDBSqlClientEncryptionKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clientEncryptionKeyName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clientEncryptionKeyName, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> Get(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>> GetAsync(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> GetIfExists(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>> GetIfExistsAsync(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlClientEncryptionKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBSqlClientEncryptionKeyData() { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyProperties Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlClientEncryptionKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlClientEncryptionKeyResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string clientEncryptionKeyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> GetIfExists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> GetIfExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlContainerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource GetCosmosDBSqlContainerThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> GetCosmosDBSqlStoredProcedure(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> GetCosmosDBSqlStoredProcedureAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureCollection GetCosmosDBSqlStoredProcedures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> GetCosmosDBSqlTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> GetCosmosDBSqlTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerCollection GetCosmosDBSqlTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> GetCosmosDBSqlUserDefinedFunction(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> GetCosmosDBSqlUserDefinedFunctionAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionCollection GetCosmosDBSqlUserDefinedFunctions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection> GetSqlContainerPartitionMerge(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection>> GetSqlContainerPartitionMergeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation> RetrieveContinuousBackupInformation(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation>> RetrieveContinuousBackupInformationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlContainerThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlContainerThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string containerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> MigrateSqlContainerToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> MigrateSqlContainerToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> MigrateSqlContainerToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> MigrateSqlContainerToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> SqlContainerRedistributeThroughput(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> SqlContainerRedistributeThroughputAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> SqlContainerRetrieveThroughputDistribution(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> SqlContainerRetrieveThroughputDistributionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlDatabaseData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource> GetCosmosDBSqlClientEncryptionKey(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource>> GetCosmosDBSqlClientEncryptionKeyAsync(string clientEncryptionKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyCollection GetCosmosDBSqlClientEncryptionKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource> GetCosmosDBSqlContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource>> GetCosmosDBSqlContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerCollection GetCosmosDBSqlContainers() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource GetCosmosDBSqlDatabaseThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection> SqlDatabasePartitionMerge(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection>> SqlDatabasePartitionMergeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBSqlDatabaseThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBSqlDatabaseThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> MigrateSqlDatabaseToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> MigrateSqlDatabaseToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> MigrateSqlDatabaseToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> MigrateSqlDatabaseToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> SqlDatabaseRedistributeThroughput(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> SqlDatabaseRedistributeThroughputAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> SqlDatabaseRetrieveThroughputDistribution(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> SqlDatabaseRetrieveThroughputDistributionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> GetIfExists(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>> GetIfExistsAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlRoleAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBSqlRoleAssignmentData() { }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> GetIfExists(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>> GetIfExistsAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlRoleDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBSqlRoleDefinitionData() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRolePermission> Permissions { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionType? RoleDefinitionType { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> GetIfExists(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>> GetIfExistsAsync(string storedProcedureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlStoredProcedureData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlStoredProcedureData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> GetIfExists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>> GetIfExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlTriggerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlTriggerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> GetIfExists(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>> GetIfExistsAsync(string userDefinedFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBSqlUserDefinedFunctionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlUserDefinedFunctionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
    public partial class CosmosDBTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>, System.Collections.IEnumerable
    {
        protected CosmosDBTableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.CosmosDB.Models.CosmosDBTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.CosmosDB.Models.CosmosDBTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBTableData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBTableData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBTablePropertiesOptions Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBTablePropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBTableResource() { }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource GetCosmosTableThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation> RetrieveContinuousBackupInformation(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation>> RetrieveContinuousBackupInformationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBTableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosDBTableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.CosmosDBTableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosTableThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosTableThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> MigrateTableToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> MigrateTableToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> MigrateTableToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> MigrateTableToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataTransferJobGetResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>, System.Collections.IEnumerable
    {
        protected DataTransferJobGetResultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.CosmosDB.Models.DataTransferJobGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.CosmosDB.Models.DataTransferJobGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataTransferJobGetResultData : Azure.ResourceManager.Models.ResourceData
    {
        public DataTransferJobGetResultData() { }
        public Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink Destination { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ErrorResponse Error { get { throw null; } }
        public string JobName { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedUtcOn { get { throw null; } }
        public long? ProcessedCount { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink Source { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public int? WorkerCount { get { throw null; } set { } }
    }
    public partial class DataTransferJobGetResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataTransferJobGetResultResource() { }
        public virtual Azure.ResourceManager.CosmosDB.DataTransferJobGetResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> Pause(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> PauseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> Resume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> ResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.DataTransferJobGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.DataTransferJobGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GraphResourceGetResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>, System.Collections.IEnumerable
    {
        protected GraphResourceGetResultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string graphName, Azure.ResourceManager.CosmosDB.Models.GraphResourceGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string graphName, Azure.ResourceManager.CosmosDB.Models.GraphResourceGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> Get(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> GetAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> GetIfExists(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> GetIfExistsAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GraphResourceGetResultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GraphResourceGetResultData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GraphResourceGetPropertiesOptions Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class GraphResourceGetResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GraphResourceGetResultResource() { }
        public virtual Azure.ResourceManager.CosmosDB.GraphResourceGetResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string graphName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GraphResourceGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GraphResourceGetResultCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GremlinDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinDatabaseData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource GetGremlinDatabaseThroughputSetting() { throw null; }
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
    public partial class GremlinDatabaseThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GremlinDatabaseThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> MigrateGremlinDatabaseToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> MigrateGremlinDatabaseToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> MigrateGremlinDatabaseToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> MigrateGremlinDatabaseToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.GremlinGraphResource> GetIfExists(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> GetIfExistsAsync(string graphName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.GremlinGraphResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraphResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.GremlinGraphResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.GremlinGraphResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GremlinGraphData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinGraphData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource GetGremlinGraphThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation> RetrieveContinuousBackupInformation(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation>> RetrieveContinuousBackupInformationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GremlinGraphThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GremlinGraphThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string graphName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> MigrateGremlinGraphToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> MigrateGremlinGraphToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> MigrateGremlinGraphToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> MigrateGremlinGraphToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoClusterResource>, System.Collections.IEnumerable
    {
        protected MongoClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mongoClusterName, Azure.ResourceManager.CosmosDB.MongoClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mongoClusterName, Azure.ResourceManager.CosmosDB.MongoClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> Get(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> GetAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetIfExists(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoClusterResource>> GetIfExistsAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoClusterData(Azure.Core.AzureLocation location) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus? ClusterStatus { get { throw null; } }
        public string ConnectionString { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public string EarliestRestoreTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.NodeGroupSpec> NodeGroupSpecs { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MongoClusterRestoreParameters RestoreParameters { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
    }
    public partial class MongoClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoClusterResource() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.Models.ListConnectionStringsResult> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.Models.ListConnectionStringsResult>> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource> GetCosmosDBFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource>> GetCosmosDBFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleCollection GetCosmosDBFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> GetIfExists(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> GetIfExistsAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBCollectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBCollectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection> GetMongoDBCollectionPartitionMerge(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection>> GetMongoDBCollectionPartitionMergeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource GetMongoDBCollectionThroughputSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation> RetrieveContinuousBackupInformation(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation>> RetrieveContinuousBackupInformationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ContinuousBackupRestoreLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBCollectionThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBCollectionThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName, string collectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> MigrateMongoDBCollectionToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> MigrateMongoDBCollectionToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> MigrateMongoDBCollectionToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> MigrateMongoDBCollectionToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> MongoDBContainerRedistributeThroughput(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> MongoDBContainerRedistributeThroughputAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> MongoDBContainerRetrieveThroughputDistribution(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> MongoDBContainerRetrieveThroughputDistributionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBDatabaseData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBDatabaseData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource> GetMongoDBCollection(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBCollectionResource>> GetMongoDBCollectionAsync(string collectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionCollection GetMongoDBCollections() { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource GetMongoDBDatabaseThroughputSetting() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection> MongoDBDatabasePartitionMerge(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection>> MongoDBDatabasePartitionMergeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MergeParameters mergeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBDatabaseThroughputSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBDatabaseThroughputSettingResource() { }
        public virtual Azure.ResourceManager.CosmosDB.ThroughputSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string databaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> MigrateMongoDBDatabaseToAutoscale(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> MigrateMongoDBDatabaseToAutoscaleAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> MigrateMongoDBDatabaseToManualThroughput(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> MigrateMongoDBDatabaseToManualThroughputAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> MongoDBDatabaseRedistributeThroughput(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> MongoDBDatabaseRedistributeThroughputAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters redistributeThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult> MongoDBDatabaseRetrieveThroughputDistribution(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult>> MongoDBDatabaseRetrieveThroughputDistributionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters retrieveThroughputParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBRoleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>, System.Collections.IEnumerable
    {
        protected MongoDBRoleDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mongoRoleDefinitionId, Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mongoRoleDefinitionId, Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> Get(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>> GetAsync(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> GetIfExists(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>> GetIfExistsAsync(string mongoRoleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBRoleDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public MongoDBRoleDefinitionData() { }
        public string DatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBPrivilege> Privileges { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionType? RoleDefinitionType { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBRole> Roles { get { throw null; } }
    }
    public partial class MongoDBRoleDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBRoleDefinitionResource() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string mongoRoleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBUserDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>, System.Collections.IEnumerable
    {
        protected MongoDBUserDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mongoUserDefinitionId, Azure.ResourceManager.CosmosDB.Models.MongoDBUserDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mongoUserDefinitionId, Azure.ResourceManager.CosmosDB.Models.MongoDBUserDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> Get(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>> GetAsync(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> GetIfExists(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>> GetIfExistsAsync(string mongoUserDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBUserDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public MongoDBUserDefinitionData() { }
        public string CustomData { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Mechanisms { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBRole> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class MongoDBUserDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBUserDefinitionResource() { }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string mongoUserDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBUserDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDB.Models.MongoDBUserDefinitionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableCosmosDBAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>, System.Collections.IEnumerable
    {
        protected RestorableCosmosDBAccountCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> Get(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>> GetAsync(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetIfExists(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>> GetIfExistsAsync(System.Guid instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableCosmosDBAccountData : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableCosmosDBAccountData() { }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType? ApiType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? OldestRestorableOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.RestorableLocationResourceInfo> RestorableLocations { get { throw null; } }
    }
    public partial class RestorableCosmosDBAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableCosmosDBAccountResource() { }
        public virtual Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, System.Guid instanceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBResourceData> GetAllRestorableMongoDBResourceData(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBResourceData> GetAllRestorableMongoDBResourceDataAsync(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlResourceData> GetAllRestorableSqlResourceData(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlResourceData> GetAllRestorableSqlResourceDataAsync(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableGremlinDatabase> GetRestorableGremlinDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableGremlinDatabase> GetRestorableGremlinDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableGremlinGraph> GetRestorableGremlinGraphs(string restorableGremlinDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableGremlinGraph> GetRestorableGremlinGraphsAsync(string restorableGremlinDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableGremlinResourceData> GetRestorableGremlinResources(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableGremlinResourceData> GetRestorableGremlinResourcesAsync(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBCollection> GetRestorableMongoDBCollections(string restorableMongoDBDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBCollection> GetRestorableMongoDBCollections(string restorableMongoDBDatabaseRid, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBCollection> GetRestorableMongoDBCollectionsAsync(string restorableMongoDBDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBCollection> GetRestorableMongoDBCollectionsAsync(string restorableMongoDBDatabaseRid, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBDatabase> GetRestorableMongoDBDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBDatabase> GetRestorableMongoDBDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This function is obsolete and will be removed in a future release.", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableMongoDBResources(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This function is obsolete and will be removed in a future release.", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableMongoDBResourcesAsync(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer> GetRestorableSqlContainers(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer> GetRestorableSqlContainersAsync(string restorableSqlDatabaseRid = null, string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase> GetRestorableSqlDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase> GetRestorableSqlDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This function is obsolete and will be removed in a future release.", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableSqlResources(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This function is obsolete and will be removed in a future release.", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> GetRestorableSqlResourcesAsync(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableTableResourceData> GetRestorableTableResources(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableTableResourceData> GetRestorableTableResourcesAsync(Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), string restoreTimestampInUtc = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.Models.RestorableTable> GetRestorableTables(string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.Models.RestorableTable> GetRestorableTablesAsync(string startTime = null, string endTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThroughputSettingData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ThroughputSettingData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedThroughputSettingsResourceInfo Resource { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.CosmosDB.Mocking
{
    public partial class MockableCosmosDBArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBArmClient() { }
        public virtual Azure.ResourceManager.CosmosDB.CassandraClusterResource GetCassandraClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraDataCenterResource GetCassandraDataCenterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceResource GetCassandraKeyspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraKeyspaceThroughputSettingResource GetCassandraKeyspaceThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableResource GetCassandraTableResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraTableThroughputSettingResource GetCassandraTableThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraViewGetResultResource GetCassandraViewGetResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraViewThroughputSettingResource GetCassandraViewThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBAccountResource GetCosmosDBAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleResource GetCosmosDBFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBLocationResource GetCosmosDBLocationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionResource GetCosmosDBPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResource GetCosmosDBPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBServiceResource GetCosmosDBServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyResource GetCosmosDBSqlClientEncryptionKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerResource GetCosmosDBSqlContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerThroughputSettingResource GetCosmosDBSqlContainerThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseResource GetCosmosDBSqlDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseThroughputSettingResource GetCosmosDBSqlDatabaseThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentResource GetCosmosDBSqlRoleAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionResource GetCosmosDBSqlRoleDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureResource GetCosmosDBSqlStoredProcedureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerResource GetCosmosDBSqlTriggerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionResource GetCosmosDBSqlUserDefinedFunctionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBTableResource GetCosmosDBTableResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosTableThroughputSettingResource GetCosmosTableThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.DataTransferJobGetResultResource GetDataTransferJobGetResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GraphResourceGetResultResource GetGraphResourceGetResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseResource GetGremlinDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinDatabaseThroughputSettingResource GetGremlinDatabaseThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphResource GetGremlinGraphResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.GremlinGraphThroughputSettingResource GetGremlinGraphThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoClusterResource GetMongoClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionResource GetMongoDBCollectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBCollectionThroughputSettingResource GetMongoDBCollectionThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseResource GetMongoDBDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBDatabaseThroughputSettingResource GetMongoDBDatabaseThroughputSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionResource GetMongoDBRoleDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionResource GetMongoDBUserDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource GetRestorableCosmosDBAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCosmosDBResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetCassandraCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CassandraClusterResource>> GetCassandraClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CassandraClusterCollection GetCassandraClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetCosmosDBAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource>> GetCosmosDBAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBAccountCollection GetCosmosDBAccounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetMongoCluster(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.MongoClusterResource>> GetMongoClusterAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.MongoClusterCollection GetMongoClusters() { throw null; }
    }
    public partial class MockableCosmosDBSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetCassandraClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CassandraClusterResource> GetCassandraClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetCosmosDBAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.CosmosDBAccountResource> GetCosmosDBAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource> GetCosmosDBLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDB.CosmosDBLocationResource>> GetCosmosDBLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDB.CosmosDBLocationCollection GetCosmosDBLocations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetMongoClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.MongoClusterResource> GetMongoClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetRestorableCosmosDBAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountResource> GetRestorableCosmosDBAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableCosmosDBTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBTenantResource() { }
        public virtual Azure.Response<bool> CheckNameExistsDatabaseAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckNameExistsDatabaseAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmCosmosDBModelFactory
    {
        public static Azure.ResourceManager.CosmosDB.Models.AutoscaleSettingsResourceInfo AutoscaleSettingsResourceInfo(int maxThroughput = 0, Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyResourceInfo autoUpgradeThroughputPolicy = null, int? targetMaxThroughput = default(int?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupResourceInfo CassandraClusterBackupResourceInfo(string backupId = null, Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState? backupState = default(Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState?), System.DateTimeOffset? backupStartTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? backupStopTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? backupExpiryTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraClusterData CassandraClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CassandraClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterDataCenterNodeItem CassandraClusterDataCenterNodeItem(string address = null, Azure.ResourceManager.CosmosDB.Models.CassandraNodeState? state = default(Azure.ResourceManager.CosmosDB.Models.CassandraNodeState?), string status = null, string cassandraProcessStatus = null, string load = null, System.Collections.Generic.IEnumerable<string> tokens = null, int? size = default(int?), System.Guid? hostId = default(System.Guid?), string rack = null, string timestamp = null, long? diskUsedKB = default(long?), long? diskFreeKB = default(long?), long? memoryUsedKB = default(long?), long? memoryBuffersAndCachedKB = default(long?), long? memoryFreeKB = default(long?), long? memoryTotalKB = default(long?), double? cpuUsage = default(double?), bool? isLatestModel = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterProperties CassandraClusterProperties(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState?), string restoreFromBackupId = null, Azure.Core.ResourceIdentifier delegatedManagementSubnetId = null, string cassandraVersion = null, string clusterNameOverride = null, Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod? authenticationMethod = default(Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod?), string initialCassandraAdminPassword = null, string prometheusEndpointIPAddress = null, bool? isRepairEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> clientCertificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> externalGossipCertificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> gossipCertificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterSeedNode> externalSeedNodes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterSeedNode> seedNodes = null, int? hoursBetweenBackups = default(int?), bool? isDeallocated = default(bool?), bool? isCassandraAuditLoggingEnabled = default(bool?), Azure.ResourceManager.CosmosDB.Models.CassandraClusterType? clusterType = default(Azure.ResourceManager.CosmosDB.Models.CassandraClusterType?), Azure.ResourceManager.CosmosDB.Models.CassandraError provisionError = null, System.Collections.Generic.IEnumerable<string> extensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupSchedule> backupSchedules = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatus CassandraClusterPublicStatus(Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.CosmosDB.Models.CassandraReaperStatus reaperStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraConnectionError> connectionErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraError> errors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatusDataCentersItem> dataCenters = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatusDataCentersItem CassandraClusterPublicStatusDataCentersItem(string name = null, System.Collections.Generic.IEnumerable<string> seedNodes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterDataCenterNodeItem> nodes = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraCommandOutput CassandraCommandOutput(string commandOutput = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionError CassandraConnectionError(Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState? connectionState = default(Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState?), string ipFrom = null, string ipTo = null, int? port = default(int?), string exception = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraDataCenterData CassandraDataCenterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterProperties CassandraDataCenterProperties(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState?), Azure.Core.AzureLocation? dataCenterLocation = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier delegatedSubnetId = null, int? nodeCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterSeedNode> seedNodes = null, string base64EncodedCassandraYamlFragment = null, System.Uri managedDiskCustomerKeyUri = null, System.Uri backupStorageCustomerKeyUri = null, string sku = null, string diskSku = null, int? diskCapacity = default(int?), bool? doesSupportAvailabilityZone = default(bool?), Azure.ResourceManager.CosmosDB.Models.AuthenticationMethodLdapProperties authenticationMethodLdapProperties = null, bool? deallocated = default(bool?), Azure.ResourceManager.CosmosDB.Models.CassandraError provisionError = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceCreateOrUpdateContent CassandraKeyspaceCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string resourceKeyspaceName = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraKeyspaceData CassandraKeyspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCassandraKeyspaceResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspacePropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraReaperStatus CassandraReaperStatus(bool? isHealthy = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> repairRunIds = null, System.Collections.Generic.IReadOnlyDictionary<string, string> repairSchedules = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraTableCreateOrUpdateContent CassandraTableCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraTableData CassandraTableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCassandraTableResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CassandraTablePropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraViewGetPropertiesResource CassandraViewGetPropertiesResource(string id = null, string viewDefinition = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraViewGetResultCreateOrUpdateContent CassandraViewGetResultCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CassandraViewResource resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CassandraViewGetResultData CassandraViewGetResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CassandraViewGetPropertiesResource resource = null, Azure.ResourceManager.CosmosDB.Models.CassandraViewGetPropertiesOptions options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CheckCosmosDBNameAvailabilityResponse CheckCosmosDBNameAvailabilityResponse(bool? nameAvailable = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason? reason = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountConnectionString CosmosDBAccountConnectionString(string connectionString = null, string description = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBKind? keyKind = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBKind?), Azure.ResourceManager.CosmosDB.Models.CosmosDBType? keyType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBType?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateOrUpdateContent CosmosDBAccountCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind? kind = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind?), Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy consistencyPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> locations = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType databaseAccountOfferType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBIPAddressOrRange> ipRules = null, bool? isVirtualNetworkFilterEnabled = default(bool?), bool? enableAutomaticFailover = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCapability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBVirtualNetworkRule> virtualNetworkRules = null, bool? enableMultipleWriteLocations = default(bool?), bool? enableCassandraConnector = default(bool?), Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? connectorOffer = default(Azure.ResourceManager.CosmosDB.Models.ConnectorOffer?), bool? disableKeyBasedMetadataWriteAccess = default(bool?), System.Uri keyVaultKeyUri = null, string defaultIdentity = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess?), bool? isFreeTierEnabled = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion? apiServerVersion = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion?), bool? isAnalyticalStorageEnabled = default(bool?), Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? analyticalStorageSchemaType = default(Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy backupPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCorsPolicy> cors = null, Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? networkAclBypass = default(Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkAclBypassResourceIds = null, Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery? diagnosticLogEnableFullTextQuery = default(Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery?), bool? disableLocalAuth = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreParameters restoreParameters = null, int? capacityTotalThroughputLimit = default(int?), bool? enableMaterializedViews = default(bool?), Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeysMetadata keysMetadata = null, bool? enablePartitionMerge = default(bool?), bool? enableBurstCapacity = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion? minimalTlsVersion = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion?), Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus? customerManagedKeyStatus = default(Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus?), bool? enablePriorityBasedExecution = default(bool?), Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel? defaultPriorityLevel = default(Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBAccountData CosmosDBAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind? kind = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind?), string provisioningState = null, string documentEndpoint = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType? databaseAccountOfferType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBIPAddressOrRange> ipRules = null, bool? isVirtualNetworkFilterEnabled = default(bool?), bool? enableAutomaticFailover = default(bool?), Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy consistencyPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCapability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> writeLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> readLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicy> failoverPolicies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBVirtualNetworkRule> virtualNetworkRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData> privateEndpointConnections = null, bool? enableMultipleWriteLocations = default(bool?), bool? enableCassandraConnector = default(bool?), Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? connectorOffer = default(Azure.ResourceManager.CosmosDB.Models.ConnectorOffer?), bool? disableKeyBasedMetadataWriteAccess = default(bool?), System.Uri keyVaultKeyUri = null, string defaultIdentity = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess?), bool? isFreeTierEnabled = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion? apiServerVersion = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion?), bool? isAnalyticalStorageEnabled = default(bool?), Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? analyticalStorageSchemaType = default(Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType?), System.Guid? instanceId = default(System.Guid?), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy backupPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCorsPolicy> cors = null, Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? networkAclBypass = default(Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkAclBypassResourceIds = null, Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery? diagnosticLogEnableFullTextQuery = default(Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery?), bool? disableLocalAuth = default(bool?), int? capacityTotalThroughputLimit = default(int?), bool? enableMaterializedViews = default(bool?), Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeysMetadata keysMetadata = null, bool? enablePartitionMerge = default(bool?), bool? enableBurstCapacity = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion? minimalTlsVersion = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion?), Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus? customerManagedKeyStatus = default(Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus?), bool? enablePriorityBasedExecution = default(bool?), Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel? defaultPriorityLevel = default(Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyList CosmosDBAccountKeyList(string primaryReadonlyMasterKey = null, string secondaryReadonlyMasterKey = null, string primaryMasterKey = null, string secondaryMasterKey = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation CosmosDBAccountLocation(string id = null, Azure.Core.AzureLocation? locationName = default(Azure.Core.AzureLocation?), string documentEndpoint = null, string provisioningState = null, int? failoverPriority = default(int?), bool? isZoneRedundant = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountReadOnlyKeyList CosmosDBAccountReadOnlyKeyList(string primaryReadonlyMasterKey = null, string secondaryReadonlyMasterKey = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupInformation CosmosDBBackupInformation(System.DateTimeOffset? continuousBackupInformationLatestRestorableTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric CosmosDBBaseMetric(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? unit = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricValue> metricValues = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage CosmosDBBaseUsage(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? unit = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName name = null, string quotaPeriod = null, long? limit = default(long?), long? currentValue = default(long?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBConnectionString CosmosDBConnectionString(string connectionString = null, string description = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBContainerPartitionKey CosmosDBContainerPartitionKey(System.Collections.Generic.IEnumerable<string> paths = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind? kind = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind?), int? version = default(int?), bool? isSystemKey = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicy CosmosDBFailoverPolicy(string id = null, Azure.Core.AzureLocation? locationName = default(Azure.Core.AzureLocation?), int? failoverPriority = default(int?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBFirewallRuleData CosmosDBFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState?), string startIPAddress = null, string endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBLocationData CosmosDBLocationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBLocationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBLocationProperties CosmosDBLocationProperties(bool? doesSupportAvailabilityZone = default(bool?), bool? isResidencyRestricted = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy> backupStorageRedundancies = null, bool? isSubscriptionRegionAccessAllowedForRegular = default(bool?), bool? isSubscriptionRegionAccessAllowedForAz = default(bool?), Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricAvailability CosmosDBMetricAvailability(string timeGrain = null, string retention = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricDefinition CosmosDBMetricDefinition(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricAvailability> metricAvailabilities = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType? primaryAggregationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? unit = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType?), Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName name = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName CosmosDBMetricName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricValue CosmosDBMetricValue(int? count = default(int?), double? average = default(double?), double? maximum = default(double?), double? minimum = default(double?), System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), double? total = default(double?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPercentileMetric CosmosDBPercentileMetric(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? unit = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.PercentileMetricValue> metricValues = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBPrivateEndpointConnectionData CosmosDBPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBPrivateLinkServiceConnectionStateProperty connectionState = null, string groupId = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBPrivateLinkResourceData CosmosDBPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPrivateLinkServiceConnectionStateProperty CosmosDBPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBRegionalService CosmosDBRegionalService(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBServiceData CosmosDBServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties CosmosDBServiceProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? instanceSize = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize?), int? instanceCount = default(int?), string serviceType = "Unknown", Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlClientEncryptionKeyData CosmosDBSqlClientEncryptionKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyProperties resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyProperties CosmosDBSqlClientEncryptionKeyProperties(string id = null, string encryptionAlgorithm = null, byte[] wrappedDataEncryptionKey = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBKeyWrapMetadata keyWrapMetadata = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerCreateOrUpdateContent CosmosDBSqlContainerCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlContainerData CosmosDBSqlContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlContainerResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerPropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseCreateOrUpdateContent CosmosDBSqlDatabaseCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlDatabaseData CosmosDBSqlDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlDatabaseResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabasePropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleAssignmentData CosmosDBSqlRoleAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, string scope = null, System.Guid? principalId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlRoleDefinitionData CosmosDBSqlRoleDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string roleName = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionType? roleDefinitionType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionType?), System.Collections.Generic.IEnumerable<string> assignableScopes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRolePermission> permissions = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureCreateOrUpdateContent CosmosDBSqlStoredProcedureCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlStoredProcedureData CosmosDBSqlStoredProcedureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlStoredProcedureResourceInfo resource = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerCreateOrUpdateContent CosmosDBSqlTriggerCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlTriggerData CosmosDBSqlTriggerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlTriggerResourceInfo resource = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBSqlUserDefinedFunctionData CosmosDBSqlUserDefinedFunctionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo resource = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBTableCreateOrUpdateContent CosmosDBTableCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBTableResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.CosmosDBTableData CosmosDBTableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBTablePropertiesResource resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBTablePropertiesOptions options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBTablePropertiesResource CosmosDBTablePropertiesResource(string tableName = null, Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeysMetadata DatabaseAccountKeysMetadata(System.DateTimeOffset? primaryMasterKeyGeneratedOn = default(System.DateTimeOffset?), System.DateTimeOffset? secondaryMasterKeyGeneratedOn = default(System.DateTimeOffset?), System.DateTimeOffset? primaryReadonlyMasterKeyGeneratedOn = default(System.DateTimeOffset?), System.DateTimeOffset? secondaryReadonlyMasterKeyGeneratedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DataTransferJobGetResultCreateOrUpdateContent DataTransferJobGetResultCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.DataTransferJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.DataTransferJobGetResultData DataTransferJobGetResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string jobName = null, Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink source = null, Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink destination = null, string status = null, long? processedCount = default(long?), long? totalCount = default(long?), System.DateTimeOffset? lastUpdatedUtcOn = default(System.DateTimeOffset?), int? workerCount = default(int?), Azure.ResourceManager.CosmosDB.Models.ErrorResponse error = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DataTransferJobProperties DataTransferJobProperties(string jobName = null, Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink source = null, Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink destination = null, string status = null, long? processedCount = default(long?), long? totalCount = default(long?), System.DateTimeOffset? lastUpdatedUtcOn = default(System.DateTimeOffset?), int? workerCount = default(int?), Azure.ResourceManager.CosmosDB.Models.ErrorResponse error = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DataTransferRegionalService DataTransferRegionalService(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DataTransferServiceProperties DataTransferServiceProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? instanceSize = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize?), int? instanceCount = default(int?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.DataTransferRegionalService> locations = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ErrorResponse ErrorResponse(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCassandraKeyspaceResourceInfo ExtendedCassandraKeyspaceResourceInfo(string keyspaceName = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCassandraTableResourceInfo ExtendedCassandraTableResourceInfo(string tableName = null, int? defaultTtl = default(int?), Azure.ResourceManager.CosmosDB.Models.CassandraSchema schema = null, int? analyticalStorageTtl = default(int?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlContainerResourceInfo ExtendedCosmosDBSqlContainerResourceInfo(string containerName = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingPolicy indexingPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBContainerPartitionKey partitionKey = null, int? defaultTtl = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBUniqueKey> uniqueKeys = null, Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy conflictResolutionPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBClientEncryptionPolicy clientEncryptionPolicy = null, long? analyticalStorageTtl = default(long?), Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), Azure.ResourceManager.CosmosDB.Models.MaterializedViewDefinition materializedViewDefinition = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlDatabaseResourceInfo ExtendedCosmosDBSqlDatabaseResourceInfo(string databaseName = null, Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string colls = null, string users = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlStoredProcedureResourceInfo ExtendedCosmosDBSqlStoredProcedureResourceInfo(string storedProcedureName = null, string body = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlTriggerResourceInfo ExtendedCosmosDBSqlTriggerResourceInfo(string triggerName = null, string body = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType? triggerType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation? triggerOperation = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo(string functionName = null, string body = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedGremlinDatabaseResourceInfo ExtendedGremlinDatabaseResourceInfo(string databaseName = null, Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedGremlinGraphResourceInfo ExtendedGremlinGraphResourceInfo(string graphName = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingPolicy indexingPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBContainerPartitionKey partitionKey = null, int? defaultTtl = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBUniqueKey> uniqueKeys = null, Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy conflictResolutionPolicy = null, long? analyticalStorageTtl = default(long?), Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedMongoDBCollectionResourceInfo ExtendedMongoDBCollectionResourceInfo(string collectionName = null, System.Collections.Generic.IDictionary<string, string> shardKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.MongoDBIndex> indexes = null, int? analyticalStorageTtl = default(int?), Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedMongoDBDatabaseResourceInfo ExtendedMongoDBDatabaseResourceInfo(string databaseName = null, Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableGremlinDatabaseResourceInfo ExtendedRestorableGremlinDatabaseResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string databaseName = null, string databaseId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableGremlinGraphResourceInfo ExtendedRestorableGremlinGraphResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string graphName = null, string graphId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongoDBCollectionResourceInfo ExtendedRestorableMongoDBCollectionResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string collectionName = null, string collectionId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongoDBDatabaseResourceInfo ExtendedRestorableMongoDBDatabaseResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string databaseName = null, string databaseId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlContainerResourceInfo ExtendedRestorableSqlContainerResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string containerName = null, string containerId = null, Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainerPropertiesResourceContainer container = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlDatabaseResourceInfo ExtendedRestorableSqlDatabaseResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string databaseName = null, string databaseId = null, Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabasePropertiesResourceDatabase database = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableTableResourceInfo ExtendedRestorableTableResourceInfo(string rid = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? operationType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType?), string eventTimestamp = null, string tableName = null, string tableId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ExtendedThroughputSettingsResourceInfo ExtendedThroughputSettingsResourceInfo(int? throughput = default(int?), Azure.ResourceManager.CosmosDB.Models.AutoscaleSettingsResourceInfo autoscaleSettings = null, string minimumThroughput = null, string offerReplacePending = null, string instantMaximumThroughput = null, string softAllowedMaximumThroughput = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.GraphApiComputeRegionalService GraphApiComputeRegionalService(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), string graphApiComputeEndpoint = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.GraphApiComputeServiceProperties GraphApiComputeServiceProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? instanceSize = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize?), int? instanceCount = default(int?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, string graphApiComputeEndpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.GraphApiComputeRegionalService> locations = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.GraphResourceGetResultCreateOrUpdateContent GraphResourceGetResultCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GraphResourceGetResultData GraphResourceGetResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.CosmosDB.Models.GraphResourceGetPropertiesOptions options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseCreateOrUpdateContent GremlinDatabaseCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinDatabaseData GremlinDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedGremlinDatabaseResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.GremlinDatabasePropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.GremlinGraphCreateOrUpdateContent GremlinGraphCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.GremlinGraphData GremlinGraphData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedGremlinGraphResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.GremlinGraphPropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ListConnectionStringsResult ListConnectionStringsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBConnectionString> connectionStrings = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.MaterializedViewDefinition MaterializedViewDefinition(string sourceCollectionRid = null, string sourceCollectionId = null, string definition = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.MaterializedViewsBuilderRegionalService MaterializedViewsBuilderRegionalService(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.MaterializedViewsBuilderServiceProperties MaterializedViewsBuilderServiceProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? instanceSize = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize?), int? instanceCount = default(int?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.MaterializedViewsBuilderRegionalService> locations = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoClusterData MongoClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), Azure.ResourceManager.CosmosDB.Models.MongoClusterRestoreParameters restoreParameters = null, string administratorLogin = null, string administratorLoginPassword = null, string serverVersion = null, string connectionString = null, string earliestRestoreTime = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState?), Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus? clusterStatus = default(Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.NodeGroupSpec> nodeGroupSpecs = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionCreateOrUpdateContent MongoDBCollectionCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBCollectionData MongoDBCollectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedMongoDBCollectionResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionPropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseCreateOrUpdateContent MongoDBDatabaseCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBDatabaseData MongoDBDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedMongoDBDatabaseResourceInfo resource = null, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabasePropertiesConfig options = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBRoleDefinitionData MongoDBRoleDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string roleName = null, Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionType? roleDefinitionType = default(Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionType?), string databaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.MongoDBPrivilege> privileges = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.MongoDBRole> roles = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.MongoDBUserDefinitionData MongoDBUserDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string userName = null, string password = null, string databaseName = null, string customData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.MongoDBRole> roles = null, string mechanisms = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PartitionMetric PartitionMetric(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string timeGrain = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? unit = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricValue> metricValues = null, System.Guid? partitionId = default(System.Guid?), string partitionKeyRangeId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PartitionUsage PartitionUsage(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? unit = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType?), Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName name = null, string quotaPeriod = null, long? limit = default(long?), long? currentValue = default(long?), System.Guid? partitionId = default(System.Guid?), string partitionKeyRangeId = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PercentileMetricValue PercentileMetricValue(int? count = default(int?), double? average = default(double?), double? maximum = default(double?), double? minimum = default(double?), System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), double? total = default(double?), double? p10 = default(double?), double? p25 = default(double?), double? p50 = default(double?), double? p75 = default(double?), double? p90 = default(double?), double? p95 = default(double?), double? p99 = default(double?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfo PhysicalPartitionStorageInfo(string id = null, double? storageInKB = default(double?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfoCollection PhysicalPartitionStorageInfoCollection(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfo> physicalPartitionStorageInfoCollectionValue = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResult PhysicalPartitionThroughputInfoResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResource> resourcePhysicalPartitionThroughputInfo = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputParameters RedistributeThroughputParameters(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputPropertiesResource resource = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.RestorableCosmosDBAccountData RestorableCosmosDBAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string accountName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? oldestRestorableOn = default(System.DateTimeOffset?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType? apiType = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.RestorableLocationResourceInfo> restorableLocations = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableGremlinDatabase RestorableGremlinDatabase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableGremlinDatabaseResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableGremlinGraph RestorableGremlinGraph(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableGremlinGraphResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableGremlinResourceData RestorableGremlinResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string databaseName = null, System.Collections.Generic.IEnumerable<string> graphNames = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableLocationResourceInfo RestorableLocationResourceInfo(Azure.Core.AzureLocation? locationName = default(Azure.Core.AzureLocation?), string regionalDatabaseAccountInstanceId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBCollection RestorableMongoDBCollection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongoDBCollectionResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBDatabase RestorableMongoDBDatabase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongoDBDatabaseResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableMongoDBResourceData RestorableMongoDBResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string databaseName = null, System.Collections.Generic.IEnumerable<string> collectionNames = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainer RestorableSqlContainer(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlContainerResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainerPropertiesResourceContainer RestorableSqlContainerPropertiesResourceContainer(string containerName = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingPolicy indexingPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBContainerPartitionKey partitionKey = null, int? defaultTtl = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBUniqueKey> uniqueKeys = null, Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy conflictResolutionPolicy = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBClientEncryptionPolicy clientEncryptionPolicy = null, long? analyticalStorageTtl = default(long?), Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), Azure.ResourceManager.CosmosDB.Models.MaterializedViewDefinition materializedViewDefinition = null, string self = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabase RestorableSqlDatabase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlDatabaseResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabasePropertiesResourceDatabase RestorableSqlDatabasePropertiesResourceDatabase(string databaseName = null, Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters restoreParameters = null, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? createMode = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode?), string colls = null, string users = null, string self = null, string rid = null, float? timestamp = default(float?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableSqlResourceData RestorableSqlResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string databaseName = null, System.Collections.Generic.IEnumerable<string> collectionNames = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableTable RestorableTable(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableTableResourceInfo resource = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RestorableTableResourceData RestorableTableResourceData(string id = null, string name = null, string resourceType = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputParameters RetrieveThroughputParameters(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> resourcePhysicalPartitionIds = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.SqlDedicatedGatewayRegionalService SqlDedicatedGatewayRegionalService(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), string sqlDedicatedGatewayEndpoint = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.SqlDedicatedGatewayServiceProperties SqlDedicatedGatewayServiceProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? instanceSize = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize?), int? instanceCount = default(int?), Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? status = default(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, string sqlDedicatedGatewayEndpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.SqlDedicatedGatewayRegionalService> locations = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.ThroughputSettingData ThroughputSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ExtendedThroughputSettingsResourceInfo resource = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo ThroughputSettingsResourceInfo(int? throughput = default(int?), Azure.ResourceManager.CosmosDB.Models.AutoscaleSettingsResourceInfo autoscaleSettings = null, string minimumThroughput = null, string offerReplacePending = null, string instantMaximumThroughput = null, string softAllowedMaximumThroughput = null) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsUpdateData ThroughputSettingsUpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo resource = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
    }
    public partial class AuthenticationMethodLdapProperties
    {
        public AuthenticationMethodLdapProperties() { }
        public int? ConnectionTimeoutInMs { get { throw null; } set { } }
        public string SearchBaseDistinguishedName { get { throw null; } set { } }
        public string SearchFilterTemplate { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> ServerCertificates { get { throw null; } }
        public string ServerHostname { get { throw null; } set { } }
        public int? ServerPort { get { throw null; } set { } }
        public string ServiceUserDistinguishedName { get { throw null; } set { } }
        public string ServiceUserPassword { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingsResourceInfo
    {
        public AutoscaleSettingsResourceInfo(int maxThroughput) { }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyResourceInfo AutoUpgradeThroughputPolicy { get { throw null; } set { } }
        public int MaxThroughput { get { throw null; } set { } }
        public int? TargetMaxThroughput { get { throw null; } }
    }
    public partial class AzureBlobDataTransferDataSourceSink : Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink
    {
        public AzureBlobDataTransferDataSourceSink(string containerName) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
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
    public readonly partial struct CassandraAuthenticationMethod : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraAuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod Cassandra { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod Ldap { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod left, Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod left, Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraCertificate
    {
        public CassandraCertificate() { }
        public string Pem { get { throw null; } set { } }
    }
    public partial class CassandraClusterBackupResourceInfo
    {
        internal CassandraClusterBackupResourceInfo() { }
        public System.DateTimeOffset? BackupExpiryTimestamp { get { throw null; } }
        public string BackupId { get { throw null; } }
        public System.DateTimeOffset? BackupStartTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState? BackupState { get { throw null; } }
        public System.DateTimeOffset? BackupStopTimestamp { get { throw null; } }
    }
    public partial class CassandraClusterBackupSchedule
    {
        public CassandraClusterBackupSchedule() { }
        public string CronExpression { get { throw null; } set { } }
        public int? RetentionInHours { get { throw null; } set { } }
        public string ScheduleName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraClusterBackupState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraClusterBackupState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState Initiated { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState InProgress { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState left, Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState left, Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraClusterDataCenterNodeItem
    {
        internal CassandraClusterDataCenterNodeItem() { }
        public string Address { get { throw null; } }
        public string CassandraProcessStatus { get { throw null; } }
        public double? CpuUsage { get { throw null; } }
        public long? DiskFreeKB { get { throw null; } }
        public long? DiskUsedKB { get { throw null; } }
        public System.Guid? HostId { get { throw null; } }
        public bool? IsLatestModel { get { throw null; } }
        public string Load { get { throw null; } }
        public long? MemoryBuffersAndCachedKB { get { throw null; } }
        public long? MemoryFreeKB { get { throw null; } }
        public long? MemoryTotalKB { get { throw null; } }
        public long? MemoryUsedKB { get { throw null; } }
        public string Rack { get { throw null; } }
        public int? Size { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraNodeState? State { get { throw null; } }
        public string Status { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
    }
    public partial class CassandraClusterKey
    {
        public CassandraClusterKey() { }
        public string Name { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
    }
    public partial class CassandraClusterProperties
    {
        public CassandraClusterProperties() { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraAuthenticationMethod? AuthenticationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraClusterBackupSchedule> BackupSchedules { get { throw null; } }
        public string CassandraVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> ClientCertificates { get { throw null; } }
        public string ClusterNameOverride { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraClusterType? ClusterType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedManagementSubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Extensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> ExternalGossipCertificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterSeedNode> ExternalSeedNodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraCertificate> GossipCertificates { get { throw null; } }
        public int? HoursBetweenBackups { get { throw null; } set { } }
        public string InitialCassandraAdminPassword { get { throw null; } set { } }
        public bool? IsCassandraAuditLoggingEnabled { get { throw null; } set { } }
        public bool? IsDeallocated { get { throw null; } set { } }
        public bool? IsRepairEnabled { get { throw null; } set { } }
        public string PrometheusEndpointIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraError ProvisionError { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RestoreFromBackupId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterSeedNode> SeedNodes { get { throw null; } }
    }
    public partial class CassandraClusterPublicStatus
    {
        internal CassandraClusterPublicStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraConnectionError> ConnectionErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraClusterPublicStatusDataCentersItem> DataCenters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraError> Errors { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraReaperStatus ReaperStatus { get { throw null; } }
    }
    public partial class CassandraClusterPublicStatusDataCentersItem
    {
        internal CassandraClusterPublicStatusDataCentersItem() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraClusterDataCenterNodeItem> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SeedNodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraClusterType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CassandraClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraClusterType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterType NonProduction { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraClusterType Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CassandraClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CassandraClusterType left, Azure.ResourceManager.CosmosDB.Models.CassandraClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CassandraClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CassandraClusterType left, Azure.ResourceManager.CosmosDB.Models.CassandraClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraColumn
    {
        public CassandraColumn() { }
        public string CassandraColumnType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class CassandraCommandOutput
    {
        internal CassandraCommandOutput() { }
        public string CommandOutput { get { throw null; } }
    }
    public partial class CassandraCommandPostBody
    {
        public CassandraCommandPostBody(string command, string host) { }
        public bool? AllowWrite { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Arguments { get { throw null; } }
        public bool? CassandraStopStart { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public string Host { get { throw null; } }
    }
    public partial class CassandraConnectionError
    {
        internal CassandraConnectionError() { }
        public Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState? ConnectionState { get { throw null; } }
        public string Exception { get { throw null; } }
        public string IPFrom { get { throw null; } }
        public string IPTo { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraConnectionState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState DatacenterToDatacenterNetworkError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState InternalError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState InternalOperatorToDataCenterCertificateError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState OK { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState OperatorToDataCenterNetworkError { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState left, Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState left, Azure.ResourceManager.CosmosDB.Models.CassandraConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraDataCenterProperties
    {
        public CassandraDataCenterProperties() { }
        public Azure.ResourceManager.CosmosDB.Models.AuthenticationMethodLdapProperties AuthenticationMethodLdapProperties { get { throw null; } set { } }
        public System.Uri BackupStorageCustomerKeyUri { get { throw null; } set { } }
        public string Base64EncodedCassandraYamlFragment { get { throw null; } set { } }
        public Azure.Core.AzureLocation? DataCenterLocation { get { throw null; } set { } }
        public bool? Deallocated { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DelegatedSubnetId { get { throw null; } set { } }
        public int? DiskCapacity { get { throw null; } set { } }
        public string DiskSku { get { throw null; } set { } }
        public bool? DoesSupportAvailabilityZone { get { throw null; } set { } }
        public System.Uri ManagedDiskCustomerKeyUri { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraError ProvisionError { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CassandraDataCenterSeedNode> SeedNodes { get { throw null; } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class CassandraDataCenterSeedNode
    {
        public CassandraDataCenterSeedNode() { }
        public string IPAddress { get { throw null; } set { } }
    }
    public partial class CassandraError
    {
        public CassandraError() { }
        public string AdditionalErrorInfo { get { throw null; } set { } }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class CassandraKeyspaceCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraKeyspaceCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public string ResourceKeyspaceName { get { throw null; } set { } }
    }
    public partial class CassandraKeyspacePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public CassandraKeyspacePropertiesConfig() { }
    }
    public partial class CassandraKeyspaceResourceInfo
    {
        public CassandraKeyspaceResourceInfo(string keyspaceName) { }
        public string KeyspaceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraNodeState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CassandraNodeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraNodeState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraNodeState Joining { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraNodeState Leaving { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraNodeState Moving { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraNodeState Normal { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraNodeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CassandraNodeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CassandraNodeState left, Azure.ResourceManager.CosmosDB.Models.CassandraNodeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CassandraNodeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CassandraNodeState left, Azure.ResourceManager.CosmosDB.Models.CassandraNodeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraPartitionKey
    {
        public CassandraPartitionKey() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CassandraProvisioningState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CassandraProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState left, Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState left, Azure.ResourceManager.CosmosDB.Models.CassandraProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CassandraReaperStatus
    {
        internal CassandraReaperStatus() { }
        public bool? IsHealthy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RepairRunIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> RepairSchedules { get { throw null; } }
    }
    public partial class CassandraSchema
    {
        public CassandraSchema() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraClusterKey> ClusterKeys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraColumn> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CassandraPartitionKey> PartitionKeys { get { throw null; } }
    }
    public partial class CassandraTableCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraTableCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CassandraTablePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public CassandraTablePropertiesConfig() { }
    }
    public partial class CassandraTableResourceInfo
    {
        public CassandraTableResourceInfo(string tableName) { }
        public int? AnalyticalStorageTtl { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraSchema Schema { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class CassandraViewGetPropertiesOptions : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public CassandraViewGetPropertiesOptions() { }
    }
    public partial class CassandraViewGetPropertiesResource : Azure.ResourceManager.CosmosDB.Models.CassandraViewResource
    {
        public CassandraViewGetPropertiesResource(string id, string viewDefinition) : base (default(string), default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class CassandraViewGetResultCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CassandraViewGetResultCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CassandraViewResource resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CassandraViewResource Resource { get { throw null; } set { } }
    }
    public partial class CassandraViewResource
    {
        public CassandraViewResource(string id, string viewDefinition) { }
        public string Id { get { throw null; } set { } }
        public string ViewDefinition { get { throw null; } set { } }
    }
    public partial class CheckCosmosDBNameAvailabilityContent
    {
        public CheckCosmosDBNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckCosmosDBNameAvailabilityResponse
    {
        internal CheckCosmosDBNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason? Reason { get { throw null; } }
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
    public partial class ContinuousBackupRestoreLocation
    {
        public ContinuousBackupRestoreLocation() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class ContinuousModeBackupPolicy : Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy
    {
        public ContinuousModeBackupPolicy() { }
        public Azure.ResourceManager.CosmosDB.Models.ContinuousTier? ContinuousModeTier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContinuousTier : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ContinuousTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContinuousTier(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ContinuousTier Continuous30Days { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ContinuousTier Continuous7Days { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ContinuousTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ContinuousTier left, Azure.ResourceManager.CosmosDB.Models.ContinuousTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ContinuousTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ContinuousTier left, Azure.ResourceManager.CosmosDB.Models.ContinuousTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosCassandraDataTransferDataSourceSink : Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink
    {
        public CosmosCassandraDataTransferDataSourceSink(string keyspaceName, string tableName) { }
        public string KeyspaceName { get { throw null; } set { } }
        public string RemoteAccountName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public abstract partial class CosmosDBAccountBackupPolicy
    {
        protected CosmosDBAccountBackupPolicy() { }
        public Azure.ResourceManager.CosmosDB.Models.BackupPolicyMigrationState MigrationState { get { throw null; } set { } }
    }
    public partial class CosmosDBAccountCapability
    {
        public CosmosDBAccountCapability() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class CosmosDBAccountConnectionString
    {
        internal CosmosDBAccountConnectionString() { }
        public string ConnectionString { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBKind? KeyKind { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBType? KeyType { get { throw null; } }
    }
    public partial class CosmosDBAccountCorsPolicy
    {
        public CosmosDBAccountCorsPolicy(string allowedOrigins) { }
        public string AllowedHeaders { get { throw null; } set { } }
        public string AllowedMethods { get { throw null; } set { } }
        public string AllowedOrigins { get { throw null; } set { } }
        public string ExposedHeaders { get { throw null; } set { } }
        public long? MaxAgeInSeconds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBAccountCreateMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBAccountCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBAccountCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBAccountCreateOrUpdateContent(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> locations) { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion? ApiServerVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCapability> Capabilities { get { throw null; } }
        public int? CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus? CustomerManagedKeyStatus { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType DatabaseAccountOfferType { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public string DefaultIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel? DefaultPriorityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery? DiagnosticLogEnableFullTextQuery { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableBurstCapacity { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableMaterializedViews { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public bool? EnablePartitionMerge { get { throw null; } set { } }
        public bool? EnablePriorityBasedExecution { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBIPAddressOrRange> IPRules { get { throw null; } }
        public bool? IsAnalyticalStorageEnabled { get { throw null; } set { } }
        public bool? IsFreeTierEnabled { get { throw null; } set { } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeysMetadata KeysMetadata { get { throw null; } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> NetworkAclBypassResourceIds { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBAccountKeyKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBAccountKeyKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind Primary { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind PrimaryReadonly { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind Secondary { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind SecondaryReadonly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBAccountKeyList : Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountReadOnlyKeyList
    {
        internal CosmosDBAccountKeyList() { }
        public string PrimaryMasterKey { get { throw null; } }
        public string SecondaryMasterKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBAccountKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBAccountKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind GlobalDocumentDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind MongoDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind Parse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBAccountLocation
    {
        public CosmosDBAccountLocation() { }
        public string DocumentEndpoint { get { throw null; } }
        public int? FailoverPriority { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public Azure.Core.AzureLocation? LocationName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBAccountOfferType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBAccountOfferType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountOfferType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBAccountPatch
    {
        public CosmosDBAccountPatch() { }
        public Azure.ResourceManager.CosmosDB.Models.AnalyticalStorageSchemaType? AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion? ApiServerVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy BackupPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCapability> Capabilities { get { throw null; } }
        public int? CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConnectorOffer? ConnectorOffer { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConsistencyPolicy ConsistencyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCorsPolicy> Cors { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus? CustomerManagedKeyStatus { get { throw null; } set { } }
        public string DefaultIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel? DefaultPriorityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.EnableFullTextQuery? DiagnosticLogEnableFullTextQuery { get { throw null; } set { } }
        public bool? DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableAutomaticFailover { get { throw null; } set { } }
        public bool? EnableBurstCapacity { get { throw null; } set { } }
        public bool? EnableCassandraConnector { get { throw null; } set { } }
        public bool? EnableMaterializedViews { get { throw null; } set { } }
        public bool? EnableMultipleWriteLocations { get { throw null; } set { } }
        public bool? EnablePartitionMerge { get { throw null; } set { } }
        public bool? EnablePriorityBasedExecution { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBIPAddressOrRange> IPRules { get { throw null; } }
        public bool? IsAnalyticalStorageEnabled { get { throw null; } set { } }
        public bool? IsFreeTierEnabled { get { throw null; } set { } }
        public bool? IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.DatabaseAccountKeysMetadata KeysMetadata { get { throw null; } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.NetworkAclBypass? NetworkAclBypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> NetworkAclBypassResourceIds { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class CosmosDBAccountReadOnlyKeyList
    {
        internal CosmosDBAccountReadOnlyKeyList() { }
        public string PrimaryReadonlyMasterKey { get { throw null; } }
        public string SecondaryReadonlyMasterKey { get { throw null; } }
    }
    public partial class CosmosDBAccountRegenerateKeyContent
    {
        public CosmosDBAccountRegenerateKeyContent(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind keyKind) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountKeyKind KeyKind { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBAccountRestoreMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBAccountRestoreMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode PointInTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode left, Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBAccountRestoreParameters : Azure.ResourceManager.CosmosDB.Models.RestoreParametersBase
    {
        public CosmosDBAccountRestoreParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.DatabaseRestoreResourceInfo> DatabasesToRestore { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseRestoreResourceInfo> GremlinDatabasesToRestore { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountRestoreMode? RestoreMode { get { throw null; } set { } }
        public string SourceBackupLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TablesToRestore { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBApiType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBApiType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType Cassandra { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType Gremlin { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType GremlinV2 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType MongoDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType Sql { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType Table { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBBackupInformation
    {
        internal CosmosDBBackupInformation() { }
        public System.DateTimeOffset? ContinuousBackupInformationLatestRestorableTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBBackupStorageRedundancy : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBBackupStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy Geo { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy Local { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy left, Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy left, Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBBaseConfig
    {
        public CosmosDBBaseConfig() { }
        public int? AutoscaleMaxThroughput { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class CosmosDBBaseMetric
    {
        internal CosmosDBBaseMetric() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? Unit { get { throw null; } }
    }
    public partial class CosmosDBBaseUsage
    {
        internal CosmosDBBaseUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName Name { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? Unit { get { throw null; } }
    }
    public partial class CosmosDBClientEncryptionIncludedPath
    {
        public CosmosDBClientEncryptionIncludedPath(string path, string clientEncryptionKeyId, string encryptionType, string encryptionAlgorithm) { }
        public string ClientEncryptionKeyId { get { throw null; } set { } }
        public string EncryptionAlgorithm { get { throw null; } set { } }
        public string EncryptionType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class CosmosDBClientEncryptionPolicy
    {
        public CosmosDBClientEncryptionPolicy(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBClientEncryptionIncludedPath> includedPaths, int policyFormatVersion) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBClientEncryptionIncludedPath> IncludedPaths { get { throw null; } }
        public int PolicyFormatVersion { get { throw null; } set { } }
    }
    public partial class CosmosDBCompositePath
    {
        public CosmosDBCompositePath() { }
        public Azure.ResourceManager.CosmosDB.Models.CompositePathSortOrder? Order { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class CosmosDBConnectionString
    {
        internal CosmosDBConnectionString() { }
        public string ConnectionString { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public partial class CosmosDBContainerPartitionKey
    {
        public CosmosDBContainerPartitionKey() { }
        public bool? IsSystemKey { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Paths { get { throw null; } }
        public int? Version { get { throw null; } set { } }
    }
    public partial class CosmosDBCreateUpdateConfig
    {
        public CosmosDBCreateUpdateConfig() { }
        public int? AutoscaleMaxThroughput { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBDataType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBDataType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType LineString { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType MultiPolygon { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType Number { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType Point { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType Polygon { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBExcludedPath
    {
        public CosmosDBExcludedPath() { }
        public string Path { get { throw null; } set { } }
    }
    public partial class CosmosDBFailoverPolicies
    {
        public CosmosDBFailoverPolicies(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicy> failoverPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBFailoverPolicy> FailoverPolicies { get { throw null; } }
    }
    public partial class CosmosDBFailoverPolicy
    {
        public CosmosDBFailoverPolicy() { }
        public int? FailoverPriority { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Core.AzureLocation? LocationName { get { throw null; } set { } }
    }
    public partial class CosmosDBIncludedPath
    {
        public CosmosDBIncludedPath() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBPathIndexes> Indexes { get { throw null; } }
        public string Path { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBIndexingMode : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBIndexingMode(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode Consistent { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode Lazy { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode left, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode left, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBIndexingPolicy
    {
        public CosmosDBIndexingPolicy() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBCompositePath>> CompositeIndexes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBExcludedPath> ExcludedPaths { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBIncludedPath> IncludedPaths { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingMode? IndexingMode { get { throw null; } set { } }
        public bool? IsAutomatic { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.SpatialSpec> SpatialIndexes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBIndexKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBIndexKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind Hash { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind Range { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind Spatial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBIPAddressOrRange
    {
        public CosmosDBIPAddressOrRange() { }
        public string IPAddressOrRange { get { throw null; } set { } }
    }
    public partial class CosmosDBKeyWrapMetadata
    {
        public CosmosDBKeyWrapMetadata() { }
        public string Algorithm { get { throw null; } set { } }
        public string CosmosDBKeyWrapMetadataType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBKind Primary { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBKind PrimaryReadonly { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBKind Secondary { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBKind SecondaryReadonly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBLocationProperties
    {
        public CosmosDBLocationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy> BackupStorageRedundancies { get { throw null; } }
        public bool? DoesSupportAvailabilityZone { get { throw null; } }
        public bool? IsResidencyRestricted { get { throw null; } }
        public bool? IsSubscriptionRegionAccessAllowedForAz { get { throw null; } }
        public bool? IsSubscriptionRegionAccessAllowedForRegular { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus? Status { get { throw null; } }
    }
    public partial class CosmosDBMetricAvailability
    {
        internal CosmosDBMetricAvailability() { }
        public string Retention { get { throw null; } }
        public string TimeGrain { get { throw null; } }
    }
    public partial class CosmosDBMetricDefinition
    {
        internal CosmosDBMetricDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName Name { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType? PrimaryAggregationType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? Unit { get { throw null; } }
    }
    public partial class CosmosDBMetricName
    {
        internal CosmosDBMetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBMetricPrimaryAggregationType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBMetricPrimaryAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType Last { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType Maximum { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType Minimum { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType None { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricPrimaryAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBMetricUnitType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBMetricUnitType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType Bytes { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType Count { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType Milliseconds { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType Percent { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBMetricValue
    {
        internal CosmosDBMetricValue() { }
        public double? Average { get { throw null; } }
        public int? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public double? Total { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBMinimalTlsVersion : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBMinimalTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion Tls { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion Tls11 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion Tls12 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion left, Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion left, Azure.ResourceManager.CosmosDB.Models.CosmosDBMinimalTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBNameUnavailableReason : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason left, Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason left, Azure.ResourceManager.CosmosDB.Models.CosmosDBNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBOperationType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBOperationType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType Create { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType Delete { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType Recreate { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType Replace { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType SystemOperation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBPartitionKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBPartitionKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind Hash { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind MultiHash { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind Range { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind left, Azure.ResourceManager.CosmosDB.Models.CosmosDBPartitionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBPathIndexes
    {
        public CosmosDBPathIndexes() { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBDataType? DataType { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexKind? Kind { get { throw null; } set { } }
        public int? Precision { get { throw null; } set { } }
    }
    public partial class CosmosDBPercentileMetric
    {
        internal CosmosDBPercentileMetric() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.PercentileMetricValue> MetricValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricName Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricUnitType? Unit { get { throw null; } }
    }
    public partial class CosmosDBPrivateLinkServiceConnectionStateProperty
    {
        public CosmosDBPrivateLinkServiceConnectionStateProperty() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBProvisioningState : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState left, Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState left, Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess left, Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess left, Azure.ResourceManager.CosmosDB.Models.CosmosDBPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBRegionalService
    {
        internal CosmosDBRegionalService() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBServerVersion : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion V3_2 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion V3_6 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion V4_0 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion V4_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBServiceCreateOrUpdateContent
    {
        public CosmosDBServiceCreateOrUpdateContent() { }
        public int? InstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? InstanceSize { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType? ServiceType { get { throw null; } set { } }
    }
    public partial class CosmosDBServiceProperties
    {
        public CosmosDBServiceProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? InstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize? InstanceSize { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBServiceSize : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBServiceSize(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize CosmosD16S { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize CosmosD4S { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize CosmosD8S { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBServiceStatus : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus Error { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBServiceType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBServiceType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType DataTransfer { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType GraphApiCompute { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType MaterializedViewsBuilder { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType SqlDedicatedGateway { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBSpatialType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBSpatialType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType LineString { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType MultiPolygon { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType Point { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType Polygon { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBSqlClientEncryptionKeyCreateOrUpdateContent
    {
        public CosmosDBSqlClientEncryptionKeyCreateOrUpdateContent(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyResourceInfo resource) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyResourceInfo Resource { get { throw null; } }
    }
    public partial class CosmosDBSqlClientEncryptionKeyProperties : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlClientEncryptionKeyResourceInfo
    {
        public CosmosDBSqlClientEncryptionKeyProperties() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class CosmosDBSqlClientEncryptionKeyResourceInfo
    {
        public CosmosDBSqlClientEncryptionKeyResourceInfo() { }
        public string EncryptionAlgorithm { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBKeyWrapMetadata KeyWrapMetadata { get { throw null; } set { } }
        public byte[] WrappedDataEncryptionKey { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlContainerCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerPropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public CosmosDBSqlContainerPropertiesConfig() { }
    }
    public partial class CosmosDBSqlContainerResourceInfo
    {
        public CosmosDBSqlContainerResourceInfo(string containerName) { }
        public long? AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBClientEncryptionPolicy ClientEncryptionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy ConflictResolutionPolicy { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingPolicy IndexingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MaterializedViewDefinition MaterializedViewDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBContainerPartitionKey PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBUniqueKey> UniqueKeys { get { throw null; } }
    }
    public partial class CosmosDBSqlDatabaseCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlDatabaseCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo Resource { get { throw null; } set { } }
        public string ResourceDatabaseName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlDatabasePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public CosmosDBSqlDatabasePropertiesConfig() { }
    }
    public partial class CosmosDBSqlDatabaseResourceInfo
    {
        public CosmosDBSqlDatabaseResourceInfo(string databaseName) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlRoleAssignmentCreateOrUpdateContent
    {
        public CosmosDBSqlRoleAssignmentCreateOrUpdateContent() { }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlRoleDefinitionCreateOrUpdateContent
    {
        public CosmosDBSqlRoleDefinitionCreateOrUpdateContent() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRolePermission> Permissions { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlRoleDefinitionType? RoleDefinitionType { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
    }
    public enum CosmosDBSqlRoleDefinitionType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public partial class CosmosDBSqlRolePermission
    {
        public CosmosDBSqlRolePermission() { }
        public System.Collections.Generic.IList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotDataActions { get { throw null; } }
    }
    public partial class CosmosDBSqlStoredProcedureCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlStoredProcedureCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlStoredProcedureResourceInfo
    {
        public CosmosDBSqlStoredProcedureResourceInfo(string storedProcedureName) { }
        public string Body { get { throw null; } set { } }
        public string StoredProcedureName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlTriggerCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlTriggerCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo Resource { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBSqlTriggerOperation : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBSqlTriggerOperation(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation All { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation Create { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation Replace { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation left, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation left, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBSqlTriggerResourceInfo
    {
        public CosmosDBSqlTriggerResourceInfo(string triggerName) { }
        public string Body { get { throw null; } set { } }
        public string TriggerName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerOperation? TriggerOperation { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType? TriggerType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBSqlTriggerType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBSqlTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType Post { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType Pre { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBSqlUserDefinedFunctionCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlUserDefinedFunctionResourceInfo
    {
        public CosmosDBSqlUserDefinedFunctionResourceInfo(string functionName) { }
        public string Body { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBStatus : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBStatus(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus InternallyReady { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus Online { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus Uninitialized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus left, Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus left, Azure.ResourceManager.CosmosDB.Models.CosmosDBStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBTableCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CosmosDBTableCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.CosmosDBTableResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBTableResourceInfo Resource { get { throw null; } set { } }
        public string ResourceTableName { get { throw null; } set { } }
    }
    public partial class CosmosDBTablePropertiesOptions : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public CosmosDBTablePropertiesOptions() { }
    }
    public partial class CosmosDBTablePropertiesResource : Azure.ResourceManager.CosmosDB.Models.CosmosDBTableResourceInfo
    {
        public CosmosDBTablePropertiesResource(string tableName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class CosmosDBTableResourceInfo
    {
        public CosmosDBTableResourceInfo(string tableName) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CosmosDBType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType Cassandra { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType CassandraConnectorMetadata { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType Gremlin { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType GremlinV2 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType MongoDB { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType Sql { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType SqlDedicatedGateway { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType Table { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CosmosDBType Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CosmosDBType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CosmosDBType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CosmosDBType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CosmosDBType left, Azure.ResourceManager.CosmosDB.Models.CosmosDBType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBUniqueKey
    {
        public CosmosDBUniqueKey() { }
        public System.Collections.Generic.IList<string> Paths { get { throw null; } }
    }
    public partial class CosmosDBVirtualNetworkRule
    {
        public CosmosDBVirtualNetworkRule() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
    }
    public partial class CosmosMongoDataTransferDataSourceSink : Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink
    {
        public CosmosMongoDataTransferDataSourceSink(string databaseName, string collectionName) { }
        public string CollectionName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string RemoteAccountName { get { throw null; } set { } }
    }
    public partial class CosmosSqlDataTransferDataSourceSink : Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink
    {
        public CosmosSqlDataTransferDataSourceSink(string databaseName, string containerName) { }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string RemoteAccountName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomerManagedKeyStatus : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomerManagedKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToTheConfiguredCustomerManagedKeyConfirmed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheAccessRulesAreBlockingOutboundRequestsToTheAzureKeyVaultServiceForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuide4016 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBAccountHasAnUndefinedDefaultIdentityForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideInvalidAzureCosmosDBDefaultIdentity4015 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBAccountSKeyVaultKeyUriDoesNotFollowTheExpectedFormatForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideImproperSyntaxDetectedOnTheKeyVaultUriProperty4006 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBServiceIsUnableToObtainTheAADAuthenticationTokenForTheAccountSDefaultIdentityForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideAzureActiveDirectoryTokenAcquisitionError4000 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBServiceIsUnableToWrapOrUnwrapTheKeyForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideInternalUnwrappingProcedureError4005 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureKeyVaultDnsNameSpecifiedByTheAccountSKeyvaultkeyuriPropertyCouldNotBeResolvedForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideUnableToResolveTheKeyVaultsDns4009 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheCorrespondentAzureKeyVaultWasNotFoundForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideAzureKeyVaultResourceNotFound4017 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheCorrespondentKeyIsNotFoundOnTheSpecifiedKeyVaultForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideAzureKeyVaultResourceNotFound4003 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedBecauseTheCurrentDefaultIdentityNoLongerHasPermissionToTheAssociatedKeyVaultKeyForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuideDefaultIdentityIsUnauthorizedToAccessTheAzureKeyVaultKey4002 { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus AccessToYourAccountIsCurrentlyRevokedForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnMicrosoftComEnUsAzureCosmosDBCmkTroubleshootingGuide { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus left, Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus left, Azure.ResourceManager.CosmosDB.Models.CustomerManagedKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseAccountKeysMetadata
    {
        internal DatabaseAccountKeysMetadata() { }
        public System.DateTimeOffset? PrimaryMasterKeyGeneratedOn { get { throw null; } }
        public System.DateTimeOffset? PrimaryReadonlyMasterKeyGeneratedOn { get { throw null; } }
        public System.DateTimeOffset? SecondaryMasterKeyGeneratedOn { get { throw null; } }
        public System.DateTimeOffset? SecondaryReadonlyMasterKeyGeneratedOn { get { throw null; } }
    }
    public partial class DatabaseRestoreResourceInfo
    {
        public DatabaseRestoreResourceInfo() { }
        public System.Collections.Generic.IList<string> CollectionNames { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
    }
    public abstract partial class DataTransferDataSourceSink
    {
        protected DataTransferDataSourceSink() { }
    }
    public partial class DataTransferJobGetResultCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public DataTransferJobGetResultCreateOrUpdateContent(Azure.ResourceManager.CosmosDB.Models.DataTransferJobProperties properties) { }
        public Azure.ResourceManager.CosmosDB.Models.DataTransferJobProperties Properties { get { throw null; } set { } }
    }
    public partial class DataTransferJobProperties
    {
        public DataTransferJobProperties(Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink source, Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink destination) { }
        public Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink Destination { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ErrorResponse Error { get { throw null; } }
        public string JobName { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedUtcOn { get { throw null; } }
        public long? ProcessedCount { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink Source { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public long? TotalCount { get { throw null; } }
        public int? WorkerCount { get { throw null; } set { } }
    }
    public partial class DataTransferRegionalService : Azure.ResourceManager.CosmosDB.Models.CosmosDBRegionalService
    {
        internal DataTransferRegionalService() { }
    }
    public partial class DataTransferServiceProperties : Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties
    {
        public DataTransferServiceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.DataTransferRegionalService> Locations { get { throw null; } }
    }
    public enum DefaultConsistencyLevel
    {
        Eventual = 0,
        Session = 1,
        BoundedStaleness = 2,
        Strong = 3,
        ConsistentPrefix = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultPriorityLevel : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultPriorityLevel(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel High { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel Low { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel left, Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel left, Azure.ResourceManager.CosmosDB.Models.DefaultPriorityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EnableFullTextQuery
    {
        None = 0,
        True = 1,
        False = 2,
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ExtendedCassandraKeyspaceResourceInfo : Azure.ResourceManager.CosmosDB.Models.CassandraKeyspaceResourceInfo
    {
        public ExtendedCassandraKeyspaceResourceInfo(string keyspaceName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedCassandraTableResourceInfo : Azure.ResourceManager.CosmosDB.Models.CassandraTableResourceInfo
    {
        public ExtendedCassandraTableResourceInfo(string tableName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlContainerResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo
    {
        public ExtendedCosmosDBSqlContainerResourceInfo(string containerName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlDatabaseResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo
    {
        public ExtendedCosmosDBSqlDatabaseResourceInfo(string databaseName) : base (default(string)) { }
        public string Colls { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
        public string Users { get { throw null; } set { } }
    }
    public partial class ExtendedCosmosDBSqlStoredProcedureResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlStoredProcedureResourceInfo
    {
        public ExtendedCosmosDBSqlStoredProcedureResourceInfo(string storedProcedureName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlTriggerResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlTriggerResourceInfo
    {
        public ExtendedCosmosDBSqlTriggerResourceInfo(string triggerName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlUserDefinedFunctionResourceInfo
    {
        public ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo(string functionName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedGremlinDatabaseResourceInfo : Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResourceInfo
    {
        public ExtendedGremlinDatabaseResourceInfo(string databaseName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedGremlinGraphResourceInfo : Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo
    {
        public ExtendedGremlinGraphResourceInfo(string graphName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedMongoDBCollectionResourceInfo : Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo
    {
        public ExtendedMongoDBCollectionResourceInfo(string collectionName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedMongoDBDatabaseResourceInfo : Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResourceInfo
    {
        public ExtendedMongoDBDatabaseResourceInfo(string databaseName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class ExtendedRestorableGremlinDatabaseResourceInfo
    {
        internal ExtendedRestorableGremlinDatabaseResourceInfo() { }
        public string DatabaseId { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableGremlinGraphResourceInfo
    {
        internal ExtendedRestorableGremlinGraphResourceInfo() { }
        public string EventTimestamp { get { throw null; } }
        public string GraphId { get { throw null; } }
        public string GraphName { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableMongoDBCollectionResourceInfo
    {
        internal ExtendedRestorableMongoDBCollectionResourceInfo() { }
        public string CollectionId { get { throw null; } }
        public string CollectionName { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableMongoDBDatabaseResourceInfo
    {
        internal ExtendedRestorableMongoDBDatabaseResourceInfo() { }
        public string DatabaseId { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableSqlContainerResourceInfo
    {
        internal ExtendedRestorableSqlContainerResourceInfo() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlContainerPropertiesResourceContainer Container { get { throw null; } }
        public string ContainerId { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableSqlDatabaseResourceInfo
    {
        internal ExtendedRestorableSqlDatabaseResourceInfo() { }
        public Azure.ResourceManager.CosmosDB.Models.RestorableSqlDatabasePropertiesResourceDatabase Database { get { throw null; } }
        public string DatabaseId { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
    }
    public partial class ExtendedRestorableTableResourceInfo
    {
        internal ExtendedRestorableTableResourceInfo() { }
        public string EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBOperationType? OperationType { get { throw null; } }
        public string Rid { get { throw null; } }
        public string TableId { get { throw null; } }
        public string TableName { get { throw null; } }
    }
    public partial class ExtendedThroughputSettingsResourceInfo : Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo
    {
        public ExtendedThroughputSettingsResourceInfo() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class GraphApiComputeRegionalService : Azure.ResourceManager.CosmosDB.Models.CosmosDBRegionalService
    {
        internal GraphApiComputeRegionalService() { }
        public string GraphApiComputeEndpoint { get { throw null; } }
    }
    public partial class GraphApiComputeServiceProperties : Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties
    {
        public GraphApiComputeServiceProperties() { }
        public string GraphApiComputeEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.GraphApiComputeRegionalService> Locations { get { throw null; } }
    }
    public partial class GraphResourceGetPropertiesOptions : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public GraphResourceGetPropertiesOptions() { }
    }
    public partial class GraphResourceGetResultCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GraphResourceGetResultCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinDatabaseCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinDatabaseResourceInfo Resource { get { throw null; } set { } }
        public string ResourceDatabaseName { get { throw null; } set { } }
    }
    public partial class GremlinDatabasePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public GremlinDatabasePropertiesConfig() { }
    }
    public partial class GremlinDatabaseResourceInfo
    {
        public GremlinDatabaseResourceInfo(string databaseName) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseRestoreResourceInfo
    {
        public GremlinDatabaseRestoreResourceInfo() { }
        public string DatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GraphNames { get { throw null; } }
    }
    public partial class GremlinGraphCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GremlinGraphCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.GremlinGraphResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class GremlinGraphPropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public GremlinGraphPropertiesConfig() { }
    }
    public partial class GremlinGraphResourceInfo
    {
        public GremlinGraphResourceInfo(string graphName) { }
        public long? AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ConflictResolutionPolicy ConflictResolutionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public int? DefaultTtl { get { throw null; } set { } }
        public string GraphName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBIndexingPolicy IndexingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBContainerPartitionKey PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBUniqueKey> UniqueKeys { get { throw null; } }
    }
    public partial class ListConnectionStringsResult
    {
        internal ListConnectionStringsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.CosmosDBConnectionString> ConnectionStrings { get { throw null; } }
    }
    public partial class MaterializedViewDefinition
    {
        public MaterializedViewDefinition(string sourceCollectionId, string definition) { }
        public string Definition { get { throw null; } set { } }
        public string SourceCollectionId { get { throw null; } set { } }
        public string SourceCollectionRid { get { throw null; } }
    }
    public partial class MaterializedViewsBuilderRegionalService : Azure.ResourceManager.CosmosDB.Models.CosmosDBRegionalService
    {
        internal MaterializedViewsBuilderRegionalService() { }
    }
    public partial class MaterializedViewsBuilderServiceProperties : Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties
    {
        public MaterializedViewsBuilderServiceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.MaterializedViewsBuilderRegionalService> Locations { get { throw null; } }
    }
    public partial class MergeParameters
    {
        public MergeParameters() { }
        public bool? IsDryRun { get { throw null; } set { } }
    }
    public partial class MongoClusterPatch
    {
        public MongoClusterPatch() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus? ClusterStatus { get { throw null; } }
        public string ConnectionString { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public string EarliestRestoreTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.NodeGroupSpec> NodeGroupSpecs { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MongoClusterRestoreParameters RestoreParameters { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MongoClusterRestoreParameters
    {
        public MongoClusterRestoreParameters() { }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterStatus : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Dropping { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus left, Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus left, Azure.ResourceManager.CosmosDB.Models.MongoClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBCollectionCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBCollectionCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBCollectionResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class MongoDBCollectionPropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public MongoDBCollectionPropertiesConfig() { }
    }
    public partial class MongoDBCollectionResourceInfo
    {
        public MongoDBCollectionResourceInfo(string collectionName) { }
        public int? AnalyticalStorageTtl { get { throw null; } set { } }
        public string CollectionName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBIndex> Indexes { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ShardKey { get { throw null; } }
    }
    public partial class MongoDBDatabaseCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MongoDBDatabaseCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBCreateUpdateConfig Options { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBDatabaseResourceInfo Resource { get { throw null; } set { } }
        public string ResourceDatabaseName { get { throw null; } set { } }
    }
    public partial class MongoDBDatabasePropertiesConfig : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseConfig
    {
        public MongoDBDatabasePropertiesConfig() { }
    }
    public partial class MongoDBDatabaseResourceInfo
    {
        public MongoDBDatabaseResourceInfo(string databaseName) { }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountCreateMode? CreateMode { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ResourceRestoreParameters RestoreParameters { get { throw null; } set { } }
    }
    public partial class MongoDBIndex
    {
        public MongoDBIndex() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBIndexConfig Options { get { throw null; } set { } }
    }
    public partial class MongoDBIndexConfig
    {
        public MongoDBIndexConfig() { }
        public int? ExpireAfterSeconds { get { throw null; } set { } }
        public bool? IsUnique { get { throw null; } set { } }
    }
    public partial class MongoDBPrivilege
    {
        public MongoDBPrivilege() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBPrivilegeResourceInfo Resource { get { throw null; } set { } }
    }
    public partial class MongoDBPrivilegeResourceInfo
    {
        public MongoDBPrivilegeResourceInfo() { }
        public string Collection { get { throw null; } set { } }
        public string DBName { get { throw null; } set { } }
    }
    public partial class MongoDBRole
    {
        public MongoDBRole() { }
        public string DBName { get { throw null; } set { } }
        public string Role { get { throw null; } set { } }
    }
    public partial class MongoDBRoleDefinitionCreateOrUpdateContent
    {
        public MongoDBRoleDefinitionCreateOrUpdateContent() { }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.MongoDBRoleDefinitionType? DefinitionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBPrivilege> Privileges { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBRole> Roles { get { throw null; } }
    }
    public enum MongoDBRoleDefinitionType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public partial class MongoDBUserDefinitionCreateOrUpdateContent
    {
        public MongoDBUserDefinitionCreateOrUpdateContent() { }
        public string CustomData { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Mechanisms { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.MongoDBRole> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
    }
    public enum NetworkAclBypass
    {
        None = 0,
        AzureServices = 1,
    }
    public partial class NodeGroupProperties
    {
        public NodeGroupProperties() { }
        public long? DiskSizeInGB { get { throw null; } set { } }
        public bool? EnableHa { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class NodeGroupSpec : Azure.ResourceManager.CosmosDB.Models.NodeGroupProperties
    {
        public NodeGroupSpec() { }
        public Azure.ResourceManager.CosmosDB.Models.NodeKind? Kind { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeKind : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.NodeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeKind(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.NodeKind Shard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.NodeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.NodeKind left, Azure.ResourceManager.CosmosDB.Models.NodeKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.NodeKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.NodeKind left, Azure.ResourceManager.CosmosDB.Models.NodeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartitionMetric : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseMetric
    {
        internal PartitionMetric() { }
        public System.Guid? PartitionId { get { throw null; } }
        public string PartitionKeyRangeId { get { throw null; } }
    }
    public partial class PartitionUsage : Azure.ResourceManager.CosmosDB.Models.CosmosDBBaseUsage
    {
        internal PartitionUsage() { }
        public System.Guid? PartitionId { get { throw null; } }
        public string PartitionKeyRangeId { get { throw null; } }
    }
    public partial class PercentileMetricValue : Azure.ResourceManager.CosmosDB.Models.CosmosDBMetricValue
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
    public partial class PeriodicModeBackupPolicy : Azure.ResourceManager.CosmosDB.Models.CosmosDBAccountBackupPolicy
    {
        public PeriodicModeBackupPolicy() { }
        public Azure.ResourceManager.CosmosDB.Models.PeriodicModeProperties PeriodicModeProperties { get { throw null; } set { } }
    }
    public partial class PeriodicModeProperties
    {
        public PeriodicModeProperties() { }
        public int? BackupIntervalInMinutes { get { throw null; } set { } }
        public int? BackupRetentionIntervalInHours { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.CosmosDBBackupStorageRedundancy? BackupStorageRedundancy { get { throw null; } set { } }
    }
    public partial class PhysicalPartitionStorageInfo
    {
        internal PhysicalPartitionStorageInfo() { }
        public string Id { get { throw null; } }
        public double? StorageInKB { get { throw null; } }
    }
    public partial class PhysicalPartitionStorageInfoCollection
    {
        internal PhysicalPartitionStorageInfoCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionStorageInfo> PhysicalPartitionStorageInfoCollectionValue { get { throw null; } }
    }
    public partial class PhysicalPartitionThroughputInfoResource
    {
        public PhysicalPartitionThroughputInfoResource(string id) { }
        public string Id { get { throw null; } set { } }
        public double? Throughput { get { throw null; } set { } }
    }
    public partial class PhysicalPartitionThroughputInfoResult : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PhysicalPartitionThroughputInfoResult(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResource> ResourcePhysicalPartitionThroughputInfo { get { throw null; } }
    }
    public partial class RedistributeThroughputParameters : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RedistributeThroughputParameters(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputPropertiesResource resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.RedistributeThroughputPropertiesResource Resource { get { throw null; } set { } }
    }
    public partial class RedistributeThroughputPropertiesResource
    {
        public RedistributeThroughputPropertiesResource(Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType throughputPolicy, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResource> targetPhysicalPartitionThroughputInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResource> sourcePhysicalPartitionThroughputInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResource> SourcePhysicalPartitionThroughputInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.PhysicalPartitionThroughputInfoResource> TargetPhysicalPartitionThroughputInfo { get { throw null; } }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType ThroughputPolicy { get { throw null; } set { } }
    }
    public partial class RegionForOnlineOffline
    {
        public RegionForOnlineOffline(string region) { }
        public string Region { get { throw null; } }
    }
    public partial class ResourceRestoreParameters : Azure.ResourceManager.CosmosDB.Models.RestoreParametersBase
    {
        public ResourceRestoreParameters() { }
    }
    public partial class RestorableGremlinDatabase : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableGremlinDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableGremlinDatabaseResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableGremlinGraph : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableGremlinGraph() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableGremlinGraphResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableGremlinResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableGremlinResourceData() { }
        public string DatabaseName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GraphNames { get { throw null; } }
    }
    public partial class RestorableLocationResourceInfo
    {
        internal RestorableLocationResourceInfo() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? LocationName { get { throw null; } }
        public string RegionalDatabaseAccountInstanceId { get { throw null; } }
    }
    public partial class RestorableMongoDBCollection : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableMongoDBCollection() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongoDBCollectionResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableMongoDBDatabase : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableMongoDBDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableMongoDBDatabaseResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableMongoDBResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableMongoDBResourceData() { }
        public System.Collections.Generic.IReadOnlyList<string> CollectionNames { get { throw null; } }
        public string DatabaseName { get { throw null; } }
    }
    public partial class RestorableSqlContainer : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableSqlContainer() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlContainerResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableSqlContainerPropertiesResourceContainer : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlContainerResourceInfo
    {
        public RestorableSqlContainerPropertiesResourceContainer(string containerName) : base (default(string)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public string Self { get { throw null; } }
        public float? Timestamp { get { throw null; } }
    }
    public partial class RestorableSqlDatabase : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableSqlDatabase() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableSqlDatabaseResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableSqlDatabasePropertiesResourceDatabase : Azure.ResourceManager.CosmosDB.Models.CosmosDBSqlDatabaseResourceInfo
    {
        public RestorableSqlDatabasePropertiesResourceDatabase(string databaseName) : base (default(string)) { }
        public string Colls { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Rid { get { throw null; } }
        public string Self { get { throw null; } }
        public float? Timestamp { get { throw null; } }
        public string Users { get { throw null; } }
    }
    public partial class RestorableSqlResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableSqlResourceData() { }
        public System.Collections.Generic.IReadOnlyList<string> CollectionNames { get { throw null; } }
        public string DatabaseName { get { throw null; } }
    }
    public partial class RestorableTable : Azure.ResourceManager.Models.ResourceData
    {
        internal RestorableTable() { }
        public Azure.ResourceManager.CosmosDB.Models.ExtendedRestorableTableResourceInfo Resource { get { throw null; } }
    }
    public partial class RestorableTableResourceData
    {
        internal RestorableTableResourceData() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class RestoreParametersBase
    {
        public RestoreParametersBase() { }
        public string RestoreSource { get { throw null; } set { } }
        public System.DateTimeOffset? RestoreTimestampInUtc { get { throw null; } set { } }
    }
    public partial class RetrieveThroughputParameters : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RetrieveThroughputParameters(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.RetrieveThroughputPropertiesResource resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ResourcePhysicalPartitionIds { get { throw null; } set { } }
    }
    public partial class RetrieveThroughputPropertiesResource
    {
        public RetrieveThroughputPropertiesResource(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> physicalPartitionIds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> PhysicalPartitionIds { get { throw null; } }
    }
    public partial class SpatialSpec
    {
        public SpatialSpec() { }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDB.Models.CosmosDBSpatialType> Types { get { throw null; } }
    }
    public partial class SqlDedicatedGatewayRegionalService : Azure.ResourceManager.CosmosDB.Models.CosmosDBRegionalService
    {
        internal SqlDedicatedGatewayRegionalService() { }
        public string SqlDedicatedGatewayEndpoint { get { throw null; } }
    }
    public partial class SqlDedicatedGatewayServiceProperties : Azure.ResourceManager.CosmosDB.Models.CosmosDBServiceProperties
    {
        public SqlDedicatedGatewayServiceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDB.Models.SqlDedicatedGatewayRegionalService> Locations { get { throw null; } }
        public string SqlDedicatedGatewayEndpoint { get { throw null; } set { } }
    }
    public partial class ThroughputPolicyResourceInfo
    {
        public ThroughputPolicyResourceInfo() { }
        public int? IncrementPercent { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThroughputPolicyType : System.IEquatable<Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThroughputPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType Custom { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType Equal { get { throw null; } }
        public static Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType left, Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType left, Azure.ResourceManager.CosmosDB.Models.ThroughputPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThroughputSettingsResourceInfo
    {
        public ThroughputSettingsResourceInfo() { }
        public Azure.ResourceManager.CosmosDB.Models.AutoscaleSettingsResourceInfo AutoscaleSettings { get { throw null; } set { } }
        public string InstantMaximumThroughput { get { throw null; } }
        public string MinimumThroughput { get { throw null; } }
        public string OfferReplacePending { get { throw null; } }
        public string SoftAllowedMaximumThroughput { get { throw null; } }
        public int? Throughput { get { throw null; } set { } }
    }
    public partial class ThroughputSettingsUpdateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ThroughputSettingsUpdateData(Azure.Core.AzureLocation location, Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo resource) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDB.Models.ThroughputSettingsResourceInfo Resource { get { throw null; } set { } }
    }
}
