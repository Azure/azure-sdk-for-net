namespace Azure.ResourceManager.PostgreSql
{
    public partial class ConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected ConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.ConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.PostgreSql.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public FirewallRuleData(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PostgreSqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PostgreSql.Models.NameAvailability> ExecuteCheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.Models.NameAvailability>> ExecuteCheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ConfigurationResource GetConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.PerformanceTierProperties> GetLocationBasedPerformanceTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.PerformanceTierProperties> GetLocationBasedPerformanceTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource GetPostgreSqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource GetPostgreSqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> GetServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerAdministratorResource GetServerAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> GetServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerKeyResource GetServerKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerResource GetServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerCollection GetServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerResource> GetServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerResource> GetServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource GetServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource GetVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
    public partial class ServerAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAdministratorResource() { }
        public virtual Azure.ResourceManager.PostgreSql.ServerAdministratorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ServerAdministratorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ServerAdministratorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAdministratorResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAdministratorResourceData() { }
        public Azure.ResourceManager.PostgreSql.Models.AdministratorType? AdministratorType { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>, System.Collections.IEnumerable
    {
        protected ServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.Models.ServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.Models.ServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.ServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.ServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string ByokEnforcement { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public string MasterServerId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.ServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.SslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerState? UserVisibleState { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerKeyResource>, System.Collections.IEnumerable
    {
        protected ServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.PostgreSql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.PostgreSql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.ServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.ServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerKeyData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ServerKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerKeyResource() { }
        public virtual Azure.ResourceManager.PostgreSql.ServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerResource() { }
        public virtual Azure.ResourceManager.PostgreSql.ServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ConfigurationResource> GetByServerConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ConfigurationResource> GetByServerConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.ConfigurationCollection GetConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.LogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.LogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> GetPostgreSqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> GetPostgreSqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionCollection GetPostgreSqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> GetPostgreSqlPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>> GetPostgreSqlPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceCollection GetPostgreSqlPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.Models.RecoverableServerResource> GetRecoverableServer(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.Models.RecoverableServerResource>> GetRecoverableServerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.ServerAdministratorResource GetServerAdministratorResource() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.PerformanceTierProperties> GetServerBasedPerformanceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.PerformanceTierProperties> GetServerBasedPerformanceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerKeyResource> GetServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerKeyResource>> GetServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.ServerKeyCollection GetServerKeys() { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyCollection GetServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> GetServerSecurityAlertPolicy(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>> GetServerSecurityAlertPolicyAsync(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.Models.ConfigurationListResult> GetUpdateConfigurationsServerParameter(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.ConfigurationListResult value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.Models.ConfigurationListResult>> GetUpdateConfigurationsServerParameterAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.ConfigurationListResult value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> GetVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>> GetVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.VirtualNetworkRuleCollection GetVirtualNetworkRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerSecurityAlertPolicyData() { }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.PostgreSql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.PostgreSql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState? State { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.PostgreSql.VirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.VirtualNetworkRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class ConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>, System.Collections.IEnumerable
    {
        protected ConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType? DataType { get { throw null; } }
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
    public partial class ConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public FirewallRuleData(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FlexibleServersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailability> ExecuteCheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailability>> ExecuteCheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<string> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityProperties> ExecuteLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageParameter virtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageParameter virtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource GetConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> GetServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> GetServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource GetServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.ServerCollection GetServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> GetServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> GetServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>, System.Collections.IEnumerable
    {
        protected ServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.ServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.ServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Backup Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public string MinorVersion { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Network Network { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSku Sku { get { throw null; } set { } }
        public string SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState? State { get { throw null; } }
        public int? StorageSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.ServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationResource>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.ConfigurationCollection GetConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RestartParameter restartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RestartParameter restartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class Backup
    {
        public Backup() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum? GeoRedundantBackup { get { throw null; } set { } }
    }
    public partial class CapabilityProperties
    {
        internal CapabilityProperties() { }
        public bool? GeoBackupSupported { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HyperscaleNodeEditionCapability> SupportedHyperscaleNodeEditions { get { throw null; } }
        public string Zone { get { throw null; } }
        public bool? ZoneRedundantHaAndGeoBackupSupported { get { throw null; } }
        public bool? ZoneRedundantHaSupported { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationDataType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationDataType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType Boolean { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType Enumeration { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType Integer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType Numeric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode Create { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModeForUpdate : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModeForUpdate(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DelegatedSubnetUsage
    {
        internal DelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode ForcedFailover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode ForcedSwitchover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode PlannedFailover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode PlannedSwitchover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlexibleServerEditionCapability
    {
        internal FlexibleServerEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    public partial class FlexibleServersSku
    {
        public FlexibleServersSku(string name, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FlexibleServersSkuTier : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FlexibleServersSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier Burstable { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoRedundantBackupEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoRedundantBackupEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeoRedundantBackupEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HighAvailability
    {
        public HighAvailability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HyperscaleNodeEditionCapability
    {
        internal HyperscaleNodeEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NodeTypeCapability> SupportedNodeTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    public partial class MaintenanceWindow
    {
        public MaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason? Reason { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class Network
    {
        public Network() { }
        public string DelegatedSubnetResourceId { get { throw null; } set { } }
        public string PrivateDnsZoneArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
    }
    public partial class NodeTypeCapability
    {
        internal NodeTypeCapability() { }
        public string Name { get { throw null; } }
        public string NodeType { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestartParameter
    {
        public RestartParameter() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FailoverMode? FailoverMode { get { throw null; } set { } }
        public bool? RestartWithFailover { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerHAState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerHAState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState Healthy { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState RemovingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState ReplicatingData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerHAState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerPatch
    {
        public ServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Backup Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForUpdate? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FlexibleServersSku Sku { get { throw null; } set { } }
        public int? StorageSizeGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerPublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerVersion : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion Eleven { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion Thirteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion Twelve { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerVersionCapability
    {
        internal ServerVersionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VcoreCapability> SupportedVcores { get { throw null; } }
    }
    public partial class StorageEditionCapability
    {
        internal StorageEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageMBCapability> SupportedStorageMB { get { throw null; } }
    }
    public partial class StorageMBCapability
    {
        internal StorageMBCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public long? StorageSizeMB { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
    }
    public partial class VcoreCapability
    {
        internal VcoreCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVcoreMB { get { throw null; } }
        public long? VCores { get { throw null; } }
    }
    public partial class VirtualNetworkSubnetUsageParameter
    {
        public VirtualNetworkSubnetUsageParameter() { }
        public string VirtualNetworkArmResourceId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkSubnetUsageResult
    {
        internal VirtualNetworkSubnetUsageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
}
namespace Azure.ResourceManager.PostgreSql.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministratorType : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.AdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.AdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.AdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.AdministratorType left, Azure.ResourceManager.PostgreSql.Models.AdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.AdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.AdministratorType left, Azure.ResourceManager.PostgreSql.Models.AdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationListResult
    {
        public ConfigurationListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PostgreSql.ConfigurationData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoRedundantBackup : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoRedundantBackup(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup left, Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup left, Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryption : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryption(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption left, Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption left, Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogFile : Azure.ResourceManager.Models.ResourceData
    {
        public LogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public long? SizeInKB { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MinimalTlsVersionEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MinimalTlsVersionEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum TLS10 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum TLS11 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum TLS12 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum TLSEnforcementDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum left, Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum left, Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class PerformanceTierProperties
    {
        internal PerformanceTierProperties() { }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxLargeStorageMB { get { throw null; } }
        public int? MaxStorageMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinLargeStorageMB { get { throw null; } }
        public int? MinStorageMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.PerformanceTierServiceLevelObjectives> ServiceLevelObjectives { get { throw null; } }
    }
    public partial class PerformanceTierServiceLevelObjectives
    {
        internal PerformanceTierServiceLevelObjectives() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxStorageMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinStorageMB { get { throw null; } }
        public int? VCore { get { throw null; } }
    }
    public partial class PostgreSqlPrivateEndpointConnectionPatch
    {
        public PostgreSqlPrivateEndpointConnectionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState Approving { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState Rejecting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState left, Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState left, Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateActionsRequire : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateActionsRequire(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire left, Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire left, Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum left, Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum left, Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoverableServerResource : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableServerResource() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string LastAvailableBackupDateTime { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
        public int? VCore { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName left, Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName left, Azure.ResourceManager.PostgreSql.Models.SecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerCreateOrUpdateContent
    {
        public ServerCreateOrUpdateContent(Azure.ResourceManager.PostgreSql.Models.ServerPropertiesForCreate properties, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.ServerPropertiesForCreate Properties { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerKeyType : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ServerKeyType AzureKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.ServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.ServerKeyType left, Azure.ResourceManager.PostgreSql.Models.ServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.ServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.ServerKeyType left, Azure.ResourceManager.PostgreSql.Models.ServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerPatch
    {
        public ServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.SslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerPrivateEndpointConnection
    {
        internal ServerPrivateEndpointConnection() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.ServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class ServerPrivateEndpointConnectionProperties
    {
        internal ServerPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.ServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ServerPrivateLinkServiceConnectionStateProperty
    {
        internal ServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateActionsRequire? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
    }
    public partial class ServerPropertiesForCreate
    {
        public ServerPropertiesForCreate() { }
        public Azure.ResourceManager.PostgreSql.Models.InfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.MinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.SslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerPropertiesForDefaultCreate : Azure.ResourceManager.PostgreSql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForDefaultCreate(string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
    }
    public partial class ServerPropertiesForGeoRestore : Azure.ResourceManager.PostgreSql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForGeoRestore(string sourceServerId) { }
        public string SourceServerId { get { throw null; } }
    }
    public partial class ServerPropertiesForReplica : Azure.ResourceManager.PostgreSql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForReplica(string sourceServerId) { }
        public string SourceServerId { get { throw null; } }
    }
    public partial class ServerPropertiesForRestore : Azure.ResourceManager.PostgreSql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForRestore(string sourceServerId, System.DateTimeOffset restorePointInOn) { }
        public System.DateTimeOffset RestorePointInOn { get { throw null; } }
        public string SourceServerId { get { throw null; } }
    }
    public enum ServerSecurityAlertPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.ServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.ServerState left, Azure.ResourceManager.PostgreSql.Models.ServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.ServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.ServerState left, Azure.ResourceManager.PostgreSql.Models.ServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerVersion : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Eleven { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Nine5 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Nine6 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Ten { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Ten0 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Ten2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.ServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.ServerVersion left, Azure.ResourceManager.PostgreSql.Models.ServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.ServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.ServerVersion left, Azure.ResourceManager.PostgreSql.Models.ServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SslEnforcementEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAutogrow : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.StorageAutogrow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAutogrow(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.StorageAutogrow Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.StorageAutogrow Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.StorageAutogrow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.StorageAutogrow left, Azure.ResourceManager.PostgreSql.Models.StorageAutogrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.StorageAutogrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.StorageAutogrow left, Azure.ResourceManager.PostgreSql.Models.StorageAutogrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageProfile
    {
        public StorageProfile() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.StorageAutogrow? StorageAutogrow { get { throw null; } set { } }
        public int? StorageMB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState Initializing { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState InProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState left, Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState left, Azure.ResourceManager.PostgreSql.Models.VirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
