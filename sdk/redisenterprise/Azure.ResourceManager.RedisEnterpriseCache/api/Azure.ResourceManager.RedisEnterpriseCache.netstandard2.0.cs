namespace Azure.ResourceManager.RedisEnterpriseCache
{
    public static partial class RedisEnterpriseCacheExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> GetRedisEnterpriseCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> GetRedisEnterpriseClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource GetRedisEnterpriseClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterCollection GetRedisEnterpriseClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> GetRedisEnterpriseClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> GetRedisEnterpriseClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource GetRedisEnterpriseDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseOperationStatus> GetRedisEnterpriseOperationsStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseOperationStatus>> GetRedisEnterpriseOperationsStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource GetRedisEnterprisePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class RedisEnterpriseClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>, System.Collections.IEnumerable
    {
        protected RedisEnterpriseClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterpriseClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RedisEnterpriseClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class RedisEnterpriseClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterpriseClusterResource() { }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateLinkResource> GetPrivateLinkResourcesByCluster(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateLinkResource> GetPrivateLinkResourcesByClusterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> GetRedisEnterpriseDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>> GetRedisEnterpriseDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseCollection GetRedisEnterpriseDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> GetRedisEnterprisePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>> GetRedisEnterprisePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionCollection GetRedisEnterprisePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisEnterpriseDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>, System.Collections.IEnumerable
    {
        protected RedisEnterpriseDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterpriseDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterpriseDatabaseData() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol? ClientProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy? ClusteringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseGeoReplication GeoReplication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseModule> Modules { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettings Persistence { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
    }
    public partial class RedisEnterpriseDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterpriseDatabaseResource() { }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ExportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ExportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ForceUnlink(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ForceUnlinkRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ForceUnlinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ForceUnlinkRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDataAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDataAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Import(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ImportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ImportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDataAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDataAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected RedisEnterprisePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterprisePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterprisePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RedisEnterpriseCache.Models
{
    public partial class ExportRedisEnterpriseDatabaseContent
    {
        public ExportRedisEnterpriseDatabaseContent(System.Uri sasUri) { }
        public System.Uri SasUri { get { throw null; } }
    }
    public partial class ForceUnlinkRedisEnterpriseDatabaseContent
    {
        public ForceUnlinkRedisEnterpriseDatabaseContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> ids) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Ids { get { throw null; } }
    }
    public partial class ImportRedisEnterpriseDatabaseContent
    {
        public ImportRedisEnterpriseDatabaseContent(System.Collections.Generic.IEnumerable<System.Uri> sasUris) { }
        public System.Collections.Generic.IList<System.Uri> SasUris { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistenceSettingAofFrequency : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistenceSettingAofFrequency(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency Always { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency OneSecond { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistenceSettingRdbFrequency : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistenceSettingRdbFrequency(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency OneHour { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency SixHours { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency TwelveHours { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersistenceSettings
    {
        public PersistenceSettings() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingAofFrequency? AofFrequency { get { throw null; } set { } }
        public bool? IsAofEnabled { get { throw null; } set { } }
        public bool? IsRdbEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettingRdbFrequency? RdbFrequency { get { throw null; } set { } }
    }
    public enum RedisEnterpriseAccessKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseClientProtocol : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseClientProtocol(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol Encrypted { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol PlainText { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseClusteringPolicy : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseClusteringPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy EnterpriseCluster { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy OssCluster { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseClusterPatch
    {
        public RedisEnterpriseClusterPatch() { }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterprisePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseClusterResourceState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseClusterResourceState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState DisableFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState EnableFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Enabling { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseDataAccessKeys
    {
        internal RedisEnterpriseDataAccessKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class RedisEnterpriseDatabaseGeoReplication
    {
        public RedisEnterpriseDatabaseGeoReplication() { }
        public string GroupNickname { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseLinkedDatabase> LinkedDatabases { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseDatabaseLinkState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseDatabaseLinkState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState Linked { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState LinkFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState Linking { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState UnlinkFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState Unlinking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseDatabasePatch
    {
        public RedisEnterpriseDatabasePatch() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClientProtocol? ClientProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusteringPolicy? ClusteringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseGeoReplication GeoReplication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseModule> Modules { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.PersistenceSettings Persistence { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseEvictionPolicy : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseEvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy AllKeysLfu { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy AllKeysLru { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy AllKeysRandom { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy NoEviction { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy VolatileLfu { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy VolatileLru { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy VolatileRandom { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy VolatileTtl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseEvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseLinkedDatabase
    {
        public RedisEnterpriseLinkedDatabase() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseDatabaseLinkState? State { get { throw null; } }
    }
    public partial class RedisEnterpriseModule
    {
        public RedisEnterpriseModule(string name) { }
        public string Args { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class RedisEnterpriseOperationStatus
    {
        internal RedisEnterpriseOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterprisePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterprisePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterprisePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterprisePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterprisePrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterprisePrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class RedisEnterprisePrivateLinkServiceConnectionState
    {
        public RedisEnterprisePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseProvisioningStatus : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseRegenerateKeyContent
    {
        public RedisEnterpriseRegenerateKeyContent(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseAccessKeyType keyType) { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseAccessKeyType KeyType { get { throw null; } }
    }
    public partial class RedisEnterpriseSku
    {
        public RedisEnterpriseSku(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseSkuName : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseSkuName(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseE10 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseE100 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseE20 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseE50 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseFlashF1500 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseFlashF300 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName EnterpriseFlashF700 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseTlsVersion : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
}
