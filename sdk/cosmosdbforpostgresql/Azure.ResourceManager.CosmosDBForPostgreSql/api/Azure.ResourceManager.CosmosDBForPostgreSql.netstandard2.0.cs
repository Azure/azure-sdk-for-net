namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    public partial class AzureResourceManagerCosmosDBForPostgreSqlContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCosmosDBForPostgreSqlContext() { }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.AzureResourceManagerCosmosDBForPostgreSqlContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>
    {
        public CosmosDBForPostgreSqlClusterData(Azure.Core.AzureLocation location) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string CitusVersion { get { throw null; } set { } }
        public string CoordinatorServerEdition { get { throw null; } set { } }
        public int? CoordinatorStorageQuotaInMb { get { throw null; } set { } }
        public int? CoordinatorVCores { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public bool? IsCoordinatorPublicIPAccessEnabled { get { throw null; } set { } }
        public bool? IsHAEnabled { get { throw null; } set { } }
        public bool? IsNodePublicIPAccessEnabled { get { throw null; } set { } }
        public bool? IsShardsOnCoordinatorEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string NodeServerEdition { get { throw null; } set { } }
        public int? NodeStorageQuotaInMb { get { throw null; } set { } }
        public int? NodeVCores { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string PostgresqlVersion { get { throw null; } set { } }
        public string PreferredPrimaryZone { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReadReplicas { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem> ServerNames { get { throw null; } }
        public Azure.Core.AzureLocation? SourceLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlClusterResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> GetCosmosDBForPostgreSqlClusterServer(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>> GetCosmosDBForPostgreSqlClusterServerAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerCollection GetCosmosDBForPostgreSqlClusterServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> GetCosmosDBForPostgreSqlConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>> GetCosmosDBForPostgreSqlConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationCollection GetCosmosDBForPostgreSqlConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource> GetCosmosDBForPostgreSqlCoordinatorConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource>> GetCosmosDBForPostgreSqlCoordinatorConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationCollection GetCosmosDBForPostgreSqlCoordinatorConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> GetCosmosDBForPostgreSqlFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>> GetCosmosDBForPostgreSqlFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleCollection GetCosmosDBForPostgreSqlFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource> GetCosmosDBForPostgreSqlNodeConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource>> GetCosmosDBForPostgreSqlNodeConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationCollection GetCosmosDBForPostgreSqlNodeConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> GetCosmosDBForPostgreSqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> GetCosmosDBForPostgreSqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionCollection GetCosmosDBForPostgreSqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> GetCosmosDBForPostgreSqlPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>> GetCosmosDBForPostgreSqlPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceCollection GetCosmosDBForPostgreSqlPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> GetCosmosDBForPostgreSqlRole(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>> GetCosmosDBForPostgreSqlRoleAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleCollection GetCosmosDBForPostgreSqlRoles() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PromoteReadReplica(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PromoteReadReplicaAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlClusterServerCollection() { }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> GetIfExists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>> GetIfExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterServerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>
    {
        public CosmosDBForPostgreSqlClusterServerData() { }
        public string AdministratorLogin { get { throw null; } }
        public string AvailabilityZone { get { throw null; } set { } }
        public string CitusVersion { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string HaState { get { throw null; } }
        public bool? IsHAEnabled { get { throw null; } set { } }
        public bool? IsPublicIPAccessEnabled { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string PostgresqlVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole? Role { get { throw null; } set { } }
        public string ServerEdition { get { throw null; } set { } }
        public string State { get { throw null; } }
        public int? StorageQuotaInMb { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlClusterServerResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string serverName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>
    {
        public CosmosDBForPostgreSqlConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType? DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsRestartRequired { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration> ServerRoleGroupConfigurations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlConfigurationResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlCoordinatorConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected CosmosDBForPostgreSqlCoordinatorConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlCoordinatorConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlCoordinatorConfigurationResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CosmosDBForPostgreSqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult> CheckCosmosDBForPostgreSqlClusterNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>> CheckCosmosDBForPostgreSqlClusterNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetCosmosDBForPostgreSqlCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> GetCosmosDBForPostgreSqlClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource GetCosmosDBForPostgreSqlClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterCollection GetCosmosDBForPostgreSqlClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetCosmosDBForPostgreSqlClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetCosmosDBForPostgreSqlClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource GetCosmosDBForPostgreSqlClusterServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource GetCosmosDBForPostgreSqlConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource GetCosmosDBForPostgreSqlCoordinatorConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource GetCosmosDBForPostgreSqlFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource GetCosmosDBForPostgreSqlNodeConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource GetCosmosDBForPostgreSqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource GetCosmosDBForPostgreSqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource GetCosmosDBForPostgreSqlRoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>
    {
        public CosmosDBForPostgreSqlFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? ProvisioningState { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlFirewallRuleResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlNodeConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected CosmosDBForPostgreSqlNodeConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlNodeConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlNodeConfigurationResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>
    {
        public CosmosDBForPostgreSqlPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>
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
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlPrivateLinkResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>
    {
        public CosmosDBForPostgreSqlPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlRoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>, System.Collections.IEnumerable
    {
        protected CosmosDBForPostgreSqlRoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleName, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> Get(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>> GetAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> GetIfExists(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>> GetIfExistsAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlRoleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>
    {
        public CosmosDBForPostgreSqlRoleData(string password) { }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlRoleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CosmosDBForPostgreSqlRoleResource() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string roleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlServerConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>
    {
        public CosmosDBForPostgreSqlServerConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType? DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsRestartRequired { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.CosmosDBForPostgreSql.Mocking
{
    public partial class MockableCosmosDBForPostgreSqlArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBForPostgreSqlArmClient() { }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource GetCosmosDBForPostgreSqlClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerResource GetCosmosDBForPostgreSqlClusterServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationResource GetCosmosDBForPostgreSqlConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlCoordinatorConfigurationResource GetCosmosDBForPostgreSqlCoordinatorConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleResource GetCosmosDBForPostgreSqlFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlNodeConfigurationResource GetCosmosDBForPostgreSqlNodeConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionResource GetCosmosDBForPostgreSqlPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResource GetCosmosDBForPostgreSqlPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleResource GetCosmosDBForPostgreSqlRoleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCosmosDBForPostgreSqlResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBForPostgreSqlResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetCosmosDBForPostgreSqlCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource>> GetCosmosDBForPostgreSqlClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterCollection GetCosmosDBForPostgreSqlClusters() { throw null; }
    }
    public partial class MockableCosmosDBForPostgreSqlSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCosmosDBForPostgreSqlSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult> CheckCosmosDBForPostgreSqlClusterNameAvailability(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>> CheckCosmosDBForPostgreSqlClusterNameAvailabilityAsync(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetCosmosDBForPostgreSqlClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterResource> GetCosmosDBForPostgreSqlClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CosmosDBForPostgreSql.Models
{
    public static partial class ArmCosmosDBForPostgreSqlModelFactory
    {
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterData CosmosDBForPostgreSqlClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string administratorLogin = null, string administratorLoginPassword = null, string provisioningState = null, string state = null, string postgresqlVersion = null, string citusVersion = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow maintenanceWindow = null, string preferredPrimaryZone = null, bool? isShardsOnCoordinatorEnabled = default(bool?), bool? isHAEnabled = default(bool?), string coordinatorServerEdition = null, int? coordinatorStorageQuotaInMb = default(int?), int? coordinatorVCores = default(int?), bool? isCoordinatorPublicIPAccessEnabled = default(bool?), string nodeServerEdition = null, int? nodeCount = default(int?), int? nodeStorageQuotaInMb = default(int?), int? nodeVCores = default(int?), bool? isNodePublicIPAccessEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem> serverNames = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.AzureLocation? sourceLocation = default(Azure.Core.AzureLocation?), System.DateTimeOffset? pointInTimeUTC = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> readReplicas = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent CosmosDBForPostgreSqlClusterNameAvailabilityContent(string name = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType resourceType = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult CosmosDBForPostgreSqlClusterNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch CosmosDBForPostgreSqlClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string administratorLoginPassword = null, string postgresqlVersion = null, string citusVersion = null, bool? isShardsOnCoordinatorEnabled = default(bool?), bool? isHAEnabled = default(bool?), string preferredPrimaryZone = null, string coordinatorServerEdition = null, int? coordinatorStorageQuotaInMb = default(int?), int? coordinatorVCores = default(int?), bool? isCoordinatorPublicIPAccessEnabled = default(bool?), string nodeServerEdition = null, int? nodeCount = default(int?), int? nodeStorageQuotaInMb = default(int?), int? nodeVCores = default(int?), bool? isNodePublicIPAccessEnabled = default(bool?), Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow maintenanceWindow = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlClusterServerData CosmosDBForPostgreSqlClusterServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serverEdition = null, int? storageQuotaInMb = default(int?), int? vCores = default(int?), bool? isHAEnabled = default(bool?), bool? isPublicIPAccessEnabled = default(bool?), bool? isReadOnly = default(bool?), string administratorLogin = null, string fullyQualifiedDomainName = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole? role = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole?), string state = null, string haState = null, string availabilityZone = null, string postgresqlVersion = null, string citusVersion = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlConfigurationData CosmosDBForPostgreSqlConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType? dataType = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType?), string allowedValues = null, bool? isRestartRequired = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration> serverRoleGroupConfigurations = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlFirewallRuleData CosmosDBForPostgreSqlFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateEndpointConnectionData CosmosDBForPostgreSqlPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlPrivateLinkResourceData CosmosDBForPostgreSqlPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlRoleData CosmosDBForPostgreSqlRoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string password = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.CosmosDBForPostgreSqlServerConfigurationData CosmosDBForPostgreSqlServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string source = null, string description = null, string defaultValue = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType? dataType = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType?), string allowedValues = null, bool? isRestartRequired = default(bool?), Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState? provisioningState = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem CosmosDBForPostgreSqlServerNameItem(string name = null, string fullyQualifiedDomainName = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration CosmosDBForPostgreSqlServerRoleGroupConfiguration(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole role = default(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole), string value = null, string defaultValue = null, string source = null) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection CosmosDBForPostgreSqlSimplePrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>
    {
        public CosmosDBForPostgreSqlClusterNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>
    {
        internal CosmosDBForPostgreSqlClusterNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>
    {
        public CosmosDBForPostgreSqlClusterPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string CitusVersion { get { throw null; } set { } }
        public string CoordinatorServerEdition { get { throw null; } set { } }
        public int? CoordinatorStorageQuotaInMb { get { throw null; } set { } }
        public int? CoordinatorVCores { get { throw null; } set { } }
        public bool? IsCoordinatorPublicIPAccessEnabled { get { throw null; } set { } }
        public bool? IsHAEnabled { get { throw null; } set { } }
        public bool? IsNodePublicIPAccessEnabled { get { throw null; } }
        public bool? IsShardsOnCoordinatorEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string NodeServerEdition { get { throw null; } set { } }
        public int? NodeStorageQuotaInMb { get { throw null; } set { } }
        public int? NodeVCores { get { throw null; } set { } }
        public string PostgresqlVersion { get { throw null; } set { } }
        public string PreferredPrimaryZone { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBForPostgreSqlConfigurationDataType : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBForPostgreSqlConfigurationDataType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType Boolean { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType Enumeration { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType Integer { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType Numeric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlConfigurationDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlMaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>
    {
        public CosmosDBForPostgreSqlMaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlMaintenanceWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBForPostgreSqlNameAvailabilityResourceType : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBForPostgreSqlNameAvailabilityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType ServerGroupsV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlNameAvailabilityResourceType right) { throw null; }
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
    public partial class CosmosDBForPostgreSqlPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>
    {
        public CosmosDBForPostgreSqlPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBForPostgreSqlProvisioningState : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBForPostgreSqlProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlServerNameItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>
    {
        internal CosmosDBForPostgreSqlServerNameItem() { }
        public string FullyQualifiedDomainName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerNameItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBForPostgreSqlServerRole : System.IEquatable<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBForPostgreSqlServerRole(string value) { throw null; }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole Coordinator { get { throw null; } }
        public static Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole Worker { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole left, Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBForPostgreSqlServerRoleGroupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>
    {
        public CosmosDBForPostgreSqlServerRoleGroupConfiguration(Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole role, string value) { }
        public string DefaultValue { get { throw null; } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRole Role { get { throw null; } set { } }
        public string Source { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlServerRoleGroupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CosmosDBForPostgreSqlSimplePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>
    {
        public CosmosDBForPostgreSqlSimplePrivateEndpointConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CosmosDBForPostgreSql.Models.CosmosDBForPostgreSqlSimplePrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
