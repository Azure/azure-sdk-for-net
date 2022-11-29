namespace Azure.ResourceManager.PostgreSql
{
    public partial class PostgreSqlConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class PostgreSqlConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlConfigurationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class PostgreSqlDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlDatabaseResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PostgreSqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult> CheckPostgreSqlNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>> CheckPostgreSqlNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties> GetLocationBasedPerformanceTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties> GetLocationBasedPerformanceTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource GetPostgreSqlConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource GetPostgreSqlDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource GetPostgreSqlFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource GetPostgreSqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource GetPostgreSqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetPostgreSqlServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource GetPostgreSqlServerAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> GetPostgreSqlServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource GetPostgreSqlServerKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerResource GetPostgreSqlServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerCollection GetPostgreSqlServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetPostgreSqlServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetPostgreSqlServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource GetPostgreSqlServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource GetPostgreSqlVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PostgreSqlFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class PostgreSqlFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFirewallRuleResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PostgreSqlPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlPrivateLinkResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlPrivateLinkResourceData() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class PostgreSqlServerAdministratorData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlServerAdministratorData() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType? AdministratorType { get { throw null; } set { } }
        public string LoginAccountName { get { throw null; } set { } }
        public System.Guid? SecureId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class PostgreSqlServerAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlServerAdministratorResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PostgreSqlServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string ByokEnforcement { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MasterServerId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState? UserVisibleState { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? Version { get { throw null; } set { } }
    }
    public partial class PostgreSqlServerKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlServerKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlServerKeyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType? ServerKeyType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class PostgreSqlServerKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlServerKeyResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlServerResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> GetPostgreSqlConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> GetPostgreSqlConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationCollection GetPostgreSqlConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> GetPostgreSqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>> GetPostgreSqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseCollection GetPostgreSqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> GetPostgreSqlFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>> GetPostgreSqlFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleCollection GetPostgreSqlFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> GetPostgreSqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> GetPostgreSqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionCollection GetPostgreSqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> GetPostgreSqlPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>> GetPostgreSqlPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceCollection GetPostgreSqlPrivateLinkResources() { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource GetPostgreSqlServerAdministrator() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> GetPostgreSqlServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> GetPostgreSqlServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyCollection GetPostgreSqlServerKeys() { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyCollection GetPostgreSqlServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> GetPostgreSqlServerSecurityAlertPolicy(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> GetPostgreSqlServerSecurityAlertPolicyAsync(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> GetPostgreSqlVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>> GetPostgreSqlVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleCollection GetPostgreSqlVirtualNetworkRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData> GetRecoverableServer(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>> GetRecoverableServerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties> GetServerBasedPerformanceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties> GetServerBasedPerformanceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList> UpdateConfigurations(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>> UpdateConfigurationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlServerSecurityAlertPolicyData() { }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public bool? SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class PostgreSqlServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlVirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlVirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlVirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlVirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState? State { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class PostgreSqlVirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlVirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public static partial class FlexibleServersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<string> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetPostgreSqlFlexibleServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerCollection GetPostgreSqlFlexibleServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlFlexibleServerConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType? DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public bool? IsConfigPendingRestart { get { throw null; } }
        public bool? IsDynamicConfig { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerConfigurationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PostgreSqlFlexibleServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? CreateMode { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public string MinorVersion { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? State { get { throw null; } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? Version { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlFlexibleServerDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerDatabaseResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlFlexibleServerFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerFirewallRuleResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> GetPostgreSqlFlexibleServerConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetPostgreSqlFlexibleServerConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationCollection GetPostgreSqlFlexibleServerConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> GetPostgreSqlFlexibleServerDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> GetPostgreSqlFlexibleServerDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseCollection GetPostgreSqlFlexibleServerDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> GetPostgreSqlFlexibleServerFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> GetPostgreSqlFlexibleServerFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleCollection GetPostgreSqlFlexibleServerFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerBackupProperties
    {
        public PostgreSqlFlexibleServerBackupProperties() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum? GeoRedundantBackup { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerCapabilityProperties
    {
        internal PostgreSqlFlexibleServerCapabilityProperties() { }
        public bool? IsGeoBackupSupported { get { throw null; } }
        public bool? IsZoneRedundantHAAndGeoBackupSupported { get { throw null; } }
        public bool? IsZoneRedundantHASupported { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAModes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability> SupportedHyperscaleNodeEditions { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerConfigurationDataType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerConfigurationDataType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType Boolean { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType Enumeration { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType Integer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType Numeric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerCreateMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode Create { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerCreateModeForUpdate : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerCreateModeForUpdate(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDelegatedSubnetUsage
    {
        internal PostgreSqlFlexibleServerDelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerEditionCapability
    {
        internal PostgreSqlFlexibleServerEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerFailoverMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerFailoverMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode ForcedFailover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode ForcedSwitchover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode PlannedFailover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode PlannedSwitchover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerGeoRedundantBackupEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerGeoRedundantBackupEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerHAState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerHAState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState Healthy { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState RemovingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState ReplicatingData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerHighAvailability
    {
        public PostgreSqlFlexibleServerHighAvailability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerHighAvailabilityMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerHighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerHyperscaleNodeEditionCapability
    {
        internal PostgreSqlFlexibleServerHyperscaleNodeEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability> SupportedNodeTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerMaintenanceWindow
    {
        public PostgreSqlFlexibleServerMaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerNameAvailabilityContent
    {
        public PostgreSqlFlexibleServerNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerNameAvailabilityResult
    {
        internal PostgreSqlFlexibleServerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? Reason { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerNameUnavailableReason : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerNetwork
    {
        public PostgreSqlFlexibleServerNetwork() { }
        public Azure.Core.ResourceIdentifier DelegatedSubnetResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateDnsZoneArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerNodeTypeCapability
    {
        internal PostgreSqlFlexibleServerNodeTypeCapability() { }
        public string Name { get { throw null; } }
        public string NodeType { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerPatch
    {
        public PostgreSqlFlexibleServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerPublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerPublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerRestartParameter
    {
        public PostgreSqlFlexibleServerRestartParameter() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public bool? RestartWithFailover { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerServerVersionCapability
    {
        internal PostgreSqlFlexibleServerServerVersionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability> SupportedVCores { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerSku
    {
        public PostgreSqlFlexibleServerSku(string name, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerSkuTier : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier Burstable { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageCapability
    {
        internal PostgreSqlFlexibleServerStorageCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public long? StorageSizeInMB { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerStorageEditionCapability
    {
        internal PostgreSqlFlexibleServerStorageEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> SupportedStorageCapabilities { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerVCoreCapability
    {
        internal PostgreSqlFlexibleServerVCoreCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVCoreInMB { get { throw null; } }
        public long? VCores { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerVersion : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver11 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver12 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver13 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter
    {
        public PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter() { }
        public Azure.Core.ResourceIdentifier VirtualNetworkArmResourceId { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult
    {
        internal PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
}
namespace Azure.ResourceManager.PostgreSql.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlAdministratorType : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlAdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlConfigurationList
    {
        public PostgreSqlConfigurationList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlGeoRedundantBackup : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlGeoRedundantBackup(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlInfrastructureEncryption : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlInfrastructureEncryption(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlLogFile : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string LogFileType { get { throw null; } set { } }
        public long? SizeInKB { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMinimalTlsVersionEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMinimalTlsVersionEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum Tls1_2 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum TLSEnforcementDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlNameAvailabilityContent
    {
        public PostgreSqlNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class PostgreSqlNameAvailabilityResult
    {
        internal PostgreSqlNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class PostgreSqlPerformanceTierProperties
    {
        internal PostgreSqlPerformanceTierProperties() { }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxLargeStorageInMB { get { throw null; } }
        public int? MaxStorageInMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinLargeStorageInMB { get { throw null; } }
        public int? MinStorageInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives> ServiceLevelObjectives { get { throw null; } }
    }
    public partial class PostgreSqlPerformanceTierServiceLevelObjectives
    {
        internal PostgreSqlPerformanceTierServiceLevelObjectives() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxStorageInMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinStorageInMB { get { throw null; } }
        public int? VCores { get { throw null; } }
    }
    public partial class PostgreSqlPrivateEndpointConnectionPatch
    {
        public PostgreSqlPrivateEndpointConnectionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlPrivateEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlPrivateEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState Approving { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState Rejecting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlPrivateLinkResourceProperties
    {
        internal PostgreSqlPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class PostgreSqlPrivateLinkServiceConnectionStateProperty
    {
        public PostgreSqlPrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlPrivateLinkServiceConnectionStateRequiredAction : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlPrivateLinkServiceConnectionStateRequiredAction(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlPrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlPrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlPublicNetworkAccessEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlPublicNetworkAccessEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlRecoverableServerResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlRecoverableServerResourceData() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
        public int? VCores { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlSecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlSecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlServerCreateOrUpdateContent
    {
        public PostgreSqlServerCreateOrUpdateContent(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate properties, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate Properties { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlServerKeyType : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType AzureKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlServerPatch
    {
        public PostgreSqlServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? Version { get { throw null; } set { } }
    }
    public partial class PostgreSqlServerPrivateEndpointConnection
    {
        internal PostgreSqlServerPrivateEndpointConnection() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class PostgreSqlServerPrivateEndpointConnectionProperties
    {
        internal PostgreSqlServerPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PostgreSqlServerPrivateLinkServiceConnectionStateProperty
    {
        internal PostgreSqlServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
    }
    public abstract partial class PostgreSqlServerPropertiesForCreate
    {
        protected PostgreSqlServerPropertiesForCreate() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? Version { get { throw null; } set { } }
    }
    public partial class PostgreSqlServerPropertiesForDefaultCreate : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForDefaultCreate(string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
    }
    public partial class PostgreSqlServerPropertiesForGeoRestore : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForGeoRestore(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
    }
    public partial class PostgreSqlServerPropertiesForReplica : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForReplica(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
    }
    public partial class PostgreSqlServerPropertiesForRestore : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForRestore(Azure.Core.ResourceIdentifier sourceServerId, System.DateTimeOffset restorePointInTime) { }
        public System.DateTimeOffset RestorePointInTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
    }
    public enum PostgreSqlServerSecurityAlertPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlServerState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlServerState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlServerVersion : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion Ver10 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion Ver10_0 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion Ver10_2 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion Ver11 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion Ver9_5 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion Ver9_6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlSku
    {
        public PostgreSqlSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlSkuTier : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PostgreSqlSslEnforcementEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlStorageAutogrow : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlStorageAutogrow(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlStorageProfile
    {
        public PostgreSqlStorageProfile() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow? StorageAutogrow { get { throw null; } set { } }
        public int? StorageInMB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlVirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlVirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState Initializing { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState InProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
