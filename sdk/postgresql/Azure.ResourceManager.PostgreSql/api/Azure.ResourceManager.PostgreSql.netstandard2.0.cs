namespace Azure.ResourceManager.PostgreSql
{
    public partial class ConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ConfigurationResource>, System.Collections.IEnumerable
    {
        protected ConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.ConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.ConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType? DataType { get { throw null; } }
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
        public static Azure.Response<string> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.CapabilityProperties> ExecuteLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.CapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.Models.VirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.PostgreSql.Models.VirtualNetworkSubnetUsageParameter virtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.Models.VirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.PostgreSql.Models.VirtualNetworkSubnetUsageParameter virtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ConfigurationResource GetConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> GetServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> GetServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerResource GetServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.ServerCollection GetServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerResource> GetServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerResource> GetServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>, System.Collections.IEnumerable
    {
        protected ServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.ServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.PostgreSql.ServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.ServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.ServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.ServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.ServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.ServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.Backup Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.HighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public string MinorVersion { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.Network Network { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public string SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerState? State { get { throw null; } }
        public int? StorageSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerVersion? Version { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ConfigurationResource>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.ConfigurationCollection GetConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.RestartParameter restartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.RestartParameter restartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.ServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.ServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.Models
{
    public partial class Backup
    {
        public Backup() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum? GeoRedundantBackup { get { throw null; } set { } }
    }
    public partial class CapabilityProperties
    {
        internal CapabilityProperties() { }
        public bool? GeoBackupSupported { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.FlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.HyperscaleNodeEditionCapability> SupportedHyperscaleNodeEditions { get { throw null; } }
        public string Zone { get { throw null; } }
        public bool? ZoneRedundantHaAndGeoBackupSupported { get { throw null; } }
        public bool? ZoneRedundantHaSupported { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationDataType : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationDataType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType Boolean { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType Enumeration { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType Integer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType Numeric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType left, Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType left, Azure.ResourceManager.PostgreSql.Models.ConfigurationDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.CreateMode Create { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.CreateMode Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.CreateMode left, Azure.ResourceManager.PostgreSql.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.CreateMode left, Azure.ResourceManager.PostgreSql.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModeForUpdate : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModeForUpdate(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate left, Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate left, Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DelegatedSubnetUsage
    {
        internal DelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverMode : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.FailoverMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.FailoverMode ForcedFailover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.FailoverMode ForcedSwitchover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.FailoverMode PlannedFailover { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.FailoverMode PlannedSwitchover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.FailoverMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.FailoverMode left, Azure.ResourceManager.PostgreSql.Models.FailoverMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.FailoverMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.FailoverMode left, Azure.ResourceManager.PostgreSql.Models.FailoverMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlexibleServerEditionCapability
    {
        internal FlexibleServerEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.ServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.StorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoRedundantBackupEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoRedundantBackupEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum left, Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum left, Azure.ResourceManager.PostgreSql.Models.GeoRedundantBackupEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HighAvailability
    {
        public HighAvailability() { }
        public Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.ServerHAState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityMode : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode left, Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode left, Azure.ResourceManager.PostgreSql.Models.HighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HyperscaleNodeEditionCapability
    {
        internal HyperscaleNodeEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.NodeTypeCapability> SupportedNodeTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.ServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.StorageEditionCapability> SupportedStorageEditions { get { throw null; } }
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
        public Azure.ResourceManager.PostgreSql.Models.Reason? Reason { get { throw null; } }
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
        public Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
    }
    public partial class NodeTypeCapability
    {
        internal NodeTypeCapability() { }
        public string Name { get { throw null; } }
        public string NodeType { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PostgreSqlSku
    {
        public PostgreSqlSku(string name, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlSkuTier : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier Burstable { get { throw null; } }
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
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.Reason left, Azure.ResourceManager.PostgreSql.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.Reason left, Azure.ResourceManager.PostgreSql.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestartParameter
    {
        public RestartParameter() { }
        public Azure.ResourceManager.PostgreSql.Models.FailoverMode? FailoverMode { get { throw null; } set { } }
        public bool? RestartWithFailover { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerHAState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ServerHAState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerHAState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ServerHAState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerHAState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerHAState Healthy { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerHAState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerHAState RemovingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerHAState ReplicatingData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.ServerHAState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.ServerHAState left, Azure.ResourceManager.PostgreSql.Models.ServerHAState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.ServerHAState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.ServerHAState left, Azure.ResourceManager.PostgreSql.Models.ServerHAState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerPatch
    {
        public ServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.Backup Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.CreateModeForUpdate? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.HighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public int? StorageSizeGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState left, Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState left, Azure.ResourceManager.PostgreSql.Models.ServerPublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerState : System.IEquatable<Azure.ResourceManager.PostgreSql.Models.ServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerState Updating { get { throw null; } }
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
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Thirteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.Models.ServerVersion Twelve { get { throw null; } }
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
    public partial class ServerVersionCapability
    {
        internal ServerVersionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.VcoreCapability> SupportedVcores { get { throw null; } }
    }
    public partial class StorageEditionCapability
    {
        internal StorageEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.StorageMBCapability> SupportedStorageMB { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.Models.DelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
}
