namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDBForPostgreSql.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDBForPostgreSql.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string CitusVersion { get { throw null; } set { } }
        public bool? CoordinatorEnablePublicIPAccess { get { throw null; } set { } }
        public string CoordinatorServerEdition { get { throw null; } set { } }
        public int? CoordinatorStorageQuotaInMb { get { throw null; } set { } }
        public int? CoordinatorVCores { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public bool? EnableHa { get { throw null; } set { } }
        public bool? EnableShardsOnCoordinator { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public bool? NodeEnablePublicIPAccess { get { throw null; } set { } }
        public string NodeServerEdition { get { throw null; } set { } }
        public int? NodeStorageQuotaInMb { get { throw null; } set { } }
        public int? NodeVCores { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string PostgresqlVersion { get { throw null; } set { } }
        public string PreferredPrimaryZone { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDBForPostgreSql.Models.SimplePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReadReplicas { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerNameItem> ServerNames { get { throw null; } }
        public string SourceLocation { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string State { get { throw null; } }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> GetClusterServer(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>> GetClusterServerAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerCollection GetClusterServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationCollection GetConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> GetCosmosDBForPostgreSqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> GetCosmosDBForPostgreSqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionCollection GetCosmosDBForPostgreSqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> GetCosmosDBForPostgreSqlPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>> GetCosmosDBForPostgreSqlPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceCollection GetCosmosDBForPostgreSqlPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> GetRole(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>> GetRoleAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.RoleCollection GetRoles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource> GetServerGroupsv2CoordinatorConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource>> GetServerGroupsv2CoordinatorConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationCollection GetServerGroupsv2CoordinatorConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource> GetServerGroupsv2NodeConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource>> GetServerGroupsv2NodeConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationCollection GetServerGroupsv2NodeConfigurations() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PromoteReadReplica(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PromoteReadReplicaAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>, System.Collections.IEnumerable
    {
        protected ClusterServerCollection() { }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterServerData : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterServerData() { }
        public string AdministratorLogin { get { throw null; } }
        public string AvailabilityZone { get { throw null; } set { } }
        public string CitusVersion { get { throw null; } set { } }
        public bool? EnableHa { get { throw null; } set { } }
        public bool? EnablePublicIPAccess { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string HaState { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string PostgresqlVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole? Role { get { throw null; } set { } }
        public string ServerEdition { get { throw null; } set { } }
        public string State { get { throw null; } }
        public int? StorageQuotaInMb { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
    }
    public partial class ClusterServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterServerResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string serverName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>, System.Collections.IEnumerable
    {
        protected ConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType? DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? RequiresRestart { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRoleGroupConfiguration> ServerRoleGroupConfigurations { get { throw null; } }
    }
    public partial class ConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CosmosDBForPostgreSqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.Models.NameAvailability> CheckNameAvailabilityCluster(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CosmosDBForPostgreSql.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.Models.NameAvailability>> CheckNameAvailabilityClusterAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CosmosDBForPostgreSql.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerResource GetClusterServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationResource GetConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource GetCosmosDBForPostgreSqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource GetCosmosDBForPostgreSqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource GetRoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource GetServerGroupsv2CoordinatorConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource GetServerGroupsv2NodeConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBForPostgreSqlPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CosmosDBForPostgreSqlPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlPrivateLinkResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public CosmosDBForPostgreSqlPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public FirewallRuleData(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>, System.Collections.IEnumerable
    {
        protected RoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleName, Azure.ResourceManager.CosmosDBForPostgreSql.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleName, Azure.ResourceManager.CosmosDBForPostgreSql.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> Get(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>> GetAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleData(string password) { }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RoleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.RoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string roleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.RoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType? DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? RequiresRestart { get { throw null; } }
        public string Source { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ServerGroupsv2CoordinatorConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServerGroupsv2CoordinatorConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerGroupsv2CoordinatorConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerGroupsv2CoordinatorConfigurationResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2CoordinatorConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerGroupsv2NodeConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServerGroupsv2NodeConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerGroupsv2NodeConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerGroupsv2NodeConfigurationResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.ServerGroupsv2NodeConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CosmosDBForPostgreSql.Models
{
    public static partial class ArmCosmosDBForPostgreSqlModelFactory
    {
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ClusterData ClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string administratorLogin = null, string administratorLoginPassword = null, string provisioningState = null, string state = null, string postgresqlVersion = null, string citusVersion = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.MaintenanceWindow maintenanceWindow = null, string preferredPrimaryZone = null, bool? enableShardsOnCoordinator = default(bool?), bool? enableHa = default(bool?), string coordinatorServerEdition = null, int? coordinatorStorageQuotaInMb = default(int?), int? coordinatorVCores = default(int?), bool? coordinatorEnablePublicIPAccess = default(bool?), string nodeServerEdition = null, int? nodeCount = default(int?), int? nodeStorageQuotaInMb = default(int?), int? nodeVCores = default(int?), bool? nodeEnablePublicIPAccess = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerNameItem> serverNames = null, string sourceResourceId = null, string sourceLocation = null, System.DateTimeOffset? pointInTimeUTC = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> readReplicas = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.SimplePrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ClusterServerData ClusterServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serverEdition = null, int? storageQuotaInMb = default(int?), int? vCores = default(int?), bool? enableHa = default(bool?), bool? enablePublicIPAccess = default(bool?), bool? isReadOnly = default(bool?), string administratorLogin = null, string fullyQualifiedDomainName = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole? role = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole?), string state = null, string haState = null, string availabilityZone = null, string postgresqlVersion = null, string citusVersion = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ConfigurationData ConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType? dataType = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType?), string allowedValues = null, bool? requiresRestart = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRoleGroupConfiguration> serverRoleGroupConfigurations = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData CosmosDBForPostgreSqlPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData CosmosDBForPostgreSqlPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.FirewallRuleData FirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string startIPAddress = null, string endIPAddress = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.NameAvailability NameAvailability(string message = null, bool? nameAvailable = default(bool?), string name = null, string resourceType = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.RoleData RoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string password = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.ServerConfigurationData ServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string source = null, string description = null, string defaultValue = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType? dataType = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType?), string allowedValues = null, bool? requiresRestart = default(bool?), Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerNameItem ServerNameItem(string name = null, string fullyQualifiedDomainName = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRoleGroupConfiguration ServerRoleGroupConfiguration(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole role = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole), string value = null, string defaultValue = null, string source = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.SimplePrivateEndpointConnection SimplePrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityResourceType : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType MicrosoftDBforPostgreSQLServerGroupsv2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string CitusVersion { get { throw null; } set { } }
        public bool? CoordinatorEnablePublicIPAccess { get { throw null; } set { } }
        public string CoordinatorServerEdition { get { throw null; } set { } }
        public int? CoordinatorStorageQuotaInMb { get { throw null; } set { } }
        public int? CoordinatorVCores { get { throw null; } set { } }
        public bool? EnableHa { get { throw null; } set { } }
        public bool? EnableShardsOnCoordinator { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public bool? NodeEnablePublicIPAccess { get { throw null; } }
        public string NodeServerEdition { get { throw null; } set { } }
        public int? NodeStorageQuotaInMb { get { throw null; } set { } }
        public int? NodeVCores { get { throw null; } set { } }
        public string PostgresqlVersion { get { throw null; } set { } }
        public string PreferredPrimaryZone { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationDataType : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationDataType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType Boolean { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType Enumeration { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType Integer { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType Numeric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ConfigurationDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateLinkServiceConnectionState
    {
        public CosmosDBForPostgreSqlPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
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
        public string ResourceType { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CheckNameAvailabilityResourceType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerNameItem
    {
        internal ServerNameItem() { }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerRole : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerRole(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole Coordinator { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole Worker { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerRoleGroupConfiguration
    {
        public ServerRoleGroupConfiguration(Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole role, string value) { }
        public string DefaultValue { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.ServerRole Role { get { throw null; } set { } }
        public string Source { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SimplePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData
    {
        public SimplePrivateEndpointConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
}
