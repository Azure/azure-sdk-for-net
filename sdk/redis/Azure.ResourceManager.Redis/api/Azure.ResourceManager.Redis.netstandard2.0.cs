namespace Azure.ResourceManager.Redis
{
    public partial class RedisCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisResource>, System.Collections.IEnumerable
    {
        protected RedisCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RedisData(Azure.Core.AzureLocation location, Azure.ResourceManager.Redis.Models.RedisSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Redis.Models.RedisAccessKeys AccessKeys { get { throw null; } }
        public bool? EnableNonSslPort { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> Instances { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> LinkedServers { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public int? Port { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonPropertiesRedisConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } set { } }
        public int? SslPort { get { throw null; } }
        public string StaticIP { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public static partial class RedisExtensions
    {
        public static Azure.Response CheckRedisNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Redis.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckRedisNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Redis.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCollection GetAllRedis(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Redis.RedisResource> GetAllRedis(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisResource> GetAllRedisAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Redis.Models.OperationStatus> GetAsyncOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.OperationStatus>> GetAsyncOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Redis.RedisResource> GetRedis(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetRedisAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Redis.RedisFirewallRuleResource GetRedisFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource GetRedisLinkedServerWithPropertyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPatchScheduleResource GetRedisPatchScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource GetRedisPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisResource GetRedisResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class RedisFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected RedisFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisFirewallRuleData(string startIP, string endIP) { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
    }
    public partial class RedisFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisFirewallRuleResource() { }
        public virtual Azure.ResourceManager.Redis.RedisFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisLinkedServerWithPropertyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>, System.Collections.IEnumerable
    {
        protected RedisLinkedServerWithPropertyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServerName, Azure.ResourceManager.Redis.Models.RedisLinkedServerWithPropertyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServerName, Azure.ResourceManager.Redis.Models.RedisLinkedServerWithPropertyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> Get(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisLinkedServerWithPropertyData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisLinkedServerWithPropertyData() { }
        public string LinkedRedisCacheId { get { throw null; } set { } }
        public string LinkedRedisCacheLocation { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.ReplicationRole? ServerRole { get { throw null; } set { } }
    }
    public partial class RedisLinkedServerWithPropertyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisLinkedServerWithPropertyResource() { }
        public virtual Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string linkedServerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisLinkedServerWithPropertyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisLinkedServerWithPropertyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisPatchScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>, System.Collections.IEnumerable
    {
        protected RedisPatchScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.DefaultName defaultName, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.DefaultName defaultName, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Redis.Models.DefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Redis.Models.DefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Get(Azure.ResourceManager.Redis.Models.DefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetAsync(Azure.ResourceManager.Redis.Models.DefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisPatchScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisPatchScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisPatchScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisPatchScheduleData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.ScheduleEntry> scheduleEntries) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Redis.Models.ScheduleEntry> ScheduleEntries { get { throw null; } }
    }
    public partial class RedisPatchScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisPatchScheduleResource() { }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.Redis.Models.DefaultName defaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected RedisPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RedisPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisResource() { }
        public virtual Azure.ResourceManager.Redis.RedisData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExportData(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ExportRDBContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportDataAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ExportRDBContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisForceRebootResponse> ForceReboot(Azure.ResourceManager.Redis.Models.RedisRebootContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisForceRebootResponse>> ForceRebootAsync(Azure.ResourceManager.Redis.Models.RedisRebootContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource> GetPrivateLinkResourcesByRedisCache(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource> GetPrivateLinkResourcesByRedisCacheAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetRedisFirewallRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetRedisFirewallRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisFirewallRuleCollection GetRedisFirewallRules() { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyCollection GetRedisLinkedServerWithProperties() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetRedisLinkedServerWithProperty(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetRedisLinkedServerWithPropertyAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetRedisPatchSchedule(Azure.ResourceManager.Redis.Models.DefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetRedisPatchScheduleAsync(Azure.ResourceManager.Redis.Models.DefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleCollection GetRedisPatchSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetRedisPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetRedisPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionCollection GetRedisPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.Models.UpgradeNotification> GetUpgradeNotifications(double history, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.Models.UpgradeNotification> GetUpgradeNotificationsAsync(double history, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportData(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ImportRDBContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportDataAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ImportRDBContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys> RegenerateKey(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> Update(Azure.ResourceManager.Redis.Models.RedisPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> UpdateAsync(Azure.ResourceManager.Redis.Models.RedisPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Redis.Models
{
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name, string resourceType) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum DayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
        Everyday = 7,
        Weekend = 8,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultName : System.IEquatable<Azure.ResourceManager.Redis.Models.DefaultName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultName(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.DefaultName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.DefaultName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.DefaultName left, Azure.ResourceManager.Redis.Models.DefaultName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.DefaultName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.DefaultName left, Azure.ResourceManager.Redis.Models.DefaultName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportRDBContent
    {
        public ExportRDBContent(string prefix, string container) { }
        public string Container { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string Prefix { get { throw null; } }
    }
    public partial class ImportRDBContent
    {
        public ImportRDBContent(System.Collections.Generic.IEnumerable<string> files) { }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public string Format { get { throw null; } set { } }
    }
    public partial class OperationStatus : Azure.ResourceManager.Models.OperationStatusResult
    {
        internal OperationStatus() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Linking { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState RecoveringScaleFailure { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Unlinking { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Unprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.ProvisioningState left, Azure.ResourceManager.Redis.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.ProvisioningState left, Azure.ResourceManager.Redis.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Redis.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.PublicNetworkAccess left, Azure.ResourceManager.Redis.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.PublicNetworkAccess left, Azure.ResourceManager.Redis.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RebootType : System.IEquatable<Azure.ResourceManager.Redis.Models.RebootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RebootType(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RebootType AllNodes { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RebootType PrimaryNode { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RebootType SecondaryNode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RebootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RebootType left, Azure.ResourceManager.Redis.Models.RebootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RebootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RebootType left, Azure.ResourceManager.Redis.Models.RebootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisAccessKeys
    {
        internal RedisAccessKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class RedisCommonPropertiesRedisConfiguration
    {
        public RedisCommonPropertiesRedisConfiguration() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AofBackupEnabled { get { throw null; } set { } }
        public string AofStorageConnectionString0 { get { throw null; } set { } }
        public string AofStorageConnectionString1 { get { throw null; } set { } }
        public string Authnotrequired { get { throw null; } set { } }
        public string Maxclients { get { throw null; } }
        public string MaxfragmentationmemoryReserved { get { throw null; } set { } }
        public string MaxmemoryDelta { get { throw null; } set { } }
        public string MaxmemoryPolicy { get { throw null; } set { } }
        public string MaxmemoryReserved { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } }
        public string PreferredDataPersistenceAuthMethod { get { throw null; } }
        public string RdbBackupEnabled { get { throw null; } set { } }
        public string RdbBackupFrequency { get { throw null; } set { } }
        public string RdbBackupMaxSnapshotCount { get { throw null; } set { } }
        public string RdbStorageConnectionString { get { throw null; } set { } }
        public string ZonalConfiguration { get { throw null; } }
    }
    public partial class RedisCreateOrUpdateContent
    {
        public RedisCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Redis.Models.RedisSku sku) { }
        public bool? EnableNonSslPort { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonPropertiesRedisConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } }
        public string StaticIP { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class RedisForceRebootResponse
    {
        internal RedisForceRebootResponse() { }
        public string Message { get { throw null; } }
    }
    public partial class RedisInstanceDetails
    {
        internal RedisInstanceDetails() { }
        public bool? IsMaster { get { throw null; } }
        public bool? IsPrimary { get { throw null; } }
        public int? NonSslPort { get { throw null; } }
        public int? ShardId { get { throw null; } }
        public int? SslPort { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    public enum RedisKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class RedisLinkedServerWithPropertyCreateOrUpdateContent
    {
        public RedisLinkedServerWithPropertyCreateOrUpdateContent(string linkedRedisCacheId, string linkedRedisCacheLocation, Azure.ResourceManager.Redis.Models.ReplicationRole serverRole) { }
        public string LinkedRedisCacheId { get { throw null; } }
        public string LinkedRedisCacheLocation { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.ReplicationRole ServerRole { get { throw null; } }
    }
    public partial class RedisPatch
    {
        public RedisPatch() { }
        public bool? EnableNonSslPort { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonPropertiesRedisConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public RedisPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class RedisPrivateLinkServiceConnectionState
    {
        public RedisPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class RedisRebootContent
    {
        public RedisRebootContent() { }
        public System.Collections.Generic.IList<int> Ports { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RebootType? RebootType { get { throw null; } set { } }
        public int? ShardId { get { throw null; } set { } }
    }
    public partial class RedisRegenerateKeyContent
    {
        public RedisRegenerateKeyContent(Azure.ResourceManager.Redis.Models.RedisKeyType keyType) { }
        public Azure.ResourceManager.Redis.Models.RedisKeyType KeyType { get { throw null; } }
    }
    public partial class RedisSku
    {
        public RedisSku(Azure.ResourceManager.Redis.Models.RedisSkuName name, Azure.ResourceManager.Redis.Models.RedisSkuFamily family, int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisSkuFamily : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisSkuFamily C { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuFamily P { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisSkuFamily left, Azure.ResourceManager.Redis.Models.RedisSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisSkuFamily left, Azure.ResourceManager.Redis.Models.RedisSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisSkuName : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisSkuName left, Azure.ResourceManager.Redis.Models.RedisSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisSkuName left, Azure.ResourceManager.Redis.Models.RedisSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ReplicationRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class ScheduleEntry
    {
        public ScheduleEntry(Azure.ResourceManager.Redis.Models.DayOfWeek dayOfWeek, int startHourUtc) { }
        public Azure.ResourceManager.Redis.Models.DayOfWeek DayOfWeek { get { throw null; } set { } }
        public System.TimeSpan? MaintenanceWindow { get { throw null; } set { } }
        public int StartHourUtc { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsVersion : System.IEquatable<Azure.ResourceManager.Redis.Models.TlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.TlsVersion One0 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.TlsVersion One1 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.TlsVersion One2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.TlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.TlsVersion left, Azure.ResourceManager.Redis.Models.TlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.TlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.TlsVersion left, Azure.ResourceManager.Redis.Models.TlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpgradeNotification
    {
        internal UpgradeNotification() { }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> UpsellNotification { get { throw null; } }
    }
}
