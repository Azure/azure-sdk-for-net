namespace Azure.ResourceManager.RedisEnterpriseCache
{
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.RedisEnterpriseCache.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.RedisEnterpriseCache.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateLinkResource> GetPrivateLinkResourcesByCluster(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateLinkResource> GetPrivateLinkResourcesByClusterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> GetRedisEnterpriseCachePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>> GetRedisEnterpriseCachePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionCollection GetRedisEnterpriseCachePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.RedisEnterpriseCache.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.RedisEnterpriseCache.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol? ClientProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy? ClusteringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.DatabasePropertiesGeoReplication GeoReplication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterpriseCache.Models.Module> Modules { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.Persistence Persistence { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState? ResourceState { get { throw null; } }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ExportClusterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ExportClusterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ForceUnlink(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ForceUnlinkContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ForceUnlinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ForceUnlinkContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Import(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ImportClusterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.ImportClusterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.Models.AccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.Models.AccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.DatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.Models.DatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RedisEnterpriseCacheExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource GetRedisEnterpriseCachePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.OperationStatus> GetRedisEnterpriseOperationsStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.Models.OperationStatus>> GetRedisEnterpriseOperationsStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisEnterpriseCachePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected RedisEnterpriseCachePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterpriseCachePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterpriseCachePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RedisEnterpriseCachePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterpriseCachePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RedisEnterpriseCache.Models
{
    public partial class AccessKeys
    {
        internal AccessKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public enum AccessKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AofFrequency : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AofFrequency(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency Always { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency OneS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusteringPolicy : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusteringPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy EnterpriseCluster { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy OSSCluster { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterpriseCache.RedisEnterpriseCachePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DatabasePatch
    {
        public DatabasePatch() { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol? ClientProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ClusteringPolicy? ClusteringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.DatabasePropertiesGeoReplication GeoReplication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterpriseCache.Models.Module> Modules { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.Persistence Persistence { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState? ResourceState { get { throw null; } }
    }
    public partial class DatabasePropertiesGeoReplication
    {
        public DatabasePropertiesGeoReplication() { }
        public string GroupNickname { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterpriseCache.Models.LinkedDatabase> LinkedDatabases { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicy : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy AllKeysLFU { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy AllKeysLRU { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy AllKeysRandom { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy NoEviction { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy VolatileLFU { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy VolatileLRU { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy VolatileRandom { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy VolatileTTL { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy left, Azure.ResourceManager.RedisEnterpriseCache.Models.EvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportClusterContent
    {
        public ExportClusterContent(System.Uri sasUri) { }
        public System.Uri SasUri { get { throw null; } }
    }
    public partial class ForceUnlinkContent
    {
        public ForceUnlinkContent(System.Collections.Generic.IEnumerable<string> ids) { }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
    }
    public partial class ImportClusterContent
    {
        public ImportClusterContent(System.Collections.Generic.IEnumerable<System.Uri> sasUris) { }
        public System.Collections.Generic.IList<System.Uri> SasUris { get { throw null; } }
    }
    public partial class LinkedDatabase
    {
        public LinkedDatabase() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState Linked { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState LinkFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState Linking { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState UnlinkFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState Unlinking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState left, Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState left, Azure.ResourceManager.RedisEnterpriseCache.Models.LinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Module
    {
        public Module(string name) { }
        public string Args { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public string EndTime { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class Persistence
    {
        public Persistence() { }
        public bool? AofEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.AofFrequency? AofFrequency { get { throw null; } set { } }
        public bool? RdbEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency? RdbFrequency { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol Encrypted { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol Plaintext { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol left, Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol left, Azure.ResourceManager.RedisEnterpriseCache.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState left, Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState left, Azure.ResourceManager.RedisEnterpriseCache.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RdbFrequency : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RdbFrequency(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency OneH { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency SixH { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency TwelveH { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency left, Azure.ResourceManager.RedisEnterpriseCache.Models.RdbFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseCachePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseCachePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseCachePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseCachePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseCachePrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterpriseCachePrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class RedisEnterpriseCachePrivateLinkServiceConnectionState
    {
        public RedisEnterpriseCachePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCachePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class RedisEnterpriseCacheSku
    {
        public RedisEnterpriseCacheSku(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseCacheSkuName : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseCacheSkuName(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseE10 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseE100 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseE20 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseE50 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseFlashF1500 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseFlashF300 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName EnterpriseFlashF700 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName left, Azure.ResourceManager.RedisEnterpriseCache.Models.RedisEnterpriseCacheSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyContent
    {
        public RegenerateKeyContent(Azure.ResourceManager.RedisEnterpriseCache.Models.AccessKeyType keyType) { }
        public Azure.ResourceManager.RedisEnterpriseCache.Models.AccessKeyType KeyType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceState : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState DisableFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState EnableFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Enabling { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState left, Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState left, Azure.ResourceManager.RedisEnterpriseCache.Models.ResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsVersion : System.IEquatable<Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion One0 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion One1 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion One2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion left, Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion left, Azure.ResourceManager.RedisEnterpriseCache.Models.TlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
}
