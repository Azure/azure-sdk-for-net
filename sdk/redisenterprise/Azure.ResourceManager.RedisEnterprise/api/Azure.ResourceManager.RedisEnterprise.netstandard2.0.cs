namespace Azure.ResourceManager.RedisEnterprise
{
    public partial class RedisEnterpriseClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>, System.Collections.IEnumerable
    {
        protected RedisEnterpriseClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterpriseClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RedisEnterpriseClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSku sku) { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class RedisEnterpriseClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterpriseClusterResource() { }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateLinkResource> GetPrivateLinkResourcesByCluster(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateLinkResource> GetPrivateLinkResourcesByClusterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> GetRedisEnterpriseDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>> GetRedisEnterpriseDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseCollection GetRedisEnterpriseDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> GetRedisEnterprisePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>> GetRedisEnterprisePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionCollection GetRedisEnterprisePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisEnterpriseDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>, System.Collections.IEnumerable
    {
        protected RedisEnterpriseDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterpriseDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterpriseDatabaseData() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol? ClientProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy? ClusteringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseGeoReplication GeoReplication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseModule> Modules { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisPersistenceSettings Persistence { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
    }
    public partial class RedisEnterpriseDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterpriseDatabaseResource() { }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.ExportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.ExportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Flush(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.FlushRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FlushAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.FlushRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ForceUnlink(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.ForceUnlinkRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ForceUnlinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.ForceUnlinkRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDataAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDataAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Import(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.ImportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.ImportRedisEnterpriseDatabaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDataAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDataAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RedisEnterpriseExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetRedisEnterpriseCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> GetRedisEnterpriseClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource GetRedisEnterpriseClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterCollection GetRedisEnterpriseClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetRedisEnterpriseClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetRedisEnterpriseClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource GetRedisEnterpriseDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseOperationStatus> GetRedisEnterpriseOperationsStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseOperationStatus>> GetRedisEnterpriseOperationsStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource GetRedisEnterprisePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegionSkuDetail> GetRedisEnterpriseSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegionSkuDetail> GetRedisEnterpriseSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected RedisEnterprisePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisEnterprisePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RedisEnterprisePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisEnterprisePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RedisEnterprise.Mocking
{
    public partial class MockableRedisEnterpriseArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRedisEnterpriseArmClient() { }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource GetRedisEnterpriseClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseResource GetRedisEnterpriseDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionResource GetRedisEnterprisePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRedisEnterpriseResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedisEnterpriseResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetRedisEnterpriseCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource>> GetRedisEnterpriseClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterCollection GetRedisEnterpriseClusters() { throw null; }
    }
    public partial class MockableRedisEnterpriseSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedisEnterpriseSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetRedisEnterpriseClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterResource> GetRedisEnterpriseClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseOperationStatus> GetRedisEnterpriseOperationsStatus(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseOperationStatus>> GetRedisEnterpriseOperationsStatusAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegionSkuDetail> GetRedisEnterpriseSkus(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegionSkuDetail> GetRedisEnterpriseSkusAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RedisEnterprise.Models
{
    public static partial class ArmRedisEnterpriseModelFactory
    {
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCapability RedisEnterpriseCapability(string name = null, bool? value = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterpriseClusterData RedisEnterpriseClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSku sku = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyEncryption customerManagedKeyEncryption = null, string hostName = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus? provisioningState = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState? resourceState = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState?), string redisVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDataAccessKeys RedisEnterpriseDataAccessKeys(string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterpriseDatabaseData RedisEnterpriseDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol? clientProtocol = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol?), int? port = default(int?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus? provisioningState = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState? resourceState = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy? clusteringPolicy = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy? evictionPolicy = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy?), Azure.ResourceManager.RedisEnterprise.Models.RedisPersistenceSettings persistence = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseModule> modules = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseGeoReplication geoReplication = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseLinkedDatabase RedisEnterpriseLinkedDatabase(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState? state = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState?)) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseLocationInfo RedisEnterpriseLocationInfo(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCapability> capabilities = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseModule RedisEnterpriseModule(string name = null, string args = null, string version = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseOperationStatus RedisEnterpriseOperationStatus(Azure.Core.ResourceIdentifier id = null, string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData RedisEnterprisePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateLinkResource RedisEnterprisePrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseRegionSkuDetail RedisEnterpriseRegionSkuDetail(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseLocationInfo locationInfo = null, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName? skuDetailsName = default(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName?)) { throw null; }
    }
    public partial class ExportRedisEnterpriseDatabaseContent
    {
        public ExportRedisEnterpriseDatabaseContent(System.Uri sasUri) { }
        public System.Uri SasUri { get { throw null; } }
    }
    public partial class FlushRedisEnterpriseDatabaseContent
    {
        public FlushRedisEnterpriseDatabaseContent() { }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
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
    public readonly partial struct PersistenceSettingAofFrequency : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistenceSettingAofFrequency(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency Always { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency OneSecond { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency left, Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency left, Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistenceSettingRdbFrequency : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistenceSettingRdbFrequency(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency OneHour { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency SixHours { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency TwelveHours { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency left, Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency left, Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum RedisEnterpriseAccessKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class RedisEnterpriseCapability
    {
        internal RedisEnterpriseCapability() { }
        public string Name { get { throw null; } }
        public bool? Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseClientProtocol : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseClientProtocol(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol Encrypted { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol PlainText { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseClusteringPolicy : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseClusteringPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy EnterpriseCluster { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy OssCluster { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseClusterPatch
    {
        public RedisEnterpriseClusterPatch() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterprise.RedisEnterprisePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseClusterResourceState : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseClusterResourceState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState DisableFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState EnableFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Enabling { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseCustomerManagedKeyEncryption
    {
        public RedisEnterpriseCustomerManagedKeyEncryption() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
    }
    public partial class RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity
    {
        public RedisEnterpriseCustomerManagedKeyEncryptionKeyIdentity() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseCustomerManagedKeyIdentityType : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseCustomerManagedKeyIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCustomerManagedKeyIdentityType right) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseLinkedDatabase> LinkedDatabases { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseDatabaseLinkState : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseDatabaseLinkState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState Linked { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState LinkFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState Linking { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState UnlinkFailed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState Unlinking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseDatabasePatch
    {
        public RedisEnterpriseDatabasePatch() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClientProtocol? ClientProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusteringPolicy? ClusteringPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseGeoReplication GeoReplication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseModule> Modules { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisPersistenceSettings Persistence { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseClusterResourceState? ResourceState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseEvictionPolicy : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseEvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy AllKeysLfu { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy AllKeysLru { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy AllKeysRandom { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy NoEviction { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy VolatileLfu { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy VolatileLru { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy VolatileRandom { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy VolatileTtl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseEvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseLinkedDatabase
    {
        public RedisEnterpriseLinkedDatabase() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseDatabaseLinkState? State { get { throw null; } }
    }
    public partial class RedisEnterpriseLocationInfo
    {
        internal RedisEnterpriseLocationInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseCapability> Capabilities { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
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
    public readonly partial struct RedisEnterprisePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterprisePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterprisePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterprisePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus right) { throw null; }
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
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterprisePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseProvisioningStatus : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisEnterpriseRegenerateKeyContent
    {
        public RedisEnterpriseRegenerateKeyContent(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseAccessKeyType keyType) { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseAccessKeyType KeyType { get { throw null; } }
    }
    public partial class RedisEnterpriseRegionSkuDetail
    {
        internal RedisEnterpriseRegionSkuDetail() { }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseLocationInfo LocationInfo { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName? SkuDetailsName { get { throw null; } }
    }
    public partial class RedisEnterpriseSku
    {
        public RedisEnterpriseSku(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseSkuName : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseSkuName(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseE10 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseE100 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseE20 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseE50 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseFlashF1500 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseFlashF300 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName EnterpriseFlashF700 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisEnterpriseTlsVersion : System.IEquatable<Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisEnterpriseTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion left, Azure.ResourceManager.RedisEnterprise.Models.RedisEnterpriseTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisPersistenceSettings
    {
        public RedisPersistenceSettings() { }
        public Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingAofFrequency? AofFrequency { get { throw null; } set { } }
        public bool? IsAofEnabled { get { throw null; } set { } }
        public bool? IsRdbEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.RedisEnterprise.Models.PersistenceSettingRdbFrequency? RdbFrequency { get { throw null; } set { } }
    }
}
