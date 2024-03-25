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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>
    {
        public PostgreSqlConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlDatabaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>
    {
        public PostgreSqlDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>
    {
        public PostgreSqlFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>
    {
        public PostgreSqlPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>
    {
        public PostgreSqlPrivateLinkResourceData() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerAdministratorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>
    {
        public PostgreSqlServerAdministratorData() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType? AdministratorType { get { throw null; } set { } }
        public string LoginAccountName { get { throw null; } set { } }
        public System.Guid? SecureId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetIfExists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> GetIfExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>
    {
        public PostgreSqlServerData(Azure.Core.AzureLocation location) { }
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
        Azure.ResourceManager.PostgreSql.PostgreSqlServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> GetIfExists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> GetIfExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlServerKeyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>
    {
        public PostgreSqlServerKeyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType? ServerKeyType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> GetIfExists(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> GetIfExistsAsync(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>
    {
        public PostgreSqlServerSecurityAlertPolicyData() { }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public bool? SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> GetIfExists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>> GetIfExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlVirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>
    {
        public PostgreSqlVirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState? State { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetIfExists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetIfExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>
    {
        public PostgreSqlFlexibleServerActiveDirectoryAdministratorData() { }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>
    {
        public PostgreSqlFlexibleServerBackupData() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin? BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetIfExists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetIfExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>
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
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>
    {
        public PostgreSqlFlexibleServerData(Azure.Core.AzureLocation location) { }
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
        public int? ReplicaCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? State { get { throw null; } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? Version { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDatabaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>
    {
        public PostgreSqlFlexibleServerDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>
    {
        public PostgreSqlFlexibleServerFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking
{
    public partial class MockablePostgreSqlFlexibleServersArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlFlexibleServersArmClient() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource GetPostgreSqlFlexibleServerBackupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePostgreSqlFlexibleServersResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlFlexibleServersResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServer(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetPostgreSqlFlexibleServerAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerCollection GetPostgreSqlFlexibleServers() { throw null; }
    }
    public partial class MockablePostgreSqlFlexibleServersSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlFlexibleServersSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePostgreSqlFlexibleServersTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlFlexibleServersTenantResource() { }
        public virtual Azure.Response<string> ExecuteGetPrivateDnsZoneSuffix(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>
    {
        public PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent() { }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>
    {
        public PostgreSqlFlexibleServerAuthConfig() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAuthEnum? ActiveDirectoryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPasswordAuthEnum? PasswordAuth { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerBackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>
    {
        public PostgreSqlFlexibleServerBackupProperties() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum? GeoRedundantBackup { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerCapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>
    {
        internal PostgreSqlFlexibleServerCapabilityProperties() { }
        public bool? FastProvisioningSupported { get { throw null; } }
        public bool? IsGeoBackupSupported { get { throw null; } }
        public bool? IsZoneRedundantHAAndGeoBackupSupported { get { throw null; } }
        public bool? IsZoneRedundantHASupported { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> SupportedFastProvisioningEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAModes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability> SupportedHyperscaleNodeEditions { get { throw null; } }
        public string Zone { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>
    {
        public PostgreSqlFlexibleServerDataEncryption() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType? KeyType { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDelegatedSubnetUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>
    {
        internal PostgreSqlFlexibleServerDelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>
    {
        internal PostgreSqlFlexibleServerEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerFastProvisioningEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>
    {
        internal PostgreSqlFlexibleServerFastProvisioningEditionCapability() { }
        public string SupportedServerVersions { get { throw null; } }
        public string SupportedSku { get { throw null; } }
        public long? SupportedStorageGb { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerHighAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>
    {
        public PostgreSqlFlexibleServerHighAvailability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState? State { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerHyperscaleNodeEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>
    {
        internal PostgreSqlFlexibleServerHyperscaleNodeEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability> SupportedNodeTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerIdentityType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType None { get { throw null; } }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType SystemAssigned { get { throw null; } }
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
    public partial class PostgreSqlFlexibleServerMaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>
    {
        public PostgreSqlFlexibleServerMaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>
    {
        public PostgreSqlFlexibleServerNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerNameAvailabilityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>
    {
        internal PostgreSqlFlexibleServerNameAvailabilityResponse() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? Reason { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerNameAvailabilityResult : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>
    {
        internal PostgreSqlFlexibleServerNameAvailabilityResult() { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>
    {
        public PostgreSqlFlexibleServerNetwork() { }
        public Azure.Core.ResourceIdentifier DelegatedSubnetResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateDnsZoneArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerNodeTypeCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>
    {
        internal PostgreSqlFlexibleServerNodeTypeCapability() { }
        public string Name { get { throw null; } }
        public string NodeType { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? Version { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole GeoSyncReplica { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole None { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole Primary { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole Secondary { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole SyncReplica { get { throw null; } }
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
    public partial class PostgreSqlFlexibleServerRestartParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>
    {
        public PostgreSqlFlexibleServerRestartParameter() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public bool? RestartWithFailover { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerServerVersionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>
    {
        internal PostgreSqlFlexibleServerServerVersionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability> SupportedVCores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedVersionsToUpgrade { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>
    {
        public PostgreSqlFlexibleServerSku(string name, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier Tier { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerStorageCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>
    {
        internal PostgreSqlFlexibleServerStorageCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public long? StorageSizeInMB { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> SupportedUpgradableTierList { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>
    {
        internal PostgreSqlFlexibleServerStorageEditionCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> SupportedStorageCapabilities { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageTierCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>
    {
        internal PostgreSqlFlexibleServerStorageTierCapability() { }
        public long? Iops { get { throw null; } }
        public bool? IsBaseline { get { throw null; } }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public string TierName { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>
    {
        public PostgreSqlFlexibleServerUserAssignedIdentity(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType identityType) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType IdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerVCoreCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>
    {
        internal PostgreSqlFlexibleServerVCoreCapability() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVCoreInMB { get { throw null; } }
        public long? VCores { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>
    {
        public PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter() { }
        public Azure.Core.ResourceIdentifier VirtualNetworkArmResourceId { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>
    {
        internal PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.Mocking
{
    public partial class MockablePostgreSqlArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlArmClient() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource GetPostgreSqlConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseResource GetPostgreSqlDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleResource GetPostgreSqlFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource GetPostgreSqlPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource GetPostgreSqlPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorResource GetPostgreSqlServerAdministratorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource GetPostgreSqlServerKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerResource GetPostgreSqlServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource GetPostgreSqlServerSecurityAlertPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleResource GetPostgreSqlVirtualNetworkRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePostgreSqlResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetPostgreSqlServer(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource>> GetPostgreSqlServerAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerCollection GetPostgreSqlServers() { throw null; }
    }
    public partial class MockablePostgreSqlSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult> CheckPostgreSqlNameAvailability(Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>> CheckPostgreSqlNameAvailabilityAsync(Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties> GetLocationBasedPerformanceTiers(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties> GetLocationBasedPerformanceTiersAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetPostgreSqlServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.PostgreSqlServerResource> GetPostgreSqlServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PostgreSqlConfigurationList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>
    {
        public PostgreSqlConfigurationList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData> Value { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlLogFile : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>
    {
        public PostgreSqlLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string LogFileType { get { throw null; } set { } }
        public long? SizeInKB { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>
    {
        public PostgreSqlNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>
    {
        internal PostgreSqlNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlPerformanceTierProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>
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
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlPerformanceTierServiceLevelObjectives : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>
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
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlPrivateEndpointConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>
    {
        public PostgreSqlPrivateEndpointConnectionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>
    {
        internal PostgreSqlPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlPrivateLinkServiceConnectionStateProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>
    {
        public PostgreSqlPrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlRecoverableServerResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>
    {
        public PostgreSqlRecoverableServerResourceData() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
        public int? VCores { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlServerCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>
    {
        public PostgreSqlServerCreateOrUpdateContent(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate properties, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate Properties { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>
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
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPrivateEndpointConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>
    {
        internal PostgreSqlServerPrivateEndpointConnection() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>
    {
        internal PostgreSqlServerPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPrivateLinkServiceConnectionStateProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>
    {
        internal PostgreSqlServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PostgreSqlServerPropertiesForCreate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>
    {
        protected PostgreSqlServerPropertiesForCreate() { }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? Version { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPropertiesForDefaultCreate : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>
    {
        public PostgreSqlServerPropertiesForDefaultCreate(string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPropertiesForGeoRestore : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>
    {
        public PostgreSqlServerPropertiesForGeoRestore(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPropertiesForReplica : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>
    {
        public PostgreSqlServerPropertiesForReplica(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerPropertiesForRestore : Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>
    {
        public PostgreSqlServerPropertiesForRestore(Azure.Core.ResourceIdentifier sourceServerId, System.DateTimeOffset restorePointInTime) { }
        public System.DateTimeOffset RestorePointInTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>
    {
        public PostgreSqlSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PostgreSqlStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>
    {
        public PostgreSqlStorageProfile() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlGeoRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageAutogrow? StorageAutogrow { get { throw null; } set { } }
        public int? StorageInMB { get { throw null; } set { } }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
