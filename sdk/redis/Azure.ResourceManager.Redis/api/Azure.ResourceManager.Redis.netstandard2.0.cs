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
        public Azure.ResourceManager.Redis.Models.RedisTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public int? Port { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } set { } }
        public int? SslPort { get { throw null; } }
        public System.Net.IPAddress StaticIP { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public static partial class RedisExtensions
    {
        public static Azure.Response CheckRedisNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckRedisNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCollection GetAllRedis(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Redis.RedisResource> GetAllRedis(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisResource> GetAllRedisAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Redis.Models.RedisOperationStatus> GetAsyncOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisOperationStatus>> GetAsyncOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public RedisFirewallRuleData(System.Net.IPAddress startIP, System.Net.IPAddress endIP) { }
        public System.Net.IPAddress EndIP { get { throw null; } set { } }
        public System.Net.IPAddress StartIP { get { throw null; } set { } }
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
        public string GeoReplicatedPrimaryHostName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRedisCacheId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? LinkedRedisCacheLocation { get { throw null; } set { } }
        public string PrimaryHostName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisLinkedServerRole? ServerRole { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Get(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisPatchScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisPatchScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisPatchScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public RedisPatchScheduleData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting> scheduleEntries) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting> ScheduleEntries { get { throw null; } }
    }
    public partial class RedisPatchScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisPatchScheduleResource() { }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName) { throw null; }
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
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState RedisPrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState? RedisProvisioningState { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation ExportData(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ExportRdbContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportDataAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ExportRdbContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisForceRebootResult> ForceReboot(Azure.ResourceManager.Redis.Models.RedisRebootContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>> ForceRebootAsync(Azure.ResourceManager.Redis.Models.RedisRebootContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetRedisPatchSchedule(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetRedisPatchScheduleAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName defaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleCollection GetRedisPatchSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetRedisPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetRedisPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionCollection GetRedisPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification> GetUpgradeNotifications(double history, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification> GetUpgradeNotificationsAsync(double history, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportData(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ImportRdbContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportDataAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ImportRdbContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys> RegenerateKey(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use another long-running operation with same method name instead.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> Update(Azure.ResourceManager.Redis.Models.RedisPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use another long-running operation with same method name instead.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> UpdateAsync(Azure.ResourceManager.Redis.Models.RedisPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Redis.Models
{
    public partial class ExportRdbContent
    {
        public ExportRdbContent(string prefix, string container) { }
        public string Container { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } set { } }
        public string Prefix { get { throw null; } }
    }
    public partial class ImportRdbContent
    {
        public ImportRdbContent(System.Collections.Generic.IEnumerable<string> files) { }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } set { } }
    }
    public partial class RedisAccessKeys
    {
        internal RedisAccessKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class RedisCommonConfiguration
    {
        public RedisCommonConfiguration() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AofStorageConnectionString0 { get { throw null; } set { } }
        public string AofStorageConnectionString1 { get { throw null; } set { } }
        public string AuthNotRequired { get { throw null; } set { } }
        public bool? IsAofBackupEnabled { get { throw null; } set { } }
        public bool? IsRdbBackupEnabled { get { throw null; } set { } }
        public string MaxClients { get { throw null; } }
        public string MaxFragmentationMemoryReserved { get { throw null; } set { } }
        public string MaxMemoryDelta { get { throw null; } set { } }
        public string MaxMemoryPolicy { get { throw null; } set { } }
        public string MaxMemoryReserved { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } }
        public string PreferredDataPersistenceAuthMethod { get { throw null; } }
        public string RdbBackupFrequency { get { throw null; } set { } }
        public int? RdbBackupMaxSnapshotCount { get { throw null; } set { } }
        public string RdbStorageConnectionString { get { throw null; } set { } }
        public string ZonalConfiguration { get { throw null; } }
    }
    public partial class RedisCreateOrUpdateContent
    {
        public RedisCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Redis.Models.RedisSku sku) { }
        public bool? EnableNonSslPort { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } }
        public System.Net.IPAddress StaticIP { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public enum RedisDayOfWeek
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
    public partial class RedisForceRebootResult
    {
        internal RedisForceRebootResult() { }
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
    public enum RedisLinkedServerRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class RedisLinkedServerWithPropertyCreateOrUpdateContent
    {
        public RedisLinkedServerWithPropertyCreateOrUpdateContent(Azure.Core.ResourceIdentifier linkedRedisCacheId, Azure.Core.AzureLocation linkedRedisCacheLocation, Azure.ResourceManager.Redis.Models.RedisLinkedServerRole serverRole) { }
        public string GeoReplicatedPrimaryHostName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRedisCacheId { get { throw null; } }
        public Azure.Core.AzureLocation LinkedRedisCacheLocation { get { throw null; } }
        public string PrimaryHostName { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisLinkedServerRole ServerRole { get { throw null; } }
    }
    public partial class RedisNameAvailabilityContent
    {
        public RedisNameAvailabilityContent(string name, Azure.Core.ResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
    }
    public partial class RedisOperationStatus : Azure.ResourceManager.Models.OperationStatusResult
    {
        internal RedisOperationStatus() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Properties { get { throw null; } }
    }
    public partial class RedisPatch
    {
        public RedisPatch() { }
        public bool? EnableNonSslPort { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPatchScheduleDefaultName : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPatchScheduleDefaultName(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName left, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName left, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisPatchScheduleSetting
    {
        public RedisPatchScheduleSetting(Azure.ResourceManager.Redis.Models.RedisDayOfWeek dayOfWeek, int startHourUtc) { }
        public Azure.ResourceManager.Redis.Models.RedisDayOfWeek DayOfWeek { get { throw null; } set { } }
        public System.TimeSpan? MaintenanceWindow { get { throw null; } set { } }
        public int StartHourUtc { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Linking { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState RecoveringScaleFailure { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Unlinking { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Unprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisProvisioningState left, Azure.ResourceManager.Redis.Models.RedisProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisProvisioningState left, Azure.ResourceManager.Redis.Models.RedisProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess left, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess left, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisRebootContent
    {
        public RedisRebootContent() { }
        public System.Collections.Generic.IList<int> Ports { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisRebootType? RebootType { get { throw null; } set { } }
        public int? ShardId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisRebootType : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisRebootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisRebootType(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisRebootType AllNodes { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisRebootType PrimaryNode { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisRebootType SecondaryNode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisRebootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisRebootType left, Azure.ResourceManager.Redis.Models.RedisRebootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisRebootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisRebootType left, Azure.ResourceManager.Redis.Models.RedisRebootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisRegenerateKeyContent
    {
        public RedisRegenerateKeyContent(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyType keyType) { }
        public Azure.ResourceManager.Redis.Models.RedisRegenerateKeyType KeyType { get { throw null; } }
    }
    public enum RedisRegenerateKeyType
    {
        Primary = 0,
        Secondary = 1,
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
        public static Azure.ResourceManager.Redis.Models.RedisSkuFamily BasicOrStandard { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuFamily Premium { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisTlsVersion : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisTlsVersion left, Azure.ResourceManager.Redis.Models.RedisTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisTlsVersion left, Azure.ResourceManager.Redis.Models.RedisTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisUpgradeNotification
    {
        internal RedisUpgradeNotification() { }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> UpsellNotification { get { throw null; } }
    }
}
