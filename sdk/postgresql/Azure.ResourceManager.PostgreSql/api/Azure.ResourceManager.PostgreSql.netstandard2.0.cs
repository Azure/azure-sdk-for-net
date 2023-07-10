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
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<string> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource GetLtrServerBackupOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource GetMigrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetPostgreSqlFlexibleServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource GetPostgreSqlFlexibleServerBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerCollection GetPostgreSqlFlexibleServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LtrServerBackupOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>, System.Collections.IEnumerable
    {
        protected LtrServerBackupOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LtrServerBackupOperationData : Azure.ResourceManager.Models.ResourceData
    {
        public LtrServerBackupOperationData() { }
        public string BackupMetadata { get { throw null; } set { } }
        public string BackupName { get { throw null; } set { } }
        public long? DatasourceSizeInBytes { get { throw null; } set { } }
        public long? DataTransferredInBytes { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public double? PercentComplete { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus? Status { get { throw null; } set { } }
    }
    public partial class LtrServerBackupOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LtrServerBackupOperationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetDbServerName, string migrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Update(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> UpdateAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>, System.Collections.IEnumerable
    {
        protected MigrationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationName, Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationName, Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Get(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetAll(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter? migrationListFilter = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetAllAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter? migrationListFilter = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MigrationResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum? Cancel { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationStatus CurrentStatus { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToCancelMigrationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToMigrate { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToTriggerCutoverOn { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode? MigrationMode { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowEndTimeInUtc { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum? OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParameters SecretParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum? SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public string SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata SourceDbServerMetadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum? StartDataMigration { get { throw null; } set { } }
        public string TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata TargetDbServerMetadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetDbServerResourceId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum? TriggerCutover { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Get(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlFlexibleServerActiveDirectoryAdministratorData() { }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerActiveDirectoryAdministratorResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string objectId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public PostgreSqlFlexibleServerBackupData() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin? BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerBackupResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig AuthConfig { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public string MinorVersion { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUtc { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? State { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityResource> CheckMigrationNameAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityResource migrationNameAvailabilityResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityResource>> CheckMigrationNameAvailabilityAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityResource migrationNameAvailabilityResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersLogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersLogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource> GetLtrServerBackupOperation(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationResource>> GetLtrServerBackupOperationAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationCollection GetLtrServerBackupOperations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetMigrationResource(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetMigrationResourceAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResourceCollection GetMigrationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetPostgreSqlFlexibleServerActiveDirectoryAdministrator(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetPostgreSqlFlexibleServerActiveDirectoryAdministratorAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection GetPostgreSqlFlexibleServerActiveDirectoryAdministrators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> GetPostgreSqlFlexibleServerBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> GetPostgreSqlFlexibleServerBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupCollection GetPostgreSqlFlexibleServerBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> GetPostgreSqlFlexibleServerConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetPostgreSqlFlexibleServerConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationCollection GetPostgreSqlFlexibleServerConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> GetPostgreSqlFlexibleServerDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> GetPostgreSqlFlexibleServerDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseCollection GetPostgreSqlFlexibleServerDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> GetPostgreSqlFlexibleServerFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> GetPostgreSqlFlexibleServerFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleCollection GetPostgreSqlFlexibleServerFirewallRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> GetServerCapabilities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> GetServerCapabilitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrBackupResponse> StartLtrBackupFlexibleServer(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrBackupResponse>> StartLtrBackupFlexibleServerAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrPreBackupResponse> TriggerLtrPreBackupFlexibleServer(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrPreBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrPreBackupResponse>> TriggerLtrPreBackupFlexibleServerAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrPreBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public static partial class ArmFlexibleServersModelFactory
    {
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase CapabilityBase(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersLogFile FlexibleServersLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), long? sizeInKb = default(long?), string typePropertiesType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrBackupResponse LtrBackupResponse(long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupName = null, string backupMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LtrPreBackupResponse LtrPreBackupResponse(int numberOfContainers = 0) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.LtrServerBackupOperationData LtrServerBackupOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupName = null, string backupMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityResource MigrationNameAvailabilityResource(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), bool? nameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResourceData MigrationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string migrationId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationStatus currentStatus = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode? migrationMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata sourceDbServerMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata targetDbServerMetadata = null, Azure.Core.ResourceIdentifier sourceDbServerResourceId = null, string sourceDbServerFullyQualifiedDomainName = null, Azure.Core.ResourceIdentifier targetDbServerResourceId = null, string targetDbServerFullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParameters secretParameters = null, System.Collections.Generic.IEnumerable<string> dbsToMigrate = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum? setupLogicalReplicationOnSourceDbIfNeeded = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum? overwriteDbsInTarget = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum?), System.DateTimeOffset? migrationWindowStartTimeInUtc = default(System.DateTimeOffset?), System.DateTimeOffset? migrationWindowEndTimeInUtc = default(System.DateTimeOffset?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum? startDataMigration = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum? triggerCutover = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum?), System.Collections.Generic.IEnumerable<string> dbsToTriggerCutoverOn = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum? cancel = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum?), System.Collections.Generic.IEnumerable<string> dbsToCancelMigrationOn = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationStatus MigrationStatus(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState?), string error = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState? currentSubState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData PostgreSqlFlexibleServerActiveDirectoryAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? principalType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType?), string principalName = null, System.Guid? objectId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData PostgreSqlFlexibleServerBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin? backupType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string source = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties PostgreSqlFlexibleServerBackupProperties(int? backupRetentionDays = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum? geoRedundantBackup = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties PostgreSqlFlexibleServerCapabilityProperties(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> supportedServerEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum? supportFastProvisioning = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum? geoBackupSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum? zoneRedundantHaSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum? zoneRedundantHaAndGeoBackupSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum? storageAutoGrowthSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum? onlineResizeSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum? restricted = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData PostgreSqlFlexibleServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType? dataType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType?), string allowedValues = null, string source = null, bool? isDynamicConfig = default(bool?), bool? isReadOnly = default(bool?), bool? isConfigPendingRestart = default(bool?), string unit = null, string documentationLink = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku sku = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity identity = null, string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? version = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion?), string minorVersion = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState?), string fullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage storage = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig authConfig = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption dataEncryption = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties backup = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork network = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability highAvailability = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow = null, Azure.Core.ResourceIdentifier sourceServerResourceId = null, System.DateTimeOffset? pointInTimeUtc = default(System.DateTimeOffset?), string availabilityZone = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? replicationRole = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole?), int? replicaCapacity = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? createMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData PostgreSqlFlexibleServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage PostgreSqlFlexibleServerDelegatedSubnetUsage(string subnetName = null, long? usage = default(long?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, string defaultSkuName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability> supportedServerSkus = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string supportedTier = null, string supportedSku = null, int? supportedStorageGb = default(int?), string supportedServerVersions = null, int? serverCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData PostgreSqlFlexibleServerFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability PostgreSqlFlexibleServerHighAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? mode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState?), string standbyAvailabilityZone = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse PostgreSqlFlexibleServerNameAvailabilityResponse(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult PostgreSqlFlexibleServerNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason?), string message = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork PostgreSqlFlexibleServerNetwork(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState?), Azure.Core.ResourceIdentifier delegatedSubnetResourceId = null, Azure.Core.ResourceIdentifier privateDnsZoneArmResourceId = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, System.Collections.Generic.IEnumerable<string> supportedVersionsToUpgrade = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability PostgreSqlFlexibleServerSkuCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, int? vCores = default(int?), int? supportedIops = default(int?), long? supportedMemoryPerVcoreMb = default(long?), System.Collections.Generic.IEnumerable<string> supportedZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode> supportedHaMode = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage PostgreSqlFlexibleServerStorage(int? storageSizeInGB = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow? autoGrow = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier? tier = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier?), int? iops = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, int? supportedIops = default(int?), long? storageSizeInMB = default(long?), string defaultIopsTier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> supportedIopsTiers = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, long? defaultStorageSizeMb = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, int? iops = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity PostgreSqlFlexibleServerUserAssignedIdentity(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType identityType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage> delegatedSubnetsUsage = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata PostgreSqlServerMetadata(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string version = null, int? storageMb = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerSku sku = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerSku ServerSku(string name = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier tier = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureManagedDiskPerformanceTier : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureManagedDiskPerformanceTier(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P1 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P10 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P15 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P2 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P20 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P3 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P30 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P4 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P40 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P50 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P6 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P60 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P70 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier P80 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupRequestBase
    {
        public BackupRequestBase(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings) { }
        public string BackupName { get { throw null; } }
    }
    public partial class CapabilityBase
    {
        internal CapabilityBase() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus Running { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlexibleServersLogFile : Azure.ResourceManager.Models.ResourceData
    {
        public FlexibleServersLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public long? SizeInKb { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyStatusEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum Invalid { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicalReplicationOnSourceDbEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicalReplicationOnSourceDbEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LtrBackupContent : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupRequestBase
    {
        public LtrBackupContent(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails targetDetails) : base (default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings)) { }
        public System.Collections.Generic.IList<string> TargetDetailsSasUriList { get { throw null; } }
    }
    public partial class LtrBackupResponse
    {
        internal LtrBackupResponse() { }
        public string BackupMetadata { get { throw null; } }
        public string BackupName { get { throw null; } }
        public long? DatasourceSizeInBytes { get { throw null; } }
        public long? DataTransferredInBytes { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ExecutionStatus? Status { get { throw null; } }
    }
    public partial class LtrPreBackupContent : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupRequestBase
    {
        public LtrPreBackupContent(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings) : base (default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings)) { }
    }
    public partial class LtrPreBackupResponse
    {
        internal LtrPreBackupResponse() { }
        public int NumberOfContainers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationListFilter : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationListFilter(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter Active { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter All { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationListFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode Offline { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationNameAvailabilityResource
    {
        public MigrationNameAvailabilityResource(string name, Azure.Core.ResourceType resourceType) { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailabilityReason? Reason { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } set { } }
    }
    public partial class MigrationResourcePatch
    {
        public MigrationResourcePatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum? Cancel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DbsToCancelMigrationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToMigrate { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToTriggerCutoverOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationMode? MigrationMode { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum? OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParameters SecretParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceDbEnum? SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public string SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum? StartDataMigration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum? TriggerCutover { get { throw null; } set { } }
    }
    public partial class MigrationSecretParameters
    {
        public MigrationSecretParameters(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials adminCredentials) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials AdminCredentials { get { throw null; } set { } }
        public string SourceServerUsername { get { throw null; } set { } }
        public string TargetServerUsername { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState WaitingForUserAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationStatus
    {
        internal MigrationStatus() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState? CurrentSubState { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationSubState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationSubState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState Completed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState CompletingMigration { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState MigratingData { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState PerformingPreRequisiteSteps { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState WaitingForCutoverTrigger { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState WaitingForDataMigrationScheduling { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState WaitingForDataMigrationWindow { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState WaitingForDBsToMigrateSpecification { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState WaitingForLogicalReplicationSetupRequestOnSourceDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState WaitingForTargetDBOverwriteConfirmation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OverwriteDbsInTargetEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OverwriteDbsInTargetEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDbsInTargetEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PostgreSqlFlexbileServerCapabilityStatus
    {
        Visible = 0,
        Available = 1,
        Default = 2,
        Disabled = 3,
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent
    {
        public PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent() { }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerActiveDirectoryAuthEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerActiveDirectoryAuthEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerAuthConfig
    {
        public PostgreSqlFlexibleServerAuthConfig() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum? ActiveDirectoryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum? PasswordAuth { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerBackupOrigin : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerBackupOrigin(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin Full { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupProperties
    {
        public PostgreSqlFlexibleServerBackupProperties() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum? GeoRedundantBackup { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerBackupSettings
    {
        public PostgreSqlFlexibleServerBackupSettings(string backupName) { }
        public string BackupName { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerBackupStoreDetails
    {
        public PostgreSqlFlexibleServerBackupStoreDetails(System.Collections.Generic.IEnumerable<string> sasUriList) { }
        public System.Collections.Generic.IList<string> SasUriList { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerCapabilityProperties : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerCapabilityProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? FastProvisioningSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum? GeoBackupSupported { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsGeoBackupSupported { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHAAndGeoBackupSupported { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHASupported { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum? OnlineResizeSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum? Restricted { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public new string Status { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum? StorageAutoGrowthSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> SupportedFastProvisioningEditions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAModes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum? SupportFastProvisioning { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Zone { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum? ZoneRedundantHaAndGeoBackupSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum? ZoneRedundantHaSupported { get { throw null; } }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode GeoRestore { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode Replica { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode ReviveDropped { get { throw null; } }
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
    public partial class PostgreSqlFlexibleServerDataEncryption
    {
        public PostgreSqlFlexibleServerDataEncryption() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum? GeoBackupEncryptionKeyStatus { get { throw null; } set { } }
        public System.Uri GeoBackupKeyUri { get { throw null; } set { } }
        public string GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType? KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.KeyStatusEnum? PrimaryEncryptionKeyStatus { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerDelegatedSubnetUsage
    {
        internal PostgreSqlFlexibleServerDelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerEditionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerEditionCapability() { }
        public string DefaultSkuName { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability> SupportedServerSkus { get { throw null; } }
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
    public partial class PostgreSqlFlexibleServerFastProvisioningEditionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerFastProvisioningEditionCapability() { }
        public int? ServerCount { get { throw null; } }
        public string SupportedServerVersions { get { throw null; } }
        public string SupportedSku { get { throw null; } }
        public int? SupportedStorageGb { get { throw null; } }
        public string SupportedTier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerFastProvisioningSupportedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerFastProvisioningSupportedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupportedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerGeoBackupSupportedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerGeoBackupSupportedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupportedEnum right) { throw null; }
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
    public readonly partial struct PostgreSqlFlexibleServerHAMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerHAMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode SameZone { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode right) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode SameZone { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerIdentityType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType None { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerKeyType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType AzureKeyVault { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType SystemManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class PostgreSqlFlexibleServerNameAvailabilityResponse
    {
        internal PostgreSqlFlexibleServerNameAvailabilityResponse() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? Reason { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerNameAvailabilityResult : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse
    {
        internal PostgreSqlFlexibleServerNameAvailabilityResult() { }
        public string Name { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerOnlineResizeSupportedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerOnlineResizeSupportedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupportedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerPasswordAuthEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerPasswordAuthEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerPatch
    {
        public PostgreSqlFlexibleServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig AuthConfig { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateModeForUpdate? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? StorageSizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerPrincipalType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType Unknown { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerReplicationRole : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole AsyncReplica { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole GeoAsyncReplica { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole GeoSyncReplica { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole None { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole Primary { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole Secondary { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole SyncReplica { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole WalReplica { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerRestartParameter
    {
        public PostgreSqlFlexibleServerRestartParameter() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public bool? RestartWithFailover { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerServerVersionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerServerVersionCapability() { }
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public new string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedVersionsToUpgrade { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerSku
    {
        public PostgreSqlFlexibleServerSku(string name, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier Tier { get { throw null; } set { } }
    }
    public partial class PostgreSqlFlexibleServerSkuCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerSkuCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode> SupportedHaMode { get { throw null; } }
        public int? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVcoreMb { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedZones { get { throw null; } }
        public int? VCores { get { throw null; } }
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
    public partial class PostgreSqlFlexibleServerStorage
    {
        public PostgreSqlFlexibleServerStorage() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow? AutoGrow { get { throw null; } set { } }
        public int? Iops { get { throw null; } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupportedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerStorageCapability() { }
        public string DefaultIopsTier { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public new string Status { get { throw null; } }
        public long? StorageSizeInMB { get { throw null; } }
        public int? SupportedIops { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> SupportedIopsTiers { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerStorageEditionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerStorageEditionCapability() { }
        public long? DefaultStorageSizeMb { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> SupportedStorageCapabilities { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerStorageTierCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityBase
    {
        internal PostgreSqlFlexibleServerStorageTierCapability() { }
        public int? Iops { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity
    {
        public PostgreSqlFlexibleServerUserAssignedIdentity(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType identityType) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType IdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver14 { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupportedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupportedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerZoneRedundantRestrictedEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerZoneRedundantRestrictedEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestrictedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlMigrationAdminCredentials
    {
        public PostgreSqlMigrationAdminCredentials(string sourceServerPassword, string targetServerPassword) { }
        public string SourceServerPassword { get { throw null; } set { } }
        public string TargetServerPassword { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationCancelEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationCancelEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancelEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlServerMetadata
    {
        internal PostgreSqlServerMetadata() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerSku Sku { get { throw null; } }
        public int? StorageMb { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ServerSku
    {
        internal ServerSku() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StartDataMigrationEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StartDataMigrationEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigrationEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAutoGrow : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAutoGrow(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerCutoverEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerCutoverEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutoverEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.Models
{
    public static partial class ArmPostgreSqlModelFactory
    {
        public static Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData PostgreSqlConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, string dataType = null, string allowedValues = null, string source = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData PostgreSqlDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData PostgreSqlFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile PostgreSqlLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? sizeInKB = default(long?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string logFileType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult PostgreSqlNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties PostgreSqlPerformanceTierProperties(string id = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minLargeStorageInMB = default(int?), int? maxLargeStorageInMB = default(int?), int? minStorageInMB = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives> serviceLevelObjectives = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives PostgreSqlPerformanceTierServiceLevelObjectives(string id = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minStorageInMB = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData PostgreSqlPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData PostgreSqlPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties PostgreSqlPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty PostgreSqlPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData PostgreSqlRecoverableServerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastAvailableBackupOn = default(System.DateTimeOffset?), string serviceLevelObjective = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, string version = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData PostgreSqlServerAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType? administratorType = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType?), string loginAccountName = null, System.Guid? secureId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerData PostgreSqlServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku sku = null, string administratorLogin = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? version = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum?), string byokEnforcement = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState? userVisibleState = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState?), string fullyQualifiedDomainName = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile storageProfile = null, string replicationRole = null, Azure.Core.ResourceIdentifier masterServerId = null, int? replicaCapacity = default(int?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData PostgreSqlServerKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType? serverKeyType = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType?), System.Uri uri = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection PostgreSqlServerPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties PostgreSqlServerPrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty PostgreSqlServerPrivateLinkServiceConnectionStateProperty(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus status = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus), string description = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction? actionsRequired = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData PostgreSqlServerSecurityAlertPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerSecurityAlertPolicyState? state = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerSecurityAlertPolicyState?), System.Collections.Generic.IEnumerable<string> disabledAlerts = null, System.Collections.Generic.IEnumerable<string> emailAddresses = null, bool? sendToEmailAccountAdmins = default(bool?), string storageEndpoint = null, string storageAccountAccessKey = null, int? retentionDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData PostgreSqlVirtualNetworkRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier virtualNetworkSubnetId = null, bool? ignoreMissingVnetServiceEndpoint = default(bool?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState? state = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState?)) { throw null; }
    }
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
